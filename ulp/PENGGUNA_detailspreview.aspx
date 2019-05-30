<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PENGGUNA_Detailspreview.aspx.cs" Inherits="CPENGGUNA_Detailspreview" %>-->
<iframe id="iframe" style="position:absolute;
               border:none;
			   left:-1px; 
			   top:-1px; 
			   filter:alpha(opacity=0);
			   z-index:-1;"> </iframe>
PENGGUNA<br>
Details found: <strong>{$row_count}.</strong>
{BEGIN display_first}
<span>Displaying first: <strong>{$display_count}</strong>.</span>
{END display_first}

{BEGIN details_data}
<table cellpadding=1 cellspacing=1 border=0  class="detailtable">
<tr>
<td><strong>KODE PENGGUNA</strong></td>
<td><strong>NAMA PENGGUNA</strong></td>
<td><strong>KATA KUNCI</strong></td>
<td><strong>KELOMPOK PENGGUNA</strong></td>
</tr>
{BEGIN details_row}
<tr>
<td>{$KODEPENGGUNA_value}</td>
<td>{$NAMA_value}</td>
<td>{$KATAKUNCI_value}</td>
<td>{$KODEKELOMPOK_value}</td>
</tr>
{END details_row}
</table>
{END details_data}

