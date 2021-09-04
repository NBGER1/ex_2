using Gameplay.Elements;
using UnityEngine;

namespace Notifications
{
    public class RocketLaunchedEventParams : EventParams
    {
        #region Constructors

        public RocketLaunchedEventParams(string projectileName, Vector3 origin)
        {
            Origin = origin;
            ProjectileName = projectileName;
        }

        #endregion

        #region Properties

        public Vector3 Origin { private set; get; }
        public string ProjectileName { private set; get; }

        #endregion
    }
}