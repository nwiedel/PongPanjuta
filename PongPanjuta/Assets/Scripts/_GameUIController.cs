using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GameUIController : MonoBehaviour
{
    public Text player1Text;
    public Text player2Text;
    public Text player1Goals;
    public Text player2Goals;
    public Text actionText;

    // Start is called before the first frame update
    void Start()
    {
        player1Text.text = PlayerPrefs.GetString("player1Name");
        player2Text.text = PlayerPrefs.GetString("player2Name");
    }

    public void UpdatePlayer1Goals(string s)
    {
        player1Goals.text = s;
    }
    public void UpdatePlayer2Goals(string s)
    {
        player2Goals.text = s;
    }

    public void updateActionText(string s)
    {
        actionText.text = s;
    }
}
