using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace E_Ticaret
{
    public partial class Urun1 : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
                int altKategoriID = int.Parse(Request.QueryString["AltKategoriID"]);
                IEnumerable<AltKategoriOzellik> altKategoriÖzellik = eticaretDB.AltKategoriOzelliks.Where(a => a.AltKategoriID == altKategoriID);
                FiltelemeOlustur(altKategoriÖzellik);
                string degerler = hiddenDeger.Value;
                VitrinOlustur(degerler, altKategoriID);
        }

        protected void FiltelemeOlustur(IEnumerable<AltKategoriOzellik> altKategoriÖzellik)
        {
            foreach(AltKategoriOzellik ao in altKategoriÖzellik)
            {
                Panel filtreBaslik = new Panel();
                filtreBaslik.CssClass = "filtre_baslik";
                Label filtreAdi = new Label();
                Ozellik ozellik=eticaretDB.Ozelliks.SingleOrDefault(o => o.OzellikID == ao.OzellikID);
                filtreAdi.Text = ozellik.OzellikAdi;
                filtreBaslik.Controls.Add(filtreAdi);
                div_filtre.Controls.Add(filtreBaslik);

                Panel filtreDeger = new Panel();
                filtreDeger.CssClass = "filtre_icerik";
                CheckBoxList cbl_filtre = new CheckBoxList();
                cbl_filtre.CssClass = "cbl_deger";
                cbl_filtre.AutoPostBack = true;
                IEnumerable<OzellikDeger> ozellikDeger = eticaretDB.OzellikDegers.Where(od => od.AltKategoriOzellikID == ao.AltKategoriOzellikID);
                foreach (OzellikDeger od in ozellikDeger)
                {
                    ListItem deger = new ListItem(od.Deger,od.OzellikDegerID.ToString(), true);
                    cbl_filtre.Items.Add(deger);
                }
                filtreDeger.Controls.Add(cbl_filtre);
                div_filtre.Controls.Add(filtreDeger);
            }
        }

        protected void VitrinOlustur(string ozellikDegerler,int altKategoriID)
        {
            table_urun.Controls.Clear();
            IEnumerable<Urun> urunlerList;
            if (ozellikDegerler == "")
            {
                urunlerList = eticaretDB.Uruns.Where(u => u.AltKategori == altKategoriID).ToList();
            }
            else 
            {
                string[] stringDegerler = ozellikDegerler.Split(',');
                int[] intDegerler = Array.ConvertAll(stringDegerler, s => int.Parse(s));
                IEnumerable<int> urunOzellikDegerList = eticaretDB.UrunOzellikDegers.Where(u => intDegerler.Contains(u.OzellikDegerID)).Select(u=>u.UrunID).Distinct().ToList();
                List<Urun> urunList = new List<Urun>();
                for (int i = 0; i < urunOzellikDegerList.Count();i++ )
                {
                    Urun urun1 = new Urun();
                    urun1 = eticaretDB.Uruns.SingleOrDefault(u=>u.UrunID==urunOzellikDegerList.ElementAt(i));
                    urunList.Add(urun1);
                }
                urunlerList = urunList;
            }

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