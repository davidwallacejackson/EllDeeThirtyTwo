using UnityEngine;
using System.Collections.Generic;

namespace LD32
{

    public class EnemySpriteChanger : BaseBehaviour
    {

        Dictionary<Team, Sprite> teamSprites;

        SpriteRenderer spriteRenderer;

        // Use this for initialization
        public override void Awake()
        {
            base.Awake();
            MessageBus.ChangeTeam.AddListener(ChangeSprite);
        }

        public override void Start()
        {
            spriteRenderer = transform.FindChild("Sprite").GetComponent<SpriteRenderer>();

            teamSprites = new Dictionary<Team, Sprite>()
            {
                {Team.GOOD, Resources.Load<Sprite>("Sprites/Friendly")},
                {Team.EVIL, Resources.Load<Sprite>("Sprites/Enemy")}
            };
        }

        void OnDestroy()
        {
            MessageBus.ChangeTeam.RemoveListener(ChangeSprite);
        }

        void ChangeSprite(Team team)
        {
            spriteRenderer.sprite = teamSprites[team];
        }
    }

}
