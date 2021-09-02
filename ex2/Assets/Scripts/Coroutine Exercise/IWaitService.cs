using System;
using Services;

namespace DefaultNamespace.Coroutine_Exercise
{
    public interface IWaitService
    {
        Awaiter WaitFor(int delaySeconds);
    }
}