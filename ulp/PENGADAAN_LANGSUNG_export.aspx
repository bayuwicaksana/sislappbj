<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PENGADAAN_LANGSUNG_Export.aspx.cs" Inherits="CPENGADAAN_LANGSUNG_Export" %>-->
<html>
<head>
<LINK REL="stylesheet" href="include/style.css" type="text/css"></LINK>
<!--[if IE]><LINK REL="stylesheet" href="include/styleIE.css" type="text/css"></LINK><![endif]-->
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
<body>
<br/><br/><br/>
{$header}
{BEGIN body}	
	
<TABLE CELLPADDING=0 CELLSPACING=0 align=center border=0>
<tr><td>

<div class="xboxcontentb">
<table cellpadding=0 cellspacing=0 border=0 width=500>
<tr><td>
<table cellpadding=0 cellspacing=0 border=0 width=100%>
<tr>
<td class=upeditmenu_left width=5px height=36px></td>
<td height=36px>
    <table cellpadding=0 cellspacing=0 border=0 width=100% height=36px>
        <tr>
		    {BEGIN rangeheader_block}
			<td width=50% class=upeditmenu_center align=center height=36px>Data range</td>
			{END rangeheader_block}
		    <td class=upeditmenu_center align=center height=36px>Output format</td>
        </tr>
    </table>
</td>	
<td class=upeditmenu_right width=5px height=36px></td>
</tr>
</table>
</td></tr>

	<tr><td colspan=3 style="padding:7px"  class=borderedit>
	    <div class=xboxcontentb>
	    <table cellpadding=0 cellspacing=0 border=0 width=100%>
	        <tr valign=top>
		    {BEGIN range_block}
	        <td width=50% class=export_left>
		        <INPUT TYPE="Radio" NAME="records" VALUE="all" CHECKED> All records<br>
		        <INPUT TYPE="Radio" NAME="records" VALUE="page"> Current page only<br>
	        </td>
		    {END range_block}
	        <td width=50% class=export_right>
		        <INPUT TYPE="Radio" NAME="type" VALUE="excel" CHECKED> <img src="images/excel.gif"> Excel
		        <br><INPUT TYPE="Radio" NAME="type" VALUE="word"> <img src="images/word.gif"> Word
		        <br><INPUT TYPE="Radio" NAME="type" VALUE="csv"> <img src="images/csv.gif"> CSV (comma separated values)
		        <br><INPUT TYPE="Radio" NAME="type" VALUE="xml"> <img src="images/xml.gif"> XML
	        </td>
	        </tr>
	        <tr><td class=menuline colspan=2></td></tr>
	        <tr height=30 valign=middle>
	        <td colspan=2 align=center class=downedit style="padding-top:2px">
	            <span class=buttonborder><input type=submit name=btnSubmit  value="&nbsp;&nbsp;Export&nbsp;&nbsp;" class=button></span>
	        </td></tr>
	    </table>
	    </div>
        <b class="xbottom"><b class="xb4a"></b><b class="xb3a"></b><b class="xb2a"></b><b class="xb1a"></b></b>
   </td></tr>
   </table>
</div>
<b class="xbottom"><b class="xb4b4"></b><b class="xb3b4"></b><b class="xb2b4"></b><b class="xb1b4"></b></b>
</td></tr>
</table>	
{END body}
{$footer}

</body>
</html>

