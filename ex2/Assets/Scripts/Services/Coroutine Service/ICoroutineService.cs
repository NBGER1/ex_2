using System;
using System.Collections;
using UnityEngine;

namespace Core
{
    public interface ICoroutineService
    {
        Coroutine RunCoroutine(IEnumerator coroutineBody);
        public void EndCoroutine(Coroutine coroutine);
    }
}