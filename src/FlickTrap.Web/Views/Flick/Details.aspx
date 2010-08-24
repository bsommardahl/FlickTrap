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
            <div class='trapButton'>
                <a href='<%=ResolveUrl("~/Flick/" + (Model.IsTrapped ? "Untrap" : "Trap") + "/" + Model.ImdbId) %>' title="<%=Model.IsTrapped ? "Untrap Flick" : "Trap Flick" %>"><%=Model.IsTrapped ? "Untrap" : "Trap" %></a>
            </div>
            <%} %>
        </div>

    </div>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
