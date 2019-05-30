<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Tb_Vendor_Add.aspx.cs" Inherits="CTb_Vendor_Add" %>-->
<html>
<head><title>Vendor</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
{BEGIN style_block}<STYLE>
#center_block{$id} {width:45%;margin:0 auto;}
#contents_block{$id} {text-align:center;}
#header_block{$id} {white-space:nowrap;height:31px;padding-top:5px;text-align:center;}
#main_block{$id} {padding:10px 0;text-align:center;}
#inmain_block{$id} {margin:0 10px}
#fields_block{$id} {width:100%}
#buttons_block{$id} {padding-bottom:5px;white-space:nowrap;}
#required_block{$id} {text-align:left;padding:5px}
#buttons_block{$id} > * {margin:0 2px}
</STYLE>
<!--[if IE]>
<STYLE>
#main_block{$id} {padding:10px 10;}
#inmain_block{$id} {margin:0 0px;width:100%}
</STYLE>
<![endif]-->{END style_block}
<link REL="stylesheet" href="include/menuCSS.css" type="text/css">
</head>
<body>
{$header}
{BEGIN body}
<br/><br/><br/>
<TABLE align=center id="center_block{$id}" cellpadding=0 cellspacing=0 border=0><tr><td>
{BEGIN flybody}
<b class="xtop"><b class="xb1b"></b><b class="xb2b"></b><b class="xb3b"></b><b class="xb4b"></b></b>
<div id="header_block{$id}" class="upeditmenu">
Vendor, Add new record
</div>
<div class="main_table_border2" style="border: 1px solid #516C81;">
<TABLE CELLPADDING=0 CELLSPACING=0 align=center border=0 class="main_table_border">
{BEGIN message_block}
<div id="message_block{$id}" class=downedit>{$message}</div>
{END message_block}

{BEGIN NAMA_fieldblock}
  <tr style="padding:3px">
    <td class=editshade_b width=150 style="padding-left:15px;">NAMA VENDOR</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$NAMA_editcontrol}
    </td></tr>
{END NAMA_fieldblock}  
{BEGIN ALAMAT_fieldblock}
  <tr style="padding:3px">
    <td class=editshade_b width=150 style="padding-left:15px;">ALAMAT</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$ALAMAT_editcontrol}
    </td></tr>
{END ALAMAT_fieldblock}  
{BEGIN NPWP_fieldblock}
  <tr style="padding:3px">
    <td class=editshade_b width=150 style="padding-left:15px;">NPWP</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$NPWP_editcontrol}
    </td></tr>
{END NPWP_fieldblock}  
{BEGIN TELEPON_fieldblock}
  <tr style="padding:3px">
    <td class=editshade_b width=150 style="padding-left:15px;">TELEPON</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$TELEPON_editcontrol}
    </td></tr>
{END TELEPON_fieldblock}  
{BEGIN FAX_fieldblock}
  <tr style="padding:3px">
    <td class=editshade_b width=150 style="padding-left:15px;">FAX</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$FAX_editcontrol}
    </td></tr>
{END FAX_fieldblock}  
{BEGIN EMAIL_fieldblock}
  <tr style="padding:3px">
    <td class=editshade_b width=150 style="padding-left:15px;">EMAIL</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$EMAIL_editcontrol}
    </td></tr>
{END EMAIL_fieldblock}  
{BEGIN STATUS_fieldblock}
  <tr style="padding:3px">
    <td class=editshade_b width=150 style="padding-left:15px;">STATUS</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$STATUS_editcontrol}
    </td></tr>
{END STATUS_fieldblock}  
</table>

<div class="downedit" id="buttons_block{$id}">
<div id="required_block{$id}" ><img src="images/icon_required.gif"> - Required field</div>
{BEGIN save_button}
<span class=buttonborder><input class=button type=submit value="Save" name=submit1></span>
{END save_button}
{BEGIN reset_button}
<span class=buttonborder><input class=button type=reset value="Reset"></span>
{END reset_button}
{BEGIN cancel_button}
<span class=buttonborder><input class=button type=button value="Cancel" {$cancelbutton_attrs}></span>
{END cancel_button}
{BEGIN back_button}
<span class=buttonborder><input class=button type=button value="Back to list" {$backbutton_attrs}></span>
{END back_button}
</div>

</div>
<b class="xbottom"><b class="xb4b"></b><b class="xb3b"></b><b class="xb2b"></b><b class="xb1b"></b></b>
{END flybody}
</td></tr>
</table>
{$footer}
{END body}

</body>
</html>

