using UnityEngine;

namespace Factories
{
    public interface IProjectile
    {
        void Launch(Quaternion launchRotation);
    }
}