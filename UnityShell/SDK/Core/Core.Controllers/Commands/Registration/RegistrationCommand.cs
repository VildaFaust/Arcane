using Commands.Base;
using Core.Utilities;

namespace Commands.Registration
{
    public class RegistrationCommand : ExecuteCommand
    {
        public RegistrationCommand(string firstName,string secondName,string email, string password) : base(nameof(RegistrationCommand))
        {
            UserParams.Add("name",firstName);
            UserParams.Add("secondName",secondName);
            UserParams.Add("email",email );
            UserParams.Add("password", password);
        }

        public override void Execute(GlobalEnvironmentModel context)
        {
            base.Execute(context);
            Send();
        }

        protected override void CallBack()
        {
            
        }
    }
}