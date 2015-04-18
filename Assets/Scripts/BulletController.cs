using UnityEngine;
using System.Collections;

namespace LD32
{
    public class BulletController : BaseBehaviour
    {
        Rigidbody2D body;
        // Use this for initialization
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            body.AddForce(new Vector2(10, 10));
        }

        void OnCollisionEnter2D(Collision2D collision) {
            Destroy(this.gameObject);
        }
    }

}