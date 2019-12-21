using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool> {

    /// <summary>
    /// 资源目录
    /// </summary>
    public string ResourceDir = "";

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();

    //取出物体
    public GameObject Spawn(string name,Transform trans) {
        SubPool pool = null;
        if (!m_pools.ContainsKey(name)) {
            RegieterNew(name,trans);
        }
        pool = m_pools[name];
       return  pool.Spawn();
    }

    //回收物体
    public void Unspawn(GameObject go) {
        SubPool pool = null;
        foreach (var p in m_pools.Values) {
            if (p.Contain(go)) {
                pool = p;
                break;
            }
        }
        pool.UnSpawn(go);
    }

    //回收所有
    public void UnspawnAll() {
        foreach (var p in m_pools.Values) {
            p.UnspawnAll();
        }
    }

    //清除所有
    public void Clear()
    {
        m_pools.Clear();
    }

    //新建一个池子
    void RegieterNew(string names,Transform trans) {
        //资源目录
        string path = ResourceDir + "/" + names;
        //生成预制体
        GameObject go = Resources.Load<GameObject>(path);
        //新建一池子
        SubPool pool = new SubPool(trans ,go);
        m_pools.Add(pool.Name,pool);
    }
}
