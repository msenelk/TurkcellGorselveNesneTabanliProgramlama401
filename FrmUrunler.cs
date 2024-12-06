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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        DbUrunEntities db = new DbUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            // dataGridView1.DataSource=db.TblUrunler.ToList(); -- İstemediğimiz tüm bilgiler geldiği için aşağıdaki kodu uyguluyoruz.

            var degerler = from x in db.TblUrunler
                           select new
                           {
                               x.UrunId,
                               x.UrunAd,
                               x.Stok,
                               x.AlisFiyat,
                               x.SatisFiyat,
                               x.TblKategori.Ad
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            cmbKategori.DataSource = db.TblKategori.ToList();
            cmbKategori.ValueMember = "ID"; // Arka planda ID çalışacak
            cmbKategori.DisplayMember = "Ad"; // Burası da kullanıcıya gösterilecek kısım.
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblUrunler t = new TblUrunler();
            t.UrunAd = txtUrunAd.Text;
            t.Stok = short.Parse(txtStok.Text);
            t.AlisFiyat = decimal.Parse(txtAlisFiyat.Text);
            t.SatisFiyat = decimal.Parse(txtSatisFiyat.Text);
            t.Kategori = int.Parse(cmbKategori.SelectedValue.ToString());
            db.TblUrunler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün başarılıyla eklendi.");
        }
    }
}
