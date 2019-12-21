using System.Collections;
using System.Collections.Generic;

public interface IReusable  {

    //取出时候调用
    void OnSpawn();

    //回收调用
    void OnUnSpawn();

}
