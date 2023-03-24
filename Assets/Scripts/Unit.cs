using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitDetection
{
    public class Unit : MonoBehaviour
    {
        private GameObject selectedGameObject;
        private IMovePosition movePosition;

        public int ActionPoints { get; protected set; } = 10; // 行动力属性值
        public float ActionPointsRecoveryRate { get; protected set; } = 1f; // 行动力恢复速度
        public float RecoveryDelay { get; protected set; } = 5f; // 行动力恢复延迟

        protected float _timeSinceLastAction = 0f;

        private void Awake()
        {
            selectedGameObject = transform.Find("Selected").gameObject;
            movePosition = GetComponent<IMovePosition>();
            SetSelectedVisible(false);
        }

        public void SetSelectedVisible(bool visible)
        {
            selectedGameObject.SetActive(visible);
        }

        public void MoveTo(Vector3 targetPosition)
        {
            movePosition.SetMovePosition(targetPosition);
        }

        protected virtual void Update()
        {
            if (ActionPoints < 10)
            {
                _timeSinceLastAction += Time.deltaTime;

                if (_timeSinceLastAction >= RecoveryDelay)
                {
                    ActionPoints = Mathf.Min(10, ActionPoints + (int)(Time.deltaTime * ActionPointsRecoveryRate));
                }
            }
        }
    }
}