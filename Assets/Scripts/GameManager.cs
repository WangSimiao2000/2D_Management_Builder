using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    public List<Villager> villagers;
    public List<Building> buildings;

    public void DailySettlement()
    {
        #region 食物消耗
        // 每个成人村民需要 2 个食物，每个未成年村民需要 1 个食物, 优先满足婴儿村民的食物需求
        // 如果食物不足, 村民死亡从村民列表中移除死亡的村民
        List<Villager> villagersToRemove = new();
        foreach (Villager villager in villagers) // 遍历村民列表
        {
            int foodNeeded = (villager.age < 3) ? 1 : 2; // 根据年龄计算食物需求
            if (resourceManager.ConsumeResource(ResourceType.Food, foodNeeded) < 0)
            {
                // 食物不足，标记村民死亡
                villagersToRemove.Add(villager);
            }
        }        
        foreach (Villager villager in villagersToRemove) // 从村民列表中移除并销毁死亡的村民
        {
            villager.VillagerDeath(); // 村民死亡
            villagers.Remove(villager); // 从村民列表中移除死亡的村民
            Destroy(villager.gameObject); // 销毁村民Object(游戏对象)
        }
        #endregion

        #region 村民年龄增长
        foreach (Villager villager in villagers)
        {
            villager.IncreaseAge();
        }
        #endregion
    }

    public void UnitTimeResourceGeneration()
    {
        foreach (Building building in buildings)
        {
            if (building.workers.Count > 0)
            {
                int totalResourceOutput = building.resourceOutput * building.workers.Count;
                resourceManager.AddResource(building.resourceType, totalResourceOutput);
            }
        }
    }

}
