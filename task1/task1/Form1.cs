using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Hangsam Nembang SDV SAC TASK 1
namespace task1
{
    public partial class Form1 : Form
    {
        public float cumuValue = 0f;
        public Form1()
        {
            InitializeComponent();
            
        }
        //End programme by clearing cumulative value
        private void button1_Click(object sender, EventArgs e)
        {
            cumuValue = 0f;
            lblCumValue.Text = "";
            lblValue.Text = "";


        }
        //calculates cumulative and singular value by taking age and purchased value as input. Accounts for non parseable values.
        public void calculateValue()
        {
            float depreciation, currentValue;
            if (float.TryParse(txtPrice.Text, out float purchasedValue) && float.TryParse(txtAge.Text, out float age))
            {
                depreciation = purchasedValue * 0.2f * age;
                if (depreciation > purchasedValue)
                {
                    lblValue.Text = "It is worth $0";
                }
                else
                {
                    currentValue = purchasedValue - depreciation;
                    lblValue.Text = "It is worth $" + currentValue;
                    cumuValue = cumuValue + currentValue;
                    lblCumValue.Text = "The collection so far is worth $" + cumuValue;
                }


            }
            else
            {
                lblValue.Text = "Error, please enter a valid number!";
            }

        }
       
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            calculateValue();
            
            txtAge.Clear();
            txtPrice.Clear();


        }
    }
}
