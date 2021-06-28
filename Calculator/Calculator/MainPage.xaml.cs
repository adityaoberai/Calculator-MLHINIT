using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double firstNumber, secondNumber;
        int state = 1;
        string calcOperator;
        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        private void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            state = 1;
            this.result.Text = "";
            calcOperator = "";
        }

        private void OnOperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            state++;

            if(state == 2)
            {
                calcOperator = button.Text;
                firstNumber = Convert.ToDouble(this.result.Text);
                this.result.Text = "";
            }
            else if(state == 3)
            {
                secondNumber = Convert.ToDouble(this.result.Text);
                this.CalculateValue(firstNumber,secondNumber,calcOperator);
            }
        }

        private void OnNumberClick(object sender, EventArgs e)
        {
            if(state == 3)
            {
                OnClear(this, null);
            }
            Button button = (Button)sender;
            this.result.Text += button.Text;
        }

        private void CalculateValue(double first, double second, string op)
        {
            switch(op)
            {
                case "+":
                    double sum = first + second;
                    this.result.Text = sum.ToString();
                    break;
                case "-":
                    double diff = first - second;
                    this.result.Text = diff.ToString();
                    break;
                case "X":
                    double product = first * second;
                    this.result.Text = product.ToString();
                    break;
                case "/":
                    double divide = first / second;
                    this.result.Text = divide.ToString();
                    break;
                default:
                    this.result.Text = "Error";
                    break;
            }

            firstNumber = 0;
            secondNumber = 0;
            state = 1;
        }
    }
}
