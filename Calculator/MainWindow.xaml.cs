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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private enum MathActionEnum
        {
            None,
            Plus,
            Minus,
            Multiply,
            Divide
        }

        private MathActionEnum MathAction;
        
        public MainWindow()
        {
            lastNumber = 0;
            result = 0;
            InitializeComponent();

        }
        
        #region Buttons
        private void AcButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
            lastNumber = 0;
            result = 0;
        }
        private void OneButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "1" : $"{ResultLabel.Content}1";
        }
        private void TwoButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "2" : $"{ResultLabel.Content}2";
        }
        private void ThreeButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "3" : $"{ResultLabel.Content}3";
        }
        private void FourButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "4" : $"{ResultLabel.Content}4";
        }
        private void FiveButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "5" : $"{ResultLabel.Content}5";
        }
        private void SixButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "6" : $"{ResultLabel.Content}6";
        }
        private void SevenButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "7" : $"{ResultLabel.Content}7";
        }
        private void EightButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "8" : $"{ResultLabel.Content}8";
        }
        private void NineButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "9" : $"{ResultLabel.Content}9";
        }
        private void ZeroButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? "0" : $"{ResultLabel.Content}0";
        }
        #endregion

        private void PlusMinusButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ResultLabel.Content = lastNumber.ToString();
            }
        }

        private void PercentButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                ResultLabel.Content = lastNumber.ToString();
            }
        }

        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            MathAction = MathActionEnum.Divide;
        }

        private void MultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            MathAction = MathActionEnum.Multiply;
        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            MathAction = MathActionEnum.Minus;
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            MathAction = MathActionEnum.Plus;
        }

        private void PeriodButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            var secondNumber = Convert.ToDouble(ResultLabel.Content);
            switch (MathAction)
            {
                case MathActionEnum.Plus:
                    ResultLabel. Content = lastNumber + secondNumber;
                    break;
                case MathActionEnum.Minus:
                    ResultLabel.Content = lastNumber - secondNumber;
                    break;
                case MathActionEnum.Multiply:
                    ResultLabel.Content = lastNumber * secondNumber;
                    break;
                case MathActionEnum.Divide:
                    if ((int)secondNumber != 0)
                        ResultLabel.Content = lastNumber / secondNumber;
                    else
                        ResultLabel.Content = "0";
                    break;
                default:
                    ResultLabel.Content = "0";
                    lastNumber = 0;
                    result = 0;
                    break;
            }
        }
    }
}
