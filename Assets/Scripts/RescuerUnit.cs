using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UnitDetection
{
    public class RescuerUnit : Unit
    {
        //private TextMeshProUGUI distanceWarningText;

        void Start()
        {
            //    distanceWarningText = GameObject.Find("DistanceWarningText").GetComponent<TextMeshProUGUI>();
            //    distanceWarningText.gameObject.SetActive(false);
            //    if (distanceWarningText == null)
            //    {
            //        Debug.Log("jiba");
            //    }
            
        }

        public void StartRescueTask(Rubble rubble)
        {
            float distance = Vector3.Distance(transform.position, rubble.transform.position);

            UnitControlSystem controlSystem = GameObject.Find("UnitControlSystem").GetComponent<UnitControlSystem>();

            if (distance <= 5f)
            {
                StartCoroutine(PerformRescueTask(rubble));
            }
            else
            {
                if (controlSystem == null)
                {
                    Debug.Log("jiba");
                }
                controlSystem.showdistanceRescueText();
            }
        }

        private IEnumerator PerformRescueTask(Rubble rubble)
        {
            Debug.Log("Start Rescue!");
            // 消耗行动力并播放挖掘动画
            ActionPoints -= 2;
            // Play digging animation

            // 等待挖掘动画完成
            yield return new WaitForSeconds(2f); // 假设挖掘动画持续2秒

            rubble.OnRescueCompleted();

            _timeSinceLastAction = 0f;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                //Debug.Log("按Q有用");

                if (hit.collider != null)
                {
                    Rubble rubble = hit.collider.GetComponent<Rubble>();
                    //RescuerUnit rescuerUnit = new RescuerUnit();
                    if (rubble != null)
                    {
                        UnitControlSystem unitControlSystem = UnitControlSystem.Instance;
                        foreach (Unit unit in unitControlSystem.selectedUnitList)
                        {
                            if (unit.ToString() == "Fireman(Clone) (UnitDetection.Unit)")
                            {
                                StartRescueTask(rubble);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}