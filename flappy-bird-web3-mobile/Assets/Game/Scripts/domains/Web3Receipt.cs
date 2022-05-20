using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Web3Receipt
{
    public string blockHash;
    public int blockNumber;
    public string contractAddress;
    public int cumulativeGasUsed;
    public string effectiveGasPrice;
    public string from;
    public int gasUsed;
    public string logsBloom;
    public bool status;
    public string to;
    public string transactionHash;
    public int transactionIndex;
    public string type;
    public List<EventObj> events = new List<EventObj>();
}