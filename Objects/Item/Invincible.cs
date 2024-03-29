﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : Item {
    public override void HitPlayer(Transform pos)
    {
        //2.声音
        Game.Instance.sound.PlayEffect("Se_UI_Whist");

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
            //other.SendMessage("HitInvincible", SendMessageOptions.RequireReceiver);//HitItem
            other.SendMessage("HitItem", ItemKind.ItemInvincible);
        }
    }
}
