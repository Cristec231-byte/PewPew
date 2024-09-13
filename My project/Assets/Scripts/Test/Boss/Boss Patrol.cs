
using System;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    [Header("Patrol Borders")]
    [SerializeField] private Transform leftBorder; // The left border of the patrol area
    [SerializeField] private Transform rightBorder; // The right border of the patrol area
    
    [Header("Enemy")]
    [SerializeField] private Transform Enemy; // The enemy object

    [Header("Movement")]
    [SerializeField] private float speed; // The speed of the enemy
    private Vector3 iP; // The initial position of the enemy
    private bool movingLeft;

    private void Awake() {
        iP = Enemy.localScale;
    }

    private void Update() {
        if (movingLeft) {
            if (Enemy.position.x >= leftBorder.position.x) {
                MovDir(-1);
            }
            else {
                DirChg();
            }
        }

        else {
            if (Enemy.position.x <= rightBorder.position.x) {
                MovDir(1);
            }
            else {
                DirChg();
            }
        }
        
    }

    //method to change direction
    private void DirChg() {
        movingLeft = !movingLeft;
    }

    //method to move in a correct direction
    private void MovDir(int dir) {
        //Make the enemy face the correct direction
        Enemy.localScale = new Vector3(Math.Abs(iP.x) * dir, iP.y, iP.z);

        //Move the enemy in the correct direction
        Enemy.position = new Vector3(Enemy.position.x + Time.deltaTime * dir * speed, Enemy.position.y, Enemy.position.z);
    }

}

