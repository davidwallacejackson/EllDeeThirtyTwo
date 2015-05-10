using UnityEngine;
using System.Collections;

namespace LD32
{
    public class CamerController : BaseBehaviour
    {
        PlayerController player;
        bool isAlive;

        Vector2 screenshakeOffset = Vector2.zero;

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
            MessageBus.Global.ScreenShakeRequested.AddListener(
                ApplyScreenshake);
        }

        public override void Start()
        {
            base.Start();
            player = FindObjectOfType<PlayerController>();
            isAlive = true;

            MessageBus.Global.OnPlayerDestroyed.AddListener(PlayerDestroyed);
        }

        public void Update()
        {
            if (isAlive)
            {
                transform.position = new Vector3(
                    player.transform.position.x + screenshakeOffset.x,
                    player.transform.position.y + screenshakeOffset.y,
                    this.transform.position.z);
            }
            screenshakeOffset = Vector2.zero;
        }
        #endregion

        #region Public API
        #endregion

        #region Internal Methods
        #endregion

        #region Event Callbacks
        void PlayerDestroyed()
        {
            isAlive = false;
        }

        void ApplyScreenshake(float shakeAmount)
        {
            if (shakeAmount == 0)
            {
                return;
            }

            var direction = Random.Range(0f, 2 * Mathf.PI);
            screenshakeOffset = new Vector2(
                Mathf.Cos(direction) * shakeAmount,
                Mathf.Sin(direction) * shakeAmount);
        }
        #endregion
    }

}