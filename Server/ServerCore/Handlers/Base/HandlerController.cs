using Utilities;

namespace Server.ServerCore.Handlers.Base
{
    public class HandlerController : IController
    {
        private readonly ServerContext _context;
        private readonly HandlersModel _model;

        public HandlerController(ServerContext context, HandlersModel model)
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
        
        private void OnAdd(IExecuteHandler handler)
        {
            handler.Execute(_context);
        }
    }
}