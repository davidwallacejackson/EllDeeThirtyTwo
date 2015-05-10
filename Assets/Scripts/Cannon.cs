using UnityEngine;

namespace LD32
{
    public class Cannon : BaseBehaviour
    {
        public float distanceToSpawnBullet;
        public float bulletForce;
        public float kickbackForce;
        public float screenshakeAmount;
        public BulletMode mode = BulletMode.Damage;
        public int bulletDamage;
        public AudioClip fireSound;

        public override void Awake()
        {
            base.Awake();

            MessageBus.FireBullet.AddListener(FireBullet);
        }

        public void OnDestroy()
        {
            MessageBus.FireBullet.RemoveListener(FireBullet);
        }

        public void FireBullet()
        {
            BulletController.Instantiate(
                transform.TransformPoint(new Vector2(1, 0)),
                transform.rotation,
                bulletForce,
                mode,
                bulletDamage);

            if (fireSound != null)
            {
                AudioSource.PlayClipAtPoint(fireSound, transform.position);
            }

            var kickback = transform.right * -1 * kickbackForce;
            MessageBus.ImpulseRequested.Invoke(kickback);

            MessageBus.Global.ScreenShakeRequested.Invoke(screenshakeAmount);
        }
    }

}