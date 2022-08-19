using Chess.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chess.ViewModel
{
    internal class BorderViewModel : ICommand
    {
        private DelegateCommand _closeApp;
        private DelegateCommand _minimize;
        private DelegateCommand _resize;
        public ICommand CloseApp
        {
            get
            {
                return _minimize ?? (_minimize = new DelegateCommand(() =>
                {
                       App.Current.Shutdown();
               }));
            }
        }
        public ICommand Minimize
        {
            get
            {
                return _closeApp ?? (_closeApp = new DelegateCommand(() =>
                {
                    App.Current.Windows[0].WindowState = WindowState.Minimized;
                }));
            }
        }
        public ICommand Resize
        {
            get
            {
                return _resize ?? (_resize = new DelegateCommand(() =>
                {
                    if (App.Current.Windows[0].WindowState == WindowState.Normal)
                    {
                       /* Window win = new MainWindow();
                        win.Close();*/
                        /*  App.Current.Shutdown();
                          // win.Show();
                          System.Windows.Application.Current.Windows[0].Close();
                          
                          App.Current.Windows[0].Show();*/
                        // transparency();

                       // App.Current.Windows[0].AllowsTransparency = false;
                        App.Current.Windows[0].WindowState = WindowState.Maximized;
                        
                    }
                    else
                    {
                        App.Current.Windows[0].WindowState = WindowState.Normal;
                    }
                    
                }));
            }
        }

        

        public ObservableCollection<FrameworkElement> UserControls { get; set; } = new ObservableCollection<FrameworkElement>();
        public void Execute(object? parameter)
        {
           // UserControls.Clear();
            switch (parameter?.ToString())
            {
                case "DeathZone":
                    UserControls.Add(GetUserControlInstance("DeathZone"));
                    break;
                
                default:
                    break;
            }
        }

        private FrameworkElement GetUserControlInstance(string v)
        {
            throw new NotImplementedException();
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

       
    }
}
