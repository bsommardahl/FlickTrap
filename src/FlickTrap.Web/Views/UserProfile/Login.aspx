<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Main.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="additional_styles"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
<h3>Login</h3>
<%using( Html.BeginForm() )
  {%>

<%=Html.EditorForModel()%>
<input type='submit' value="Login" />
<%
  }%>

</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="additional_scripts"></asp:Content>
