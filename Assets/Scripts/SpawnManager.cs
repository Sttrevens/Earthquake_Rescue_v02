using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    private Camera mainCamera;
    private SpawnTypeListSO spawnTypeList;
    private SpawnTypeSO activeSpawnType;
    private ResourceTypeListSO resourceTypeList;
    private int cost = 0;

    public ResourceTypeSO resourceType;

    private void Awake()
    {
        Instance = this;

        spawnTypeList = Resources.Load<SpawnTypeListSO>(typeof(SpawnTypeListSO).Name);
        //activeSpawnType = spawnTypeList.list[0];
        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        resourceType = resourceTypeList.list[0];
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (activeSpawnType != null)
            {
                Instantiate(activeSpawnType.prefab, GetMouseWorldPosition(), Quaternion.identity);
                ResourceManager.Instance.AddResource(resourceType, -cost);
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    public void SetActiveSpawnType(SpawnTypeSO spawnType)
    {
        activeSpawnType = spawnType;
    }

    public SpawnTypeSO GetActiveSpawnType()
    {
        return activeSpawnType;
    }
}
