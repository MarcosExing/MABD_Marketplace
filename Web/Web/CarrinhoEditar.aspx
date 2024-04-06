<%@ Page Title="Editar Carrinho" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrinhoEditar.aspx.cs" Inherits="Web.CarrinhoEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Editar Carrinho</h2>
        <p>Preencha todos os campos</p>
    </section>
    <!-- Formulário -->
    <asp:Label ID="lblDataPedido" runat="server" Text="Data do Pedido"></asp:Label>
    <br />
    <asp:TextBox ID="txtDataPedido" runat="server" TextMode="Date"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDataPedido" runat="server" ControlToValidate="txtDataPedido" ErrorMessage="Data do Pedido é obrigatória!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblValorTotal" runat="server" Text="Valor Total"></asp:Label>
    <br />
    <asp:TextBox ID="txtValorTotal" runat="server" Enabled="False" TextMode="Number">0</asp:TextBox>
    <asp:Label ID="lblValorTotalPlaceHolder" runat="server" ForeColor="#CCCCCC"></asp:Label>
    <br />
    <asp:Label ID="lblStatusPedido" runat="server" Text="Status do Pedido"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlStatusPedido" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblCliente" runat="server" Text="Cliente: "></asp:Label>
    <asp:Label ID="lblClienteSelecionado" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <asp:Label ID="lblProdutos" runat="server" Text="Produtos: "></asp:Label>
    <asp:Label ID="lblProdutosSelecionados" runat="server" Font-Bold="True"></asp:Label>
    <asp:Label ID="lblProdutosSelecionadosPlaceHolder" runat="server" ForeColor="#CCCCCC"></asp:Label>
    <asp:Label ID="lblErroSemProduto" runat="server" ForeColor="Red" Text="É necessário selecionar ao menos 1 produto!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroProdutoIndisponivel" runat="server" ForeColor="Red" Text="Nenhum produto disponível!" Visible="False"></asp:Label>
    <br />
    <div id="divProdutos" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com os produtos disponíveis do banco de dados -->
        <asp:GridView ID="grdProdutos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Culture="pt-BR" OnRowCommand="grd_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="Descrição" />
                <asp:BoundField DataField="preco" HeaderText="Preço" SortExpression="Preço" DataFormatString="{0:C}" />
                <asp:ImageField DataImageUrlField="imagem" HeaderText="Imagem" SortExpression="Imagem">
                    <ControlStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status" />
                <asp:TemplateField HeaderText="Quantidade">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantidadePedida" runat="server" TextMode="Number"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" CommandName="AdicionarProduto" Text="Adicionar" />
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
    <asp:Button class="btn btn-primary btn-md" runat="server" Text="Confirmar" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
    <asp:Button ID="btnVoltar" class="btn btn-primary btn-md" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="False" />
    <br />
</asp:Content>
