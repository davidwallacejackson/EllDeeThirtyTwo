using UnityEngine;

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
            this.OnLevelWillReload.AddListener(Teardown);
            this.ManualReloadLevel.AddListener(Reload);
        }

        void Teardown()
        {
            _instance = null;
        }

        void Reload()
        {
            this.OnLevelWillReload.Invoke();
            Application.LoadLevel(Application.loadedLevel);
        }

        GameObjectEvent _convert = new GameObjectEvent();
        public GameObjectEvent Convert { get { return _convert; } }

        FloatEvent _screenShakeRequested = new FloatEvent();
        public FloatEvent ScreenShakeRequested { get {return _screenShakeRequested; } }

        NoArgEvent _onEnemyDestroyed = new NoArgEvent();
        public NoArgEvent OnEnemyDestroyed { get { return _onEnemyDestroyed; } }

        NoArgEvent _onPlayerDestroyed = new NoArgEvent();
        public NoArgEvent OnPlayerDestroyed { get { return _onPlayerDestroyed; } }

        NoArgEvent _levelComplete = new NoArgEvent();
        public NoArgEvent LevelComplete { get { return _levelComplete; } }

        NoArgEvent _onLevelWillReload = new NoArgEvent();
        public NoArgEvent OnLevelWillReload { get { return _onLevelWillReload; } }

        NoArgEvent _manualReloadLevel = new NoArgEvent();
        public NoArgEvent ManualReloadLevel { get { return _manualReloadLevel; } }
    }

}