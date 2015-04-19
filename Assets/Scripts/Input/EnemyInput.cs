using UnityEngine;
using System.Collections;

namespace LD32
{
    public class EnemyInput : BaseBehaviour, IInput
    {
        /// <summary>
        /// Set this to the player.
        /// </summary>
        Transform target;

        void Start()
        {
            target = FindObjectOfType<PlayerController>().transform;
        }

        public Vector2 GetMoveVector()
        {
            return Vector2.zero;
        }

        public Vector2 lookAt
        {
            get
            {
                return target.position;
            }
        }

        public bool fire
        {
            get
            {
                return false;
            }
        }
    }

}