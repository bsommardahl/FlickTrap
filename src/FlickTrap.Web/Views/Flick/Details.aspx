<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<FlickTrap.Web.Models.FlickDetailsViewModel>" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    
    <div class='flickDetails'>

        <div class='thumbnail span-5'>
            <img src='<%=ResolveUrl("~/Image/?width=180&path=" + Model.ThumbnailUrl) %>' alt='<%=Model.Name %>' />
        </div>
    
        <div class='details span-15'>
            <div class='release'><%=Model.TheaterReleaseDate.HasValue ? Model.TheaterReleaseDate.Value.ToShortDateString() : "" %></div>
            <div class='name'><%=Model.Name %></div>
            <div class='userRating rating <%=Model.Stars %>star'></div>
            <div class='description'><%=Model.Description %></div>
            <% if(Model.IsTrappable) { %>
            <a href='<%=ResolveUrl("~/Flick/ToggleTrapping/" + Model.RemoteId + "?isTrapped=" + Model.IsTrapped) %>' class='trap_button'><%=Model.IsTrapped ? "Remove from My Flicks" : "Add to My Flicks" %></a>
            <%} %>
        </div>

    </div>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
