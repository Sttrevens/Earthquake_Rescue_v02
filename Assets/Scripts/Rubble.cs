using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitDetection;

public class Rubble : MonoBehaviour
{
    [SerializeField] private GameObject survivorPrefab;
    [SerializeField] private float survivorProbability = 0.5f;

    private bool hasSurvivor;

    //public GameObject rescuerPrefab;
    //private GameObject instantiatedRescuer;
    //private RescuerUnit rescuerUnit;
    //private bool isSelected = false;

    private void Start()
    {
        hasSurvivor = UnityEngine.Random.value < survivorProbability;
        //RescuerUnit rescuerUnit = new RescuerUnit();
    }

    

    //private void OnRescue()
    //{
    //    Debug.Log("正常启动OnRescue");
    //    if (UnitControlSystem.Instance.IsRescuerSelected())
    //    {
    //        Debug.Log("开始挖掘！");
    //        foreach (Unit unit in UnitControlSystem.Instance.selectedUnitList)
    //        {
    //            if (unit.ToString() == "Fireman(Clone) (UnitDetection.Unit)")
    //            {
    //                instantiatedRescuer = Instantiate(rescuerPrefab);
    //                rescuerUnit = instantiatedRescuer.AddComponent<RescuerUnit>();
    //                rescuerUnit.StartRescueTask(this);
    //                break;
    //            }
    //        }
    //    }
    //}

    public void OnRescueCompleted()
    {
            if (hasSurvivor)
            {
                // 生成幸存者并设置其位置
                GameObject survivor = Instantiate(survivorPrefab, transform.position, Quaternion.identity);
            }

            // 销毁废墟
            Destroy(gameObject);
    }
}