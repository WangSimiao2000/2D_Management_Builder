using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        GridMapMgr.Instance.mapX = 25;
        GridMapMgr.Instance.mapY = 25;
        GridMapMgr.Instance.CreateGridDictionary();
    }
}
