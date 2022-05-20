using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeWindow : MonoBehaviour
{
    private Text LifeText;
    private int lifeCount;
    private string account;

    private void Awake()
    {
        LifeText = transform.Find("LifeCount").GetComponent<Text>();
    }

    private void Start()
    {
        account = DataManager.account;
    }

    private void Update()
    {
        lifeCount = GameManager.GetLifeCount();
        LifeText.text = "x " + lifeCount.ToString();
    }
}
