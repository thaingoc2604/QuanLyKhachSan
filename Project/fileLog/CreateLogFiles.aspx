<%@ Page language="c#" Codebehind="CreateLogFiles.aspx.cs" AutoEventWireup="false" Inherits="CreateLogFiles.CreateLogFiles1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CreateLogFiles</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="CreateLogFiles" method="post" runat="server">
			<asp:Label id="Label1" runat="server">Please specify your Fullpath filename :</asp:Label>
			<asp:TextBox id="TxtFilename" runat="server" Columns="35"></asp:TextBox>
			<asp:Button id="BtnFind" runat="server" Text="Search"></asp:Button>
			<br>
			<asp:Label id="Msg" runat="server" Visible="False" ForeColor="Red"></asp:Label></form>
	</body>
</HTML>
