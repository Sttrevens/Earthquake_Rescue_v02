using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostGenerator : MonoBehaviour
{
    public int cost = 0;
    private SpawnTypeListSO spawnTypeList;
    private SpawnTypeSO spawnType;

    void Awake()
    {
        spawnTypeList = Resources.Load<SpawnTypeListSO>(typeof(SpawnTypeListSO).Name);
        Debug.Log("List: " + spawnTypeList);
        Debug.Log("Type: " + spawnType);
        //spawnType = spawnTypeList.list[0];

        //if (spawnType = spawnTypeList.list[0])
        //{
        //    cost = 1;
        //}

        //if (spawnType = spawnTypeList.list[1])
        //{
        //    cost = 2;
        //}

        //if (spawnType = spawnTypeList.list[2])
        //{
        //    cost = 3;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}