using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace IAU_Otomasyon
{
    public partial class DuyuruEkle : Form
    {
        public DuyuruEkle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");

        private void duyurugoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("SELECT ders.ders_adi, duyuru.duyuru FROM ders INNER JOIN duyuru ON ders.ders_id = duyuru.ders_id where personel_id ='" + AkademisyenGiris.no.ToString() + "'");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ders_adi"].ToString();
                ekle.SubItems.Add(oku["duyuru"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void DuyuruEkle_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string sorgu = "SELECT * FROM ders where personel_id ='" + AkademisyenGiris.no.ToString() + "'";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    comboBox1.Items.Add(oku["ders_adi"].ToString());
                }


                baglanti.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            duyurugoster();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO duyuru (ders_id, duyuru) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            duyurugoster();
            textBox1.Clear();
            textBox2.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Duyuru Başarıyla Gönderildi!");
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string sorgu = "SELECT * FROM ders where ders_adi ='" + comboBox1.Text + "'";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku["ders_id"].ToString();
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            akademisyen frm = new akademisyen();
            frm.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
