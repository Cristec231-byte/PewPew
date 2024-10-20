using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 50;
    public Slider slider;

    [SerializeField]
    private TextMeshProUGUI valueText;

    // Reference to the GameOverScript
    [SerializeField]
    private GameOverScript gameOverScript;

    // Reference to the Timer script
    [SerializeField]
    private Timer timer;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;

        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        valueText.text = $"Health: {health}";
    }

    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        slider.value = health;

        UpdateHealthText();

        if (health <= 0)
        {

            // Stop the timer when player dies
            if (timer != null)
            {
                timer.StopTimer();
            }

            // Notify GameOverScript about the player death
            if (gameOverScript != null)
            {
                gameOverScript.ShowGameOverScreen();
            }


            Destroy(gameObject);
        }
    }

    internal void ChangePlayerHealth(int amountToChangeStat)
    {
        health += amountToChangeStat;

        health = Mathf.Clamp(health, 0, maxHealth);

        slider.value = health;

        UpdateHealthText();
    }
}