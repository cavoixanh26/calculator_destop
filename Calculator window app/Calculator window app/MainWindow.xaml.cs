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
        private const string ErrorStringDivide = "xin chịu";

        double firstNumber;
        double secondNumber;
        string op = "";
        bool checkFirst;
        bool checkOperator;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void keyBoard_Loaded(object sender, RoutedEventArgs e)
        {
            result.Text = "0";
            checkFirst = true;
            SpuareRoot.Content = "\u00b2\u221Ax";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkFirst)
            {
                result.Clear();
            }

            checkFirst = false;
            Button btn = (Button)sender;
            result.Text += btn.Content.ToString();
            double.TryParse(result.Text,out secondNumber);
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (checkOperator)
            {
                double.TryParse(result.Text, out secondNumber);
            }
            else
            {
                double.TryParse(result.Text, out firstNumber);
            }

            double resultOperation;
            switch(op)
            {
                case "+":
                    result.Text = (firstNumber + secondNumber).ToString();
                    break;
                case "-":
                    result.Text = (firstNumber - secondNumber).ToString();
                    break;
                case "x":
                    result.Text = (firstNumber * secondNumber).ToString();
                    break;
                case "÷":
                    result.Text = secondNumber == 0
                        ? ErrorStringDivide
                        : (firstNumber / secondNumber).ToString();
                    DisableButton(false);
                    break;
                default:
                    result.Text = (secondNumber).ToString();
                    break;
            }

            if (checkFirst || op.IsNullOrEmpty())
            {
                operation.Text = $"{secondNumber}=";
            }
            else
            {
                operation.Text = $"{firstNumber} {op} {secondNumber}=";
            }
            checkOperator = false;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            checkOperator = true;
            double.TryParse(result.Text, out firstNumber);
            op = btn.Content.ToString();
            operation.Text = $"{result.Text} {op}";
            result.Clear();
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            operation.Clear();
            result.Text = "0";
            secondNumber = 0;
            firstNumber = 0;
            checkFirst = true;
            DisableButton(true);
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            if (result.Text.Length != 1) 
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1); 
            }
            else
            {
                result.Text = "0";
                
            }
        }

        private void negative_Click(object sender, RoutedEventArgs e)
        {
            if(secondNumber != 0 || !result.Text.Equals("0"))
            {
                secondNumber *= -1;
                result.Text = (double.Parse(result.Text)*-1).ToString();
            }
        }

        private void OneDevideX_Click(object sender, RoutedEventArgs e)
        {
            if (!result.Text.Equals("0"))
            {
                result.Text = (1/secondNumber).ToString();
                double.TryParse(result.Text, out secondNumber);
            } else
            {
                result.Text = ErrorStringDivide;
                DisableButton(false);
            }
        }

        private void DisableButton(bool status)
        {
            Negative.IsEnabled = status;
            Dot.IsEnabled = status;
            Plus.IsEnabled = status;
            Sub.IsEnabled = status;
            Mul.IsEnabled = status;
            Div.IsEnabled = status; 
            OneDevideX.IsEnabled = status;
            Spuare.IsEnabled = status;
        }

        private void Spuare_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(result.Text, out var res);
            operation.Text = $"sqr({res})";
            result.Text = (Math.Pow(res, 2)).ToString();
            double.TryParse(result.Text, out secondNumber);
        }

        private void SpuareRoot_Click(object sender, RoutedEventArgs e)
        {

            double.TryParse(result.Text, out var res);
            operation.Text = $"sqrt({res})";
            result.Text = (Math.Sqrt(res)).ToString();
            double.TryParse(result.Text, out secondNumber);
        }
    }
}
