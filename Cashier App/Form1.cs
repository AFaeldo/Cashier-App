using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cashier_App
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"Porksilog", 75 },
            {"Cornsilog", 60 },
            {"Tosilog", 70 },
            {"Mineral Water", 25 },
            {"Ice Tea", 40 },
            {"Juice", 35 }
        };
        double total = 0;

        private ErrorProvider errorProvider1 = new ErrorProvider(); //base on my research this is for error provider
        public Form1()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink; // avoids blinking icon

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            lblTotalAmount.Text = "₱0";
        }
       
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            btnCheckOut.BackColor = Color.LightGreen;

            btnCheckOut.Refresh();
            Application.DoEvents();

            Payment paymentForm = new Payment(total);
            paymentForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.IndianRed;

            btnCancel.Refresh();
            Application.DoEvents();

            Application.Exit();
        }


        private void ComputeSubtotal(string itemName, TextBox quantityBox, Label subtotalLabel)
        {
            // Validate input
            if (!int.TryParse(quantityBox.Text, out int qty) || qty < 0)
            {
                errorProvider1.SetError(quantityBox, "Please enter a valid positive number");
                subtotalLabel.Text = "Sub Total: ₱0";
            }
            else
            {
                errorProvider1.SetError(quantityBox, ""); // Clear previous error
                double price = prices[itemName];
                double subtotal = price * qty;
                subtotalLabel.Text = $"Sub Total: ₱{subtotal}";
            }

            // calling/call the UpdateTotal method to refresh the total amount
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            double newTotal = 0;

            //this is for the total amount in textboxupadate the total amount
            newTotal += GetItemTotal("Porksilog", txtQuantityPork);
            newTotal += GetItemTotal("Cornsilog", txtQuantityCorn);
            newTotal += GetItemTotal("Tosilog", txtQuantityTocino);
            newTotal += GetItemTotal("Mineral Water", txtQuantityWater);
            newTotal += GetItemTotal("Ice Tea", txtQuantityIceTea);
            newTotal += GetItemTotal("Juice", txtQuantityJuice);

            total = newTotal;
            lblTotalAmount.Text = $"₱{total}";
        }
        private double GetItemTotal(string itemName, TextBox quantityBox)
        {
            return int.TryParse(quantityBox.Text, out int qty) ? qty * prices[itemName] : 0;
        }

        private void txtQuantityCorn_TextChanged(object sender, EventArgs e)
        {
            ComputeSubtotal("Cornsilog", txtQuantityCorn, lblCornsilogSubTotal);
        }
        private void txtQuantityPork_TextChanged(object sender, EventArgs e)
        {
            ComputeSubtotal("Porksilog", txtQuantityPork, lblPorksilogSubTotal);
        }

        private void txtQuantityTocino_TextChanged(object sender, EventArgs e)
        {
            ComputeSubtotal("Tosilog", txtQuantityTocino, lblTosilogSubTotal);
        }

        private void txtQuantityWater_TextChanged(object sender, EventArgs e)
        {
            ComputeSubtotal("Mineral Water", txtQuantityWater, lblWaterSubTotal);
        }

        private void txtQuantityIceTea_TextChanged(object sender, EventArgs e)
        {
            ComputeSubtotal("Ice Tea", txtQuantityIceTea, lblIceTeaSubTotal);
        }

        private void txtQuantityJuice_TextChanged(object sender, EventArgs e)
        {
            ComputeSubtotal("Juice", txtQuantityJuice, lblJuiceSubTotal);
        }
    }
}
