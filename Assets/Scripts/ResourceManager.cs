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

[System.Serializable] // ���л� ResourceItem
public class ResourceItem
{
    public ResourceType type;
    public int amount;
    // ��ԴUI
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
    
    public int ConsumeResource(ResourceType type, int amount) // ������Դ
    {
        ResourceItem resource = resources.Find(r => r.type == type); // ������Դ
        resource.amount -= amount; // ������Դ
        resource.resourceItemUI.GetComponentInChildren<TextMeshPro>().text = resource.amount.ToString(); // ����UI��������Ϣ(����)
        return resource.amount; // �����Դ�㹻, �򷵻طǸ���, ���򷵻ظ���
    }

    public void AddResource(ResourceType type, int amount) // �����Դ
    {
        // ����: type - ��Դ����, amount - ����
        ResourceItem resource = resources.Find(r => r.type == type);
        resource.amount += amount;
        resource.resourceItemUI.GetComponentInChildren<TextMeshPro>().text = resource.amount.ToString(); // ����UI��������Ϣ(����)
    }

    public int GetResourceAmount(ResourceType type) // ��ȡ��ǰ��Դ����
    {
        ResourceItem resource = resources.Find(r => r.type == type); // ������Դ
        return resource != null ? resource.amount : 0;
    }
}
