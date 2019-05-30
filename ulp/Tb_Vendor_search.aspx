<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Tb_Vendor_Search.aspx.cs" Inherits="CTb_Vendor_Search" %>-->
<html>
<head>
<title>Vendor: Advanced search page</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
<style>
#center_block {margin:0 auto;}
#contents_block {text-align:center;width:100%}
#header_block {white-space:nowrap;height:31px;padding-top:5px;}
#main_block {padding:10px 0;width:100%}
#inmain_block {margin:0 10px}
#buttons_block {width:100%;padding-bottom:5px}
#required_block {text-align:left;padding:5px}
#buttons_block > * {margin:0 2px}
#conditions_block {padding:5px;}
</style>
<!--[if IE]>
<style>
#main_block {padding:10px 10;}
#inmain_block {margin:0 0px}
</style>
<![endif]-->
</head>
<body bgcolor=white>
{$header}
{BEGIN body}
{BEGIN contents_block}
<table align=center id="center_block"><tr><td id="contents_block">
	
<b class="xtop"><b class="xb1b"></b><b class="xb2b"></b><b class="xb3b"></b><b class="xb4b"></b></b>
<div id="header_block" class="upeditmenu">Vendor - Advanced search</div>

<div class="main_table_border2">
<div class="main_table_border">

{BEGIN conditions_block}
<DIV id="conditions_block" class="loginshade">
<span class=fieldname>Search for:</span>
<input type="radio" name="type" {$all_checkbox}>All conditions
&nbsp;&nbsp;&nbsp;
<input type="radio" name="type" {$any_checkbox}>Any condition
</div>
{END conditions_block}
<table cellpadding=4 cellspacing=0 border=0 id="fields_block">
<tr valign=center>
<td align=center valign=middle class="headerlist">&nbsp;</td>
<td width=30 align=center valign=middle class=headerlist>NOT</td>
<td align=center valign=middle class="headerlist">&nbsp; </td>
<td align=center valign=middle class="headerlist">&nbsp; </td>
<td align=center valign=middle class="headerlist" style="border-right:0px;">&nbsp;</td></tr>

{BEGIN KD_VENDOR_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>KD VENDOR</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$KD_VENDOR_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_KD_VENDOR}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$KD_VENDOR_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_KD_VENDOR">
	{$KD_VENDOR_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END KD_VENDOR_fieldblock}
{BEGIN NAMA_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>NAMA VENDOR</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$NAMA_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_NAMA}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$NAMA_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_NAMA">
	{$NAMA_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END NAMA_fieldblock}
{BEGIN ALAMAT_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>ALAMAT</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$ALAMAT_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_ALAMAT}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$ALAMAT_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_ALAMAT">
	{$ALAMAT_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END ALAMAT_fieldblock}
{BEGIN NPWP_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>NPWP</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$NPWP_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_NPWP}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$NPWP_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_NPWP">
	{$NPWP_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END NPWP_fieldblock}
{BEGIN TELEPON_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>TELEPON</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$TELEPON_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_TELEPON}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$TELEPON_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_TELEPON">
	{$TELEPON_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END TELEPON_fieldblock}
{BEGIN FAX_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>FAX</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$FAX_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_FAX}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$FAX_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_FAX">
	{$FAX_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END FAX_fieldblock}
{BEGIN EMAIL_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>EMAIL</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$EMAIL_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_EMAIL}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$EMAIL_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_EMAIL">
	{$EMAIL_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END EMAIL_fieldblock}
{BEGIN STATUS_fieldblock}	
<tr>
	<td style="padding-left:15px;" class="editshade_b"><b>STATUS</b>
	<td align=center style="padding-left:10px;" class="editshade_lb"><input type=checkbox {$STATUS_notbox}></td>
	
	<td style="padding-left:10px;" class="editshade_lb">
	{$searchtype_STATUS}
	</td>
	
	<td width=270 style="padding-left:10px;" class="editshade_lb">{$STATUS_editcontrol}</td>

	<td width=270 style="padding-left:10px;" class="editshade_lb"><span id="second_STATUS">
	{$STATUS_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END STATUS_fieldblock}
</table>

<div class="downedit" id="buttons_block">
 <div id="required_block" ><img src="images/icon_required.gif"> - Required field</div>
{BEGIN search_button}
 <span class=buttonborder><input class=button type=button value="Search" {$searchbutton_attrs}></span>
{END search_button} 
{BEGIN reset_button}
 <span class=buttonborder><input class=button type=button value="Reset" {$resetbutton_attrs}></span>
{END reset_button}
{BEGIN back_button}
 <span class=buttonborder><input class=button type=button value="Back to list" {$backbutton_attrs}></span>
{END back_button}
</div>
</div>
</div>
<b class="xbottom"><b class="xb4b"></b><b class="xb3b"></b><b class="xb2b"></b><b class="xb1b"></b></b>
</td></tr></table>
{END contents_block}
{END body}
{$footer}
</body>
</html>
