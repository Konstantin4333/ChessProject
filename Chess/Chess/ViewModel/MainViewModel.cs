using Chess.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chess.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
       
       
        public MainViewModel()
        {
            
           
        }

        private DeathZonePiecesViewModel otherVM;
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
