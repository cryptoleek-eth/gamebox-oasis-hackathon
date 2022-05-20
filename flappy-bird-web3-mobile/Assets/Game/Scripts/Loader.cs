using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader
{
    public enum Scene
    {
        GameScene,
        WebLogin,
        LeaderboardScene,
        BuyScene,
        RedeemScene,
        LoadingScene,
    }

    public static Scene targetScene;

    public static void LoadTargetScene(Scene scene)
    {
        targetScene = scene;
        SceneManager.LoadScene(targetScene.ToString());
    }
}