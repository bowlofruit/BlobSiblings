using UnityEngine;

public class LevelCompleteMenu : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompleteMenu;

    private void Awake()
    {
        EventController.LevelComplete.AddListener(ActivityMenu);
    }

    private void ActivityMenu()
    {
        _levelCompleteMenu.SetActive(true);
    }
}
