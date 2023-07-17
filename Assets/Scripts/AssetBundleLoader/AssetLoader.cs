using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetLoader : MonoBehaviour
{
    [SerializeField] private string _dropboxURL = "https://www.dropbox.com/s/ifj8r0jni5d204b/environment_game_object_sprite.manifest?dl=0";
    [SerializeField] private string _spriteAssetName;
    [SerializeField] private GameObject _targetObject;

    private void Start()
    {
        StartCoroutine(LoadSpriteFromAssetBundle(_dropboxURL, _spriteAssetName));
    }

    private IEnumerator LoadSpriteFromAssetBundle(string url, string assetName)
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

            if (bundle != null)
            {
                Sprite sprite = bundle.LoadAsset<Sprite>(assetName);
                ApplySpriteToTarget(sprite);
            }
            else
            {
                Debug.LogError("Failed to load Asset Bundle from URL: " + url);
            }
        }
        else
        {
            Debug.LogError("Failed to download Asset Bundle from URL: " + www.error);
        }
    }

    private void ApplySpriteToTarget(Sprite sprite)
    {
        if (_targetObject.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
        {
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("Target object does not have a SpriteRenderer component.");
        }
    }
}