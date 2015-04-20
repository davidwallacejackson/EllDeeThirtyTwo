using UnityEngine;
using System.Collections;

namespace LD32
{
    public class WinPanelController : BaseBehaviour
    {
        //TODO: tracking the number of enemies on this controller and
        //raising the level complete event from here is lame. should be
        //some kind of global-level game manager to do that.
        int totalEnemies;
        GameObject panel;

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();

            //now that everything's instantiated, count the enemies in the scene...
            totalEnemies = FindObjectsOfType<EnemyController>().Length;

            //...and register with our own enemyDestroyed event
            messageBus.global.enemyDestroyed.AddListener(EnemyDestroyed);

            panel = transform.Find("Win Panel").gameObject;
            messageBus.global.levelComplete.AddListener(LevelComplete);
        }
        #endregion

        #region Public API
        #endregion

        #region Internal Methods
        void LevelComplete()
        {
            panel.SetActive(true);
        }
        #endregion

        #region Event Callbacks
        void EnemyDestroyed()
        {
            totalEnemies -= 1;

            if (totalEnemies <= 1)
            {
                messageBus.global.levelComplete.Invoke();
            }
        }

        //TODO: as with DeadPanelController, this is assigned from
        //the editor and we should switch it to code.
        public void Click()
        {
            //TODO: come up with a more appropriate event for this:
            messageBus.global.levelReloading.Invoke();
            Application.LoadLevel("Main Menu");
        }
        #endregion
    }

}