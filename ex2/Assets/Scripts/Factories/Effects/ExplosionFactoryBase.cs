using UnityEngine;

namespace Factories
{
    public abstract class ExplosionFactoryBase : MonoBehaviour
    {
        #region Methods

        public abstract GameObject Create(Vector3 atPoint);

        #endregion
    }
}