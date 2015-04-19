using UnityEngine;
using System.Collections;

namespace LD32
{

    /// <summary>
    /// BaseBehaviour uses this for communication internal to the
    /// GameObject. It's created implicitly with the first BaseBehaviour
    /// on a given object (see BaseBehaviour).
    /// </summary>
    public class BehaviourMessageBus : MonoBehaviour
    {
        public GlobalMessageBus global = GlobalMessageBus.Instance;


        IntEvent _damage = new IntEvent();
        public IntEvent damage { get { return _damage; } }

        BehaviourEvent _destroyed = new BehaviourEvent();
        public BehaviourEvent destroyed { get { return _destroyed; } }

        NoArgEvent _fireBullet = new NoArgEvent();
        public NoArgEvent fireBullet { get { return _fireBullet; } }

        TeamEvent _teamChanged = new TeamEvent();
        public TeamEvent teamChanged { get { return _teamChanged; } }

    }

}
