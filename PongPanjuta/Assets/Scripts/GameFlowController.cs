using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
    public BallBehaviour ball;
    public _GameUIController uiController;
    public SoundController sounds;

    public int maxGoals = 5;
    private int player1Goals = 0;
    private int player2Goals = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startNewRound(true)); 
    }

    public IEnumerator startNewRound(bool isPlayer1)
    {
        yield return StartCoroutine(startAnimationoroutine());
        ball.StartBall(isPlayer1);
    }

    private IEnumerator startAnimationoroutine()
    {
        yield return new WaitForSeconds(1);

        sounds.wallSound.Play();
        uiController.updateActionText("3");
        yield return new WaitForSeconds(1);

        sounds.wallSound.Play();
        uiController.updateActionText("2");
        yield return new WaitForSeconds(1);

        sounds.wallSound.Play();
        uiController.updateActionText("1");
        yield return new WaitForSeconds(1);

        sounds.wallSound.Play();
        uiController.updateActionText("Pong");
        yield return new WaitForSeconds(1);

        uiController.updateActionText("");
        yield break;
    }

    public IEnumerator goalPlayer1()
    {
        player1Goals++;
        uiController.UpdatePlayer1Goals(player1Goals.ToString());

        if (HasFinished())
        {
            if(PlayerPrefs.GetString("player1Name") != null)
            {
                PlayerPrefs.SetString("lastWinner", PlayerPrefs.GetString("player1Name"));
            }
            else
            {
                PlayerPrefs.SetString("lastWinner", "Player 1");
            }

            // TODO PlayerPrefs player 1  won
            Application.LoadLevel("GameOverScene");
        }

        ball.ResetBall(true);
        yield return StartCoroutine(goalAnimationCoroutine());
        StartCoroutine(startNewRound(true));
    }

    public IEnumerator goalPlayer2()
    {
        player2Goals++;
        uiController.UpdatePlayer2Goals(player2Goals.ToString());

        if (HasFinished())
        {
            if (PlayerPrefs.GetString("player2Name") != null)
            {
                PlayerPrefs.SetString("lastWinner", PlayerPrefs.GetString("player2Name"));
            }
            else
            {
                PlayerPrefs.SetString("lastWinner", "Player 2");
            }

            // TODO PlayerPrefs player 2  won
            Application.LoadLevel("GameOverScene");
        }

        ball.ResetBall(false);
        yield return StartCoroutine(goalAnimationCoroutine());
        StartCoroutine(startNewRound(false));
    }

    private IEnumerator goalAnimationCoroutine()
    {
        uiController.updateActionText("GOAL!!");
        yield return new WaitForSeconds(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool HasFinished()
    {
        if(player1Goals == maxGoals || player2Goals == maxGoals)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
