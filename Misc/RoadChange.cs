using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChange : MonoBehaviour {

    GameObject roadNow;
    GameObject roadNext;
    GameObject parent;

	void Start () {
        if (parent == null) {
            parent = new GameObject();
            parent.transform.position = Vector3.zero;
            parent.name = "Road";
        }

        roadNow = Game.Instance.objectPool.Spawn("Pattern_1", parent.transform);
        roadNext = Game.Instance.objectPool.Spawn("Pattern_2", parent.transform);
        roadNext.transform.position += new Vector3(0,0,160);
        AddItem(roadNow);
        AddItem(roadNext);

    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag.road) {
            //回收
            Game.Instance.objectPool.Unspawn(other.gameObject);

            //创建新的铺跑道
            SpawnNewRoad();
        }
    }

    void SpawnNewRoad() {

        int i = Random.Range(1,5);
        //生成新的游戏对象
        roadNow = roadNext;
        roadNext = Game.Instance.objectPool.Spawn("Pattern_"+ i.ToString(),parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0,0,160);
        AddItem(roadNext);
    }

    //生成障碍物
    public void AddItem(GameObject obj)
    {
        var itemChild = obj.transform.Find("Item");
        if(itemChild != null)
        {
            var patternManager = PatternManager.Instance;
            if(patternManager != null && patternManager.Patterns != null && patternManager.Patterns.Count > 0)
            {
                //随机取一个方案
                var pattern = patternManager.Patterns[Random.Range(0, patternManager.Patterns.Count)];
                if(pattern != null && pattern.PatternItems != null && pattern.PatternItems.Count > 0)
                {
                    foreach(var itemList in pattern.PatternItems)
                    {
                        GameObject go = Game.Instance.objectPool.Spawn(itemList.prefabName, itemChild);
                        go.transform.parent = itemChild;
                        go.transform.localPosition = itemList.pos;
                    }
                }
            }
        }
    }

}
