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
        int totalFoodRequirement = villagers.Sum(v => v.dailyFoodRequirement);
        if (resourceManager.ConsumeResource(ResourceType.Food, totalFoodRequirement) > 0)
        {
            // TODO: 村民死亡逻辑
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
