<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriaMain.aspx.cs" Inherits="Web.CategoriaMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Categorias</h2>
        <p>Página para alterar ou deletar categorias</p>
    </section>
    <asp:Button ID="btnAdicionarCategoria" Text="Adicionar" runat="server" OnClick="btnAdicionarCategoria_Click" CssClass="btn btn-primary btn-md" />
    <br />
    <br />
    <div id="divCategorias" style="max-height: 500px; overflow-y:scroll;">
        <!-- Tabela com todas as categorias do banco de dados -->
        <asp:GridView ID="grdCategorias" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="grdCategorias_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar" />
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="Categoria" />
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
