<%@ Page Title="Editar Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteEditar.aspx.cs" Inherits="Web.ClienteEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Editar Cliente</h2>
        <p>Preencha todos os campos</p>
    </section>
    <!-- Formulário -->
    <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
    <br />
    <asp:TextBox ID="txtNome" runat="server" MaxLength="256"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" ErrorMessage="Nome é obrigatório!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblCpf" runat="server" Text="Cpf"></asp:Label>
    <br />
    <asp:TextBox ID="txtCpf" runat="server" TextMode="Number" MaxLength="19"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCpf" runat="server" ControlToValidate="txtCpf" ErrorMessage="Cpf é obrigatório!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
    <br />
    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email é necessário!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
    <br />
    <asp:TextBox ID="txtSenha" runat="server" MaxLength="25"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenha" ErrorMessage="Senha é necessária!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblEndereco" runat="server" Text="Endereço: "></asp:Label>
    <asp:Label ID="lblEnderecoSelecionado" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button class="btn btn-primary btn-md" runat="server" Text="Confirmar" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
    <asp:Button ID="btnVoltar" class="btn btn-primary btn-md" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="False" />
    <br />
</asp:Content>
