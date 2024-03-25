using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZombieKill : MonoBehaviour
{
    private scoremanagerScript scoreManager; // Referentie naar ScoreManager

    void Start()
    {
        // Zoek de ScoreManager in de scène
        scoreManager = FindObjectOfType<scoremanagerScript>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Vernietig de kogel
            Destroy(other.gameObject);

            // Verhoog de score
            if (scoreManager != null)
            {
                scoreManager.AddScore(10); // Voeg 10 punten toe voor het neerschieten van een vijand
            }
        }
    }

}

