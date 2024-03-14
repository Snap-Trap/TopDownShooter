using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

namespace Assets.Scripts
{
    public class ZombieNav : MonoBehaviour
    {
        public Transform player;
        public float RayX = 0f;
        public float RayY = 0f;
        public float moveSpeed = 6f;

        public bool canChase = false;

        private float RayDistance = 7.5f;
        private float RayAngle = 360f;
        private int raycount = 30;

        private Ray sight;


        Animator anim;
        Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        void Update()
        {
            //RaycastHit2D hit3 = Physics2D.Raycast(transform.position -new Vector3(0, 0), player.position, 7.5f);
            //Debug.DrawRay(transform.position - new Vector3(RayX, RayY), player.position * 7.5f, Color.green);

            //RaycastHit2D hit2 = Physics2D.Raycast(transform.position -new Vector3(-ERayX, -ERayY), Vector2.right, 7.5f);
            //Debug.DrawRay(transform.position - new Vector3(-ERayX, ERayY), Vector2.right * 7.5f, Color.yellow);
             
            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            //Vector3 PlayerPos = player.position;

            //RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerPos, 7.5f);
            //Debug.DrawRay(transform.position, PlayerPos, Color.green);

       

        //.................................

        void FixedUpdate()
        {
            sight.origin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            sight.direction = transform.forward;
            RaycastHit rayHit;
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(sight, out rayHit, chaseRange))
            {
                Debug.DrawLine(sight.origin, rayHit.point, Color.red);
                if (rayHit.collider.tag == "Player")
                {
                    CurrentState = EnemyStates.following;
                }

                if (rayHit.collider.tag != "Player" && rayHit.collider.tag != "Enemy")
                {
                    CurrentState = EnemyStates.idle;
                }
            }
        }

            if (rayHit.collider != null && hit.collider.CompareTag("Player"))
            {
                Debug.Log(hit.collider.gameObject + " hit 1");
                canChase = true;
            }
            else
            {
                canChase = false;
            }
            
            if (canChase)
            {
                ChasePlayer();
            }
            else
            {
                StopChasingPlayer();
            }
        }



        void ChasePlayer() // Makes the enemy chase the player
        {
            // Means enemy is to the left of the player so they go right
            // Because the player has the bigger X value, means it's further to the right
            if (transform.position.x < player.position.x)
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
                // transform.localScale = new Vector2(2, 2);
            }
            else // for when enemy is to the right of the player so they go left
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                // transform.localScale = new Vector2(-1, 1);
            }

            if (transform.position.y < player.position.y)
            {
                rb2d.velocity = new Vector2(0, moveSpeed);
            }
            else
            {
                rb2d.velocity = new Vector2(0, -moveSpeed);
            }
        }

        void StopChasingPlayer() // Makes the enemy stop chasing the player
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
