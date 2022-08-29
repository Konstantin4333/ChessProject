using Prism.Commands;
using System.Windows;

namespace Chess.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
       
     
        private MainViewModel homeVM;

        public DelegateCommand<string> NavigationCommand { get; private set; }

        
        private static void transparency()
        {
            if (App.Current.Windows[0].WindowState == WindowState.Normal)
            {
                App.Current.Windows[0].AllowsTransparency = true;
            }else if (App.Current.Windows[0].WindowState == WindowState.Maximized)
            {
                App.Current.Windows[0].AllowsTransparency = false;
            }
        }
    }
}
