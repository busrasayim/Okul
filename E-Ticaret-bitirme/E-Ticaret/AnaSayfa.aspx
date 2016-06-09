<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" ClientIDMode="Static"  MasterPageFile="~/MasterPage.master" Inherits="E_Ticaret.AnaSayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="VitrinIcerik" Runat="Server">
      <asp:Table ID="table_urun" cssclass="cssTable" runat="server"> </asp:Table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SecenekIcerik" Runat="Server">
  <div id="div_yanMenu" class="menum" runat="server">
      <ul id="ul_yanMenu" runat="server"> </ul>
  </div>
</asp:Content>