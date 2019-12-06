using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatternManager : MonoSingleton<PatternManager> {
    public List<Pattern> Patterns = new List<Pattern>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[Serializable]
//一个游戏物体的信息
public class PatternItem
{
    public string prefabName;
    public Vector3 pos;
}
[Serializable]
//一套方案
public class Pattern
{
    public List<PatternItem> PatternItems = new List<PatternItem>();
}
