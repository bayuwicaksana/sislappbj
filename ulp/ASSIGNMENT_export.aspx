<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="ASSIGNMENT_Export.aspx.cs" Inherits="CASSIGNMENT_Export" %>-->
<html>
<link REL="stylesheet" href="include/style.css" type="text/css">
<body>

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

