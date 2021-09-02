using Factories;

namespace Gameplay.Elements
{
    public interface ICannon
    {
        void SetRotationForce(float force);

        void Fire();
        void Init(CannonParams cannonParams, ProjectileFactoryBase projectileFactory);
    }
}