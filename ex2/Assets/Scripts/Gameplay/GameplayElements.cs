using Core;
using Factories;
using Gameplay.Elements;
using UnityEngine;

namespace DefaultNamespace.Gameplay
{
    public class GameplayElements : Singleton<GameplayElements>
    {
        #region Editor

        [SerializeField] private Cannon _cannon;
        [SerializeField] private ProjectileFactoryBase _projectileFactory;
        [SerializeField] private ProjectileFactoryBase _bombFactory;
        [SerializeField] private ProjectileFactoryBase _bulletFactory;
        [SerializeField] private ExplosionFactoryBase _explosionFactoryBase;
        [SerializeField] private CannonParams _cannonParams;

        #endregion

        #region Methods

        protected override GameplayElements GetInstance()
        {
            return this;
        }

        #endregion

        #region Properties

        public Cannon Cannon => _cannon;
        public ProjectileFactoryBase ProjectileFactory => _projectileFactory;
        public ProjectileFactoryBase BombFactory => _bombFactory;
        public ProjectileFactoryBase BulletFactory => _bulletFactory;
        public ExplosionFactoryBase ExplosionFactory => _explosionFactoryBase;
        public CannonParams CannonParams => _cannonParams;

        #endregion
    }
}