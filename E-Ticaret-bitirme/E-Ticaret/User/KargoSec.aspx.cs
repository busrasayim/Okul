using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret.User
{
    public partial class KargoSec : System.Web.UI.Page
    {
        EticaretDBDataContext eticaretDB = new EticaretDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_urunAdet.Text = Request.Cookies["miktar"].Value + " " + "Ürün";
            lbl_toplamTutar.Text = Request.Cookies["tutar"].Value;
            lbl_odenecekMiktar.Text = Request.Cookies["odenecek"].Value;

            rpt_kargo.DataSource = eticaretDB.Kargos;
            rpt_kargo.DataBind();
        }

        protected void btn_Tamamla_Click(object sender, EventArgs e)
        {
            if (Request.Form["kargo"] != null)
            {
                Kargo kargo = new Kargo();
                string kargoID = Request.Form["kargo"].ToString();
                kargo = eticaretDB.Kargos.SingleOrDefault(k=>k.KargoID==int.Parse(kargoID));
                int odenecekMiktar = int.Parse(Request.Cookies["odenecek"].Value) + int.Parse(kargo.KargoFiyat);
                Response.Cookies["kargoID"].Value = kargoID;
                Response.Cookies["kargoID"].Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies["odenecek"].Value = odenecekMiktar.ToString();

                Response.Redirect(ResolveUrl("Odeme.aspx"));
            }
            else
            {
                
            }
        }
    }
}