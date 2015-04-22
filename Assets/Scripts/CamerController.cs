using UnityEngine;
using System.Collections;

namespace LD32
{
    public class CamerController : BaseBehaviour
    {
        PlayerController player;
        bool isAlive;

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
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
                    player.transform.position.x,
                    player.transform.position.y,
                    this.transform.position.z);
            }
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
        #endregion
    }

}