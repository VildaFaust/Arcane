namespace Core.Utilities
{
    public abstract class BaseEnvironmentModel
    {
        protected readonly GlobalEnvironmentModel Model;

        protected BaseEnvironmentModel(GlobalEnvironmentModel model)
        {
            Model = model;
        }
    }
}