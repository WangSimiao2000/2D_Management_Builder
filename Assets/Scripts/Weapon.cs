using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public Profession type;
    public int damage;

    // TODO: ��������

    public bool IsValidForProfession(Profession profession)
    {
        return type == profession;
    }
}
