using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 职业
public enum Profession
{
    None,
    Farmer,
    Miner,
    Lumberjack,
    Blacksmith,
    Archer,
    Warrior
}

public class Villager : MonoBehaviour
{
    public string villagerName;
    public int age;
    public static int maxStamina;
    public int currStamina;
    public int dailyFoodRequirement;
    public int armorValue;
    public bool isAdult;
    public Profession profession;
    public Weapon currWeapon;
    public Armor currArmor;    

    // 设置职业
    void SetProfessionFromWeapon()
    {
        if(currWeapon != null) // 如果有武器(工具)
        {
            profession = currWeapon.type; // 设置职业为武器的职业类型
        }
        else
        {
            profession = Profession.None; // 没有武器, 职业为None
        }
    }

    // 设置武器(工具)
    public bool SetWeapon(Weapon newWeapon)
    {
        if (isAdult)
        {
            currWeapon = newWeapon; // 设置武器槽的装备
            SetProfessionFromWeapon(); // 根据武器设置职业

            // TODO: 更新武器图片

            return true;
        }
        return false; // 如果未成年，无法装备武器
    }

    // 设置护甲(服装)
    public bool SetArmor(Armor newArmor)
    {
        if (isAdult)
        {
            currArmor = newArmor; // 设置护甲槽的装备
            armorValue = newArmor.armorValue; // 设置护甲值

            // TODO: 更新护甲图片

            return true;
        }
        return false; // 如果未成年，无法装备护甲
    }

    // 成年(当年龄(天数)达到3岁时调用)
    public void BecomeAdult()
    {
        isAdult = true;
        dailyFoodRequirement = 2;
        maxStamina = 10;
        currStamina = maxStamina;

        // TODO: 切换成年村民的精灵图片
        // Sprite sprite = Resources.Load<Sprite>("Sprites/Villagers/Villager_Adult");
        // GetComponent<SpriteRenderer>().sprite = sprite;
    }

    // 年龄增加(根据天数调用)
    public void IncreaseAge()
    {
        age++;
        if (age == 3) // 三岁那天成年
        {
            BecomeAdult();
        }
    }
}
