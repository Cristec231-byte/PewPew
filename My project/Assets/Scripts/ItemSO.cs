using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    //public AttributeToChange attributeToChange = new AttributeToChange();
    //public int amountToChangeAttribute;

    /*public void UseItem()
    {
        if (statToChange == StatToChange.health)
        {
            GameObject.Find("Health").GetComponent<Health>().ChangePlayerHealth(amountToChangeStat);
        }

    }*/
    public bool UseItem(Health healthComponent)
    {
        if (statToChange == StatToChange.health)
        {

            if (healthComponent != null)
            {
                //Health playerHealth = healthComponent.ChangePlayerHealth(amountToChangeStat);
                if (healthComponent.health == healthComponent.maxHealth)
                {
                    return false;
                }
                else
                {
                    // Safely change player health using the passed reference
                    healthComponent.ChangePlayerHealth(amountToChangeStat);
                }

            }
            else
            {
                Debug.LogError("Health component reference is missing.");
            }
        }
        return false;

    }

    public enum StatToChange
    {
        none,
        health
    };

}