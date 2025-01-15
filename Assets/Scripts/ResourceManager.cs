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

    // ����ģʽ
    public static ResourceManager instance;

    void Start()
    {
        // ����ģʽ
        instance = this;
    }

    public int ConsumeResource(ResourceType type, int amount) // ������Դ
    {
        if (!resources.ContainsKey(type))
        {
            // �����Դ���Ͳ����ڣ�����-1
            return -1;
        }

        if (resources[type] >= amount)
        {
            resources[type] -= amount; // ������Դ
            return 0; // �ɹ����ģ����� 0 ��ʾû��Ƿȱ
        }
        else
        {
            int less = amount - resources[type]; // ����Ƿȱ������
            resources[type] = 0; // ����Դ���
            return less; // ����Ƿȱ������
        }
    }

    public void AddResource(ResourceType type, int amount) // �����Դ
    {
        // ����: type - ��Դ����, amount - ����

        if (!resources.ContainsKey(type))
        {
            resources[type] = 0;
        }
        resources[type] += amount;
    }

    public int GetResourceAmount(ResourceType type) // ��ȡ��ǰ��Դ����
    {
        return resources.ContainsKey(type) ? resources[type] : 0;
    }
}
