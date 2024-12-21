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
            lblMusteriSayisi.Text=db.TblMusteri.Count().ToString();
            lblKategoriSayisi.Text=db.TblKategori.Count().ToString();
            lblUrunSayisi.Text = db.TblUrunler.Count().ToString();
        }
    }
}
