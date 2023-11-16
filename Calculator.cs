using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Calculator
{
    public partial class Calculator : Form
    {

        char decimalSeperator;
        double numOne = 0;
        double numTwo = 0;
        string operation;

        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            decimalSeperator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            this.BackColor = Color.Blue;
            Display.Text = "0";
            Display.TabStop = false;

            string buttonName = null;
            Button button = null;
            for(int i = 0; i < 10; i ++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if(!Display.Text.Contains("."))
            {
                if(Display.Text == string.Empty)
                {
                    Display.Text += "0." + decimalSeperator;
                }
                else
                {
                    Display.Text += decimalSeperator;
                }
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                if ((s.Contains("-")) && (s.Length == 2))
                {
                    s = "0";
                }
                else
                {
                    s = s.Substring(0, (s.Length - 1));
                }
            }
            else
            {
                s = "0";
            }

            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
         try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = number.ToString("F99").TrimEnd('0');
            }
            catch
            {

            }
        }


        private void buttonResult_Click(object sender, EventArgs e)
        {
            numTwo = Convert.ToDouble(Display.Text);
            Display.Text = (numOne + numTwo).ToString();
            if(operation == "+")
            {
                Display.Text = (numOne + numTwo).ToString();
            }
            else if(operation == "-")
            {
                Display.Text = (numOne - numTwo).ToString();
            }
            else if(operation == "*")
            {
                Display.Text = (numOne * numTwo).ToString();
            }
            else if(operation == "/")
            {
                Display.Text = (numOne / numTwo).ToString();
            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
            operation = button.Text;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
