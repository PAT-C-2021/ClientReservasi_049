using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceReservasi;
using System.ServiceModel;

namespace ClientReservasi_20160140049
{
    public partial class Register : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Register()
        {
            InitializeComponent();
            TampilData();

            comboBoxKategori.Items.Add("Admin");
            comboBoxKategori.Items.Add("Resepsionis");

            textBoxID.Visible = false;
            btDelete.Enabled = false;
            btUpdate.Enabled = false;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string kategori = comboBoxKategori.Text;
            string a = service.Register(username, password, kategori);

            if(textBoxUsername.Text == "" || textBoxPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi !!");
            }
            else
            {
                MessageBox.Show(a);
                Refresh();
                TampilData();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string kategori = comboBoxKategori.Text;

            int id = Convert.ToInt32(textBoxID.Text);

            string a = service.UpdateRegister(username, password, kategori, id);

            if (textBoxUsername.Text == "" || textBoxPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi !!");
            }
            else
            {
                MessageBox.Show(a);
                Refresh();
                TampilData();
            }
        }
        public void TampilData()
        {
            var list = service.DataRegist();
            dtRegister.DataSource = list;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxPassword.Clear();
            textBoxUsername.Clear();
            comboBoxKategori.SelectedItem = null;

            btSave.Enabled = true;
            btUpdate.Enabled = false;
            btDelete.Enabled = false;


        }


        private void btDelete_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Hapus Data", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                string a = service.DeleteRegister(username);
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
            else if(dialogResult == DialogResult.No)
            {

            }
        }

        private void dtRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[0].Value);
            textBoxUsername.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[1].Value);
            textBoxPassword.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[2].Value);
            comboBoxKategori.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[0].Value);

            btUpdate.Enabled = true;
            btDelete.Enabled = true;

            btSave.Enabled = false;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

    }
}
