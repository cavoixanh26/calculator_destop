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

namespace Calculator_window_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstNumber;
        double secondNumber;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void keyBoard_Loaded(object sender, RoutedEventArgs e)
        {
            result.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mul_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
