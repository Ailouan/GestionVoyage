using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionVoyage
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtpass.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtid.Text=="admin" && txtpass.Text == "admin")
            {
                Menu m = new Menu();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username ou password incorect");
            }
        }
    }
}
