using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessageDisplay : MonoBehaviour
{
    public Text wrongMessageText;

    void Start()
    {
        wrongMessageText.gameObject.SetActive(false);  // Hide the text at the start
    }

    public void ShowWrongMessage(string message)
    {
        wrongMessageText.gameObject.SetActive(true);
        wrongMessageText.text = message;  // Set the message text
    }

    public void HideWrongMessage()
    {
        wrongMessageText.gameObject.SetActive(false);  // Hide the message
    }
}
