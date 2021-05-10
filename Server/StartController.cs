using Microsoft.AspNetCore.Http;
using Server.ServerCore;
using Server.ServerCore.Databases.Connect;
using Server.ServerCore.Utilities;

namespace Server
{
    public class StartController : IController
    {
        private readonly ServerContext _context;
        private ControllerCollection _controllerCollection = new ControllerCollection();
        private StepCollection _stepCollection = new StepCollection();
        private HttpContext _httpContext;

        public StartController(ServerContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;
            _stepCollection.Add(new DatabaseConnectionStep());
            _stepCollection.Add(new DatabaseCollectionDataStep());
        }

        public void Activate()
        {
            _stepCollection.Execute(_context, _controllerCollection);
            
            // var user = new User()
            // {
            //     Email = "timofey@gmail.com",
            //     Login = "timasha1",
            //     Password = "12345",
            //     Name = "Tima"
            // };
            // _context.Data.UserCollection.AddNewUser(user);
        }

        public void Deactivate()
        {
            _stepCollection.Clear(_context);
        }
    }
}