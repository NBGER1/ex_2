using UnityEngine;

namespace Factories
{
    public class ExplosionFactory : ExplosionFactoryBase
    {
       [SerializeField] private Object _explosionPrefabRef;

        public override GameObject Create(Vector3 atPoint)
        {
            var explosionInstance = (GameObject) Instantiate(_explosionPrefabRef, atPoint, Quaternion.identity);
            return explosionInstance;
        }
    }
}