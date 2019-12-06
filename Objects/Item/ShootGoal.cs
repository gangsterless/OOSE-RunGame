using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGoal : ReusableObject
{
   public  Animation goalKeeper;
   public  Animation door;
    public GameObject net;
    public float speed = 10;
    bool m_IsFly = false;

    public override void OnSpawn()
    {
        
    }

    public override void OnUnSpawn()
    {
        goalKeeper.Play("standard");
        door.Play("QiuMen_St");
        net.SetActive(true);
        //goalKeeper.gameObject.SetActive(true);
        goalKeeper.gameObject.transform.parent.parent.gameObject.SetActive(true);
        m_IsFly = false;
        StopAllCoroutines();
        goalKeeper.transform.localPosition = Vector3.zero;
    }

    //表示进球了，孩子发送一个消息
    public void ShootAGoal(int i )
    {
        switch (i)
        {
            case -2:
                goalKeeper.Play("left_flutter");
                break;
            case 0:
                goalKeeper.Play("flutter");
                break;
            case 2:
                goalKeeper.Play("right_flutter");
                break;
        }
        StartCoroutine(HideGoalKeeper());
    } 

    IEnumerator HideGoalKeeper()
    {
        yield return new WaitForSeconds(1f);
        goalKeeper.gameObject.transform.parent.parent.gameObject.SetActive(false);

    }

    //撞飞
    public void HitGoalKeeper()
    {
        m_IsFly = true;
        goalKeeper.Play("fly");
    }

    private void Update()
    {
        if (m_IsFly)
        {
            goalKeeper.transform.position += new Vector3(0, speed, speed) * Time.deltaTime;
        }
    }

    public void HitDoor(int i)
    {
        //1.door 动画
        switch (i)
        {
            case 0:
                door.Play("QiuMen_RR");
                break;
            case 1:
                door.Play("QiuMen_St");
                break;
            case 2:
                door.Play("QiuMen_LR");
                break;

        }
        //2.球网消失
        net.SetActive(false);
    }
}
