using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public string armorName;
    public Profession type; // ����(��װ)���õ�ְҵ
    public int armorValue;
    public int armorEffect; // �Ը�ְҵ�����ļ���Ч��

    // TODO: ��������

    public int GetProfessionBoost(Profession profession)
    {
        if(profession == type) // ��������õ�ְҵ
        {
            return armorEffect; // ���ؼ���Ч��
        }
        return 0; // ����������õ�ְҵ������0
    }
}
