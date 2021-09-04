using System;
using Gameplay.Elements;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories
{
    public class BombFactory : ProjectileFactoryBase
    {
        #region Editor

        [SerializeField] private Object _projectilePrefabRef;

        #endregion

        #region Methods

        public override IProjectile Create(Vector3 atPosition)
        {
            var projectile = (GameObject) Instantiate(_projectilePrefabRef);
            var p = projectile.GetComponent<Bomb>();
            projectile.transform.position = atPosition;
            return p;
        }

        #endregion
    }
}