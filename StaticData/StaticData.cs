using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StaticData : MonoSingleton<StaticData>
{
    Dictionary<int, FootBallInfo> m_FootBallData = new Dictionary<int, FootBallInfo>();
    public List<Material> FootBallMat;

    Dictionary<int, Dictionary<int, FootBallInfo>> m_PlayerClothData = new Dictionary<int, Dictionary<int, FootBallInfo>>();
    public List<Material> PlayerCloth;

    //初始化足球信息
    void InitFootBall()
    {
        m_FootBallData.Add(0, new FootBallInfo() { Coin = 0, Material = FootBallMat[0] });
        m_FootBallData.Add(1, new FootBallInfo() { Coin = 200, Material = FootBallMat[1] });
        m_FootBallData.Add(2, new FootBallInfo() { Coin = 400, Material = FootBallMat[2] });
    }


    void InitPlayerCloth()
    {
        int t = 0;
        for(int i = 0;i <3; i++)
        {
            for(int j = 0;j< 3;j++)
            {
                if (!m_PlayerClothData.ContainsKey(i))
                {
                    m_PlayerClothData.Add(i, new Dictionary<int, FootBallInfo>());

                }
                //print(t * 200);
                m_PlayerClothData[i].Add(j, new FootBallInfo { Coin = t * 200, Material = PlayerCloth[t] });
                t++;
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        InitFootBall();
        InitPlayerCloth();
    }

    public FootBallInfo GetFootballInfo(int i )
    {
        return m_FootBallData[i];
    }

 public FootBallInfo GetPlayerInfo(int i,int j)
    {
        return m_PlayerClothData[i][j];
    }
}
