using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private GameObject detectionIndicatorPrefab;
    [SerializeField] private float detectionRadius = 5f;

    private GameObject detectionIndicatorInstance;

    private void Start()
    {
        // 实例化检测指示器并将其设置为初始状态不可见
        Vector3 indicatorOffset = new Vector3(0, 1f, 0); // 您可以根据需要更改这个值
        detectionIndicatorInstance = Instantiate(detectionIndicatorPrefab, transform.position + indicatorOffset, Quaternion.identity, transform);
        detectionIndicatorInstance.SetActive(false);
    }

    private void Update()
    {
        // 查找附近的废墟
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        bool survivorDetected = false;
        foreach (Collider2D collider in colliders)
        {
            Rubble rubble = collider.GetComponent<Rubble>();
            if (rubble != null && rubble.hasSurvivor)
            {
                // 发现有幸存者的废墟
                survivorDetected = true;
                break;
            }
        }

        // 根据是否检测到幸存者更新指示器的可见性
        detectionIndicatorInstance.SetActive(survivorDetected);
    }
}