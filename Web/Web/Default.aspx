<%@ Page Title="Página Inicial" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1>CRUD do MABD (Mecanismo de Acesso ao Banco de Dados) - Vendas</h1>
            <p class="lead">Esta aplicação tem como objetivo oferecer as operações CRUD para o banco de dados com o escopo vendas.</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2>Endereço CRUD</h2>
                <p>
                    Permite realizar as operações CRUD com os endereços.
                </p>
                <p>     
                    <asp:Button ID="btnEndereco" class="btn btn-primary btn-md" runat="server" Text="Endereço" OnClick="btnEndereco_Click" />            
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2>Cliente CRUD</h2>
                <p>
                    Permite realizar as operações CRUD com os clientes.
                </p>
                <p>     
                    <asp:Button ID="btnCliente" class="btn btn-primary btn-md" runat="server" Text="Cliente" OnClick="btnCliente_Click" />            
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2>Vendedor CRUD</h2>
                <p>
                    Permite realizar as operações CRUD com os vendedores.
                </p>
                <p>     
                    <asp:Button ID="btnVendedor" class="btn btn-primary btn-md" runat="server" Text="Vendedor" OnClick="btnVendedor_Click" />            
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2>Categoria CRUD</h2>
                <p>
                    Permite realizar as operações CRUD com as categorias.
                </p>
                <p>     
                    <asp:Button ID="btnCategoria" class="btn btn-primary btn-md" runat="server" Text="Categoria" OnClick="btnCategoria_Click" />            
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2>Produto CRUD</h2>
                <p>
                    Permite realizar as operações CRUD com os produtos.
                </p>
                <p>     
                    <asp:Button ID="btnProduto" class="btn btn-primary btn-md" runat="server" Text="Produto" OnClick="btnProduto_Click" />     
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2>Carrinho CRUD</h2>
                <p>
                    Permite realizar as operações CRUD com o carrinho.
                </p>
                <p>     
                    <asp:Button ID="btnCarrinho" class="btn btn-primary btn-md" runat="server" Text="Carrinho" OnClick="btnCarrinho_Click" />     
                </p>
            </section>
        </div>
    </main>
</asp:Content>
