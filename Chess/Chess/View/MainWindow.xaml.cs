using System.Windows;
using System.Windows.Input;

namespace Chess.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
        
          Rows.Content = new RowsAndColumns();
          
          

        }

        private static void Vis()
        {
            if (App.Current.Windows[0].WindowState == WindowState.Normal)
            {
                
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}
