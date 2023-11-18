using BelajarWindowsForm.Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BelajarWindowsForm
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            Utils.initCon();
            textBox1.Text = UserModel.name;
            textBox2.Text = UserModel.email;
            comboBox1.Text = UserModel.country;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Utils.open();

            SqlCommand command = new SqlCommand($"UPDATE Users SET Name='{textBox1.Text}',Email='{textBox2.Text}',Country='{comboBox1.Text}' WHERE ID='{UserModel.id}'", Utils.con);

            int row = command.ExecuteNonQuery();

            if (row >= 1)
            {
                MessageBox.Show("Data akun berhasil di perbarui !", "Berhasil !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Utils.close();
                return;
            }

            MessageBox.Show("Terjadi kesalahan saat mengupdate akun,silahkan coba lagi", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Apakahan anda yakin ingin menghapus akun anda ?", "Peringatan !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Utils.open();

                SqlCommand command = new SqlCommand($"DELETE FROM Users WHERE ID='{UserModel.id}'", Utils.con);
                int row = command.ExecuteNonQuery();

                if (row >= 1)
                {
                    DialogResult dr2 = MessageBox.Show("Akun anda berhasil di hapus !", "Berhasil !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dr2 == DialogResult.OK)
                    {
                        MainLogin mainlogin = new MainLogin();
                        mainlogin.Show();
                        this.Hide();

                    }
                }

                Utils.close();
            }
        }
    }
}
