using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoSingletonBase<CameraMgr>
{
    private Camera mainCamera;
    //private Vector2 mouseWorldPos;

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main; // 获取主摄像机
    }

    /// <summary>
    /// 获取鼠标所在的世界坐标
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMouseWorldPosition()
    {
        // 将屏幕坐标转换为世界坐标
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
