using UnityEngine;
using System.Collections.Generic;

namespace LD32
{

    public class EnemySpriteChanger : BaseBehaviour
    {

        Dictionary<Team, Sprite> teamSprites;

        EnemyController controller;
        SpriteRenderer renderer;

        // Use this for initialization
        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            controller = GetComponent<EnemyController>();

            teamSprites = new Dictionary<Team, Sprite>()
            {
                {Team.GOOD, Resources.Load<Sprite>("Sprites/Friendly")},
                {Team.EVIL, Resources.Load<Sprite>("Sprites/Enemy")}
            };

            controller.teamChanged.AddListener(ChangeSprite);

            controller.team = Team.GOOD;
        }

        void OnDestroy()
        {
            controller.teamChanged.RemoveListener(ChangeSprite);
        }

        void ChangeSprite(Team team)
        {
            renderer.sprite = teamSprites[team];
        }
    }

}
