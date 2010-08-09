<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FlickTrap.Web.Models.FlickListingViewModel>" %>
<div class='flickListing'>
    <div class='name'>
        <a href='<%=ResolveUrl("~/Flick/Details/" + Model.ImdbId) %>' alt='<%=Model.Name + " Details" %>'>
            <%=Model.Name %>
        </a>
    </div>

</div>
