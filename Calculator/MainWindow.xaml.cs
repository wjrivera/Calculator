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
        

        private SelectedOperator selectedOperator;
        
        public MainWindow()
        {
            lastNumber = 0;
            result = 0;
            InitializeComponent();

        }
        
        #region NumberButtons
        private void AcButtonClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
            lastNumber = 0;
            result = 0;
        }

        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            if (sender == ZeroButton)
                selectedValue = 0;
            if (sender == OneButton)
                selectedValue = 1;
            if (sender == TwoButton)
                selectedValue = 2;
            if (sender == ThreeButton)
                selectedValue = 3;
            if (sender == FourButton)
                selectedValue = 4;
            if (sender == FiveButton)
                selectedValue = 5;
            if (sender == SixButton)
                selectedValue = 6;
            if (sender == SevenButton)
                selectedValue = 7;
            if (sender == EightButton)
                selectedValue = 8;
            if (sender == NineButton)
                selectedValue = 9;

            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? $"{selectedValue}" : $"{ResultLabel.Content}{selectedValue}";
        }
        #endregion

        #region OperationButtons

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
                ResultLabel.Content = "0";

            if (sender == PlusButton)
                selectedOperator = SelectedOperator.Plus;
            if (sender == MinusButton)
                selectedOperator = SelectedOperator.Minus;
            if (sender == MultiplyButton)
                selectedOperator = SelectedOperator.Multiply;
            if (sender == DivideButton)
                selectedOperator = SelectedOperator.Divide;
        }

        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            selectedOperator = SelectedOperator.Divide;
        }

        private void MultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            selectedOperator = SelectedOperator.Multiply;
        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            selectedOperator = SelectedOperator.Minus;
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            lastNumber = Convert.ToDouble(ResultLabel.Content);
            ResultLabel.Content = "0";
            selectedOperator = SelectedOperator.Plus;
        }

        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Plus:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Minus:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiply:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Divide:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    default:
                        ResultLabel.Content = "0";
                        lastNumber = 0;
                        result = 0;
                        break;
                }

                ResultLabel.Content = result.ToString();
            }
        }

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

        private void PeriodButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ResultLabel.Content.ToString().Contains("."))
                ResultLabel.Content = $"{ResultLabel.Content}.";
        }

        #endregion


    }

    public enum SelectedOperator
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            var result = Math.Abs(n2) < 0.00001 ? 0 : n1 / n2;
            return result;
        }
    }
}
