using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace BlobSiblings
{
    public class AddressableLoaderLevel : MonoBehaviour
    {
        [SerializeField] private string _levelName;

        public async void LoadLevel()
        {
            var asyncOperationHandle = Addressables.LoadSceneAsync(_levelName, LoadSceneMode.Single);
            await asyncOperationHandle.Task;

            Debug.Log("Load success");
        }
    }
}