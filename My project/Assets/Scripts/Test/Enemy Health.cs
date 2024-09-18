using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Slider slider;

    [SerializeField]
    private TextMeshProUGUI valueText;

     [SerializeField]
    private GameOverScript gameOverScript;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;

        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        valueText.text = $"Boss Health: {health}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
             // Notify GameOverScript about the Boss death
            if (gameOverScript != null)
            {
                gameOverScript.ShowGameOverScreen();
                Time.timeScale = 0;
            }
            
            Destroy(gameObject);
        }

        health = Mathf.Clamp(health, 0, maxHealth);
        slider.value = health;
        UpdateHealthText();

    }

    internal void ChangeBossHealth(int amountToChangeStat)
    {
        health += amountToChangeStat;

        health = Mathf.Clamp(health, 0, maxHealth);

        slider.value = health;

        UpdateHealthText();
    }
}
