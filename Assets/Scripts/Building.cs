using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Profession type; // ũ�����󳡵�
    public int level;
    public int resourceOutput; // ��λʱ��Ĳ�����
    public int capacity; // �洢����(��������)
    public List<Villager> workers; // ��ǰ�����Ĵ����б�

    public  void Upgrade()
    {
        // TODO: ��������
        // �ȼ�+1, ���ݵȼ����½�������ͼƬ
        // ��߲�����(�����ཨ����߲������洢�ཨ�����������)
    }

    public void AssignWorker(Villager villager)
    {
        // TODO: ���������
        // ����������ʺϵ�ְҵ������Է������ڴ˽�������, ��λʱ�����������
    }

    public void RemoveWorker(Villager villager)
    {
        // TODO: �Ƴ�����
        // ����ӹ����б����Ƴ�, ʹ��ֹͣ����, ��λʱ�����������
    }
}
