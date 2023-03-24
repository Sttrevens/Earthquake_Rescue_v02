using UnityEngine;
using UnitDetection;

public class Survivor : MonoBehaviour
{
    private bool isHealed = false;

    Animator animator;

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
        isHealed = true;
        // 在这里更新幸存者的外观或状态，以表示他们已经被治疗
        animator.SetTrigger("isHealed");
    }
}