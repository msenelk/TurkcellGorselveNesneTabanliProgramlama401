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
            // dataGridView1.DataSource = db.TblMusteri.ToList();
            var degerler = from x in db.TblMusteri
                           select new
                           {
                               x.MusteriID,
                               x.Ad,
                               x.Soyad,
                               x.Sehir,
                               x.Bakiye
                           };
            dataGridView1.DataSource = degerler.ToList();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x=db.TblMusteri.Find(id);
            db.TblMusteri.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Müşteri Sistemden Silindi.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = db.TblMusteri.Find(id);
            x.Ad = txtAd.Text;
            x.Soyad=txtSoyad.Text;
            x.Sehir=txtSehir.Text;
            x.Bakiye=decimal.Parse(txtBakiye.Text);
            db.SaveChanges();
            MessageBox.Show("Müşteri bilgileri güncellendi.");
        }
    }
}
