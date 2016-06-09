using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            Kullanici user = new Kullanici();
            user = eticaretDB.Kullanicis.SingleOrDefault(k => k.KullaniciAd == kullaniciAd.Text && k.Parola == MD5Hash(sifre.Text));
            if (user != null)
            {
                Rol rol = eticaretDB.Rols.SingleOrDefault(r => r.RolID == user.RolID);
                loginMesaj.Text = "E-TİCARET SİTESİNE HOŞGELDİNİZ";
                girisDurum.Value = "1";

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, //Ticket versiyonu (şu andadaki güncel versiyon 1'dir)
                user.KullaniciAd, //ticket ile ilgili olan txtusername
                DateTime.Now, //şu anki zamanı alıyor.
                DateTime.Now.AddMinutes(30), //yaratılan cookie'nin zamanını 30 dakika olarak ayarlıyor.
                false, //yaratılan cookie'nin IsPErsistent özelliğini false yapıyor.
                rol.RolTipi,// kullanıcının rollerle ilgili bilgisini alıyor.
                FormsAuthentication.FormsCookiePath); // yaratılan cookie'nin yolunu belirtiyor.

                // FormsAuthenticationTicket ile yaratılan cookie'yi şifreliyoruz.
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                // Eğer FormsAuthenticationTicket ile yaratılan cookie'nin expiration süresi
                //sınırsız ise, bu cookie'ye ticket nesnesinin Expiration süresi atanıyor.
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);

                HttpCookie musteriCookie = new HttpCookie("Musteri");
                string adSoyad = user.Ad + " " + user.Soyad;
                musteriCookie.Values.Add("AdSoyad", adSoyad);
                musteriCookie.Values.Add("kullaniciID",user.KullaniciID.ToString());
                musteriCookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(musteriCookie);
            }
            else
                loginMesaj.Text = "Yanlış Kullanıcı Adı veya Şifre";
        }

        public string MD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
    }
}