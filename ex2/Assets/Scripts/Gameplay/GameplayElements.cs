using Core;
using Gameplay.Elements;
using UnityEngine;

namespace DefaultNamespace.Gameplay
{
    public class GameplayElements : Singleton<GameplayElements>
    {
        [SerializeField]
        private Cannon _cannon;

        protected override GameplayElements GetInstance()
        {
            return this;
        }

        public Cannon Cannon => _cannon;
    }
}