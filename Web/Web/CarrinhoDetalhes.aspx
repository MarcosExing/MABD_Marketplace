<%@ Page Title="Detalhes do Carrinho" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrinhoDetalhes.aspx.cs" Inherits="Web.CarrinhoDetalhes"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Dados do cliente do carrinho -->
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
    <!-- Dados dos produtos no carrinho -->
    <h2>Produtos no Carrinho</h2>
    <div id="divProdutos" style="max-height: 500px; overflow-y:scroll;">
        <!-- Tabela com os produtos no carrinho -->
        <asp:GridView ID="grdProdutos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Culture="pt-BR">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="Descrição" />
                <asp:BoundField DataField="preco" HeaderText="Preço" SortExpression="Preço" DataFormatString="{0:C}" />
                <asp:ImageField DataImageUrlField="imagem" HeaderText="Imagem" SortExpression="Imagem">
                    <ControlStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="quantidadePedida" HeaderText="Quantidade" SortExpression="Quantidade" />
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
    <asp:Button ID="btnVoltar" Text="Voltar" CssClass="btn btn-primary btn-md" runat="server" OnClick="btnVoltar_Click" />
</asp:Content>
