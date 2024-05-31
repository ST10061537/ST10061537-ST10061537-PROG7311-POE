<%@ Page Title="New Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProduct.aspx.cs" Inherits="AgriEnergy.Pages.Products.NewProduct" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2>New Product</h2>
    <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message"></asp:Label>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Product Name</label>
        <div class="col-sm-6">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Category</label>
        <div class="col-sm-6">
            <asp:TextBox ID="CategoryTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Production Date</label>
        <div class="col-sm-6">
            <asp:TextBox ID="ProductionDateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CalendarExtender ID="ProductionDateCalendarExtender" runat="server" TargetControlID="ProductionDateTextBox" Format="yyyy-MM-dd"></asp:CalendarExtender>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Description</label>
        <div class="col-sm-6">
            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <div class="offset-sm-3 col-sm-3 d-grid">
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="SUBMIT" BackColor="Black" ForeColor="White" />
        </div>
        <div class="col-sm-3 d-grid">
            <a class="btn btn-outline-primary" role="button" href="Products.aspx">Cancel</a>
        </div>
    </div>
</asp:Content>
