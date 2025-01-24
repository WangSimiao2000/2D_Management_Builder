using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件管理器
/// 用于事件的定义、触发
/// 当需要创建一个新的事件时，
/// 1. 需要在EventManager中定义一个新的事件, 并在需要触发的地方调用TriggerEvent方法即可
/// 2. 1) 在被触发的地方声明一个方法, 该方法的参数和返回值要和事件的委托一致
/// 2. 2) 在被触发的地方的OnEnable中使用EventManager.事件名 += 方法名 来订阅事件, 
/// 2. 3) 在被触发的地方的OnDisable中使用EventManager.事件名 -= 方法名 来取消订阅事件
/// 3. 在需要触发的地方使用EventManager.TriggerEvent方法触发事件
/// 注意: 事件的参数需要在这两个地方声明: 
/// 1. 事件的定义处的Action后面加上<参数值类型>, 可以用多个参数, 用逗号隔开
/// 2. 触发事件的地方的TriggerEvent方法的参数处加上参数
/// 3. 触发事件的地方的TriggerEvent方法中的Invoke后面加上参数
/// </summary>

public class EventManager : BaseManager<EventManager>
{
    #region 事件名(定义事件)
    public static event Action EventA;
    #endregion

    #region 事件触发
    public static void TriggerEventA()
    {
        EventA?.Invoke();
    }
    #endregion
}
