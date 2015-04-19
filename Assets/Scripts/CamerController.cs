using UnityEngine;
using System.Collections;

namespace LD32
{
    public class CamerController : BaseBehaviour
    {
        Camera camera;
        PlayerController player;
        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
            camera = GetComponent<Camera>();
        }

        public override void Start()
        {
            base.Start();
            player = FindObjectOfType<PlayerController>();

        }

        public void Update()
        {
            transform.position = new Vector3(
                player.transform.position.x,
                player.transform.position.y,
                this.transform.position.z);
        }
        #endregion

        #region Public API
        #endregion

        #region Internal Methods
        #endregion

        #region Event Callbacks
        #endregion
    }

}