using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Giris_Yapildimi"] = "sifirlandi";
        conn.ConnectionString = "Server=(localdb)\\Projects;Database=Newdatabase;Integrated Security=True";
        conn.Open();
        if (conn.State == ConnectionState.Open)
            Label3.Text = "Bağlı";


        HttpCookie myCookie = Request.Cookies["myCookie"];



    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {




    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand kontrol = new SqlCommand("select * from tablo2 where kadi='" + TextBox1.Text + "'", conn);
        SqlDataReader verioku = kontrol.ExecuteReader();
        if (verioku.Read())
        {
            Label4.Text = "Kullanıcı Adı zaten var.";

        }

        else
        {

            verioku.Close();
            SqlCommand komut = new SqlCommand("INSERT INTO tablo2(kadi,pwd)VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "')", conn);
            if (TextBox1.Text == "")
                Label4.Text = "Kullanıcı adı boş olamaz.";
            else if (TextBox2.Text.Length < 6)
                Label4.Text = "Şifre en az 6 haneli olmalıdır.";
            else
            {
                komut.ExecuteNonQuery();
                Label4.Text = "Kayıt Başarılı!";
            }
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        bool kontrol = false;
        string grskmt;
        if(Label6.Visible)
            grskmt = "select * from admin where kadi='" + TextBox1.Text + "'and pwd Collate SQL_Latin1_General_CP1254_CS_AS ='" + TextBox2.Text + "'";
        else
            grskmt = "select * from tablo2 where kadi='" + TextBox1.Text + "'and pwd Collate SQL_Latin1_General_CP1254_CS_AS ='" + TextBox2.Text + "'";
        SqlCommand komut = new SqlCommand(grskmt, conn);
        SqlDataReader verioku = komut.ExecuteReader();
        while (verioku.Read())
            kontrol = true;
        verioku.Close();
        if (kontrol == true)
        {
            Label4.Text = "Giriş Başarılı";
            if (CheckBox1.Checked == true)
            {
                HttpCookie myCookies = new HttpCookie("myCookie");
                myCookies["Ad"] = TextBox1.Text;
                myCookies["Parola"] = TextBox2.Text;
                myCookies.Expires = DateTime.Now.AddHours(4);
                Response.Cookies.Add(myCookies);
                if (Label6.Visible)
                    Response.Redirect("Default3.aspx");
                else
                    Response.Redirect("Default2.aspx");
            }
            else
            {

                if (Label6.Visible)
                {
                    Session["Giris_Yapildimi"] = "admin_girdi";
                    Session["a_Kullanici"] = TextBox1.Text;
                    Response.Redirect("Default3.aspx");
                }
                else
                {
                    Session["Giris_Yapildimi"] = "kullanici_girdi";
                    Session["n_Kullanici"] = TextBox1.Text;
                    Response.Redirect("Default2.aspx");
                }
            }
        }
        else
            Label4.Text = "Giriş Başarısız";
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (LinkButton1.Text == "Kullanıcı Girişi")
        {
            Label3.Visible = false;
            Button3.Visible = true;
            Label6.Visible = false;
            CheckBox1.Visible = true;
            Label7.Visible = false;
            LinkButton1.Text = "Yönetici Girişi";
        }
        else
        {
            Label3.Visible = true;
            Button3.Visible = false;
            Label6.Visible = true;
            CheckBox1.Visible = false;
            Label7.Visible = true;
            LinkButton1.Text = "Kullanıcı Girişi";
        }

    }
}
    