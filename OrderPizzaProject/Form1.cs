using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderPizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);
            else
                return Convert.ToSingle(rbLarge.Tag);
        }
        float GetToppingPrice()
        {
            float ToppingPrice = 0;

            if (chkCheese.Checked)
                ToppingPrice += Convert.ToSingle(chkCheese.Tag);
            
            if (chkMushrooms.Checked)
                ToppingPrice += Convert.ToSingle(chkMushrooms.Tag);
            
            if (chkOlives.Checked)
                ToppingPrice += Convert.ToSingle(chkOlives.Tag);
            
            if (chkOnion.Checked)
                ToppingPrice += Convert.ToSingle(chkOnion.Tag);
            
            if (chkPapers.Checked)
                ToppingPrice += Convert.ToSingle(chkPapers.Tag);
            
            if (chkTomatoes.Checked)
                ToppingPrice += Convert.ToSingle(chkTomatoes.Tag);

            return ToppingPrice;
        }
        float GetSelectedCrustPrice()
        {
            if (rbThinCrust.Checked)
                return Convert.ToSingle(rbThinCrust.Tag);
            else
                return Convert.ToSingle(rbThickCrust.Tag);
        }

        float CalculateTotalPrice()
        {
            return (GetSelectedSizePrice() + GetToppingPrice() + GetSelectedCrustPrice())
                * Convert.ToInt32(nudPizzaCounter.Value); //multiply by pizza count
        }
        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
                lblSize.Text = "Small";
            else if (rbMedium.Checked)
                lblSize.Text = "Medium";
            else if (rbLarge.Checked)
                lblSize.Text = "Large";

        }
        void UpdateCrust()
        {
            UpdateTotalPrice();

            if (rbThinCrust.Checked)
                lblCrustType.Text = "Thin Crust";
            else
                lblCrustType.Text = "Thick Crust";
        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sAllToppings = "";

            if (chkCheese.Checked)
                sAllToppings = chkCheese.Text + ", ";

            if (chkOnion.Checked)
                sAllToppings += chkOnion.Text + ", ";

            if (chkMushrooms.Checked)
                sAllToppings += chkMushrooms.Text + ", ";

            if (chkOlives.Checked)
                sAllToppings += chkOlives.Text + ", ";

            if (chkTomatoes.Checked)
                sAllToppings += chkTomatoes.Text + ", ";

            if (chkPapers.Checked)
                sAllToppings += chkPapers.Text + ", ";


            if (sAllToppings.EndsWith(", "))
                sAllToppings = sAllToppings.Substring(0, sAllToppings.Length - 2);//delete last ", "

            if (sAllToppings == "")
                sAllToppings = "No Toppings";

            lblToppings.Text = sAllToppings;
        }
        void UpdateWhereToEat()
        {
            if (rbEatIn.Checked)
                lblWhereToEat.Text = "Eat In";
            else
                lblWhereToEat.Text = "Take Out";
        }
        void UpdatePizzaCount()
        {
            UpdateTotalPrice();
            lblPizzaCount.Text = nudPizzaCounter.Value.ToString(); ;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order?", "Orderring...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Done Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnOrder.Enabled = false;
                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                nudPizzaCounter.Enabled = false;
            }
            
        }

        void ResetForm()
        {
            //reset groups
            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            
            
            //reset size
            rbMedium.Checked = true;

            //reset crust
            rbThinCrust.Checked = true;

            //reset toppings
            chkCheese.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkPapers.Checked = false;
            chkTomatoes.Checked = false;

            //reset where to eat
            rbEatIn.Checked = true;

            //reset order pizza form
            btnOrder.Enabled = true;

            //reset pizza count
            nudPizzaCounter.Value = 1;
            nudPizzaCounter.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }
        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void chkCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkPapers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }
        private void rbTakeout_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetForm(); //to add deafualt values and calculate them
        }

        private void nudPizzaCounter_ValueChanged(object sender, EventArgs e)
        {
            UpdatePizzaCount();
        }
    }
}
