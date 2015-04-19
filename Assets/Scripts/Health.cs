using UnityEngine;
using System.Collections;

namespace LD32
{
    public class Health : BaseBehaviour, IDamageListener
    {
        int _health;

        public int maxHealth;
        public int health
        {
            get
            {
                return _health;
            }
        }

        public override void Start()
        {
            _health = maxHealth;
        }

        public void Damage(int damageAmount)
        {
            _health -= damageAmount;

            if (_health <= 0)
            {
                this.Destroy();
            }
        }
    }

}