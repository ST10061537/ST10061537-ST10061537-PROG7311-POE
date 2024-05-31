<%@ Page Title="Marketplace" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marketplace.aspx.cs" Inherits="AgriEnergy.Marketplace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
        <div class="row">
            <section class="col-md-4" aria-labelledby="marketplaceOverviewTitle">
                <img class="section-image" src='<%= ResolveUrl("~/Images/marketplace-overview.jpeg") %>' alt="Marketplace Overview" />
                <br />
                <h2 id="marketplaceOverviewTitle">Marketplace Overview</h2>
                <p>
                    Our marketplace is a one-stop shop for green energy solutions tailored to agricultural needs. Here, you can find products like solar-powered irrigation systems, wind turbines for farms, and biogas energy solutions.
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="productComparisonTitle">
                <img class="section-image" src='<%= ResolveUrl("~/Images/product-comparison.jpeg") %>' alt="Product Comparison" />
                <br />
                <h2 id="productComparisonTitle">Product Comparison</h2>
                <p>
                    Compare products, review technologies, and connect with green tech providers. Our comparison features make it easy to find the right solution for your needs.
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="comingSoonTitle">
                <img class="section-image" src='<%= ResolveUrl("~/Images/coming-soon.jpeg") %>' alt="Coming Soon" />
                <br />
                <h2 id="comingSoonTitle">Coming Soon</h2>
                <p>
                    Stay tuned for the final launch of our website, where we'll be introducing even more features to help you find the best green energy solutions for your farm.
                </p>
            </section>
        </div>
    </main>
</asp:Content>
