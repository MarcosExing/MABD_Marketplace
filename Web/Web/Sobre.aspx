<%@ Page Title="Sobre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Informações sobre a aplicação.
        </h3>
        <p> Esta aplicação foi desenvolvida com o propósito de oferecer uma interface para a realização das operações CRUDs
            sobre a parte de vendas do banco de dados sobe responsabilidade. Esta aplicação utiliza o MABD_Vendas (Mecanismo de Acesso ao Banco de Dados), desenvolvido para realizar as operações CRUDs
            sobre a parte de vendas do banco de dados, e o SqlServer.
        </p>
    </main>
</asp:Content>
