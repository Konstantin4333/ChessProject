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
    public partial class BorderView : Page
    {
        public BorderView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* Window window = new MainWindow();
             window.Close();*/
            System.Windows.Application.Current.Windows[0].Close();
        }
    }
}
