<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Teslimat.aspx.cs" Inherits="E_Ticaret.User.Teslimat" %>
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
         <asp:Button ID="btn_Tamamla" runat="server" Text="Devam >>" OnClick="btn_Tamamla_Click"   />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VitrinIcerik" runat="server">
    <div class="alisverisTamamla">

        <asp:Panel ID="adresYok" runat="server">
            <div id="teslimat">
                <div class="baslik">
                    <h1>Teslimat Adresi</h1>
                </div>
                <div class="icerik">
                    <table>
                        <tr>
                            <td><h2>Adres Seç</h2></td>
                            <td>:</td>
                            <td><asp:DropDownList ID="drp_adreslerTeslimat"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="drp_adreslerTeslimat_SelectedIndexChanged"></asp:DropDownList></td>
                            <td><asp:Button ID="btn_tadresEkle" runat="server" CssClass="btn_adres" Text="+ Yeni Adres" OnClick="btn_tadresEkle_Click" /></td>
                        </tr>
                        <tr>
                            <td><h3>Adres Adı</h3></td>
                            <td>:</td>
                            <td><asp:TextBox ID="txt_tadresAD" runat="server" Height="17px" Width="250px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><h3>Ülke</h3></td>
                            <td>:</td>
                            <td><asp:DropDownList ID="drp_tulke"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="drp_tulke_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td><h3>Şehir</h3></td>
                            <td>:</td>
                            <td><asp:DropDownList ID="drp_tsehir" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td><h3>Adres</h3></td>
                            <td>:</td>
                            <td><asp:TextBox ID="txt_tAdres" runat="server" Height="65px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><h3>Telelfon (Cep)</h3></td>
                            <td>:</td>
                            <td><asp:TextBox ID="txt_tTel" runat="server"></asp:TextBox></td>
                            <td><asp:Button ID="btn_tadresKayit" CssClass="btn_adres"  runat="server" Text="Kaydet" OnClick="btn_tadresKayit_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="fatura">
                <div class="baslik">
                    <h1>Fatura Adresi</h1>
                    <table style="float:right;color:#14185c;font-size:18px;"> 
                        <tr>
                            <td><strong>Teslimat adresi ile aynı </strong></td>
                            <td>:</td>
                            <td><asp:CheckBox ID="cb_fatura" runat="server" AutoPostBack="true" OnCheckedChanged="cb_fatura_CheckedChanged" /></td>
                        </tr>
                    </table>
                </div>
                <div class="icerik">
                    <table>
                        <tr>
                            <td><h2>Adres Seç</h2></td>
                            <td>:</td>
                            <td><asp:DropDownList ID="drp_adreslerFatura" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drp_adreslerFatura_SelectedIndexChanged"></asp:DropDownList></td>
                            <td><asp:Button ID="btn_fadresEkle" runat="server" CssClass="btn_adres" Text="+ Yeni Adres" OnClick="btn_fadresEkle_Click" /></td>
                        </tr>
                        <tr>
                            <td><h3>Adres Adı</h3></td>
                            <td>:</td>
                            <td><asp:TextBox ID="txt_fadresAd" runat="server" Height="17px" Width="250px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><h3>Ülke</h3></td>
                            <td>:</td>
                            <td><asp:DropDownList ID="drp_fUlke" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drp_fUlke_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td><h3>Şehir</h3></td>
                            <td>:</td>
                            <td><asp:DropDownList ID="drp_fSehir" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td><h3>Adres</h3></td>
                            <td>:</td>
                            <td><asp:TextBox ID="txt_fAdres" runat="server" Height="65px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><h3>Telelfon (Cep)</h3></td>
                            <td>:</td>
                            <td><asp:TextBox ID="txt_fTel" runat="server"></asp:TextBox></td>
                            <td><asp:Button ID="btn_fadresKayit" CssClass="btn_adres" runat="server" Text="Kaydet" OnClick="btn_fadresKayit_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <div style="float:left;width:90%;height:50px;">
            <font size="5" face="Verdana, Arial, Helvetica, sans-serif">
                <asp:Label ID="lbl_mesaj" runat="server" Text=""></asp:Label>
            </font>
        </div>
    </div>
</asp:Content>
