using System;

namespace Services
{
    public interface IAwaiter
    {
        Awaiter OnStart(Action onStartCallback);
        Awaiter OnProgress(Action<float> onProgressCallback);
        Awaiter OnEnd(Action onEndCallback);
        void Start();
        void End();
        void Progress(float progress);
    }
}