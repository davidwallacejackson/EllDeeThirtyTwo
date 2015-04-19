using UnityEngine;
using System.Collections;

namespace LD32
{
    //can fire Cannon by raising fireEvent
    public interface IInput
    {
        Vector2 GetMoveVector();

        Vector2 lookAt
        {
            get;
        }

    }
}