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

namespace simpcal
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result = 0;
        String operation = "";
        bool enter_value = false;
        bool changing_operation = false;
        string previous_operator = "";
        bool cleaning_number = false;

        bool equal_spam = false;
        double first_digit;
        double second_digit;
        string prev_operator = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            changing_operation = false;
            equal_spam = false;
            Button b = (Button)sender;

            if (cleaning_number)
            {
                tb.Text = "";
                changing_operation = false;
                equal_spam = false;
                cleaning_number = false;
            }
            if ((tb.Text == "0") || (enter_value))
            {
                tb.Text = "";
            }
            enter_value = false;

            if (b.Content.ToString() == ",")
            {
                if (!tb.Text.Contains(","))
                {
                    tb.Text = tb.Text + b.Content.ToString();
                }
            }
            else
            {
                tb.Text = tb.Text + b.Content.ToString();
            }
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            equal_spam = false;
            Button b = (Button)sender;
            if (!changing_operation)
            {
                if (result != 0)
                {
                    equal.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, equal));
                    enter_value = true;
                    operation = b.Content.ToString();
                    previous_operator = operation;
                    history.Text = result.ToString() + " " + operation;
                    changing_operation = true;
                }
                else
                {
                    //equal.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, equal));
                    operation = b.Content.ToString();
                    previous_operator = operation;
                    result = Double.Parse(tb.Text);
                    enter_value = true;
                    history.Text = result.ToString() + " " + operation;
                    changing_operation = true;
                }
            }
            else
            {
                if(previous_operator != b.Content.ToString())
                {
                    operation = b.Content.ToString();
                    history.Text = history.Text.Remove(history.Text.Length-1) + operation;
                }
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "0";
            history.Text = "";
            result = 0;
            operation = "";
            changing_operation = false;
            equal_spam = false;
            cleaning_number = false;
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            history.Text = "";
            first_digit = result;
            if (!equal_spam)
            {
                second_digit = Double.Parse(tb.Text);
                prev_operator = operation;
                switch (operation)
                {
                    case "+":
                        tb.Text = (result + Double.Parse(tb.Text)).ToString();
                        break;
                    case "-":
                        tb.Text = (result - Double.Parse(tb.Text)).ToString();
                        break;
                    case "*":
                        tb.Text = (result * Double.Parse(tb.Text)).ToString();
                        break;
                    case "/":
                        if (Double.Parse(tb.Text) == 0)
                        {
                            tb.Text = "0";
                        }
                        else
                        {
                            tb.Text = (result / Double.Parse(tb.Text)).ToString();
                        }
                        break;
                    default:
                        break;
                }
                result = Double.Parse(tb.Text);
                operation = "";
                equal_spam = true;
                cleaning_number = true;
            }
            else
            {
                switch (prev_operator)
                {
                    case "+":
                        tb.Text = (first_digit + second_digit).ToString();
                        break;
                    case "-":
                        tb.Text = (first_digit - second_digit).ToString();
                        break;
                    case "*":
                        tb.Text = (first_digit * second_digit).ToString();
                        break;
                    case "/":
                        if (Double.Parse(tb.Text) == 0)
                        {
                            tb.Text = "0";
                        }
                        else
                        {
                            tb.Text = (result / Double.Parse(tb.Text)).ToString();
                        }
                        break;
                    default:
                        break;
                }
                result = Double.Parse(tb.Text);
                operation = "";
            }
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if(tb.Text.Length > 0)
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1, 1);
            }

            if (tb.Text == "")
            {
                tb.Text = "0";
            }
        }

        private void plmin_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = (-1*Double.Parse(tb.Text)).ToString();
        }

        private void Sq_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = (Double.Parse(tb.Text) * Double.Parse(tb.Text)).ToString();
            equal.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, equal));
            result = Double.Parse(tb.Text);
            enter_value = true;
            history.Text = result.ToString() + " " + operation;
        }

        private void rev_Click(object sender, RoutedEventArgs e)
        {
            result = (1 / Double.Parse(tb.Text));
            if (-1 < result && result < 1)
            {
                tb.Text = result.ToString();
                result = Double.Parse(tb.Text);
                history.Text = result.ToString();
            }
            else
            {
                tb.Text = Math.Round(result).ToString();
                result = Double.Parse(tb.Text);
                history.Text = Math.Round(result).ToString();
            }
        }
    }
}
