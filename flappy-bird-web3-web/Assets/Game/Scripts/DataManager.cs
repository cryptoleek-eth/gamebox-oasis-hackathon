using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class DataManager
{
    public static string CHAIN = "ethereum";
    public static string NETWORK = "kovan";
    public static string FlappyBirdTicketContract = "0x2cB049C7cE171B78c11e7048471605EADCc6104a";
    public static string FlappyBirdLeaderboardContract = "0xaaF06DCBAfcCE286446Af33B05C0222A3160FEd8";
    public static string FlappyBirdTicketAbi = Resources.Load<TextAsset>("Abis/flappyBirdTicket").ToString();
    public static string FlappyBirdLeaderboardAbi = Resources.Load<TextAsset>("Abis/flappyBirdLeaderboard").ToString();
    public static string TOTAL_TICKETS = "TOTAL_TICKETS";
    private static List<string> ticketBalances;
    public static string account;
    public static void InitData()
    {
        account = PlayerPrefs.GetString("Account");
        // account = "0x0782a1e303F8D8DdaE98ffdf56D8142E8B19217f";
    }

    async public static void FetchTicketBalances()
    {
        BigInteger totalAmount = 0;
        List<string> ticketBalanceList = new List<string>();

        for (int i = 1; i < 4; i++)
        {
            string tokenId = $"{i}";
            account = PlayerPrefs.GetString("Account");
            // account = "0x0782a1e303F8D8DdaE98ffdf56D8142E8B19217f";
            BigInteger balanceOf = await ERC1155.BalanceOf(CHAIN, NETWORK, FlappyBirdTicketContract, account, tokenId);
            ticketBalanceList.Add(balanceOf.ToString());
            totalAmount += balanceOf;
        }

        SetTicketBalances(ticketBalanceList);
        string key = account + TOTAL_TICKETS;
        PlayerPrefs.SetInt(key, (int)totalAmount);
        PlayerPrefs.Save();
    }

    public static void SetTicketBalances(List<string> tickets)
    {
        ticketBalances = tickets;
    }

    public static List<string> GetTicketBalances()
    {
        return ticketBalances;
    }

    public static int GetTotalTickets()
    {
        account = PlayerPrefs.GetString("Account");
        // account = "0x0782a1e303F8D8DdaE98ffdf56D8142E8B19217f";
        string key = account + TOTAL_TICKETS;
        int totalAmount = PlayerPrefs.GetInt(key);
        return totalAmount;
    }
}




