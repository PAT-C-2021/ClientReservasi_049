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
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();
            TampilData();
            btUpdate.Enabled = false;
            btDelete.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelpon = textBoxNoTlf.Text;
            int JumlahPemesanan = int.Parse(textBoxJumlah.Text);
            string IDLokasi = textBoxIDLokasi.Text;

            var a = service.pemesanan(IDPemesanan, NamaCustomer, NoTelpon, JumlahPemesanan, IDLokasi);

            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelpon = textBoxNoTlf.Text;

            var a = service.editPemesanan(IDPemesanan, NamaCustomer, NoTelpon);

            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;

            var a = service.deletePemesanan(IDPemesanan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }
        public void TampilData()
        {
            var List = service.Pemesanan1();
            dtPemesanan.DataSource = List;
            //dtPemesanan.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
        public void Clear()
        {
            textBoxID.Clear();
            textBoxNama.Clear();
            textBoxNoTlf.Clear();
            textBoxJumlah.Clear();
            textBoxIDLokasi.Clear();

            textBoxJumlah.Enabled = true;
            textBoxIDLokasi.Enabled = true;

            btSave.Enabled = true;
            btUpdate.Enabled = false;
            btDelete.Enabled = false;

            textBoxID.Enabled = true;


        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dtPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[0].Value);
            textBoxNama.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[1].Value);
            textBoxNoTlf.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[2].Value);
            textBoxJumlah.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[3].Value);
            textBoxIDLokasi.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[4].Value);

            textBoxJumlah.Enabled = false;
            textBoxIDLokasi.Enabled = false;
            
            btUpdate.Enabled = true;
            btDelete.Enabled = true;

            btSave.Enabled = false;
            textBoxID.Enabled = false;
        }
    }
}
