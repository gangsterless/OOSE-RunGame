using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item {

    Transform effectPrent;
    public float moveSpeed = 40;

    public override void HitPlayer(Transform pos)
    {
        //1.特效
        GameObject go = Game.Instance.objectPool.Spawn("FX_JinBi", effectPrent);
        go.transform.position = pos.position;

        //2.声音
        Game.Instance.sound.PlayEffect("Se_UI_JinBi");

        //3.回收
        Game.Instance.objectPool.Unspawn(gameObject);
        //Destroy(gameObject);
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUnSpawn()
    {
        base.OnUnSpawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tag.player)
        {
            HitPlayer(other.transform);
            other.SendMessage("HitCoin", SendMessageOptions.RequireReceiver);
        }else if(other.tag == Tag.magnetCollider)
        {
            //飞向主角
            StartCoroutine(HitMagnet(other.transform));
        }
    }

    IEnumerator HitMagnet(Transform pos)
    {
       bool isLoop = true;
        while (isLoop)
        {
            transform.position = Vector3.Lerp(transform.position,pos.position, moveSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position,pos.position) <0.5f)
            {
                isLoop = false;
                HitPlayer(pos.transform);
                pos.parent. SendMessage("HitCoin", SendMessageOptions.RequireReceiver);
            }
            yield return 0;
        }
    }


    private void Awake()
    {
        effectPrent = GameObject.Find("EffectParent").transform;
    }
}
