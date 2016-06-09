<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"  ClientIDMode="Static" CodeBehind="AltKategori.aspx.cs" Inherits="E_Ticaret.AltKategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecenekIcerik" runat="server">
    <div id="div_yanMenu" class="menum" runat="server">
        <ul id="ul_altKategoriMenu" runat="server"></ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VitrinIcerik" runat="server">
    <asp:Table ID="table_urun"  cssclass="cssTable" runat="server"></asp:Table>
</asp:Content>
