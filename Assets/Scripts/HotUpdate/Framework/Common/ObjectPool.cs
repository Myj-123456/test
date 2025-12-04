using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一个GameObject对象池
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> availableObjects = new List<T>();
    private T prefab;

    public ObjectPool(T prefab, int initialSize)
    {
        this.prefab = prefab;
        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            availableObjects.Add(obj);
        }
    }

    public T GetObject()
    {
        if (availableObjects.Count > 0)
        {
            T obj = availableObjects[0];
            availableObjects.RemoveAt(0);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T obj = GameObject.Instantiate(prefab);
            return obj;
        }
    }

    public void ReleaseObject(T obj)
    {
        obj.gameObject.SetActive(false);
        availableObjects.Add(obj);
    }
}