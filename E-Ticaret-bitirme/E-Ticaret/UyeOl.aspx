<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.Master" CodeBehind="UyeOl.aspx.cs" Inherits="E_Ticaret.UyeOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="VitrinIcerik" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="Css/UyeForm.css" rel="stylesheet" />
</head>
<body>
    <div id="UyeForm">
        <table id="tbl_uyeForm">
            <tr>
                <td><h3>Ad</h3></td>
                <td><asp:TextBox  id="form_ad" class="textInput" runat="server"/></td>
            </tr>
            <tr>
                <td><h3>Soyad</h3></td>
                <td><asp:TextBox  id="form_soyad" class="textInput"  runat="server"/></td>
            </tr>
            <tr>
                <td><h3>Kullanıcı Adı</h3></td>
                <td><asp:TextBox  id="form_kullanici_adi" class="textInput" runat="server"/></td>
            </tr>
            <tr>
                <td><h3>E-Posta Adresi</h3></td>
                <td><asp:TextBox  id="form_eposta" class="textInput" runat="server"/></td>
            </tr>
            <tr>
                <td><h3>E-Posta Adresi(Tekrar)</h3></td>
                <td><asp:TextBox  id="form_eposta_onay" class="textInput" runat="server"/></td>
            </tr>
            <tr>
                <td><h3>Şifre</h3></td>
                <td><asp:TextBox TextMode="Password" id="form_sifre" class="textInput" runat="server"/></td>
            </tr>
            <tr>
                <td><h3>Şifre(Tekrar)</h3></td>
                <td> <asp:TextBox TextMode="Password" id="form_sifre_onay" class="textInput" runat="server"/></td>
            </tr>
            <tr>
                <td><h3>Adres</h3></td>
                <td><asp:TextBox  id="form_adres" class="textInput" runat="server"/></td>
            </tr>
            <tr>
                <td><h3>Telefon</h3></td>
                <td> <asp:TextBox  id="form_telefon" class="textInput" runat="server"/></td>
            </tr>
        </table>
        </div>
        <div class="uyeKonum">
            <table style="margin-left:auto;margin-right:auto">
                <tr>
                    <td><h3>Ülke</h3></td>
                    <td>
                        <asp:DropDownList ID="form_ulke" runat="server" DataSourceID="LinqDataSource1" DataTextField="UlkeAd" DataValueField="UlkeAd">
                            <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
                        </asp:DropDownList>

                        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="E_Ticaret.EticaretDBDataContext" EntityTypeName="" Select="new (UlkeAd)" TableName="Ulkes">
                        </asp:LinqDataSource>
                    </td>
                </tr>
                <tr>
                    <td><h3>Şehir</h3></td>
                    <td>
                       <asp:DropDownList ID="form_sehir" runat="server" DataSourceID="LinqDataSource2" DataTextField="SehirAd" DataValueField="SehirAd">
                           <asp:ListItem Value="-1">Seçiniz(Türkiye)</asp:ListItem>
                        </asp:DropDownList>
                
                        <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="E_Ticaret.EticaretDBDataContext" EntityTypeName="" Select="new (SehirAd)" TableName="Sehirs">
                        </asp:LinqDataSource>
                    </td>
                </tr>
                <tr>
                    <td><h3>Doğum Tarihi</h3></td>
                    <td>
                    <asp:DropDownList ID="form_dt_gun" Width="80" runat="server">
                        <asp:ListItem Value="01">1</asp:ListItem>
                        <asp:ListItem Value="02">2</asp:ListItem>
                        <asp:ListItem Value="03">3</asp:ListItem>
                        <asp:ListItem Value="04">4</asp:ListItem>
                        <asp:ListItem Value="05">5</asp:ListItem>
                        <asp:ListItem Value="06">6</asp:ListItem>
                        <asp:ListItem Value="07">7</asp:ListItem>
                        <asp:ListItem Value="08">8</asp:ListItem>
                        <asp:ListItem Value="09">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="31">31</asp:ListItem>
            
                    </asp:DropDownList>
                    <asp:DropDownList ID="form_dt_ay" Width="80" runat="server">
                        <asp:ListItem Value="1">Ocak</asp:ListItem>
                        <asp:ListItem Value="2">Şubat</asp:ListItem>
                        <asp:ListItem Value="3">Mart</asp:ListItem>
                        <asp:ListItem Value="4">Nisan</asp:ListItem>
                        <asp:ListItem Value="5">Mayıs</asp:ListItem>
                        <asp:ListItem Value="6">Haziran</asp:ListItem>
                        <asp:ListItem Value="7">Temmuz</asp:ListItem>
                        <asp:ListItem Value="8">Ağustos</asp:ListItem>
                        <asp:ListItem Value="9">Eylül</asp:ListItem>
                        <asp:ListItem Value="10">Ekim</asp:ListItem>
                        <asp:ListItem Value="11">Kasım</asp:ListItem>
                        <asp:ListItem Value="12">Aralık</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="form_dt_yil" Width="80" runat="server">
                        <asp:ListItem>1997</asp:ListItem>
                        <asp:ListItem>1996</asp:ListItem>
                        <asp:ListItem>1995</asp:ListItem>
                        <asp:ListItem>1994</asp:ListItem>
                        <asp:ListItem>1993</asp:ListItem>
                        <asp:ListItem>1992</asp:ListItem>
                        <asp:ListItem>1991</asp:ListItem>
                        <asp:ListItem>1990</asp:ListItem>
                        <asp:ListItem>1989</asp:ListItem>
                        <asp:ListItem>1988</asp:ListItem>
                        <asp:ListItem>1987</asp:ListItem>
                        <asp:ListItem>1986</asp:ListItem>
                        <asp:ListItem>1985</asp:ListItem>
                        <asp:ListItem>1984</asp:ListItem>
                        <asp:ListItem>1983</asp:ListItem>
                        <asp:ListItem>1982</asp:ListItem>
                        <asp:ListItem>1981</asp:ListItem>
                        <asp:ListItem>1980</asp:ListItem>
                        <asp:ListItem>1979</asp:ListItem>
                        <asp:ListItem>1978</asp:ListItem>
                        <asp:ListItem>1977</asp:ListItem>
                        <asp:ListItem>1976</asp:ListItem>
                        <asp:ListItem>1975</asp:ListItem>
                        <asp:ListItem>1974</asp:ListItem>
                        <asp:ListItem>1973</asp:ListItem>
                        <asp:ListItem>1972</asp:ListItem>
                        <asp:ListItem>1971</asp:ListItem>
                        <asp:ListItem>1970</asp:ListItem>
                        <asp:ListItem>1969</asp:ListItem>
                        <asp:ListItem>1968</asp:ListItem>
                        <asp:ListItem>1967</asp:ListItem>
                        <asp:ListItem>1966</asp:ListItem>
                        <asp:ListItem>1965</asp:ListItem>
                        <asp:ListItem>1964</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><h3>Cinsiyet</h3></td>
                    <td>
                        <asp:RadioButtonList ID="form_cinsiyet" runat="server">
                        <asp:ListItem Text="Kadın" Value="0" />
                        <asp:ListItem Text="Erkek" Value="1" />
                        </asp:RadioButtonList> 
                    </td>
                </tr>
            </table>
        <div style="width:80%;margin-left:auto;margin-right:auto">
        <p>Üyelik kaydımı oluşturarak:</p>
        <p><a href="#" rel="nofollow" target="_blank">Üyelik Sözleşmesi Koşulları</a>'nı ve 
           <a href="#" rel="nofollow" target="_blank">Gizlilik Politikası</a>'nı kabul ediyorum.
        </p>
       <asp:Button id="kayitOlButton" Text="Kayıt Ol" runat="server" OnClick="kayitOlButton_Click"></asp:Button>
    </div>
</body>
</html>
    </asp:Content>

