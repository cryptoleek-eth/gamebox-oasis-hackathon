using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class LoadingManager : MonoBehaviour
{
    public static Text loadingText;
    public static string textInfo = "";
    bool isCoroutineReady = true;
    private void Awake()
    {
        loadingText = transform.Find("LoadingText").GetComponent<Text>();
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        loadingText.text = textInfo.ToString();

        if (isCoroutineReady)
        {
            isCoroutineReady = false;
            StartCoroutine(Loading());
        }
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1);
        textInfo += ".";
        if (CountCharacter('.', textInfo) > 6)
        {
            textInfo = textInfo.Replace(".", "");
        }
        isCoroutineReady = true;
        yield return null;
    }

    public static void UpdateTextInfo(string info)
    {
        textInfo = info;
    }

    public static int CountCharacter(char character, string letter)
    {
        int count = 0;
        //Counts each character except space  
        for (int i = 0; i < letter.Length; i++)
        {
            if (letter[i] == character)
                count++;
        }

        return count;
    }
}
