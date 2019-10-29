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
    public partial class YetkiliGiris : Form
    {
        public YetkiliGiris()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")

            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Yönetici Girişi Yapıldı!");
                YetkiliEkran frm = new YetkiliEkran();
                frm.Show();
                this.Hide();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Hatalı Giriş Yaptınız!");

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Anasayfa frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void YetkiiliGiris_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
