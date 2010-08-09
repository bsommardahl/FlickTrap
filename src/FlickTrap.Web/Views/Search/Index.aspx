<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<FlickTrap.Web.Models.SearchViewModel>" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <form action="<%=ResolveUrl("~/Search") %>" method="post">
        <h3>Search for flicks:</h3>
        <div class='searchBox'>
            <input type="text" name="searchText" />
            <input type="submit" value="Search" />
        </div>
    </form>

    <h1>Found <%=Model.Flicks.Count() %> Flicks</h1>
    <%foreach(var flick in Model.Flicks)
      {
          Html.RenderPartial("FlickListingView", flick);
      } %>
    
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
