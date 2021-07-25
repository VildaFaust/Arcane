using System;

namespace Core.Models.Screens
{
    public interface IScreenModel
    {
        event Action OnShow; 
        event Action OnHide; 
        
        void Show();
        void Hide();
    }
}