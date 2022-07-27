using Microsoft.UI.Dispatching;
using System;
using WiWheeIn.BusinessLogic.Framework;

namespace WiWheeIn.WinUI.Framework
{
    public class MainThreadDispatcher : IMainThreadDispatcher
    {
        public void InvokeOnMainThread(Action action)
        {
            var dispatcher = DispatcherQueue.GetForCurrentThread();

            if (dispatcher.HasThreadAccess)
            {
                action();
                return;
            }

            dispatcher.TryEnqueue(() => { action(); });
        }
    }
}
