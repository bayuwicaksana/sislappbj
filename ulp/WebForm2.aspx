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
    <script language="javascript">
    function OnSubmit()
    {
		var queryString = window.location.search;
        document.Main.hid_selected_nip.value = queryString.substring(1);
        document.Main.hid_selected_lang.value = GetDataListFromMultiSelectCombo();
        document.Main.action = "WebForm2.aspx";
        return true;        
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
    
    <form id="Main" method="post" runat="server">
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
        // generate package list to choose
		SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select pbj.kodepbj, namapaket+' pada kegiatan '+namakegiatan+' di skpd '+deskripsi, pbj.kodeskpd from pbj inner join skpd on pbj.kodeskpd = skpd.kodeskpd where lengkap = 'YA' and dikembalikan = 'TIDAK'  and kodestatuspbj in ('DITERIMA') and YEAR(tanggalpengajuan) = year(getdate()) order by pbj.kodeskpd;";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        NameValueCollection opItems = new NameValueCollection();
		
        while (myReader.Read())
            {
			opItems.Add(myReader.GetValue(0).ToString(),myReader.GetValue(1).ToString());
            }
        myReader.Close();
		
        Languege.ListItems = opItems;
    %>
        
    Pilih Paket : <Custom:MultiSelectCombo id="Languege" Name="Languege" MaxSize="2" MaxListHeight="4" runat="server"></Custom:MultiSelectCombo>

    <%
    string sValues = Request["hid_selected_lang"];
    if (sValues != null &&
        sValues.Equals("-1"))
    {
        sValues = "None";
    }
    if (sValues != null && sValues != "")
    {
    %>
    <label id="selected_nip" name="selected_nip"><%=Request["hid_selected_nip"]%></label><br/>
    <label id="selected_lang" name="selected_lang">Paket yang dipilih : <%=sValues%></label><br/>
    <%}%>

    <input type="submit" value="Simpan Paket" onclick="OnSubmit()">
    <input type="hidden" id="hid_selected_lang" name="hid_selected_lang">
    <input type="hidden" id="hid_selected_nip" name="hid_selected_nip">
    
    </form>
	<%
	if (Request["usrgrp"] != null && Request["usrgrp"] != "")
	{
	%>
    <input type="submit" value="Prev" onclick="location.href='WebForm1.aspx?usrgrp=<%=Request["usrgrp"]%>';">
	<%
	}
	if (Request["hid_selected_nip"] != null && Request["hid_selected_nip"] != "")
	{
	%>
    <input type="submit" value="Prev" onclick="location.href='WebForm1.aspx?<%=Request["hid_selected_nip"]%>';">
	<%
	}
    if (Request["hid_selected_lang"] != null && Request["hid_selected_lang"] != "")
    {
	%>
    <input type="submit" value="Next" onclick="location.href='WebForm3.aspx?<%=Request["hid_selected_nip"]%>&pkg=<%=Request["hid_selected_lang"]%>';">
	<%
	}
	%>
    
  </body>
</html>
