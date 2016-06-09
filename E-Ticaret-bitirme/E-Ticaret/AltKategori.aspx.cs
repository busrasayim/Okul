using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace E_Ticaret
{
    public partial class AltKategori : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                IEnumerable<Alt_Kategori> altKategoriList = eticaretDB.Alt_Kategoris.Where(a => a.KategoriID == int.Parse(Request.QueryString["KategoiID"]));
                YanMenuOlustur(altKategoriList);
                VitrinOlustur(altKategoriList);
            }
        }
        protected void YanMenuOlustur(IEnumerable<Alt_Kategori> altKategoriler)
        {
            List<Urun> urunler = new List<Urun>();
            for (int i = 0; i < altKategoriler.Count(); i++)
            {
                #region Yan Menü
                Alt_Kategori altKategori = new Alt_Kategori();
                altKategori = altKategoriler.ElementAt(i);

                HtmlGenericControl li_altKategori = new HtmlGenericControl("li");
                li_altKategori.Attributes.Add("class", "li_yanMenu");
                ul_altKategoriMenu.Controls.Add(li_altKategori);

                HtmlAnchor anchor = new System.Web.UI.HtmlControls.HtmlAnchor();
                anchor.InnerText = altKategori.AltKategoriAdi;
                string urunPage = "Urun.aspx?AltKategoriID=" + altKategori.AltKategoriID.ToString();
                anchor.Attributes.Add("href", urunPage);
                li_altKategori.Controls.Add(anchor);
                #endregion

            }
        }
        protected void VitrinOlustur(IEnumerable<Alt_Kategori> altKategoriler)
        {
            List<int> altKategoriID=new List<int>();
            foreach(Alt_Kategori altKategori in altKategoriler)
            {
                altKategoriID.Add(altKategori.AltKategoriID);
            }
            IEnumerable<Urun> urunlerList = eticaretDB.Uruns.Where(u=>altKategoriID.Contains(u.AltKategori)).ToList();
            Urun urun = new Urun();
            int urunAdet = urunlerList.Count();
            int urunSayac = 0;
            while (urunAdet > 5)
            {
                TableRow tRow = new TableRow();
                table_urun.Rows.Add(tRow);
                for (int i = 0; i < 5; i++)
                {
                    urun = urunlerList.ElementAt(urunSayac);
                    UrunGetir(urun, tRow);
                    urunSayac++;
                    urunAdet--;
                }
            }
            TableRow tRow_kalan = new TableRow();
            table_urun.Rows.Add(tRow_kalan);
            for (int k = 0; k < urunAdet; k++)
            {
                urun = urunlerList.ElementAt(urunSayac);
                UrunGetir(urun, tRow_kalan);
                urunSayac++;
            }
        }

        protected void UrunGetir(Urun urun, TableRow tr)
        {
            Resimler resim = eticaretDB.Resimlers.Where(r => r.UrunID == urun.UrunID).First();
            System.Web.UI.WebControls.Image imgNew = new System.Web.UI.WebControls.Image();
            imgNew.ImageUrl = "~/ResimYolla.ashx?imgID=" + resim.ResimID.ToString();
            imgNew.Width = new Unit("100%");
            imgNew.Height = new Unit("100%");

            HtmlGenericControl div_resim = new HtmlGenericControl("div");
            div_resim.Attributes.Add("class", "div_image");
            div_resim.Controls.Add(imgNew);

            Label urunAdi = new Label();
            urunAdi.Text = urun.UrunAdi + "<br/>";
            urunAdi.Attributes.Add("class", "txt_urunAdi");

            Label urunTanimi = new Label();
            urunTanimi.Text = urun.Tanimi + "<br/>";
            urunTanimi.Attributes.Add("class", "txt_urunTanimi");

            Label urunFiyat = new Label();
            urunFiyat.Text = urun.Fiyat;
            urunFiyat.Attributes.Add("class", "txt_urunFiyat");

            HtmlGenericControl div_indirim = new HtmlGenericControl("div");
            div_indirim.Attributes.Add("class", "div_indirim");
            Label urunIndirim = new Label();
            urunIndirim.Text = "<br/>" + "%" + urun.Indirim + "<br/>" + "indirim";
            urunIndirim.Attributes.Add("class", "txt_urunIndirim");
            div_indirim.Controls.Add(urunIndirim);

            TableCell tCell = new TableCell();
            tCell.ID = urun.UrunID.ToString();
            tCell.CssClass = "urunCell";
            tCell.Width = new Unit("20%");
            tCell.Height = 150;
            tCell.Controls.Add(div_resim);
            tCell.Controls.Add(urunAdi);
            tCell.Controls.Add(urunTanimi);
            tCell.Controls.Add(urunFiyat);
            tCell.Controls.Add(div_indirim);
            tr.Cells.Add(tCell);
        }
    }
}