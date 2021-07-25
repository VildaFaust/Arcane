using System;
using System.Collections.Generic;

namespace Core.Utilities
{
    public interface IStep
    {
        void Execute(List<IController> controllers,GlobalEnvironmentModel model,IEnvironmentView view );
    }
}