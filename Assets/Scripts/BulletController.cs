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
        // Use this for initialization
        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
        }

        public void Push(float force)
        {
            body.AddRelativeForce(new Vector2(force, 0));
        }

        public static void Instantiate(Vector2 location, Quaternion orientation, float force)
        {
            var bullet = Instantiate<GameObject>(prefab).GetComponent<BulletController>();
            bullet.transform.position = location;
            bullet.transform.rotation = orientation;
            bullet.Push(force);
        }
    }

}