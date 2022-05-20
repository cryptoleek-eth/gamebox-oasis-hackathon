using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static SafeFloat score;
    public Text scoreText;
    public GameObject playButton;
    public GameObject getReady;
    public GameObject leaderBoardScene;
    public Player player;
    public Text addressText;
    public static GameManager G;
    public string[] ticketsBalance;
    private UnityEngine.Vector3 addressTextOriginalPosition;
    public event EventHandler OnOver;
    public event EventHandler OnRestart;
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Impossible,
    }
    public string account;
    public int lifeCount;
    public int totalTickets;
    public string flappyBirdTicketContract;
    public string flappyBirdLeaderboardContract;
    public string flappyBirdTicketAbi;
    public string flappyBirdLeaderboardAbi;
    private static string CURRENT_LIVES;
    private static string HIGHEST_SCORE;

    public SoundAudioClip[] SoundAudioClipArray;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        G = this;
        Pause();
    }

    private void Start()
    {
        DataManager.InitData();
        account = DataManager.account;
        CURRENT_LIVES = account + "_lives";
        HIGHEST_SCORE = account + "_score";
        flappyBirdTicketContract = DataManager.FlappyBirdTicketContract;
        flappyBirdLeaderboardContract = DataManager.FlappyBirdLeaderboardContract;
        flappyBirdTicketAbi = DataManager.FlappyBirdTicketAbi;
        flappyBirdLeaderboardAbi = DataManager.FlappyBirdLeaderboardAbi;
        addressText.text = account.Substring(0, 4);
        addressTextOriginalPosition = addressText.transform.position;
        lifeCount = GetLifeCount();
        score = new SafeFloat();
        getReady.SetActive(true);
        DataManager.FetchTicketBalances();
        Debug.Log("Web game initialised");
    }

    // public void Json2Obj()
    // {
    //     string receiptJson = Resources.Load<TextAsset>("Mocks/receipt").ToString();
    //     Web3Receipt myObject = JsonUtility.FromJson<Web3Receipt>(receiptJson);
    //     Debug.Log(myObject.events[1].returnValues[2].key);
    // }

    // public void Obj2Json()
    // {
    //     // SerializableList<string> names = new SerializableList<string>();
    //     // names.list.Add("Mark");
    //     // names.list.Add("Luke");

    //     // string json = JsonUtility.ToJson(names);

    //     // Debug.Log(json);

    //     Web3Receipt web3Receipt = new Web3Receipt();
    //     web3Receipt.blockHash = "0x1234";
    //     web3Receipt.blockNumber = 1;

    //     EventObj obj1 = new EventObj();
    //     obj1.address = "0x111";

    //     ReturnValuePair pair1 = new ReturnValuePair();
    //     pair1.key = "pair1Key";
    //     pair1.value = "pair1Value";

    //     ReturnValuePair pair2 = new ReturnValuePair();
    //     pair2.key = "pair222Key";
    //     pair2.value = "pair222Value";

    //     List<ReturnValuePair> returnValuesList = new List<ReturnValuePair>();
    //     returnValuesList.Add(pair1);
    //     returnValuesList.Add(pair2);
    //     obj1.returnValues = returnValuesList;

    //     EventObj obj2 = new EventObj();
    //     obj2.address = "0x222";

    //     List<EventObj> eventObjs = new List<EventObj>();
    //     eventObjs.Add(obj1);
    //     eventObjs.Add(obj2);

    //     web3Receipt.events = eventObjs;

    //     string jsoonUtin = Jslity.ToJson(web3Receipt);

    //     Debug.Log("web3Receipt obj 2 json " + json);
    // }

    public void LoadLeaderboardScene()
    {
        Loader.LoadTargetScene(Loader.Scene.LeaderboardScene);
    }

    public void LoadBuyTicketScene()
    {
        Loader.LoadTargetScene(Loader.Scene.BuyScene);
    }

    public void LoadRedeemScene()
    {
        Loader.LoadTargetScene(Loader.Scene.RedeemScene);
    }

    private void Update()
    {
        lifeCount = GetLifeCount();
    }

    async public void PurchaseTicket(string purchasedValue, int ticketType, int ticketAmount)
    {
        string gasLimit = "";
        string method = "buyTicket";
        string gasPrice = "";
        string args = $"[\"{ticketType}\",\"{ticketAmount}\"]";
        try
        {
            Debug.Log("PurchaseTicket is in");
            Loader.LoadTargetScene(Loader.Scene.LoadingScene);
            LoadingManager.UpdateTextInfo("Purchasing");
            string response = await Web3GL.SendContract(method, flappyBirdTicketAbi, flappyBirdTicketContract, args, purchasedValue, gasLimit, gasPrice);
            Debug.Log("PurchaseTicket finish");
            Debug.Log("buyTicket Response >>>>>" + response);
            Loader.LoadTargetScene(Loader.Scene.GameScene);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Loader.LoadTargetScene(Loader.Scene.BuyScene);
        }
    }

    async public void RedeemTicket(int ticketType)
    {
        // ResetLifeInfo(account, 2);
        string gasLimit = "";
        string method = "redeemTicket";
        string gasPrice = "";
        string args = $"[\"{ticketType}\"]";
        try
        {
            Debug.Log("RedeemTicket is in");
            Loader.LoadTargetScene(Loader.Scene.LoadingScene);
            LoadingManager.UpdateTextInfo("Redeeming");
            string response = await Web3GL.SendContract(method, flappyBirdTicketAbi, flappyBirdTicketContract, args, gasLimit, gasPrice);
            Debug.Log("Redeem Ticket Response" + response);

            Web3Receipt web3Receipt = JsonUtility.FromJson<Web3Receipt>(response);
            List<EventObj> eventObjs = web3Receipt.events;

            foreach (EventObj eo in eventObjs)
            {
                if (eo.name.ToLower() == "redeem")
                {
                    List<ReturnValuePair> returnValuesList = eo.returnValues;

                    for (int i = 0; i < returnValuesList.Count; i++)
                    {
                        if (returnValuesList[i].key == "noOfLives")
                        {
                            lifeCount = Int32.Parse(returnValuesList[i].value.ToString());
                            ResetLifeInfo(lifeCount);
                            break;
                        }
                    }
                }
            }

            Loader.LoadTargetScene(Loader.Scene.GameScene);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Loader.LoadTargetScene(Loader.Scene.RedeemScene);
        }
    }

    async public void Sync()
    {
        string gasLimit = "";
        string method = "addScore";
        string gasPrice = "";
        string args = $"[\"{account}\",\"{GetHighestScore()}\"]";
        Debug.Log("Sync function is in");
        Loader.LoadTargetScene(Loader.Scene.LoadingScene);
        LoadingManager.UpdateTextInfo("Syncing...");
        string response = await Web3GL.SendContract(method, flappyBirdLeaderboardAbi, flappyBirdLeaderboardContract, args, gasLimit, gasPrice);
        Debug.Log("Sync function" + response);
        Loader.LoadTargetScene(Loader.Scene.LeaderboardScene);
    }

    public void Play()
    {
        if (lifeCount > 0)
        {
            score = new SafeFloat();
            scoreText.text = score.GetValue().ToString();
            addressText.enabled = true;

            getReady.SetActive(false);
            playButton.SetActive(false);
            Time.timeScale = 1f;
            player.enabled = true;

            Pipes[] pipes = FindObjectsOfType<Pipes>();

            for (int i = 0; i < pipes.Length; i++)
            {
                Destroy(pipes[i].gameObject);
            }

            if (OnRestart != null) OnRestart(this, EventArgs.Empty);
        }
        else if (DataManager.GetTotalTickets() > 0)
        {
            Loader.LoadTargetScene(Loader.Scene.RedeemScene);
            Debug.Log("Please redeem the ticket first");
        }
        else
        {
            Loader.LoadTargetScene(Loader.Scene.BuyScene);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void IncreaseScore()
    {
        float oldScore = score.GetValue();
        score = new SafeFloat(++oldScore);
        scoreText.text = score.GetValue().ToString();
    }

    public void GameOver()
    {
        if (lifeCount > 0)
        {
            getReady.SetActive(false);
            playButton.SetActive(true);
            addressText.transform.position = addressTextOriginalPosition;
            int currentScore = Int32.Parse(score.ToString());
            if (currentScore > GetHighestScore())
            {
                ResetHighestScore(currentScore);
            }
            lifeCount--;
            ResetLifeInfo(lifeCount);
            Pause();
        }

        if (OnOver != null) OnOver(this, EventArgs.Empty);
    }

    public static Difficulty GetDifficulty()
    {
        int currentScore = Int32.Parse(score.ToString());
        if (currentScore >= 60) return Difficulty.Impossible;
        if (currentScore >= 40) return Difficulty.Hard;
        if (currentScore >= 20) return Difficulty.Medium;
        return Difficulty.Easy;
    }

    public static int GetLifeCount()
    {
        int currentLives = PlayerPrefs.GetInt(CURRENT_LIVES);
        // int currentLives = 3;
        return currentLives;
    }
    public static void ResetLifeInfo(int lifeCount)
    {
        PlayerPrefs.SetInt(CURRENT_LIVES, lifeCount);
        PlayerPrefs.Save();
    }

    public static int GetHighestScore()
    {
        int highScore = PlayerPrefs.GetInt(HIGHEST_SCORE);
        return highScore;
    }

    public static void ResetHighestScore(int score)
    {
        PlayerPrefs.SetInt(HIGHEST_SCORE, score);
        PlayerPrefs.Save();
    }

}
