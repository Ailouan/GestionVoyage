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
    public partial class Cancel : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter dap;
        DataSet ds = new DataSet();
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BGSI08N;Initial Catalog=GestionVoyage;Integrated Security=True");

        public Cancel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void replicombo()
        {
            cnx.Open();
            cmd.CommandText = "select * from Vol";
            cmd.Connection = cnx;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            cnx.Close();
        }

        public void replicombo1()
        {
            cnx.Open();
            cmd.CommandText = "select * from Ticket";
            cmd.Connection = cnx;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();
            cnx.Close();
        }
        
        private void Cancel_Load(object sender, EventArgs e)
        {
            replicombo();
            replicombo1();
            repligrid();
        }
        public void repligrid()
        {
            cnx.Open();
            dap = new SqlDataAdapter("select * from Annulation", cnx);
            dap.Fill(ds, "payment");
            dataGridView1.DataSource = ds.Tables["payment"];
            cnx.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd.CommandText = "insert into Annulation values ('"+textBox2.Text+ "','" + comboBox2.Text + "','"+comboBox1.Text+"','"+dateTimePicker1.Value+"')";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                MessageBox.Show("bien Annuler");
                repligrid();
            }
            catch
            {
                //MessageBox.Show("pas Annuler");
            }

        }
    }
}
