using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div_yonetici.Visible = false;
            btn_yonetici.Visible = false;

            if ((Request.Cookies["Musteri"] != null) && (HttpContext.Current.User.Identity.IsAuthenticated))
            {
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
        }

        protected void Giris_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("UyeGiris.aspx"));
        }

        protected void Cikis_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut(); //Yetkilendirme işlemini sonlandırıyoruz.

            HttpCookie musteriAd = Request.Cookies["Musteri"]; // cookiesimizi okuduk
            musteriAd.Expires = DateTime.Now.AddMinutes(-30);
            Response.Cookies.Add(musteriAd); // cookies ekledik

            Response.Redirect(ResolveUrl("AnaSayfa.aspx"));
        }

        protected void btn_yonetici_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("Yonetici/UrunKayit.aspx"));
        }

        protected void btn_hesap_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("User/Hesabim.aspx"));
        }

        protected void btn_sepet_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("User/Sepetim.aspx"));
        }

        protected void btn_kayit_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("UyeOl.aspx"));
        }
    }
}