using BlobSiblings;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventController eventController = collision.GetComponent<EventController>();

        if(collision != null && eventController != null) 
        {
            eventController.DieStatusChangedEvent.Invoke(true);
            EventController.SwitchInputSystemEvent.Invoke(false);
        }
        
    }
}