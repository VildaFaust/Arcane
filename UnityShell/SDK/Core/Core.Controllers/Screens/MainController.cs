using Core.Models.Screens;
using Core.Utilities;
using Core.Views.Screens;

namespace Core.Controllers.Screens
{
    public class MainController : BaseScreenController<MainScreenModel,IMainScreenView>
    {
        public MainController(GlobalEnvironmentModel environment, MainScreenModel model, IMainScreenView view) : base(environment, model, view)
        {
        }
    }
}