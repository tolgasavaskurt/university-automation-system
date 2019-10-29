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
    public partial class AkademisyenGiris : Form
    {
        public static string no;

        public AkademisyenGiris()
        {
            InitializeComponent();
        }

        OleDbDataReader oku;
        private void Button1_Click(object sender, EventArgs e)
        {
            no = textBox1.Text;
            string sifre = textBox2.Text;
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM akademisyen where personel_id='" + no + "' AND parola='" + sifre + "'";
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Giriş Başarılı!");
                akademisyen frm = new akademisyen();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            baglanti.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Anasayfa frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
