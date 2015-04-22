using UnityEngine;
using System.Collections;

namespace LD32
{
    //can fire Cannon by raising fireEvent
    public interface IInput
    {
        Vector2 MoveVector
        {
            get;
        }

        Vector2 lookAt
        {
            get;
        }

    }
}