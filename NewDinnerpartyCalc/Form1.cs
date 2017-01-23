using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDinnerpartyCalc //Calculator for dinnerparty depended on guests, decor option and kind of drinks.
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;
        public Form1()
        {
            InitializeComponent();

            dinnerParty = new DinnerParty();
            DisplayCost();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //change the total cost every time you check or uncheck the healthy box
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DisplayCost();
        }

        //change the total cost every time you check or uncheck the fancy box
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DisplayCost();
        }

        // change the total cost every time you change the number of quests
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) 
        {
            DisplayCost();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayCost() // check all properties and display the totalcost
        {
            dinnerParty.GuestsOfPartyCost((int)numericUpDown1.Value);
            dinnerParty.CostOfDecors(checkBox1.Checked, (int)numericUpDown1.Value);
            dinnerParty.CostOfDrinks(checkBox2.Checked, (int)numericUpDown1.Value);
            textBox1.Text = dinnerParty.TotalCostOfParty(checkBox2.Checked, (int)numericUpDown1.Value).ToString("c");
        }
    }

    public class DinnerParty
    {
        private int numberOfPeople;
        private decimal DrinksCost;
        private decimal FancyDecorsCosts;
        private decimal TotalCost;
        private int  GuestsCost;

        
        public int GuestsOfPartyCost(int People) //calculate the cost for the quests
        {
            numberOfPeople = People;
            GuestsCost = numberOfPeople * 25;

            return GuestsCost;

        }
        public decimal CostOfDecors(bool Fancy,int People) //calculate the cost of decors
        {
            numberOfPeople = People;
            if (Fancy)
            {
                FancyDecorsCosts = (numberOfPeople * 15) + 50;
                return FancyDecorsCosts;
            }
            else
            {
                FancyDecorsCosts = (numberOfPeople * 7.5m) + 30;
                return FancyDecorsCosts;
            }
        }

        public decimal CostOfDrinks (bool Healthy , int People)//calculate the cost of the drinks 
        {
            numberOfPeople = People;
            if (Healthy)
            {
                DrinksCost = numberOfPeople * 5;
                return DrinksCost;
            }
            else
            {
                DrinksCost = numberOfPeople * 20;
                return DrinksCost;
            }
        }

        public decimal TotalCostOfParty(bool Healthy, int People) // calculate the cost for all  the party
        {
            numberOfPeople = People;
            if (Healthy)
            {
                TotalCost = (GuestsCost+ FancyDecorsCosts + DrinksCost) * 0.95m;
                return TotalCost;
            }
            else
            {
                TotalCost = (GuestsCost + FancyDecorsCosts + DrinksCost);
                return TotalCost;
            }

        }

    }
}
