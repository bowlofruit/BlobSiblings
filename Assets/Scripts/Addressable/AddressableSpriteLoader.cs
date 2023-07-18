using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesSpriteLoader : MonoBehaviour
{
    [SerializeField] AssetReference loadableSprite;
    [SerializeField] Image uiImage;

    private IEnumerator Start()
    {
        AsyncOperationHandle<Sprite> handle = loadableSprite.LoadAssetAsync<Sprite>();
        yield return handle;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            uiImage.sprite = sprite;
            Addressables.Release(handle);
        }
    }
}