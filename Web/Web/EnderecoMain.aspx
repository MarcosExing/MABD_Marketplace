<%@ Page Title="Endereços" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnderecoMain.aspx.cs" Inherits="Web.EnderecoMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header da página -->
    <section>
        <h2>Endereços</h2>
        <p>Página para alterar ou deletar 1 ou mais endereços</p>
    </section>

    <asp:Button ID="btnAdicionarEndereco" Text="Adicionar" CssClass="btn btn-primary btn-md" runat="server" OnClick="btnAdicionarEndereco_Click" />
    <br />
    <br />
    <div id="divEnderecos" style="max-height: 500px; overflow-y:scroll;">
        <!-- Tabela com todos os endereços do banco de dados -->
        <asp:GridView ID="grdEnderecos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" class="customGridView" OnRowCommand="grdEndereco_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar" />
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="cep" HeaderText="Cep" SortExpression="Cep" />
                <asp:BoundField DataField="cidade" HeaderText="Cidade" SortExpression="Cidade" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="rua" HeaderText="Rua" SortExpression="Rua" />
                <asp:BoundField DataField="bairro" HeaderText="Bairro" SortExpression="Bairro" />
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
