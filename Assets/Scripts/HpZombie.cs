using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    private scoremanagerScript scoreManager; // Referentie naar ScoreManager
    public int maxHealth = 10; // Maximale HP van de vijand
    private int currentHealth; // Huidige HP van de vijand

    void Start()
    {
        currentHealth = maxHealth; // Initialiseer de HP van de vijand                                
        scoreManager = FindObjectOfType<scoremanagerScript>();// Zoek de ScoreManager in de scène
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
        }
    }

    // Methode om schade toe te passen op de vijand
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Verminder de HP van de vijand met de ontvangen schade

        if (currentHealth <= 0)
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(10); // Voeg 10 punten toe voor het neerschieten van een vijand
            }
            Die(); // Als de HP van de vijand nul of minder is, roep de Die-methode aan
        }
    }

    // Methode om de vijand te laten sterven
    void Die()
    {
        Destroy(gameObject); // Vernietig de vijand GameObject wanneer deze sterft
    }
}

