using System;
using System.Collections.Generic;
using Core.Models.Screens;

namespace Core.Controllers.Screens
{
    public class ScreenObserver
    {
        private Dictionary<ScreenType, IScreenModel> _screenModels = new Dictionary<ScreenType, IScreenModel>();
        private IScreenModel _currentScreenModel;

        public void ChangeScreen(ScreenType type)  
        {
            if (_screenModels.ContainsKey(type))
            {
                ChangeCurrentScreen(_screenModels[type]);
            }
            else
            {
                IScreenModel model = null;
                switch (type)
                {
                    case ScreenType.Registration:
                        model = new RegistrationScreenModel();
                        break;

                    case ScreenType.Login:
                        model = new LoginScreenModel();
                        break;

                    case ScreenType.Main:
                        model = new MainScreenModel();
                        break;
                }

                _screenModels.Add(type, model);
            }
        }

        private void ChangeCurrentScreen(IScreenModel model)
        {
            _currentScreenModel.Hide();
            _currentScreenModel = model;
            _currentScreenModel.Show();
        }
    }
}