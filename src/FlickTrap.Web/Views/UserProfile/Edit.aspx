<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<FlickTrap.Web.Models.UserProfileViewModel>" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <h2>Edit Profile</h2>
    <% using(Html.BeginForm()) { %>
        <%=Html.EditorForModel() %>
        <input type='submit' value='Register' />
    <%} %>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
