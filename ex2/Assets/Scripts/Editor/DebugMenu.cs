using DefaultNamespace.Gameplay;
using Notifications;
using Services;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Editor
{
    public static class DebugMenu
    {
        [MenuItem("Gamepleay/Debug Cannon Fire")]
        public static void DebugCannonFire()
        {
            if (!EditorApplication.isPlaying)
            {
                Debug.LogError("Enter playmode first");
                return;
            }

            GameplayElements.Instance.Cannon.Fire();
        }

        [MenuItem("Gamepleay/Debug Explosion Vfx")]
        public static void DebugExplosion()
        {
            if (!EditorApplication.isPlaying)
            {
                Debug.LogError("Enter playmode first");
                return;
            }

            var edp = GameObject.Find("DebugExplosionPosition");
            GameplayServices.EventBus.Publish(GameplayEventType.ProjectileHitCar,
                new ProjectileHitCarEventParams(edp.transform.position));
        }
    }
}