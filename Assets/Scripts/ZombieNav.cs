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
        private GameObject spriteRenderer;

        Animator anim;
        Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            spriteRenderer = GameObject.FindWithTag("Rotpoint");
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
        public float ConeOfVision = 45;
        public int RaysToShoot = 10;
        void Update()
        {
            Vector3 direction = player.position - transform.position;

            var angle = MathF.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

            var currentAngle = spriteRenderer.transform.rotation.eulerAngles.z;

            var directionWithAngle1 = Quaternion.Euler(new Vector3(0, 0, -ConeOfVision + currentAngle - 90)) * Vector3.up;
            Debug.DrawRay(transform.position, directionWithAngle1 * RayDistance, Color.red);
            var directionWithAngle2 = Quaternion.Euler(new Vector3(0, 0, ConeOfVision + currentAngle - 90)) * Vector3.up;
            Debug.DrawRay(transform.position, directionWithAngle2 * RayDistance, Color.red);

            var z1 = -ConeOfVision + currentAngle - 90; // These are the bounds of the cone of vision
            var z2 = ConeOfVision + currentAngle - 90;

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            // The wall check
            for (int i = 0; i < RaysToShoot; i++)
            {
                var z = Mathf.Lerp(z1, z2, i / (float)RaysToShoot);
                var directionWithAngle = Quaternion.Euler(new Vector3(0, 0, z)) * Vector3.up;

                var origin = transform.position;

                hits.Add(Physics2D.Raycast(origin, directionWithAngle, RayDistance, LayerMask.GetMask("Obstacles")));
                Debug.DrawRay(origin, directionWithAngle * RayDistance, Color.red);
            }

            for (int i = 0; i < hits.Count; i++)
            {
                if (hits[i].collider != null)
                {
                    if (hits[i].collider.CompareTag("Player"))
                    {
                        canChase = true;
                        break;
                    }
                    else
                    {
                        canChase = false;
                    }
                }
            }

            if (canChase)
            {
                ChasePlayer();
                RotateTowardsPlayer(direction);
            }
            else
            {
                StopChasingPlayer();

            }

            void RotateTowardsPlayer(Vector3 direction)
            {
                var angle = MathF.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                angle -= 90;

                spriteRenderer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
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