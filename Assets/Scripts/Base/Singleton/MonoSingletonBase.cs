using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 继承MonoBehaviour的单例基类(手动挂载在场景中的GameObject上)

#region 注意: 挂载式的单例基类
// 1. 不能使用new()来实例化, 因为MonoBehaviour的实例化是通过Unity引擎来实现的
// 2. 一定得挂载在GameObject上, 通过GameObject来实例化
#endregion

#region 潜在问题: 挂载式的单例基类
// 挂载式的单例基类: 会破坏单例模式的唯一性
// 1. 在一个GameObject上挂载多个继承自SingletonMono的类, 会导致后面的类覆盖前面的类
// 2. 切换场景时, 由于场景放置了挂载了SingletonMono的GameObject, 再切换回来时, 会导致单例类的重新实例化
// 3. 用脚本动态添加多个该脚本, 也会破坏单例的唯一性
#endregion

#region 解决方案
// 1. 同一个GameObject上挂载多个: 为脚本添加特性[DisallowMultipleComponent]
// 2. 多个GameObject上挂载: 判断如果存在对象, 则移除脚本
#endregion

// 不允许在同一个GameObject上挂载多个该脚本
[DisallowMultipleComponent]
public class MonoSingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        // 如果已经存在单例模式对象实例, 则销毁当前实例
        if (instance != null)
        {
            Destroy(this); // 不用Destroy(this.gameObject), 因为只需要移除脚本即可
            return;
        }
        instance = this as T;
        // 挂载继承此单例基类脚本时, 依附的对象在切换场景时不会被销毁
        // 可以保证在游戏整个生命周期中, 单例类的唯一性
        DontDestroyOnLoad(this.gameObject);
    }
}
