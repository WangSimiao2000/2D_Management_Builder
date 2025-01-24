using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : BaseManager<EnviromentManager>
{
    // 环境物体列表
    private List<GameObject> envirObj = new List<GameObject>();
    // 建筑物体列表
    private List<GameObject> buildingObj = new List<GameObject>();

    public void InitialNewEnvironment()
    {
        GenerateTree(new Vector3(0, 0, 0));// 生成树
    }

    private void GenerateTree(Vector3 pos)
    {
        Sprite treeSprite = Resources.Load<Sprite>("Sprites/Trees/treePineLarge");
        if (treeSprite == null)
        {
            Debug.LogError("Can't find tree sprite");
            return;
        }
        GameObject newtree = new GameObject("Tree");

        SpriteRenderer spriteRenderer = newtree.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = treeSprite;

        newtree.transform.position = pos;

        TreeObj treeScript = newtree.AddComponent<TreeObj>();
        treeScript.resourceAmount = 100;

        envirObj.Add(newtree);
    }

    private void GenerateForests()
    {
    }

    private void GenerateBuildings()
    {
    }

    private void GenerateMountains()
    {
    }

    private void GenerateGrasses()
    {
    }

    private void GenerateStones()
    {
    }

    private void GenerateCactuses()
    {
    }
}
