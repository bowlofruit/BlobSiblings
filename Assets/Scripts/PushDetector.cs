using UnityEngine;
using UnityEngine.Events;

namespace BlobSiblings
{
    public class PushDetector : MonoBehaviour
    {
        public UnityEvent<bool> PushCheckEvent { get; set; } = new UnityEvent<bool>();

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider != null)
            {
                PushCheckEvent.Invoke(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider != null)
            {
                PushCheckEvent.Invoke(false);
            }
        }
    }
}