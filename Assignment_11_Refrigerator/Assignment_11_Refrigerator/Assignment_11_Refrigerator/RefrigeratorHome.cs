using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment_11_Refrigerator;
using Exception = System.Exception;

namespace Assignment_10_Vehicle
{
    public partial class RefrigeratorHome : Form
    {
        public RefrigeratorHome()
        {
            InitializeComponent();
        }
        Refrigerator refrigerator=new Refrigerator();
        //List<double> cws=new List<double>();
        List<int> itemList=new List<int>();
        List<double> wpuList=new List<double>();
        List<double> cwList=new List<double>();
        List<double> maxWeightList=new List<double>();
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                refrigerator.WeightTotal = Convert.ToDouble(textBoxMaximumWeight.Text);
                maxWeightList.Add(refrigerator.WeightTotal);
                textBoxMaximumWeight.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                refrigerator.Item = Convert.ToInt32(textBoxNoOfItems.Text);
                refrigerator.WeightUnit = Convert.ToDouble(textBoxWeightPerUnit.Text);
                itemList.Add(refrigerator.Item);
                wpuList.Add(refrigerator.WeightUnit);
                cwList.Add(refrigerator.Item*refrigerator.WeightUnit);
                textBoxNoOfItems.Clear();
                textBoxWeightPerUnit.Clear();
               // refrigerator.CurrentWeight();
                //cws.Add(refrigerator.CurrentWeight());
                if (refrigerator.WeightTotal < refrigerator.CurrentWeight() )
                {
                    textBoxCurrentWeight.Clear();
                    textBoxRemainingWeight.Clear();
                    MessageBox.Show("Overflow!");
                }
                else
                {
                    textBoxCurrentWeight.Text = Convert.ToString(refrigerator.CwList());
                    textBoxRemainingWeight.Text = Convert.ToString(refrigerator.RemainingWeight());
                    string see = " ";
                    for(int i=itemList.Count()-1;i<itemList.Count();i++)
                    {
                        see +="\nItem: " + itemList[i]+"\n";
                        see += "WeightPerUnit: " + wpuList[i] + "\n";
                        see += "Weight: " + cwList[i] + "\n";
                        see += "TotalItem: " + itemList.Sum() + "\n";
                        see += "TotalWeightUnit: " + wpuList.Sum() + "\n";
                        see += "TotalWeight: " + refrigerator.CwList() + "\n";
                        see +="MaximumWeight: "+maxWeightList.Sum() + "\n";
                    }
            
                    richTextBoxRefrigerator.Text+=see;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}