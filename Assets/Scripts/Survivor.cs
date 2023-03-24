using UnityEngine;
using UnitDetection;
using Mono.Cecil;

public class Survivor : MonoBehaviour
{
    private bool isHealed = false;
    private ResourceTypeListSO resourceTypeList;

    Animator animator;

    public ResourceTypeSO target;

    private void Awake()
    {
        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        target = resourceTypeList.list[1];
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //private void OnMouseDown()
    //{
    //    if (UnitControlSystem.Instance.IsDoctorSelected())
    //    {
    //        foreach (Unit unit in UnitControlSystem.Instance.selectedUnitList)
    //        {
    //            Debug.Log(unit);
    //            if (unit is DoctorUnit doctorUnit)
    //            {
    //                doctorUnit.StartHealTask(this);
    //                break;
    //            }
    //        }
    //    }
    //}

    public void Healed()
    {
        if (isHealed == false)
        {
            isHealed = true;
            // 在这里更新幸存者的外观或状态，以表示他们已经被治疗
            animator.SetTrigger("isHealed");
            ResourceManager.Instance.AddResource(target, -1);
        }
    }
}