using Core.Models.Screens;
using Core.Utilities;
using Core.Views.Screens;

namespace Core.Controllers.Screens
{
    public abstract class BaseScreenController<TModel,TView> : IController where TModel : IScreenModel where TView : IScreenView
    {
        private readonly GlobalEnvironmentModel _environment;
        private readonly TModel _model;
        private readonly TView _view;

        protected BaseScreenController(GlobalEnvironmentModel environment,TModel model,TView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }

        public void Attach()
        {
            _model.OnShow += Show;
            _model.OnHide += Hide;
        }

        public void Detach()
        {
            _model.OnShow -= Show;
            _model.OnHide -= Hide;
        }

        protected virtual void Hide()
        {
            _view.Hide();
        }

        protected virtual void Show()
        {
            _view.Show();
        }
    }
}