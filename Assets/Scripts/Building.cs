using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Profession workerType; // 工人类型
    public ResourceType resourceType; // 资源类型
    public int level = 1; // 建筑等级
    public int resourceOutput = 0; // 单位时间的产出量
    public int capacity = 1; // 存储容量(村民数量)
    public List<Villager> workers; // 当前工作的村民列表

    public  void Upgrade()
    {
        // TODO: 升级建筑
        // 等级+1, 根据等级更新建筑精灵图片
        // 提高产出量(生产类建筑提高产出、存储类建筑提高容量等)
        resourceOutput++;
        capacity++;
    }

    public void AssignWorker(Villager villager)
    {
        // TODO: 分配村民工作
        // 如果村民是适合的职业，则可以分配其在此建筑工作, 单位时间产出量增加
        if (villager.profession == workerType)
        {
            workers.Add(villager);
            resourceOutput += villager.currWeapon.ToolEffect + villager.currArmor.armorEffect;
        }
    }

    public void RemoveWorker(Villager villager)
    {
        // TODO: 移除村民
        // 将其从工作列表中移除, 使其停止工作, 单位时间产出量减少
        resourceOutput -= villager.currWeapon.ToolEffect + villager.currArmor.armorEffect;
        workers.Remove(villager);
    }
}
