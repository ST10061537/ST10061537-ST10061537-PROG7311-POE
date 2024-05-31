<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="AgriEnergy.Pages.Products.Products" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>List of Products</h2>
    <h2></h2>
    <asp:LinkButton ID="btn_AddNewProduct" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/Pages/Products/NewProduct.aspx">Add New Product</asp:LinkButton>
    <h2></h2>
    <div>
        <label>Start Date:</label>
        <asp:TextBox ID="StartDateTextBox" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="StartDateCalendarExtender" runat="server" TargetControlID="StartDateTextBox" Format="yyyy-MM-dd"></asp:CalendarExtender>
        <label>End Date:</label>
        <asp:TextBox ID="EndDateTextBox" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="EndDateCalendarExtender" runat="server" TargetControlID="EndDateTextBox" Format="yyyy-MM-dd"></asp:CalendarExtender>
        <asp:Button ID="FilterButton" runat="server" Text="Filter" OnClick="FilterButton_Click" CssClass="btn btn-primary btn-sm" />
        <asp:Button ID="ResetButton" runat="server" Text="Reset" OnClick="ResetButton_Click" CssClass="btn btn-secondary btn-sm" />
        <br><br/>
        <asp:Label ID="CategoryLabel" runat="server" Text="Product Category:" Visible="false"></asp:Label>
        <asp:TextBox ID="CategorySearchTextBox" runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="CategorySearchButton" runat="server" Text="Search For Category" OnClick="CategorySearchButton_Click" CssClass="btn btn-primary btn-sm" Visible="false" />
        <br><br/>
        <asp:Label ID="FarmerUsernameLabel" runat="server" Text="Farmer Username:"></asp:Label>
        <asp:TextBox ID="FarmerSearchTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="FarmerSearchButton" runat="server" Text="Search For Farmer" OnClick="FarmerSearchButton_Click" CssClass="btn btn-primary btn-sm" />
    </div>
    <h2></h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="ProductsTab" Width="1279px" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" InsertVisible="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="ProductionDate" HeaderText="ProductionDate" SortExpression="ProductionDate" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="FarmerID" HeaderText="FarmerID" SortExpression="FarmerID" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <HeaderStyle BackColor="#666666" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="ProductsTab" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM Products" 
        DeleteCommand="DELETE FROM Products WHERE ProductID = @ProductID">
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
