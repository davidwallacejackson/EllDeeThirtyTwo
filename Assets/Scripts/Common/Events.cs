using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace LD32
{
    public class IntEvent : UnityEvent<int> { }
    public class BehaviourEvent : UnityEvent<BaseBehaviour> { }
    public class TeamEvent : UnityEvent<Team> { }
    public class GameObjectEvent : UnityEvent<GameObject> { }
}
