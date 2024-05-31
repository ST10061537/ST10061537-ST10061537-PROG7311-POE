<%@ Page Title="Farmers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Farmers.aspx.cs" Inherits="AgriEnergy.Pages.Farmers.Farmers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2>List of Farmers</h2>
    <h2></h2>
    <asp:LinkButton ID="btn_AddNewFarmer" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/Pages/Farmers/NewFarmer.aspx">Add New Farmer</asp:LinkButton>
    <h2></h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="FarmerID" DataSourceID="FarmersTab" Width="1279px" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="FarmerID" HeaderText="FarmerID" ReadOnly="True" SortExpression="FarmerID" InsertVisible="False" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
            <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" SortExpression="MobileNumber" />
        </Columns>
        <HeaderStyle BackColor="#666666" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="FarmersTab" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [Farmers]" 
        OldValuesParameterFormatString="original_{0}">
    </asp:SqlDataSource>
</asp:Content>
