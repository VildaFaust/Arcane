
using Commands.Base;
using Core.Utilities;

namespace Core.Controllers.Commands.Base
{
    public interface IExecuteCommand : ICommand
    { 
        void Execute(GlobalEnvironmentModel context);
    }
}