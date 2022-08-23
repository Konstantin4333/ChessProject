using Chess.Models;
using Chess.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private DelegateCommand _windowTest;
        private DelegateCommand _resetApp;
        private DelegateCommand _deathZone;


        private Board _board;
        private Square _square;
        bool isOpened = false;


      
        

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
      
       
        public ICommand ResetApp
        {
            get
            {
                return _resetApp ?? (_resetApp = new DelegateCommand(() =>
                {
                      var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
                    Process.Start(currentExecutablePath);
                    Application.Current.Shutdown();

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
        public ICommand WindowTest
        {
            get
            {
                return _windowTest ?? (_windowTest = new DelegateCommand(() =>
                {
                    /*App.Current.Windows[0].WindowState = WindowState.Minimized;*/
                    Window window = new WindowDeathZone();
                    
                   
                    if (!isOpened)
                    {
                        window.Show();
                        isOpened = true;
                    }
                    else
                    {
                        // App.Current.Windows[1].Close();
                        window.Hide();
                        isOpened = false;
                    }
                    
                }));
            }
        }
      
        public ICommand DeathZonecmd
        {
            get
            {
                return _deathZone ?? (_deathZone = new DelegateCommand(() =>
                {
                   UserControl userControl = new DeathZonePieces();
                    UserControls.Add(userControl);
                    userControl.BringIntoView();
                   
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
