using System.Windows;
using System.Windows.Controls;

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
