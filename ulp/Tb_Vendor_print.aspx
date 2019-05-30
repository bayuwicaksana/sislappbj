<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Tb_Vendor_Print.aspx.cs" Inherits="CTb_Vendor_Print" %>-->
<html>
<head>
<title>Vendor</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
<style>
.grid_block {  
margin-top:5px;
border-collapse: collapse;
align:center;
width:95%;
border:none;
} 
.grid_block td { 
 padding: 5px; 
 margin: 0px; 
 border: solid black 1px;
}
.grid_block .gridspacing {width:20px;border-top-color:white; border-bottom-color:white;background-color:white}
@media print 
{
	a.pdf {display:none}
}
.printpage {page-break-after:always}
#selpage{margin-left:30px;}
</style> 
</head>
<body style="background-color:white">
{BEGIN body}
{BEGIN page}
{$header}

<h1>Vendor</h1>
{BEGIN page_number}
<div id='selpage'>Page {$pageno} of {$maxpages} </div>
{END page_number}

{BEGIN grid_block}

<table align="center" cellpadding=5 class="grid_block">
{BEGIN grid_header}
<tr>
{BEGIN record_header}
{BEGIN KD_VENDOR_fieldheadercolumn}
	<td>
{BEGIN KD_VENDOR_fieldheader}
	<b>KD VENDOR</b>
{END KD_VENDOR_fieldheader}
	</td>
{END KD_VENDOR_fieldheadercolumn}
{BEGIN NAMA_fieldheadercolumn}
	<td>
{BEGIN NAMA_fieldheader}
	<b>NAMA VENDOR</b>
{END NAMA_fieldheader}
	</td>
{END NAMA_fieldheadercolumn}
{BEGIN ALAMAT_fieldheadercolumn}
	<td>
{BEGIN ALAMAT_fieldheader}
	<b>ALAMAT</b>
{END ALAMAT_fieldheader}
	</td>
{END ALAMAT_fieldheadercolumn}
{BEGIN NPWP_fieldheadercolumn}
	<td>
{BEGIN NPWP_fieldheader}
	<b>NPWP</b>
{END NPWP_fieldheader}
	</td>
{END NPWP_fieldheadercolumn}
{BEGIN TELEPON_fieldheadercolumn}
	<td>
{BEGIN TELEPON_fieldheader}
	<b>TELEPON</b>
{END TELEPON_fieldheader}
	</td>
{END TELEPON_fieldheadercolumn}
{BEGIN FAX_fieldheadercolumn}
	<td>
{BEGIN FAX_fieldheader}
	<b>FAX</b>
{END FAX_fieldheader}
	</td>
{END FAX_fieldheadercolumn}
{BEGIN EMAIL_fieldheadercolumn}
	<td>
{BEGIN EMAIL_fieldheader}
	<b>EMAIL</b>
{END EMAIL_fieldheader}
	</td>
{END EMAIL_fieldheadercolumn}
{BEGIN STATUS_fieldheadercolumn}
	<td>
{BEGIN STATUS_fieldheader}
	<b>STATUS</b>
{END STATUS_fieldheader}
	</td>
{END STATUS_fieldheadercolumn}
{BEGIN endrecordheader_block}
	<td class="gridspacing">&nbsp;</td>
{END endrecordheader_block}
{END record_header}
</tr>
{END grid_header}
{BEGIN grid_row}
<tr valign=top {$rowstyle} {$rowattrs}>
{BEGIN grid_record}
{BEGIN KD_VENDOR_fieldcolumn}
<td {$KD_VENDOR_style}>
{$KD_VENDOR_value}
</td>
{END KD_VENDOR_fieldcolumn}
{BEGIN NAMA_fieldcolumn}
<td {$NAMA_style}>
{$NAMA_value}
</td>
{END NAMA_fieldcolumn}
{BEGIN ALAMAT_fieldcolumn}
<td {$ALAMAT_style}>
{$ALAMAT_value}
</td>
{END ALAMAT_fieldcolumn}
{BEGIN NPWP_fieldcolumn}
<td {$NPWP_style}>
{$NPWP_value}
</td>
{END NPWP_fieldcolumn}
{BEGIN TELEPON_fieldcolumn}
<td {$TELEPON_style}>
{$TELEPON_value}
</td>
{END TELEPON_fieldcolumn}
{BEGIN FAX_fieldcolumn}
<td {$FAX_style}>
{$FAX_value}
</td>
{END FAX_fieldcolumn}
{BEGIN EMAIL_fieldcolumn}
<td {$EMAIL_style}>
{$EMAIL_value}
</td>
{END EMAIL_fieldcolumn}
{BEGIN STATUS_fieldcolumn}
<td {$STATUS_style}>
{$STATUS_value}
</td>
{END STATUS_fieldcolumn}
{BEGIN endrecord_block}
<td class="gridspacing">&nbsp;</td>
{END endrecord_block}
{END grid_record}
</tr>
{END grid_row}
<!-- totals row -->
</table>
{END grid_block}
{$footer}
{END page}
{END body}
</body>
</html>
