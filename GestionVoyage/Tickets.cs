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
    
    public partial class Tickets : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter dap;
        DataSet ds = new DataSet();
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BGSI08N;Initial Catalog=GestionVoyage;Integrated Security=True");

        public Tickets()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd.CommandText = "insert into Ticket values('" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + txtcode.Text + "','" + textBox1.Text + "','" + textBox4.Text + "')";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                MessageBox.Show("bien ajoute");
            }
            catch
            {
                MessageBox.Show("id jeja exist");
            }


        }

        public void replicombo2()
        {
            cnx.Open();
            cmd.CommandText = "select * from Passengers";
            cmd.Connection = cnx;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();
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
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            cnx.Close();
        }

        public void repligrid()
        {
            cnx.Open();
            dap = new SqlDataAdapter("select * from Vol", cnx);
            dap.Fill(ds, "payment");
            dataGridView1.DataSource = ds.Tables["payment"];
            cnx.Close();
        }
        private void Tickets_Load(object sender, EventArgs e)
        {
            replicombo();
            replicombo2();
            repligrid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                string id = comboBox2.SelectedItem.ToString();

                cnx.Open();
                cmd = new SqlCommand("select * from Passengers where id ='" + id + "'", cnx);
                dr = cmd.ExecuteReader();

                DataTable d = new DataTable();
                d.Load(dr);

                textBox3.Text = d.Rows[0][1].ToString();
                textBox1.Text = d.Rows[0][4].ToString();
                txtcode.Text = d.Rows[0][2].ToString();

                dr.Close();
                cnx.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }
    }
}
