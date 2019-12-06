using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : ReusableObject
{
    public float time = 1;

    public override void OnSpawn()
    {
        StartCoroutine(DestroyCoroutine());
    }

    public override void OnUnSpawn()
    {
        StopAllCoroutines();
    }
 

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(time);
        //回收
        Game.Instance.objectPool.Unspawn(gameObject);
    }
}
