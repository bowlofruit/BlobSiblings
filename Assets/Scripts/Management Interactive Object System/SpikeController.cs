using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EventController>().DieStatusChangedEvent.Invoke(true);
        EventController.SwitchInputSystemEvent.Invoke(false);
    }
}