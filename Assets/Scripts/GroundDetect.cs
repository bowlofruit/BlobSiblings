using UnityEngine;
using UnityEngine.Events;

namespace BlobSiblings
{
    public class GroundDetect : MonoBehaviour
    {
        public UnityEvent<float> ChangeIceAccelerationEvent { get; set; } = new UnityEvent<float>();
        public UnityEvent<bool> GroundCheckEvent { get; set; } = new UnityEvent<bool>();

        private int _groundColliderCount = 0;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Ice"))
            {
                ChangeIceAccelerationEvent.Invoke(1.4f);
            }
            else
            {
                ChangeIceAccelerationEvent.Invoke(1f);
            }

            if (collider != null && _groundColliderCount == 0)
            {
                GroundCheckEvent.Invoke(true);
            }

            _groundColliderCount++;
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            _groundColliderCount--;

            if (collider != null && _groundColliderCount == 0)
            {
                GroundCheckEvent.Invoke(false);
            }
        }
    }
}