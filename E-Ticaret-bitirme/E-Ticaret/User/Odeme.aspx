<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Odeme.aspx.cs" Inherits="E_Ticaret.User.Odeme" %>
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
        <asp:Button ID="btn_Tamamla" runat="server" Text="Siparişi Tamamla >>" OnClick="btn_Tamamla_Click"/>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VitrinIcerik" runat="server">
    <div style="width:100%;height:350px;border:solid 1px;color:#18116f;margin-top:20px;">
        <div class="baslik">
            <h1>Ödeme Bilgileri</h1>
        </div>
        <div id="odeme">
            <table id="tbl_odeme">
                <tr>
                    <td>
                        <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                            Kart Numarası
                        </font>
                    </td>
                    <td><asp:TextBox ID="txt_kartNo" runat="server" Height="25px" Width="230px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                            Son Kullanma Tarihi
                        </font>
                    </td>
                    <td>
                        <asp:DropDownList ID="drp_ay" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="drp_yil" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                            Güvenlik Kodu
                        </font>
                    </td>
                    <td><asp:TextBox ID="txt_güvenlikKod" runat="server" Height="25px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                            Kart Üzerindeki İsim
                        </font>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_kartSahibi" runat="server" Height="25px" Width="230px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
