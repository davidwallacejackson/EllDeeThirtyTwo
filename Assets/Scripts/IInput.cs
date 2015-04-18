using UnityEngine;
using System.Collections;

namespace LD32
{
    public interface IInput
    {
        Vector2 GetMoveVector();

        Vector2 lookAt
        {
            get;
        }

        bool fire
        {
            get;
        }
    }
}