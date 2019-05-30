<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="TIPEAKTOR_View.aspx.cs" Inherits="CTIPEAKTOR_View" %>-->
<html>
<head><title>TIPE AKTOR</title>
{BEGIN stylefiles_block}
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
{END stylefiles_block}
{BEGIN style_block}
<style>
#center_block{$id} {width:45%;margin:0 auto;}
#contents_block{$id} {text-align:center;}
#header_block{$id} {white-space:nowrap;height:31px;padding-top:5px;text-align:center;}
#main_block{$id} {padding:10px 0;text-align:center;}
#inmain_block{$id} {margin:0 10px}
#fields_block{$id} {width:100%}
#buttons_block{$id} {padding:7px 5px 2px;white-space:nowrap;}
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
</head>
<body>
{$header}
{BEGIN body}
<div>


<table align=center id="center_block"><tr><td id="contents_block">
<b class="xtop"><b class="rb1 rb1_top"></b><b class="rb2 rb2_top"></b><b class="rb3 rb3_top"></b><b class="rb4 rb4_top"></b></b>
<div id="header_block{$id}" class="top">
TIPE AKTOR, View record [
KODE TIPE: {$show_key1}
]
</div>
<div id="main_block{$id}" class="xboxcontentb" >
<div id="inmain_block{$id}" class="xboxcontentb" >
<table cellpadding=4 cellspacing=0 border=0 id="fields_block{$id}">

{BEGIN KODETIPE_fieldblock}
<tr>
    <td class=editshadeleft_b width=150 style="padding-left:15px;">KODE TIPE</td>
    <td width=250 class=editshaderight_lb style="padding-left:10px;">
    {$KODETIPE_value}&nbsp;
  </td></tr>
{END KODETIPE_fieldblock}
{BEGIN DESKRIPSI_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">DESKRIPSI</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$DESKRIPSI_value}&nbsp;
  </td></tr>
{END DESKRIPSI_fieldblock}
</table>
<div class="downedit" id="buttons_block{$id}">
{BEGIN back_button}
  <span class=buttonborder><input class=button type=reset value="Back to list" {$backbutton_attrs}></span>
{END back_button}
&nbsp;</div>
<b class="xbottom"><b class="xb4a"></b><b class="xb3a"></b><b class="xb2a"></b><b class="xb1a"></b></b>
</div>
</div>
<b class="xbottom"><b class="xb4b4"></b><b class="xb3b4"></b><b class="xb2b4"></b><b class="xb1b4"></b></b>
</td></tr></table>
</div>
{END body}
{$footer}

</body>
</html>


