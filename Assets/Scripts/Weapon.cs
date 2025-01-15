using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public Profession type;
    public int damage;
    public int ToolEffect; // 对该职业工作的加速效果

    // TODO: 其它功能

    public bool IsValidForProfession(Profession profession)
    {
        return type == profession;
    }
}
