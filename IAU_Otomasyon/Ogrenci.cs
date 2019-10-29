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
    public partial class Ogrenci : Form
    {
        public Ogrenci()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DuyuruOku frm = new DuyuruOku();
            frm.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OgrenciEkran frm = new OgrenciEkran();
            frm.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OgrenciGiris frm = new OgrenciGiris();
            frm.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
