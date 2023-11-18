using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BelajarWindowsForm
{
    public partial class MainRegister : Form
    {
        public MainRegister()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPass.PasswordChar = '*';
            Utils.initCon();
        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }

            string pass = Encrypt.enc(txtPass.Text);

            Utils.open();

            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Users VALUES('{txtUser.Text}','{txtEmail.Text}','{pass}','{cbCountry.Text}')", Utils.con);

            int row = sqlCommand.ExecuteNonQuery();
            if (row >= 1)
            {
                MessageBox.Show("Registrasi berhasil", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainLogin login = new MainLogin();
                login.Show();
                this.Hide();
                return;
            }

            MessageBox.Show("Registrasi gagal,silahkan coba lagi", "Gagal !", MessageBoxButtons.OK, MessageBoxIcon.Error);


            Utils.close();
        }

        bool validate()
        {
            if (txtUser.TextLength < 1 || txtEmail.TextLength < 1 || txtPass.TextLength < 1 || cbCountry.Text.Length < 1)
            {
                MessageBox.Show("Semua input wajib di isi !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MainLogin mainLogin = new MainLogin();
            mainLogin.Show();
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
    }
}
