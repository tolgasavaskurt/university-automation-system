using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAU_Otomasyon
{
    public partial class YetkiliEkran : Form
    {
        public YetkiliEkran()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Akademisyen_Duzenle frm = new Akademisyen_Duzenle();
            frm.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Ogrenci_Duzenle frm = new Ogrenci_Duzenle();
            frm.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Ders_Duzenle frm = new Ders_Duzenle();
            frm.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            YetkiliGiris frm = new YetkiliGiris();
            frm.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
