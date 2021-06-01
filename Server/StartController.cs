using Server.ServerCore.Databases.Connect;
using Server.ServerCore.Services.Utilities;
using Utilities;

namespace Server
{
    public class StartController : IController
    {
        private readonly ServerContext _context;
        private ControllerCollection _controllerCollection = new ControllerCollection();
        private StepCollection<ServerContext> _stepCollection = new StepCollection<ServerContext>();

        public StartController(ServerContext context)
        {
            _context = context;
            _stepCollection.Add(new DatabaseConnectionStep());
            _stepCollection.Add(new DatabaseCollectionDataStep());
            _stepCollection.Add(new ServicesCreateStep());
        }

        public void Activate()
        {
            _stepCollection.Execute(_context, _controllerCollection);
        }

        public void Deactivate()
        {
            _stepCollection.Clear(_context);
        }            
    }
}