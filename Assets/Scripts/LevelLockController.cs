using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLockController : MonoBehaviour
{
    private int _openLevels = 0;

    [SerializeField] private Button[] _levelChoose;

    private void Awake()
    {
        PlayerPrefs.SetInt("CompletedLevelsCount", 2);
        Debug.Log(PlayerPrefs.GetInt("CompletedLevelsCount"));

        foreach (var button in _levelChoose)
        {
            button.interactable = false;
        }

        EventController.LevelComplete.AddListener(AddCompletedLevelsCount);
    }

    public void LevelChooseButtonInit()
    {
        if (PlayerPrefs.HasKey("CompletedLevelsCount"))
        {
            _openLevels = PlayerPrefs.GetInt("CompletedLevelsCount");
        }
        else
        {
            AddCompletedLevelsCount();
        }

        for (int i = 0; i < _openLevels; i++)
        {
            _levelChoose[i].interactable = true;
        }
    }

    public void AddCompletedLevelsCount()
    {
        _openLevels++;
        PlayerPrefs.SetInt("CompletedLevelsCount", _openLevels);
    }

    public void ResetCompleteLevelCount()
    {
        PlayerPrefs.DeleteKey("CompletedLevelsCount");
        Debug.Log(PlayerPrefs.GetInt("CompletedLevelsCount"));
    }

    public void LevelStart(int selectedLevel)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + selectedLevel);
    }
}