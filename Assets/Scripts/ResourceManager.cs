using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

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
    // 资源UI
    public GameObject resourceItemUI;
}

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private List<ResourceItem> resources = new()
    {
        new() { type = ResourceType.Food, amount = 0, resourceItemUI = null },
        new() { type = ResourceType.Wood, amount = 0, resourceItemUI = null },
        new() { type = ResourceType.Stone, amount = 0, resourceItemUI = null },
        new() { type = ResourceType.Iron, amount = 0, resourceItemUI = null },
        new() { type = ResourceType.Gold, amount = 0, resourceItemUI = null},
        new() { type = ResourceType.Diamond, amount = 0, resourceItemUI = null}
    };
    
    public int ConsumeResource(ResourceType type, int amount) // 消耗资源
    {
        ResourceItem resource = resources.Find(r => r.type == type); // 查找资源
        resource.amount -= amount; // 减少资源
        resource.resourceItemUI.GetComponentInChildren<TextMeshPro>().text = resource.amount.ToString(); // 更新UI的文字信息(数量)
        return resource.amount; // 如果资源足够, 则返回非负数, 否则返回负数
    }

    public void AddResource(ResourceType type, int amount) // 添加资源
    {
        // 参数: type - 资源类型, amount - 数量
        ResourceItem resource = resources.Find(r => r.type == type);
        resource.amount += amount;
        resource.resourceItemUI.GetComponentInChildren<TextMeshPro>().text = resource.amount.ToString(); // 更新UI的文字信息(数量)
    }

    public int GetResourceAmount(ResourceType type) // 获取当前资源数量
    {
        ResourceItem resource = resources.Find(r => r.type == type); // 查找资源
        return resource != null ? resource.amount : 0;
    }
}
