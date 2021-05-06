using System;
using ServerAspNetCoreLinux.ServerCore.Commands.Base;

namespace ServerAspNetCoreLinux.ServerCore.Commands
{
    public class CommandModel
    {
        public event Action<IExecuteCommand> Add;
        
        public void AddCommand(IExecuteCommand command)
        {
            Add?.Invoke(command);
        }
    }
}