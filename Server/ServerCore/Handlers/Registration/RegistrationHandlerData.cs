using Server.ServerCore.Handlers.Base;

namespace Server.ServerCore.Handlers.Registration
{
    public class RegistrationHandlerData : HandlerData
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}