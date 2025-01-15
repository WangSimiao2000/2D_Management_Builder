using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Profession workerType; // ��������
    public ResourceType resourceType; // ��Դ����
    public int level = 1; // �����ȼ�
    public int resourceOutput = 0; // ��λʱ��Ĳ�����
    public int capacity = 1; // �洢����(��������)
    public List<Villager> workers; // ��ǰ�����Ĵ����б�

    public  void Upgrade()
    {
        // TODO: ��������
        // �ȼ�+1, ���ݵȼ����½�������ͼƬ
        // ��߲�����(�����ཨ����߲������洢�ཨ�����������)
        resourceOutput++;
        capacity++;
    }

    public void AssignWorker(Villager villager)
    {
        // TODO: ���������
        // ����������ʺϵ�ְҵ������Է������ڴ˽�������, ��λʱ�����������
        if (villager.profession == workerType)
        {
            workers.Add(villager);
            resourceOutput += villager.currWeapon.ToolEffect + villager.currArmor.armorEffect;
        }
    }

    public void RemoveWorker(Villager villager)
    {
        // TODO: �Ƴ�����
        // ����ӹ����б����Ƴ�, ʹ��ֹͣ����, ��λʱ�����������
        resourceOutput -= villager.currWeapon.ToolEffect + villager.currArmor.armorEffect;
        workers.Remove(villager);
    }
}
