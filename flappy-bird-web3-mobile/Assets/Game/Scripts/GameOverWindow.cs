using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;
    private Text infoText;
    public GameObject syncButton;

    private void Awake()
    {
        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        scoreText = transform.Find("PopUp/scoreText").GetComponent<Text>();
        infoText = transform.Find("PopUp/infoText").GetComponent<Text>();
    }

    private void Start()
    {
        Hide();
        GameManager.G.OnOver += Game_OnOver;
        GameManager.G.OnRestart += Game_OnRestart;
    }

    private void Game_OnRestart(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Game_OnOver(object sender, System.EventArgs e)
    {
        Show();
        int highestScore = GameManager.GetHighestScore();
        int currentScore = Int32.Parse(GameManager.score.ToString());
        Debug.Log("currentScore " + currentScore);
        GameManager.G.addressText.enabled = false;
        scoreText.text = "HIGHEST SCORE: " + highestScore;

        if (currentScore < highestScore)
        {
            infoText.text = "Unfortnately, you didn't achieve \n your highest score. Please tray again.";
            syncButton.SetActive(false);
        }
        else
        {
            infoText.text = "Congratulations, you have achieved \n your highest score. You can sync now.";
            syncButton.SetActive(true);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
