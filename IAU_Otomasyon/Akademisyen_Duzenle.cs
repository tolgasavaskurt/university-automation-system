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
    public partial class Akademisyen_Duzenle : Form
    {
        public Akademisyen_Duzenle()
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
            komut.CommandText = "SELECT * FROM akademisyen";
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["personel_id"].ToString();
                ekle.SubItems.Add(oku["personel_ad"].ToString());
                ekle.SubItems.Add(oku["personel_soyad"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }


        private void Akademisyen_Duzenle_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string sorgu = "SELECT * FROM akademisyen";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    comboBox1.Items.Add(oku["personel_id"].ToString());
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
            OleDbCommand komut = new OleDbCommand("INSERT INTO akademisyen (personel_id, personel_ad, personel_soyad, parola) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + 1234 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Akademisyen Başarıyla Eklendi!");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM akademisyen where personel_id = '" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Kayıt Başarıyla Silindi!");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE akademisyen SET personel_ad='" + textBox2.Text + "', personel_soyad='" + textBox3.Text + "' where personel_id='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            hepsinigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
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
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string sorgu = "SELECT * FROM akademisyen where personel_id ='" + comboBox1.Text + "'";
                komut.CommandText = sorgu;

                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku["personel_id"].ToString();
                    textBox2.Text = oku["personel_ad"].ToString();
                    textBox3.Text = oku["personel_soyad"].ToString();
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
