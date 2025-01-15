using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Profession type; // 农场、矿场等
    public int level;
    public int resourceOutput; // 单位时间的产出量
    public int capacity; // 存储容量(村民数量)
    public List<Villager> workers; // 当前工作的村民列表

    public  void Upgrade()
    {
        // TODO: 升级建筑
        // 等级+1, 根据等级更新建筑精灵图片
        // 提高产出量(生产类建筑提高产出、存储类建筑提高容量等)
    }

    public void AssignWorker(Villager villager)
    {
        // TODO: 分配村民工作
        // 如果村民是适合的职业，则可以分配其在此建筑工作, 单位时间产出量增加
    }

    public void RemoveWorker(Villager villager)
    {
        // TODO: 移除村民
        // 将其从工作列表中移除, 使其停止工作, 单位时间产出量减少
    }
}
