using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public Profession type;
    public int damage;
    public int ToolEffect; // �Ը�ְҵ�����ļ���Ч��

    // TODO: ��������

    public bool IsValidForProfession(Profession profession)
    {
        return type == profession;
    }
}
