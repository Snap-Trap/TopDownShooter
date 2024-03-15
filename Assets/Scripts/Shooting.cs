using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D bulletRb;
    private Vector2 mousePosition;
    private Camera mainCamera;

    public Vector2 aimDirection;

    public GameObject Bullet;
    public Transform Bulletpoint;
    public float BulletSpeed;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        bulletRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Input.GetMouseButtonDown(0))
        {
           Fire();
        }
    }
   void Fire()
   {
        // GameObject tempBullet = Instantiate(Bullet,new Vector2(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y),
        //Quaternion.identity);

        GameObject tempBullet = Instantiate(Bullet, Bulletpoint.position, Quaternion.identity);


        Rigidbody2D bulletRb = tempBullet.GetComponent<Rigidbody2D>();
        if (bulletRb) // Check for Rigidbody2D presence
        {
            Vector2 forceDirection = aimDirection.normalized; // Normalize for consistent force
            bulletRb.AddForce(forceDirection * 2500f);
        }
        else
        {
            Debug.LogError("Bullet prefab missing Rigidbody2D component!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
          //  Destroy(tempBullet);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
           // Destroy(tempBullet);
        }
    }
}
