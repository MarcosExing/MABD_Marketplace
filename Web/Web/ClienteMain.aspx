<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteMain.aspx.cs" Inherits="Web.ClienteMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Clientes</h2>
        <p>Página para alterar ou deletar clientes</p>
    </section>
    <asp:Button ID="btnAdicionarCliente" Text="Adicionar" runat="server" OnClick="btnAdicionarCliente_Click" CssClass="btn btn-primary btn-md" />
    <br />
    <br />
    <div id="divClientes" style="max-height: 500px; overflow-y:scroll;">
        <!-- Tabela com todos os clientes do banco de dados -->
        <asp:GridView ID="grdClientes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="grdClientes_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Detalhes" Text="Detalhes" />
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar"></asp:ButtonField>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="cpf" HeaderText="CPF" SortExpression="CPF" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="senha" HeaderText="Senha" SortExpression="Senha" />
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
