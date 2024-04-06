<%@ Page Title="Carrinhos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrinhoMain.aspx.cs" Inherits="Web.CarrinhoMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Carrinhos</h2>
        <p>Página para alterar ou deletar carrinhos</p>
    </section>
    <asp:Button ID="btnAdicionarCarrinho" Text="Adicionar" class="btn btn-primary btn-md" runat="server" OnClick="btnAdicionarCarrinho_Click" />
    <br />
    <br />
    <div id="divCarrinhos" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com todos os carrinhos do banco de dados -->
        <asp:GridView ID="grdCarrinhos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="grdCarrinhos_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Detalhes" Text="Detalhes" />
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar"></asp:ButtonField>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="dataPedido" HeaderText="Data do Pedido" SortExpression="DataPedido" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="valorTotal" HeaderText="Valor Total" SortExpression="ValorTotal" DataFormatString="{0:C}" />
                <asp:BoundField DataField="statusPedido" HeaderText="Status do Pedido" SortExpression="StatusPedido" />
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
