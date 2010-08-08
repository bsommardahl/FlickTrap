<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<FlickTrap.Web.Models.HomeViewModel>" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
<h1>Recently Released</h1>
<ul>
<%foreach(var flick in Model.RecentlyReleasedFlicks) { %>
    <li>
        <a href='<%=ResolveUrl("~/Flick/" + flick.Id) %>'><%=flick.Name %> (Rated <%=flick.Rating %>)</a>
    </li>
<%} %>
</ul>

<h1>Soon to Released</h1>
<ul>
<%foreach(var flick in Model.UnreleasedFlicks) { %>
    <li>
        <a href='<%=ResolveUrl("~/Flick/" + flick.Id) %>'><%=flick.Name %> (Rated <%=flick.Rating %>)</a>
    </li>
<%} %>
</ul>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
