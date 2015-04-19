using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace LD32
{
    public class BehaviourEvent : UnityEvent<BaseBehaviour> { }
    public class IntEvent : UnityEvent<int> { }
    public class GameObjectEvent : UnityEvent<GameObject> { }
    public class NoArgEvent : UnityEvent { }
    public class TeamEvent : UnityEvent<Team> { }
}
