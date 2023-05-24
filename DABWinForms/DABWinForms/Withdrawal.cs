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
    public partial class Withdrawal : Form
    {
        Crud _crud = new Crud();
        public Withdrawal()
        {
            InitializeComponent();
            label2.Text = label2.Text + " " + Crud.cardNumber;
            numericUpDown1.Maximum = decimal.MaxValue;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_crud.setValueAfterWithdrawl(Crud.cardNumber, numericUpDown1.Value))
            {
                MessageBox.Show("done your new ballance is  " + Crud.balance, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("can't withdraw " + numericUpDown1.Value, "NO funds in you account for a " + numericUpDown1.Value+ " withrawl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
