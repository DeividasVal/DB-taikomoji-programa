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

namespace DBlab
{
    public partial class Form3 : Form
    {
        string connetionString = "Data Source= localhost\\SQLEXPRESS; Database= ld3; Integrated Security=SSPI;";

        string selectedUzsakymas = "";
        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.Add("P");
            comboBox1.Items.Add("K");
            comboBox1.Items.Add("S");
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon2 = new SqlConnection(connetionString);

            sqlCon2.Open();
            SqlDataAdapter sqlDa2 = new SqlDataAdapter("SELECT UZSAKYMAS.UZSAKYMO_ID, KLIENTAS.KLIENTO_ID, UZSAKYMAS.NUOLAIDOS_ID, UZSAKYMAS.SIUNTIMAS, UZSAKYMAS.VISA_KAINA, UZSAKYMAS.SIUNTIMO_ADRESAS, UZSAKYMAS.DATA  FROM UZSAKYMAS, KLIENTAS WHERE UZSAKYMAS.KLIENTO_ID = '" + comboBox2.SelectedValue + "' AND KLIENTAS.KLIENTO_ID = '" + comboBox2.SelectedValue + "'", sqlCon2);
            DataTable dtbl2 = new DataTable();
            sqlDa2.Fill(dtbl2);

            dataGridView1.DataSource = dtbl2;
            sqlCon2.Close();


            dataGridView1.Columns["KLIENTO_ID"].Visible = false;
            dataGridView1.Columns["UZSAKYMO_ID"].Visible = false;
            dataGridView1.Columns["NUOLAIDOS_ID"].Visible = false;

            dataGridView1.Columns[3].HeaderText = "Siuntimo būdas";
            dataGridView1.Columns[4].HeaderText = "Visa užsakymo kaina";
            dataGridView1.Columns[5].HeaderText = "Siuntimo adresas";
            dataGridView1.Columns[6].HeaderText = "Užsakymo data";

            dataGridView1.Sort(this.dataGridView1.Columns["DATA"], ListSortDirection.Descending);
        }

        private void button1_Click(object sender, EventArgs e)
        {

                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandText = "INSERT INTO UZSAKYMAS (KLIENTO_ID, SIUNTIMAS, VISA_KAINA, SIUNTIMO_ADRESAS, DATA)" +
                "VALUES ('"+comboBox2.SelectedValue+"', '"+ comboBox1.GetItemText(this.comboBox1.SelectedItem) + "', '"+textBox1.Text+"', '"+textBox2.Text+"', '"+dateTimePicker1.Value+"')";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Sėkmingai įdėta.");
                } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (selectedUzsakymas != "")
            {
                if (comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "")
                {
                    using (SqlConnection sqlCon = new SqlConnection(connetionString))
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandText = "UPDATE UZSAKYMAS SET VISA_KAINA= '" + textBox1.Text + "', SIUNTIMO_ADRESAS= '" + textBox2.Text + "', SIUNTIMAS='" + comboBox1.GetItemText(this.comboBox1.SelectedItem) + "'," +
                            " DATA='" + dateTimePicker1.Value + "' WHERE UZSAKYMO_ID = '" + selectedUzsakymas + "'";
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                        MessageBox.Show("Sėkmingai atnaujinta.");
                    }
                }
                else
                {
                    MessageBox.Show("Laukai negali būti tušti!");
                }
            }
            else
            {
                MessageBox.Show("Pasirinkite užsakymą!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandText = "DELETE FROM UZSAKYMAS WHERE UZSAKYMO_ID = '" + selectedUzsakymas + "'";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Sėkmingai pašalinta.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                selectedUzsakymas = row.Cells["UZSAKYMO_ID"].Value.ToString();

                comboBox1.Text = "";
                comboBox1.SelectedText = row.Cells["SIUNTIMAS"].Value.ToString();
                textBox1.Text = row.Cells["VISA_KAINA"].Value.ToString();
                textBox2.Text = row.Cells["SIUNTIMO_ADRESAS"].Value.ToString();
                dateTimePicker1.Text = row.Cells["DATA"].Value.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
