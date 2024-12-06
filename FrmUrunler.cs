﻿using System;
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
    }
}