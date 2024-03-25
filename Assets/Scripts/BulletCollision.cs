using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int bulletDamage = 1;
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
