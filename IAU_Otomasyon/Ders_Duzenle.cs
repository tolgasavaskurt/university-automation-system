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
    public partial class Ders_Duzenle : Form
    {
        public Ders_Duzenle()
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
            komut.CommandText = "SELECT ders.ders_id, ders.ders_adi, ders.kredi, bolum.bolum_adi, akademisyen.personel_ad, akademisyen.personel_soyad, ders.sinif FROM bolum INNER JOIN(akademisyen INNER JOIN ders ON akademisyen.personel_id = ders.personel_id) ON bolum.bolum_id = ders.bolum_id; ";
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ders_id"].ToString();
                ekle.SubItems.Add(oku["ders_adi"].ToString());
                ekle.SubItems.Add(oku["kredi"].ToString());
                ekle.SubItems.Add(oku["bolum_adi"].ToString());
                ekle.SubItems.Add(oku["personel_ad"].ToString());
                ekle.SubItems.Add(oku["personel_soyad"].ToString());
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
                string sorgu = "SELECT ders.ders_id, ders.ders_adi, ders.kredi, ders.bolum_id, bolum.bolum_adi, ders.sinif, ders.personel_id, akademisyen.personel_ad, akademisyen.personel_soyad FROM bolum INNER JOIN(akademisyen INNER JOIN ders ON akademisyen.personel_id = ders.personel_id) ON bolum.bolum_id = ders.bolum_id where ders_id ='" + comboBox1.Text + "'";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku["ders_id"].ToString();
                    textBox2.Text = oku["ders_adi"].ToString();
                    textBox3.Text = oku["kredi"].ToString();
                    textBox4.Text = oku["bolum_id"].ToString();
                    textBox5.Text = oku["bolum_adi"].ToString();
                    textBox6.Text = oku["sinif"].ToString();
                    textBox7.Text = oku["personel_id"].ToString();
                    textBox8.Text = oku["personel_ad"].ToString();
                    textBox9.Text = oku["personel_soyad"].ToString();
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }

        private void Ders_Duzenle_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string sorgu = "SELECT * FROM ders";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    comboBox1.Items.Add(oku["ders_id"].ToString());
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
            OleDbCommand komut = new OleDbCommand("INSERT INTO ders (ders_id, ders_adi, kredi, bolum_id, sinif, personel_id) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Ders Başarıyla Eklendi!");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM ders where ders_id = '" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Kayıt Başarıyla Silindi!");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE ders SET ders_adi='" + textBox2.Text + "', kredi='" + textBox3.Text + "', bolum_id='" + textBox4.Text + "', sinif='" + textBox6.Text + "', personel_id='" + textBox7.Text + "' where ders_id='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
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
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
