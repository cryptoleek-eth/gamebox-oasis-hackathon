using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ERC1155BalanceOfExample : MonoBehaviour
{

    public GameObject Sphere;

    async void Start()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0x1C8F5AF7Baacc0627a351DA564a4cE9bbdba7368";
        string account = PlayerPrefs.GetString("Account");
        string tokenId = "3";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(">>>>>>>> " + balanceOf);

        if (balanceOf > 0) {
            Sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
}
