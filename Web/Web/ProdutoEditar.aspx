<%@ Page Title="Editar Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProdutoEditar.aspx.cs" Inherits="Web.ProdutoEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Editar Produto</h2>
        <p>Preencha todos os campos</p>
    </section>
    <!-- Formulário -->
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
    <asp:Label ID="lblCategoriaSelecionadaPlaceHolder" runat="server" ForeColor="#CCCCCC"></asp:Label>
    <asp:Label ID="lblErroSemCategoria" runat="server" ForeColor="Red" Text="É necessário selecionar uma categoria!" Visible="False"></asp:Label>
    <asp:Label ID="lblErroCategoriaIndisponivel" runat="server" ForeColor="Red" Text="Nenhuma categoria disponível!" Visible="False"></asp:Label>
    <div id="divCategoria" style="max-height: 200px; overflow-y:scroll;">
        <!-- Tabela com todas as categorias do banco de dados-->
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
    <asp:Label ID="lblVendedorSelecionado" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblStatusProduto" runat="server" Text="Status do Produto"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlStatusProduto" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Image ID="imgProduto" runat="server" BackColor="#CCCCCC" Height="50px" Width="50px" />
    <br />
    <asp:Label ID="lblImagem" runat="server" Text="Imagem"></asp:Label>
    <br />
    <asp:FileUpload ID="fuImagem" runat="server" enctype="multipart/form-data" />
    <asp:Label ID="lblErroSemImagem" runat="server" ForeColor="Red" Text="É necessário carregar uma imagem!" Visible="False"></asp:Label>
    <asp:Label ID="lblStatusImagem" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
    <br />
    <br />
    <asp:Button class="btn btn-primary btn-md" runat="server" Text="Confirmar" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
    <asp:Button ID="btnVoltar" class="btn btn-primary btn-md" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="False" />
    <br />
</asp:Content>
