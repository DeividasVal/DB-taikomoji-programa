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
    public partial class Form5 : Form
    {

        string connetionString = "Data Source= localhost\\SQLEXPRESS; Database= ld3; Integrated Security=SSPI;";

        string selectedTiekejas = "";
        string selectedSandelis = "";
        string kaina, aprasymas, pavadinimas, prekiu_kiekis, sandelio_id, tiekejo_id;
        public Form5()
        {
            InitializeComponent();
            comboBox2.Items.Add("DPD");
            comboBox2.Items.Add("Omniva");
            comboBox2.Items.Add("Lietuvos paštas");
            comboBox3.Items.Add("Dvarkiemo g. 4, Kaunas");
            comboBox3.Items.Add("Krokuvos g. 57, Vilnius");
            comboBox3.Items.Add("Testo g. 1, Kaunas");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                    SqlConnection sqlCon = new SqlConnection(connetionString);

                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT PREKES_KAINA, APRASYMAS, PREKES_PAV, PREKIU_KIEKIS FROM PREKE WHERE PREKES_ID = '" + comboBox1.SelectedValue + "'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);

                    sqlCon.Close();

                foreach (DataRow row in dtbl.Rows)
                {
                    kaina = row["PREKES_KAINA"].ToString();
                    aprasymas = row["APRASYMAS"].ToString();
                    pavadinimas = row["PREKES_PAV"].ToString();
                    prekiu_kiekis = row["PREKIU_KIEKIS"].ToString();
                }

                SqlConnection sqlCon2 = new SqlConnection(connetionString);

                sqlCon2.Open();
                SqlDataAdapter sqlD2 = new SqlDataAdapter("SELECT TIEKEJAS.TIEKEJO_ID, SANDELIS.SANDELIO_ID FROM SANDELIS, TIEKEJAS WHERE SANDELIS.ADRESAS= '" + comboBox3.GetItemText(this.comboBox3.SelectedItem) + "' AND TIEKEJAS.TIEKEJO_PAV = '" + comboBox2.GetItemText(this.comboBox2.SelectedItem) + "'", sqlCon2);
                DataTable dtbl2 = new DataTable();
                sqlD2.Fill(dtbl2);

                sqlCon2.Close();

                foreach (DataRow row in dtbl2.Rows)
                {
                    tiekejo_id = row["TIEKEJO_ID"].ToString();
                    sandelio_id = row["SANDELIO_ID"].ToString();
                }

                using (SqlConnection sqlCon3 = new SqlConnection(connetionString))
                {
                    sqlCon3.Open();
                    SqlCommand cmd1 = sqlCon3.CreateCommand();
                    cmd1.CommandText = "INSERT INTO PREKE VALUES('" + sandelio_id + "','" + tiekejo_id + "', '" + kaina + "', '" + aprasymas + "', '" + pavadinimas + "', '" + prekiu_kiekis + "')";
                    cmd1.ExecuteNonQuery();
                    sqlCon3.Close();
                    MessageBox.Show("Sėkmingai įdėta.");
                }

            }
            catch (SqlException error)
            {
                throw new Exception(error.Message, error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridView1.Rows.Count;

            if (rowCount >= 2)
            {
                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "DELETE FROM PREKE WHERE TIEKEJO_ID = '" + selectedTiekejas + "' AND SANDELIO_ID = '"+selectedSandelis+"'";
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show("Sėkmingai pašalinta.");
                }
            }
            else
            {
                MessageBox.Show("Prekė privalo turėti sandėlį!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandText = "UPDATE TIEKEJAS SET TIEKEJO_PAV= '"+comboBox2.GetItemText(this.comboBox1.SelectedItem) + "' WHERE TIEKEJO_ID = '"+selectedTiekejas+"'"; 
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandText = "UPDATE SANDELIS SET ADRESAS= '" + comboBox3.GetItemText(this.comboBox1.SelectedItem) + "' WHERE SANDELIO_ID = '" + selectedSandelis + "'";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Sėkmingai atnaujinta.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                selectedSandelis = row.Cells["SANDELIO_ID"].Value.ToString();
                selectedTiekejas = row.Cells["TIEKEJO_ID"].Value.ToString();


                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox2.SelectedText = row.Cells["TIEKEJO_PAV"].Value.ToString();
                comboBox3.SelectedText = row.Cells["ADRESAS"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connetionString);

            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select PREKE.PREKES_PAV, TIEKEJAS.TIEKEJO_ID, SANDELIS.SANDELIO_ID, SANDELIS.ADRESAS, TIEKEJAS.TIEKEJO_PAV FROM TIEKEJAS, SANDELIS, PREKE WHERE PREKE.PREKES_PAV = '"+ comboBox1.GetItemText(this.comboBox1.SelectedItem) + "' AND PREKE.TIEKEJO_ID = TIEKEJAS.TIEKEJO_ID AND SANDELIS.SANDELIO_ID = PREKE.SANDELIO_ID", sqlCon);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            dataGridView1.DataSource = dtbl;
            sqlCon.Close();


            dataGridView1.Columns["TIEKEJO_ID"].Visible = false;
            dataGridView1.Columns["SANDELIO_ID"].Visible = false;
            dataGridView1.Columns["PREKES_PAV"].Visible = false;

            dataGridView1.Columns[3].HeaderText = "Sandėlio adresas";
            dataGridView1.Columns[4].HeaderText = "Tiekėjo pavadinimas";
        }
    }
}
