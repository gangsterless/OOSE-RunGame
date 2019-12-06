using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts
{
    //事件名字
    public const string E_ExitScenes = "E_ExitScenes";//ScenesArgs
    public const string E_EnterScenes = "E_EnterScenes";//ScenesArgs
    public const string E_StartUp = "E_StartUp";
    public const string E_EndGame = "E_EndGame";

    public const string E_PauseGame = "E_PauseGame";
    public const string E_ResumeGame = "E_ResumeGame";

    /// <summary>
    /// ****UI相关
    /// </summary>
    public const string E_UpdataDis = "E_UpdataDis";//DistanceArgs
    public const string E_UpdateCoin = "E_UpdateCoin";//CoinArgs
    public const string E_HitAddTime = "E_HitAddTime";
    public const string E_HitItem = "E_HitItem"; //ItemArgs

    //ui可以射门了
    public const string E_HitGoalTrigger = "E_HitGoalTrigger";
    public const string E_ClickGoalButton = "E_ClickGoalButton";
    //进球事件，让goal + 1
    public const string E_ShootGoal = "E_ShootGoal";
    //结算事件
    public const string E_FinalShowUI = "E_FinalShowUI";
    //贿赂
    public const string E_BriberyClick = "E_BriberyClick";//CoinArgs
    //resumen播放完成，继续游戏
    public const string E_ContinueGame = "E_ContinueGame";
    //买道具
    public const string E_BuyTools = "E_BuyTools";
    //买足球
    public const string E_BuyFootBall = "E_BuyFootBall";
    //装备足球
    public const string E_EquipFootBall = "E_EquipFootBall";
    //买衣服
    public const string E_BuyCloth = "E_BuyCloth";
    //装备衣服
    public const string E_EquipCloth = "E_EquipCloth";




    //model名字
    public const string M_GameModel = "M_GameModel";

    //view名字
    public const string V_PlayerMove = "V_PlayerMove";
    public const string V_PlayerAnim = "V_PlayerAnim";
    public const string V_Board = "V_Board";
    public const string V_Pause = "V_Pause";
    public const string V_Resume = "V_Resume";
    public const string V_Dead = "V_Dead";
    public const string V_FinalScore = "V_FinalScore";
    public const string V_BuyTools = "V_BuyTools";
    public const string V_MainMenu = "V_MainMenu";
    public const string V_Shop = "V_Shop";
    //
}

public enum InputDirection {
    NULL,
    Right,
    Left,
    Down,
    Up
}
//吃到奖励物品类型
public enum ItemKind
{
    ItemMagnet,
    ItemMultiply,
    ItemInvincible

}

public enum  ItemState
{
    UnBuy,
    Buy,
    Equip
}
  
