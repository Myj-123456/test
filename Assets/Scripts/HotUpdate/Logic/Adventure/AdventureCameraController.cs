using DG.Tweening;
using FairyGUI;
using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 相机控制器
/// </summary>
public class AdventureCameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.01f;
    [SerializeField]
    private float scaleRatio = 0.72f;
    //相机移动速度
    private float movePointSpeed = 20f;
    private Vector3 dragOrigin = Vector3.zero;
    private float scaleMax = 0f;
    private bool isCameraInit = false;
    private float mapWidth = 0;
    private float mapHeight = 0;
    private bool isMoving = false;

    public float margin = 300f;
    public float scrollDuration = 0.3f;
    public float additionalScrollDuration = 0.1f;
    public float tScale = 1f;
    public float leftBoundary = 0f;
    public float rightBoundary = 1000f;

    private float posX;
    private float stageWidth;
    private bool isScrolling = false;
    public float scrollSpeed = 2f;
    private Camera mainCamera;


    private float limitScaleMax = 0f;
    private float limitScaleMin = 6f;
    private Touch _OldTouch1;  //上次触摸点1(手指1)  
    private Touch _OldTouch2;  //上次触摸点2(手指2)  
    private bool fingerDrag = false;
    private bool fingerMove = false;
    private int fingerId = -1;
    private const float SceneScaleRatio = 1.7f;//场景缩放比率(值越大 那么场景缩放小点)
    private bool isOrgPointReleaseTouch = false;//是否原点释放touch
    private Vector2 targetPos;

    public void SetMap(Transform map, TransformVector2 mapSize)
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        //SpriteRenderer spriteRenderer = map.GetComponent<SpriteRenderer>();
        //var size = spriteRenderer.size;
        //mapWidth = size.x;
        //mapHeight = size.y;
        mapWidth = mapSize.x;
        mapHeight = mapSize.y;
        //相机距离自适应
        //第一版先搁置
        //float limitHeight = size.y * 0.5f;
        //var pixelRatio = (Screen.width / Screen.height) * 0.01f;
        //scaleMax = Mathf.Min(limitHeight, ((size.x / pixelRatio) * 0.5f));
        //limitScaleMax = scaleMax;
        //limitScaleMin = scaleMax * 0.35f;//之前是一半 放到之后字体还是感觉有点模糊 所以改为0.4
        //scaleMax *= scaleRatio;

        //第二版 按照60%(最小) 80%(默认) 100%(最大)

        var fitScreenHeight = 0f;
        if (Screen.width <= 500 && Screen.height <= 900)//暂时为了适配网页上分辨率
        {
            var ratio = 1334 * 1.0f / Screen.height;
            var designOrthographicSize = 6.67f;
            fitScreenHeight = designOrthographicSize * ratio;
        }
        else
        {
            //场景按照手机设备分辨率适配
            //fitScreenHeight = Screen.height * 0.01f * 0.5f;//最大 屏幕高度一半 不合理 pass

            //场景按设计分辨率适配
            var designOrthographicSize = 6.67f * SceneScaleRatio;
            //fitScreenHeight = designOrthographicSize * GRoot.inst.scaleX;

            fitScreenHeight = designOrthographicSize;//固定分辨率

            //fitScreenHeight = designOrthographicSize * (750f / 1334f) / (Screen.width * 1.0f / Screen.height);
        }
        float limitHeight = mapHeight * 0.5f;//限制地图高度

        limitScaleMax = Mathf.Min(limitHeight, fitScreenHeight * 10 / 6); //最小60%
        scaleMax = Mathf.Min(limitHeight, fitScreenHeight * 10 / 8);//默认80%
        limitScaleMin = fitScreenHeight / 1.2f;//最大 放大1.2倍
        if (limitScaleMin <= 5) limitScaleMin = 5;//限制到5吧 
        //mainCamera.orthographicSize = scaleMax;
        //SceneManager.Instance.TweenCameraOrthoSize(scaleMax);


        Debug.Log("Screen.width:" + Screen.width);
        Debug.Log("Screen.height:" + Screen.height);
        Debug.Log("mainCamera.orthographicSize:" + mainCamera.orthographicSize);
        Debug.Log("fitScreenHeight:" + fitScreenHeight);
        Debug.Log("limitScaleMax:" + limitScaleMax);
        Debug.Log("limitScaleMax:" + limitScaleMax);
        Debug.Log("limitScaleMin:" + limitScaleMin);
        Debug.Log("limitHeight:" + limitHeight);
        Debug.Log("moveSpeed:" + moveSpeed);
        isCameraInit = true;
    }


    /// <summary>
    /// 拖拽中
    /// </summary>
    public bool isDraging
    {
        get { return dragOrigin != Vector3.zero; }
    }

    void Update()
    {
        //if (UIManager.Instance.HasWindowShow || UIManager.Instance.HasPanelShow) return;
        if (mainCamera == null || isMoving) return;
        //if (GuideModel.Instance.IsGuiding) return;

        //if (SceneManager.Instance.IsDragging)//拖动种植中
        //{
        //    stageWidth = Screen.width;
        //    float mouseX = Input.mousePosition.x;

        //    if (mouseX > margin && mouseX < stageWidth - margin)
        //    {
        //        isScrolling = false;
        //        return; // Cancel auto-scroll if in the middle of the screen
        //    }

        //    float targetX = (mouseX - stageWidth / 2) * 0.01f * 0.5f + transform.position.x;

        //    isScrolling = true;

        //    if (isScrolling)
        //    {
        //        posX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * scrollSpeed);
        //        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        //    }
        //}
        //else
        //{
        if (UIManager.Instance.IsTouchUI) return;

#if UNITY_EDITOR || UNITY_EDITOR_WIN || (UNITY_WEBGL && !WEIXINMINIGAME)//微信ide也需要开启滚动
        MoveZoomEditor();
#else
            MoveZoomMobileDevices();
#endif
        //}

        if (mainCamera.orthographicSize <= limitScaleMax)
        {
            Vector3 offsetPosition = CalculationPoint(mainCamera.transform.position);
            mainCamera.transform.position = offsetPosition;
        }
        else
        {
            mainCamera.orthographicSize = limitScaleMax;
        }
    }

    private void MoveZoomEditor()
    {
        if (FlowerSellModel.Instance.isSelectFlowerShelfing) return;
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //if (scroll != 0)
        //{
        //    float _Scale = mainCamera.orthographicSize - scroll * 10f; // Adjust zoom speed
        //    if (_Scale <= limitScaleMin) _Scale = limitScaleMin;
        //    if (_Scale >= limitScaleMax) _Scale = limitScaleMax;
        //    mainCamera.orthographicSize = _Scale;
        //    Debug.Log("orthographicSize:" + mainCamera.orthographicSize);
        //    //SceneManager.Instance.IsTouchSceneObject = false;
        //}
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                OrgPointReleaseTouch();
            }
            Vector3 deltaPosition = dragOrigin - Input.mousePosition;
            if (deltaPosition.magnitude > 5f)
            {
                var speed = moveSpeed * (mainCamera.orthographicSize / scaleMax);
                Vector3 movePosition = mainCamera.transform.position + deltaPosition * speed;
                mainCamera.transform.position = movePosition;
                dragOrigin = Input.mousePosition;
                //SceneManager.Instance.IsTouchSceneObject = false;
                isOrgPointReleaseTouch = false;
            }
        }
        else
        {
            dragOrigin = Vector3.zero;
            if (isOrgPointReleaseTouch)
            {
                isOrgPointReleaseTouch = false;
                SentOrgPointReleaseTouchEvent();
            }
        }
    }

    private void OrgPointReleaseTouch()
    {
        if (Stage.isTouchOnUI || PlantModel.Instance.isShowPlantUI)//点击到ui/打开种植ui
        {
            Debug.Log("isTouchOnUI:" + Stage.isTouchOnUI);
            return;
        }
        // 将鼠标的屏幕坐标转换为世界坐标
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //// 发射2D射线检测
        //RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        //if (hit.collider != null)//大部分场景物都不需要响应 除了land
        //{
        //    Debug.Log("has collider:" + hit.collider.name);
        //    return;
        //}
        targetPos = mousePosition;
        isOrgPointReleaseTouch = true;
    }

    private void SentOrgPointReleaseTouchEvent()
    {
        EventManager.Instance.DispatchEvent<Vector3>(SceneEvent.OrgPointReleaseTouch, targetPos);
    }

    private void MoveZoomMobileDevices()
    {
        if (FlowerSellModel.Instance.isSelectFlowerShelfing) return;
        if (Input.touchCount > 0)
        {
            //if (Input.touchCount == 2)
            //{
            //    //多点触摸, 放大缩小  
            //    Touch _NewTouch1 = Input.GetTouch(0);
            //    Touch _NewTouch2 = Input.GetTouch(1);
            //    isOrgPointReleaseTouch = false;//多点禁止
            //    if (_NewTouch2.phase == TouchPhase.Began)
            //    {
            //        fingerDrag = true;
            //        _OldTouch2 = _NewTouch2;
            //        _OldTouch1 = _NewTouch1;
            //        return;
            //    }
            //    else
            //    {
            //        if (!fingerDrag)//微信小游戏有个bug 重复TouchPhase.Began偶现不触发 只能这样子先处理下
            //        {
            //            fingerDrag = true;
            //            _OldTouch2 = _NewTouch2;
            //            _OldTouch1 = _NewTouch1;
            //            return;
            //        }
            //    }
            //    if (_NewTouch1.phase != TouchPhase.Moved && _NewTouch2.phase != TouchPhase.Moved)//没有任何手指移动
            //    {
            //        fingerMove = false;
            //        return;
            //    }
            //    //计算老的两点距离和新的两点间距离  
            //    float _OldDistance = Vector2.Distance(_OldTouch1.position, _OldTouch2.position);
            //    float _NewDistance = Vector2.Distance(_NewTouch1.position, _NewTouch2.position);

            //    //两个距离之差，为正表示放大手势， 为负表示缩小手势  
            //    float _Offset = _NewDistance - _OldDistance;
            //    //放大因子， 一个像素按 0.01倍来算(100可调整)  
            //    float _ScaleFactor = -(_Offset / 100f);
            //    float _Scale = mainCamera.orthographicSize + _ScaleFactor;

            //    //缩放限制
            //    if (_Scale <= limitScaleMin) _Scale = limitScaleMin;
            //    if (_Scale >= limitScaleMax) _Scale = limitScaleMax;
            //    mainCamera.orthographicSize = _Scale;
            //    Debug.Log("orthographicSize:" + mainCamera.orthographicSize);

            //    _OldTouch1 = _NewTouch1;
            //    _OldTouch2 = _NewTouch2;
            //    fingerMove = false;
            //    //SceneManager.Instance.IsTouchSceneObject = false;
            //}
            if (Input.touchCount == 1)
            {
                fingerDrag = false;
                if (Input.GetMouseButton(0))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        fingerMove = true;
                        fingerId = Input.GetTouch(0).fingerId;
                        dragOrigin = Input.mousePosition;
                        OrgPointReleaseTouch();
                    }

                    if (Input.GetTouch(0).phase == TouchPhase.Moved && fingerMove && fingerId == Input.GetTouch(0).fingerId)
                    {
                        Vector3 deltaPosition = dragOrigin - Input.mousePosition;
                        if (deltaPosition.magnitude >= 5f)
                        {
                            var speed = moveSpeed * (mainCamera.orthographicSize / scaleMax);
                            Debug.Log("speed:" + speed);
                            Vector3 movePosition = mainCamera.transform.position + deltaPosition * speed;
                            mainCamera.transform.position = movePosition;
                            dragOrigin = Input.mousePosition;
                            //SceneManager.Instance.IsTouchSceneObject = false;
                            isOrgPointReleaseTouch = false;
                        }
                    }
                }
                else
                {
                    dragOrigin = Vector3.zero;
                    fingerMove = false;
                    fingerId = -1;
                    if (isOrgPointReleaseTouch)
                    {
                        isOrgPointReleaseTouch = false;
                        SentOrgPointReleaseTouchEvent();
                        Debug.Log("Mobile手指原点释放");
                    }
                }
            }
        }
        else
        {
            dragOrigin = Vector3.zero;
            fingerDrag = false;
            fingerMove = false;
            fingerId = -1;
            if (isOrgPointReleaseTouch)
            {
                isOrgPointReleaseTouch = false;
                SentOrgPointReleaseTouchEvent();
                Debug.Log("Mobile手指原点释放");
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="point"></param>
    /// <param name="time"></param>
    /// <param name="isLimitboundary">是否限制边界</param>
    /// <param name="endMoveCallBack"></param>
    public void MoveToPoint(Vector3 point, float time = 0f, bool isLimitboundary = true, UnityAction endMoveCallBack = null)
    {
        isMoving = true;
        var mainCamera = Camera.main;
        var movePoint = point;
        if (isLimitboundary)
        {
            movePoint = CalculationPoint(point);
        }
        movePoint.z = mainCamera.transform.position.z;
        if (Vector3.Distance(mainCamera.transform.position, movePoint) <= 0.1f)
        {
            EndMoveToPoint(movePoint, endMoveCallBack);
            return;
        }

        float duration = time;
        if (duration <= 0)
        {
            float distance = Vector3.Distance(mainCamera.transform.position, movePoint);//计算要移动的距离
            duration = distance / movePointSpeed;//计算需要的时间
            Debug.Log("duration:" + duration);
        }
        mainCamera.transform.DOMove(movePoint, duration).OnComplete(() =>
        {
            EndMoveToPoint(movePoint, endMoveCallBack);
        });
    }

    private void EndMoveToPoint(Vector3 movePoint, UnityAction endMoveCallBack = null)
    {
        var mainCamera = Camera.main;
        mainCamera.transform.position = movePoint;
        isMoving = false;
        endMoveCallBack?.Invoke();
    }

    /// <summary>
    /// 镜头缩放
    /// </summary>
    public void TweenCameraOrthoSize(float targetSize, Action action = null)
    {
        mainCamera.DOOrthoSize(targetSize, 1.2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            action?.Invoke();
        });
    }

    /// <summary>
    /// 镜头缩放
    /// </summary>
    public void TweenCameraOrthoSize(float targetSize, float duration, Action action = null)
    {
        mainCamera.DOOrthoSize(targetSize, duration).OnComplete(() =>
        {
            action?.Invoke();
        });
    }

    /// <summary>
    /// 计算所给点的边缘点
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    private Vector3 CalculationPoint(Vector3 point)
    {
        Camera mainCamera = Camera.main;
        if (!mainCamera || !isCameraInit)
        {
            return point;
        }
        float limitWidth = mapWidth * 0.5f;
        float limitHeight = mapHeight * 0.5f;
        float xMax = point.x + CameraHalf.x;
        float xMin = point.x - CameraHalf.x;
        float yMax = point.y + CameraHalf.y;
        float yMin = point.y - CameraHalf.y;

        if (xMin <= -limitWidth)
        {
            point.x = -limitWidth + CameraHalf.x;
        }
        if (xMax >= limitWidth)
        {
            point.x = limitWidth - CameraHalf.x;
        }
        if (yMin <= -limitHeight)
        {
            point.y = -limitHeight + CameraHalf.y;
        }
        if (yMax >= limitHeight)
        {
            point.y = limitHeight - CameraHalf.y;
        }
        point.z = mainCamera.transform.position.z;
        return point;
    }

    /// <summary>
    /// 摄像机半边的宽高
    /// </summary>
    public Vector2 CameraHalf
    {
        get
        {
            //获取摄像机半边的宽高
            Camera mainCamera = Camera.main;
            float cameraHalfHeight = mainCamera.orthographic ? mainCamera.orthographicSize : Mathf.Abs(transform.position.z) * Mathf.Tan(mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            float cameraHalfWidth = mainCamera.orthographic ? mainCamera.orthographicSize * mainCamera.aspect : cameraHalfHeight * mainCamera.aspect;
            return new Vector2(cameraHalfWidth, cameraHalfHeight);
        }
    }
}