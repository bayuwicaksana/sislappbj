<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PENGADAAN_LANGSUNG_Print.aspx.cs" Inherits="CPENGADAAN_LANGSUNG_Print" %>-->
<html>
<head>
<title>PENGADAAN LANGSUNG</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
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
<body style="background-color:white">
{BEGIN body}
{BEGIN page}
<br/><br/><br/>
{$header}

<h1>PENGADAAN LANGSUNG</h1>
{BEGIN page_number}
<div id='selpage'>Page {$pageno} of {$maxpages} </div>
{END page_number}

{BEGIN grid_block}

<table align="center" cellpadding=5 class="grid_block">
{BEGIN grid_header}
<tr>
{BEGIN record_header}
{BEGIN NAMAKEGIATAN_fieldheadercolumn}
	<td>
{BEGIN NAMAKEGIATAN_fieldheader}
	<b>NAMA KEGIATAN</b>
{END NAMAKEGIATAN_fieldheader}
	</td>
{END NAMAKEGIATAN_fieldheadercolumn}
{BEGIN NAMAPAKET_fieldheadercolumn}
	<td>
{BEGIN NAMAPAKET_fieldheader}
	<b>NAMA PAKET</b>
{END NAMAPAKET_fieldheader}
	</td>
{END NAMAPAKET_fieldheadercolumn}
{BEGIN KODESKPD_fieldheadercolumn}
	<td>
{BEGIN KODESKPD_fieldheader}
	<b>SKPD</b>
{END KODESKPD_fieldheader}
	</td>
{END KODESKPD_fieldheadercolumn}
{BEGIN TANGGALKONTRAK_fieldheadercolumn}
	<td>
{BEGIN TANGGALKONTRAK_fieldheader}
	<b>TANGGAL KONTRAK</b>
{END TANGGALKONTRAK_fieldheader}
	</td>
{END TANGGALKONTRAK_fieldheadercolumn}
{BEGIN PAGU_fieldheadercolumn}
	<td>
{BEGIN PAGU_fieldheader}
	<b>PAGU</b>
{END PAGU_fieldheader}
	</td>
{END PAGU_fieldheadercolumn}
{BEGIN HPS_fieldheadercolumn}
	<td>
{BEGIN HPS_fieldheader}
	<b>HPS</b>
{END HPS_fieldheader}
	</td>
{END HPS_fieldheadercolumn}
{BEGIN NILAIKONTRAK_fieldheadercolumn}
	<td>
{BEGIN NILAIKONTRAK_fieldheader}
	<b>NILAI KONTRAK</b>
{END NILAIKONTRAK_fieldheader}
	</td>
{END NILAIKONTRAK_fieldheadercolumn}
{BEGIN PEMENANG_fieldheadercolumn}
	<td>
{BEGIN PEMENANG_fieldheader}
	<b>PEMENANG</b>
{END PEMENANG_fieldheader}
	</td>
{END PEMENANG_fieldheadercolumn}
{BEGIN KETERANGAN_fieldheadercolumn}
	<td>
{BEGIN KETERANGAN_fieldheader}
	<b>JENIS KEGIATAN</b>
{END KETERANGAN_fieldheader}
	</td>
{END KETERANGAN_fieldheadercolumn}
{BEGIN PEJABATPENGADAAN_fieldheadercolumn}
	<td>
{BEGIN PEJABATPENGADAAN_fieldheader}
	<b>PEJABAT PENGADAAN</b>
{END PEJABATPENGADAAN_fieldheader}
	</td>
{END PEJABATPENGADAAN_fieldheadercolumn}
{BEGIN MENGETAHUI_fieldheadercolumn}
	<td>
{BEGIN MENGETAHUI_fieldheader}
	<b>MENGETAHUI</b>
{END MENGETAHUI_fieldheader}
	</td>
{END MENGETAHUI_fieldheadercolumn}
{BEGIN endrecordheader_block}
	<td class="gridspacing">&nbsp;</td>
{END endrecordheader_block}
{END record_header}
</tr>
{END grid_header}
{BEGIN grid_row}
<tr valign=top {$rowstyle} {$rowattrs}>
{BEGIN grid_record}
{BEGIN NAMAKEGIATAN_fieldcolumn}
<td {$NAMAKEGIATAN_style}>
{$NAMAKEGIATAN_value}
</td>
{END NAMAKEGIATAN_fieldcolumn}
{BEGIN NAMAPAKET_fieldcolumn}
<td {$NAMAPAKET_style}>
{$NAMAPAKET_value}
</td>
{END NAMAPAKET_fieldcolumn}
{BEGIN KODESKPD_fieldcolumn}
<td {$KODESKPD_style}>
{$KODESKPD_value}
</td>
{END KODESKPD_fieldcolumn}
{BEGIN TANGGALKONTRAK_fieldcolumn}
<td {$TANGGALKONTRAK_style}>
{$TANGGALKONTRAK_value}
</td>
{END TANGGALKONTRAK_fieldcolumn}
{BEGIN PAGU_fieldcolumn}
<td {$PAGU_style}>
{$PAGU_value}
</td>
{END PAGU_fieldcolumn}
{BEGIN HPS_fieldcolumn}
<td {$HPS_style}>
{$HPS_value}
</td>
{END HPS_fieldcolumn}
{BEGIN NILAIKONTRAK_fieldcolumn}
<td {$NILAIKONTRAK_style}>
{$NILAIKONTRAK_value}
</td>
{END NILAIKONTRAK_fieldcolumn}
{BEGIN PEMENANG_fieldcolumn}
<td {$PEMENANG_style}>
{$PEMENANG_value}
</td>
{END PEMENANG_fieldcolumn}
{BEGIN KETERANGAN_fieldcolumn}
<td {$KETERANGAN_style}>
{$KETERANGAN_value}
</td>
{END KETERANGAN_fieldcolumn}
{BEGIN PEJABATPENGADAAN_fieldcolumn}
<td {$PEJABATPENGADAAN_style}>
{$PEJABATPENGADAAN_value}
</td>
{END PEJABATPENGADAAN_fieldcolumn}
{BEGIN MENGETAHUI_fieldcolumn}
<td {$MENGETAHUI_style}>
{$MENGETAHUI_value}
</td>
{END MENGETAHUI_fieldcolumn}
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
