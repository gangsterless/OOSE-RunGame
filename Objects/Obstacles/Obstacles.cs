using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : ReusableObject
{
   protected Transform effectPrent;

    protected virtual void Awake()
    {
        effectPrent = GameObject.Find("EffectParent").transform;
    }

    public override void OnSpawn()
    {
    }

    public override void OnUnSpawn()
    {
    }

    public virtual void HitPlayer(Vector3 pos)
    {
        //1.特效
        GameObject go =  Game.Instance.objectPool.Spawn("FX_ZhuangJi", effectPrent);
        go.transform.position = pos;


        //3.回收
        Game.Instance.objectPool.Unspawn(gameObject);
        //Destroy(gameObject);

    }
}
