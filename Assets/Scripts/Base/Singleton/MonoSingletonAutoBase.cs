using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自动挂载式的继承MonoBehaviour的单例模式基类
/// 1. 无需手动挂载(请勿手动挂载)
/// 2. 无需动态添加
/// 3. 无需关心切换场景带来的问题
/// </summary>
/// <typeparam name="T"></typeparam>

public class MonoSingletonAutoBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                #region 动态创建 动态挂载
                // 在场景上创建一个空的GameObject
                GameObject obj = new GameObject();
                // 设置该GameObject的名字(类名)
                obj.name = typeof(T).ToString();
                // 动态挂载对应的单例模式脚本
                instance = obj.AddComponent<T>();
                // 过场景切换时不销毁, 保证在整个游戏生命周期中都存在
                DontDestroyOnLoad(obj);
                #endregion
            }
            return instance;
        }
    }
}
