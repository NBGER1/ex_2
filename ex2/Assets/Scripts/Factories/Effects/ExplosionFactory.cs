using UnityEngine;

namespace Factories
{
    public class ExplosionFactory : ExplosionFactoryBase
    {
        #region Editor

        [SerializeField] private Object _explosionPrefabRef;

        #endregion

        #region Methods

        public override GameObject Create(Vector3 atPoint)
        {
            var explosionInstance = (GameObject) Instantiate(_explosionPrefabRef, atPoint, Quaternion.identity);
            return explosionInstance;
        }

        #endregion
    }
}