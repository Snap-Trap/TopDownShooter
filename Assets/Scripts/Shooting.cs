using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isPistol;
    public bool isShotgun;
    public bool isAssaultRifle;

    private Rigidbody2D rb;
    private Rigidbody2D bulletRb;
    private Vector2 mousePosition;
    private Camera mainCamera;

    public Vector2 aimDirection;

    public GameObject Bullet;
    public Transform Bulletpoint;
    public float BulletSpeed;
    public int bulletDamage = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (isPistol)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FirePistol();
            }

        }
        if (isShotgun)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireShotgun();
            }
        }

        if (isAssaultRifle)
        {
            if (Input.GetMouseButton(0))
            {
                FireAssaultRifle();
            }
        }
    }

    public void FirePistol()
    {
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

    public void FireAssaultRifle()
    {
        GameObject tempBullet = Instantiate(Bullet, Bulletpoint.position, Quaternion.identity);


        Rigidbody2D bulletRb = tempBullet.GetComponent<Rigidbody2D>();
        if (bulletRb) // Check for Rigidbody2D presence
        {
            Vector2 forceDirection = aimDirection.normalized; // Normalize for consistent force
            bulletRb.AddForce(forceDirection * 1750f);
        }
        else
        {
            Debug.LogError("Bullet prefab missing Rigidbody2D component!");
        }
    }

    public void FireShotgun()
    {
        int numPellets = 8;
        float spreadAngle = 70f;

        for (int i = 0; i < numPellets; i++)
        {
            // Calculate random direction within the spread angle
            float randomAngleOffset = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
            Vector2 direction = aimDirection.normalized;
            direction = Quaternion.Euler(0, 0, randomAngleOffset) * direction;

            // Instantiate and fire the bullet
            GameObject tempBullet = Instantiate(Bullet, Bulletpoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = tempBullet.GetComponent<Rigidbody2D>();
            if (bulletRb)
            {
                bulletRb.AddForce(direction * 2000f);
            }
            else
            {
                Debug.LogError("Bullet prefab missing Rigidbody2D component!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Controleer of de kogel de vijand heeft geraakt
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Haal het EnemyHealth-component op van de geraakte vijand
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            // Controleer of het EnemyHealth-component bestaat
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage); // Pas schade toe op de vijand
            }
        }
    }
}

