using UnityEngine;
using System.Collections;

namespace LD32
{
    public class PlayerController : BaseBehaviour
    {

        Rigidbody2D body;
        IInput input;
        ICannon cannon;

        public float acceleration;
        public float maxSpeed;


        // Use this for initialization
        void Start()
        {
            input = GetComponent<PlayerInput>();
            cannon = GetComponent<Cannon>();
            body = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            LookAt2D(input.lookAt);

            if (input.fire)
            {
                cannon.FireBullet();
            }
        }

        void FixedUpdate()
        {
            Vector2 impulse = input.GetMoveVector();
            impulse = impulse.normalized * acceleration * Time.fixedDeltaTime;
            body.AddForce(impulse);

            if (body.velocity.magnitude > maxSpeed)
            {
                body.velocity = body.velocity.normalized * maxSpeed;
            }
        }

    }

}