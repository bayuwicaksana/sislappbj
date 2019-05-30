<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="ASSIGNMENT_Detailspreview.aspx.cs" Inherits="CASSIGNMENT_Detailspreview" %>-->
<iframe id="iframe" style="position:absolute;
               border:none;
			   left:-1px; 
			   top:-1px; 
			   filter:alpha(opacity=0);
			   z-index:-1;"> </iframe>
ASSIGNMENT<br>
Details found: <strong>{$row_count}.</strong>
{BEGIN display_first}
<span>Displaying first: <strong>{$display_count}</strong>.</span>
{END display_first}

{BEGIN details_data}
<table cellpadding=1 cellspacing=1 border=0  class="detailtable">
<tr>
<td><strong>NO SURAT TUGAS</strong></td>
<td><strong>NAMA</strong></td>
<td><strong>KEGIATAN/PAKET</strong></td>
</tr>
{BEGIN details_row}
<tr>
<td>{$NOSURATTUGAS_value}</td>
<td>{$NIP_value}</td>
<td>{$KODEPBJ_value}</td>
</tr>
{END details_row}
</table>
{END details_data}

