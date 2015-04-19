using UnityEngine;
using System.Collections.Generic;

namespace LD32
{
    public class BaseBehaviour : MonoBehaviour
    {
        BehaviourMessageBus _messageBus;
        public BehaviourMessageBus messageBus
        {
            get
            {
                return _messageBus;
            }
        }

        public virtual void Awake()
        {
            //resolve messageBus before we do anything else:
            _messageBus = GetComponent<BehaviourMessageBus>();

            if (_messageBus == null)
            {
                //we couldn't find a message bus -- we'll have to
                //create one
                _messageBus = gameObject.AddComponent<BehaviourMessageBus>();
            }
        }

        public virtual void Start()
        {

        }

        void OnDestroy()
        {
            messageBus.destroyed.Invoke(this);
        }

        protected void LookAt2D(Vector2 lookAt)
        {
            var lookDirection = lookAt - (Vector2)transform.position;

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        protected virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }

}