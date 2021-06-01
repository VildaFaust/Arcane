using System;

namespace Server.ServerCore.Handlers.Base
{
    public class HandlersModel
    {
        public event Action<IExecuteHandler> Add;
        
        public void AddCommand(IExecuteHandler handler)
        {
            Add?.Invoke(handler);
        }
    }
}