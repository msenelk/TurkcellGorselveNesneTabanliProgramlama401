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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DbUrunEntities db=new DbUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            lblMusteriSayisi.Text=db.TblMusteri.Count().ToString();
            lblKategoriSayisi.Text=db.TblKategori.Count().ToString();
            lblUrunSayisi.Text = db.TblUrunler.Count().ToString();
            lblBeyazEsyaSayisi.Text = db.TblUrunler.Count(x=>x.Kategori==1).ToString();
            lblToplamStok.Text = db.TblUrunler.Sum(x => x.Stok).ToString();
            lblBugunSatisAdedi.Text=db.TblSatislar.Count(x=>x.Tarih==bugun).ToString();
            lblToplamKasa.Text = db.TblSatislar.Sum(x => x.Toplam).ToString()+ " ₺";
            lblBugunkuKasa.Text=db.TblSatislar.Where(x=>x.Tarih==bugun).Sum(y=>y.Toplam).ToString() +" ₺";
            lblEnYuksekFiyatliUrun.Text = (from x in db.TblUrunler
                                           orderby x.SatisFiyat descending
                                           select x.UrunAd).FirstOrDefault();
            lblEnDusukFiyatliUrun.Text = (from x in db.TblUrunler orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            lblEnFazlaStokluUrun.Text = (from x in db.TblUrunler
                                         orderby x.Stok descending
                                         select x.UrunAd).FirstOrDefault();
            lblEnAzStokluUrun.Text=(from x in db.TblUrunler
                                   orderby x.Stok ascending
                                   select x.UrunAd).FirstOrDefault();
        }
    }
}
