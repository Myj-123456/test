using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class BucketManager : Singleton<BucketManager>
{
    private List<Bucket> bucketMap;
    private List<Vector3> pos = new List<Vector3>
    {
         new Vector3(){x = 2.1f,y = -1.64f},
        new Vector3(){x = 2.85f,y = -1.06f},
        new Vector3(){x = 3.67f,y = -0.55f},
        new Vector3(){x = 4.46f,y = 0.09f},
        new Vector3(){x = 2.96f,y = -2.32f},
        new Vector3(){x = 3.76f,y = -1.79f},
        new Vector3(){x = 4.55f,y = -1.21f},
        new Vector3(){x = 5.3f,y = -0.58f},
    };

    public void InitBucket(Transform parent)
    {
        bucketMap = new List<Bucket>();
        for (int i = GlobalModel.Instance.module_profileConfig.bucketMax - 1; i >= 0; i--)
        {
            var panel = GetUIPanel();
            var bucket = panel.gameObject.AddComponent<Bucket>();
            bucket.Init(i, panel, parent, pos[i]);
            bucketMap.Insert(0, bucket);
        }
    }

    private UIPanel GetUIPanel()
    {
        GameObject emptyObject = new GameObject("BucketItem");
        var panel = emptyObject.AddComponent<UIPanel>();
        panel.packageName = "fun_Scene";
        panel.componentName = "bucket_item";
        panel.container.touchable = true;
        panel.container.renderMode = RenderMode.WorldSpace;
        panel.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        return panel;
    }

    public void UpdateBucket()
    {
        for (int i = 0; i < GlobalModel.Instance.module_profileConfig.bucketMax; i++)
        {
            if (MyselfModel.Instance.waterBucketSeries[i] == 1)
            {
                bucketMap[i].visible = true;
            }
            else
            {
                bucketMap[i].visible = false;
            }
        }
    }
    public Bucket GetBucket()
    {
        if (bucketMap == null) return null;
        foreach (var bucket in bucketMap)
        {
            if (bucket.visible)
            {
                return bucket;
            }
        }
        return null;
    }

    public Bucket GetBucketByIndex(int idx)
    {
        if (bucketMap == null || bucketMap.Count <= 0) return null;
        return bucketMap[idx];
    }
}
