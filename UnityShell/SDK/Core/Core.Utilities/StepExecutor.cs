using System.Collections.Generic;

namespace Core.Utilities
{
    public class StepExecutor : IStep
    {
        private List<IStep> _steps = new List<IStep>();

        public void Add(IStep step)
        {
            _steps.Add(step);
        }

        public void Remove(IStep step)
        {
            _steps.Remove(step);
        }
        public void Execute()
        {
            
        }

        public void Execute(List<IController> controllers, GlobalEnvironmentModel model, IEnvironmentView view)
        {
            foreach (var step in _steps)
            {
                step.Execute(controllers,model,view);
            }
        }
    }
}