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
    public partial class AfficherPass : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dap = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BGSI08N;Initial Catalog=GestionVoyage;Integrated Security=True");

        public AfficherPass()
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
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void repligrid()
        {
            cnx.Open();
            dap = new SqlDataAdapter("select * from Passengers", cnx);
            dap.Fill(ds, "payment");
            dataGridView1.DataSource = ds.Tables["payment"];
            cnx.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AfficherPass_Load(object sender, EventArgs e)
        {
            repligrid();
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
                cmd.CommandText = "update Passengers set Nom='"+textBox1.Text+"',Passeport='"+textBox2.Text+"',Adresse='"+textBox3.Text+"',Nationalite='"+textBox2.Text+"',Sexe='"+comboBox2.Text+"',Tele='"+comboBox1.Text+"' where Id='" + textBox5.Text + "'";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                repligrid();
                MessageBox.Show("bien modifier");
            }
            catch
            {
                MessageBox.Show("pas modifier");
            }
            cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd.CommandText = "delete Passengers where Id='" + textBox5.Text + "'";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                repligrid();
                MessageBox.Show("bien supprimer");
            }
            catch
            {
                MessageBox.Show("non supprimer");
            }
            cnx.Close();
        }
    }
}
