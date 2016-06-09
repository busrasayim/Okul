using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class Default3 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    string komut;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn.ConnectionString = "Server=(localdb)\\Projects;Database=Newdatabase;Integrated Security=True;";
        conn.Open();
        
        Session["Giris_Yapildimi"] = "admin_girdi";
        if (Session["Giris_Yapildimi"].ToString() == "admin_girdi");
       // Label1.Text = Session["a_Kullanici"].ToString();
        else if (Session["Giris_Yapildimi"].ToString() == "kullanici_girdi")
            Response.Redirect("Default2.aspx");
        else
            Response.Redirect("Default.aspx");
        
        GridView1.ShowFooter = true;

        if (!IsPostBack)
        {
            komut = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'tablo1' ";
            SqlCommand mySqlCommand = new SqlCommand(komut, conn);
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
            DataSet myDataSet = new DataSet();
            mySqlDataAdapter.Fill(myDataSet);
            DropDownList1.DataSource = myDataSet;
            DropDownList1.DataTextField = "COLUMN_NAME";
            DropDownList1.DataValueField = "COLUMN_NAME";
            DropDownList1.DataBind();

            komut = "SELECT DISTINCT [" + DropDownList1.SelectedValue + "] FROM [tablo1] ";
            SqlCommand mySqlCommand1 = new SqlCommand(komut, conn);
            SqlDataAdapter mySqlDataAdapter1 = new SqlDataAdapter(mySqlCommand1);
            DataSet myDataSet1 = new DataSet();
            mySqlDataAdapter1.Fill(myDataSet1);
            DropDownList2.DataSource = myDataSet1;
            DropDownList2.DataTextField = DropDownList1.SelectedValue;
            DropDownList2.DataValueField = DropDownList1.SelectedValue;
            DropDownList2.DataBind();
            DropDownList2.Visible = true;

        }

    }



  
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        komut = "SELECT DISTINCT ["+DropDownList1.SelectedValue+"] FROM [tablo1] ";
        SqlCommand mySqlCommand = new SqlCommand(komut, conn);
        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet);
        DropDownList2.DataSource = myDataSet;
        DropDownList2.DataTextField = DropDownList1.SelectedValue;
        DropDownList2.DataValueField = DropDownList1.SelectedValue;
        DropDownList2.DataBind();
        DropDownList2.Visible = true;
}

    protected void TabloVeriAl()
    {
        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("SELECT * FROM tablo1 WHERE [" + DropDownList1.SelectedValue + "]='" + DropDownList2.SelectedValue + "'", conn);
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet);
        GridView1.DataSource = myDataSet.Tables[0];

        GridView1.DataBind();

    }
    protected void FooterOtoVeri()
    {
        Label lblisim = (Label)GridView1.FooterRow.FindControl("ft_lblkadi");
        Label lblulke = (Label)GridView1.FooterRow.FindControl("ft_lblulke");
        Label lbltarih = (Label)GridView1.FooterRow.FindControl("ft_lbltarih");
        TextBox tbxisim = (TextBox)GridView1.FooterRow.FindControl("ft_tbxkadi");
        TextBox tbxulke = (TextBox)GridView1.FooterRow.FindControl("ft_tbxulke");
        EO.Web.DatePicker dptarih = (EO.Web.DatePicker)GridView1.FooterRow.FindControl("ft_dptarih");

        if (DropDownList1.SelectedValue == "isim")
        {

            lblisim.Text = DropDownList2.SelectedValue;
            lblisim.Visible = true;
            tbxisim.Visible = false;
        }
        else if (DropDownList1.SelectedValue == "ulke")
        {
            lblulke.Text = DropDownList2.SelectedValue;
            lblulke.Visible = true;
            tbxulke.Visible = false;

        }
        else if (DropDownList1.SelectedValue == "tarih")
        {
            lbltarih.Text = DropDownList2.SelectedValue;
            lbltarih.Visible = true;
            dptarih.Visible = false;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TabloVeriAl();
        FooterOtoVeri();


    }
    protected void ft_btnVeriEkle_Click(object sender, EventArgs e)
    {
        TextBox tbxisim = (TextBox)GridView1.FooterRow.FindControl("ft_tbxkadi");
        TextBox tbxulke = (TextBox)GridView1.FooterRow.FindControl("ft_tbxulke");
        EO.Web.DatePicker textdate = (EO.Web.DatePicker)GridView1.FooterRow.FindControl("ft_dptarih");
        SqlCommand ft_veriekle = new SqlCommand("INSERT INTO tablo1(isim,ulke,tarih)VALUES('" + tbxisim.Text + "','" + tbxulke.Text + "','" + textdate.SelectedDate.ToLongDateString() + "')", conn);
        ft_veriekle.ExecuteNonQuery();
        TabloVeriAl();
    }
   
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView1.EditIndex = e.NewEditIndex;
        GridView1.ShowFooter = false;
        TabloVeriAl();
        
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            TabloVeriAl();
            FooterOtoVeri();

        }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("t_lblID");
        SqlCommand sil = new SqlCommand("DELETE FROM tablo1 Where id='"+lblID.Text +"' ", conn);
        sil.ExecuteNonQuery();
        TabloVeriAl();
        FooterOtoVeri();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("t_lblID");
            TextBox tbxisim = (TextBox)row.FindControl("t_tbxkadi");
            TextBox tbxulke = (TextBox)row.FindControl("t_tbxulke");
            EO.Web.DatePicker textdate = (EO.Web.DatePicker)row.FindControl("t_dptarih");

            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            SqlCommand cmd = new SqlCommand("update tablo1 set isim='" + tbxisim.Text + "',ulke='" + tbxulke.Text + "',tarih='" + textdate.SelectedDate.ToLongDateString()+ "' WHERE id='" + lblID.Text + "'", conn);
            cmd.ExecuteNonQuery();
            TabloVeriAl();


    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
      
        LinkButton4.CommandArgument = ((LinkButton)sender).CommandArgument;
        ResimleriDataListeDoldur(DDListResimler, LinkButton4.CommandArgument);

    }

    protected void ResimleriDataListeDoldur(DataList DDResimler, string ResimKlasor)
    {
        IList<FileInfo> ResimleriYakala = new List<FileInfo>();

        string[] Uzantilar = { ".jpg", ".JPG", ".gif", "GIF", "PNG", "JPEG", ".png", ".jpeg" };

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
    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        Response.Cookies["myCookie"].Expires = DateTime.Now.AddHours(-4);
        Session.Clear();
        Response.Redirect("Default.aspx");
    }
}
