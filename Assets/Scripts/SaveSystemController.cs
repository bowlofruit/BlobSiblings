using System.IO;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerObjects;
    private Vector3[] _playerPos;

    private void Start()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        if (_playerObjects == null || _playerObjects.Length == 0)
        {
            Debug.LogError("Player objects reference is null or empty. Cannot save game.");
            return;
        }

        _playerPos = new Vector3[_playerObjects.Length];

        for (int i = 0; i < _playerObjects.Length; i++)
        {
            _playerPos[i] = _playerObjects[i].transform.position;
        }

        PlayerPositionData playerPositionData = new PlayerPositionData
        {
            _playerPositions = _playerPos
        };

        string json = JsonUtility.ToJson(playerPositionData);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
        Debug.Log(Application.persistentDataPath + "/saveFile.json");
        Debug.Log("Save complete!");
    }

    public void LoadGame()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        PlayerPositionData loadedPlayerData = JsonUtility.FromJson<PlayerPositionData>(json);

        _playerPos = loadedPlayerData._playerPositions;

        if (_playerObjects != null && _playerObjects.Length == _playerPos.Length)
        {
            for (int i = 0; i < _playerObjects.Length; i++)
            {
                _playerObjects[i].transform.position = _playerPos[i];
            }
        }

        Debug.Log("Load complete!");
    }
}

[System.Serializable]
public class PlayerPositionData
{
    public Vector3[] _playerPositions;
}