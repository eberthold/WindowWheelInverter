namespace WiWheeIn.BusinessLogic.Framework
{
    public interface IMainThreadDispatcher
    {
        void InvokeOnMainThread(Action action);
    }
}
