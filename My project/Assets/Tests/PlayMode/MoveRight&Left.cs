using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Player
{
    private GameObject playerObject;
    private Pmovement playerMovement;
    private Rigidbody2D playerRigidbody;
    private float moves;

    private BoxCollider2D BoxCollider;

    [SetUp]
    public void Setup()
    {
        playerObject = new GameObject("Player");
        playerMovement = playerObject.AddComponent<Pmovement>();
        playerRigidbody = playerObject.AddComponent<Rigidbody2D>();
        playerObject.AddComponent<Animator>();
        playerObject.AddComponent<BoxCollider2D>();
    }
    // A Test behaves as an ordinary method
    //[Test]
    /*public void PlayerMovesRight()
    {
        moves = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")* 2, playerRigidbody.velocity.y);
        if(moves  < 0.01f)
        {
            Assert.Greater(playerRigidbody.velocity.x, 0, "Player should move right");
        }

        // Use the Assert class to test conditions
    }*/

      /*[Test]
     public void PlayerMovesLeft()
    {
        moves = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")* 2, playerRigidbody.velocity.y);
        if(moves  < -0.01f)
        {
            Assert.Greater(playerRigidbody.velocity.x, 0, "Player should move left");
        }

        // Use the Assert class to test conditions
    }*/

    /*private LayerMask groundlayer;
    [Test]
     public void Jump()
    {
        if(Input.GetKey(KeyCode.Space))
      {
        if(OnGrounded())
        {
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 2f);
        Assert.Greater(playerObject.GetComponent<Rigidbody2D>().velocity.y, 0);
        }
      }
        // Use the Assert class to test conditions
    }

     private bool OnGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCollider.bounds.center,BoxCollider.bounds.size,0,Vector2.down,0.1f,groundlayer);
        return raycastHit.collider != null;
    }*/

    [Test]
     public void FlipLeftAndRight()
    {
        moves = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")* 2, playerRigidbody.velocity.y);
        if(moves  > 0.01f)
        {
            Assert.Greater(playerRigidbody.velocity.x, 0, "Player should move right");
        }
        else if(moves  < -0.01f)
        {
            Assert.Greater(playerRigidbody.velocity.x, 0, "Player should move left");
        }

        // Use the Assert class to test conditions
    }
}
