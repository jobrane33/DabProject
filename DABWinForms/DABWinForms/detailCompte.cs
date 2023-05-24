using DABWinForms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DABWinForms
{
    public partial class detailCompte : Form
    {
        public detailCompte()
        {
            InitializeComponent();
            label5.Text = label5.Text + " " + Crud.userName;
            label2.Text = label2.Text + " " + Crud.cardNumber;
            label3.Text = label3.Text + " " + Crud.lastName;
            label4.Text = label4.Text + " " + Crud.balance;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
