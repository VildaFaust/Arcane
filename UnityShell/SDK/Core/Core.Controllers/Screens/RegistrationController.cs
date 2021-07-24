using Core.Models.Screens;
using Core.Utilities;
using Core.Views.Screens;

namespace Core.Controllers.Screens
{
    public class RegistrationController : BaseScreenController<RegistrationScreenModel,IRegistrationScreenView>
    {
        public RegistrationController(GlobalEnvironmentModel environment, RegistrationScreenModel model, IRegistrationScreenView view) : base(environment, model, view)
        {
        }
    }
}