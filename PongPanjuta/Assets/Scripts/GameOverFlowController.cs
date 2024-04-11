using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverFlowController : MonoBehaviour
{
    public Text actionText;

    public void UpdateActionText(string text)
    {
        actionText.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        actionText.text = PlayerPrefs.GetString("lastWinner") + System.Environment.NewLine + "wins!";
        yield return new WaitForSeconds(3);
        actionText.text = "Game Over!";

        yield return new WaitForSeconds(3);
        Application.LoadLevel("OptionsScene");

    }
}
