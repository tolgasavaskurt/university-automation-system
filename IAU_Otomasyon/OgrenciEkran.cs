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
    public partial class OgrenciEkran : Form
    {
        public OgrenciEkran()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void bilgilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText=("SELECT * FROM ogrenci INNER JOIN bolum ON ogrenci.bolum_id=bolum.bolum_id where ogrenci_id='" + OgrenciGiris.id.ToString() + "'");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ogrenci_id"].ToString();
                ekle.SubItems.Add(oku["ogrenci_ad"].ToString());
                ekle.SubItems.Add(oku["ogrenci_soyad"].ToString());
                ekle.SubItems.Add(oku["bolum_adi"].ToString());
                ekle.SubItems.Add(oku["sinif"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void derslerigoster()
        {
            listView2.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("SELECT ders.ders_id, ders.ders_adi, akademisyen.personel_ad, akademisyen.personel_soyad FROM(bolum INNER JOIN(akademisyen INNER JOIN ders ON akademisyen.personel_id = ders.personel_id) ON bolum.bolum_id = ders.bolum_id) INNER JOIN ogrenci ON(ogrenci.sinif = ders.sinif) AND(bolum.bolum_id = ogrenci.bolum_id) where ogrenci_id='" + OgrenciGiris.id.ToString() + "'");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ders_id"].ToString();
                ekle.SubItems.Add(oku["ders_adi"].ToString());
                ekle.SubItems.Add(oku["personel_ad"].ToString());
                ekle.SubItems.Add(oku["personel_soyad"].ToString());

                listView2.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bilgilerigoster();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            derslerigoster();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Ogrenci frm = new Ogrenci();
            frm.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE ogrenci SET parola='" + textBox1.Text + "' where ogrenci_id='" + OgrenciGiris.id.ToString() + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Şifre Başarıyla Değiştirildi!");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
