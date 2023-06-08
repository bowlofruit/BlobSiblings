using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent<bool> OnPressedButton { get; set; } = new UnityEvent<bool>();

    private Vector3 _originalPos; 
    private Vector3 _pressedPos;

    private void Awake()
    {
        _originalPos = transform.position;
        _pressedPos = new Vector3(0f, -0.04f) + transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            OnPressedButton.Invoke(true);
            transform.position = _pressedPos;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider != null)
        {
            OnPressedButton.Invoke(false);
            transform.position = _originalPos;
        }
    }
}