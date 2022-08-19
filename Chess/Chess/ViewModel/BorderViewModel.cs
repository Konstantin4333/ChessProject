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
        /*private DelegateCommand _deathZone;
        public ICommand DeathZone
        {
            get
            {
                return _deathZone ?? ( _deathZone = new DelegateCommand(() =>
                {
                    System.Windows.Application.Current.Windows[0].Close();
                    UserControl userControl = new DeathZonePieces();

                   
                    *//* FillAutopartsList();
                     if (AllParts != null)
                     {
                         Window window = new SearchView();

                         window.Show();
                         System.Windows.Application.Current.Windows[0].Close();
                     }
                     else
                     {
                         MessageBox.Show("Грешни данни");
                     }*//*
                }));
            }
        }*/

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
