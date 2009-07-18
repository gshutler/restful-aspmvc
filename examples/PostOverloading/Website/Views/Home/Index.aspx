<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>POST /Users/</h3>
    <form action="/Users/" method="post">        
        <p>             
            <input type="submit" value="Create" />        
        </p>
    </form>
    
    <h3>DELETE /Users/2</h3>
    <form action="/Users/2" method="post">
        <input type="hidden" name="_method" value="DELETE" />
        <p>        
            <input type="submit" value="Delete" />        
        </p>
    </form>
    
    <h3>PUT /Users/2</h3>
    <form action="/Users/2" method="post">
        <input type="hidden" name="_method" value="PUT" />
        <p>        
            <input type="submit" value="Update" />        
        </p>
    </form>
    
    <h3>GET /Users/</h3>
    <p>
        <a href="/Users/">Index</a>    
    </p>
    
    <h3>GET /Users/New</h3>
    <p>
        <a href="/Users/New">New</a>
    </p>
    
    <h3>GET /Users/2</h3>
    <p>
        <a href="/Users/2">Show</a>
    </p>
    
    <h3>GET /Users/2/Edit</h3>
    <p>
        <a href="/Users/2/Edit">Edit</a>
    </p>    
    
</asp:Content>
