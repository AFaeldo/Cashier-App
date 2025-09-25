using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cashier_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
