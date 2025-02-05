using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 网格单元
/// [可序列化: 后期要保存地图数据]
/// </summary>

[SerializeField] // 序列化
public class GridCell
{
    // 以下用于A*寻路算法
    public float g; // 起点到当前点的代价
    public float h; // 当前点到终点的代价
    public float f; // f = g + h
    public GridCell f_GridCell; // 父节点

    // 坐标位置
    public int pox_x; // x坐标
    public int pox_y; // y坐标

    // 网格类型
    public GridType gridType;

    /// <summary>
    /// 无参构造函数, 用于初始化
    /// </summary>
    public GridCell() 
    {
        g = 0;
        h = 0;
        f = 0;
        f_GridCell = null;
        pox_x = 0;
        pox_y = 0;
        gridType = GridType.None;
    }

    /// <summary>
    /// 设置网格类型
    /// </summary>
    /// <param name="type"></param>
    public void SetGridCellType(GridType type)
    {
        gridType = type;
    }

    /// <summary>
    /// 设置网格坐标
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetGridCellPos(int x, int y)
    {
        pox_x = x;
        pox_y = y;
    }
}
