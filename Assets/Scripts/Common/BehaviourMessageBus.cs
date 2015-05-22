using UnityEngine;

namespace LD32
{

    /// <summary>
    /// BaseBehaviour uses this for communication internal to the
    /// GameObject. It's created implicitly with the first BaseBehaviour
    /// on a given object (see BaseBehaviour).
    /// </summary>
    public class BehaviourMessageBus : MonoBehaviour
    {
        public GlobalMessageBus Global
        {
            get
            {
                return GlobalMessageBus.Instance;
            }
        }

        TeamEvent changeTeam = new TeamEvent();
        public TeamEvent ChangeTeam { get { return changeTeam; } }

        IntEvent _damage = new IntEvent();
        public IntEvent Damage { get { return _damage; } }

        NoArgEvent _fireBullet = new NoArgEvent();
        public NoArgEvent FireBullet { get { return _fireBullet; } }

        BehaviourEvent _destroyed = new BehaviourEvent();
        public BehaviourEvent OnDestroy { get { return _destroyed; } }

        VectorEvent _impulseRequested = new VectorEvent();
        public VectorEvent ImpulseRequested { get {
            return _impulseRequested; } }

    }

}
