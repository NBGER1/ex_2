using DefaultNamespace;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class UIManager : Singleton<UIManager>
    {
        #region Editor

        [SerializeField] private TextMeshProUGUI _rocketsLaunchedText;

        #endregion

        #region Methods

        public void SetRocketsLaunchedText(string text)
        {
            _rocketsLaunchedText.text = text;
        }

        protected override UIManager GetInstance()
        {
            return this;
        }

        #endregion
    }
}