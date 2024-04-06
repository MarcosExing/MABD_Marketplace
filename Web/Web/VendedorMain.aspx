<%@ Page Title="Vendedores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendedorMain.aspx.cs" Inherits="Web.VendedorMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Vendedores</h2>
        <p>Página para alterar ou deletar vendedores</p>
    </section>
    <asp:Button ID="btnAdicionarVendedor" Text="Adicionar" CssClass="btn btn-primary btn-md" runat="server" OnClick="btnAdicionarVendedor_Click" />
    <br />
    <br />
    <div id="divVnededores" style="max-height: 500px; overflow-y:scroll;">
        <!-- Tabela com todos os vendedores do banco de dados -->
        <asp:GridView ID="grdVendedores" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="grdVendedores_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Detalhes" Text="Detalhes" />
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar"></asp:ButtonField>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="razaoSocial" HeaderText="Razão Social" SortExpression="Razão Social" />
                <asp:BoundField DataField="nomeFantasia" HeaderText="Nome Fantasia" SortExpression="Nome Fantasia" />
                <asp:BoundField DataField="cnpj" HeaderText="Cnpj" SortExpression="Cnpj" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="senha" HeaderText="Senha" SortExpression="Senha" />
                <asp:BoundField DataField="comissao" HeaderText="Comissão" SortExpression="Comissão" />
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
</asp:Content>
