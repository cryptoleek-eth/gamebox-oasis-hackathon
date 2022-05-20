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
    public static string NsShaftTicketContract = "0x2cB049C7cE171B78c11e7048471605EADCc6104a";
    public static string NsShaftLeaderboardContract = "0x0903BDD547388b85bAe2b025D2f354877912D63C";
    public static string NsShaftTicketAbi = Resources.Load<TextAsset>("Abis/nsShaftTicket").ToString();
    public static string NsShaftLeaderboardAbi = Resources.Load<TextAsset>("Abis/nsShaftLeaderboard").ToString();
    public static string TOTAL_TICKETS;
    private static List<string> ticketBalances;
    public static string account;
    public static void InitData()
    {
        account = PlayerPrefs.GetString("Account");
        // account = "0x0782a1e303F8D8DdaE98ffdf56D8142E8B19217f";
        TOTAL_TICKETS = account + "_tickets";
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
            BigInteger balanceOf = await ERC1155.BalanceOf(CHAIN, NETWORK, NsShaftTicketContract, account, tokenId);
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


