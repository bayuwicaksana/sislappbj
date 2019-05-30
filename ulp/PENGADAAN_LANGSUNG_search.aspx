<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PENGADAAN_LANGSUNG_Search.aspx.cs" Inherits="CPENGADAAN_LANGSUNG_Search" %>-->
<html>
<head>
<title>PENGADAAN LANGSUNG: Advanced search page</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
<style>
#center_block {margin:0 auto;}
#contents_block {text-align:center;width:100%}
#header_block {width:100%;white-space:nowrap;height:31px;padding-top:5px;}
#main_block {padding:10px 0;width:100%}
#inmain_block {margin:0 10px}
#fields_block {width:100%}
#buttons_block {width:100%;padding-bottom:5px}
#required_block {text-align:left;padding:5px}
#buttons_block > * {margin:0 2px}
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
<b class="xtop"><b class="rb1 rb1_top"></b><b class="rb2 rb2_top"></b><b class="rb3 rb3_top"></b><b class="rb4 rb4_top"></b></b>
<div id="header_block" class="top">
PENGADAAN LANGSUNG - Advanced search</div>
<div id="main_block" class="xboxcontentb" >
<div id="inmain_block" class="xboxcontentb" >
	
{BEGIN conditions_block}
<DIV id=conditions_block>
<b class="xtop"><b class="xb1"></b><b class="xb2"></b><b class="xb3"></b><b class="xb4"></b></b>
<div class="xboxcontent" style="width:100%">
<span class=fieldname>Search for:</span>
<input type="radio" name="type" {$all_checkbox}>All conditions
&nbsp;&nbsp;&nbsp;
<input type="radio" name="type" {$any_checkbox}>Any condition
</div>
<b class="xbottom"><b class="xb4"></b><b class="xb3"></b><b class="xb2"></b><b class="xb1"></b></b>
<br>
</DIV>
{END conditions_block}
<table cellpadding=4 cellspacing=0 border=0 id="fields_block">
<tr valign=center>
<td align=center valign=middle class="searchlist_left">&nbsp;</td>
<td width=30 align=center valign=middle class=searchlist>NOT</td>
<td align=center valign=middle class="searchlist">&nbsp; </td>
<td align=center valign=middle class="searchlist">&nbsp; </td>
<td align=center valign=middle class="searchlist_right">&nbsp; </td></tr>
{BEGIN NAMAKEGIATAN_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">NAMA KEGIATAN</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$NAMAKEGIATAN_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_NAMAKEGIATAN}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$NAMAKEGIATAN_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_NAMAKEGIATAN">
	{$NAMAKEGIATAN_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END NAMAKEGIATAN_fieldblock}	
{BEGIN NAMAPAKET_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">NAMA PAKET</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$NAMAPAKET_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_NAMAPAKET}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$NAMAPAKET_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_NAMAPAKET">
	{$NAMAPAKET_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END NAMAPAKET_fieldblock}	
{BEGIN KODESKPD_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">SKPD</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$KODESKPD_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_KODESKPD}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$KODESKPD_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_KODESKPD">
	{$KODESKPD_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END KODESKPD_fieldblock}	
{BEGIN TANGGALKONTRAK_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">TANGGAL KONTRAK</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$TANGGALKONTRAK_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_TANGGALKONTRAK}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$TANGGALKONTRAK_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_TANGGALKONTRAK">
	{$TANGGALKONTRAK_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END TANGGALKONTRAK_fieldblock}	
{BEGIN PAGU_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">PAGU</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$PAGU_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_PAGU}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$PAGU_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_PAGU">
	{$PAGU_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END PAGU_fieldblock}	
{BEGIN HPS_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">HPS</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$HPS_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_HPS}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$HPS_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_HPS">
	{$HPS_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END HPS_fieldblock}	
{BEGIN NILAIKONTRAK_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">NILAI KONTRAK</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$NILAIKONTRAK_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_NILAIKONTRAK}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$NILAIKONTRAK_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_NILAIKONTRAK">
	{$NILAIKONTRAK_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END NILAIKONTRAK_fieldblock}	
{BEGIN PEMENANG_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">PEMENANG</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$PEMENANG_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_PEMENANG}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$PEMENANG_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_PEMENANG">
	{$PEMENANG_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END PEMENANG_fieldblock}	
{BEGIN KETERANGAN_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">JENIS KEGIATAN</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$KETERANGAN_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_KETERANGAN}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$KETERANGAN_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_KETERANGAN">
	{$KETERANGAN_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END KETERANGAN_fieldblock}	
{BEGIN PEJABATPENGADAAN_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">PEJABAT PENGADAAN</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$PEJABATPENGADAAN_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_PEJABATPENGADAAN}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$PEJABATPENGADAAN_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_PEJABATPENGADAAN">
	{$PEJABATPENGADAAN_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END PEJABATPENGADAAN_fieldblock}	
{BEGIN MENGETAHUI_fieldblock}	
<tr>
	<td class=editshade_b style="padding-left:15px;">MENGETAHUI</td>
	<td align=center class=editshade_lb style="padding-left:10px;"><input type=checkbox {$MENGETAHUI_notbox}></td>
	
	<td class=editshade_lb style="padding-left:10px;">{$searchtype_MENGETAHUI}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;">{$MENGETAHUI_editcontrol}</td>
	<td width=270 class=editshade_lb style="padding-left:10px;"><span id="second_MENGETAHUI">
	{$MENGETAHUI_editcontrol1}
	</span>&nbsp;</td>
</tr>
{END MENGETAHUI_fieldblock}	
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
<b class="xbottom"><b class="xb4a"></b><b class="xb3a"></b><b class="xb2a"></b><b class="xb1a"></b></b>
</div>
</div>
<b class="xbottom"><b class="xb4b4"></b><b class="xb3b4"></b><b class="xb2b4"></b><b class="xb1b4"></b></b>
</td></tr></table>
{END contents_block}
{END body}
{$footer}

</body>
</html>
	

