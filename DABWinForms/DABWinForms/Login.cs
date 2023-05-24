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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        Crud _crud = new Crud();
       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out var cardnumber) && int.TryParse(textBox2.Text, out var pin))
            {
                if (_crud.LogIn(cardnumber, pin) && Crud.fn != "admin")
                {
                    var home = new Form1();
                    Hide();
                    home.Show();
                    return;
                }
                else if(_crud.LogIn(cardnumber, pin) && Crud.fn == "admin")
                {
                    var home = new Form2();
                    Hide();
                    home.Show();
                    return;
                }



                //MessageBox.Show("erreur!", "wrong ping or number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("erreur!", "only numbers are accepted", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
