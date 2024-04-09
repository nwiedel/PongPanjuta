using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public GameFlowController game;

    public float speed = 300f;
    private float speedCummulator = 50f;

    private int hitCounter = 0;

    public void ResetBall(bool isPlayer1)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (isPlayer1)
        {
            transform.position = new Vector3(-50, 0, 0);
        }
        else
        {
            transform.position = new Vector3(50, 0, 0);
        }
        hitCounter = 0;
    }

    public void StartBall(bool isPlayer1)
    {
        if (isPlayer1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }

    private float YOnHit(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player1Racket")
        {
            OnCollisionPlayer1Racket(other);
        }
        else if(other.gameObject.name == "Player2Racket")
        {
            OnCollisionPlayer2Racket(other);
        }
        else if(other.gameObject.name == "LeftWall")
        {
            OnCollisionPlayer1Wall(other);
        }
        else if (other.gameObject.name == "RightWall")
        {
            OnCollisionPlayer2Wall(other);
        }
    }

    private void OnCollisionPlayer1Racket(Collision2D other)
    {
        float y = YOnHit(transform.position, other.transform.position, other.collider.bounds.size.y);
        Vector2 v = new Vector2(1, y).normalized;
        GetComponent<Rigidbody2D>().velocity = v * (speed + hitCounter * speedCummulator);

        if(hitCounter < 12)
        {
            hitCounter++;
        }

        // TODO adding sound
    }

    private void OnCollisionPlayer2Racket(Collision2D other)
    {
        float y = YOnHit(transform.position, other.transform.position, other.collider.bounds.size.y);
        Vector2 v = new Vector2(-1, y).normalized;
        GetComponent<Rigidbody2D>().velocity = v * (speed + hitCounter * speedCummulator);

        if (hitCounter < 12)
        {
            hitCounter++;
        }

        // TODO adding sound
    }

    private void OnCollisionPlayer1Wall(Collision2D c)
    {
        StartCoroutine(game.goalPlayer2());
    }
    private void OnCollisionPlayer2Wall(Collision2D c)
    {
        StartCoroutine(game.goalPlayer1());
    }
}
