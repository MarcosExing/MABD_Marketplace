<%@ Page Title="Adicionar Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProdutoAdicionar.aspx.cs" Inherits="Web.ProdutoAdicionar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Inserir Produto</h2>
        <p>Preencha todos os campos</p>
    </section>
    <!-- Formulário-->
    <asp:Label ID="lblDescricao" runat="server" Text="Descrição"></asp:Label>
    <br />
    <asp:TextBox ID="txtDescricao" runat="server" MaxLength="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ControlToValidate="txtDescricao" ErrorMessage="Descrição do produto é obrigatória!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblPreco" runat="server" Text="Preço"></asp:Label>
    <br />
    <asp:TextBox ID="txtPreco" runat="server" MaxLength="10"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPreco" runat="server" ControlToValidate="txtPreco" ErrorMessage="Preço é necessário!" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revPreco" runat="server" ControlToValidate="txtPreco" ErrorMessage="Número decimal apenas" ForeColor="Red" ValidationExpression="^\d+\.\d{0,2}"></asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="lblCategoria" runat="server" Text="Categoria: "></asp:Label>
    <asp:Label ID="lblCategoriaSelecionada" runat="server" Font-Bold="True" Visible="False"></asp:Label>
    <asp:Label ID="lblErroSemCategoria" runat="server" ForeColor="Red" Text="É necessário selecionar uma categoria!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroCategoriaIndisponivel" runat="server" ForeColor="Red" Text="Nenhuma categoria disponível!" Visible="False"></asp:Label>
    <div id="divCategoria" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com as todas as categorias -->
        <asp:GridView ID="grdCategoria" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="grd_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:ButtonField ButtonType="Button" CommandName="AdicionarCategoria" Text="Adicionar" />
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
    <asp:Label ID="lblVendedor" runat="server" Text="Vendedor: "></asp:Label>
    <asp:Label ID="lblVendedorSelecionado" runat="server" Font-Bold="True" Visible="False"></asp:Label>
    <asp:Label ID="lblErroSemVendedor" runat="server" ForeColor="Red" Text="É necessário selecionar um vendedor!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroVendedorIndisponivel" runat="server" ForeColor="Red" Text="Nenhum vendedor disponível!" Visible="False"></asp:Label>
    <br />
    <div id="divVendedores" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com todos os vendedores -->
        <asp:GridView ID="grdVendedores" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="grd_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="razaoSocial" HeaderText="Razão Social" SortExpression="Razão Social" />
                <asp:BoundField DataField="nomeFantasia" HeaderText="Nome Fantasia" SortExpression="Nome Fantasia" />
                <asp:BoundField DataField="cnpj" HeaderText="Cnpj" SortExpression="Cnpj" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="senha" HeaderText="Senha" SortExpression="Senha" />
                <asp:BoundField DataField="comissao" HeaderText="Comissão" SortExpression="Comissão" />
                <asp:ButtonField ButtonType="Button" CommandName="AdicionarVendedor" Text="Adicionar" />
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
    <asp:Label ID="lblStatusProduto" runat="server" Text="Status do Produto"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlStatusProduto" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblImagem" runat="server" Text="Imagem"></asp:Label>
    <br />
    <asp:FileUpload ID="fuImagem" runat="server" enctype="multipart/form-data" />
    <asp:Label ID="lblErroSemImagem" runat="server" ForeColor="Red" Text="É necessário carregar uma imagem!" Visible="False"></asp:Label>
    <asp:Label ID="lblStatusImagem" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
    <br />
    <br />
    <asp:Button class="btn btn-primary btn-md" runat="server" Text="Confirmar" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
    <asp:Button ID="btnVoltar" class="btn btn-primary btn-md" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="False" />
    <br />
</asp:Content>
