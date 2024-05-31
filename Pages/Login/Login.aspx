<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgriEnergy.Pages.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Images/letter-r.png" rel="shortcut icon" type="image/png" />
    <title>Login</title>

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <style>
        body {
            position: relative;
            background-image: url('<%= ResolveUrl("~/Images/background.jpeg") %>');
            background-repeat: no-repeat;
            background-size: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        body::before {
            content: "";
            position: absolute;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background-color: rgba(0, 0, 0, 0.5);
            z-index: -1;
        }
        .container {
            padding: 16px;
            background-color: white;
        }
        body {
            font-family: Arial, Helvetica, sans-serif;
            color: white;
            background-color: white;
        }
        form {
            border: 3px solid #f1f1f1;
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
        .center {
            text-align: center;
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
            margin: 13px 0 8px;
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
        .container {
            padding: 16px;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 40%;
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
    </style>

</head>
<body>
    <form id="form1" runat="server" class="frmalg">
        <div class="container">
            <center>
                <h3>Agri-Energy Connect Platform: Login</h3>
            </center>
            <label for="txt_Username"><b>Username</b></label>
            <asp:TextBox runat="server" ID="txt_Username" placeholder="Enter your username"></asp:TextBox>
            <label for="txt_password"><b>Password</b></label>
            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
            <label for="userType"><b>Select User Type</b></label><br />
            <asp:RadioButton ID="rb_Employee" runat="server" GroupName="UserType" Text="Employee" Checked="True" />
            <asp:RadioButton ID="rb_Farmer" runat="server" GroupName="UserType" Text="Farmer" /><br />
            <div class="center">
                <br />
                <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message"></asp:Label>
                <br />
                <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" Text="Login" OnClick="btn_Login_Click" />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
