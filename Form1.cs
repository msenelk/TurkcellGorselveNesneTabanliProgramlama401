using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkcellGorselveNesneTabanliProgramlama401
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbUrunEntities db=new DbUrunEntities();
         private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TblMusteri.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblMusteri t=new TblMusteri();
            t.Ad = txtAd.Text;
            t.Bakiye = decimal.Parse(txtBakiye.Text);
            t.Sehir = txtSehir.Text;
            t.Soyad = txtSoyad.Text;
            db.TblMusteri.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Müşteri Kaydı Yapıldı");
        }
    }
}
