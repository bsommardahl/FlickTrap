<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<FlickTrap.Web.Models.UserProfileLoginRequest>" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="AdditionalStyles" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

<h3>Login</h3>
<% using(Html.BeginForm()) { %>
    <%=Html.EditorForModel() %>
    <input type='submit' value='Login' />
<% } %>
</asp:Content>
<asp:Content runat="server" ID="AdditionalScripts" ContentPlaceHolderID="additional_scripts"></asp:Content>
