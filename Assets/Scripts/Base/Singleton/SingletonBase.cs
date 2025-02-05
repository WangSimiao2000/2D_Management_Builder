using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用泛型来实现所有Manager的基类

#region 作用
// 1. 主要避免代码冗余
// 2. 泛型为可变的, 所以可以用来实现所有Manager的基类
#endregion

#region 注意
// 限制泛型T必须是类，且必须有一个无参构造函数, 以便在Instance属性中实例化
# endregion

#region 潜在问题
// 1. 可能会有出现在别的地方 new() 一个单例类的情况, 但是这样会破坏单例的原则
// 2. 多个线程同时访问同一个单例类的情况时, 可能会出现共享资源的安全问题
#endregion

#region 解决方案
// 1. 将父类变为抽象类, 抽象类是不能被new的
// 2. 规定, 继承单例模式基类的类, 必须显式地实现私有的无参构造函数
// 3. 在基类中通过反射来调用私有的无参构造函数, 以此实例化对象 (使用Type类的GetConstructor()方法)
// ConstructorInfo constructor = typeof(T).GetConstructor(
// BindingFlags.Instance | BindingFlags.NonPublic,  // 表示成员私有方法(Instance)和非公共方法(NonPublic): 因为无参构造函数是私有的
// null,                                            // 表示不需要绑定对象
// Type.EmptyTypes,                                 // 表示没有参数
// null);                                           // 表示没有参数修饰符(如out, ref)
#endregion

public abstract class SingletonBase<T> where T: class // , new()
{
    private static T instance;

    // 用于加锁的对象
    protected static readonly object lockObj = new object();

    // 通过属性获取实例 任选其一
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        // instance = new T();

                        // 利用反射得到私有的无参构造函数, 以此实例化对象
                        Type type = typeof(T);
                        ConstructorInfo info = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                                                                    null,
                                                                    Type.EmptyTypes,
                                                                    null);
                        if (info != null)
                        {
                            instance = info.Invoke(null) as T;
                        }
                        else
                        {
                            Debug.LogError("The constructor is not found!");
                        }
                    }
                }
            }
            return instance;
        }
    }

    // 通过方法获取实例 任选其一
    //public static T GetInstance()
    //{
    //    if (instance == null)
    //    {
    //        instance = new T();
    //    }
    //    return instance;
    //}
}