using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static Text loadingText;
    private static string textInfo = "Loading...";
    private void Awake()
    {
        loadingText = transform.Find("LoadingText").GetComponent<Text>();
    }
    private void Update()
    {
        UpdateText(textInfo);
        loadingText.text = textInfo.ToString();
    }

    public static void UpdateText(string info)
    {
        textInfo = info;
    }
}
