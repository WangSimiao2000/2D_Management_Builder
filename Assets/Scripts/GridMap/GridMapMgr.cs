using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridMapMgr : MonoSingletonAutoBase<GridMapMgr>
{
    public int mapX; // 地图的宽度
    public int mapY; // 地图的高度
    private Dictionary<Vector2Int, GridCell> gridDictionary; // 保存地图网格信息的字典, 用来访问和保存GridCell信息
    public GameObject gridPrefab; // 一个暂时基础显示效果的Grid实例预制体


    // 创建GridCell字典
    public void CreateGridDictionary()
    {
        gridDictionary = new Dictionary<Vector2Int, GridCell>();
        for (int x = 0; x < mapX; x++)
        {
            for (int y = 0; y < mapY; y++)
            {
                GridCell gridCell = new GridCell();
                gridCell.pox_x = x;
                gridCell.pox_y = y;
                gridCell.gridType = GridType.Ground;
                gridDictionary.Add(new Vector2Int(x, y), gridCell);

                // 创建实例
                Instantiate<GameObject>(gridPrefab, new Vector3Int(x, y, 0), Quaternion.identity, transform);
            }
        }
    }

    /// <summary>
    /// 通过给定世界位置获取对应的网格单元的信息
    /// </summary>
    /// <param name="worldPos">世界坐标</param>
    /// <returns></returns>
    public GridCell GetGridCell(Vector2 worldPos)
    {
        // 将世界坐标转换为网格坐标(舍弃小数部分)
        Vector2Int pos = new Vector2Int(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        // 判断位置是否合法, 如果超出地图范围, 则返回null
        if(pos.x < 0 || pos.x >= mapX || pos.y < 0 || pos.y >= mapY)
        {
            return new GridCell(); // 返回一个空的GridCell
        }
        else
        {
            return gridDictionary[pos];
        }
    }

    /// <summary>
    /// 自动获取鼠标所在位置的网格单元的信息(多态)
    /// </summary>
    /// <returns></returns>
    public GridCell GetGridCell()
    {
        // 获取鼠标所在的世界坐标
        Vector2Int mouseWorldPos = CameraMgr.Instance.GetMouseWorldPosition();
        // 将世界坐标转换为网格坐标(舍弃小数部分)
        Vector2Int pos = new Vector2Int(Mathf.RoundToInt(mouseWorldPos.x), Mathf.RoundToInt(mouseWorldPos.y));
        // 判断位置是否合法, 如果超出地图范围, 则返回null
        if (pos.x < 0 || pos.x >= mapX || pos.y < 0 || pos.y >= mapY)
        {
            return new GridCell(); // 返回一个空的GridCell
        }
        else
        {
            return gridDictionary[pos];
        }
    }
}

