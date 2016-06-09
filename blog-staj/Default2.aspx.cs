using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class Default2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    bool dosyakontrol=true;
    protected void Page_Load(object sender, EventArgs e)
    {



        conn.ConnectionString = "Server=(localdb)\\Projects;Database=Newdatabase;Integrated Security=True;";
        conn.Open();
        HttpCookie myCookies = Request.Cookies["myCookie"];
        if (myCookies != null)
            Label1.Text = myCookies["Ad"];
        else if (Session["Giris_Yapildimi"].ToString() == "admin_girdi")
            Response.Redirect("Default3.aspx");
        else if (Session["Giris_Yapildimi"].ToString() == "kullanici_girdi")
            Label1.Text = Session["n_Kullanici"].ToString();
        else
            Response.Redirect("Default.aspx");


        if (!IsPostBack)
        {
            DatePicker1.SelectedDate = DateTime.Today.Date;
            TabloVeriAl();
        }
    }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {

        Response.Cookies["myCookie"].Expires = DateTime.Now.AddHours(-4);
        Session.Clear();
        Response.Redirect("Default.aspx");

    }


    protected void btnkaydet(object sender, EventArgs e)
    {
        string veriekle;
        veriekle = "INSERT INTO tablo1(isim,ulke,tarih,aciklama)VALUES('" + Label1.Text + "','" + DropDownList1.SelectedValue + "','" + DatePicker1.SelectedDate.ToLongDateString() + "','"+TextBox1.Text+"')";
        if (DropDownList1.SelectedValue == "Ülke Seçiniz")
            Label2.Text = "Lütfen Bir Ülke Seçin.";
        else
        {

            if (dosyakontrol)
            {
                SqlCommand komut = new SqlCommand(veriekle, conn);
                komut.ExecuteNonQuery();
                resimyukle();
                pdfyukle();
                Label2.Text = "İşlem veritabanına kaydedildi.";
                Response.Redirect("Default2.aspx");
            }
            else
                Label2.Text = "İşleminiz Kaydedilmedi. Lütfen Dosya Türlerini Doğru Seçtiğinize Emin Olun. ";
        }


    }
    protected void resimyukle()
    {
        if (resimupload.HasFile)
        {
            foreach (HttpPostedFile dosya in resimupload.PostedFiles)
            {
                string yol = @"dosyalar\resimler\" + Label1.Text + @"\" + DropDownList1.SelectedValue + @"\" + DatePicker1.SelectedDate.ToShortDateString() + @"\";
                string dosyaadi = Label1.Text + "_" + DatePicker1.SelectedDate.Day + DatePicker1.SelectedDate.Month + DatePicker1.SelectedDate.Year + "_" + DropDownList1.SelectedValue + "_" + dosya.FileName;
                Directory.CreateDirectory(Server.MapPath(yol));
                dosya.SaveAs(Server.MapPath(yol + dosyaadi));
                SqlCommand komut = new SqlCommand("UPDATE tablo1 set resim='" + yol + "' where isim='" + Label1.Text + "'and ulke='" + DropDownList1.SelectedValue + "'and tarih='" + DatePicker1.SelectedDate.ToLongDateString() + "' ", conn);
                komut.ExecuteNonQuery();
            }
        }

    }
    protected void pdfyukle()
    {
        if (pdfupload.HasFile)
        {

                string yol = @"dosyalar\pdf\" + Label1.Text + @"\" + DropDownList1.SelectedValue + @"\" + DatePicker1.SelectedDate.ToShortDateString() + @"\";
                string dosyaadi = Label1.Text + "_" + DatePicker1.SelectedDate.Day + DatePicker1.SelectedDate.Month + DatePicker1.SelectedDate.Year + "_" + DropDownList1.SelectedValue + "_" + pdfupload.FileName;
                Directory.CreateDirectory(Server.MapPath(yol));
                pdfupload.SaveAs(Server.MapPath(yol + dosyaadi));
                SqlCommand komut = new SqlCommand("UPDATE tablo1 set pdf ='" + yol + dosyaadi+ "' where isim='" + Label1.Text + "'and ulke='" + DropDownList1.SelectedValue + "'and tarih='" + DatePicker1.SelectedDate.ToLongDateString() + "' ", conn);
                komut.ExecuteNonQuery();
                dosyakontrol = true;
        }
    }
    protected void ulkeekle(object sender, EventArgs e)
    {
        if (lnkaddulke.Text == "Ekle")
        {
            SqlCommand uekle = new SqlCommand("INSERT INTO ulkeler(ulke) VALUES ('" + tbxUlkeEkle.Text + "')", conn);
            if (tbxUlkeEkle.Text == "")
                Label2.Text = "Ülke Adı Boş Olamaz.";
            else
            {
                SqlCommand kontrol = new SqlCommand("select * from ulkeler where ulke='" + tbxUlkeEkle.Text + "'", conn);
                SqlDataReader verioku = kontrol.ExecuteReader();
                if (verioku.Read())
                {
                    Label2.Text = "Ülke zaten mevcut.";

                }
                else
                {
                    verioku.Close();
                    uekle.ExecuteNonQuery();
                    tbxUlkeEkle.Visible = false;
                    Response.Redirect("Default2.aspx");
                }
            }
        }
        if (lnkaddulke.Text == "Ülke Ekle")
        {
            tbxUlkeEkle.Visible = true;
            lnkaddulke.Text = "Ekle";
        }


    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, "Ülke Seçiniz");

    }

 
    protected void ResimleriDataListeDoldur( DataList DDResimler, string ResimKlasor)
    {
        IList<FileInfo> ResimleriYakala = new List<FileInfo>();

        string[] Uzantilar = { ".jpg", ".JPG", ".gif","GIF","PNG","JPEG", ".png", ".jpeg" };

        FileInfo[] TumResimleriOku = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/" + ResimKlasor)).GetFiles();

        foreach (FileInfo Resimler in TumResimleriOku)
        {
            for (int i = 0; i < Uzantilar.Length; i++)
            {
                if (Uzantilar[i] == Resimler.Extension)
                {
                    ResimleriYakala.Add(Resimler);
                   
                }
            }
        }

        DDResimler.RepeatColumns = 2;
        DDResimler.DataSource = ResimleriYakala;
        DDResimler.DataBind();

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        LinkButton7.CommandArgument = ((LinkButton)sender).CommandArgument;
        ResimleriDataListeDoldur(DDListResimler, LinkButton7.CommandArgument);

    }

    protected void TabloVeriAl()
    {
        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("SELECT * FROM [tablo1] ORDER BY [id]", conn);
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet);
        GridView2.DataSource = myDataSet.Tables[0];
        GridView2.DataBind();
        if (GridView2.EditIndex == -1)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                GridViewRow row = (GridViewRow)GridView2.Rows[i];
                LinkButton lnkedit = (LinkButton)row.FindControl("LinkButton3");
                LinkButton lnkdel = (LinkButton)row.FindControl("LinkButton1");
                Label lblisim = (Label)row.FindControl("t_lblkadi");
                if (Label1.Text != lblisim.Text)
                {
                    lnkdel.Visible = false;
                    lnkedit.Visible = false;
                }
            }
        }
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView2.EditIndex = e.NewEditIndex;
        TabloVeriAl();

    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        TabloVeriAl();

    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView2.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("t_lblID1");
        SqlCommand sil = new SqlCommand("DELETE FROM tablo1 Where id='" + lblID.Text + "' ", conn);
        sil.ExecuteNonQuery();
        TabloVeriAl();
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row1 = (GridViewRow)GridView2.Rows[e.RowIndex];
        Label lblID1 = (Label)row1.FindControl("t_lblID1");
        DropDownList ddlulke1 = (DropDownList)row1.FindControl("DropDownList2");
        EO.Web.DatePicker textdate1 = (EO.Web.DatePicker)row1.FindControl("t_dptarih1");

        GridView2.EditIndex = -1;
        SqlCommand cmd = new SqlCommand("update tablo1 set ulke='" + ddlulke1.SelectedValue + "',tarih='" + textdate1.SelectedDate.ToLongDateString() + "' WHERE id='" + lblID1.Text + "'", conn);
        cmd.ExecuteNonQuery();
        TabloVeriAl();


    }
    protected void ft_btnVeriEkle_Click(object sender, EventArgs e)
    {
        TextBox tbxisim = (TextBox)GridView2.FooterRow.FindControl("ft_tbxkadi");
        TextBox tbxulke = (TextBox)GridView2.FooterRow.FindControl("ft_tbxulke");
        EO.Web.DatePicker textdate = (EO.Web.DatePicker)GridView2.FooterRow.FindControl("ft_dptarih");
        SqlCommand ft_veriekle = new SqlCommand("INSERT INTO tablo1(isim,ulke,tarih,aciklama)VALUES('" + tbxisim.Text + "','" + tbxulke.Text + "','" + textdate.SelectedDate.ToLongDateString() + "','"+TextBox1.Text+"')", conn);
        ft_veriekle.ExecuteNonQuery();
        TabloVeriAl();
    }



}
