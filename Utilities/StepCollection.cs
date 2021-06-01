using System.Collections.Generic;

namespace Utilities
{
    public class StepCollection<T> : IStep<T> where T : IContext 
    {
        private List<IStep<T>> _steps = new List<IStep<T>>();

        public void Add(IStep<T> step)
        {
            _steps.Add(step);
        }
        
        public void Execute(T context, ControllerCollection controllerCollection)
        {
            foreach (var step in _steps)
            {
                step.Execute(context, controllerCollection);
            }
        }

        public void Clear(T context)
        {
            foreach (var step in _steps)
            {
                step.Clear(context);
            }
        }
    }
}