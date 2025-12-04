using ADK;
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public class TransformVector2
{
    public float x;
    public float y;
}

[System.Serializable]
public class TransformVector3
{
    public float x;
    public float y;
    public float z;
}

[System.Serializable]
public class TransformVector4
{
    public TransformVector2 left;
    public TransformVector2 up;
    public TransformVector2 right;
    public TransformVector2 down;
    public override bool Equals(object obj)
    {
        if (obj is TransformVector4 other)
        {
            return left == other.left && up == other.up &&
                   right == other.right && down == other.down;
        }
        return false;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + left.GetHashCode();
            hash = hash * 23 + up.GetHashCode();
            hash = hash * 23 + right.GetHashCode();
            hash = hash * 23 + down.GetHashCode();
            return hash;
        }
    }
}

[System.Serializable]
public class ObstacleData
{
    public int gridId;
    public string objectShow;
    public List<FogData> fogs;
    public TransformVector3 position;
    public TransformVector3 rotation;
    public TransformVector3 scale;
}

/// <summary>
/// 场景障碍
/// </summary>
/// 

public class Obstacle : MonoBehaviour
{
    public int gridId;
    public int enemyId;
    public string objectShow;
    public List<Fog> fogs;
    [SerializeField]
    private GameObject bubbleObject;
    [SerializeField]
    private UIPanel bubbleItem;
    public Action OnClickAction;
    private bool isMeetCost = false;
    private int costItemId;
    private void Start()
    {
        bubbleItem.ui.onClick.Add(OnClickBubble);
    }

    private void OnClickBubble()
    {
        OnClickAction?.Invoke();
        OnClickAction = null;
    }

    public void ShowHideBubble(bool isShow)
    {
        bubbleItem.gameObject.SetActive(isShow);
        if (isShow)
        {
            UpdateBubble();
            CancelInvoke("DelayHide");
            Invoke("DelayHide", 10f);
        }
        else
        {
            CancelInvoke("DelayHide");
        }
    }

    public bool CheckCanClick(bool isShowPrompt = true)
    {
        if (isMeetCost)
        {
            return true;
        }
        else
        {
            if (isShowPrompt)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("slang_128", ItemModel.Instance.GetNameByEntityID(costItemId)));
            }
            return false;
        }
    }

    private void UpdateBubble()
    {
        var gridConfig = AdventureModel.Instance.GetGridConfig(gridId);
        if (gridConfig != null)
        {
            var bubble = bubbleItem.ui as fun_Adventure.BubbleItem;
            var size = GetComponent<BoxCollider2D>().size;
            string pattern = @"^shu\d$";
            bool isMatch = Regex.IsMatch(objectShow, pattern);
            if (isMatch)//如果是树
            {
                bubbleObject.transform.localPosition = new Vector3(0, size.y * transform.localScale.y, 0);
            }
            else
            {
                bubbleObject.transform.localPosition = new Vector3(0, size.y / 2 * transform.localScale.y, 0);
            }
            if (gridConfig.ObjectType == 2)
            {
                bubble.c1.selectedIndex = 1;
                isMeetCost = true;
            }
            else
            {
                bubble.c1.selectedIndex = 0;
                if (gridConfig.ClearCosts.Length > 0)
                {
                    var clearCost = gridConfig.ClearCosts[0];
                    var itemId = ADK.IDUtil.GetEntityValue(clearCost.EntityID);
                    costItemId = itemId;
                    bubble.img_itemIcon.url = ImageDataModel.Instance.GetIconUrlByEntityId(itemId);
                    bubble.txt_costNum.text = clearCost.Value.ToString();
                    var ownItemNum = StorageModel.Instance.GetItemCount(clearCost.EntityID);
                    isMeetCost = ownItemNum >= clearCost.Value;
                }
            }
        }
    }

    private void DelayHide()
    {
        ShowHideBubble(false);
    }
}
