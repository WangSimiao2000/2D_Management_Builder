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
    public int food; // 食物
    public int wood; // 木材
    public int stone; // 石材
    public int iron; // 铁矿
    public int gold; // 金币
    public int diamond; // 钻石

    // 单例模式
    public static ResourceManager instance;

    void Start()
    {
        // 单例模式
        instance = this;
    }

    public bool ConsumeResource(ResourceType type, int amount)
    {
        // TODO: 消耗资源
        // 资源消耗：建筑、装备、升级会扣除资源
        // 每日结算: 消耗食物, 减少食物库存, 如果食物不足, 村民死亡
        // 参数: cost - 消耗的资源类型和数量

        return true;
    }

    public void AddResource(ResourceType type, int amount)
    {
        // TODO: 添加资源
        // 参数: type - 资源类型, amount - 数量
    }
}
