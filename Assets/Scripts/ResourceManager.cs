using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public enum ResourceType 
{
    Food,
    Wood,
    Stone,
    Iron,
    Gold,
    Diamond
}

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>()
    {
        { ResourceType.Food, 0 },
        { ResourceType.Wood, 0 },
        { ResourceType.Stone, 0 },
        { ResourceType.Iron, 0 },
        { ResourceType.Gold, 0 },
        { ResourceType.Diamond, 0 },
    };

    // 单例模式
    public static ResourceManager instance;

    void Start()
    {
        // 单例模式
        instance = this;
    }

    public int ConsumeResource(ResourceType type, int amount) // 消耗资源
    {
        if (!resources.ContainsKey(type))
        {
            // 如果资源类型不存在，返回-1
            return -1;
        }

        if (resources[type] >= amount)
        {
            resources[type] -= amount; // 消耗资源
            return 0; // 成功消耗，返回 0 表示没有欠缺
        }
        else
        {
            int less = amount - resources[type]; // 计算欠缺的数量
            resources[type] = 0; // 将资源清空
            return less; // 返回欠缺的数量
        }
    }

    public void AddResource(ResourceType type, int amount) // 添加资源
    {
        // 参数: type - 资源类型, amount - 数量

        if (!resources.ContainsKey(type))
        {
            resources[type] = 0;
        }
        resources[type] += amount;
    }

    public int GetResourceAmount(ResourceType type) // 获取当前资源数量
    {
        return resources.ContainsKey(type) ? resources[type] : 0;
    }
}
