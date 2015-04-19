using UnityEngine;
using System.Collections;

namespace LD32
{
    public interface IDamageListener
    {
        void Damage(int damageAmount);
    }
}