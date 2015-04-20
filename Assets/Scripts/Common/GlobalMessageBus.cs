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

        public GlobalMessageBus()
        {
            //tear down the global bus if the level reloads:
            this.levelReloading.AddListener(Teardown);
        }

        void Teardown()
        {
            _instance = null;
        }

        GameObjectEvent _convert = new GameObjectEvent();
        public GameObjectEvent convert { get { return _convert; } }

        NoArgEvent _enemyDestroyed = new NoArgEvent();
        public NoArgEvent enemyDestroyed { get { return _enemyDestroyed; } }

        NoArgEvent _playerDestroyed = new NoArgEvent();
        public NoArgEvent playerDestroyed { get { return _playerDestroyed; } }

        NoArgEvent _levelComplete = new NoArgEvent();
        public NoArgEvent levelComplete { get { return _levelComplete; } }

        NoArgEvent _levelReloading = new NoArgEvent();
        public NoArgEvent levelReloading { get { return _levelReloading; } }
    }

}