using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitTypeSelectedUI : MonoBehaviour
{
    [SerializeField] private Sprite arrowSprite;

    private Dictionary<SpawnTypeSO, Transform> buttonTransformDictionary;
    private Transform arrowButton;

    private void Awake()
    {
        Transform buttonTemplate = transform.Find("buttonTemplate");
        buttonTemplate.gameObject.SetActive(false);

        SpawnTypeListSO spawnTypeList = Resources.Load<SpawnTypeListSO>(typeof(SpawnTypeListSO).Name);

        //for (int i = 0; i < spawnTypeList.list.Count; i++)
        //{
        //    Debug.Log("Element at index " + i + ": " + spawnTypeList.list[i]);
        //}

        buttonTransformDictionary = new Dictionary<SpawnTypeSO, Transform>();

        int index = 0;
        arrowButton = Instantiate(buttonTemplate, transform);
        arrowButton.gameObject.SetActive(true);

        float offsetAmount = 130f;
        arrowButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

        arrowButton.Find("image").GetComponent<Image>().sprite = arrowSprite;

        arrowButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            SpawnManager.Instance.SetActiveSpawnType(null);
        });

        index++;

        foreach (SpawnTypeSO spawnType in spawnTypeList.list)
        {
            Transform buttonTransform = Instantiate(buttonTemplate, transform);
            buttonTransform.gameObject.SetActive(true);

            offsetAmount = 130f;
            buttonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            buttonTransform.Find("image").GetComponent<Image>().sprite = spawnType.sprite;

            buttonTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                SpawnManager.Instance.SetActiveSpawnType(spawnType);
            });

            buttonTransformDictionary[spawnType] = buttonTransform;

            index++;
        }
    }

    private void Update()
    {
        UpdateActiveUnitTypeButton();
    }

    private void UpdateActiveUnitTypeButton()
    {
        arrowButton.Find("selected").gameObject.SetActive(false);
        foreach (SpawnTypeSO spawnType in buttonTransformDictionary.Keys)
        {
            Transform buttonTransform = buttonTransformDictionary[spawnType];
            buttonTransform.Find("selected").gameObject.SetActive(false);
        }

        SpawnTypeSO activeSpawnType = SpawnManager.Instance.GetActiveSpawnType();
        if (activeSpawnType == null)
        {
            arrowButton.Find("selected").gameObject.SetActive(true);
        }
        else
        {
            buttonTransformDictionary[activeSpawnType].Find("selected").gameObject.SetActive(true);
        }
    }
}
