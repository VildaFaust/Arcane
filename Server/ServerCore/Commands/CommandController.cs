using ServerAspNetCoreLinux.ServerCore.Commands.Base;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux.ServerCore.Commands
{
    public class CommandController : IController
    {
        private readonly ServerContext _context;
        private readonly CommandModel _model;

        public CommandController(ServerContext context, CommandModel model)
        {
            _context = context;
            _model = model;
        }
        
        public void Activate()
        {
            _model.Add += OnAdd;
        }
     
        public void Deactivate()
        {
            _model.Add -= OnAdd;
        }
        
        private void OnAdd(IExecuteCommand command)
        {
            command.Execute(_context);
        }
    }
}