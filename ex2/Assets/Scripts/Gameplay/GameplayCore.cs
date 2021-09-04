using Core;
using GUI;
using Notifications;
using Services;
using UnityEngine;

namespace DefaultNamespace.Gameplay
{
    public class GameplayCore : IUpdatable
    {
        #region Fields

        private int _rocketsLaunched = 0;

        #endregion

        #region Methods

        private void OnRocketLaunched(EventParams e)
        {
            UIManager.Instance.SetRocketsLaunchedText((++_rocketsLaunched).ToString());
        }

        public void StartGame()
        {
            UIManager.Instance.SetRocketsLaunchedText(_rocketsLaunched.ToString());
            GameplayServices.EventBus.Subscribe(GameplayEventType.RocketLaunched, OnRocketLaunched);
            GameplayElements.Instance.Cannon.Init(
                GameplayElements.Instance.CannonParams,
                //# Leave only 1 factory uncommented
                GameplayElements.Instance.BombFactory
                //GameplayElements.Instance.BulletFactory
                //GameplayElements.Instance.ProjectileFactory
            );
        }

        public void Update()
        {
        }

        #endregion

        #region Properties

        public int RocketsLaunched => _rocketsLaunched;

        #endregion
    }
}