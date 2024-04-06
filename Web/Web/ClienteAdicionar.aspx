<%@ Page Title="Adicionar Categoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteAdicionar.aspx.cs" Inherits="Web.ClienteAdicionar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <h2>Inserir Cliente</h2>    
        <p>Preencha todos os campos</p>
    </section>
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
    <asp:Label ID="lblEnderecoSelecionado" runat="server" Font-Bold="True" Visible="False"></asp:Label>
    <asp:Label ID="lblErroSemEndereco" runat="server" ForeColor="Red" Text="É necessário selecionar um endereco!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroEnderecoIndisponivel" runat="server" ForeColor="Red" Text="Nenhum endereco disponível!" Visible="False"></asp:Label>
    <br />
    <div id="divEndereco" style="max-height: 200px; overflow-y:scroll;">
        <asp:GridView ID="grdEndereco" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="grdEndereco_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="cep" HeaderText="Cep" SortExpression="Cep" />
                <asp:BoundField DataField="cidade" HeaderText="Cidade" SortExpression="Cidade" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="rua" HeaderText="Rua" SortExpression="Rua" />
                <asp:BoundField DataField="bairro" HeaderText="Bairro" SortExpression="Bairro" />
                <asp:ButtonField ButtonType="Button" CommandName="Adicionar" Text="Adicionar" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
    <br />
    <br />
    <asp:Button class="btn btn-primary btn-md" runat="server" Text="Confirmar" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
    <asp:Button ID="btnVoltar" class="btn btn-primary btn-md" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="False" />
    <br />
</asp:Content>
