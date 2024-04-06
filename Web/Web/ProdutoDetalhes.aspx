<%@ Page Title="Detalhes do Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProdutoDetalhes.aspx.cs" Inherits="Web.ProdutoDetalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Dados do produto -->
    <section>
        <h2>Produto</h2>
        <asp:Image ID="imgProdutoImagem" runat="server" Height="150px" Width="150px" />
        <br />
        <asp:Label ID="lblProdutoId" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblProdutoCategoria" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblProdutoDescricao" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblProdutoPreco" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblProdutoStatus" runat="server"></asp:Label>
        <br />
        <br />
    </section>
    <!-- Dados do vendedor do produto -->
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
    <asp:Button class="btn btn-primary btn-md" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
</asp:Content>
