using System.Collections;
using System.Collections.Generic;
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
    public int food; // ʳ��
    public int wood; // ľ��
    public int stone; // ʯ��
    public int iron; // ����
    public int gold; // ���
    public int diamond; // ��ʯ

    // ����ģʽ
    public static ResourceManager instance;

    void Start()
    {
        // ����ģʽ
        instance = this;
    }

    public bool ConsumeResource(ResourceType type, int amount)
    {
        // TODO: ������Դ
        // ��Դ���ģ�������װ����������۳���Դ
        // ÿ�ս���: ����ʳ��, ����ʳ����, ���ʳ�ﲻ��, ��������
        // ����: cost - ���ĵ���Դ���ͺ�����

        return true;
    }

    public void AddResource(ResourceType type, int amount)
    {
        // TODO: �����Դ
        // ����: type - ��Դ����, amount - ����
    }
}
