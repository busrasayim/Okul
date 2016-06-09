using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret.User
{
    public partial class Teslimat : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string kullaniciID = Request.Cookies["Musteri"]["kullaniciID"];
            lbl_urunAdet.Text = Request.Cookies["miktar"].Value + " " + "Ürün";
            lbl_toplamTutar.Text = Request.Cookies["tutar"].Value;
            lbl_odenecekMiktar.Text = Request.Cookies["odenecek"].Value;


            if (!Page.IsPostBack)
            {
                btn_tadresKayit.Visible = false;
                btn_fadresKayit.Visible = false;

                drp_adreslerTeslimat.DataSource = eticaretDB.Adreslers.Where(a => a.KullaniciID == int.Parse(kullaniciID));
                drp_adreslerTeslimat.DataTextField = "AdesAd";
                drp_adreslerTeslimat.DataValueField = "AdresID";
                drp_adreslerTeslimat.DataBind();

                drp_adreslerFatura.DataSource = eticaretDB.Adreslers.Where(a => a.KullaniciID == int.Parse(kullaniciID)); ;
                drp_adreslerFatura.DataTextField = "AdesAd";
                drp_adreslerFatura.DataValueField = "AdresID";
                drp_adreslerFatura.DataBind();

                drp_tulke.DataSource = eticaretDB.Ulkes;
                drp_tulke.DataTextField = "UlkeAd";
                drp_tulke.DataValueField = "UlkeID";
                drp_tulke.DataBind();
                drp_tulke.SelectedValue = "24";

                drp_tsehir.DataSource = eticaretDB.Sehirs.Where(s => s.UlkeID == int.Parse(drp_tulke.SelectedValue)); ;
                drp_tsehir.DataTextField = "SehirAd";
                drp_tsehir.DataValueField = "SehirID";
                drp_tsehir.DataBind();

                drp_fUlke.DataSource = eticaretDB.Ulkes;
                drp_fUlke.DataTextField = "UlkeAd";
                drp_fUlke.DataValueField = "UlkeID";
                drp_fUlke.DataBind();
                drp_fUlke.SelectedValue = "24";

                drp_fSehir.DataSource = eticaretDB.Sehirs.Where(s => s.UlkeID == int.Parse(drp_fUlke.SelectedValue)); ;
                drp_fSehir.DataTextField = "SehirAd";
                drp_fSehir.DataValueField = "SehirID";
                drp_fSehir.DataBind();
            }
            

        }

        protected void cb_fatura_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_fatura.Checked)
            {
                btn_fadresEkle.Visible = true;
                btn_fadresKayit.Visible = false;

                txt_fadresAd.Text = txt_tadresAD.Text;
                drp_fUlke.SelectedValue = drp_tulke.SelectedValue;
                drp_fSehir.SelectedValue = drp_tsehir.SelectedValue;
                txt_fAdres.Text = txt_tAdres.Text;
                txt_fTel.Text = txt_tTel.Text;
                drp_adreslerFatura.SelectedValue = drp_adreslerTeslimat.SelectedValue;
            }
        }

        protected void drp_tulke_SelectedIndexChanged(object sender, EventArgs e)
        {
            drp_tsehir.DataSource = eticaretDB.Sehirs.Where(s => s.UlkeID == int.Parse(drp_tulke.SelectedValue));
            drp_tsehir.DataTextField = "SehirAd";
            drp_tsehir.DataValueField = "SehirID";
            drp_tsehir.DataBind();
        }

        protected void drp_fUlke_SelectedIndexChanged(object sender, EventArgs e)
        {
            drp_fSehir.DataSource = eticaretDB.Sehirs.Where(s => s.UlkeID == int.Parse(drp_fUlke.SelectedValue));
            drp_fSehir.DataTextField = "SehirAd";
            drp_fSehir.DataValueField = "SehirID";
            drp_fSehir.DataBind();
        }

        protected void btn_Tamamla_Click(object sender, EventArgs e)
        {
            Response.Cookies["TeslimatAdres"].Value = drp_adreslerTeslimat.SelectedValue;
            Response.Cookies["FaturaAdres"].Value = drp_adreslerFatura.SelectedValue;
            Response.Cookies["TeslimatAdres"].Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies["FaturaAdres"].Expires = DateTime.Now.AddMinutes(30); 
            Response.Redirect(ResolveUrl("KargoSec.aspx"));
        }

        protected void btn_tadresEkle_Click(object sender, EventArgs e)
        {
            btn_tadresKayit.Visible = true;
            btn_tadresEkle.Visible = false;
            txt_tadresAD.Text = "";
            drp_tulke.SelectedValue = "24";
            txt_tAdres.Text = "";
            txt_tTel.Text = "";
        }

        protected void btn_tadresKayit_Click(object sender, EventArgs e)
        {
            string adresAd = txt_tadresAD.Text;
            string adresTarif = txt_tAdres.Text;
            string tel = txt_tTel.Text;
            if ((adresAd != "") && (adresTarif != "") && (tel != ""))
            {
                string kullaniciID = Request.Cookies["Musteri"]["kullaniciID"];
                Adresler adres = new Adresler();
                adres.AdesAd = adresAd;
                adres.AdresTarif = adresTarif;
                adres.Telefon = tel;
                adres.SehirID = int.Parse(drp_tsehir.SelectedValue);
                adres.KullaniciID = int.Parse(kullaniciID);
                eticaretDB.Adreslers.InsertOnSubmit(adres);
                eticaretDB.SubmitChanges();

                drp_adreslerTeslimat.DataSource = eticaretDB.Adreslers.Where(a => a.KullaniciID == int.Parse(kullaniciID));
                drp_adreslerTeslimat.DataTextField = "AdesAd";
                drp_adreslerTeslimat.DataValueField = "AdresID";
                drp_adreslerTeslimat.DataBind();

                drp_adreslerFatura.DataSource = eticaretDB.Adreslers.Where(a => a.KullaniciID == int.Parse(kullaniciID)); ;
                drp_adreslerFatura.DataTextField = "AdesAd";
                drp_adreslerFatura.DataValueField = "AdresID";
                drp_adreslerFatura.DataBind();

                btn_tadresKayit.Visible = false;
                btn_tadresEkle.Visible = true;

                drp_adreslerTeslimat.SelectedValue = adres.AdresID.ToString();

                lbl_mesaj.Text = "Adres Kaydı Başarılı...";

            }
            else
            {
                lbl_mesaj.Text = "Teslim Adresinde Boş Alan Bıraktınız...";
            }
        }

        protected void btn_fadresKayit_Click(object sender, EventArgs e)
        {
            string adresAd = txt_fadresAd.Text;
            string adresTarif = txt_fAdres.Text;
            string tel = txt_fTel.Text;

            if ((adresAd != "") && (adresTarif != "") && (tel != ""))
            {
                string preTeslimat = drp_adreslerTeslimat.SelectedValue;
                string kullaniciID = Request.Cookies["Musteri"]["kullaniciID"];
                Adresler adres = new Adresler();
                adres.AdesAd = adresAd;
                adres.AdresTarif = adresTarif;
                adres.Telefon = tel;
                adres.SehirID = int.Parse(drp_tsehir.SelectedValue);
                adres.KullaniciID = int.Parse(kullaniciID);
                eticaretDB.Adreslers.InsertOnSubmit(adres);
                eticaretDB.SubmitChanges();

                drp_adreslerFatura.DataSource = eticaretDB.Adreslers.Where(a => a.KullaniciID == int.Parse(kullaniciID)); ;
                drp_adreslerFatura.DataTextField = "AdesAd";
                drp_adreslerFatura.DataValueField = "AdresID";
                drp_adreslerFatura.DataBind();

                drp_adreslerTeslimat.DataSource = eticaretDB.Adreslers.Where(a => a.KullaniciID == int.Parse(kullaniciID));
                drp_adreslerTeslimat.DataTextField = "AdesAd";
                drp_adreslerTeslimat.DataValueField = "AdresID";
                drp_adreslerTeslimat.DataBind();

                btn_fadresKayit.Visible = false;
                btn_fadresEkle.Visible = true;

                drp_adreslerFatura.SelectedValue = adres.AdresID.ToString();
                drp_adreslerTeslimat.SelectedValue = preTeslimat;

                lbl_mesaj.Text = "Adres Kaydı Başarılı...";
            }
            else
            {
                lbl_mesaj.Text = "Fatura Adresinde Boş Alan Bıraktınız...";
            }
        }

        protected void btn_fadresEkle_Click(object sender, EventArgs e)
        {
            btn_fadresKayit.Visible = true;
            btn_fadresEkle.Visible = false;
            cb_fatura.Checked = false; 

            txt_fadresAd.Text = "";
            drp_fUlke.SelectedValue = "24";
            txt_fAdres.Text = "";
            txt_fTel.Text = "";
        }

        protected void drp_adreslerTeslimat_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_tadresKayit.Visible = false;
            btn_tadresEkle.Visible = true;
            Adresler adres = eticaretDB.Adreslers.SingleOrDefault(a=>a.AdresID==int.Parse(drp_adreslerTeslimat.SelectedValue));
            Sehir sehir = eticaretDB.Sehirs.SingleOrDefault(s=>s.SehirID==adres.SehirID);
            txt_tadresAD.Text = adres.AdesAd;
            drp_tulke.SelectedValue = sehir.UlkeID.ToString();
            drp_tsehir.SelectedValue = adres.SehirID.ToString();
            txt_tAdres.Text = adres.AdresTarif;
            txt_tTel.Text = adres.Telefon;

        }

        protected void drp_adreslerFatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_fadresKayit.Visible = false;
            btn_fadresEkle.Visible = true;
            Adresler adres = eticaretDB.Adreslers.SingleOrDefault(a => a.AdresID == int.Parse(drp_adreslerFatura.SelectedValue));
            Sehir sehir = eticaretDB.Sehirs.SingleOrDefault(s => s.SehirID == adres.SehirID);
            txt_fadresAd.Text = adres.AdesAd;
            drp_fUlke.SelectedValue = sehir.UlkeID.ToString();
            drp_fSehir.SelectedValue = adres.SehirID.ToString();
            txt_fAdres.Text = adres.AdresTarif;
            txt_fTel.Text = adres.Telefon;
        }

    }
}