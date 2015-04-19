using UnityEngine;
using System.Collections;

namespace LD32
{
    public class Cannon : BaseBehaviour
    {
        public float distanceToSpawnBullet;

        public void FireBullet()
        {
            BulletController.Instantiate(
                transform.TransformPoint(new Vector2(1, 0)),
                transform.rotation,
                10f);
        }
    }

}