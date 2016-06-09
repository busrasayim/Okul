using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret
{
    public partial class UyeOl : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();
       
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
        protected void kayitOlButton_Click(object sender, EventArgs e)
        {
            Kullanici yeniUye=new Kullanici();
            String []form=new String[10];
            yeniUye.Ad= form_ad.Text;
            yeniUye.Soyad = form_soyad.Text;
            yeniUye.KullaniciAd = form_kullanici_adi.Text;
            if (form_eposta_onay.Text == form_eposta.Text)
                yeniUye.EPosta = form_eposta.Text;
            else
                return;
            if (form_sifre.Text == form_sifre_onay.Text)
                yeniUye.Parola = MD5Hash(form_sifre.Text);
            else
                return;
            yeniUye.Adres = form_adres.Text;
            yeniUye.UlkeID = form_ulke.SelectedIndex+1;
            yeniUye.SehirID = form_sehir.SelectedIndex+1;
            yeniUye.Telefon = form_telefon.Text;
            yeniUye.DogumTarih = form_dt_gun.SelectedValue.ToString()+"."+form_dt_ay.SelectedValue.ToString()+"."+form_dt_yil.SelectedValue.ToString();
            yeniUye.Cinsiyet=(byte)Convert.ToInt32(form_cinsiyet.SelectedValue.ToString());
            yeniUye.KayitTarih = DateTime.Now;
            yeniUye.RolID = 2;
            eticaretDB.Kullanicis.InsertOnSubmit(yeniUye);
            eticaretDB.SubmitChanges();

            Sepet sepet = new Sepet();
            sepet.KullaniciID = yeniUye.KullaniciID;
            sepet.Fiyat = "0";
            sepet.Durum = "bos";
            eticaretDB.Sepets.InsertOnSubmit(sepet);
            eticaretDB.SubmitChanges();
            Response.Redirect("UyeGiris.aspx");

        }
    }
}