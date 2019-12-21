using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MVC
{
    //资源
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>(); //名字 -- model
    public static Dictionary<string, View> Views = new Dictionary<string, View>(); // 名字 -- view
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>(); //事件名字 -- 类型

    //注册view
    public static void RegisterView(View view) {
        //防止view重复注册
        if (Views.ContainsKey(view.Name))
        {
            Views.Remove(view.Name);
            
        }

        view.RegisterAttentionEvent();
        Views[view.Name] = view;
    }

    //注册model
    public static void RegisterModel(Model model)
    {
        
        Models[model.Name] = model;
    }

    //注册controller
    public static void RegisterController(string eventName,Type controllerType)
    {

        CommandMap[eventName] = controllerType;

    }

    //获取model
    public static T GetModel<T>()
        where T:Model
    {
        foreach (var m in Models.Values) {
            if (m is T) {
                return (T)m;
            }
        }
        return null;
    }

    //获取view
    public static T GetView<T>()
        where T : View
    {
        foreach (var v in Views.Values)
        {
            if (v is T)
            {
                return (T)v;
            }
        }
        return null;
    }


    //发送事件
    public static void SendEvent(string eventName,object data = null) {

        //controller执行
        if (CommandMap.ContainsKey(eventName)) {
            Type t = CommandMap[eventName];
            //控制器生成
            Controller c = Activator.CreateInstance(t) as Controller;
            c.Execute(data );
        }

        //view处理
        foreach (var v in Views.Values) {
            if (v.AttentionList.Contains(eventName)) {
                //执行
                v.HandleEvent(eventName,data);
            }
        }


    }
}