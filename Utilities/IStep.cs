namespace Utilities
{
    public interface IStep<T> where T : IContext
    {
        void Execute(T context, ControllerCollection controllerCollection);
        void Clear(T context);
    }
}