using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitDetection;

public class Rubble : MonoBehaviour
{
    [SerializeField] private GameObject survivorPrefab;

    public bool hasSurvivor;

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