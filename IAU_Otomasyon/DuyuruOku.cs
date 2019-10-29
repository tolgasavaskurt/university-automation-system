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
    public partial class DuyuruOku : Form
    {
        public DuyuruOku()
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
            komut.CommandText = ("SELECT ders.ders_adi, duyuru.duyuru FROM bolum INNER JOIN(ogrenci INNER JOIN (ders INNER JOIN duyuru ON ders.ders_id = duyuru.ders_id) ON ogrenci.sinif = ders.sinif) ON(bolum.bolum_id = ogrenci.bolum_id) AND(bolum.bolum_id = ders.bolum_id) where ogrenci_id ='" + OgrenciGiris.id.ToString() + "'");
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

        private void Button1_Click(object sender, EventArgs e)
        {
            duyurugoster();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Ogrenci frm = new Ogrenci();
            frm.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
