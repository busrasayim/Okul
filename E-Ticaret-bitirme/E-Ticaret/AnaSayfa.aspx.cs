using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace E_Ticaret
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                YanMenuOlustur();
                VitrinOlustur();
            }
        }

        protected void YanMenuOlustur()
        {
            IEnumerable<Kategori> kategoriler = eticaretDB.Kategoris;

            for (int i = 0; i < kategoriler.Count(); i++)
            {
                Kategori kategori = new Kategori();
                kategori = kategoriler.ElementAt(i);

                IEnumerable<Alt_Kategori> alt_kategoriler = eticaretDB.Alt_Kategoris.Where(ak => ak.KategoriID == kategori.KategoriID);


                HtmlGenericControl li_kategori = new HtmlGenericControl("li");
                li_kategori.Attributes.Add("class", "li_yanMenu");
                ul_yanMenu.Controls.Add(li_kategori);

                HtmlAnchor anchor = new System.Web.UI.HtmlControls.HtmlAnchor();
                anchor.InnerText = kategori.KategoriAdi;
                string altKategoriPage = "AltKategori.aspx?KategoiID=" + kategori.KategoriID.ToString();
                anchor.Attributes.Add("href",altKategoriPage);
                li_kategori.Controls.Add(anchor);


                HtmlGenericControl ul = new HtmlGenericControl("ul");
                li_kategori.Controls.Add(ul);
                HtmlGenericControl li_altKategori = new HtmlGenericControl("li");
                ul.Controls.Add(li_altKategori);

                for (int j = 0; j < alt_kategoriler.Count(); j++)
                {
                    Alt_Kategori alt_kategori = new Alt_Kategori();
                    alt_kategori = alt_kategoriler.ElementAt(j);
                    HtmlGenericControl anchor1 = new HtmlGenericControl("a");
                    string urunPage = "Urun.aspx?AltKategoriID="+alt_kategori.AltKategoriID.ToString();
                    anchor1.Attributes.Add("href", urunPage);
                    anchor1.InnerText = alt_kategori.AltKategoriAdi;
                    li_altKategori.Controls.Add(anchor1);
                }
            }


        }

        protected void VitrinOlustur()
        {           
           IEnumerable<Urun> urunlerList = eticaretDB.Uruns;
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