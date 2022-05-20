using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventObj
{
    public string name;
    public string address;
    public string blockHash;
    public int blockNumber;
    public int logIndex;
    public bool removed;
    public string transactionHash;
    public int transactionIndex;
    public string id;
    public List<ReturnValuePair> returnValues = new List<ReturnValuePair>();
    public string signature;


}