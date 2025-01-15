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
        #region ʳ������
        // ÿ�����˴�����Ҫ 2 ��ʳ�ÿ��δ���������Ҫ 1 ��ʳ��, ��������Ӥ�������ʳ������
        // ���ʳ�ﲻ��, ���������Ӵ����б����Ƴ������Ĵ���
        List<Villager> villagersToRemove = new();
        foreach (Villager villager in villagers) // ���������б�
        {
            int foodNeeded = (villager.age < 3) ? 1 : 2; // �����������ʳ������
            if (resourceManager.ConsumeResource(ResourceType.Food, foodNeeded) < 0)
            {
                // ʳ�ﲻ�㣬��Ǵ�������
                villagersToRemove.Add(villager);
            }
        }        
        foreach (Villager villager in villagersToRemove) // �Ӵ����б����Ƴ������������Ĵ���
        {
            villager.VillagerDeath(); // ��������
            villagers.Remove(villager); // �Ӵ����б����Ƴ������Ĵ���
            Destroy(villager.gameObject); // ���ٴ���Object(��Ϸ����)
        }
        #endregion

        #region ������������
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
