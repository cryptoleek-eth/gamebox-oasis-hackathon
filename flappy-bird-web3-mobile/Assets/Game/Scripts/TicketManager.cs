using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using TMPro;

public class TicketManager : MonoBehaviour
{
    public List<Transform> tickets;
    public Ticket selectedBuyTicket;
    public Ticket selectedRedeemTicket;
    public int purchaseTicketAmount;
    private int[] purchaseTicketAmountArray = new int[3] { 1, 1, 1 };
    public int selectedTicketIndex;
    private Text buyButtonText;

    public enum TicketType
    {
        Gold,
        Silver,
        Bronze,
    }

    private List<string> ticketBalances;
    private void Awake()
    {
        for (int i = 0; i < tickets.Count; i++)
        {
            tickets[i].Find("selected").GetComponent<Image>().enabled = false;
        }
    }

    async private void Start()
    {
        selectedTicketIndex = 0;
        if (Loader.targetScene == Loader.Scene.BuyScene)
        {
            buyButtonText = transform.Find("BuyButton/ButtonText").GetComponent<Text>();
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
                    tickets[i].Find("balance").GetComponent<Text>().text = "x " + ticketBalances[i];
                }

            }
        }
    }

    public void OnTicketSelected(int index)
    {
        selectedTicketIndex = index;
        switch (selectedTicketIndex)
        {
            case 1:
                tickets[0].Find("selected").GetComponent<Image>().enabled = true;
                tickets[1].Find("selected").GetComponent<Image>().enabled = false;
                tickets[2].Find("selected").GetComponent<Image>().enabled = false;

                if (Loader.targetScene == Loader.Scene.BuyScene)
                {
                    tickets[0].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = true;
                    tickets[1].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = false;
                    tickets[2].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = false;
                }

                break;
            case 2:
                tickets[0].Find("selected").GetComponent<Image>().enabled = false;
                tickets[1].Find("selected").GetComponent<Image>().enabled = true;
                tickets[2].Find("selected").GetComponent<Image>().enabled = false;

                if (Loader.targetScene == Loader.Scene.BuyScene)
                {
                    tickets[0].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = false;
                    tickets[1].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = true;
                    tickets[2].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = false;
                }
                break;
            case 3:
                tickets[0].Find("selected").GetComponent<Image>().enabled = false;
                tickets[1].Find("selected").GetComponent<Image>().enabled = false;
                tickets[2].Find("selected").GetComponent<Image>().enabled = true;

                if (Loader.targetScene == Loader.Scene.BuyScene)
                {
                    tickets[0].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = false;
                    tickets[1].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = false;
                    tickets[2].Find("Dropdown").GetComponent<TMPro.TMP_Dropdown>().enabled = true;
                }

                break;
        }

        if (SceneManager.GetActiveScene().name == Loader.Scene.BuyScene.ToString())
        {
            selectedBuyTicket.name = GetTicketName();
            selectedBuyTicket.ticketType = selectedTicketIndex;
            selectedBuyTicket.price = GetTicketPrice();
            purchaseTicketAmount = purchaseTicketAmountArray[index - 1];
        }
        else
        {
            selectedRedeemTicket.name = GetTicketName();
            selectedRedeemTicket.ticketType = selectedTicketIndex;
            selectedRedeemTicket.price = GetTicketPrice();
            selectedRedeemTicket.balance = ticketBalances[selectedTicketIndex - 1];
        }
    }

    private void Update()
    {
        if (Loader.targetScene == Loader.Scene.BuyScene)
        {
            if (selectedTicketIndex > 0)
            {
                purchaseTicketAmountArray[selectedTicketIndex - 1] = purchaseTicketAmount;
                buyButtonText.text = "Buy (" + purchaseTicketAmountArray[selectedTicketIndex - 1] + ")";
            }
            else
            {
                buyButtonText.text = "Buy (1)";
            }
        }
    }

    public void ReturnToMainScene()
    {
        Loader.LoadTargetScene(Loader.Scene.GameScene);
    }

    public void PurchaseTicket()
    {
        if (selectedBuyTicket.ticketType > 0)
        {
            int ticketAmount = purchaseTicketAmountArray[selectedTicketIndex - 1];
            string purchasedValue = GetFullValue(selectedBuyTicket.price, ticketAmount);
            GameManager.G.PurchaseTicket(purchasedValue, selectedBuyTicket.ticketType, ticketAmount);
        }
        else
        {
            Debug.Log("Ticket is not selected");
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
                purchaseTicketAmount = 5;
                break;
            case 2:
                purchaseTicketAmount = 10;
                break;
        }
    }

    public void RedeemTicket()
    {
        if (selectedRedeemTicket.ticketType > 0 && Int32.Parse(selectedRedeemTicket.balance) > 0)
        {
            GameManager.G.RedeemTicket(selectedRedeemTicket.ticketType);
        }
        else
        {
            Debug.Log("The selected ticket balance is 0 or Ticket is not selected");
        }
    }


    public string GetTicketName()
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

    public float GetTicketPrice()
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

    public string GetFullValue(float value, int amount)
    {
        BigInteger valueMultily = BigInteger.Pow(10, 18);
        double dValueMultily = (double)valueMultily;
        double result = Math.Round((double)value, 2) * dValueMultily;
        BigInteger fullValue = BigInteger.Multiply(amount, new BigInteger(result));
        return fullValue.ToString();
    }
}
