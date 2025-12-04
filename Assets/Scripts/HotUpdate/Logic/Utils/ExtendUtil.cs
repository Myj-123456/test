using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using YooAsset;

//扩展工具类
public static class ExtendUtil
{
    /// <summary>
    /// 动态加载并设置一个图片
    /// </summary>
    /// <param name="spriteRenderer"></param>
    /// <param name="url"></param>
    public static void SetTexture(this SpriteRenderer spriteRenderer, string url, Action showCall = null)
    {
        AssetHandle assetHandle = ResourceManager.Instance.LoadAssetAsync<Texture2D>(url);
        assetHandle.Completed += (AssetHandle handle) =>
        {
            if (handle.Status == EOperationStatus.Succeed)
            {
                SetTexture(spriteRenderer, handle.AssetObject as Texture2D);
                showCall?.Invoke();
            }
            else
            {
                Debug.Log("图片资源找不到，url：" + url);
            }
        };
    }

    public static void SetSprite(this SpriteRenderer spriteRenderer, string url, Action showCall = null)
    {
        AssetHandle assetHandle = ResourceManager.Instance.LoadAssetAsync<Sprite>(url);
        assetHandle.Completed += (AssetHandle handle) =>
        {
            spriteRenderer.sprite = handle.AssetObject as Sprite;
            showCall?.Invoke();
        };
    }

    /// <summary>
    /// 直接用Texture2D设置图片
    /// </summary>
    /// <param name="spriteRenderer"></param>
    /// <param name="texture"></param>
    public static void SetTexture(this SpriteRenderer spriteRenderer, Texture2D texture)
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not assigned.");
            return;
        }
        // Create a new Sprite from the Texture2D
        Sprite sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f)
        );

        sprite.name = texture.name;
        // Assign the new Sprite to the SpriteRenderer
        spriteRenderer.sprite = sprite;

    }
}
