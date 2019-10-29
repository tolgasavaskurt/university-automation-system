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
    public partial class Ogrenci_Duzenle : Form
    {
        public Ogrenci_Duzenle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void hepsinigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT ogrenci.ogrenci_id, ogrenci.ogrenci_ad, ogrenci.ogrenci_soyad, bolum.bolum_id, bolum.bolum_adi, ogrenci.sinif FROM bolum INNER JOIN ogrenci ON bolum.bolum_id = ogrenci.bolum_id;";
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ogrenci_id"].ToString();
                ekle.SubItems.Add(oku["ogrenci_ad"].ToString());
                ekle.SubItems.Add(oku["ogrenci_soyad"].ToString());
                ekle.SubItems.Add(oku["bolum_id"].ToString());
                ekle.SubItems.Add(oku["bolum_adi"].ToString());
                ekle.SubItems.Add(oku["sinif"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string sorgu = "SELECT ogrenci.ogrenci_id, ogrenci.ogrenci_ad, ogrenci.ogrenci_soyad, bolum.bolum_id, bolum.bolum_adi, ogrenci.sinif FROM bolum INNER JOIN ogrenci ON bolum.bolum_id = ogrenci.bolum_id where ogrenci_id ='" + comboBox1.Text + "'";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();
                while(oku.Read())
                {
                    textBox1.Text = oku["ogrenci_id"].ToString();
                    textBox2.Text = oku["ogrenci_ad"].ToString();
                    textBox3.Text = oku["ogrenci_soyad"].ToString();
                    textBox4.Text = oku["bolum_id"].ToString();
                    textBox5.Text = oku["bolum_adi"].ToString();
                    textBox6.Text = oku["sinif"].ToString();
                }
                baglanti.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }

        private void Ogrenci_Duzenle_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string sorgu = "SELECT * FROM ogrenci";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();

                while(oku.Read())
                {
                    comboBox1.Items.Add(oku["ogrenci_id"].ToString());
                }


                baglanti.Close();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            hepsinigoster();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO ogrenci (ogrenci_id, ogrenci_ad, ogrenci_soyad, bolum_id, sinif, parola) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','"+ 1234 +"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Öğrenci Başarıyla Eklendi!");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM ogrenci where ogrenci_id = '" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Kayıt Başarıyla Silindi!");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE ogrenci SET ogrenci_ad='"+ textBox2.Text + "', ogrenci_soyad='"+ textBox3.Text + "', bolum_id='" + textBox4.Text + "', sinif='" + textBox6.Text + "' where ogrenci_id='"+ textBox1.Text +"'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Bilgiler Başarıyla Güncellendi!");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            YetkiliEkran frm = new YetkiliEkran();
            frm.Show();
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
