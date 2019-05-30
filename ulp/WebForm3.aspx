<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Import namespace="System.Collections"%>
<%@ Import namespace="System.Collections.Specialized"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Register Tagprefix="Custom" Tagname="MultiSelectCombo" Src="MultiSelectCombo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>Add Assignment</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 8.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <script runat="server">
      protected void AddButton_Click(Object sender, EventArgs e)
      {
         Response.Redirect("tambah_penugasan.aspx?usrgrp="+Request.QueryString["usrgrp"]+"&nip="+Request.QueryString["nip"]+"&pkg="+Request.QueryString["pkg"]+"&no="+NoSuratTugas.Text);
      }
      protected void PrevButton_Click(Object sender, EventArgs e)
      {
         Response.Redirect("WebForm2.aspx?nip="+Request.QueryString["nip"]+"&usrgrp="+Request.QueryString["usrgrp"]);
      }
      protected void CancelButton_Click(Object sender, EventArgs e)
      {
         Response.Redirect("surat_tugas.aspx?usrgrp="+Request.QueryString["usrgrp"]);
      }
    </script>
	<STYLE>
	#toplinks_block {padding:2px 5px}
	#toplinks_block > * {margin:4px 6px;vertical-align:middle;}
	#menu_block {clear:left;margin-top:10px;}
	#menu_block div {float:left;}
	#menu_block div div {margin-right:1px;float:none;}
	#menu_block a {white-space:nowrap;}
	.menuitem {padding:6px 18px 10px 13px;margin-bottom:1px}
	.menuitem_active {padding:6px 18px 11px 13px;}
	#search_records_block {padding:9px 10px 13px 10px;text-align:right}
	#search_records_block > * {margin:2px 2px;vertical-align:middle}
	#details_block, #pages_block {white-space:nowrap}
	#recordcontrols_block {padding:13px 10px 9px 10px;text-align:right}
	#recordcontrols > *,#newrecordcontrols > * {margin:2px 2px;vertical-align:middle}
	#search_records_top {clear:left}
	#message_block {text-align:center;}
	#grid_block {margin-top:10px;}
	.headerlist_right2 *,.headerlist * {vertical-align:middle}
	.grid_recordheader {padding:0 5px 5px}
	.grid_recordheader * {margin:0px 5px; vertical-align:middle}
	#mastertable_block {margin:10px 0}
	</STYLE>

	<link REL="stylesheet" href="include/menuCSS.css" type="text/css">
  </head>
  <body MS_POSITIONING="GridLayout">
    
  <form id="form1" runat="server">
	<table width="100%"  border="0" cellpadding="0" cellspacing="0" style="background-repeat:no-repeat">
	  <tr>
		<td  align="left"  style="width: 100%; background:repeat url(images/HeaderulpFill.jpg);">
		<img src="images/Headerulp1.jpg"   />
		</td>
	  </tr>
	</table>
	<div id="menu" runat="server" style="width: 100%;">
	</div>
	<br/>
    <%
		string sNIP = Request.QueryString["nip"];
		string sPkg = Request.QueryString["pkg"];
		if (sNIP != "" && sPkg != "") {
    %>
    <label id="selected_nip" name="selected_nip">NIP berikut : <%=sNIP%></label><br/>
    <label id="selected_pkg" name="selected_pkg">Ditugaskan pada paket : <%=sPkg%></label><br/>
	<%}%>
        
    Dengan No. Surat Tugas : <br/><asp:TextBox ID="NoSuratTugas" runat="server"/></br>

    <asp:Button ID="AddButton" Text="Simpan Penugasan" OnClick="AddButton_Click" runat="server"/></br></br>
    <asp:Button ID="PrevButton" Text="Prev" OnClick="PrevButton_Click" runat="server"/>
    <asp:Button ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" runat="server"/>
  </form>
    
  </body>
</html>
