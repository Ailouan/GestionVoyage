using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionVoyage
{
    public partial class Passengers : Form
    {
        public Passengers()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BGSI08N;Initial Catalog=GestionVoyage;Integrated Security=True");
        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AfficherPass f = new AfficherPass();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd.CommandText = "insert into Passengers values(" + textBox5.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "')";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bien Ajoute");
            }
            catch
            {
                MessageBox.Show("Pas Ajoute");
            }
        }

        private void Passengers_Load(object sender, EventArgs e)
        {

        }
    }
}
