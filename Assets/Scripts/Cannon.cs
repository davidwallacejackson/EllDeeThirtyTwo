using UnityEngine;

namespace LD32
{
    public class Cannon : BaseBehaviour, ICannon
    {
        public float distanceToSpawnBullet;
        public float bulletForce;
        public BulletMode mode = BulletMode.Damage;
        public int bulletDamage;

        public override void Awake()
        {
            base.Awake();

            messageBus.fireBullet.AddListener(FireBullet);
        }

        public void OnDestroy()
        {
            messageBus.fireBullet.RemoveListener(FireBullet);
        }

        public void FireBullet()
        {
            BulletController.Instantiate(
                transform.TransformPoint(new Vector2(1, 0)),
                transform.rotation,
                bulletForce,
                mode,
                bulletDamage);
            
        }
    }

}