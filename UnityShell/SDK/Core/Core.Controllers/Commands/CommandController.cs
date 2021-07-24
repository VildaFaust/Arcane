using Commands;
using Core.Controllers.Commands.Base;
using Core.Utilities;

namespace Core.Controllers.Commands
{
    public class CommandController : IController
    {
        private readonly GlobalEnvironmentModel _context;
        private readonly CommandModel _model;

        public CommandController(GlobalEnvironmentModel context, CommandModel model)
        {
            _context = context;
            _model = model;
        }

        public void Attach()
        {
            _model.Add += OnAdd;
        }

        public void Detach()
        {
            _model.Add -= OnAdd;
        }

        private void OnAdd(IExecuteCommand command)
        {
            command.Execute(_context);
        }
    }
}