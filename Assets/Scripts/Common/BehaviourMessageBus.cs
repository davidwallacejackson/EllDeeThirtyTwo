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
        /// <summary>
        /// Trigger or respond to damage;
        /// </summary>
        public IntEvent damage = new IntEvent();
        public BehaviourEvent destroyed = new BehaviourEvent();
        public TeamEvent teamChanged = new TeamEvent();
    }

}
