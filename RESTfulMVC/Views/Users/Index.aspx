<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>Action</h3>
    <p><%= ViewData["action"] %></p>

    <h3>Id</h3>
    <p><%= ViewData["id"] %></p>
    
    <p>
        <a href="/">Home</a>
    </p>

</asp:Content>
