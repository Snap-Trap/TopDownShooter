using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public float speed = 5.0f;
   public float AxisX;
   public float AxisY;

   private Rigidbody2D rb;

   void Update()
   {
        AxisX = Input.GetAxis("Horizontal");
        AxisY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(AxisX, AxisY) * speed ;
        rb.velocity = new Vector2(AxisX * speed, AxisY * speed);
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
