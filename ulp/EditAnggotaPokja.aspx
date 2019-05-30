<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Import namespace="System.Collections"%>
<%@ Import namespace="System.Collections.Specialized"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Register Tagprefix="Custom" Tagname="MultiSelectCombo" Src="MultiSelectCombo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>Edit Anggota POKJA</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 8.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
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
	Daftar Anggota POKJA :
	<br/>
    <%
        // generate pokja member
	SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select NAMA, AKTORPOKJA.NIP from AKTORPOKJA inner join AKTOR on AKTORPOKJA.NIP=AKTOR.NIP where AKTORPOKJA.KODEPOKJA = '" + Request["usrgrp"] + "' and TAHUN = "+DateTime.Now.Year.ToString()+";";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		
        while (myReader.Read())
            {
			Response.Write(myReader.GetValue(0).ToString() + " | <a href='hapusAnggotaPokja.aspx?kodepokja="+ Request["usrgrp"] +"&nip="+myReader.GetValue(1).ToString()+"'>hapus</a><br/>");
            }
        myReader.Close();		
    %>

	<br/>        
    <input type="submit" value="Back to POKJA edit" onclick="location.href='POKJA_edit.aspx?editid1=<%=Request["usrgrp"]%>';">
  </body>
</html>
