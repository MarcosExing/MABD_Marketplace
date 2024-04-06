<%@ Page Title="Detalhes do Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteDetalhes.aspx.cs" Inherits="Web.ClienteDetalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Dados do cliente -->
    <section>
        <h2>Cliente</h2>
        <asp:Label ID="lblClienteId" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblClienteNome" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblClienteCpf" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblClienteEmail" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblClienteSenha" runat="server"></asp:Label>
        <br />
        <br />
    </section>
    <!-- Dados do endereço do cliente -->
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
