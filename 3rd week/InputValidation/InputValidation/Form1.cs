using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using InputValidation;

namespace InputValidation
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation.ValidName(txtName.Text))
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");

            if (Validation.ValidPhone(txtPhone.Text))
            {
                txtPhone.Text = Validation.ReformatPhone(txtPhone.Text);
            } else
            {
                MessageBox.Show("The phone number is not a valid US phone number");
            }
            if (!Validation.ValidEmail(txtEmail.Text))
                MessageBox.Show("The e-mail address is not valid.");

        }
    }
}
