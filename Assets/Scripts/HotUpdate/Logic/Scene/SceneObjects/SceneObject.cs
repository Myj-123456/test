using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 场景对象枚举
/// </summary>
public enum SceneObjectType
{
    Null,
    Structure,
    Land,
    Decoration,
    OrderNpc,
    Mouse,
}

/// <summary>
/// 场景层对象
/// </summary>
public class SceneObject : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public int uid;
    public string objectUid;//场景物唯一id(这个是根据前端自定义的id) 所有基础这个类都需要指定uid
    protected SceneObjectType sceneObjectType = SceneObjectType.Null;
    public object data = null;
    private float longPressDuration = 0.5f; // 长按判定时间（秒）
    private bool isPointerDown = false;
    private bool isLongPress = false;//触发长按
    private float pressTime = 0f;

    /// <summary>
    /// 设置场景uid
    /// </summary>
    protected void SetObjectUid(uint uid)
    {
        this.uid = (int)uid;
        try
        {
            objectUid = ((uint)sceneObjectType * 10).ToString() + uid; //根据SceneObjectType * 10作为前置类型
        }
        catch (System.Exception e)
        {
            Debug.Log(uid);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UIManager.Instance.HasWindowShow || UIManager.Instance.HasPanelShow) return;
        if (Stage.isTouchOnUI || SceneManager.Instance.IsTouchOnUI || !SceneManager.Instance.IsTouchSceneObject|| FlowerShopModel.Instance.isEditing|| SceneManager.Instance.IsDragging) return;
        if (!MyselfModel.Instance.atHome)
        {
            return;//非己方不可交互
        }
        StartCoroutine(DispatchEvent(eventData));
    }
    private IEnumerator DispatchEvent(PointerEventData eventData)
    {
        yield return new WaitForSeconds(0.01f);//延迟10ms再发
        if (Stage.isTouchOnUI || SceneManager.Instance.IsTouchOnUI) yield break;
        if (isLongPress) yield break;//触发长按 就不会再触发OnClick
        // 触发事件
        OnClick();//内部
        EventManager.Instance.DispatchEvent(SceneEvent.SceneObjectClick, this);//外部
    }
    /// <summary>
    /// 点击回调 子对象必须重写
    /// </summary>
    protected virtual void OnClick()
    {

    }

    /// <summary>
    /// 长按回调 子对象必须重写
    /// </summary>
    protected virtual void OnLongPress()
    {

    }

    private Vector3 touchPos;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (UIManager.Instance.HasWindowShow || UIManager.Instance.HasPanelShow) return;
        if (Stage.isTouchOnUI || SceneManager.Instance.IsTouchOnUI) return;
        if (FlowerShopModel.Instance.isEditing) return;
        if (!MyselfModel.Instance.atHome)
        {
            return;//非己方不可交互
        }
        touchPos = eventData.position;
        isPointerDown = true;
        isLongPress = false;
        SceneManager.Instance.isLongPress = false;
        pressTime = Time.time;
        StartCoroutine(CheckLongPress());
        SceneManager.Instance.IsTouchSceneObject = true;
        SceneManager.Instance.sceneObjectType = sceneObjectType;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        //SceneManager.Instance.IsTouchSceneObject = true;
        SceneManager.Instance.sceneObjectType = SceneObjectType.Null;
    }

    private IEnumerator CheckLongPress()
    {
        yield return new WaitForSeconds(longPressDuration);

        if (isPointerDown && Time.time - pressTime >= longPressDuration)
        {
            float currentDistance = Vector3.Distance(touchPos, Input.mousePosition);
            if (currentDistance > 0.1f)
            {
                yield break;
            }
            // 触发长按事件
            isLongPress = true;
            SceneManager.Instance.isLongPress = true;
            OnLongPress();
        }
    }
}
