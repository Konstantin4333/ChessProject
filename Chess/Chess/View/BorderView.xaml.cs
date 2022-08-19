using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess.View
{
    /// <summary>
    /// Interaction logic for BorderView.xaml
    /// </summary>
    public partial class BorderView : UserControl
    {
        public BorderView()
        {
            InitializeComponent();
           // DeathZone.Content = new DeathZonePieces();
           
        }
        public bool IsOpened = true;
        private bool Ischecked = true;
        public UserControl ParentControl { get; set; }
      /*  private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsOpened)
            {
                DeathZone.Content = new DeathZonePieces();
                IsOpened = false;
            }
            else
            {
                //ParentControl.Children.Remove(this);
              //  DeathZonePieces.Children.Remove(this);
            }

        }*/

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Windows[0].Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeathZone.Content = new DeathZonePieces();
        }





        /* private void op_CheckedChanged(object sender, EventArgs e)
         {
             if (op.Checked)
             {

                 DeathZone.Visibility = Visibility.Visible;
                 Ischecked = false;
             }
             else
             {
                 DeathZone.Visibility = Visibility.Hidden;
                 Ischecked = true;
             }
         }*/
    }
}
