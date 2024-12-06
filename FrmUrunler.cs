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
        void Listele()
        {
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

        void Temizle()
        {
            txtAlisFiyat.Text = "";
            txtId.Text = "";
            txtSatisFiyat.Text = "";
            txtStok.Text = "";
            txtUrunAd.Text = "";
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            // dataGridView1.DataSource=db.TblUrunler.ToList(); -- İstemediğimiz tüm bilgiler geldiği için aşağıdaki kodu uyguluyoruz.

            Listele();
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            cmbKategori.DataSource = db.TblKategori.ToList();
            cmbKategori.ValueMember = "ID"; // Arka planda ID çalışacak
            cmbKategori.DisplayMember = "Ad"; // Burası da kullanıcıya gösterilecek kısım.
            Listele();
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
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //cmbKategori.SelectedValue= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(txtId.Text!="")
            {
                int id=int.Parse(txtId.Text);
                var x = db.TblUrunler.Find(id);
                db.TblUrunler.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Ürün başarılı bir şekilde silindi", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Lütfen verileri listeledikten sonra bir satıra tıklayıp silmek istediğiniz kaydı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = db.TblUrunler.Find(id);
            x.UrunAd = txtUrunAd.Text;
            x.Stok = short.Parse(txtStok.Text);
            x.AlisFiyat=decimal.Parse(txtAlisFiyat.Text);
            x.SatisFiyat = decimal.Parse(txtSatisFiyat.Text);
            x.Kategori=int.Parse(cmbKategori.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Verileriniz başarılı bir şekilde güncellendi","Güncelleme Bilgisi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();
        }
    }
}
