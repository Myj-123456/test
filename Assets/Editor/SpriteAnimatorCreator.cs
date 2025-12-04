using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SpriteAnimatorCreator : Editor
{
    [MenuItem("Assets/Create Sprite Animations", false, 99)]
    static void CreateSpriteAnimations()
    {
        // 获取选中的文件夹路径
        string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
        {
            Debug.LogError("请选择一个有效的文件夹！");
            return;
        }

        // 获取文件夹名称
        string folderName = new DirectoryInfo(folderPath).Name;

        // 获取文件夹下的所有图片，并按自然顺序排序
        string[] imagePaths = Directory.GetFiles(folderPath, "*.png");
        List<string> sortedImagePaths = new List<string>(imagePaths);
        sortedImagePaths.Sort(NaturalSort);

        List<Sprite> sprites = new List<Sprite>();
        foreach (string imagePath in sortedImagePaths)
        {
            // 转换路径格式
            string assetPath = imagePath.Replace("\\", "/");
            TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (textureImporter != null)
            {
                // 设置为 Sprite 类型，Single 模式
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spriteImportMode = SpriteImportMode.Single;
                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);

                // 加载 Sprite
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                if (sprite != null)
                {
                    sprites.Add(sprite);
                }
            }
        }

        // 创建 AnimationClip
        AnimationClip animClip = new AnimationClip
        {
            frameRate = 10 // 设置帧率，可以根据需要调整
        };

        EditorCurveBinding curveBinding = new EditorCurveBinding
        {
            type = typeof(SpriteRenderer),
            path = "",
            propertyName = "m_Sprite"
        };

        ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[sprites.Count];
        for (int i = 0; i < keyFrames.Length; i++)
        {
            keyFrames[i] = new ObjectReferenceKeyframe
            {
                time = i * (1.0f / animClip.frameRate),
                value = sprites[i]
            };
        }

        AnimationUtility.SetObjectReferenceCurve(animClip, curveBinding, keyFrames);

        // 设置动画为循环
        AnimationClipSettings clipSettings = AnimationUtility.GetAnimationClipSettings(animClip);
        clipSettings.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(animClip, clipSettings);

        AssetDatabase.CreateAsset(animClip, Path.Combine(folderPath, folderName + ".anim"));

        // 创建 Animator Controller
        AnimatorController animatorController = AnimatorController.CreateAnimatorControllerAtPath(Path.Combine(folderPath, folderName + ".controller"));
        var rootStateMachine = animatorController.layers[0].stateMachine;
        AnimatorState state = rootStateMachine.AddState("AnimationState");
        state.motion = animClip;

        // 创建预制体
        GameObject prefab = new GameObject(folderName);
        SpriteRenderer spriteRenderer = prefab.AddComponent<SpriteRenderer>();
        Animator animator = prefab.AddComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;

        string prefabPath = Path.Combine(folderPath, folderName + ".prefab");
        PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);

        // 清理
        GameObject.DestroyImmediate(prefab);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("动画和预制体创建成功！");
    }

    static int NaturalSort(string a, string b)
    {
        return EditorUtility.NaturalCompare(Path.GetFileNameWithoutExtension(a), Path.GetFileNameWithoutExtension(b));
    }
}