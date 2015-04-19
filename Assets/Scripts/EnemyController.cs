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

        #region Unity Hooks

        public override void Awake()
        {
            base.Awake();
            messageBus.global.convert.AddListener(GlobalConvert);
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

        // Update is called once per frame
        void Update()
        {
            LookAt2D(input.lookAt);
        }

        void OnDestroy()
        {
            messageBus.global.convert.RemoveListener(GlobalConvert);
            StopCoroutine(firePeriodically);
        }

        #endregion

        #region Internal API
        IEnumerator FirePeriodically()
        {
            while (true)
            {
                cannon.FireBullet();
                yield return new WaitForSeconds(fireDelay);
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Something needs to switch sides. May or may not be us.
        /// </summary>
        void GlobalConvert(GameObject target)
        {
            if (target == this.gameObject)
            {
                team = Team.GOOD;
            }
            else if (this.team == Team.GOOD)
            {
                //there can only be one ally at a time:
                team = Team.EVIL;
            }
        }
        #endregion
    }

}
