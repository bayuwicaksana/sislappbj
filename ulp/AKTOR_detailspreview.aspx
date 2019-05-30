<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="AKTOR_Detailspreview.aspx.cs" Inherits="CAKTOR_Detailspreview" %>-->
<iframe id="iframe" style="position:absolute;
               border:none;
			   left:-1px; 
			   top:-1px; 
			   filter:alpha(opacity=0);
			   z-index:-1;"> </iframe>
AKTOR<br>
Details found: <strong>{$row_count}.</strong>
{BEGIN display_first}
<span>Displaying first: <strong>{$display_count}</strong>.</span>
{END display_first}

{BEGIN details_data}
<table cellpadding=1 cellspacing=1 border=0  class="detailtable">
<tr>
<td><strong>NIP</strong></td>
<td><strong>NAMA</strong></td>
<td><strong>JABATAN</strong></td>
<td><strong>TIPE</strong></td>
</tr>
{BEGIN details_row}
<tr>
<td>{$NIP_value}</td>
<td>{$NAMA_value}</td>
<td>{$KODEJABATAN_value}</td>
<td>{$KODETIPE_value}</td>
</tr>
{END details_row}
</table>
{END details_data}

