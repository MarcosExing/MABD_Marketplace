<%@ Page Title="Adicionar Carrinho" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrinhoAdicionar.aspx.cs" Inherits="Web.CarrinhoAdicionar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Inserir Carrinho</h2>
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
    <asp:TextBox ID="txtValorTotal" runat="server" Enabled="False">0</asp:TextBox>
    <br />
    <asp:Label ID="lblStatusPedido" runat="server" Text="Status do Pedido"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlStatusPedido" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblCliente" runat="server" Text="Cliente: "></asp:Label>
    <asp:Label ID="lblClienteSelecionado" runat="server" Font-Bold="True" Visible="False"></asp:Label>
    <asp:Label ID="lblErroSemCliente" runat="server" ForeColor="Red" Text="É necessário selecionar um cliente!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroClienteIndisponivel" runat="server" ForeColor="Red" Text="Nenhum cliente disponível!" Visible="False"></asp:Label>
    <br />
    <div id="divCliente" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com os clientes disponíveis -->
        <asp:GridView ID="grdCliente" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="grd_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="cpf" HeaderText="Cpf" SortExpression="Cpf" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" />
                <asp:ButtonField ButtonType="Button" CommandName="AdicionarCliente" Text="Adicionar" />
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
    <asp:Label ID="lblProdutos" runat="server" Text="Produtos: "></asp:Label>
    <asp:Label ID="lblProdutosSelecionados" runat="server" Font-Bold="True" Visible="False"></asp:Label>
    <asp:Label ID="lblErroSemProduto" runat="server" ForeColor="Red" Text="É necessário selecionar ao menos 1 produto!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroProdutoIndisponivel" runat="server" ForeColor="Red" Text="Nenhum produto disponível!" Visible="False"></asp:Label>
    <br />
    <div id="divProdutos" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com os produtos disponíveis -->
        <asp:GridView ID="grdProdutos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Culture="pt-BR" OnRowCommand="grd_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="Descrição" />
                <asp:BoundField DataField="preco" HeaderText="Preço" SortExpression="Preço" DataFormatString="{0:C}" />
                <asp:ImageField DataImageUrlField="imagem" HeaderText="Imagem" SortExpression="Imagem">
                    <ControlStyle Height="50px" Width="50px" />
                    <ItemStyle Wrap="True" />
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
