<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       
    <title></title>
    <link href="StyleSheet2.css" type="text/css" rel="stylesheet"/>
    <style type="text/css">
        #form1 {
            height: 602px;
            width: 927px;
        }
        #div {
            height: 599px;
            width: 894px;
        }
        #div1 {
            height: 361px;
            width: 732px;
        }
        #div2 {
            width: 154px;
        }
        .auto-style1 {
            height: -15px;
        }
        .auto-style2 {
            width: 100%;
            height: 197px;
        }
        .auto-style3 {
            height: 33px;
        }
        .auto-style4 {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto">
        <div class="anadiv" id="div">
          
    <div id="baslik">Hoşgeldiniz,<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <hr class="auto-style1" />
        
            <br />
        
            </div>

    <div id="tablo" class="auto-style1">
        <table class="auto-style2">
            <tr>
                <td>
                    <br />
                    Giriş Tarihiniz</td>
                <td>


                    <br />


            <eo:DatePicker ID="DatePicker1" runat="server" ControlSkinID="None" DayCellHeight="16" DayCellWidth="21" DayHeaderFormat="FirstLetter" DisabledDates="" GridLineColor="207, 217, 227" GridLineFrameVisible="False" GridLineVisible="True" PickerFormat="dd/MM/yyyy" SelectedDates="" TitleFormat="MMM yyyy" TitleLeftArrowHtml="&amp;lt;" TitleRightArrowHtml="&amp;gt;" VisibleDate="2013-07-01">
                <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea" />
                <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;" />
                <DayHeaderStyle CssText="font-size: 11px; font-family: verdana;height: 17px" />
                <DayStyle CssText="font-size: 11px; font-family: verdana;border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea" />
                <DayHoverStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                <SelectedDayStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
            </eo:DatePicker>

                </td>
            </tr>
            <tr>
                <td>Ülke Seçiniz</td>
                <td> <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="ulke" DataValueField="ulke" AppendDataBoundItems="true" OnDataBound="DropDownList1_DataBound">   
            </asp:DropDownList>
            <asp:TextBox ID="tbxUlkeEkle" runat="server" Height="23px" Visible="False" Width="79px"></asp:TextBox>
            <asp:LinkButton ID="lnkaddulke" runat="server" OnClick="ulkeekle" CssClass="gbutton">Ülke Ekle</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>Resim Ekle</td>
                <td>
            <asp:FileUpload ID="resimupload" runat="server" AllowMultiple="True" />
                </td>
            </tr>
            <tr>
                <td>Dosya Ekle</td>
                <td><asp:FileUpload ID="pdfupload" runat="server" />
                    <br />


            <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Açıklamalar</td>
                <td class="auto-style4"><asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="70px" Width="297px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style4">
            <asp:Button ID="btn_kaydet" runat="server" OnClick="btnkaydet" Text="Kaydet" CssClass="gbutton" />

                </td>
            </tr>
        </table>
        <br />
                  <br />
        <br />
    <asp:GridView ID="GridView2" runat="server" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="0" Height="96px" Width="1000px" CssClass="auto-style4">
    <Columns>
        <asp:TemplateField HeaderText="Veri No" Visible="False">
            <ItemTemplate>
                <asp:Label ID="t_lblID1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Kullanıcı Adı">
            <ItemTemplate>
                <asp:Label ID="t_lblkadi" runat="server" Text='<%# Bind("isim") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Gidilen Ülke">
            <EditItemTemplate>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="ulke" DataValueField="ulke">
                </asp:DropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="t_lblUlke" runat="server" Text='<%# Bind("ulke") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Gidiş Tarihi">
            <EditItemTemplate>
                <eo:DatePicker ID="t_dptarih1" runat="server" ControlSkinID="None" DayCellHeight="16" DayCellWidth="21" DayHeaderFormat="FirstLetter" DisabledDates="" GridLineColor="207, 217, 227" GridLineFrameVisible="False" GridLineVisible="True" Height="22px" PickerFormat="dd/MM/yyyy" SelectedDates="2013-07-17" TitleFormat="MMM yyyy" TitleLeftArrowHtml="&amp;lt;" TitleRightArrowHtml="&amp;gt;" VisibleDate="2013-07-01" Width="128px">
                    <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea" />
                    <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;" />
                    <DayHeaderStyle CssText="font-size: 11px; font-family: verdana;height: 17px" />
                    <DayStyle CssText="font-size: 11px; font-family: verdana;border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea" />
                    <DayHoverStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                    <SelectedDayStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                </eo:DatePicker>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="t_lbltarih" runat="server" Text='<%# Eval("tarih") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Resim">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("resim") %>' OnClick="LinkButton3_Click">Resimleri Göster</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Veri Değiştir" ShowHeader="False">
            <EditItemTemplate>
                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                &nbsp;<asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
            </EditItemTemplate>

            <ItemTemplate>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Edit">Düzenle</asp:LinkButton>
            </ItemTemplate>

        </asp:TemplateField>
        <asp:TemplateField HeaderText="Veri Sil" ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Doküman">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("pdf") %>'>indir</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Açıklamalar">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("aciklama") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("aciklama") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    
            </div>

    <div id="resimler">
        
    
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <br />
                  <br />
                  <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>

    
                  <asp:DataList ID="DDListResimler" runat="server" CellPadding="4" ForeColor="#333333" Height="52px" Width="273px" RepeatDirection="Horizontal" RepeatColumns="5">
                      <AlternatingItemStyle BackColor="White" />
                      <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                      <ItemStyle BackColor="#E3EAEB" />
                      <ItemTemplate>
                          <asp:Image ID="Image2" runat="server" ImageUrl='<%# (LinkButton7.CommandArgument)+Eval("Name") %>' />
                      </ItemTemplate>
                      <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
      </asp:DataList>
                  <br />

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewdatabaseConnectionString %>"  SelectCommand="SELECT [Ulke] FROM [ulkeler]"></asp:SqlDataSource>
        
    
        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton1_Click1" CssClass="gbutton">Çıkış Yap</asp:LinkButton>
                  </div>

    


    </div>

            </form>
</body>
</html>
