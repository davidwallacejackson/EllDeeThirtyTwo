using UnityEngine;
using System.Collections;

namespace LD32
{

    public class EnemyController : BaseBehaviour
    {
        Rigidbody2D body;
        IInput input;
        ICannon cannon;
        Team _team = Team.EVIL;

        IEnumerator firePeriodically;

        public float maxTurnSpeed;
        public float fireDelay;

        public Team team
        {
            get
            {
                return _team;
            }
            set
            {
                _team = value;
                messageBus.teamChanged.Invoke(_team);
            }
        }

        // Use this for initialization
        public override void Start()
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
