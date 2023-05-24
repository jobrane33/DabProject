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
    public partial class cheque : Form
    {
        Crud _crud = new Crud();
        public cheque()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(amount.Text, out var amoutInt) && int.TryParse(number.Text, out var numberInt)) {
                if(_crud.setValueForcheque(numberInt, amoutInt, bankName.Text))
                {
                    MessageBox.Show("Done added chque with " + amount.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("error adding cheque","error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
