<%@ Page Title="Adicionar Vendedor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendedorAdicionar.aspx.cs" Inherits="Web.VendedorAdicionar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--Header da página -->
    <section>
        <h2>Inserir Vendedor</h2>
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
    <asp:Label ID="lblEnderecoSelecionado" runat="server" Font-Bold="True" Visible="False"></asp:Label>
    <asp:Label ID="lblErroSemEndereco" runat="server" ForeColor="Red" Text="É necessário selecionar um endereco!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroEnderecoIndisponivel" runat="server" ForeColor="Red" Text="Nenhum endereco disponível!" Visible="False"></asp:Label>
    <br />
    <div id="divEndereco" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com os endereços disponíveis -->
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
