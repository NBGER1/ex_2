using UnityEngine;

namespace Factories
{
    public abstract class ExplosionFactoryBase : MonoBehaviour
    {
        public abstract GameObject Create(Vector3 atPoint);
    }
}