using Core;
using UnityEngine;

namespace DefaultNamespace.Gameplay
{
    public class GameplayCore : IUpdatable
    {
        #region Editor

        #endregion

        #region Methods

        public void StartGame()
        {
            GameplayElements.Instance.Cannon.Init(
                GameplayElements.Instance.CannonParams,
                //# Leave only 1 factory uncommented

               GameplayElements.Instance.BombFactory
                //   GameplayElements.Instance.BulletFactory
                //GameplayElements.Instance.ProjectileFactory
            );
        }

        #endregion

        public void Update()
        {
        }
    }
}