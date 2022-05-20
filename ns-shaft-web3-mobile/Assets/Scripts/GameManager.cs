using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    private static float objMoveSpeed = 2f;
    public Transform healthImageHolder;
    Image[] healthImages;
    public static int floor;
    int floorF, floorS, floorT;
    public Transform firstRow, secondRow, thirdRow;
    public Transform firstRow_, secondRow_, thirdRow_;
    public Text hiScoreText;
    public GameObject infoText;
    bool isPlaying;
    public GameObject getReayWindow;
    public event EventHandler OnOver;
    private Text totalTickets;
    public Transform ticketsSection;
    private static string account;
    private static string HI_SCORE;
    private string nsShaftTicketContract;
    private string nsShaftTicketAbi;
    private string nsShaftLeaderboardContract;
    private string nsShaftLeaderboardAbi;
    private int lifeLength;
    public GameObject difficultySection;
    private Text difficultyText;
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Impossible,
    }

    private void Awake()
    {
        S = this;
        totalTickets = ticketsSection.Find("balance").GetComponent<Text>();
        difficultyText = difficultySection.GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
        getReayWindow.SetActive(true);
        Time.timeScale = 0f;
        DataManager.InitData();
        DataManager.FetchTicketBalances();
        account = DataManager.account;
        lifeLength = TicketManager.GetLifeLengthFromLocal();
        Debug.Log("lifeLength " + lifeLength);
        HI_SCORE = account + "_hiScore";
        // SetObjectMoveSpeed(Difficulty.Easy);
        nsShaftTicketContract = DataManager.NsShaftTicketContract;
        nsShaftTicketAbi = DataManager.NsShaftTicketAbi;
        nsShaftLeaderboardContract = DataManager.NsShaftLeaderboardContract;
        nsShaftLeaderboardAbi = DataManager.NsShaftLeaderboardAbi;
        healthImages = new Image[lifeLength];
        for (int i = 0; i < healthImageHolder.childCount; i++)
        {
            healthImageHolder.GetChild(i).GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i] = healthImageHolder.GetChild(i).GetComponent<Image>();
            healthImages[i].enabled = true;
        }

        if (DataManager.GetTotalTickets() > 0)
        {
            infoText.GetComponent<Text>().text = "PRESS REDEEM TO REDEEM TICKETS";
        }
        else
        {
            infoText.GetComponent<Text>().text = "PRESS BUY TO BUY TICKETS";
        }

        totalTickets.text = "x " + DataManager.GetTotalTickets().ToString();
        int hiScore = GetHiScore();
        string zero = "000";
        hiScoreText.text = "RECORD: 地下 " + zero.Substring(0, zero.Length - hiScore.ToString().Length) + hiScore + " 階";
        InvokeRepeating("IncreaseFloor", 0f, 1.5f);
    }

    private void Update()
    {
        lifeLength = TicketManager.GetLifeLengthFromLocal();
        // difficultyText.text = "DIFFICULTY: " + GetDifficulty().ToString().ToUpper();
        // SetObjectMoveSpeed(GetDifficulty());

        if (!isPlaying)
        {
            if (lifeLength > 0)
            {
                infoText.GetComponentInChildren<Text>().text = "PRESS PLAY TO PLAY GAME";
            }
        }
    }

    void IncreaseFloor()
    {
        floor++;
        RenewFloor();
    }

    public static Difficulty GetDifficulty()
    {
        if (floor >= 30) return Difficulty.Impossible;
        if (floor >= 20) return Difficulty.Hard;
        if (floor >= 10) return Difficulty.Medium;
        return Difficulty.Easy;
    }

    // private void SetObjectMoveSpeed(Difficulty difficulty)
    // {
    //     switch (difficulty)
    //     {
    //         case (Difficulty.Impossible):
    //             objMoveSpeed = 6f;
    //             break;
    //         case (Difficulty.Hard):
    //             objMoveSpeed = 4.5f;
    //             break;
    //         case (Difficulty.Medium):
    //             objMoveSpeed = 3f;
    //             break;
    //         case (Difficulty.Easy):
    //             objMoveSpeed = 1.5f;
    //             break;
    //     }
    // }

    public static float GetObjMoveSpeed()
    {
        return objMoveSpeed;
    }

    public void LoadBuyScene()
    {
        Loader.LoadTargetScene(Loader.Scene.BuyScene);
    }

    public void LoadRedeemScene()
    {
        Loader.LoadTargetScene(Loader.Scene.RedeemScene);
    }

    public void LoadLeaderboardScene()
    {
        Loader.LoadTargetScene(Loader.Scene.LeaderboardScene);
    }

    public void Play()
    {
        if (lifeLength > 0)
        {
            isPlaying = true;
            Time.timeScale = 1f;
            getReayWindow.SetActive(false);
        }
    }

    async public void PurchaseTicket(string purchasedValue, int ticketType, int ticketAmount)
    {
        string gasLimit = "";
        string method = "buyTicket";
        string gasPrice = "";
        string args = $"[\"{ticketType}\",\"{ticketAmount}\"]";
        Debug.Log("PurchaseTicket is in");
        Loader.LoadTargetScene(Loader.Scene.LoadingScene);
        LoadingManager.UpdateTextInfo("Purchasing");

        try
        {
            string response = await Web3GL.SendContract(method, nsShaftTicketAbi, nsShaftTicketContract, args, purchasedValue, gasLimit, gasPrice);
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

    async public void Sync()
    {
        string gasLimit = "";
        string method = "addScore";
        string gasPrice = "";
        string args = $"[\"{account}\",\"{floor}\"]";
        Debug.Log("Sync function is in");
        Loader.LoadTargetScene(Loader.Scene.LoadingScene);
        LoadingManager.UpdateTextInfo("Syncing");
        try
        {
            string response = await Web3GL.SendContract(method, nsShaftLeaderboardAbi, nsShaftLeaderboardContract, args, gasLimit, gasPrice);
            Debug.Log("Sync function" + response);
            Loader.LoadTargetScene(Loader.Scene.LeaderboardScene);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Loader.LoadTargetScene(Loader.Scene.GameScene);
        }
    }

    async public void RedeemTicket(int ticketType)
    {
        string gasLimit = "";
        string method = "redeemTicket";
        string gasPrice = "";
        string args = $"[\"{ticketType}\"]";
        try
        {
            Debug.Log("RedeemTicket is in");
            Loader.LoadTargetScene(Loader.Scene.LoadingScene);
            LoadingManager.UpdateTextInfo("Redeeming");
            string response = await Web3GL.SendContract(method, nsShaftTicketAbi, nsShaftTicketContract, args, gasLimit, gasPrice);
            Debug.Log("RedeemTicket >>>>> " + response);
            if (response != null && response.Length > 0)
            {
                TicketManager.SetLifeLengthToLocal();
                Loader.LoadTargetScene(Loader.Scene.GameScene);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Loader.LoadTargetScene(Loader.Scene.RedeemScene);
        }
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RenewHealthBar(int health)
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < health)
                healthImages[i].enabled = true;
            else
                healthImages[i].enabled = false;
        }
    }

    void RenewFloor()
    {
        int f = floor / 100;
        int s = (floor - 100 * f) / 10;
        int t = floor % 10;

        if (floorF != f)
        {
            RenewFloorUI(0, floorF, f);
            floorF = f;
        }

        if (floorS != s)
        {
            RenewFloorUI(1, floorS, s);
            floorS = s;
        }

        if (floorT != t)
        {
            RenewFloorUI(2, floorT, t);
            floorT = t;
        }
    }

    void RenewFloorUI(int row, int originNumber, int newNumber)
    {
        Transform upperText = null;
        Transform lowerText = null;
        Vector3 upperTextPos;
        Vector3 lowerTextPos;

        switch (row)
        {
            case 0:
                {
                    upperText = firstRow.position.y > firstRow_.position.y ? firstRow : firstRow_;
                    lowerText = firstRow.position.y < firstRow_.position.y ? firstRow : firstRow_;
                    break;
                }
            case 1:
                {
                    upperText = secondRow.position.y > secondRow_.position.y ? secondRow : secondRow_;
                    lowerText = secondRow.position.y < secondRow_.position.y ? secondRow : secondRow_;
                    break;
                }
            case 2:
                {
                    upperText = thirdRow.position.y > thirdRow_.position.y ? thirdRow : thirdRow_;
                    lowerText = thirdRow.position.y < thirdRow_.position.y ? thirdRow : thirdRow_;
                    break;
                }
        }

        upperTextPos = upperText.position;
        lowerTextPos = lowerText.position;
        upperText.GetComponent<Text>().text = originNumber.ToString();
        lowerText.GetComponent<Text>().text = newNumber.ToString();

        StartCoroutine(MoveText(lowerText, lowerTextPos, upperTextPos));
        StartCoroutine(MoveText(upperText, upperTextPos, upperTextPos + (upperTextPos - lowerTextPos), lowerTextPos));

    }

    IEnumerator MoveText(Transform textToMove, Vector3 originPos, Vector3 targetPos)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            textToMove.position = originPos + (targetPos - originPos) * percent;

            yield return null;
        }

        textToMove.position = targetPos;
    }

    IEnumerator MoveText(Transform textToMove, Vector3 originPos, Vector3 targetPos, Vector3 teleportPos)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            textToMove.position = originPos + (targetPos - originPos) * percent;

            yield return null;
        }

        textToMove.position = teleportPos;
    }

    public void GameOver()
    {
        isPlaying = false;

        int hiScore = GetHiScore();
        if (floor > hiScore)
        {
            SetHiScore(floor);
        }

        string key = account + TicketManager.LIFE_LENGTH;
        PlayerPrefs.SetInt(key, 0);
        Time.timeScale = 0;
        if (OnOver != null) OnOver(this, EventArgs.Empty);
    }

    public void SetHiScore(int floorNumber)
    {
        PlayerPrefs.SetInt(HI_SCORE, floorNumber);
    }

    public static int GetHiScore()
    {
        return PlayerPrefs.GetInt(HI_SCORE);
    }
}
