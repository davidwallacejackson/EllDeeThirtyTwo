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

        // Use this for initialization
        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var targets = collision.gameObject.GetComponents<IDamageListener>();

            foreach (var target in targets)
            {
                target.Damage(damage);
            }

            this.Destroy();
        }

        public void Push(float force)
        {
            body.AddRelativeForce(new Vector2(force, 0));
        }

        public static void Instantiate(Vector2 location, Quaternion orientation, float force, int damage)
        {
            var bullet = Instantiate<GameObject>(prefab).GetComponent<BulletController>();
            bullet.transform.position = location;
            bullet.transform.rotation = orientation;
            bullet.damage = damage;
            bullet.Push(force);
        }

    }

}