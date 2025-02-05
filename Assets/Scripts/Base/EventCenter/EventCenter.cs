using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件信息的基类
/// 用于里氏替换原则 装载子类的父类
/// </summary>
public abstract class EventInfoBase { }

/// <summary>
/// 用来包裹 对应观察者 函数委托的类
/// </summary>
/// <typeparam name="T">泛型</typeparam>
public class EventInfo<T>: EventInfoBase
{
    // 真正观察者 对应的 函数信息 记录在其中
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

/// <summary>
/// 主要用来记录 无参 无返回值 的委托
/// </summary>
public class EventInfo : EventInfoBase
{
    // 真正观察者 对应的 函数信息 记录在其中
    public UnityAction actions;
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

/// <summary>
/// 事件中心，负责事件的注册、监听、广播
/// </summary>
public class EventCenter : SingletonBase<EventCenter>
{
    /// <summary>
    /// 用于记录 对应事件 关联的 对应的逻辑
    /// object: 传递的参数(可以用结构体来实现多参数传递)
    /// object的装箱拆箱会带来性能损耗(可以用泛型来解决)
    /// </summary>
    private Dictionary<E_EventType, EventInfoBase> eventDic = new Dictionary<E_EventType, EventInfoBase>();

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private EventCenter() { }

    /// <summary>
    /// 触发事件: 若事件存在则触发 否则不触发
    /// </summary>
    /// <param name="T">泛型</param>
    /// <param name="eventName">事件的名字(string类型)</param>
    /// <param name="info">传递的参数</param>
    public void EventTrigger<T>(E_EventType eventName, T info)
    {
        // 存在关心的事件, 才通知别人去处理逻辑
        if (eventDic.ContainsKey(eventName))
        {
            // 去执行对应的逻辑
            (eventDic[eventName] as EventInfo<T>).actions?.Invoke(info); // 若不为空则触发
        }
    }

    /// <summary>
    /// 触发事件(无参): 若事件存在则触发 否则不触发
    /// </summary>
    /// <param name="eventName">事件的名字</param>
    public void EventTrigger(E_EventType eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions?.Invoke();
        }
    }

    /// <summary>
    /// 添加事件: 若事件已经存在则添加新的逻辑 否则添加新的事件和逻辑
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    /// <param name="eventName">事件的名字</param>
    /// <param name="action">传入的委托函数</param>
    public void AddEventListener<T>(E_EventType eventName, UnityAction<T> action)
    {
        // 若事件已经存在关心事件的委托记录, 直接添加新的逻辑
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions += action; // 添加新的逻辑
        }
        else
        {
            eventDic.Add(eventName, new EventInfo<T>(action)); // 先添加事件
        }
    }

    /// <summary>
    /// 添加事件(无参): 若事件已经存在则添加新的逻辑 否则添加新的事件和逻辑
    /// </summary>
    /// <param name="eventName">事件的名字</param>
    /// <param name="action">传入的委托函数</param>
    public void AddEventListener(E_EventType eventName, UnityAction action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo(action));
        }
    }

    /// <summary>
    /// 移除事件: 若事件存在则移除对应的逻辑 否则不移除
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    /// <param name="eventName">事件的名字</param>
    /// <param name="action">传入的委托函数</param>
    public void RemoveEventListener<T>(E_EventType eventName, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions -= action;
        }
    }

    /// <summary>
    /// 移除事件(无参): 若事件存在则移除对应的逻辑 否则不移除
    /// </summary>
    /// <param name="eventName">事件的名字</param>
    /// <param name="action">传入的委托函数</param>
    public void RemoveEventListener(E_EventType eventName, UnityAction action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions -= action;
        }
    }

    /// <summary>
    /// 清空事件中心所有事件的监听
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }

    /// <summary>
    /// 清空指定事件的监听
    /// </summary>
    /// <param name="eventName">指定事件的名字</param>
    public void Clear(E_EventType eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic.Remove(eventName);
        }
    }
}
