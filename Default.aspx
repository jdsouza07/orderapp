<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>&nbsp;</h1>
            </hgroup>
            <p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p>
        Please note that the order is deliverable in 12 working days</p>
</asp:Content>