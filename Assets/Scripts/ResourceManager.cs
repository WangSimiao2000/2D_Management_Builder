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

[System.Serializable] // ���л� ResourceItem
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

    public int ConsumeResource(ResourceType type, int amount) // ������Դ
    {
        ResourceItem resource = resources.Find(r => r.type == type); // ������Դ
        resource.amount -= amount; // ������Դ
        return resource.amount; // �����Դ�㹻, �򷵻طǸ���, ���򷵻ظ���
    }

    public void AddResource(ResourceType type, int amount) // �����Դ
    {
        // ����: type - ��Դ����, amount - ����
        ResourceItem resource = resources.Find(r => r.type == type);
        if (resource == null)
        {
            resources.Add(new ResourceItem { type = type, amount = amount }); // �����Դ�����ڣ������Դ
        }
        else
        {
            resource.amount += amount;
        }
    }

    public int GetResourceAmount(ResourceType type) // ��ȡ��ǰ��Դ����
    {
        ResourceItem resource = resources.Find(r => r.type == type); // ������Դ
        return resource != null ? resource.amount : 0;
    }
}
