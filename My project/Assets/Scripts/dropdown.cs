using System.Collections;
using UnityEngine;

public class dropdown : MonoBehaviour
{
    private Collider2D col;
    private bool playr;

    private void Start()
    {
        col = GetComponent<Collider2D>();

    }

 private void Update()
    {
        if (playr && Input.GetAxisRaw("Vertical") < 0)
        {
            col.enabled = false;
            StartCoroutine(EnableCol());  // Start the coroutine to re-enable the collider
        }
    }

    private IEnumerator EnableCol()
    {
        yield return new WaitForSeconds(1.2f);
        col.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<Pmovement>();
        if (player != null)
        {
            playr = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, false);  // Set to false when the player exits the platform
    }
}