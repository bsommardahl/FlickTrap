<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FlickTrap.Web.Models.FlickListingViewModel>" %>
<div class='flickListing span-7'>
    <div class='thumbnail span-2'>
        <img src='<%=ResolveUrl("~/Image/?width=65&path=" + Model.ThumbnailUrl) %>' alt='<%=Model.Name %>' />
    </div>
    
    <div class='details span-4'>
        <div class='name'>
            <a href='<%=ResolveUrl("~/Flick/Details/" + Model.RemoteId) %>' title='<%=Model.Name + " Details" %>'>
                <%=Model.Name %>
            </a>
        </div>
        <div class='release'><%=Model.TheaterReleaseDate.Year.ToString() %></div>
        <div class='userRating rating <%=Model.Stars %>star'></div>
       
        <% if(Model.IsTrappable) { %>
        <button class='trap_button <%=Model.IsTrapped ? "remove_from_flicks" : "add_to_flicks" %>' value='<%=ResolveUrl("~/Flick/ToggleTrapping/" + Model.RemoteId + "?isTrapped=" + Model.IsTrapped) %>'>
            Toggle Trapping     
        </button>
        <%} %>
    </div>
</div>
