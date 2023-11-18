using BelajarWindowsForm.Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BelajarWindowsForm
{
    public partial class MainLogin : Form
    {
        public MainLogin()
        {
            InitializeComponent();
        }

        private void MainLogin_Load(object sender, EventArgs e)
        {
            Utils.initCon();
            txtPass.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }

            Utils.open();

            string pass = Encrypt.enc(txtPass.Text);

            SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE Name='{txtUser.Text}' AND Password='{pass}'", Utils.con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                UserModel.id = reader.GetInt32(0);
                UserModel.name = reader.GetString(1);
                UserModel.email = reader.GetString(2);
                UserModel.pass = reader.GetString(3);
                UserModel.country = reader.GetString(4);

                MainDashboard main = new MainDashboard();
                main.Show();
                this.Hide();
                return;
            }

            MessageBox.Show("User tidak di temukan", "Gagal !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Utils.close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MainRegister mainRegister = new MainRegister();
            mainRegister.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        bool validate()
        {
            if (txtPass.TextLength < 1 || txtUser.TextLength < 1)
            {
                MessageBox.Show("Semua input wajib di isi !", "Gagal !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
