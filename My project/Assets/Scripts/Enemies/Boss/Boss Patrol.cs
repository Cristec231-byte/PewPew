using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    [Header("Patrol Borders")]
    [SerializeField] private Transform topBorder; // The top border of the patrol area
    [SerializeField] private Transform bottomBorder; // The bottom border of the patrol area
    
    [Header("Enemy")]
    [SerializeField] private Transform Enemy; // The enemy object

    [Header("Movement")]
    [SerializeField] private float speed; // The speed of the enemy
    private Vector3 iP; // The initial position of the enemy
    private bool movingDown;

    private void Awake() {
        iP = Enemy.localScale;
    }

    private void Update() {
        if (movingDown) {
            if (Enemy.position.y >= bottomBorder.position.y) {
                MovDir(-1);
            }
            else {
                DirChg();
            }
        }

        else {
            if (Enemy.position.y <= topBorder.position.y) {
                MovDir(1);
            }
            else {
                DirChg();
            }
        }
        
    }

    //method to change direction
    private void DirChg() {
        movingDown = !movingDown;
    }

    //method to move in a correct direction
    private void MovDir(int dir) {
        // //Make the enemy face the correct direction
        // Enemy.localScale = new Vector3(iP.x, Math.Abs(iP.y) * dir, iP.z);

        //Move the enemy in the correct direction
        Enemy.position = new Vector3(Enemy.position.x, Enemy.position.y + Time.deltaTime * dir * speed, Enemy.position.z);
    }
}
