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
    private string nsShaftLeaderboardContract;
    private string nsShaftLeaderboardAbi;
    private void Awake()
    {
        entryContainer = transform.Find("LeaderboardContainer");
        entryTemplate = entryContainer.Find("LeaderboardTemplate");
    }

    async private void Start()
    {
        chain = DataManager.CHAIN;
        network = DataManager.NETWORK;
        nsShaftLeaderboardContract = DataManager.NsShaftLeaderboardContract;
        nsShaftLeaderboardAbi = DataManager.NsShaftLeaderboardAbi;
        string method = "getUsersfromLeaderBoard";
        string args = "[]";
        string response = await EVM.Call(chain, network, nsShaftLeaderboardContract, nsShaftLeaderboardAbi, method, args);
        var userRankings = JsonConvert.DeserializeObject<string[][]>(response);

        for (int i = 0; i < loopCount; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -height * i);

            if (userRankings[i][1] != "0")
            {
                string address = userRankings[i][0].Substring(0, 4) + "..." + userRankings[i][0].Substring(userRankings[i][0].Length - 4);
                entryTransform.Find("addressDetails").GetComponent<Text>().text = address;
                entryTransform.Find("scoreDetails").GetComponent<Text>().text = userRankings[i][1];
            }
        }
    }

    public void ReturnGameScene()
    {
        Loader.LoadTargetScene(Loader.Scene.GameScene);
    }
}
