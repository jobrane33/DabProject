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
    public partial class CheqeuAdmin : Form
    {
        public CheqeuAdmin()
        {
            InitializeComponent();
        }

        private void CheqeuAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dABDataSet.cheque' table. You can move, or remove it, as needed.
            this.chequeTableAdapter.Fill(this.dABDataSet.cheque);

        }
    }
}
