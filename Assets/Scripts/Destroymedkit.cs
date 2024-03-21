using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroymedkit : MonoBehaviour
{
    public float maxHealthIncrease = 1f; // Hoeveelheid gezondheid die de medkit toevoegt
    private Playerhealth playerHealth; // Referentie naar de spelergezondheid

    void Start()
    {
        // Zoek en wijs de spelergezondheid toe
        playerHealth = FindObjectOfType<Playerhealth>();
        if (playerHealth == null)
        {
            Debug.LogError("Playerhealth script not found!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Roep de methode aan om de medkit te gebruiken
            UseMedkit();
        }
    }

    public void UseMedkit()
    {
        // Controleer of de speler al volledige gezondheid heeft
        if (playerHealth.GetCurrentHealth() < playerHealth.maxHealth)
        {
            // Als de speler niet volledig gezond is, verhoog de gezondheid en vernietig de medkit
            playerHealth.currentHealth += maxHealthIncrease;
            playerHealth.currentHealth = Mathf.Clamp(playerHealth.currentHealth, 0f, playerHealth.maxHealth);
            Debug.Log("Health restored!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Health is already full!");
        }
    }
}

