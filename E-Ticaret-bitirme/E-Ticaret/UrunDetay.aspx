<%@ Page Language="C#" AutoEventWireup="true" ClientIDMode="Static" CodeBehind="UrunDetay.aspx.cs" Inherits="E_Ticaret.UrunDetay" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style=" background-image: url('../../image/web-site-back.jpg');background-size:100% 2000px;">
<head runat="server">
    <title></title>
    <script src="Js/jquery-2.1.3.min.js"></script>
    <script src="Js/jsCarousel.js"></script>
    <script src="Js/UrunDetay.js"></script>
    <script src="Js/modernizr.js"></script>
    <script src="Js/main.js"></script>
    
    <link href='http://fonts.googleapis.com/css?family=PT+Sans:400,700' rel='stylesheet' type='text/css'/>

    <link href="Css/Master.css" rel="stylesheet" />
    <link href="Css/UrunDetay.css" rel="stylesheet" />
    <link href="Css/jsCarousel.css" rel="stylesheet" />
    <link href="Css/reset.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
   
</head>
<body>
    <div style="margin-left:auto;margin-right:auto;width:90%;height:100%">
        <form id="form1" runat="server">
            <div style="width:100%;height:220px">
                <div id="logo_secenek">
                    <div id="logo"  onclick="location.href='../Anasayfa.aspx'">
                        <div id="logo_baslik" style="width:100%;height:50px"><span>E-TİCARET</span></div>
                        <div style="width:100%;height:150px;"><img src="image/logo_e-ticaret.png" style="width:100%;height:150px"/></div>              
                    </div>
                </div>
                <div id="baslik_vitrin">
                    <div id="baslik">
                        <div style="width:100%;height:50%">
                            <div class="arama">
                                <div id="div_textAra"><input id="input_ara" type="text"/></div>
                                <div class="div_araButon"><asp:Button ID="btn_ara" runat="server"/></div>
                            </div>
                            <div id="div_kullaniciIsllem">
                                <div id="div_hesap">                  
                                    <asp:Button ID="btn_hesap" Text="Hesabım" runat="server" OnClick="btn_hesap_Click" />
                                </div>
                                <div id="div_sepet">
                                    <asp:Button ID="btn_sepet" Text="Sepetim" runat="server" OnClick="btn_sepet_Click" />
                                </div>
                                <asp:Panel ID="div_yonetici" runat="server">
                                    <asp:Button ID="btn_yonetici" runat="server" Text="Yönetici" OnClick="btn_yonetici_Click" />
                                </asp:Panel>
                            </div>
                            <div id="div_girisCikis">
                                <div id="div_giris">
                                    <asp:Button ID="Giris" CssClass="btn_giris" runat="server" OnClick="Giris_Click"/>
                                    <asp:Button ID="Cikis" CssClass="btn_cikis" runat="server" OnClick="Cikis_Click" />
                                </div>
                                 <div id="div_kayit">
                                     <asp:Button ID="btn_kayit" Text="Kayıt Ol" runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div style="width:100%;height:50%">
                            <asp:Label ID="lbl_kullaniciRol" runat="server" Text=""></asp:Label>
                            <ul id="ul_menu">
                                <li><a>Markalar</a></li>
                                <li><a>En Çok Satanlar</a></li>
                                <li><a>İndirimde Olanlar</a></li>
                                <li><a>En Çok Yorum Alanlar</a></li>
                                <li><a>En Yeniler</a></li>
                            </ul>        
                        </div>
                    </div>
                </div>
            </div>
            <div id="urunDetay">
                <div style="width:100%;height:550px">
                    <div id="urunGorsel">
                        <div id="resimGoster" runat="server"></div>
                        <div id="resimSec">
                            <div id="wrapper">
                                <div id="jsCarousel" runat="server"></div>
                             </div>
                        </div>  
                    </div>
                    <div id="urunBilgi">
                        <div style="display: table-cell;vertical-align: middle;text-align: center">
                            <div class="div_urunBilgi">
                                <asp:Label ID="lbl_urunAd" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="div_urunBilgi">
                                <asp:Label ID="lbl_urunTanim" CssClass="urunIcerik" runat="server" Text=""></asp:Label>
                            </div>
                            <div  class="div_urunBilgi">
                                <span class="tableBaslik">Özellik Bilgileri</span>
                                <asp:Table ID="tbl_urunOzellik" runat="server">
                                </asp:Table>
                            </div>
                            <div id="div_oylama">
                                <table>
                                    <tr>
                                        <td><span class="baslikIcerik">Ürün Oylaması :</span></td>
                                        <td>
                                            <div id ="stars" runat="server">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="indirim">
                                <div id="indirimIcerik">
                                    <asp:Label ID="urunIndirim" runat="server" Text= ""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="urunSiparis">
                        <div style="display: table-cell;vertical-align: middle;text-align: center">
                            <div class="div_urunBilgi">
                                <table class="urunIcerik">
                                    <tr>
                                        <td><span class="baslikIcerik">Stok Durum</span></td>
                                        <td>:</td>
                                        <td><asp:Label ID="lbl_urunStok" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="div_urunBilgi">
                                <table class="urunIcerik">
                                    <tr>
                                        <td><span class="baslikIcerik">Fiyat</span></td>
                                        <td>:</td>
                                        <td><asp:Label ID="lbl_urunFiyat" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="div_urunBilgi">
                                <table class="urunIcerik">
                                    <tr>
                                        <td><span class="baslikIcerik">İndirimli Fiyat</span></td>
                                        <td>:</td>
                                        <td><asp:Label ID="lbl_indirimliFiyat" ForeColor="Red" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><span class="baslikIcerik">Kazanç</span></td>
                                        <td>:</td>
                                        <td><asp:Label ID="lbl_kazanc" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                            <div class="div_urunBilgi">
                                <table  class="urunIcerik">
                                    <tr>
                                        <td style="padding-top:40px;padding-bottom:30px;"><span class="baslikIcerik">Ürün Adedi</span></td>
                                        <td style="padding-top:40px;padding-bottom:30px;">:</td>
                                        <td style="padding-bottom:10px;"><asp:TextBox ID="txt_urunAdet"  runat="server"></asp:TextBox></td>
                                    </tr>
                                </table>
                                <asp:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server"  TargetControlID="txt_urunAdet" width="80" ></asp:NumericUpDownExtender>
                            </div>
                            <asp:Button ID="btn_sepeteEkle" runat="server" OnClick="btn_sepeteEkle_Click" />
                            <div style="width:300px;height:50px;margin-left:auto;margin-right:auto;margin-top:10px">
                                <asp:Label ID="lbl_urunDetayMesaj" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                
                    <div class="cd-tabs">

	                    <nav>
		                    <ul class="cd-tabs-navigation">
			                    <li><a data-content="inbox" class="selected" href="#0">Ürün Açıklama</a></li>
			                    <li><a data-content="new" href="#0">Yorumlar</a></li>
			                    <li><a data-content="gallery" href="#0">Taksit Seçenekleri</a></li>
		                    </ul> <!-- cd-tabs-navigation -->
	                    </nav>

	                    <ul class="cd-tabs-content">
		                    <li data-content="inbox" class="selected">
			                    <p>Inbox Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum recusandae rem animi accusamus quisquam reprehenderit sed voluptates, numquam, quibusdam velit dolores repellendus tempora corrupti accusantium obcaecati voluptate totam eveniet laboriosam?</p>

			                    <p>Inbox Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum recusandae rem animi accusamus quisquam reprehenderit sed voluptates, numquam, quibusdam velit dolores repellendus tempora corrupti accusantium obcaecati voluptate totam eveniet laboriosam?</p>
		                    </li>

		                    <li data-content="new">
			                    <div id="div_yorumBaslik">
                                    <div id="div_yorumResim">
                                        <img src="image/yorum-icon.png" /></div>
                                    <div id="div_baslik">
                                        <span>Sizin yorumlarınız bizim için değerli. Yapacağınız yorumlarla, bu ürünü almak isteyenleri doğru yönlendirmiş olun.</span>
                                    </div>
                                    <div id="div_btnYorum" runat="server">
                                        <div id="btn_yorumYap">Yorum Yap</div>
                                    </div>
                                    <div id="div_yorumAdet">
                                        <asp:Label ID="lbl_yorumAdet" runat="server"></asp:Label>
                                    </div>
			                    </div>
                                <div class="yorumEkle" id="pnl_yorumEkle">
                                    <table style="margin-left:210px;margin-top:130px;float:left">
                                        <tr>
                                            <td>Yorum Başlığı</td><td><asp:TextBox ID="txt_yorumBaslik" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Yorumunuz</td><td><asp:TextBox ID="txt_yorumIcerik" Width="400 " Height="100" runat ="server" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    <div id="div_kullaniciDegerlendirme">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="rdb_puanlama" runat="server">
                                                        <asp:listitem Selected="True" Value="5">Çok İyi</asp:listitem>
                                                        <asp:listitem Value="4">İyi</asp:listitem>
                                                        <asp:listitem Value="3">Normal</asp:listitem>
                                                        <asp:listitem Value="2">Kötü</asp:listitem>
                                                        <asp:listitem Value="1">Çok Kötü</asp:listitem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:Button ID="btn_yorumGonder" runat="server" Text="Gönder" OnClick="btn_yorumGonder_Click" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <asp:Panel ID="pnl_yorumlar" ScrollBars="Vertical" runat="server"> </asp:Panel>
		                    </li>

		                    <li data-content="gallery">
			                    <p>Gallery Lorem ipsum dolor sit amet, consectetur adipisicing elit. Cumque tenetur aut, cupiditate, libero eius rerum incidunt dolorem quo in officia.</p>

			                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. A ipsa vero, culpa doloremque voluptatum consectetur mollitia, atque expedita unde excepturi id, molestias maiores delectus quos molestiae. Ab iure provident adipisci eveniet quisquam ratione libero nam inventore error pariatur optio facilis assumenda sint atque cumque, omnis perspiciatis. Maxime minus quam voluptatum provident aliquam voluptatibus vel rerum. Soluta nulla tempora aspernatur maiores! Animi accusamus officiis neque exercitationem dolore ipsum maiores delectus asperiores reprehenderit pariatur placeat, quaerat sed illum optio qui enim odio temporibus, nulla nihil nemo quod dicta consectetur obcaecati vel. Perspiciatis animi corrupti quidem fugit deleniti, atque mollitia labore excepturi ut.</p>
		                    </li>
	                    </ul> <!-- cd-tabs-content -->
                    </div>

                
            </div>
        </form>
    </div>
</body>
</html>
