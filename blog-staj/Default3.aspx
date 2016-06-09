<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet3.css" type="text/css" rel="stylesheet"/>
    <style type="text/css">
        .auto-style1 {
            height: 16px ;
            width: auto;
            margin-bottom: 5px;
        }
        </style>
</head>
<body>
  <form id="form1" runat="server">
    <div style="height: 475px">
    
        <div class="auto-style1">
          Hoşgeldin,<asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
        <hr />
        <div class="body">
            <br />
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Height="17px" Width="185px">
        </asp:DropDownList>
            <br />
        <asp:DropDownList ID="DropDownList2" runat="server" Width="185px" Visible="False">
        </asp:DropDownList>
            <br />
        <asp:Button ID="Button1" runat="server" Text="Kaydet" OnClick="Button1_Click" />
    
        
            <br />
    
        
        <asp:Label ID="Label2" runat="server" Text="Label2" Visible="False"></asp:Label>
            <br />
            <br />
    
        
            <br />
            <br />
    
        
    <asp:GridView ID="GridView1" runat="server" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="0" Width="1000px">
    <Columns>
        <asp:TemplateField HeaderText="Veri No">
            <ItemTemplate>
                <asp:Label ID="t_lblID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Kullanıcı Adı">
            <EditItemTemplate>
                <asp:TextBox ID="t_tbxkadi" runat="server" Text='<%# Bind("isim") %>'></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="ft_tbxkadi" runat="server"></asp:TextBox>
                <asp:Label ID="ft_lblkadi" runat="server" Visible="False"></asp:Label>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="t_lblkadi" runat="server" Text='<%# Bind("isim") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Gidilen Ülke">
            <EditItemTemplate>
                <asp:TextBox ID="t_tbxulke" runat="server" Text='<%# Bind("ulke") %>'></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="ft_tbxulke" runat="server"></asp:TextBox>
                <asp:Label ID="ft_lblulke" runat="server" Visible="False"></asp:Label>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="t_lblUlke" runat="server" Text='<%# Bind("ulke") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Gidiş Tarihi">
            <EditItemTemplate>
                <eo:DatePicker ID="t_dptarih" runat="server" ControlSkinID="None" DayCellHeight="16" DayCellWidth="21" DayHeaderFormat="FirstLetter" DisabledDates="" GridLineColor="207, 217, 227" GridLineFrameVisible="False" GridLineVisible="True" Height="22px" PickerFormat="dd/MM/yyyy" SelectedDates="" TitleFormat="MMM yyyy" TitleLeftArrowHtml="&amp;lt;" TitleRightArrowHtml="&amp;gt;" VisibleDate="2013-07-01" Width="128px">
                    <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea" />
                    <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;" />
                    <DayHeaderStyle CssText="font-size: 11px; font-family: verdana;height: 17px" />
                    <DayStyle CssText="font-size: 11px; font-family: verdana;border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea" />
                    <DayHoverStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                    <SelectedDayStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                </eo:DatePicker>
            </EditItemTemplate>
            <FooterTemplate>
                <eo:DatePicker ID="ft_dptarih" runat="server" ControlSkinID="None" DayCellHeight="16" DayCellWidth="21" DayHeaderFormat="FirstLetter" DisabledDates="" GridLineColor="207, 217, 227" GridLineFrameVisible="False" GridLineVisible="True" Height="21px" PickerFormat="dd/MM/yyyy" SelectedDates="" TitleFormat="MMM yyyy" TitleLeftArrowHtml="&amp;lt;" TitleRightArrowHtml="&amp;gt;" VisibleDate="2013-07-01" Width="128px">
                    <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea" />
                    <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;" />
                    <DayHeaderStyle CssText="font-size: 11px; font-family: verdana;height: 17px" />
                    <DayStyle CssText="font-size: 11px; font-family: verdana;border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea" />
                    <DayHoverStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                    <SelectedDayStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                </eo:DatePicker>
                <asp:Label ID="ft_lbltarih" runat="server" Text="Label" Visible="False"></asp:Label>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="t_lbltarih" runat="server" Text='<%# Eval("tarih") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Açıklama">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("aciklama") %>' TextMode="MultiLine"></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("aciklama") %>' TextMode="MultiLine"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("aciklama") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Resim">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("resim") %>' OnClick="LinkButton3_Click">Resim Göster</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Doküman">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("pdf") %>'>Doküman Göster</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Veri Değiştir" ShowHeader="False">
            <EditItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
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
    
    </div>
   
    <div style="height: 475px">
    
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="gbutton">Çıkış Yap</asp:LinkButton>
    
        <br />
    
        <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
    
        <asp:DataList ID="DDListResimler" runat="server">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# (LinkButton4.CommandArgument)+Eval("Name") %>' />
            </ItemTemplate>
        </asp:DataList>
    
    </div>
       </form>
    
   
</body>
</html>
