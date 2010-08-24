<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<FlickTrap.Web.Models.SearchViewModel>" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    
    <%=Html.Partial("AppDescription") %>
    <div class='searchArea span-24'>
        <%=Html.Partial("SearchBox", Model.SearchText) %>
    </div>

    <h4>Found <%=Model.Flicks.Count() %> Flicks</h4>
    <%foreach(var flick in Model.Flicks)
      {
          Html.RenderPartial("FlickListingView", flick);
      } %>
    
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
