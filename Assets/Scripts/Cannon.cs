using UnityEngine;
using System.Collections;

namespace LD32
{
    public class Cannon : BaseBehaviour, ICannon
    {
        public float distanceToSpawnBullet;
        public float bulletForce;
        public int bulletDamage;

        public void FireBullet()
        {
            BulletController.Instantiate(
                transform.TransformPoint(new Vector2(1, 0)),
                transform.rotation,
                bulletForce,
                bulletDamage);
        }
    }

}