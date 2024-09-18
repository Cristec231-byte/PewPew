using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Slider slider; 

    private bool hasTriggered = false;
    private void Start()
    {
        if (slider != null)
        {
            slider.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered) 
        {
            if (slider != null)
            {
                slider.gameObject.SetActive(true); 
                hasTriggered = true; 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
