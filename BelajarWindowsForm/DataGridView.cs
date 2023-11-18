using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BelajarWindowsForm
{
    public partial class DataGridView : Form
    {
        DataTable dtUsers = new DataTable();
        SqlDataAdapter adapter;

        public DataGridView()
        {
            InitializeComponent();
        }

        private void DataGridView_Load(object sender, EventArgs e)
        {
            Utils.initCon();
            Utils.open();

            SqlCommand command = new SqlCommand($"SELECT Name,Email,Country FROM Users", Utils.con);
            command.ExecuteNonQuery();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dtUsers);

            dataGridView1.DataSource = dtUsers;

            Utils.close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utils.open();

            SqlCommand command = new SqlCommand($"SELECT Name,Email,Country FROM Users", Utils.con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dtUsers);

            Utils.close();
        }
    }
}
