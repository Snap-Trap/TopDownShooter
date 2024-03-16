using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoremanagerScript : MonoBehaviour
{
    public TMP_Text scoreText; // Gebruik TMP_Text in plaats van Text
    private int score = 0;

    // Voeg punten toe aan de score en update de UI
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Update de score tekst in de UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void Start()
    {
        // Zoek en wijs het TMP Text-component toe aan scoreText
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();

        // Controleer of scoreText is gevonden
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found!");
        }
    }
}
