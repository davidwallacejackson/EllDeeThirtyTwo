using UnityEngine;

namespace LD32
{

    public static class ExtensionMethods
    {
        public static BehaviourMessageBus GetMessageBus(this GameObject go)
        {
            var messageBus = go.GetComponent<BehaviourMessageBus>();

            if (messageBus == null)
            {
                //no message bus yet -- make one!
                messageBus = go.AddComponent<BehaviourMessageBus>();
            }

            return messageBus;
        }

        public static BehaviourMessageBus GetMessageBus(this Component comp)
        {
            return comp.gameObject.GetMessageBus();
        }
    }

}
