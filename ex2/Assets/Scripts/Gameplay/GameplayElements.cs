using Core;
using Factories;
using Gameplay.Elements;
using UnityEngine;

namespace DefaultNamespace.Gameplay
{
    public class GameplayElements : Singleton<GameplayElements>
    {
        [SerializeField] private Cannon _cannon;
        [SerializeField] private ProjectileFactoryBase _projectileFactory;
        [SerializeField] private ProjectileFactoryBase _bombFactory;
        [SerializeField] private ExplosionFactoryBase _explosionFactoryBase;

        protected override GameplayElements GetInstance()
        {
            return this;
        }

        public Cannon Cannon => _cannon;
        public ProjectileFactoryBase ProjectileFactory => _projectileFactory;
        public ProjectileFactoryBase BombFactory => _bombFactory;

        public ExplosionFactoryBase ExplosionFactory => _explosionFactoryBase;
    }
}