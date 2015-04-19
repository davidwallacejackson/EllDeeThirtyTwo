using UnityEngine;
using System.Collections;

namespace LD32
{

    public class EnemyController : BaseBehaviour
    {
        Rigidbody2D body;
        IInput input;
        ICannon cannon;

        IEnumerator firePeriodically;

        public float maxTurnSpeed;
        public float fireDelay;

        // Use this for initialization
        void Start()
        {
            input = GetComponent<IInput>();
            body = GetComponent<Rigidbody2D>();
            cannon = GetComponent<ICannon>();

            firePeriodically = FirePeriodically();
            StartCoroutine(firePeriodically);
        }

        void OnDestroy()
        {
            StopCoroutine(firePeriodically);
        }

        // Update is called once per frame
        void Update()
        {
            LookAt2D(input.lookAt);
        }

        IEnumerator FirePeriodically()
        {
            while (true)
            {
                cannon.FireBullet();
                yield return new WaitForSeconds(fireDelay);
            }
        }
    }

}
