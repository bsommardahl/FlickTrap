<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>

    <form action="<%=ResolveUrl("~/Search") %>" method="post">
        <div class='searchBox'>
            <input type="text" name="searchText" class='textBox' value="<%=Model %>" />
            <input type="submit" value="Search for Flicks" class='searchButton' />
        </div>
    </form>