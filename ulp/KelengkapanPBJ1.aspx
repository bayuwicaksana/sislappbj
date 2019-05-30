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
		//var queryString = window.location.search;
        //document.Main.hid_selected_pbj.value = queryString.substring(1);
		//var textOleh = document.getElementById('txtOleh');
        //document.Main.hid_selected_oleh.value = textOleh;
        document.Main.hid_selected_lang.value = GetDataListFromMultiSelectCombo();
        document.Main.action = "KELENGKAPANPBJ1.aspx";
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
        // generate ulp member list to choose
		SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select kodekelengkapan from kelengkapan where kodejeniskegiatan in ( select kodejeniskegiatan from pbj where kodepbj = '"+ Request.QueryString["masterkey1"] +"' );";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        NameValueCollection opItems = new NameValueCollection();
		
        while (myReader.Read())
            {
			opItems.Add(myReader.GetValue(0).ToString(),myReader.GetValue(0).ToString());
            }
        myReader.Close();
		
        Languege.ListItems = opItems;
	%>
    Pilih Kelengkapan Pengadaan Barang/Jasa : <Custom:MultiSelectCombo id="Languege" Name="Languege" MaxSize="2" MaxListHeight="4" runat="server"></Custom:MultiSelectCombo>
    Diterima oleh : <br/><input type="text" name="txtOleh" id="txtOleh"></br>
    <%
	string sTanggal = System.DateTime.Now.ToString("dd.MM.yyyy");
    string sValues = Request["hid_selected_oleh"];
    if (sValues != null &&
        sValues.Equals("-1"))
    {
        sValues = "None";
    }
    if (sValues != null && sValues != "")
    {
    %>
    <label id="selected_lang" name="selected_lang">Kelengkapan berikut : <%=sValues%></label><br/>
    <label id="selected_pkg" name="selected_pkg">Untuk : <%=Request["hid_selected_pbj"]%></label><br/>
    <label id="selected_tgl" name="selected_tgl">Diterima pada tanggal : <%=sTanggal%></label><br/>
    <label id="selected_terima" name="selected_terima">Oleh : <%=Request["hid_selected_oleh"]%></label><br/>
	<%}%>
    <input type="submit" value="Simpan Kelengkapan" onclick="OnSubmit()">
    <input type="hidden" id="hid_selected_lang" name="hid_selected_lang">
    <input type="hidden" id="hid_selected_pbj" name="hid_selected_pbj">
	<input type="hidden" id="hid_selected_oleh" name="hid_selected_oleh">
  </form>
    <input type="submit" value="Simpan" onclick="location.href='tambah_kelengkapanpbj.aspx?<%=Request["hid_selected_pbj"]%>&lkppbj=<%=Request["hid_selected_lang"]%>&oleh=<%=Request["hid_selected_oleh"]%>';">
    <input type="submit" value="Batal" onclick="location.href='KELENGKAPANPBJ_list.aspx?<%=Request["hid_selected_pbj"]%>&mastertable=PBJ';">
    
  </body>
</html>
