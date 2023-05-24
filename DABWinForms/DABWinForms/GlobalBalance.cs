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
    public partial class GlobalBalance : Form
    {
        private Crud _crud = new Crud();
        public GlobalBalance()
        {
            InitializeComponent();
            label1.Text = label1.Text + " " + _crud.getGlobalBalence();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_crud.setGlobalAmount(numericUpDown1.Value))
            {
                MessageBox.Show("done your  ballance is updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                label1.Text = "The DAB is updated :" + " " + _crud.getGlobalBalence();
                return;
            }
            MessageBox.Show("problem", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
