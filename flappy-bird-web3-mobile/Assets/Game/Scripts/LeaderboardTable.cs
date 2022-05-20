using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;

public class LeaderboardTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private float height = 50f;
    private int loopCount = 10;
    private string chain;
    private string network;
    private string flappyBirdLeaderboardContract;
    private string flappyBirdLeaderboardAbi;
    private void Awake()
    {
        entryContainer = transform.Find("leaderboardEntryContainer");
        entryTemplate = entryContainer.Find("leaderboardEntryTemplate");
    }

    async private void Start()
    {
        chain = DataManager.CHAIN;
        network = DataManager.NETWORK;
        flappyBirdLeaderboardContract = DataManager.FlappyBirdLeaderboardContract;
        flappyBirdLeaderboardAbi = DataManager.FlappyBirdLeaderboardAbi;
        string method = "getUsersfromLeaderBoard";
        string args = "[]";
        string response = await EVM.Call(chain, network, flappyBirdLeaderboardContract, flappyBirdLeaderboardAbi, method, args);
        var userRankings = JsonConvert.DeserializeObject<string[][]>(response);

        for (int i = 0; i < loopCount; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -height * i);

            if (userRankings[i][1] != "0")
            {
                entryTransform.Find("addressDetails").GetComponent<Text>().text = userRankings[i][0];
                entryTransform.Find("scoreDetails").GetComponent<Text>().text = userRankings[i][1];
            }
        }
    }
}
