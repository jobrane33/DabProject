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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void openSildbenificiere(object Form)
        {
            if (this.childPanel.Controls.Count > 0)
            {

                this.childPanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.childPanel.Controls.Add(f);
            this.childPanel.Tag = f;
            f.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            openSildbenificiere(new GlobalBalance());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openSildbenificiere(new CheqeuAdmin());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openSildbenificiere(new BlockedCards());
        }
    }
}
