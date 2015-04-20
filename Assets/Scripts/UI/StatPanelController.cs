using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace LD32
{
    public class StatPanelController : BaseBehaviour
    {
        Health playerHealth;
        Text healthDisplay;
        int healthAlertThreshold;

        bool isAlive;
        int totalEnemies = 0;
        Text enemiesDisplay;

        public float percentHealthAlertThreshold;
        public Color normalColor;
        public Color alertColor;

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
            messageBus.global.enemyDestroyed.AddListener(EnemyDestroyed);
            messageBus.global.levelReloading.AddListener(LevelReloading);
        }

        public override void Start()
        {
            base.Start();
            isAlive = true;
            playerHealth = FindObjectOfType<PlayerController>().GetComponent<Health>();
            healthDisplay = transform.Find("Health Row/Health Display").GetComponent<Text>();

            healthAlertThreshold = (int)(
                percentHealthAlertThreshold * playerHealth.maxHealth);

            totalEnemies = FindObjectsOfType<EnemyController>().Length;
            enemiesDisplay = transform.Find("Enemies Row/Enemies Display").GetComponent<Text>();
            enemiesDisplay.text = totalEnemies.ToString("D2");
        }

        void Update()
        {
            if (isAlive)
            {
                healthDisplay.text = playerHealth.health.ToString("D3");


                if (playerHealth.health < healthAlertThreshold)
                {
                    healthDisplay.color = alertColor;
                }
                else
                {
                    healthDisplay.color = normalColor;
                }
            }
        }
        #endregion

        #region Public API
        #endregion

        #region Internal Methods
        void EnemyDestroyed()
        {
            if (isAlive)
            {
                totalEnemies -= 1;
                enemiesDisplay.text = totalEnemies.ToString("D2");
            }
        }

        void LevelReloading()
        {
            isAlive = false;
        }
        #endregion

        #region Event Callbacks
        #endregion
    }

}