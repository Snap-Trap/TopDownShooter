using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZombieKill : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            // Vernietig de kogel
            Destroy(other.gameObject);

            
        }
    }
}

