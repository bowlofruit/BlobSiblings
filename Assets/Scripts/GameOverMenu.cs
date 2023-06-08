using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;

    private void Awake()
    {
        EventController.LevelFailed.AddListener(ActivityMenu);
    }

    private void ActivityMenu()
    {
        _gameOverMenu.SetActive(true);
    }
}
