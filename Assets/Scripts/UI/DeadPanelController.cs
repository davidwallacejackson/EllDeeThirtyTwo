using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace LD32
{
    public class DeadPanelController : BaseBehaviour
    {
        GameObject panel;

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();

            panel = transform.Find("Dead Panel").gameObject;
            messageBus.global.playerDestroyed.AddListener(PlayerDestroyed);
        }
        #endregion

        #region Public API
        #endregion

        #region Internal Methods
        #endregion

        #region Event Callbacks
        void PlayerDestroyed()
        {
            panel.SetActive(true);
        }

        //TODO: we're binding this from the UI. would prefer to do
        //it in PlayerDestroyed() when we enable the panel.
        public void Click()
        {
            messageBus.global.levelReloading.Invoke();
            Application.LoadLevel(Application.loadedLevel);
        }
        #endregion
    }

}