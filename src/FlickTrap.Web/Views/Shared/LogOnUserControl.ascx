﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%: Page.User.Identity.Name %></b>!
        | <%: Html.ActionLink("Log Off", "LogOff", "UserProfile") %>
<%
    }
    else {
%> 
        <%: Html.ActionLink( "Log In", "Login", "UserProfile" )%>
        | <%: Html.ActionLink("Register", "Create", "UserProfile") %>
<%
    }
%>
