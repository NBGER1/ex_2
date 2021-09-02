using DefaultNamespace.Gameplay;
using Notifications;
using UnityEngine;

namespace Services
{
    public class GameplayVfxManager
    {
        #region Constructors

        public GameplayVfxManager()
        {
            GameplayServices.EventBus.Subscribe(GameplayEventType.ProjectileHitCar, OnProjectileHitCar);
        }

        #endregion

        #region Methods

        private void OnProjectileHitCar(EventParams e)
        {
            var hitParams = e as ProjecitleHitCarEventParams;
            var explosion = GameplayElements.Instance.ExplosionFactory.Create(hitParams.HitPoint);
            Debug.Log("Car hit at = " + hitParams);
        }

        #endregion
    }
}