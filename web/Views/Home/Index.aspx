<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<FlickTrap.Web.Models.HomeViewModel>" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">

<%=Html.Partial("AppDescription") %>
    
<div class='searchArea span-24'>
    <div class='span-24'>
        <%=Html.Partial("SearchBox", "") %>
    </div>
</div>

<%--<div class='span-12'>
<h3>Recently Released</h3>
    <%foreach(var flick in Model.RecentlyReleasedFlicks)
      {
          Html.RenderPartial("FlickListingView", flick);
      } %>
</div>

<div class='span-12 last'>
    <h3>Soon to Released</h3>
    <%foreach(var flick in Model.UnreleasedFlicks)
          {
              Html.RenderPartial("FlickListingView", flick);
          } %>
</div>--%>


</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
