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

        public float percentHealthAlertThreshold;
        public Color normalColor;
        public Color alertColor;

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            playerHealth = FindObjectOfType<PlayerController>().GetComponent<Health>();
            healthDisplay = transform.FindChild("Health Display").GetComponent<Text>();

            healthAlertThreshold = (int)(
                percentHealthAlertThreshold * playerHealth.maxHealth);
        }

        void Update()
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
        #endregion

        #region Public API
        #endregion

        #region Internal Methods
        #endregion

        #region Event Callbacks
        #endregion
    }

}