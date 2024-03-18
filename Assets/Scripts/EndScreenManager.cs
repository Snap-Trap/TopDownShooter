using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Voeg deze regel toe om toegang te krijgen tot TMP_Text

public class EndScreenManager : MonoBehaviour
{
    public TMP_Text aantalZombiesText; // Naam moet overeenkomen met de werkelijke naam in de scène
    public TMP_Text aantalPuntenText; // Naam moet overeenkomen met de werkelijke naam in de scène

    void Start()
    {
        // Haal het aantal gedode vijanden op uit PlayerPrefs en toon het in de UI
        int enemyKillCount = PlayerPrefs.GetInt("EnemyKillCount", 0);
        aantalZombiesText.text = "Aantal zombies dood: " + enemyKillCount;

        // Haal het aantal behaalde punten op uit PlayerPrefs en toon het in de UI
        int score = PlayerPrefs.GetInt("Score", 0);
        aantalPuntenText.text = "Aantal punten: " + score;
    }
}
