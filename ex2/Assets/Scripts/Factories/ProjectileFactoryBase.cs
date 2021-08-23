using UnityEngine;

namespace Factories
{
    public abstract class ProjectileFactoryBase : MonoBehaviour
    {
        #region Methods

        public abstract IProjectile Create(Vector3 atPosition);

        #endregion
    }
}