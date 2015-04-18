using UnityEngine;
using System.Collections;

namespace LD32
{
    public class PlayerController : BaseBehaviour
    {

        Rigidbody2D body;
        IInput input;

        public float acceleration;
        public float maxSpeed;

        // Use this for initialization
        void Start()
        {
            input = GetComponent<PlayerInput>();
            body = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 impulse = input.GetMoveVector();

            if (body.velocity.magnitude < maxSpeed)
            {
                impulse = impulse.normalized * acceleration * Time.deltaTime;
                body.AddForce(impulse);
            }
        }
    }

}