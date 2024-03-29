using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Behaviour : MonoBehaviour
{
    public float speed = 100f;

    private void FixedUpdate()
    {
        float axis = Input.GetAxisRaw("Vertical2");
        GetComponent<Rigidbody2D>().velocity = new Vector2 (0, axis) *speed;
     }
}
