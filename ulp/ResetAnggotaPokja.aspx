<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ResetAnggotaPokja.aspx.vb" Inherits="ResetAnggotaPokja" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reset Anggota Pokja</title>
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
	POKJA Member Succsessfully reseted ...<br/>
	<a href='POKJA_list.aspx'>Back to POKJA list</a>
</body>
</html>
