using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketsWindow : MonoBehaviour
{
    private Text TicketsText;
    private int totalTickets;

    private void Awake()
    {
        TicketsText = transform.Find("TicketCount").GetComponent<Text>();
    }

    private void Update()
    {
        totalTickets = DataManager.GetTotalTickets();
        TicketsText.text = "x " + totalTickets.ToString();
    }
}

