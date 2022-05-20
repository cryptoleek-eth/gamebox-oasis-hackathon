using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Numerics;
using System;
using Cysharp.Threading.Tasks;

public class TicketManager : MonoBehaviour
{
    public List<Transform> tickets;
    public Ticket selectedBuyTicket;
    public Ticket selectedRedeemTicket;
    private Text buyButtonText;
    public static int selectedTicketIndex;
    public int purchaseTicketAmount = 1;
    public static string LIFE_LENGTH = "LIFE_LENGTH";
    private static string account;
    public enum TicketType
    {
        Gold,
        Silver,
        Bronze,
    }

    private List<string> ticketBalances;

    async private void Start()
    {
        DataManager.InitData();
        account = DataManager.account;

        if (Loader.targetScene == Loader.Scene.BuyScene)
        {
            buyButtonText = transform.Find("BuyButton/buttonText").GetComponent<Text>();
        }

        if (Loader.targetScene == Loader.Scene.RedeemScene)
        {
            ticketBalances = DataManager.GetTicketBalances();
            DataManager.FetchTicketBalances();

            while (ticketBalances.Count != 3 || ticketBalances == null)
            {
                ticketBalances = DataManager.GetTicketBalances();
                Debug.Log("ticketBalances" + ticketBalances.Count);
                await UniTask.Delay(TimeSpan.FromSeconds(1), ignoreTimeScale: true);
            }

            for (int i = 0; i < ticketBalances.Count; i++)
            {
                if (Int32.Parse(ticketBalances[i]) >= 0)
                {
                    tickets[i].Find("ticketBalance").GetComponent<Text>().text = "x " + ticketBalances[i];
                }

            }
        }
    }

    private void Awake()
    {
        for (int i = 0; i < tickets.Count; i++)
        {
            tickets[i].Find("selectedImage").GetComponent<Image>().enabled = false;
        }
    }

    private void Update()
    {
        if (Loader.targetScene == Loader.Scene.BuyScene)
        {
            buyButtonText.text = "Buy Ticket (" + purchaseTicketAmount + ")";
        }
    }

    public void OnTicketSelected(int index)
    {
        selectedTicketIndex = index;
        switch (selectedTicketIndex)
        {
            case 1:
                tickets[0].Find("selectedImage").GetComponent<Image>().enabled = true;
                tickets[1].Find("selectedImage").GetComponent<Image>().enabled = false;
                tickets[2].Find("selectedImage").GetComponent<Image>().enabled = false;
                break;
            case 2:
                tickets[0].Find("selectedImage").GetComponent<Image>().enabled = false;
                tickets[1].Find("selectedImage").GetComponent<Image>().enabled = true;
                tickets[2].Find("selectedImage").GetComponent<Image>().enabled = false;
                break;
            case 3:
                tickets[0].Find("selectedImage").GetComponent<Image>().enabled = false;
                tickets[1].Find("selectedImage").GetComponent<Image>().enabled = false;
                tickets[2].Find("selectedImage").GetComponent<Image>().enabled = true;
                break;
        }

        if (SceneManager.GetActiveScene().name == Loader.Scene.BuyScene.ToString())
        {
            selectedBuyTicket.name = GetTicketName();
            selectedBuyTicket.ticketType = selectedTicketIndex;
            selectedBuyTicket.price = GetTicketPrice();
        }
        else
        {
            selectedRedeemTicket.name = GetTicketName();
            selectedRedeemTicket.ticketType = selectedTicketIndex;
            selectedRedeemTicket.price = GetTicketPrice();
            selectedRedeemTicket.balance = ticketBalances[selectedTicketIndex - 1];
            selectedRedeemTicket.lifeLength = GetLifeLength();
            // SetLifeLengthToLocal();
        }
    }

    public void BackToGameScene()
    {
        Loader.LoadTargetScene(Loader.Scene.GameScene);
    }

    public void PurchaseTicket()
    {
        if (selectedBuyTicket.ticketType > 0)
        {
            // Debug.Log("purchased ticket " + selectedBuyTicket.ticketAmount);
            string purchasedValue = GetFullValue(selectedBuyTicket.price, purchaseTicketAmount);
            GameManager.S.PurchaseTicket(purchasedValue, selectedBuyTicket.ticketType, purchaseTicketAmount);
        }
        else
        {
            Debug.Log("Ticket is not selected");
        }
    }

    public void RedeemTicket()
    {
        if (selectedRedeemTicket.ticketType > 0 && Int32.Parse(selectedRedeemTicket.balance) > 0)
        {
            GameManager.S.RedeemTicket(selectedRedeemTicket.ticketType);
        }
        else
        {
            Debug.Log("The selected ticket balance is 0 or Ticket is not selected");
        }
    }

    public void OnDropDownChanged(int val)
    {
        switch (val)
        {
            case 0:
                purchaseTicketAmount = 1;
                break;
            case 1:
                purchaseTicketAmount = 2;
                break;
            case 2:
                purchaseTicketAmount = 3;
                break;
        }
    }

    private string GetTicketName()
    {
        string ticketType = "";
        switch (selectedTicketIndex)
        {
            case 1:
                ticketType = TicketType.Bronze.ToString();
                break;
            case 2:
                ticketType = TicketType.Silver.ToString();
                break;
            case 3:
                ticketType = TicketType.Gold.ToString();
                break;
        }

        return ticketType;
    }

    private float GetTicketPrice()
    {
        float ticketPrice = 0f;
        switch (selectedTicketIndex)
        {

            case 1:
                ticketPrice = 0.1f;
                break;
            case 2:
                ticketPrice = 0.2f;
                break;
            case 3:
                ticketPrice = 0.3f;
                break;
        }

        return ticketPrice;
    }

    private static int GetLifeLength()
    {
        int lifeLength = 0;
        switch (selectedTicketIndex)
        {
            case 1:
                lifeLength = 5;
                break;
            case 2:
                lifeLength = 10;
                break;
            case 3:
                lifeLength = 15;
                break;
        }
        return lifeLength;
    }

    public string GetFullValue(float value, int amount)
    {
        BigInteger valueMultily = BigInteger.Pow(10, 18);
        double dValueMultily = (double)valueMultily;
        double result = Math.Round((double)value, 2) * dValueMultily;
        BigInteger fullValue = BigInteger.Multiply(amount, new BigInteger(result));
        return fullValue.ToString();
    }

    public static void SetLifeLengthToLocal()
    {
        int lifeLength = GetLifeLength();
        string key = account + LIFE_LENGTH;
        PlayerPrefs.SetInt(key, lifeLength);
    }

    public static int GetLifeLengthFromLocal()
    {
        string key = account + LIFE_LENGTH;
        return PlayerPrefs.GetInt(key);
        // return 15;
    }
}
