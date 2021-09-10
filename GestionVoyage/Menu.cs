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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flights f = new Flights();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Passengers p = new Passengers();
            p.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tickets t = new Tickets();
            t.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cancel c = new Cancel();
            c.Show();
            this.Hide();
        }
    }
}
