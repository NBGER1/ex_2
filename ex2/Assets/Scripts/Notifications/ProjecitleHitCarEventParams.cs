using UnityEngine;
namespace Notifications
{
    public class ProjecitleHitCarEventParams : EventParams
    {
        public ProjecitleHitCarEventParams(Vector3 hitPoint)
        {
            HitPoint = hitPoint;
        }
        
        public Vector3 HitPoint { private set; get; }
    }
}