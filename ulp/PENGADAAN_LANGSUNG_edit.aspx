<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PENGADAAN_LANGSUNG_Edit.aspx.cs" Inherits="CPENGADAAN_LANGSUNG_Edit" %>--><HTML><HEAD><TITLE>PENGADAAN LANGSUNG</TITLE>
<LINK REL="stylesheet" href="include/style.css" type="text/css"></LINK><!--[if IE]><LINK REL="stylesheet" href="include/styleIE.css" type="text/css"></LINK><![endif]-->
<STYLE>
#center_block {width:45%;margin:0 auto;}
#contents_block {text-align:center;width:100%}
#header_block {width:100%;white-space:nowrap;height:31px;padding-top:5px;}
#main_block {padding:10px 0;width:100%}
#inmain_block {margin:0 10px}
#fields_block {width:100%}
#buttons_block {width:100%;padding-bottom:5px}
#required_block {text-align:left;padding:5px}
#buttons_block > * {margin:0 2px}
</STYLE>
<!--[if IE]>
<STYLE>
#main_block {padding:10px 10;}
#inmain_block {margin:0 0px}
</STYLE>
<![endif]-->
<link REL="stylesheet" href="include/menuCSS.css" type="text/css">

<BODY>{$header} 

{BEGIN body}<TABLE id=center_block align=center><TR><TD id=contents_block><B class=xtop><B class="rb1 rb1_top"></B><B 
      class="rb2 rb2_top"></B><B class="rb3 rb3_top"></B><B 
      class="rb4 rb4_top"></B></B>
      <DIV id=header_block class=top>PENGADAAN LANGSUNG, Edit record [ 
      KODEPENGADAANLANGSUNG: {$show_key1} 
      ] </DIV>
      <DIV id=main_block class=xboxcontentb><DIV id=inmain_block class=xboxcontentb>{BEGIN message_block}<DIV id=message_block><B class=xtop><B 
      class=xb1></B><B class=xb2></B><B class=xb3></B><B class=xb4></B></B>
      <DIV class=xboxcontent style="WIDTH: 100%">{$message} 
      </DIV><B class=xbottom><B class=xb4></B><B class=xb3></B><B 
      class=xb2></B><B class=xb1></B></B><BR></DIV>{END message_block}
      <TABLE id=fields_block cellSpacing=0 cellPadding=4 border=0>{BEGIN NAMAKEGIATAN_fieldblock}<TR><TD class=editshadeleft_b style="PADDING-LEFT: 15px" width=150>NAMA 
            KEGIATAN</TD>
          <TD class=editshaderight_lb style="PADDING-LEFT: 10px" 
            width=250>{$NAMAKEGIATAN_editcontrol} &nbsp;<IMG 
            src="images/icon_required.gif"> </TD></TR>{END NAMAKEGIATAN_fieldblock}
        {BEGIN NAMAPAKET_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>NAMA 
          PAKET</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$NAMAPAKET_editcontrol} &nbsp;<IMG 
            src="images/icon_required.gif"> </TD></TR>{END NAMAPAKET_fieldblock}
        {BEGIN KODESKPD_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>SKPD</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$KODESKPD_editcontrol} &nbsp;<IMG 
            src="images/icon_required.gif"> </TD></TR>{END KODESKPD_fieldblock}
        {BEGIN TANGGALKONTRAK_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>TANGGAL 
            KONTRAK</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$TANGGALKONTRAK_editcontrol} &nbsp;<IMG 
            src="images/icon_required.gif"> </TD></TR>{END TANGGALKONTRAK_fieldblock}
        {BEGIN PAGU_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>PAGU</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$PAGU_editcontrol} </TD></TR>{END PAGU_fieldblock}
        {BEGIN HPS_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>HPS</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$HPS_editcontrol} </TD></TR>{END HPS_fieldblock}
        {BEGIN NILAIKONTRAK_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>NILAI 
            KONTRAK</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$NILAIKONTRAK_editcontrol} </TD></TR>{END NILAIKONTRAK_fieldblock}
        {BEGIN PEMENANG_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" 
          width=150>PEMENANG</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$PEMENANG_editcontrol}
      &nbsp;<img src="images/icon_required.gif"> </TD></TR>{END PEMENANG_fieldblock}
        {BEGIN KETERANGAN_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>JENIS 
            KEGIATAN</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$KETERANGAN_editcontrol} &nbsp;<IMG 
            src="images/icon_required.gif"> </TD></TR>{END KETERANGAN_fieldblock}
		<!-- 	
        {BEGIN PEJABATPENGADAAN_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>JENIS PENGADAAN</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$PEJABATPENGADAAN_editcontrol} 
            &nbsp;<IMG src="images/icon_required.gif"></TD></TR>{END PEJABATPENGADAAN_fieldblock}
		 -->	
        {BEGIN MENGETAHUI_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" 
          width=150>PPK</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$MENGETAHUI_editcontrol} &nbsp;<IMG 
            src="images/icon_required.gif"> </TD></TR>{END MENGETAHUI_fieldblock}</TABLE>
      <DIV id=buttons_block class=downedit><DIV id=required_block><IMG src="images/icon_required.gif"> - Required 
      field</DIV>{BEGIN save_button}<SPAN class=buttonborder><INPUT class=button type=submit value=Save></SPAN>{END save_button} 
      {BEGIN reset_button}<SPAN class=buttonborder><INPUT class=button type=reset value=Reset></SPAN>{END reset_button} 
      {BEGIN back_button}<SPAN class=buttonborder><INPUT class=button type=button value="Back to list" {$backbutton_attrs}></SPAN>{END back_button} 
      </DIV><B class=xbottom><B class=xb4a></B><B class=xb3a></B><B 
      class=xb2a></B><B class=xb1a></B></B></DIV></DIV><B class=xbottom><B 
      class=xb4b4></B><B class=xb3b4></B><B class=xb2b4></B><B 
      class=xb1b4></B></B></TD></TR></TABLE>{END body}{$footer} 
</BODY></HTML>
