using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Hangsam Nembang Year 12 SAC 1 TASK 2
namespace task2
{
    public partial class Form1 : Form
    {
        List<string> lines = new List<string>();
        double _totalProfit = 0;
        public Form1()
        {
            InitializeComponent();
            BindingSource bs = new BindingSource();
            
            

            

        }
        //Inputs an array of string and creates a header out of the first line of the CSV file.
        public void setHeader(string[] _headers)
        {
            int counter = 0;
            dataGridView2.ColumnCount = _headers.Length + 1;
            for (int i = 0; i < _headers.Length; i++)
            {
                dataGridView2.Columns[i].HeaderText = _headers[i];
                counter = i + 1;

            }
            dataGridView2.Columns[counter].HeaderText = "Profit";

        }

        //Takes CSV files as input, splits the CSV file text by commas and assigns it to appropriate variables. Outputs profit and prints csv file into datagrid
        public void readCSV()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                double profit, purchasePrice;
                string salePrice;
                

                string filepath = openFileDialog.FileName;
                List<string> tempList = new List<string>();
                String[] headers = File.ReadAllLines(filepath).First().Split(',').ToArray();
                setHeader(headers);
                lines = File.ReadAllLines(filepath).Skip(1).ToList();
                foreach (var line in lines)
                {
                    tempList = line.Split(',').ToList();
                    purchasePrice = double.Parse(tempList[4]);
                    salePrice = tempList[5];
                    if(salePrice == "NA")
                    {
                        profit = purchasePrice * -1;
                    }
                    else
                    {
                        profit = double.Parse(salePrice) - purchasePrice;
                    }
                    tempList.Add(profit.ToString());
                    dataGridView2.Rows.Add(tempList.ToArray());
                    _totalProfit = _totalProfit + profit;






                }

                dataGridView2.Rows.Add("", "", "", "", "", "Total Profit", "$" + _totalProfit.ToString());

            }

            

           

        }


        private void btnU_Click(object sender, EventArgs e)
        {
            readCSV();
        }
    }
}
