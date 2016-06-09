<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" ClientIDMode="Static" Inherits="E_Ticaret.UyeGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/UyeGiris.css" rel="stylesheet" />
    <script src="Js/jquery-migrate-1.2.1.min.js"></script>
    <script src="Js/jquery-2.1.3.min.js"></script>
</head>
<body>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
  <div class="wrapper">
	<div class="container">
		<h1><asp:Label ID="loginMesaj" runat="server" Text="E-TİCARET ÜYE  GİRİŞ"></asp:Label></h1>

		<form class="form" runat="server">
            <asp:TextBox ID="kullaniciAd" runat="server"></asp:TextBox>
            <asp:TextBox ID="sifre" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="buttonLogin" runat="server" Text="Giriş" OnClick="buttonLogin_Click"/>
            <input id="girisDurum" type="hidden"  runat="server" value="0"/>
		</form>
	</div>
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
</div>

  <script src='http://codepen.io/assets/libs/fullpage/jquery.js'></script>

  <script src="Js/UyeGiris.js"></script>

</body>
</html>
