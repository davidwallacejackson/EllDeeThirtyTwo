using UnityEngine;
using UnityEngine.Events;

namespace LD32
{
    public class BehaviourEvent : UnityEvent<BaseBehaviour> { }
    public class FloatEvent : UnityEvent<float> { }
    public class IntEvent : UnityEvent<int> { }
    public class GameObjectEvent : UnityEvent<GameObject> { }
    public class NoArgEvent : UnityEvent { }
    public class TeamEvent : UnityEvent<Team> { }
    public class VectorEvent : UnityEvent<Vector2> { }
}
