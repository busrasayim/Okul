<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="Sepetim.aspx.cs" Inherits="E_Ticaret.User.Sepetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SecenekIcerik" runat="server">
    <div id="div_siparis">
        <h2 style="text-align:center;">Sipariş Özeti</h2>
        <asp:Label ID="lbl_urunAdet" CssClass="urunAdet" runat="server"></asp:Label>

        <div style="background-color:#e4eef7">
            <h3 style="margin-left:10px">Toplam Tutar</h3>
            <h2 style="margin-left:10px;text-decoration:line-through;">
                <asp:Label ID="lbl_toplamTutar" runat="server"></asp:Label>
            </h2>
        </div>
        <asp:Table ID="tbl_indirim" CssClass="tblIndirim" runat="server"></asp:Table>
        <div style="background-color:#e4eef7">
            <h3 style="margin-left:10px">İndirimli Toplam Tutar</h3>
            <h1 style="margin-left:10px;color:red">
                <asp:Label ID="lbl_odenecekMiktar" runat="server"></asp:Label>
            </h1>
        </div>
        <asp:Button ID="btn_Tamamla" runat="server" Text="Alışverişi Tamamla >>" OnClick="btn_Tamamla_Click"  />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VitrinIcerik" runat="server">
    <div id="div_sepetim">
        <asp:HiddenField ID="hfSepetID" runat="server" />
        <span style="font-size:35px;color:#18116f;font-weight:600;margin-left:20px">Sepetim</span>
        <asp:Panel ID="pnl_sepetMesaj" Visible="false" CssClass="sepetimMesaj" runat="server">
              <asp:Label ID="lbl_sepetMesaj" runat="server" Text="Sepette Ürün Bulunmamaktadır..."></asp:Label>
        </asp:Panel>
        <asp:Table ID="tbl_sepet" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Ürün Resim</asp:TableHeaderCell>
                <asp:TableHeaderCell>Ürün Adı</asp:TableHeaderCell>
                <asp:TableHeaderCell>Ürün Bilgi</asp:TableHeaderCell>
                <asp:TableHeaderCell>Ürün Adeti</asp:TableHeaderCell>
                <asp:TableHeaderCell> Fiyat</asp:TableHeaderCell>
                <asp:TableHeaderCell></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="btn_alisveriDevam" runat="server" Text="Alışverişe Devam Et" OnClick="btn_alisveriDevam_Click" />
    </div>
</asp:Content>
