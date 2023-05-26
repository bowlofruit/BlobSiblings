using UnityEngine;

public class PuddleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Collider2D _playerCollider;

    private void Awake()
    {
        _playerCollider = _player.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != _playerCollider)
        {
            collision.GetComponent<PlayerController>().IsDied = true;
        }
    }
}