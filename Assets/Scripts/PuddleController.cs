using System;
using UnityEngine;

namespace BlobSiblings
{
    public class PuddleController : MonoBehaviour
    {
        [SerializeField] private Collider2D[] _playerColliders;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Array.Exists(_playerColliders, collider => collider == collision))
            {
                collision.GetComponent<EventController>().DieStatusChangedEvent.Invoke(true);
                EventController.SwitchInputSystemEvent.Invoke(false);
            }
        }
    }
}