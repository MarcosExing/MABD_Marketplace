<%@ Page Title="Editar Vendedor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendedorEditar.aspx.cs" Inherits="Web.VendedorEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Editar Vendedor</h2>
        <p>Preencha todos os campos</p>
    </section>
    <!-- Formulário -->
    <asp:Label ID="lblRazaoSocial" runat="server" Text="Razão Social"></asp:Label>
    <br />
    <asp:TextBox ID="txtRazaoSocial" runat="server" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvRazaoSocial" runat="server" ControlToValidate="txtRazaoSocial" ErrorMessage="Razão Social é obrigatório!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblNomeFantasia" runat="server" Text="Nome Fantasia"></asp:Label>
    <br />
    <asp:TextBox ID="txtNomeFantasia" runat="server" MaxLength="70"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNomeFantasia" runat="server" ControlToValidate="txtNomeFantasia" ErrorMessage="Nome Fantasia é obrigatório!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblCnpj" runat="server" Text="CNPJ"></asp:Label>
    <br />
    <asp:TextBox ID="txtCnpj" runat="server" TextMode="Number" MaxLength="14"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCnpj" runat="server" ControlToValidate="txtCnpj" ErrorMessage="CNPJ é obrigatório!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
    <br />
    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email é obrigatório!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
    <br />
    <asp:TextBox ID="txtSenha" runat="server" MaxLength="25"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenha" ErrorMessage="Senha é obrigatória!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblComissao" runat="server" Text="Comissão"></asp:Label>
    <br />
    <asp:TextBox ID="txtComissao" runat="server" TextMode="Number" MaxLength="4"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvComissao" runat="server" ControlToValidate="txtComissao" ErrorMessage="Comissão é obrigatória!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblEndereco" runat="server" Text="Endereço: "></asp:Label>
    <asp:Label ID="lblEnderecoSelecionado" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button class="btn btn-primary btn-md" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
    <asp:Button ID="btnVoltar" class="btn btn-primary btn-md" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="False" />
    <br />
</asp:Content>
