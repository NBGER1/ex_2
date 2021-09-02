﻿using Core;
using DefaultNamespace.Coroutine_Exercise;
using GameInput;
using Notifications;
using UnityEngine;

namespace Services
{
    public static class GameplayServices
    {
        #region Fields

        private static UnityCore _unityCore;
        private static EventBus _eb;
        private static GameplayVfxManager _gameplayVfxManager;
        private static IWaitService _waitService;

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

            _eb = new EventBus();
            _gameplayVfxManager = new GameplayVfxManager();
            _waitService = new WaitService();
        }

        #endregion

        #region Properties

        public static IUnityCoreService UnityCore
        {
            get { return _unityCore; }
        }

        public static ICoroutineService CoroutineService => _unityCore;
        public static EventBus EventBus => _eb;
        public static IWaitService WaitService => _waitService;

        #endregion
    }
}