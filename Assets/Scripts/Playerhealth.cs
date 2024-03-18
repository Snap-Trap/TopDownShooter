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
            Destroy(collision.gameObject);
            enemyKillCount++; // Verhoog het aantal gedode vijanden
            TakeDamage(1); // Speler krijgt 1 HP schade als deze een vijand raakt
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Wanneer de speler op "E" drukt, roep de functie voor het gebruiken van de medkit aan
            UseMedkit();
        }
    }

    void UseMedkit()
    {
        // Controleer of de speler al volledige gezondheid heeft
        if (currentHealth < maxHealth)
        {
            // Als de speler niet volledig gezond is, verhoog de gezondheid en vernietig de medkit
            currentHealth += 1f; // Stel de hoeveelheid gezondheid die de medkit toevoegt in
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            Debug.Log("Health restored!");
            // Hier moet je de logica toevoegen om de medkit te vernietigen
        }
        else
        {
            Debug.Log("Health is already full!");
        }
    }
}