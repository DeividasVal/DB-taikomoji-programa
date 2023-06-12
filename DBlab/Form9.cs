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
    public partial class Form9 : Form
    {
        string connetionString = "Data Source= localhost\\SQLEXPRESS; Database= ld3; Integrated Security=SSPI;";
        string selectedNuolaida = "";
        string selectedUzsakymas = "";

        decimal kur;
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridView1.Rows.Count;

            if (rowCount <= 1)
            {
                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "INSERT INTO NUOLAIDOS_KODAI (PROCENTAS, NUOLAIDOS_KOD)" +
                    "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();

                    SqlCommand cmd1 = sqlCon.CreateCommand();
                    cmd1.CommandText = "select NUOLAIDOS_ID FROM NUOLAIDOS_KODAI WHERE NUOLAIDOS_KODAI.NUOLAIDOS_KOD = '" + textBox2.Text + "'";
                    SqlDataReader dr = cmd1.ExecuteReader();
                    dr.Read();
                    kur = dr.GetDecimal(0);
                    sqlCon.Close();
                }

                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "UPDATE UZSAKYMAS SET NUOLAIDOS_ID= '" + kur + "' WHERE UZSAKYMO_ID = '" + comboBox1.SelectedValue + "'";
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show("Sėkmingai įdėta.");
                }
            }
            else
            {
                MessageBox.Show("Užsakymas gali turėti tik vieną nuolaidą!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandText = "DELETE FROM NUOLAIDOS_KODAI WHERE NUOLAIDOS_ID = '" + selectedNuolaida + "'";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Sėkmingai pašalinta.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedNuolaida != "")
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                            using (SqlConnection sqlCon = new SqlConnection(connetionString))
                            {
                                sqlCon.Open();
                                SqlCommand cmd = sqlCon.CreateCommand();
                                cmd.CommandText = "UPDATE NUOLAIDOS_KODAI SET PROCENTAS= '" + textBox1.Text + "', NUOLAIDOS_KOD = '"+textBox2.Text+"' WHERE NUOLAIDOS_ID = '" + selectedNuolaida + "'";
                                cmd.ExecuteNonQuery();
                                sqlCon.Close();
                                MessageBox.Show("Sėkmingai atnaujinta.");
                            }
                }
                else
                {
                    MessageBox.Show("Negali būti tušti laukai!");
                }
            }
            else
            {
                MessageBox.Show("Pasirinkite nuolaidą!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon2 = new SqlConnection(connetionString);

            sqlCon2.Open();
            SqlDataAdapter sqlDa2 = new SqlDataAdapter("SELECT UZSAKYMAS.UZSAKYMO_ID, NUOLAIDOS_KODAI.NUOLAIDOS_ID, NUOLAIDOS_KODAI.PROCENTAS, NUOLAIDOS_KODAI.NUOLAIDOS_KOD FROM UZSAKYMAS, NUOLAIDOS_KODAI WHERE UZSAKYMAS.UZSAKYMO_ID = '"+comboBox1.SelectedValue+"' AND UZSAKYMAS.NUOLAIDOS_ID = NUOLAIDOS_KODAI.NUOLAIDOS_ID", sqlCon2);
            DataTable dtbl2 = new DataTable();
            sqlDa2.Fill(dtbl2);

            dataGridView1.DataSource = dtbl2;
            sqlCon2.Close();

            dataGridView1.Columns["UZSAKYMO_ID"].Visible = false;
            dataGridView1.Columns["NUOLAIDOS_ID"].Visible = false;

            dataGridView1.Columns[2].HeaderText = "Nuolaidos procentas";
            dataGridView1.Columns[3].HeaderText = "Nuolaidos kodo pavadinimas";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                selectedNuolaida = row.Cells["NUOLAIDOS_ID"].Value.ToString();
                selectedUzsakymas = row.Cells["UZSAKYMO_ID"].Value.ToString();

                textBox1.Clear();
                textBox2.Clear();
                textBox1.SelectedText = row.Cells["PROCENTAS"].Value.ToString();
                textBox2.Text = row.Cells["NUOLAIDOS_KOD"].Value.ToString();
            }
        }
    }
}
