<%@ Page Title="Detalhes do Vendedor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendedorDetalhes.aspx.cs" Inherits="Web.VendedorDetalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Dados do vendedor -->
    <section>
        <h2>Vendedor</h2>
        <asp:Label ID="lblVendedorId" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblVendedorRazaoSocial" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblVendedorNomeFantasia" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblVendedorCnpj" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblVendedorEmail" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblVendedorSenha" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblVendedorComissao" runat="server"></asp:Label>
        <br />
        <br />
    </section>
    <!-- Dados do endereço do vendedor -->
    <section>
        <h2>Endereço</h2>
        <asp:Label ID="lblEnderecoId" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblEnderecoCep" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblEnderecoCidade" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblEnderecoEstado" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblEnderecoRua" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblEnderecoBairro" runat="server"></asp:Label>
        <br />
        <br />
    </section>
    <asp:Button class="btn btn-primary btn-md" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
</asp:Content>
