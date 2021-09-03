using Gameplay.Elements;
using UnityEngine;

namespace Notifications
{
    public class RocketLaunchedEventParams : EventParams
    {
        public RocketLaunchedEventParams(string projectileName, Vector3 origin)
        {
            Origin = origin;
            ProjectileName = projectileName;
        }

        public Vector3 Origin { private set; get; }
        public string ProjectileName { private set; get; }
    }
}