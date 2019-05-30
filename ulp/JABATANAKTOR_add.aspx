<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="JABATANAKTOR_Add.aspx.cs" Inherits="CJABATANAKTOR_Add" %>-->
<html>
<head><title>JABATAN AKTOR</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
{BEGIN style_block}
<style>
#center_block{$id} {width:45%;margin:0 auto;}
#contents_block{$id} {text-align:center;}
#header_block{$id} {white-space:nowrap;height:31px;padding-top:5px;text-align:center;}
#main_block{$id} {padding:10px 0;text-align:center;}
#inmain_block{$id} {margin:0 10px}
#fields_block{$id} {width:100%}
#buttons_block{$id} {padding-bottom:5px;white-space:nowrap;}
#required_block{$id} {text-align:left;padding:5px}
#buttons_block{$id} > * {margin:0 2px}
</style>
<!--[if IE]>
<style>
#main_block{$id} {padding:10px 10;}
#inmain_block{$id} {margin:0 0px;width:100%}
</style>
<![endif]-->
{END style_block}

<link REL="stylesheet" href="include/menuCSS.css" type="text/css">

</head>
<body>
{$header}
{BEGIN body}

<table align=center id="center_block"><tr><td id="contents_block">
{BEGIN flybody}
<b class="xtop"><b class="rb1 rb1_top"></b><b class="rb2 rb2_top"></b><b class="rb3 rb3_top"></b><b class="rb4 rb4_top"></b></b>
<div id="header_block{$id}" class="top">
JABATAN AKTOR, Add new record
</div>
<div id="main_block{$id}" class="xboxcontentb" >
<div id="inmain_block{$id}" class="xboxcontentb" >
{BEGIN message_block}
<div id="message_block{$id}">
<b class="xtop"><b class="xb1"></b><b class="xb2"></b><b class="xb3"></b><b class="xb4"></b></b>
<div class="xboxcontent" style="width:100%">
{$message}
</div>
<b class="xbottom"><b class="xb4"></b><b class="xb3"></b><b class="xb2"></b><b class="xb1"></b></b>
<br>
</div>
{END message_block}
<table cellpadding=4 cellspacing=0 border=0 id="fields_block{$id}">

{BEGIN KODEJABATAN_fieldblock}
<tr>
    <td class=editshadeleft_b width=150 style="padding-left:15px;">KODE JABATAN</td>
    <td width=250 class=editshaderight_lb style="padding-left:10px;">
    {$KODEJABATAN_editcontrol}
      &nbsp;<img src="images/icon_required.gif">
  </td></tr>
{END KODEJABATAN_fieldblock}
{BEGIN DESKRIPSI_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">DESKRIPSI</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$DESKRIPSI_editcontrol}
    </td></tr>
{END DESKRIPSI_fieldblock}
</table>
<div class="downedit" id="buttons_block{$id}">
 <div id="required_block{$id}" ><img src="images/icon_required.gif"> - Required field</div>
{BEGIN save_button}
 <span class=buttonborder><input class=button type=submit value="Save"></span>
{END save_button} 
{BEGIN reset_button}
 <span class=buttonborder><input class=button type=reset value="Reset"></span>
{END reset_button}
{BEGIN back_button}
 <span class=buttonborder><input class=button type=button value="Back to list" {$backbutton_attrs}></span>
{END back_button}
{BEGIN cancel_button}
 <span class=buttonborder><input class=button type=button value="Cancel" {$cancelbutton_attrs}></span>
{END cancel_button}
</div>
<b class="xbottom"><b class="xb4a"></b><b class="xb3a"></b><b class="xb2a"></b><b class="xb1a"></b></b>
</div>
</div>
<b class="xbottom"><b class="xb4b4"></b><b class="xb3b4"></b><b class="xb2b4"></b><b class="xb1b4"></b></b>
{END flybody}
</td></tr></table>

{END body}
{$footer}
</body>
</html>


