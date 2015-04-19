using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace LD32
{
    public class GlobalMessageBus
    {
        static GlobalMessageBus _instance;
        public static GlobalMessageBus Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalMessageBus();
                }

                return _instance;
            }
        }

        GameObjectEvent _convert = new GameObjectEvent();
        public GameObjectEvent convert { get { return _convert; } }

        NoArgEvent _enemyDestroyed = new NoArgEvent();
        public NoArgEvent enemyDestroyed { get { return _enemyDestroyed; } }
    }

}