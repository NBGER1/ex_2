using Core;
using GameInput;
using UnityEngine;

namespace Services
{
    public static class GameplayServices
    {
        #region Fields

        private static UnityCore _unityCore;

        #endregion

        #region Methods

        public static void Initialize()
        {
            var go = new GameObject("UnityCore");
            _unityCore = go.AddComponent<UnityCore>();

            var inputManager = new StandaloneInputManager();
            _unityCore.RegisterUpdatable(inputManager);
            _unityCore.RegisterOnEnableAware(inputManager);

            Object.DontDestroyOnLoad(go);
        }

        #endregion

        #region Properties

        public static IUnityCoreService UnityCore
        {
            get { return _unityCore; }
        }

        public static ICoroutineService CoroutineService => _unityCore;

        #endregion
    }
}