using DefaultNamespace.Gameplay;
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
    }
}