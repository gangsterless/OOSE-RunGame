using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SubPool
{
    //集合
    List<GameObject> m_objecs = new List<GameObject>();

    //预设
    GameObject m_prefab;

    //父物体的位置
    Transform m_parent;


    //名字
    public string Name
    {
        get
        {
            return m_prefab.name;
        }
    }

    public SubPool(Transform parent, GameObject go)
    {
        m_prefab = go;
        m_parent = parent;
    }

    //取出物体
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (var obj in m_objecs)
        {

            if (!obj.activeSelf)
            {
                go = obj;
            }
        }

        if (go == null)
        {
            go = GameObject.Instantiate<GameObject>(m_prefab);
            go.transform.parent = m_parent;
            m_objecs.Add(go);
        }
        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        return go;
    }

    //回收物体
    public void UnSpawn(GameObject go)
    {
        if (Contain(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }


    //回收所有
    public void UnspawnAll()
    {
        foreach (var obj in m_objecs)
        {

            if (obj.activeSelf)
            {
                UnSpawn(obj);
            }
        }

    }

    //判断是否属于list里边
    public bool Contain(GameObject  go) {

        return m_objecs.Contains(go);
    
    }
}