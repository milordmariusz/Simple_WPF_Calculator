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
        char iOp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
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
            Button b = (Button)sender;
            if (result != 0)
            {
                equal.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, equal));
                enter_value = true;
                operation = b.Content.ToString();
                history.Text = result.ToString() + " " + operation;
            }
            else
            {
                equal.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, equal));
                operation = b.Content.ToString();
                result = Double.Parse(tb.Text);
                enter_value = true;
                history.Text = result.ToString() + " " + operation;
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "0";
            history.Text = "";
            result = 0;
            operation = "";
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            history.Text = "";
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
                    tb.Text = (result / Double.Parse(tb.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(tb.Text);
            operation = "";
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
            result = result + (Double.Parse(tb.Text)* Double.Parse(tb.Text));
            tb.Text = result.ToString();
            history.Text = result.ToString();
        }

        private void rev_Click(object sender, RoutedEventArgs e)
        {
            result = (1 / Double.Parse(tb.Text));
            if (result > 1)
            {
                tb.Text = Math.Round(result).ToString();
                result = Double.Parse(tb.Text);
                history.Text = Math.Round(result).ToString();
            }
            else
            {
                tb.Text = result.ToString();
                result = Double.Parse(tb.Text);
                history.Text = result.ToString();
            }

            //tb.Text = (1/ Double.Parse(tb.Text)).ToString();
            //result = Double.Parse(tb.Text);
            //history.Text = result.ToString();
        }
    }
}
