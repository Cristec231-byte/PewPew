using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 50;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start method called");
        health = 30;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    internal void ChangePlayerHealth(int amountToChangeStat)
    {
        // Update the player's health
        health += amountToChangeStat;

        // Clamp the health to stay between 0 and maxHealth
        health = Mathf.Clamp(health, 0, maxHealth);

        // Update the health slider
        slider.value = health;

        // Optional: Print to debug console for confirmation
        Debug.Log($"Health changed by {amountToChangeStat}. New health: {health}");
    }
}
