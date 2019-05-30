<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PBJ_Edit.aspx.cs" Inherits="CPBJ_Edit" %>-->
<html>
<head><title>PBJ</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
<style>
#center_block {width:45%;margin:0 auto;}
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

<link REL="stylesheet" href="include/menuCSS.css" type="text/css">

</head>
<body>
{$header}
{BEGIN body}


<table align=center id="center_block"><tr><td id="contents_block">
<b class="xtop"><b class="rb1 rb1_top"></b><b class="rb2 rb2_top"></b><b class="rb3 rb3_top"></b><b class="rb4 rb4_top"></b></b>
<div id="header_block" class="top">
PBJ, Edit record [
KODE PBJ: {$show_key1}
]
</div>
<div id="main_block" class="xboxcontentb" >
<div id="inmain_block" class="xboxcontentb" >
{BEGIN message_block}
<DIV id=message_block>
<b class="xtop"><b class="xb1"></b><b class="xb2"></b><b class="xb3"></b><b class="xb4"></b></b>
<div class="xboxcontent" style="width:100%">
{$message}
</div>
<b class="xbottom"><b class="xb4"></b><b class="xb3"></b><b class="xb2"></b><b class="xb1"></b></b>
<br>
</div>
{END message_block}
<table cellpadding=4 cellspacing=0 border=0 id="fields_block">
<!--
{BEGIN KODEPBJ_fieldblock}
<tr>
    <td class=editshadeleft_b width=150 style="padding-left:15px;">KODE PBJ</td>
    <td width=250 class=editshaderight_lb style="padding-left:10px;">
    {$KODEPBJ_editcontrol}
      &nbsp;<img src="images/icon_required.gif">
  </td></tr>
{END KODEPBJ_fieldblock}
-->
{BEGIN NAMAKEGIATAN_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">NAMA KEGIATAN</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$NAMAKEGIATAN_editcontrol}
    </td></tr>
{END NAMAKEGIATAN_fieldblock}
{BEGIN NAMAPAKET_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">NAMA PAKET</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$NAMAPAKET_editcontrol}
    </td></tr>
{END NAMAPAKET_fieldblock}
{BEGIN KODESKPD_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">SKPD</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$KODESKPD_editcontrol}
      &nbsp;<img src="images/icon_required.gif">
  </td></tr>
{END KODESKPD_fieldblock}
{BEGIN PPK_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PPK</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$PPK_editcontrol}
      &nbsp;<img src="images/icon_required.gif">
  </td></tr>
{END PPK_fieldblock}
{BEGIN PPTK_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PPTK</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$PPTK_editcontrol}
      &nbsp;<img src="images/icon_required.gif">
  </td></tr>
{END PPTK_fieldblock}
{BEGIN KODEJENISKEGIATAN_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">JENIS KEGIATAN</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$KODEJENISKEGIATAN_editcontrol}
      &nbsp;<img src="images/icon_required.gif">
  </td></tr>
{END KODEJENISKEGIATAN_fieldblock}
{BEGIN PROSESPENGADAAN_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PROSES PENGADAAN</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$PROSESPENGADAAN_editcontrol}
    </td></tr>
{END PROSESPENGADAAN_fieldblock}
{BEGIN TANGGALPENGAJUAN_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">TANGGAL PENGAJUAN</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$TANGGALPENGAJUAN_editcontrol}
    </td></tr>
{END TANGGALPENGAJUAN_fieldblock}
{BEGIN PEMBAWABERKAS1_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PEMBAWA BERKAS 1</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$PEMBAWABERKAS1_editcontrol}
    </td></tr>
{END PEMBAWABERKAS1_fieldblock}
{BEGIN PENERIMABERKAS1_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PENERIMA BERKAS 1</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$PENERIMABERKAS1_editcontrol}
    </td></tr>
{END PENERIMABERKAS1_fieldblock}
{BEGIN PEMBAWABERKAS2_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PEMBAWA BERKAS 2</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$PEMBAWABERKAS2_editcontrol}
    </td></tr>
{END PEMBAWABERKAS2_fieldblock}
{BEGIN PENERIMABERKAS2_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PENERIMA BERKAS 2</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$PENERIMABERKAS2_editcontrol}
    </td></tr>
{END PENERIMABERKAS2_fieldblock}
{BEGIN LENGKAP_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">LENGKAP</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$LENGKAP_editcontrol}
    </td></tr>
{END LENGKAP_fieldblock}
{BEGIN DIKEMBALIKAN_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">DIKEMBALIKAN</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$DIKEMBALIKAN_editcontrol}
    </td></tr>
{END DIKEMBALIKAN_fieldblock}
{BEGIN TANGGALKEMBALI_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">TANGGAL KEMBALI</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$TANGGALKEMBALI_editcontrol}
    </td></tr>
{END TANGGALKEMBALI_fieldblock}
{BEGIN KODESTATUSPBJ_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">STATUS</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$KODESTATUSPBJ_editcontrol}
      &nbsp;<img src="images/icon_required.gif">
  </td></tr>
{END KODESTATUSPBJ_fieldblock}
{BEGIN CATATAN_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">TAMBAHAN KELENGKAPAN</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    {$CATATAN_editcontrol}
    </td></tr>
{END CATATAN_fieldblock}
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">PAGU</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    <input type="text" name="value_PAGU"  maxlength=500 value="">
    </td></tr>
<tr>
    <td class=editshade_b width=150 style="padding-left:15px;">HPS</td>
    <td width=250 class=editshade_lb style="padding-left:10px;">
    <input type="text" name="value_HPS"  maxlength=500 value="">
    </td></tr>
</table>
<div class="downedit" id="buttons_block">
 <div id="required_block" ><img src="images/icon_required.gif"> - Required field</div>
{BEGIN save_button}
 <span class=buttonborder><input class=button type=submit value="Save"></span>
{END save_button} 
{BEGIN reset_button}
 <span class=buttonborder><input class=button type=reset value="Reset"></span>
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

{END body}
{$footer}
</body>
</html>
