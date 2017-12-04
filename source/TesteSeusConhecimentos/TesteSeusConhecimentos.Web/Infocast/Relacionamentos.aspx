<%@ Page Title="Relacionamentos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relacionamentos.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Relacionamentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-width">
        <h2 id="formStatus"  runat="server">Novo Relacionamento</h2>
        <div class="form-group">
            <asp:Label ID="lbEnterprise" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList ID="ddlEnterprise" CssClass="form-control" runat="server"></asp:DropDownList>
        </div> 
        <div class="form-group">
            <asp:Label ID="lblUser" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList ID="ddlUser" CssClass="form-control" runat="server"></asp:DropDownList>
        </div> 
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Relacionar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>
