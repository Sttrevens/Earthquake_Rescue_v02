using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnitDetection;
using TMPro;
using UnityEngine.UI;

public class UnitControlSystem : MonoBehaviour
{
    public static UnitControlSystem Instance;

    [SerializeField] private Transform selectionAreaTransform;
    private Vector3 startPosition;
    public List<Unit> selectedUnitList;

    public TextMeshProUGUI distanceWarningText;

    private void Awake()
    {
        selectedUnitList = new List<Unit>();
        selectionAreaTransform.gameObject.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        distanceWarningText = GameObject.Find("DistanceWarningText").GetComponent<TextMeshProUGUI>();
        distanceWarningText.gameObject.SetActive(false);
        if (distanceWarningText == null)
        {
            Debug.Log("jiba");
        }
    }

    public void showdistanceRescueText()
    {
        distanceWarningText.text = "Too far for rescue!";
        StartCoroutine(HideDistanceWarningTextAfterDelay(3f));
    }

    IEnumerator HideDistanceWarningTextAfterDelay(float delay)
    {
        distanceWarningText.gameObject.SetActive(true); // 显示文本
        yield return new WaitForSeconds(delay); // 等待指定的延迟时间
        distanceWarningText.gameObject.SetActive(false); // 隐藏文本
    }

    public void hidedistanceText()
    {
        distanceWarningText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectionAreaTransform.gameObject.SetActive(true);
            startPosition = UtilsClass.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
            );
            Vector3 upperRight = new Vector3(
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
            );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectionAreaTransform.gameObject.SetActive(false);

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition());

            foreach (Unit unit in selectedUnitList)
            {
                unit.SetSelectedVisible(false);
            }
            selectedUnitList.Clear();

            foreach (Collider2D collider2D in collider2DArray)
            {
                Unit unit = collider2D.GetComponent<Unit>();
                if (unit != null)
                {
                    unit.SetSelectedVisible(true);
                    selectedUnitList.Add(unit);
                }
            }
            //Debug.Log(selectedUnitList.Count);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 moveToPosition = UtilsClass.GetMouseWorldPosition();

            foreach (Unit unit in selectedUnitList)
            {
                unit.MoveTo(moveToPosition);
            }
        }
    }

    public bool IsRescuerSelected()
    {
        Debug.Log("开始检测是不是搜救员1");
        foreach (Unit unit in selectedUnitList)
        {
            Debug.Log("开始检测是不是搜救员2");
            Debug.Log(unit);
            if (unit.ToString() == "Fireman(Clone) (UnitDetection.Unit)")
            {
                Debug.Log("有搜救员！");
                return true;
            }
        }
        return false;
    }

    public bool IsDoctorSelected()
    {
        foreach (Unit unit in selectedUnitList)
        {
            if (unit is DoctorUnit)
            {
                return true;
            }
        }
        return false;
    }
}
