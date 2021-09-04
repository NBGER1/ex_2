using UnityEngine;

namespace Notifications
{
    public class ProjectileHitCarEventParams : EventParams
    {
        #region Constructors

        public ProjectileHitCarEventParams(Vector3 hitPoint)
        {
            HitPoint = hitPoint;
        }

        #endregion

        #region Properties

        public Vector3 HitPoint { private set; get; }

        #endregion
    }
}