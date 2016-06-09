<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="KargoSec.aspx.cs" Inherits="E_Ticaret.User.KargoSec" %>
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
        <asp:Button ID="btn_Tamamla" runat="server" Text="Devam >>" OnClick="btn_Tamamla_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VitrinIcerik" runat="server">
    <script>
       $(document).ready(function (e) {
           /* $(':radio').bind('change', function () {
                var th = $(this), id = th.attr('id');
                //alert(th);
                if (th.is(':checked')) {
                    $(':radio[id="' + id + '"]').not($(this)).attr('checked', false);
                }
                else {
                    $(':radio[id="' + id + '"]').not($(this)).attr('checked', true);
                }
            });*/
        });
    </script>
    <div class="alisverisTamamla">
        <div class="baslik">
            <h1>Kargo Seçimi</h1>
        </div>
        <div id="kargo" style="overflow:scroll">
            <table id="tbl_kargo">
                <asp:Repeater ID="rpt_kargo" runat="server">
                    <HeaderTemplate>
                        <tr>
                            <td>
                                <strong><font size="4" face="Verdana, Arial, Helvetica, sans-serif">
                                        Kargo Ad
                                </font></strong>
                            </td>
                            <td>
                                <strong><font size="4" face="Verdana, Arial, Helvetica, sans-serif">
                                        Açıklama
                                </font></strong>
                            </td>
                            <td>
                                <strong><font size="4" face="Verdana, Arial, Helvetica, sans-serif">
                                        Fiyat
                                </font></strong>
                            </td>
                            <td>
                                <strong><font size="4" face="Verdana, Arial, Helvetica, sans-serif">
                                        Seçim
                                </font></strong>
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr bgcolor="#DDFFD7">
                            <td>
                                <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%# DataBinder.Eval(Container.DataItem, "KargoAdi") %>
                                 </font>
                            </td>
                            <td>
                                <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%# DataBinder.Eval(Container.DataItem, "KargoAciklama") %>
                                 </font>
                            </td>
                            <td>
                                <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%# DataBinder.Eval(Container.DataItem, "KargoFiyat")+" "+"TL" %>
                                </font>
                            </td>
                            <td>
                                <input type="radio" name="kargo" value='<%# DataBinder.Eval(Container.DataItem, "KargoID") %>' />                              
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr bgcolor="#E8F5FF">
                            <td>
                                <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%# DataBinder.Eval(Container.DataItem, "KargoAdi") %>
                                 </font>
                            </td>
                            <td>
                                <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%# DataBinder.Eval(Container.DataItem, "KargoAciklama") %>
                                 </font>
                            </td>
                            <td>
                                <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%# DataBinder.Eval(Container.DataItem, "KargoFiyat")+" "+"TL" %>
                                </font>
                            </td>
                            <td>
                                <input type="radio" name="kargo" value='<%# DataBinder.Eval(Container.DataItem, "KargoID") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
