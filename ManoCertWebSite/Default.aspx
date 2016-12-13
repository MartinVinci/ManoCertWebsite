<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ManoCertWebSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Version: 2.4</p>
    </div>
    <div>
        <%--         <img src="https://manobranch.blob.core.windows.net/files/myblob" class="image-super" > --%>
        <img src="https://manobranch.blob.core.windows.net/images/turtle.jpg" class="image-super">
    </div>
    <div class="margin-below">
        <asp:Button ID="btnQuickTest" runat="server" class="btn btn-primary btn-md" Text="Quick Test" OnClick="btnQuickTest_Click" />
        <asp:Label ID="lblQuickTest" runat="server" Text="ej tryckt på knapp"></asp:Label>
    </div>
    <div class="margin-below">
        <asp:Button ID="btnRandomNumber" runat="server" class="btn btn-primary btn-md" Text="Slumpa siffra" OnClick="btnRandomNumber_Click" />
        <asp:Label ID="lblRandomNumber" runat="server" Text="0"></asp:Label>
    </div>
    <div class="margin-below">
        <asp:Button ID="btnMySettings" runat="server" class="btn btn-primary btn-md" Text="AppSettings_MySettings" OnClick="btnMySettings_Click" />
        <asp:Label ID="lblMySettings" runat="server" Text="ej hämtat"></asp:Label>
    </div>
    <div class="margin-below">
        <asp:Label ID="lblTrySettingsFromAzure" runat="server" Text="Default text Azure"></asp:Label>
        <br/>
        <asp:Label ID="lblTrySettingsFromLocal" runat="server" Text="Default text Local"></asp:Label>

    </div>
</asp:Content>




<%--        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>--%>