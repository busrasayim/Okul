using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret.User
{
    public partial class SiparisTamamlandi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btn_alisveriDevam_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("../AnaSayfa.aspx"));
        }
    }
}