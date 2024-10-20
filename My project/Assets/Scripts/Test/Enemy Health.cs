using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public Slider slider;

    public GameObject Popuptext;
    public TMP_Text PopupText;

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

    

    public void TakeDamage(float amount)
    {
        health -= amount;
        //PopupText.text = amount.ToString();

        Vector3 offset = new Vector3(0, 2, 0);

        Instantiate(Popuptext, transform.position + offset, Quaternion.identity);
        
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

    private void Instantiate(GameObject popuptext, float v, Quaternion identity)
    {
        throw new NotImplementedException();
    }

    internal void ChangeBossHealth(int amountToChangeStat)
    {
        health += amountToChangeStat;

        health = Mathf.Clamp(health, 0, maxHealth);

        slider.value = health;

        UpdateHealthText();
    }
}