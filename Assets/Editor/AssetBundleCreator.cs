using UnityEditor;

public class AssetBundleCreator
{
    [MenuItem("Assets/Create Asset Bundle")]
    public static void AssetBundleCreate()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}