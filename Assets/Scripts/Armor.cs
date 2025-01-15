using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public string armorName;
    public Profession type; // 护甲(服装)适用的职业
    public int armorValue;
    public int armorEffect; // 对该职业工作的加速效果

    // TODO: 其它功能

    public int GetProfessionBoost(Profession profession)
    {
        if(profession == type) // 如果是适用的职业
        {
            return armorEffect; // 返回加速效果
        }
        return 0; // 如果不是适用的职业，返回0
    }
}
