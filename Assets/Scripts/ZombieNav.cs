using System;
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
        public float moveSpeed = 6f;

        public bool canChase = false;

        private float RayDistance = 7.5f;

        Animator anim;
        Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        //RaycastHit2D hit3 = Physics2D.Raycast(transform.position -new Vector3(0, 0), player.position, 7.5f);
        //Debug.DrawRay(transform.position - new Vector3(RayX, RayY), player.position * 7.5f, Color.green);

        //RaycastHit2D hit2 = Physics2D.Raycast(transform.position -new Vector3(-ERayX, -ERayY), Vector2.right, 7.5f);
        //Debug.DrawRay(transform.position - new Vector3(-ERayX, ERayY), Vector2.right * 7.5f, Color.yellow);

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Vector3 PlayerPos = player.position;

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerPos, 7.5f);
        //Debug.DrawRay(transform.position, PlayerPos, Color.green);



        //.................................

        void Update()
        {
            Vector3 direction = player.position - transform.position;
            Vector3 adjustedTransform = new Vector3(transform.position.x + 1.5f, transform.position.y);
            Vector3 AntiadjustedTransform = new Vector3(transform.position.x - 1.5f, transform.position.y);

            // Cast a ray from the zombie's position towards the player
            RaycastHit2D hit1 = Physics2D.Raycast(adjustedTransform, direction, RayDistance);
            Debug.DrawRay(adjustedTransform, direction * 7.5f, Color.green);

            // Github pls make it so that the hit collider works because the if statement doesn't work
            // Fuck you Github

            RaycastHit2D hit2 = Physics2D.Raycast(AntiadjustedTransform, direction, RayDistance);
            Debug.DrawRay(AntiadjustedTransform, direction * 7.5f, Color.green);

            if (hit1.collider != null)
            {
                Debug.Log("Hit something");
                if (hit1.collider.CompareTag("Player") || hit2.collider.CompareTag("Player"))
                {
                    Debug.Log("Player is in sight");
                    canChase = true;
                }
                else
                {
                    canChase = false;
                }
            }

            if (canChase)
            {
                ChasePlayer();
            }
            else
            {
                StopChasingPlayer();
            }


            void ChasePlayer() // Makes the enemy chase the player
            {
                if (player != null)
                {
                    // Calculate direction from zombie to player
                    Vector3 direction = player.position - transform.position;
                    direction.Normalize();
                    transform.Translate(direction * moveSpeed * Time.deltaTime);
                }
            }

            void StopChasingPlayer() // Makes the enemy stop chasing the player
            {
                rb2d.velocity = Vector2.zero;
            }
        }
    }
}
