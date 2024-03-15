using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Playerhealth playerHealth;
    public Slider healthSlider;

    void Update()
    {
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {

        float fillValue = playerHealth.GetCurrentHealth() / playerHealth.maxHealth;
        healthSlider.value = fillValue;
    }
}