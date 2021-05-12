using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorNew
{
    public partial class FormCalculator : Form
    {
        public FormCalculator()
        {
            InitializeComponent();
        }

        double resultValue = 0;
        string operation = "";
        bool isOperationPerformed = false;
        double memory=0;
        private void FormCalculator_Load(object sender, EventArgs e)
        {

        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            if (isOperationPerformed || resultTextBox.Text=="0")
            {
                resultTextBox.Clear();
            }
            isOperationPerformed = false;
            Button btn = (Button)sender;
            resultTextBox.Text = resultTextBox.Text + btn.Text;
        }
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (isOperationPerformed)
            {
                resultTextBox.Text="0";
            }
            isOperationPerformed = false;
            Button btn = (Button)sender;
            if(!resultTextBox.Text.Contains(","))
            resultTextBox.Text = resultTextBox.Text + btn.Text;
        }
        private void btnOperation_Click(object sender, EventArgs e)
        {
             if (isOperationPerformed)
            {
                resultTextBox.Clear();
            }
           Button btn = (Button)sender; 
            if(resultValue != 0)
            {
                btnResult.PerformClick();
                operation = btn.Text;
                isOperationPerformed = true;
                resultValue = Double.Parse(resultTextBox.Text);
            }
            else
            {
                operation = btn.Text;
                resultValue = Double.Parse(resultTextBox.Text);
                isOperationPerformed = true;
            } 
        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = Math.Sqrt(double.Parse(resultTextBox.Text)).ToString();
        }
       
        private void btnResult_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    resultTextBox.Text = (resultValue + double.Parse(resultTextBox.Text)).ToString();
                        break;
                case "-":
                    resultTextBox.Text = (resultValue - double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "*":
                    resultTextBox.Text = (resultValue * double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "/":
                    resultTextBox.Text = (resultValue / double.Parse(resultTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = 0;
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            memory += double.Parse(resultTextBox.Text);
        }

        private void buttonMMinus_Click(object sender, EventArgs e)
        {
            memory -= double.Parse(resultTextBox.Text);
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = memory.ToString();
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            memory = double.Parse(resultTextBox.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            resultValue = 0;
        }


    }
}
