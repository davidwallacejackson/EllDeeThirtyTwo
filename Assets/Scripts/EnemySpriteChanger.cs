using UnityEngine;
using System.Collections.Generic;

namespace LD32
{

    public class EnemySpriteChanger : BaseBehaviour
    {

        Dictionary<Team, Sprite> teamSprites;

        EnemyController controller;
        SpriteRenderer spriteRenderer;

        // Use this for initialization
        public override void Awake()
        {
            base.Awake();
            messageBus.teamChanged.AddListener(ChangeSprite);
        }

        public override void Start()
        {
            spriteRenderer = transform.FindChild("Sprite").GetComponent<SpriteRenderer>();
            controller = GetComponent<EnemyController>();

            teamSprites = new Dictionary<Team, Sprite>()
            {
                {Team.GOOD, Resources.Load<Sprite>("Sprites/Friendly")},
                {Team.EVIL, Resources.Load<Sprite>("Sprites/Enemy")}
            };
        }

        void OnDestroy()
        {
            messageBus.teamChanged.RemoveListener(ChangeSprite);
        }

        void ChangeSprite(Team team)
        {
            spriteRenderer.sprite = teamSprites[team];
        }
    }

}
