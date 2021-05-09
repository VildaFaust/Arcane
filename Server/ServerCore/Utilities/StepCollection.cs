using System.Collections.Generic;

namespace Server.ServerCore.Utilities
{
    public class StepCollection : IStep
    {
        private List<IStep> _steps = new List<IStep>();

        public void Add(IStep step)
        {
            _steps.Add(step);
        }
        
        public void Execute(ServerContext context, ControllerCollection controllerCollection)
        {
            foreach (var step in _steps)
            {
                step.Execute(context, controllerCollection);
            }
        }

        public void Clear(ServerContext context)
        {
            foreach (var step in _steps)
            {
                step.Clear(context);
            }
        }
    }
}