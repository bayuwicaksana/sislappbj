<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Tb_Vendor_Export.aspx.cs" Inherits="CTb_Vendor_Export" %>-->
<html>
<link REL="stylesheet" href="include/style.css" type="text/css">
<body>
{$header}
{BEGIN body}

<TABLE CELLPADDING=0 CELLSPACING=0 align=center border=0>
<tr><td>
<table cellpadding=0 cellspacing=0 border=0 width=100%>
<tr>
<td class=headerlistup_left width=7px valign=middle align=center height=31></td>
<td class=upeditmenu_gif valign=middle align=center height=31>
<table cellpadding=0 cellspacing=0 border=0 width=100%>
<tr>{BEGIN rangeheader_block}<td align=center><font color=white><b>Data range</b></font></td>{END rangeheader_block}
		<td align=center><font color=white><b>Output format</b></font></td>
	</tr>
</table>
</td>
<td class=headerlistup_right width=7px valign=middle align=center height=31></td>
</tr>
</table>

</td></tr>
<tr><td>

<TABLE CELLPADDING=0 CELLSPACING=0 align=center border=0 class="main_table_border2" width=550>
<tr><td>
<TABLE CELLPADDING=0 CELLSPACING=0 align=center border=0 class="main_table_border" width=550>
    <tr valign=top>
    {BEGIN range_block}
    <td width=50% class=editshade_b style="vertical-align: top;">
        <INPUT TYPE="Radio" NAME="records" VALUE="all" CHECKED> All records<br>
        <INPUT TYPE="Radio" NAME="records" VALUE="page"> Current page only<br>
    </td>
    {END range_block}
    <td width=50% class=editshade_lb style="vertical-align: top;">
        <INPUT TYPE="Radio" NAME="type" VALUE="excel" CHECKED> <img src="images/excel.gif"> Excel
        <br><INPUT TYPE="Radio" NAME="type" VALUE="word"> <img src="images/word.gif"> Word
        <br><INPUT TYPE="Radio" NAME="type" VALUE="csv"> <img src="images/csv.gif"> CSV (comma separated values)
        <br><INPUT TYPE="Radio" NAME="type" VALUE="xml"> <img src="images/xml.gif"> XML
    </td>
    </tr>
    <tr height=30 valign=middle>
    <td colspan=2 align=center class=downedit>
        <input type=submit name=btnSubmit  value="&nbsp;&nbsp;Export&nbsp;&nbsp;" class=button>
    </td></tr>
   </table>
    </td></tr>
   </table>
</td></tr>
<tr><td>
<table cellpadding=0 cellspacing=0 border=0 width=100%>
<tr>
<td class=headerlistdown_left width=8px valign=middle align=center height=15></td>
<td class=downeditmenu valign=middle align=center height=15>&nbsp;</td>
<td class=headerlistdown_right width=8px valign=middle align=center height=15></td>
</tr>
</table>
</td></tr>
</TABLE>
{END body}
{$footer}

</body>
</html>

