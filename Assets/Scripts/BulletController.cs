using UnityEngine;
using System.Collections;

namespace LD32
{
    public class BulletController : BaseBehaviour
    {
        static GameObject prefab
        {
            get
            {
                return Resources.Load<GameObject>("Bullet");
            }
        }

        Rigidbody2D body;
        int damage;
        BulletMode mode;

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
            body = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var target = collision.gameObject.GetMessageBus();
            
            MessageToTarget(target);

            Destroy(this.gameObject);

            Sparks.Instantiate(
                transform.position,
                collision.contacts[0].normal);
        }
        #endregion

        #region Public API
        public void Push(float force)
        {
            body.AddRelativeForce(new Vector2(force, 0));
        }

        public static void Instantiate(Vector2 location, Quaternion orientation,
            float force, BulletMode mode, int damage = 0)
        {
            var bullet = Instantiate<GameObject>(prefab).GetComponent<BulletController>();
            bullet.transform.position = location;
            bullet.transform.rotation = orientation;
            bullet.mode = mode;
            bullet.damage = damage;
            bullet.Push(force);
        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Depending on the bullet's mode, either deals damage or sends
        /// a team change signal.
        /// </summary>
        /// <param name="target">a target we just hit</param>
        void MessageToTarget(BehaviourMessageBus target)
        {
            if (mode == BulletMode.Damage)
            {
                target.Damage.Invoke(damage);
            }
            else if (mode == BulletMode.Convert)
            {
                MessageBus.Global.Convert.Invoke(target.gameObject);
            }
        }
        #endregion
    }

}