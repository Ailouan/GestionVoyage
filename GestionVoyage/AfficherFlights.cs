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
    public partial class AfficherFlights : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter dap = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BGSI08N;Initial Catalog=GestionVoyage;Integrated Security=True");
        public AfficherFlights()
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
            comboBox3.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        public void repligrid()
        {
            cnx.Open();
            dap = new SqlDataAdapter("select * from Vol", cnx);
            dap.Fill(ds, "payment");
            dataGridView1.DataSource = ds.Tables["payment"];
            cnx.Close();
        }

        public void replicombo()
        {
            cnx.Open();
            cmd.CommandText = "select * from Vol";
            cmd.Connection = cnx;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0]);
            }
            dr.Close();
            cnx.Close();
        }
        private void AfficherFlights_Load(object sender, EventArgs e)
        {
            repligrid();
            replicombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd.CommandText = "update Vol set Villedepart='" + comboBox1.Text + "',VilleArrivee='" + comboBox2.Text + "',Datee='" + dateTimePicker1.Value + "',Nbrplaces= '" + textBox2.Text + "' where Vcode='" + comboBox3.Text + "'";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                MessageBox.Show("bien modifier");
            }
            catch
            {
                MessageBox.Show("pas modifier");
            }
        }
        
    }
}
