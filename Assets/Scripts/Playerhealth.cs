using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerhealth : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;
    private int enemyKillCount = 0; // Variabele om het aantal gedode vijanden bij te houden
    private scoremanagerScript scoreManager; // Referentie naar het scoremanagerScript

    void Start()
    {
        currentHealth = maxHealth;
        // Zoek en wijs de scoreManager toe
        scoreManager = FindObjectOfType<scoremanagerScript>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoremanagerScript not found!");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (currentHealth <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // Sla het aantal gedode vijanden en het aantal behaalde punten op in PlayerPrefs
        PlayerPrefs.SetInt("EnemyKillCount", enemyKillCount);
        PlayerPrefs.SetInt("Score", scoreManager.GetScore());
        PlayerPrefs.Save(); // Belangrijk om PlayerPrefs op te slaan
        SceneManager.LoadScene("EndScreen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Als de speler een vijand raakt, voeg dan punten toe en verhoog het aantal gedode vijanden
            scoreManager.AddScore(10); // Voeg punten toe bij het raken van een vijand
            enemyKillCount++; // Verhoog het aantal gedode vijanden
            TakeDamage(10); // Speler krijgt 1 HP schade als deze een vijand raakt
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}