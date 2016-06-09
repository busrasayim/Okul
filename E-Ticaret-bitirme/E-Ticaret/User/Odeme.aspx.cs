using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret.User
{
    public partial class Odeme : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_urunAdet.Text = Request.Cookies["miktar"].Value + " " + "Ürün";
            lbl_toplamTutar.Text = Request.Cookies["tutar"].Value;
            lbl_odenecekMiktar.Text = Request.Cookies["odenecek"].Value;

            for(int i=2015;i<2040;i++)
            {
                drp_yil.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            DateTime month = Convert.ToDateTime("1/1/2015");
            for (int i = 0; i < 12; i++)
            {
                DateTime NextMont = month.AddMonths(i);
                ListItem list = new ListItem();
                list.Text = NextMont.ToString("MMMM");
                list.Value = NextMont.Month.ToString();
                drp_ay.Items.Add(list);
            }
        }

        protected void btn_Tamamla_Click(object sender, EventArgs e)
        {
            if ((txt_kartNo.Text != "") && (txt_kartSahibi.Text != "") && (txt_güvenlikKod.Text != ""))
            {
                // burada banka ile irtibata geçilir.
            
                string fAdres = Request.Cookies["FaturaAdres"].Value;
                string tAdres = Request.Cookies["TeslimatAdres"].Value;
                string kargo = Request.Cookies["kargoID"].Value;

                Siparis siparis = new Siparis();
                siparis.KullaniciID = int.Parse(Request.Cookies["Musteri"]["kullaniciID"]);
                siparis.KargoID = int.Parse(kargo);
                siparis.Tutar = Request.Cookies["tutar"].Value;
                siparis.FaturaAdresID = int.Parse(fAdres);
                siparis.TeslimatAdresID = int.Parse(tAdres);

                eticaretDB.Siparis.InsertOnSubmit(siparis);
                eticaretDB.SubmitChanges();

                Sepet sepet = eticaretDB.Sepets.SingleOrDefault(s => s.KullaniciID == int.Parse(Request.Cookies["Musteri"]["kullaniciID"]));
                sepet.Fiyat = "0";
                sepet.Durum = "bos";
                eticaretDB.SubmitChanges();

                IEnumerable<SepetUrun> sepetUrun = eticaretDB.SepetUruns.Where(su => su.SepetID == sepet.SepetID);
                for (int i = 0; i < sepetUrun.Count(); i++)
                {
                    SiparisUrun siparisUrun = new SiparisUrun();
                    siparisUrun.UrunID = sepetUrun.ElementAt(i).UrunID;
                    siparisUrun.SiparisID = siparis.SiparisID;
                    eticaretDB.SiparisUruns.InsertOnSubmit(siparisUrun);
                    eticaretDB.SubmitChanges();
                }

                eticaretDB.SepetUruns.DeleteAllOnSubmit(sepetUrun);
                eticaretDB.SubmitChanges();
                Response.Redirect(ResolveUrl("SiparisTamamlandi.aspx"));

            }
            else
            {
                // Boş olan bırakılması durumunda...
            }
        }
    }
}