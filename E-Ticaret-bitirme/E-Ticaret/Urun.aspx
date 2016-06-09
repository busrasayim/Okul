<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" ClientIDMode="Static" CodeBehind="Urun.aspx.cs" Inherits="E_Ticaret.Urun1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecenekIcerik" runat="server">
    <div id="div_filtre" runat="server">
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="VitrinIcerik" runat="server">
    <asp:HiddenField ID="hiddenDeger" runat="server" />
    <asp:Table ID="table_urun"  cssclass="cssTable" runat="server"></asp:Table>
</asp:Content>