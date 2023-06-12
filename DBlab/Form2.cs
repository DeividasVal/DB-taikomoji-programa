using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBlab
{
    public partial class Form2 : Form
    {
        string connetionString = "Data Source= localhost\\SQLEXPRESS; Database= ld3; Integrated Security=SSPI;";
        string selectedPreke = "";

        public Form2()
        {
            InitializeComponent();
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT PREKES_PAV, PREKES_ID FROM PREKE", sqlCon);
                DataSet ds = new DataSet();

                sqlDa.Fill(ds);
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.DisplayMember = "PREKES_PAV";
                comboBox2.ValueMember = "PREKES_ID";
                sqlCon.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon3 = new SqlConnection(connetionString))
            {
                sqlCon3.Open();
                SqlCommand cmd1 = sqlCon3.CreateCommand();
                cmd1.CommandText = "INSERT INTO TVARKO VALUES('" + comboBox1.SelectedValue+ "','" + comboBox2.SelectedValue + "')";
                cmd1.ExecuteNonQuery();
                sqlCon3.Close();
                MessageBox.Show("Sėkmingai įdėta.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedPreke != "")
            {
                    using (SqlConnection sqlCon = new SqlConnection(connetionString))
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandText = "UPDATE PREKE SET PREKES_PAV= '" + comboBox2.GetItemText(this.comboBox2.SelectedItem) + "', PREKES_KAINA= '" + textBox3.Text + "', PREKIU_KIEKIS='" + textBox2.Text + "', APRASYMAS='" + textBox4.Text + "' WHERE PREKES_ID= '" + selectedPreke + "'";
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                        MessageBox.Show("Sėkmingai atnaujinta.");
                }
                
            }
            else
            {
                MessageBox.Show("Pasirinkite prekę!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection sqlCon2 = new SqlConnection(connetionString);

            sqlCon2.Open();
            SqlDataAdapter sqlDa2 = new SqlDataAdapter("select tvarko.PREKES_ID, TVARKO.DARBUOTOJO_ID, PREKE.PREKES_KAINA, PREKE.PREKES_PAV, PREKE.PREKIU_KIEKIS, PREKE.APRASYMAS FROM PREKE, DARBUOTOJAS, TVARKO WHERE PREKE.PREKES_ID = TVARKO.PREKES_ID AND TVARKO.DARBUOTOJO_ID = '"+comboBox1.SelectedValue+"' AND DARBUOTOJAS.DARBUOTOJO_ID = '"+comboBox1.SelectedValue+"'", sqlCon2);
            DataTable dtbl2 = new DataTable();
            sqlDa2.Fill(dtbl2);

            dataGridView1.DataSource = dtbl2;
            sqlCon2.Close();


            dataGridView1.Columns["PREKES_ID"].Visible = false;
            dataGridView1.Columns["DARBUOTOJO_ID"].Visible = false;

            dataGridView1.Columns["PREKES_PAV"].DisplayIndex = 0;
            dataGridView1.Columns["PREKES_KAINA"].DisplayIndex = 1;
            dataGridView1.Columns["PREKIU_KIEKIS"].DisplayIndex =2;
            dataGridView1.Columns["APRASYMAS"].DisplayIndex = 3;


            dataGridView1.Columns[2].HeaderText = "Prekės kaina";
            dataGridView1.Columns[3].HeaderText = "Prekės pavadinimas";
            dataGridView1.Columns[4].HeaderText = "Kiekis";
            dataGridView1.Columns[5].HeaderText = "Aprašymas";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                selectedPreke = row.Cells["PREKES_ID"].Value.ToString();

                comboBox2.Text = "";
                comboBox2.SelectedText = row.Cells["PREKES_PAV"].Value.ToString();
                textBox2.Text = row.Cells["PREKIU_KIEKIS"].Value.ToString();
                textBox3.Text = row.Cells["PREKES_KAINA"].Value.ToString();
                textBox4.Text = row.Cells["APRASYMAS"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandText = "DELETE FROM TVARKO WHERE PREKES_ID = '" + selectedPreke + "'";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Sėkmingai pašalinta.");
            }
        }
    }
}
