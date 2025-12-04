using UnityEngine;
using UnityEditor;

public class CustomTextureImporter : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter importer = (TextureImporter)assetImporter;
        importer.mipmapEnabled = false;
        importer.npotScale = TextureImporterNPOTScale.None;
    }
}