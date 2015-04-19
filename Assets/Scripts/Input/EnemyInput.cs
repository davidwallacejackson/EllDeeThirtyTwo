using UnityEngine;
using System.Collections;

namespace LD32
{
    public class EnemyInput : BaseBehaviour, IInput
    {
        /// <summary>
        /// Set this to the player.
        /// </summary>
        PlayerController target;
        Vector2 lastTargetPosition;

        bool targetIsAlive = false;

        void Start()
        {
            target = FindObjectOfType<PlayerController>();
            targetIsAlive = true;
            target.destroyed.AddListener(TargetDestroyed);
        }

        public Vector2 GetMoveVector()
        {
            return Vector2.zero;
        }

        public Vector2 lookAt
        {
            get
            {
                if (targetIsAlive)
                {
                    lastTargetPosition = target.transform.position;
                }

                return lastTargetPosition;
            }
        }

        public bool fire
        {
            get
            {
                return false;
            }
        }

        public void TargetDestroyed(BaseBehaviour destroyed)
        {
            targetIsAlive = false;
        }
    }

}