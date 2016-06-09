using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret.User
{
    public partial class Sepetim : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string kullaniciID = Request.Cookies["Musteri"]["kullaniciID"];
             Sepet sepet = eticaretDB.Sepets.SingleOrDefault(s => s.KullaniciID == int.Parse(kullaniciID));
            if(!Page.IsPostBack)
            {
                hfSepetID.Value = sepet.SepetID.ToString();
            }
           
            SepetGoster(sepet);
        }

        protected void SepetGoster(Sepet sepet) 
        {
            string urunMiktar = "";
            int toplamFiyat=0;
            string odenecek = "";

            if (sepet.Durum=="dolu")
            {
                IEnumerable<SepetUrun> sepetUrun = eticaretDB.SepetUruns.Where(su=>su.SepetID==sepet.SepetID);
                for (int i = 0; i < sepetUrun.Count(); i++)
                {
                    Urun urun = eticaretDB.Uruns.SingleOrDefault(u => u.UrunID == sepetUrun.ElementAt(i).UrunID);
                    Resimler urunResim = eticaretDB.Resimlers.Where(r => r.UrunID == urun.UrunID).First();

                    #region Sipariş Özet

                    urunMiktar = sepetUrun.Count().ToString();
                    lbl_urunAdet.Text = urunMiktar + " " + "Ürün";
                    
                    toplamFiyat+=(int.Parse(urun.Fiyat)*(sepetUrun.ElementAt(i).UrunAdet));
                    lbl_toplamTutar.Text = toplamFiyat.ToString();

                    TableRow tr_indirim = new TableRow();
                    TableCell urunSayac = new TableCell();
                    Label lbl_sayac = new Label();
                    lbl_sayac.Text = (i+1 )+ " ." + "Ürün";
                    urunSayac.Controls.Add(lbl_sayac);
                    TableCell urunIndirim = new TableCell();
                    Label lblIndirim = new Label();
                    lblIndirim.Text = "%" + urun.Indirim + "İndirim";
                    urunIndirim.Controls.Add(lblIndirim);
                    tr_indirim.Controls.Add(urunSayac);
                    tr_indirim.Controls.Add(urunIndirim);
                    tbl_indirim.Controls.Add(tr_indirim);

                    odenecek=sepet.Fiyat;
;
                    lbl_odenecekMiktar.Text = odenecek;
                    #endregion

                    Response.Cookies["miktar"].Value = urunMiktar;
                    Response.Cookies["tutar"].Value = toplamFiyat.ToString();
                    Response.Cookies["odenecek"].Value = odenecek;

                    #region Sepet Icerik
                   

                    int fiyat = int.Parse(urun.Fiyat);
                    int indirim;
                    if (urun.Indirim != null)
                        indirim = (int)urun.Indirim;
                    else
                        indirim = 0;
                    int indirimliFiyat = fiyat - (fiyat * indirim) / 100;

                    TableRow trUrun = new TableRow();

                    TableCell resim = new TableCell();
                    resim.CssClass = "tc_resim";
                    System.Web.UI.WebControls.Image imgNew = new System.Web.UI.WebControls.Image();
                    imgNew.ImageUrl = ResolveUrl("~/ResimYolla.ashx?imgID=") + urunResim.ResimID.ToString();
                    imgNew.Width = new Unit("100%");
                    imgNew.Height = new Unit("150px");
                    Panel pnlResim = new Panel();
                    pnlResim.CssClass = "sepetResim";
                    pnlResim.Controls.Add(imgNew);
                    resim.Controls.Add(pnlResim);

                    TableCell urunAd = new TableCell();
                    Label lblAd = new Label();
                    lblAd.Text = urun.UrunAdi;
                    urunAd.Controls.Add(lblAd);

                    TableCell urunBilgi = new TableCell();
                    Label lblBilgi = new Label();
                    lblBilgi.Text = urun.Tanimi;
                    urunBilgi.Controls.Add(lblBilgi);

                    TableCell urunAdet = new TableCell();
                    Label lblAdet = new Label();
                    lblAdet.Text = sepetUrun.ElementAt(i).UrunAdet.ToString();
                    urunAdet.Controls.Add(lblAdet);

                    TableCell urunFiyat = new TableCell();
                    Label lblFiyat = new Label();
                    lblFiyat.ID = "lbl" + urun.UrunID.ToString(); ;
                    lblFiyat.Text = (indirimliFiyat * (sepetUrun.ElementAt(i).UrunAdet)).ToString();
                    urunFiyat.Controls.Add(lblFiyat);

                    TableCell btnSil = new TableCell();
                    Panel pnlSil = new Panel();
                    pnlSil.ID = urun.UrunID.ToString();
                    pnlSil.CssClass = "btn_sil";
                    Panel pnlText = new Panel();
                    Label lblText = new Label();
                    pnlText.Controls.Add(lblText);
                    lblText.Text = "Sepetten Çıkar";
                    btnSil.Controls.Add(pnlSil);
                    btnSil.Controls.Add(pnlText);

                    trUrun.Controls.Add(resim);
                    trUrun.Controls.Add(urunAd);
                    trUrun.Controls.Add(urunBilgi);
                    trUrun.Controls.Add(urunAdet);
                    trUrun.Controls.Add(urunFiyat);
                    trUrun.Controls.Add(btnSil);

                    tbl_sepet.Controls.Add(trUrun);
                    #endregion   
                }
            }
            else
            {
                tbl_sepet.Visible = false;
                pnl_sepetMesaj.Visible = true;
                btn_Tamamla.Visible = false;
            }

        }


        [System.Web.Services.WebMethod]
        public static void SepettenCikar(int urunID,string fiyat,int sepetID)
        {
            EticaretDBDataContext eticaret_db = new EticaretDBDataContext();
            SepetUrun sepetUrun = eticaret_db.SepetUruns.SingleOrDefault(su=>su.UrunID==urunID && su.SepetID==sepetID);
            
            Urun urun = eticaret_db.Uruns.SingleOrDefault(u => u.UrunID == urunID);
            urun.Stok += sepetUrun.UrunAdet;
            eticaret_db.SubmitChanges();

            Sepet sepet = eticaret_db.Sepets.SingleOrDefault(s=>s.SepetID==sepetUrun.SepetID);
            int guncelFiyat = int.Parse(sepet.Fiyat) - int.Parse(fiyat);
            sepet.Fiyat = guncelFiyat.ToString();
            if (guncelFiyat == 0)
                sepet.Durum = "bos";
            eticaret_db.SubmitChanges();

            eticaret_db.SepetUruns.DeleteOnSubmit(sepetUrun);
            eticaret_db.SubmitChanges();
        }
        protected void btn_alisveriDevam_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("../AnaSayfa.aspx"));
        }

        protected void btn_Tamamla_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("Teslimat.aspx"));
        }
    }
}