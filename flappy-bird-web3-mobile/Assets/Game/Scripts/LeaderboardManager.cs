using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject ReturnButton;
    private int highestScore;
    private void Start()
    {
        highestScore = GameManager.GetHighestScore();
        scoreText.text = "HIGHEST SCORE: " + highestScore.ToString();
    }

    public void ReturnToMainScene()
    {
        Loader.LoadTargetScene(Loader.Scene.GameScene);
    }
}
