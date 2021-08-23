using System;
using DefaultNamespace.Gameplay;
using UnityEngine;

namespace Core
{
    public abstract class Singleton<T> : MonoBehaviour
    {
        private static T _instance;

        private void Awake()
        {
            _instance = GetInstance();
        }

        protected abstract T GetInstance();
        
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Have no instance yet");
                }

                return _instance;
            }
        }
    }
}