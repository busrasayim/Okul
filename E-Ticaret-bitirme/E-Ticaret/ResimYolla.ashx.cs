using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Ticaret
{
    /// <summary>
    /// Summary description for ResimYolla
    /// </summary>
    public class ResimYolla : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            EticaretDBDataContext eticaretDB = new EticaretDBDataContext();
            string imgID=context.Request.QueryString["imgID"];
            Resimler resim = eticaretDB.Resimlers.SingleOrDefault(r => r.ResimID ==int.Parse(imgID));
            context.Response.ContentType = "image/jpg";
            context.Response.BinaryWrite((byte[])resim.Data.ToArray());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}