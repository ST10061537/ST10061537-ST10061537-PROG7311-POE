<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="AgriEnergy.Pages.Employees.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2>List of Employees</h2>
    <h2></h2>
    <a class='btn btn-primary btn-sm' href='NewEmployee.aspx'>New Employee</a>
    <h2></h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID" DataSourceID="SqlDataSource1" Width="1279px" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" InsertVisible="False" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
        <HeaderStyle BackColor="#666666" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [Employees]" 
        OldValuesParameterFormatString="original_{0}">
    </asp:SqlDataSource>
</asp:Content>
