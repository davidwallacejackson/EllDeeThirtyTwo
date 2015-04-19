using UnityEngine;
using System.Collections.Generic;

namespace LD32
{
    public class BaseBehaviour : MonoBehaviour
    {
        public BehaviourEvent destroyed = new BehaviourEvent();

        protected void LookAt2D(Vector2 lookAt)
        {
            var lookDirection = lookAt - (Vector2)transform.position;

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        void OnDestroy()
        {
            destroyed.Invoke(this);
        }

        protected virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }

}