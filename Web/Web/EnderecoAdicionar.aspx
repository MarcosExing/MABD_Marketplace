<%@ Page Title="Adicionar Endereço" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnderecoAdicionar.aspx.cs" Inherits="Web.EnderecoAdicionar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Inserir Endereço</h2>
        <p>Preencha todos os campos</p>
    </section>

    <!-- Formulário -->
    <asp:Label ID="lblCep" runat="server" Text="CEP"></asp:Label>
    <br />
    <asp:TextBox ID="txtCep" runat="server" TextMode="Number" MaxLength="9"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCep" runat="server" ControlToValidate="txtCep" ErrorMessage="Cep é obrigatório!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblCidade" runat="server" Text="Cidade"></asp:Label>
    <br />
    <asp:TextBox ID="txtCidade" runat="server" MaxLength="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCidade" runat="server" ControlToValidate="txtCidade" ErrorMessage="Cidade é obrigatório!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
    <br />
    <asp:TextBox ID="txtEstado" runat="server" MaxLength="40"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="txtEstado" ErrorMessage="Estado é obrigatório!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblRua" runat="server" Text="Rua"></asp:Label>
    <br />
    <asp:TextBox ID="txtRua" runat="server" MaxLength="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvRua" runat="server" ControlToValidate="txtRua" ErrorMessage="Rua é obrigatório!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblBairro" runat="server" Text="Bairro"></asp:Label>
    <br />
    <asp:TextBox ID="txtBairro" runat="server" MaxLength="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvBairro" runat="server" ControlToValidate="txtBairro" ErrorMessage="Bairro é obrigatório!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button class="btn btn-primary btn-md" ID="btnConfirmarEndereco" runat="server" Text="Confirmar" OnClick="btnConfirmarEndereco_Click" />
    <asp:Button ID="btnVoltar" class="btn btn-primary btn-md" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="False" />
    <br />
</asp:Content>
