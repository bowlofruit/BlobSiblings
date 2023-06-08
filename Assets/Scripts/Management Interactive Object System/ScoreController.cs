using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Collider2D _playerCollider;
    public int Score { get; set;}

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = _playerCollider.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == _playerCollider)
        {
            Score++;
            Destroy(gameObject);
        }
    }
}
