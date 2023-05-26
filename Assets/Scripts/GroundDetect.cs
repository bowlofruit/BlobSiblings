using UnityEngine;
using UnityEngine.Events;

public class GroundDetect : MonoBehaviour
{
    public UnityEvent<bool> OnGroundCheck { get; set; } = new UnityEvent<bool>();

    private bool _isGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            Debug.Log("Enter");
            _isGround = true;
            OnGroundCheck.Invoke(_isGround);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision != null) 
        {
            Debug.Log("Exit");
            _isGround = false;
            OnGroundCheck.Invoke(_isGround);
        }
    }
}
