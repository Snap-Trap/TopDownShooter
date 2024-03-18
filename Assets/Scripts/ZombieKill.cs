using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ZombieKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Zoek de ScoreManager in de scène
            scoremanagerScript scoreManager = FindObjectOfType<scoremanagerScript>();
            if (scoreManager != null)
            {
                // Roep de AddScore-methode aan om punten toe te voegen
                scoreManager.AddScore(10); // Voeg hier het aantal punten toe dat je wilt toekennen voor het neerschieten van een vijand
            }
            // Voeg hier eventueel andere gedragingen toe die moeten plaatsvinden wanneer een zombie wordt neergeschoten
            Destroy(gameObject); // Vernietig de zombie
            Destroy(other.gameObject); // Vernietig de kogel
        }
    }
}

