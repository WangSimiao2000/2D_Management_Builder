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

[System.Serializable] // 序列化 ResourceItem
public class ResourceItem
{
    public ResourceType type;
    public int amount;
}

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private List<ResourceItem> resources = new()
    {
        new() { type = ResourceType.Food, amount = 0 },
        new() { type = ResourceType.Wood, amount = 0 },
        new() { type = ResourceType.Stone, amount = 0 },
        new() { type = ResourceType.Iron, amount = 0 },
        new() { type = ResourceType.Gold, amount = 0 },
        new() { type = ResourceType.Diamond, amount = 0 }
    };

    public int ConsumeResource(ResourceType type, int amount) // 消耗资源
    {
        ResourceItem resource = resources.Find(r => r.type == type); // 查找资源
        if (resource == null)
        {
            return -1; // 如果资源类型不存在
        }

        if (resource.amount >= amount)
        {
            resource.amount -= amount;
            return 0; // 成功消耗，返回 0
        }
        else
        {
            int less = amount - resource.amount;
            resource.amount = 0; // 将资源清空
            return less; // 返回欠缺的数量
        }
    }

    public void AddResource(ResourceType type, int amount) // 添加资源
    {
        // 参数: type - 资源类型, amount - 数量
        ResourceItem resource = resources.Find(r => r.type == type);
        if (resource == null)
        {
            resources.Add(new ResourceItem { type = type, amount = amount }); // 如果资源不存在，添加资源
        }
        else
        {
            resource.amount += amount;
        }
    }

    public int GetResourceAmount(ResourceType type) // 获取当前资源数量
    {
        ResourceItem resource = resources.Find(r => r.type == type); // 查找资源
        return resource != null ? resource.amount : 0;
    }
}
