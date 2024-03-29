using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Behaviour : MonoBehaviour
{
    public float speed = 100f;
    public GameObject ball;

    private void FixedUpdate()
    {
        //if(PlayerPrefs.GetString("isAI") == "false")
        //{
            float axis = Input.GetAxisRaw("Vertical");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, axis) * speed;

        //}
    }
}
