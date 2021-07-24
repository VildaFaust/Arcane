using System.Collections.Generic;
using Core.Controllers.Commands;
using Core.Utilities;

namespace Commands
{
    public class CommandStep : IStep
    {
        public void Execute(List<IController> controllerCollection, GlobalEnvironmentModel context, IEnvironmentView container)
        {
            var model = new CommandModel();
            var controller = new CommandController(context,model);
            controllerCollection.Add(controller);
        }
    }
}