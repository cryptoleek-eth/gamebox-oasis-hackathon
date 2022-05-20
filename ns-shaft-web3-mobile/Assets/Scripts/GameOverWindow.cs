using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Text infoText;
    private void Awake()
    {
        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        infoText = transform.Find("infoText").GetComponent<Text>();
    }

    void Start()
    {
        Hide();
        GameManager.S.OnOver += Game_OnOver;
    }

    private void Game_OnOver(object sender, System.EventArgs e)
    {
        Show();
        int highestScore = GameManager.GetHiScore();
        int currentScore = GameManager.floor;

        if (currentScore < highestScore)
        {
            infoText.text = "Unfortnately, you didn't achieve \n your highest score. Please tray again.";
        }
        else
        {
            infoText.text = "Congratulations, you have achieved \n your highest score. You can sync now.";
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
