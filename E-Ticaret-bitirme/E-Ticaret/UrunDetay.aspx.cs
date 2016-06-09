using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace E_Ticaret
{
    public partial class UrunDetay : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            div_yonetici.Visible = false;
            btn_yonetici.Visible = false;
            div_btnYorum.Visible = false;

            if ((Request.Cookies["Musteri"] != null) && (HttpContext.Current.User.Identity.IsAuthenticated))
            {
                div_btnYorum.Visible = true;
                Giris.Visible = false;
                Cikis.Visible = true;
                string adsoyad = Request.Cookies["Musteri"]["AdSoyad"];
                lbl_kullaniciRol.Text = "Hoşgeldiniz" + " " + adsoyad;

                bool isAdmin = HttpContext.Current.User.IsInRole("admin");
                if (isAdmin)
                {
                    div_yonetici.Visible = true;
                    btn_yonetici.Visible = true;
                }
            }
            else
            {
                Giris.Visible = true;
                Cikis.Visible = false;
            }

            NumericUpDownExtender1.Minimum = 1;
            NumericUpDownExtender1.Maximum = 22;
            
            int urunID=int.Parse(Request.QueryString["urunID"]);
            
            Resimler resim = eticaretDB.Resimlers.Where(r => r.UrunID == urunID).First();
            System.Web.UI.WebControls.Image urunResim = new System.Web.UI.WebControls.Image();
            urunResim.ImageUrl="~/ResimYolla.ashx?imgID=" + resim.ResimID.ToString();
            urunResim.Width = new Unit("100%");
            urunResim.Height = new Unit("400px");
            resimGoster.Controls.Add(urunResim);
            
            Urun urun = new Urun();
            urun = eticaretDB.Uruns.SingleOrDefault(u => u.UrunID == urunID);
            UrunGorselOlustur(urunID);
            UrunBilgiDoldur(urun);
            UrunSiparisDoldur(urun);
            YorumGetir(urunID);
        }
        protected void UrunGorselOlustur(int urunID)
        {
            IEnumerable<Resimler> resimler = eticaretDB.Resimlers.Where(u=>u.UrunID==urunID);
            foreach (Resimler resim in resimler)
            {
                System.Web.UI.WebControls.Image imgNew = new System.Web.UI.WebControls.Image();
                imgNew.ID = resim.ResimID.ToString();
                imgNew.ImageUrl = "~/ResimYolla.ashx?imgID=" + resim.ResimID.ToString();
                HtmlGenericControl div_resim = new HtmlGenericControl("div");
                div_resim.Controls.Add(imgNew);
                jsCarousel.Controls.Add(div_resim);
            }
        }
        protected void UrunSiparisDoldur(Urun urun) 
        {
            lbl_urunStok.Text = urun.Stok.ToString();
            int fiyat = int.Parse(urun.Fiyat);
            lbl_urunFiyat.Text = fiyat.ToString() + " TL";

            int indirim;
            if (urun.Indirim != null)
                indirim = (int)urun.Indirim;
            else
                indirim = 0;
            int indirimliFiyat = fiyat - (fiyat * indirim) / 100;
            lbl_indirimliFiyat.Text = indirimliFiyat.ToString() + " TL";
            lbl_kazanc.Text = (fiyat - indirimliFiyat).ToString() + " TL";
        }
        protected void UrunBilgiDoldur(Urun urun)
        {
            lbl_urunAd.Text = urun.UrunAdi;
            lbl_urunTanim.Text = urun.Tanimi;
            
            urunIndirim.Text =  "%" +urun.Indirim+ "<br/>" + "indirim";

            
            IEnumerable<UrunOzellikDeger> urunOzellikDegerList = eticaretDB.UrunOzellikDegers.Where(u=>u.UrunID==urun.UrunID);
            foreach (UrunOzellikDeger uod in urunOzellikDegerList)
            {
                TableRow tr = new TableRow();
                Label lbl_ozellikAd = new Label();
                lbl_ozellikAd.CssClass = "ozellikAd";
                Label lbl_ozellikDeger = new Label();
                Label lbl_ayrac = new Label();
                OzellikDeger ozellikDeger = eticaretDB.OzellikDegers.SingleOrDefault(o => o.OzellikDegerID == uod.OzellikDegerID);
                string deger = ozellikDeger.Deger;
                
                var ID = (from o in eticaretDB.OzellikDegers
                                where (o.OzellikDegerID == ozellikDeger.OzellikDegerID)
                                join a in eticaretDB.AltKategoriOzelliks on o.AltKategoriOzellikID equals a.AltKategoriOzellikID
                                select new { a.OzellikID }).ToList();
                int ozellikID = ID[0].OzellikID;
                Ozellik ozellik = eticaretDB.Ozelliks.SingleOrDefault(o=>o.OzellikID==ozellikID);
                string ad = ozellik.OzellikAdi;

                lbl_ozellikAd.Text = ad;
                lbl_ayrac.Text = " : ";
                lbl_ozellikDeger.Text = deger;

                TableCell td1 = new TableCell();
                td1.Controls.Add(lbl_ozellikAd);
                TableCell td2 = new TableCell();
                td2.Controls.Add(lbl_ayrac);
                TableCell td3 = new TableCell();
                td3.Controls.Add(lbl_ozellikDeger);
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                tbl_urunOzellik.Controls.Add(tr);
            }
            OylamaGetir(urun.UrunID);
        }
        protected void OylamaGetir(int ID)
        {
            UrunOylama oylar = eticaretDB.UrunOylamas.SingleOrDefault(o=>o.UrunID==ID);
            int bir = oylar.BirYildiz;
            int iki = oylar.İkiYildiz;
            int uc = oylar.UcYildiz;
            int dort = oylar.DortYildiz;
            int bes = oylar.BesYildiz;
            int toplam = bir + iki + uc + dort + bes;
            if (toplam == 0)
                toplam = 1;
            int ortalama = (bir + (iki * 2) + (uc * 3) + (dort * 4) + (bes * 5)) / toplam;
            for (int i = 0; i < ortalama; i++)
            {
                HtmlGenericControl yildiz = new HtmlGenericControl("div");
                yildiz.Attributes.Add("class", "doluYildiz");
                stars.Controls.Add(yildiz);
            }
            int kalan = 5 - ortalama;
            for (int i = 0; i < kalan; i++)
            {
                HtmlGenericControl yildiz = new HtmlGenericControl("div");
                yildiz.Attributes.Add("class", "bosYildiz");
                stars.Controls.Add(yildiz);
            }
        }

        protected void YorumGetir(int UrunID)
        {
            IEnumerable<Yorumlar> yorumlar = eticaretDB.Yorumlars.Where(y=>y.UrunID==UrunID);
            lbl_yorumAdet.Text="("+yorumlar.Count().ToString()+") "+"Yorum";
            for (int i = 0; i < yorumlar.Count(); i++)
            {
                Yorumlar yorum = yorumlar.ElementAt(i);
                Kullanici kullanici = eticaretDB.Kullanicis.SingleOrDefault(k=>k.KullaniciID==yorum.KullaniciID);
                Panel pnlYorum = new Panel();
                pnlYorum.CssClass = "kullaniciYorum";

                Panel pnlBaslik = new Panel();
                pnlBaslik.CssClass = "kullaniciBaslik";
                Label lblBaslik = new Label();
                lblBaslik.Text = yorum.YorumBaslik;
                pnlBaslik.Controls.Add(lblBaslik);

                Panel pnlTarih = new Panel();
                pnlTarih.CssClass = "yorumTarih";
                Label lblYorum = new Label();
                lblYorum.Text = yorum.YorumTarih.ToString();
                pnlTarih.Controls.Add(lblYorum);

                Panel pnlIcerik = new Panel();
                pnlIcerik.CssClass = "yorumIcerik";
                Label lblIcerik = new Label();
                lblIcerik.Text = yorum.Yorum;
                pnlIcerik.Controls.Add(lblIcerik);

                Panel pnlYorumYapan = new Panel();
                pnlYorumYapan.CssClass = "yorumYapan";
                Label lblYorumYapan = new Label();
                lblYorumYapan.Text = kullanici.Ad + " " + kullanici.Soyad;
                pnlYorumYapan.Controls.Add(lblYorumYapan);

                pnlYorum.Controls.Add(pnlBaslik);
                pnlYorum.Controls.Add(pnlTarih);
                pnlYorum.Controls.Add(pnlIcerik);
                pnlYorum.Controls.Add(pnlYorumYapan);

                pnl_yorumlar.Controls.Add(pnlYorum);
            }
        }

        protected void btn_yorumGonder_Click(object sender, EventArgs e)
        {
            int urunId=int.Parse(Request.QueryString["urunID"]);
            Yorumlar yorum = new Yorumlar();
            yorum.YorumBaslik = txt_yorumBaslik.Text;
            yorum.Yorum = txt_yorumIcerik.Text;
            string kullaniciID = Request.Cookies["Musteri"]["kullaniciID"];
            yorum.KullaniciID = int.Parse(kullaniciID);
            yorum.UrunID = urunId;
            yorum.YorumTarih = DateTime.Now;
            eticaretDB.Yorumlars.InsertOnSubmit(yorum);
            eticaretDB.SubmitChanges();

            int oy = int.Parse(rdb_puanlama.SelectedValue);
            UrunOylama oylama = eticaretDB.UrunOylamas.SingleOrDefault(o => o.UrunID == urunId);
            if (oy == 1)
                oylama.BirYildiz += 1;
            else if (oy == 2)
                oylama.İkiYildiz += 1;
            else if (oy == 3)
                oylama.UcYildiz += 1;
            else if (oy == 4)
                oylama.DortYildiz += 1;
            else if (oy == 5)
                oylama.BesYildiz += 1;
            eticaretDB.SubmitChanges();

        }

        protected void Giris_Click(object sender, EventArgs e)
        {
            Response.Redirect("UyeGiris.aspx");
        }

        protected void Cikis_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut(); //Yetkilendirme işlemini sonlandırıyoruz.

            HttpCookie myCookie = Request.Cookies["Musteri"]; // cookiesimizi okuduk
            myCookie.Expires = DateTime.Now.AddMinutes(-2);
            Response.Cookies.Add(myCookie); // cookies ekledik

            Response.Redirect("AnaSayfa.aspx");
        }

        protected void btn_yonetici_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yonetici/UrunKayit.aspx");
        }

        protected void btn_hesap_Click(object sender, EventArgs e)
        {
            Response.Redirect("User/Hesabim.aspx");
        }

        protected void btn_sepet_Click(object sender, EventArgs e)
        {
            Response.Redirect("User/Sepetim.aspx");
        }

        protected void btn_sepeteEkle_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Musteri"] != null)
            {
                int urunID = int.Parse(Request.QueryString["urunID"]);
                Urun eklenecekUrun = eticaretDB.Uruns.SingleOrDefault(u => u.UrunID == urunID);
                int urunStok = eklenecekUrun.Stok;
                int ekleneceAdet = int.Parse(txt_urunAdet.Text);

                if ((urunStok - ekleneceAdet) >= 0)
                {
                    eklenecekUrun.Stok -= ekleneceAdet;
                    eticaretDB.SubmitChanges();

                    string kullaniciID = Request.Cookies["Musteri"]["kullaniciID"];
                    Sepet sepet = eticaretDB.Sepets.SingleOrDefault(s => s.KullaniciID == int.Parse(kullaniciID));
                    int fiyat = int.Parse(eklenecekUrun.Fiyat);
                    int indirim;
                    if (eklenecekUrun.Indirim != null)
                        indirim = (int)eklenecekUrun.Indirim;
                    else
                        indirim = 0;
                    int indirimliFiyat = fiyat - (fiyat * indirim) / 100;
                    sepet.Fiyat=(int.Parse(sepet.Fiyat) +(ekleneceAdet * indirimliFiyat)).ToString();
                    sepet.Durum = "dolu";
                    eticaretDB.SubmitChanges();

                    SepetUrun sepetteVarmi = eticaretDB.SepetUruns.SingleOrDefault(v=>v.UrunID==urunID && v.SepetID==sepet.SepetID);
                    if (sepetteVarmi == null)
                    {
                        SepetUrun sepetUrun = new SepetUrun();
                        sepetUrun.UrunID = urunID;
                        sepetUrun.SepetID = sepet.SepetID;
                        sepetUrun.UrunAdet += ekleneceAdet;
                        eticaretDB.SepetUruns.InsertOnSubmit(sepetUrun);
                        eticaretDB.SubmitChanges();
                    }
                    else
                    {
                        sepetteVarmi.UrunAdet += ekleneceAdet;
                        eticaretDB.SubmitChanges();
                    }
                    lbl_urunDetayMesaj.Text = "Ürün Sepete Eklendi...";
                }
                else
                {
                    lbl_urunDetayMesaj.Text="Yeterli Sayıda Ürün Kalmadı...";
                }
            }
            else
            {
                Response.Redirect("UyeGiris.aspx");
            }
        }
    }
}