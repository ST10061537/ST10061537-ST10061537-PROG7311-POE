<%@ Page Title="New Farmer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewFarmer.aspx.cs" Inherits="AgriEnergy.Pages.Farmers.NewFarmer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2>New Farmer</h2>
    <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message"></asp:Label>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">First Name</label>
        <div class="col-sm-6">
            <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Last Name</label>
        <div class="col-sm-6">
            <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Email</label>
        <div class="col-sm-6">
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Username</label>
        <div class="col-sm-6">
            <asp:TextBox runat="server" ID="UsernameTextBox" CssClass="form-control"></asp:TextBox>
            <small class="form-text text-muted">Username requirements: <br /> - An underscore (_) <br />- No more than 5 characters in length</small>
        <div id="usernameAvailability"></div>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Password</label>
        <div class="col-sm-6">
            <asp:TextBox runat="server" ID="PasswordTextBox" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <small class="form-text text-muted">Password requirements: <br />- No more than 8 characters in length <br />- A capital letter <br /> - A number <br />- A special character</small>
        <div id="passwordStrength"></div>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script>
            $(document).ready(function () {
                $('#<%= PasswordTextBox.ClientID %>').keyup(function () {
                var password = $(this).val();
                var strength = 0;

                // Check the password against various criteria and increment the strength variable for each match
                if (password.length > 7) strength++;
                if (/[A-Z]/.test(password)) strength++;
                if (/[a-z]/.test(password)) strength++;
                if (/[0-9]/.test(password)) strength++;
                if (/[^A-Za-z0-9]/.test(password)) strength++;

                // Display the password strength
                if (strength == 0) {
                    $('#passwordStrength').text('');
                } else if (strength <= 2) {
                    $('#passwordStrength').text('Weak').css('color', 'red');
                } else if (strength <= 4) {
                    $('#passwordStrength').text('Medium').css('color', 'orange');
                } else {
                    $('#passwordStrength').text('Strong').css('color', 'green');
                }
            });
        });
    </script>
        <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Confirm Password</label>
        <div class="col-sm-6">
            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Mobile Number</label>
        <div class="col-sm-6">
            <asp:TextBox ID="MobileNumberTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label class="col-sm-3 col-form-label">Location</label>
        <div class="col-sm-6">
            <asp:TextBox ID="LocationTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <div class="offset-sm-3 col-sm-3 d-grid">
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="SUBMIT" BackColor="Black" ForeColor="White" />
        </div>
        <div class="col-sm-3 d-grid">
            <a class="btn btn-outline-primary" role="button" href="Farmers.aspx">Cancel</a>
        </div>
    </div>
</asp:Content>
