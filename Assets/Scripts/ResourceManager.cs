using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }


    public event EventHandler OnResourceAmountChanged;

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    public int initialbudget;
    public int initialtarget;

    public ResourceTypeSO budgetSO;
    public ResourceTypeSO targetSO;

    private void Awake()
    {
        Instance = this;
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        resourceAmountDictionary[budgetSO] = initialbudget;
        resourceAmountDictionary[targetSO] = initialtarget;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
        TestLogResourceAmountDictionary();
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        return resourceAmountDictionary[resourceType];
    }

    public bool IsResourceAmountZero(ResourceTypeSO resourceType)
    {
        if (resourceAmountDictionary.ContainsKey(resourceType))
        {
            return resourceAmountDictionary[resourceType] == 0;
        }
        else
        {
            // 如果资源类型不在字典中，我们可以假定该资源的数量为0。
            return true;
        }
    }
}
