using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public bool IsDied { get; set; }
    public bool IsGround { get; set; }

    public UnityEvent<bool> OnGroundedStatusChanged { get; set; } = new UnityEvent<bool>();

    private void Update()
    {
        if (IsDied)
        {
            Destroy(gameObject);
        }
    }
}
