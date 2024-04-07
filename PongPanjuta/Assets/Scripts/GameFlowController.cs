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

        // TODO Sound abspielen
        uiController.updateActionText("3");
        yield return new WaitForSeconds(1);

        // TODO Sound abspielen
        uiController.updateActionText("2");
        yield return new WaitForSeconds(1);

        // TODO Sound abspielen
        uiController.updateActionText("1");
        yield return new WaitForSeconds(1);

        uiController.updateActionText("");
        yield break;
    }

    private IEnumerator goalAnimationController()
    {
        uiController.updateActionText("GOAL!!");
        yield return new WaitForSeconds(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
