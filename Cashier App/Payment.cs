using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier_App 
{
    public partial class Payment: Form
    {
        double TotalAmount;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public Payment(double total)
        {
            InitializeComponent();
            TotalAmount = total;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink; // avoids blinking icon
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPayment, "");

            if (string.IsNullOrWhiteSpace(txtPayment.Text))
            {
                errorProvider1.SetError(txtPayment, "Please enter a payment amount.");
                return;
            }

            if (!double.TryParse(txtPayment.Text, out double payment))
            {
                errorProvider1.SetError(txtPayment, "Invalid number. Please enter a valid payment.");
                return;
            }

            if (payment < TotalAmount)
            {
                errorProvider1.SetError(txtPayment, "Insufficient payment. Enter an amount equal to or greater than total.");
                return;
            }

            // Successful payment
            double change = payment - TotalAmount;
            txtChange.Text = $"₱{change:0.00}";
            MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            txtTotalAmount.Text = $"₱{TotalAmount}";

            txtTotalAmount.Text = $"₱{TotalAmount}";
        }
    }
}
