using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 公共Mono模块管理器
/// (此脚本用于管理所有涉及帧更新或协程的功能)
/// 1. 集中在一个脚本内管理的目的是为了提升性能
/// 2. 声明对应事件或委托用于存储外部函数, 提供添加和移除的接口, 从而使得不继承MonoBehaviour的类也能使用Update和协程
/// </summary>

public class MonoMgr : MonoSingletonAutoBase<MonoMgr>
{
    private event UnityAction updateEvent; // 声明一个帧更新的事件
    private event UnityAction fixedUpdateEvent; // 声明一个固定帧更新的事件
    private event UnityAction lateUpdateEvent; // 声明一个晚帧更新的事件

    /// <summary>
    /// 添加Update帧更新监听函数
    /// </summary>
    /// <param name="updateFun"></param>
    public void AddUpdateListener(UnityAction updateFun) // 添加帧更新事件
    {
        updateEvent += updateFun;
    }

    /// <summary>
    /// 添加FixedUpdate帧更新监听函数
    /// </summary>
    /// <param name="fixedUpdateFun"></param>
    public void AddFixedUpdateListener(UnityAction fixedUpdateFun) // 添加固定帧更新事件
    {
        fixedUpdateEvent += fixedUpdateFun;
    }

    /// <summary>
    /// 添加LateUpdate帧更新监听函数
    /// </summary>
    /// <param name="lateUpdateFun"></param>
    public void AddLateUpdateListener(UnityAction lateUpdateFun) // 添加晚帧更新事件
    {
        lateUpdateEvent += lateUpdateFun;
    }

    /// <summary>
    /// 移除Update帧更新监听函数
    /// </summary>
    /// <param name="updateFun"></param>
    public void RemoveUpdateListener(UnityAction updateFun) // 移除帧更新事件
    {
        updateEvent -= updateFun;
    }

    /// <summary>
    /// 移除FixedUpdate帧更新监听函数
    /// </summary>
    /// <param name="fixedUpdateFun"></param>
    public void RemoveFixedUpdateListener(UnityAction fixedUpdateFun) // 移除固定帧更新事件
    {
        fixedUpdateEvent -= fixedUpdateFun;
    }

    /// <summary>
    /// 移除LateUpdate帧更新监听函数
    /// </summary>
    /// <param name="lateUpdateFun"></param>
    public void RemoveLateUpdateListener(UnityAction lateUpdateFun) // 移除晚帧更新事件
    {
        lateUpdateEvent -= lateUpdateFun;
    }

    private void Update() // 每帧调用
    {
        updateEvent?.Invoke(); // 触发帧更新事件
    }

    private void FixedUpdate() // 固定时间间隔调用
    {
        fixedUpdateEvent?.Invoke(); // 触发固定帧更新事件
    }

    private void LateUpdate() // 每帧调用, 在Update之后调用
    {
        lateUpdateEvent?.Invoke(); // 触发晚帧更新事件
    }
}
