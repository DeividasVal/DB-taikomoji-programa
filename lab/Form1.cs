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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace DBlab
{
    public partial class Form1 : Form
    {
        Form2 darbuotojo_forma = new Form2();
        Form3 kliento_forma = new Form3();
        Form5 prekes_forma = new Form5();
        Form9 uzsakymo_forma = new Form9();

        String selectedDarbuotojas = "";
        String selectedPreke = "";
        String selectedUzsakymas = "";
        String selectedKlientas = "";

        DataTable dtbl = new DataTable();
        DataTable dtbl2 = new DataTable();
        DataTable dtbl3 = new DataTable();
        DataTable dtbl4 = new DataTable();

        string cmdstr = "select * from sys.tables";
        string connetionString = "Data Source= localhost\\SQLEXPRESS; Database= ld3; Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
            fillCombo();
        }

        private void fillCombo()
        {
            comboBox1.Items.Add("Klientas");
            comboBox1.Items.Add("Darbuotojas");
            comboBox1.Items.Add("Preke");
            comboBox1.Items.Add("Uzsakymas");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Klientas")
            {
                dtbl.Clear();
                label1.Text = comboBox1.Text + " lentelė";
                string selectedTable = comboBox1.Text;

                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM " + selectedTable, sqlCon);
                    sqlDa.Fill(dtbl);

                    advancedDataGridView1.DataSource = dtbl;
                }

                advancedDataGridView1.Columns["KLIENTO_ID"].Visible = false;
                advancedDataGridView1.Columns["SLAPTAZODIS"].Visible = false;
                advancedDataGridView1.Columns["KLIENTO_VARDAS"].DisplayIndex = 0;
                advancedDataGridView1.Columns["KLIENTO_PAVARDE"].DisplayIndex = 1;
                advancedDataGridView1.Columns["KLIENTO_TEL_NR"].DisplayIndex = 2;
                advancedDataGridView1.Columns["EL_PASTAS"].DisplayIndex = 3;
                advancedDataGridView1.Columns["PRISIJUNGIMO_VARDAS"].DisplayIndex = 4;

                advancedDataGridView1.Columns[1].HeaderText = "El. paštas";
                advancedDataGridView1.Columns[3].HeaderText = "Prisijungimo vardas";
                advancedDataGridView1.Columns[4].HeaderText = "Kliento vardas";
                advancedDataGridView1.Columns[5].HeaderText = "Kliento pavardė";
                advancedDataGridView1.Columns[6].HeaderText = "Telefono numeris";
            }
            else if (comboBox1.Text == "Darbuotojas")
            {
                dtbl2.Clear();
                label1.Text = comboBox1.Text + " lentelė";
                string selectedTable = comboBox1.Text;

                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM " + selectedTable, sqlCon);
                    sqlDa.Fill(dtbl2);

                    advancedDataGridView1.DataSource = dtbl2;
                }
                advancedDataGridView1.Columns["DARBUOTOJO_ID"].Visible = false;
                advancedDataGridView1.Columns["SANDELIO_ID"].Visible = false;
                advancedDataGridView1.Columns["DARB_VARDAS"].DisplayIndex = 0;
                advancedDataGridView1.Columns["DARB_PAVARDE"].DisplayIndex = 1;
                advancedDataGridView1.Columns["DARB_TEL_NR"].DisplayIndex = 2;

                advancedDataGridView1.Columns[0].HeaderText = "Asmens kodas";
                advancedDataGridView1.Columns[1].HeaderText = "Gimimo data";
                advancedDataGridView1.Columns[2].HeaderText = "Atlyginimas";
                advancedDataGridView1.Columns[3].HeaderText = "Darbuotojo vardas";
                advancedDataGridView1.Columns[4].HeaderText = "Darbuotojo pavardė";
                advancedDataGridView1.Columns[5].HeaderText = "Telefono numeris";
            }
            else if (comboBox1.Text == "Uzsakymas")
            {
                dtbl3.Clear();
                label1.Text = comboBox1.Text + " lentelė";
                string selectedTable = comboBox1.Text;

                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT KLIENTAS.KLIENTO_VARDAS, KLIENTAS.KLIENTO_PAVARDE, UZSAKYMAS.UZSAKYMO_ID, KLIENTAS.KLIENTO_ID, UZSAKYMAS.NUOLAIDOS_ID, UZSAKYMAS.SIUNTIMAS, UZSAKYMAS.VISA_KAINA, UZSAKYMAS.SIUNTIMO_ADRESAS, UZSAKYMAS.DATA  FROM UZSAKYMAS, KLIENTAS WHERE KLIENTAS.KLIENTO_ID = UZSAKYMAS.KLIENTO_ID", sqlCon);
                    sqlDa.Fill(dtbl3);

                    advancedDataGridView1.DataSource = dtbl3;
                }

                advancedDataGridView1.Columns["KLIENTO_ID"].Visible = false;
                advancedDataGridView1.Columns["UZSAKYMO_ID"].Visible = false;
                advancedDataGridView1.Columns["NUOLAIDOS_ID"].Visible = false;

                advancedDataGridView1.Columns[0].HeaderText = "Kliento vardas";
                advancedDataGridView1.Columns[1].HeaderText = "Kliento pavardė";
                advancedDataGridView1.Columns[5].HeaderText = "Siuntimo būdas";
                advancedDataGridView1.Columns[6].HeaderText = "Visa užsakymo kaina";
                advancedDataGridView1.Columns[7].HeaderText = "Siuntimo adresas";
                advancedDataGridView1.Columns[8].HeaderText = "Užsakymo data";

                advancedDataGridView1.Sort(this.advancedDataGridView1.Columns["DATA"], ListSortDirection.Descending);

            }
            else if (comboBox1.Text == "Preke")
            {
                dtbl4.Clear();
                label1.Text = comboBox1.Text + " lentelė";
                string selectedTable = comboBox1.Text;

                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM " + selectedTable, sqlCon);
                    sqlDa.Fill(dtbl4);

                    advancedDataGridView1.DataSource = dtbl4;
                }
                advancedDataGridView1.Columns["PREKES_ID"].Visible = false;
                advancedDataGridView1.Columns["SANDELIO_ID"].Visible = false;
                advancedDataGridView1.Columns["TIEKEJO_ID"].Visible = false;

                advancedDataGridView1.Columns["PREKES_PAV"].DisplayIndex = 0;
                advancedDataGridView1.Columns["PREKES_KAINA"].DisplayIndex = 1;
                advancedDataGridView1.Columns["PREKIU_KIEKIS"].DisplayIndex = 2;

                advancedDataGridView1.Columns[3].HeaderText = "Kaina";
                advancedDataGridView1.Columns[4].HeaderText = "Aprašymas";
                advancedDataGridView1.Columns[5].HeaderText = "Pavadinimas";
                advancedDataGridView1.Columns[6].HeaderText = "Kiekis";
            }
            else
            {
                MessageBox.Show("Pasirinkite objektą!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRowCount = advancedDataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);


            if (selectedRowCount == 1)
            {
                switch (comboBox1.Text)
                {
                    case "Darbuotojas":
                        darbuotojo_forma.Show();

                        using (SqlConnection sqlCon = new SqlConnection(connetionString))
                        {
                            sqlCon.Open();
                            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT CONCAT(DARB_VARDAS, ' ', DARB_PAVARDE) AS DARBUOTOJAS, DARBUOTOJO_ID FROM DARBUOTOJAS", sqlCon);
                            DataSet ds = new DataSet();

                            sqlDa.Fill(ds);
                            darbuotojo_forma.comboBox1.DataSource = ds.Tables[0];
                            darbuotojo_forma.comboBox1.DisplayMember = "DARBUOTOJAS";
                            darbuotojo_forma.comboBox1.ValueMember = "DARBUOTOJO_ID";
                            sqlCon.Close();
                        }

                        darbuotojo_forma.comboBox1.SelectedValue = selectedDarbuotojas;

                        break;
                    case "Klientas":
                        kliento_forma.Show();

                        using (SqlConnection sqlCon = new SqlConnection(connetionString))
                        {
                            sqlCon.Open();
                            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT CONCAT(KLIENTO_VARDAS, ' ', KLIENTO_PAVARDE) AS VARTOTOJAS, KLIENTO_ID FROM KLIENTAS", sqlCon);
                            DataSet ds = new DataSet();

                            sqlDa.Fill(ds);
                            kliento_forma.comboBox2.DataSource = ds.Tables[0];
                            kliento_forma.comboBox2.DisplayMember = "VARTOTOJAS";
                            kliento_forma.comboBox2.ValueMember = "KLIENTO_ID";
                            sqlCon.Close();
                        }

                        kliento_forma.comboBox2.SelectedValue = selectedKlientas;

                        break;
                    case "Preke":
                        prekes_forma.Show();

                        using (SqlConnection sqlCon = new SqlConnection(connetionString))
                        {
                            sqlCon.Open();
                            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT DISTINCT PREKES_PAV, min(prekes_id) as PREKES_ID FROM PREKE group by PREKES_PAV", sqlCon);
                            DataSet ds = new DataSet();

                            sqlDa.Fill(ds);
                            prekes_forma.comboBox1.DataSource = ds.Tables[0];
                            prekes_forma.comboBox1.DisplayMember = "PREKES_PAV";
                            prekes_forma.comboBox1.ValueMember = "PREKES_ID";
                            sqlCon.Close();
                        }

                        prekes_forma.comboBox1.SelectedValue = selectedPreke;

                        break;
                    case "Uzsakymas":
                        uzsakymo_forma.Show();

                        using (SqlConnection sqlCon = new SqlConnection(connetionString))
                        {
                            sqlCon.Open();
                            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT DATA, UZSAKYMO_ID FROM UZSAKYMAS", sqlCon);
                            DataSet ds = new DataSet();

                            sqlDa.Fill(ds);
                            uzsakymo_forma.comboBox1.DataSource = ds.Tables[0];
                            uzsakymo_forma.comboBox1.DisplayMember = "DATA";
                            uzsakymo_forma.comboBox1.ValueMember = "UZSAKYMO_ID";
                            sqlCon.Close();
                        }

                        uzsakymo_forma.comboBox1.SelectedValue = selectedUzsakymas;

                        break;
                    default:
                        MessageBox.Show("Error!");
                        break;
                }
            }
            else if (selectedRowCount > 1)
            {
                MessageBox.Show("Pasirinkite tik vieną įrašą! (eilutę)");
            }
            else
            {
                MessageBox.Show("Pasirinkite įrašą! (eilutę)");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ld3DataSet.DARBUOTOJAS' table. You can move, or remove it, as needed.
            this.dARBUOTOJASTableAdapter.Fill(this.ld3DataSet.DARBUOTOJAS);

        }

        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Darbuotojas":
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow row = this.advancedDataGridView1.Rows[e.RowIndex];

                        selectedDarbuotojas = row.Cells["DARBUOTOJO_ID"].Value.ToString();
                        
                    }
                    break;
                case "Klientas":
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow row = this.advancedDataGridView1.Rows[e.RowIndex];

                        selectedKlientas = row.Cells["KLIENTO_ID"].Value.ToString();
                    }
                    break;
                case "Preke":
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow row = this.advancedDataGridView1.Rows[e.RowIndex];

                        selectedPreke = row.Cells["PREKES_ID"].Value.ToString();
                    }
                    break;
                case "Uzsakymas":
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow row = this.advancedDataGridView1.Rows[e.RowIndex];

                        selectedUzsakymas = row.Cells["UZSAKYMO_ID"].Value.ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Uzsakymas")
            {
                report rpt = new report();
                rpt.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pasirinkite užsakymų sąrašą!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Darbuotojas")
            {
                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "DELETE FROM DARBUOTOJAS WHERE DARBUOTOJO_ID = '" + selectedDarbuotojas + "'";
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show("Sėkmingai pašalinta.");
                }
                selectedDarbuotojas = "";
            }
            else if (comboBox1.Text == "Klientas")
            {
                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "DELETE FROM KLIENTAS WHERE KLIENTO_ID = '" + selectedKlientas + "'";
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show("Sėkmingai pašalinta.");
                }
                selectedKlientas = "";
            }
            else if (comboBox1.Text == "Preke")
            {
                using (SqlConnection sqlCon = new SqlConnection(connetionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "DELETE FROM PREKE WHERE PREKES_ID = '" + selectedPreke + "'";
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show("Sėkmingai pašalinta.");
                }
                selectedPreke = "";
            }
            else if (comboBox1.Text == "Uzsakymas")
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
                selectedUzsakymas = "";
            }
            else
            {
                MessageBox.Show("Pasirinkite objektą!");
            }
        }

        private void advancedDataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            if (comboBox1.Text == "Klientas")
            {
                dtbl.DefaultView.Sort = advancedDataGridView1.SortString;
            }
            else if (comboBox1.Text == "Darbuotojas")
            {
                dtbl2.DefaultView.Sort = advancedDataGridView1.SortString;

            }
            else if (comboBox1.Text == "Preke")
            {
                dtbl4.DefaultView.Sort = advancedDataGridView1.SortString;

            }
            else
            {
                dtbl3.DefaultView.Sort = advancedDataGridView1.SortString;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
