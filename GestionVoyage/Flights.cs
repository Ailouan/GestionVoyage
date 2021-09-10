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
    public partial class Flights : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BGSI08N;Initial Catalog=GestionVoyage;Integrated Security=True");
        public Flights()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AfficherFlights f = new AfficherFlights();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd.CommandText = "insert into Vol values ('"+textBox1.Text+ "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Value + "','" + textBox2.Text + "')";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bien Ajoute");
            }
            catch
            {
                MessageBox.Show("Pas Ajoute");
            }
            cnx.Close();
        }

        private void Flights_Load(object sender, EventArgs e)
        {

        }
    }
    
}
