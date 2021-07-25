using Core.Models.Screens;
using Core.Utilities;
using Core.Views.Screens;

namespace Core.Controllers.Screens
{
    public class LoginController : BaseScreenController<LoginScreenModel,ILoginScreenView>
    {
        public LoginController(GlobalEnvironmentModel environment, LoginScreenModel model, ILoginScreenView view) : base(environment, model, view)
        {
        }
    }
}