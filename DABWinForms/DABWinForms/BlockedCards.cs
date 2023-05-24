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
    public partial class BlockedCards : Form
    {
        Crud crud = new Crud();
        public BlockedCards()
        {
            InitializeComponent();
            dataGridView1.DataSource = crud.getBlockedAccounts();
            
        }
    }
}
