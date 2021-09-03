using UnityEngine;
namespace Notifications
{
    public class ProjectileHitCarEventParams : EventParams
    {
        public ProjectileHitCarEventParams(Vector3 hitPoint)
        {
            HitPoint = hitPoint;
        }
        
        public Vector3 HitPoint { private set; get; }
    }
}