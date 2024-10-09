using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace DB_Act1_046_Agcanas
{
    public partial class frmMain : Form
    {
        string connectionStr = "server=localhost; database=db_act1; uid=root; pwd=uslt; port=3306";
        MySqlConnection conn;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            conn = new MySqlConnection(connectionStr);
            string query = "select * from car where model like '%" + txtKeyword.Text + "%' and brand like '%" + cboBrand.Text + "%'";
            conn.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
            dataAdapter.Fill(dt);
            conn.Close();
            dtgrResults.DataSource = dt;
            dtgrResults.Columns["ID"].Visible = false;
            dtgrResults.Columns[1].HeaderText = "Model";
            dtgrResults.Columns[2].HeaderText = "Brand";
            dtgrResults.Columns[3].HeaderText = "Year";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboBrand.SelectedIndex = -1;
            dtgrResults.DataSource = null;
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            conn = new MySqlConnection(connectionStr);
            string query = "select * from car where model like '%" + txtKeyword.Text + "%' and brand like '%" + cboBrand.Text + "%'";
            conn.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
            dataAdapter.Fill(dt);
            conn.Close();
            dtgrResults.DataSource = dt;
            dtgrResults.Columns["ID"].Visible = false;
            dtgrResults.Columns[1].HeaderText = "Model";
            dtgrResults.Columns[2].HeaderText = "Brand";
            dtgrResults.Columns[3].HeaderText = "Year";
        }
    }
}
