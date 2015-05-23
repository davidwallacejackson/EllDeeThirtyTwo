using UnityEngine;

namespace LD32
{
    public class DeadPanelController : BaseBehaviour
    {
        GameObject panel;

        #region Unity Hooks
        public override void Start()
        {
            base.Start();

            panel = transform.Find("Dead Panel").gameObject;
            MessageBus.Global.OnPlayerDestroyed.AddListener(PlayerDestroyed);
        }

        public void OnApplicationQuit()
        {
            MessageBus.Global.OnPlayerDestroyed.RemoveListener(
                PlayerDestroyed);
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
            MessageBus.Global.OnLevelWillReload.Invoke();
            Application.LoadLevel(Application.loadedLevel);
        }
        #endregion
    }

}