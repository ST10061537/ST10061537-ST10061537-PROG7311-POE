<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AgriEnergy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .section-image {
            width: 100%;
            max-width: 420px;
            display: block;
            margin: 0 auto;
        }
        
        .welcome-message {
            font-size: 2em;
            text-align: center;
            margin-top: 20px;
        }
    </style>
    <main>
        <asp:Label ID="WelcomeMessage" runat="server" CssClass="welcome-message"></asp:Label>
        <div class="row">
        <section class="col-md-4" aria-labelledby="gettingStartedTitle">
            <img class="section-image" src='<%= ResolveUrl("~/Images/getting-started.jpeg") %>' alt="Getting started" />
            <br />
            <h2 id="gettingStartedTitle">Getting started</h2>
            <p>
                Our web app is easy to use. If you're an employee, you can add farmers to the system. If you're a farmer, you can add products to your profile.
            </p>
        </section>
        <section class="col-md-4" aria-labelledby="librariesTitle">
            <img class="section-image" src='<%= ResolveUrl("~/Images/features.jpeg") %>' alt="Features" />
            <br />
            <h2 id="librariesTitle">Green Marketplace</h2>
            <p>
                Here, you'll find green energy solutions tailored to agricultural needs, such as solar-powered irrigation systems, wind turbines for farms, and biogas energy solutions. You can compare products, review technologies, and connect with green tech providers.
            </p>
        </section>
        <section class="col-md-4" aria-labelledby="hostingTitle">
            <img class="section-image" src='<%= ResolveUrl("~/Images/support.jpeg") %>' alt="Support" />
            <br />
            <h2 id="hostingTitle">Support</h2>
            <p>
                If you need help, our support team is always ready to assist. Click on the "Support" link in the menu to contact us.
            </p>
        </section>
    </div>
</main>
</asp:Content>
