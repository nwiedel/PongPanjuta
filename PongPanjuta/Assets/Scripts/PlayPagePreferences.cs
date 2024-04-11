using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPagePreferences : MonoBehaviour
{
    public Text player1NameText;
    public Text player2NameText;
    public Toggle aiToggle;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("player1Name"))
        {
            player1NameText.text = PlayerPrefs.GetString("player1Name");
        }
        if (PlayerPrefs.HasKey("player2Name"))
        {
            player2NameText.text = PlayerPrefs.GetString("player2Name");
        }
        if(PlayerPrefs.GetString("isAI") == "true")
        {
            aiToggle.isOn = true;
        }
        else
        {
            aiToggle.isOn = false;
        }
    }

    public void ChangePlayer1Name(string name)
    {
        player1NameText.text = name;
        PlayerPrefs.SetString("player1Name", name);
    }

    public void ChangePlayer2Name(string name)
    {
        player2NameText.text = name;
        PlayerPrefs.SetString("player2Name", name);
    }

    public void toggleAI()
    {
        if (aiToggle.isOn)
        {
            PlayerPrefs.SetString("isAI", "true");
        }
        else
        {
            PlayerPrefs.SetString("isAI", "false");
        }
    }
}
