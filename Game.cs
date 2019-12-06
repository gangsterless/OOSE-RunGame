using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Sound))]
[RequireComponent(typeof(StaticData))]
public class Game : MonoSingleton<Game> {

    //全局访问
    [HideInInspector]
    public ObjectPool objectPool;
    [HideInInspector]
    public Sound sound;
    [HideInInspector]
    public StaticData staticData;


    private void Start()
    {
        //别删
        DontDestroyOnLoad(gameObject);

        objectPool = ObjectPool.Instance;
        sound = Sound.Instance;
        staticData = StaticData.Instance;

        

        //初始化注册startUpcontroller
        RegisterController(Consts.E_StartUp, typeof(StartUpController));

        //游戏启动
        SendEvent(Consts.E_StartUp);

        //跳转场景
        Game.Instance.LoadLevel(1);
    }

    public  void LoadLevel(int level) {

        //发送退出场景事件
        ScenesArgs e = new ScenesArgs()
        {
            //获取当前场景索引
            scnesIndex = SceneManager.GetActiveScene().buildIndex
        };

        SendEvent(Consts.E_ExitScenes,e);

        //发送加载新的场景事件
        SceneManager.LoadScene(level,LoadSceneMode.Single);

    }

    //进入新场景
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("进入新场景："+ level);
        //发送进入场景事件
        ScenesArgs e = new ScenesArgs()
        {//获取当前场景索引
            scnesIndex = level
        };
        
        SendEvent(Consts.E_EnterScenes, e);
    }

    //发送事件
    void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    //注册controler
     void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}
