using UnityEngine;
using System.Collections;

namespace LD32
{
    public class PlayerInput : BaseBehaviour, IInput
    {

        Vector2 currentMove;
        bool _fire;
        Vector2 _lookAt;

        // Update is called once per frame
        void Update()
        {
            currentMove = Vector3.zero;

            currentMove.x = Input.GetAxis("Horizontal");
            currentMove.y = Input.GetAxis("Vertical");

            _fire = Input.GetButtonDown("Fire");

            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            _lookAt = mousePosition;
        }

        public Vector2 GetMoveVector()
        {
            return currentMove;
        }

        public bool fire
        {
            get
            {
                return _fire;
            }
        }

        public Vector2 lookAt
        {
            get
            {
                return _lookAt;
            }
        }
    }

}