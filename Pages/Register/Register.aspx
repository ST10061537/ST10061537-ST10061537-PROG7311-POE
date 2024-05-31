<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AgriEnergy.Pages.Register.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Images/letter-r.png" rel="shortcut icon" type="image/png" />
    <title>Register</title>

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            color: white;
            background-color: white;
        }
        .container {
            width: 40%;
            margin: auto;
            padding: 16px;
            border: 3px solid #f1f1f1;
            background-color: white;
        }
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }
        button:hover {
            opacity: 0.8;
        }
        .cnbtn {
            background-color: white;
            color: black;
            padding: 14px 20px;
            margin: 8px 0;
            border: 1px solid black;
            cursor: pointer;
            width: 49%;
        }
        .lgnbtn {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #000;
            color: #fff;
            padding: 14px 20px;
            margin: 13px 0 8px 0;
            cursor: pointer;
            width: 50%;
        }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }
        img.avatar {
            width: 40%;
            border-radius: 50%;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        h3 {
            color: black;
        }
        .header {
            color: black;
        }
        label {
            color: black;
        }
        .label {
            color: black;
        }
        .error-message {
          color: red; 
          font-weight: bold; 
        }
        .username-requirements {
            color: black;
            font-size: 14px;
        }

        .password-requirements {
            color: black;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <center>
                <h3>Agri-Energy Connect Platform: Register</h3>
            </center>
            <div class="form-row">
                <label for="txt_name"><b>Full name</b></label>
                <asp:TextBox runat="server" ID="txt_name" placeholder="Enter your full name"></asp:TextBox>
            </div>
            <div class="form-row">
                <label for="txt_mobile"><b>Mobile number</b></label>
                <asp:TextBox runat="server" ID="txt_mobile" placeholder="Enter your mobile number"></asp:TextBox>
            </div>
            <div class="form-row">
                <label for="txt_email"><b>Email</b></label>
                <asp:TextBox runat="server" ID="txt_email" placeholder="Enter your email"></asp:TextBox>
            </div>
            <div class="form-row">
                <label for="txt_username"><b>Username</b></label>
                <asp:TextBox runat="server" ID="txt_username" placeholder="Enter your username"></asp:TextBox>
            </div>
            <!-- Username requirements -->
            <div class="username-requirements">
                <p>Username requirements:</p>
                <ul>
                    <li>An underscore (_)</li>
                    <li>No more than 5 characters in length</li>
                </ul>
            </div>
            <div class="form-row">
                <label for="txt_password"><b>Password</b></label>
                <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
            </div>
            <!-- Password requirements -->
            <div class="password-requirements">
                <p>Password requirements:</p>
                <ul>
                    <li>No more than 8 characters in length</li>
                    <li>A capital letter</li>
                    <li>A number</li>
                    <li>A special character</li>
                </ul>
            </div><div class="row mb-3">
    <label class="col-sm-3 col-form-label">Role</label>
    <div class="col-sm-6">
        <asp:RadioButtonList ID="RoleRadioButtonList" runat="server" CssClass="form-control">
            <asp:ListItem Text="Employee" Value="Employee" />
            <asp:ListItem Text="Farmer" Value="Farmer" />
        </asp:RadioButtonList>
    </div>
</div>
            <div class="form-row">
                <label for="txt_confirm_password"><b>Confirm password</b></label>
                <asp:TextBox runat="server" ID="txt_confirm_password" TextMode="Password" placeholder="Confirm your password"></asp:TextBox>
            </div>
            <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message"></asp:Label>
            <br />
            <asp:Button runat="server" ID="btn_Register" CssClass="lgnbtn" Text="Register" OnClick="btn_Register_Click" />
            <asp:Button runat="server" ID="btn_Cancel" Text="Cancel" CssClass="cnbtn" OnClick="btn_Cancel_Click" />
        </div>
    </form>
</body>
</html>
