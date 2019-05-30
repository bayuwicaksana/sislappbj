<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Import namespace="System.Collections"%>
<%@ Import namespace="System.Collections.Specialized"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="System.Data.SqlClient"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>Create Surat Hasil Pelelangan</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 8.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <script runat="server">
      protected void AddButton_Click(Object sender, EventArgs e)
      {
         Response.Redirect("tambah_hasil_lelang.aspx?usrgrp="+Request.QueryString["usrgrp"]+"&kodepbj="+Request.QueryString["kodepbj"]+"&no="+NoSurat.Text+"&tgl1="+TglPenetapan.Text+"&nama="+NmPemenang.Text+"&harga="+HrgPemenang.Text+"&addr="+AddrPemenang.Text+"&tgl2="+TglSanggah.Text+"&nego="+HrgNego.Text);
      }
      protected void CancelButton_Click(Object sender, EventArgs e)
      {
         Response.Redirect("surat_hasil_lelang.aspx?usrgrp="+Request.QueryString["usrgrp"]);
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
		string sPkg = Request.QueryString["kodepbj"];
		if (sPkg != "") {
    %>
    No. Surat : <br/><asp:TextBox ID="NoSurat" runat="server"/></br>
    Tgl. Pengumuman Pemenang : <br/><asp:TextBox ID="TglPenetapan" runat="server"/> format : yyyy-mm-dd</br>
    Pemenang : <br/><asp:TextBox ID="NmPemenang" runat="server"/></br>
    Harga Ditawarkan : <br/><asp:TextBox ID="HrgPemenang" runat="server"/> format : tanpa Rp. dan tanda baca</br>
    Harga Setelah Negosiasi: <br/><asp:TextBox ID="HrgNego" runat="server"/> format : tanpa Rp. dan tanda baca</br>
    Alamat : <br/><asp:TextBox ID="AddrPemenang" runat="server"/></br>
    Tgl. Masa Sanggah : <br/><asp:TextBox ID="TglSanggah" runat="server"/> format : yyyy-mm-dd</br>
	<%}%>

    <asp:Button ID="AddButton" Text="Simpan" OnClick="AddButton_Click" runat="server"/></br></br>
    <asp:Button ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" runat="server"/>
  </form>
    
  </body>
</html>
