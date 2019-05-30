<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="KELENGKAPANPBJ_Detailspreview.aspx.cs" Inherits="CKELENGKAPANPBJ_Detailspreview" %>-->
<iframe id="iframe" style="position:absolute;
               border:none;
			   left:-1px; 
			   top:-1px; 
			   filter:alpha(opacity=0);
			   z-index:-1;"> </iframe>
KELENGKAPAN PBJ<br>
Details found: <strong>{$row_count}.</strong>
{BEGIN display_first}
<span>Displaying first: <strong>{$display_count}</strong>.</span>
{END display_first}

{BEGIN details_data}
<table cellpadding=1 cellspacing=1 border=0  class="detailtable">
<tr>
<td><strong>KODE BPJ</strong></td>
<td><strong>KODE KELENGKAPAN</strong></td>
<td><strong>TANGGAL DITERIMA</strong></td>
<td><strong>PENERIMA KELENGKAPAN</strong></td>
</tr>
{BEGIN details_row}
<tr>
<td>{$KODEBPJ_value}</td>
<td>{$KODEKELENGKAPAN_value}</td>
<td>{$TANGGALDITERIMA_value}</td>
<td>{$PENERIMAKELENGKAPAN_value}</td>
</tr>
{END details_row}
</table>
{END details_data}

