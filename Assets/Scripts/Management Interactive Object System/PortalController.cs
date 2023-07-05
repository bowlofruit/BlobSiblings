using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Collider2D _playerCollider;
    public static int _playersFinishedCount;


    private void Awake()
    {
        _playersFinishedCount = 0;
        GetComponent<SpriteRenderer>().color = _playerCollider.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == _playerCollider)
        {
            _playersFinishedCount++;

            if (_playersFinishedCount == 2)
            {
                _playerCollider.gameObject.transform.position = GetComponent<Collider2D>().bounds.center;
                EventController.LevelComplete.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == _playerCollider)
        {
            _playersFinishedCount--;
        }
    }
}