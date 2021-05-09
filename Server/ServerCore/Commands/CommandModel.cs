using System;
using Server.ServerCore.Commands.Base;

namespace Server.ServerCore.Commands
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