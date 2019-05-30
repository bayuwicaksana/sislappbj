<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="KELENGKAPAN_Detailspreview.aspx.cs" Inherits="CKELENGKAPAN_Detailspreview" %>-->
<iframe id="iframe" style="position:absolute;
               border:none;
			   left:-1px; 
			   top:-1px; 
			   filter:alpha(opacity=0);
			   z-index:-1;"> </iframe>
KELENGKAPAN<br>
Details found: <strong>{$row_count}.</strong>
{BEGIN display_first}
<span>Displaying first: <strong>{$display_count}</strong>.</span>
{END display_first}

{BEGIN details_data}
<table cellpadding=1 cellspacing=1 border=0  class="detailtable">
<tr>
<td><strong>KODE KELENGKAPAN</strong></td>
<td><strong>DOKUMEN</strong></td>
<td><strong>JENIS KEGIATAN</strong></td>
</tr>
{BEGIN details_row}
<tr>
<td>{$KODEKELENGKAPAN_value}</td>
<td>{$KODEDOKUMEN_value}</td>
<td>{$KODEJENISKEGIATAN_value}</td>
</tr>
{END details_row}
</table>
{END details_data}

