using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitDetection
{
    public class DoctorUnit : Unit
    {
        public float healRange = 2f; // 治疗范围
        public float healDuration = 2f; // 治疗时长

        public void StartHealTask(Survivor survivor)
        {
            if (Vector3.Distance(transform.position, survivor.transform.position) <= healRange)
            {
                StartCoroutine(Heal(survivor));
            }
            else
            {
                Debug.Log("医生距离废墟太远，无法进行治疗。");
            }
        }

        private IEnumerator Heal(Survivor survivor)
        {
            // 播放治疗动画
            // animator.SetTrigger("Heal");

            // 治疗过程
            yield return new WaitForSeconds(healDuration);

            // 治疗结束，改变幸存者状态
            survivor.Healed();

            // 恢复行动力属性值
            // RestoreActionPoints();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    Survivor survivor = hit.collider.GetComponent<Survivor>();
                    if (survivor != null)
                    {
                        UnitControlSystem unitControlSystem = UnitControlSystem.Instance;
                        foreach (Unit unit in UnitControlSystem.Instance.selectedUnitList)
                        {
                            if (unit.ToString() == "body_nurse(Clone) (UnitDetection.DoctorUnit)")
                            {
                                StartHealTask(survivor);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}