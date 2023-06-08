using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public UnityEvent<bool> DieStatusChangedEvent { get; set; } = new UnityEvent<bool>();

    public static UnityEvent LevelComplete = new UnityEvent();
    public static UnityEvent LevelFailed = new UnityEvent();

    public static UnityEvent<bool> SwitchInputSystemEvent { get; set; } = new UnityEvent<bool>();
}