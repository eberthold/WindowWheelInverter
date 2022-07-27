using System;
using System.Windows;
using WiWheeIn.BusinessLogic.Framework;

namespace WiWheeIn.WPF.Framework
{
    public class MainThreadDispatcher : IMainThreadDispatcher
    {
        public void InvokeOnMainThread(Action action)
        {
            var dispatcher = Application.Current.Dispatcher;

            if (dispatcher.CheckAccess())
            {
                action();
                return;
            }

            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
