using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    public event EventHandler<OnActiveSpawnTypeChangedEventArgs> OnActiveSpawnTypeChanged;

    public class OnActiveSpawnTypeChangedEventArgs : EventArgs
    {
        public SpawnTypeSO activeSpawnType;
    }

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
        UnitControlSystem controlSystem = GameObject.Find("UnitControlSystem").GetComponent<UnitControlSystem>();
        int budget = ResourceManager.Instance.GetResourceAmount(resourceTypeList.list[0]);
        int target = ResourceManager.Instance.GetResourceAmount(resourceTypeList.list[1]);

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (activeSpawnType != null)
            {
                cost = activeSpawnType.cost;
                if (budget >= cost)
                {
                    Instantiate(activeSpawnType.prefab, UtilsClas.GetMouseWorldPosition(), Quaternion.identity);
                    ResourceManager.Instance.AddResource(resourceType, -cost);
                    GameController.Instance.AddToBudgetUsed(cost);
                }
                else
                {
                    controlSystem.shownoBudgetText();
                }
            }
        }
    }

    

    public void SetActiveSpawnType(SpawnTypeSO spawnType)
    {
        activeSpawnType = spawnType;

        OnActiveSpawnTypeChanged?.Invoke(this, new OnActiveSpawnTypeChangedEventArgs { activeSpawnType = activeSpawnType });
    }

    public SpawnTypeSO GetActiveSpawnType()
    {
        return activeSpawnType;
    }
}
