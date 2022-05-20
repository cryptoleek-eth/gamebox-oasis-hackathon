using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Web3GL
{
    [DllImport("__Internal")]
    private static extern void SendContractJs(string method, string abi, string contract, string args, string value, string gasLimit, string gasPrice);

    [DllImport("__Internal")]
    private static extern string SendContractResponse();

    [DllImport("__Internal")]
    private static extern void SetContractResponse(string value);

    [DllImport("__Internal")]
    private static extern void SendTransactionJs(string to, string value, string gasLimit, string gasPrice);

    [DllImport("__Internal")]
    private static extern string SendTransactionResponse();

    [DllImport("__Internal")]
    private static extern void SetTransactionResponse(string value);

    [DllImport("__Internal")]
    private static extern void SignMessage(string value);

    [DllImport("__Internal")]
    private static extern string SignMessageResponse();

    [DllImport("__Internal")]
    private static extern void SetSignMessageResponse(string value);

    [DllImport("__Internal")]
    private static extern int GetNetwork();

    // this function will create a metamask tx for user to confirm.
    async public static Task<string> SendContract(string _method, string _abi, string _contract, string _args, string _value, string _gasLimit = "", string _gasPrice = "")
    {
        try
        {
            // Set response to empty
            SetContractResponse("");
            SendContractJs(_method, _abi, _contract, _args, _value, _gasLimit, _gasPrice);
            string response = SendContractResponse();
            Debug.Log("response >>>" + response);
            int count = 1;
            while (response == "")
            {
                Debug.Log("loop count is" + count);
                await UniTask.Delay(TimeSpan.FromSeconds(1), ignoreTimeScale: true);
                response = SendContractResponse();
                Debug.Log("response in web3gl.sendContract" + response + " ... " + count);
                count += 1;
            }

            Debug.Log("response in web3gl.sendContract" + response);
            SetContractResponse("");

            if (response.Length > 10)
            {
                Debug.Log("response will return is in");
                return response;
            }
            else
            {
                Debug.Log("Exception is in");
                throw new Exception(response);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error Error " + e.ToString());
            throw new Exception(e.ToString());
        }
    }

    async public static Task<string> SendTransaction(string _to, string _value, string _gasLimit = "", string _gasPrice = "")
    {
        // Set response to empty
        SetTransactionResponse("");
        SendTransactionJs(_to, _value, _gasLimit, _gasPrice);
        string response = SendTransactionResponse();
        while (response == "")
        {
            await new WaitForSeconds(1f);
            response = SendTransactionResponse();
        }
        SetTransactionResponse("");
        // check if user submmited or user rejected
        if (response.Length == 66)
        {
            return response;
        }
        else
        {
            throw new Exception(response);
        }
    }

    async public static Task<string> Sign(string _message)
    {
        SignMessage(_message);
        string response = SignMessageResponse();
        while (response == "")
        {
            await new WaitForSeconds(1f);
            response = SignMessageResponse();
        }
        // Set response to empty
        SetSignMessageResponse("");
        // check if user submmited or user rejected
        if (response.Length == 132)
        {
            return response;
        }
        else
        {
            throw new Exception(response);
        }
    }

    public static int Network()
    {
        return GetNetwork();
    }

}