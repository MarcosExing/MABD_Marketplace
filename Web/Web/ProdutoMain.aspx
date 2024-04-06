<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProdutoMain.aspx.cs" Inherits="Web.ProdutoMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Produtos</h2>
        <p>Página para alterar ou deletar produtos</p>
    </section>
    <asp:Button ID="btnAdicionarProduto" Text="Adicionar" runat="server" OnClick="btnAdicionarProduto_Click" CssClass="btn btn-primary btn-md" />
    <br />
    <br />
    <div id="divProdutos" style="max-height: 500px; overflow-y:scroll;">
        <!-- Tabela com todos os produtos do banco de dados -->
        <asp:GridView ID="grdProdutos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Culture="pt-BR" OnRowCommand="grdProdutos_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Detalhes" Text="Detalhes" />
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar" />
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="categoria.nome" HeaderText="Categoria" SortExpression="Categoria" />
                <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="Descrição" />
                <asp:BoundField DataField="preco" HeaderText="Preço" SortExpression="Preço" DataFormatString="{0:C}" />
                <asp:ImageField DataImageUrlField="imagem" HeaderText="Imagem" SortExpression="Imagem">
                    <ControlStyle Height="50px" Width="50px" />
                    <ItemStyle Wrap="True" />
                </asp:ImageField>
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status" />
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
