
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///< summary >
/// 对象池
/// </summary>
public class GameObjectPool : MonoSingleton<GameObjectPool>
{

    //内部容器，用于存入缓存的对象
    private Dictionary<string, List<GameObject>> cache = new Dictionary<string, List<GameObject>>();

    //构造函数私有化，防止外部调用实例化破坏单例规则
    private GameObjectPool() { }


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    /// 生产物体
    /// </summary>
    public GameObject GetObject(string key, GameObject go, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        //有：key对应列表中有没有可用(非活动状态)的物体
        var tempGo = FindUsable(key);
        if (tempGo != null)
        {
            //有：设置后返回可用物体
            tempGo.transform.position = position;
            tempGo.transform.rotation = quaternion;
            tempGo.transform.SetParent(parent,false);
            tempGo.SetActive(true);
        }
        else
        {
            //没有:(场景中没有，内存中也没有)创建物体后添加cache，
            tempGo = Instantiate(go, position, quaternion) as GameObject;
            tempGo.transform.SetParent(parent, false);
            Add(key, tempGo);
        }
        return tempGo;
    }

    /// <summary>
    /// 将对象放入缓存
    /// </summary>
    private void Add(string key, GameObject newObject)
    {
        //创建key,创建key的列表
        if (!cache.ContainsKey(key))
            cache.Add(key, new List<GameObject>());
        cache[key].Add(newObject);
    }

    /// <summary>
    /// 找对应key的列表中没有没可用的物体
    /// </summary>
    private GameObject FindUsable(string key)
    {
        //有Key: 找非活动状态的物体
        if (cache.ContainsKey(key))
        {
            return cache[key].Find(p => !p.activeSelf);
        }
        return null;
    }

    /// <summary>
    /// 即时回收
    /// </summary>
    /// <param name="go">要回收的对象</param>
    public void ReturnObject(GameObject go)
    {
        
        if(go != null) go.SetActive(false);
    }

    /// <summary>
    /// 延时回收
    /// </summary>
    /// <param name="go">要回收的对象</param>
    /// <param name="delay">延时时长</param>
    public void CollectObject(GameObject go, float delay)
    {
        //开启协程
        StartCoroutine(Delay(go, delay));
    }

    /// <summary>
    /// 用于回收的协程方法
    /// </summary>
    public IEnumerator Delay(GameObject go, float delay)
    {
        //等待delay之后，
        yield return new WaitForSeconds(delay);
        //调用即时回收
        ReturnObject(go);
    }

    /// <summary>
    /// 将key对象的缓存物体从池中清除（销毁）
    /// </summary>
    /// <param name="key"></param>
    public void Clear(string key)
    {
        if (cache.ContainsKey(key))
        {
            while (cache[key].Count > 0)
            {
                //销毁每个物体
                Destroy(cache[key][0]);
                //删除列表中的空引用
                cache[key].RemoveAt(0);
            }
            //删除key
            cache.Remove(key);
        }
    }

    /// <summary>
    /// 清空池中物体
    /// </summary>
    public void ClearAll()
    {

        //遍历所有的key
        List<string> keys = new List<string>(cache.Keys);
        //逐个清除
        while (cache.Count > 0)
        {
            Clear(keys[0]);
            keys.RemoveAt(0);
        }
    }
}
