<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="POKJA_Add.aspx.cs" Inherits="CPOKJA_Add" %>--><HTML><HEAD><TITLE>POKJA</TITLE>
<LINK REL="stylesheet" href="include/style.css" type="text/css"></LINK><!--[if IE]><LINK REL="stylesheet" href="include/styleIE.css" type="text/css"></LINK><![endif]-->{BEGIN style_block}<STYLE>
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
<BODY>{$header} 

{BEGIN body}<TABLE id=center_block align=center><TR><TD id=contents_block>{BEGIN flybody}<B class=xtop><B 
      class="rb1 rb1_top"></B><B class="rb2 rb2_top"></B><B 
      class="rb3 rb3_top"></B><B class="rb4 rb4_top"></B></B>
      <DIV id="header_block{$id}" class=top>POKJA, Add new record </DIV>
      <DIV id="main_block{$id}" class=xboxcontentb><DIV id="inmain_block{$id}" class=xboxcontentb>{BEGIN message_block}<DIV id="message_block{$id}"><B 
      class=xtop><B class=xb1></B><B class=xb2></B><B class=xb3></B><B 
      class=xb4></B></B>
      <DIV class=xboxcontent style="WIDTH: 100%">{$message} 
      </DIV><B class=xbottom><B class=xb4></B><B class=xb3></B><B 
      class=xb2></B><B class=xb1></B></B><BR></DIV>{END message_block}
      <TABLE id="fields_block{$id}" cellSpacing=0 cellPadding=4 border=0>{BEGIN KODEPOKJA_fieldblock}<TR><TD class=editshadeleft_b style="PADDING-LEFT: 15px" width=150>KODE 
            POKJA</TD>
          <TD class=editshaderight_lb style="PADDING-LEFT: 10px" 
            width=250>{$KODEPOKJA_editcontrol}
      &nbsp;<img src="images/icon_required.gif"> </TD></TR>{END KODEPOKJA_fieldblock}
        {BEGIN NAMA_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" width=150>NAMA</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$NAMA_editcontrol} </TD></TR>{END NAMA_fieldblock}
        {BEGIN DESKRIPSSI_fieldblock}<TR><TD class=editshade_b style="PADDING-LEFT: 15px" 
          width=150>DESKRIPSI</TD>
          <TD class=editshade_lb style="PADDING-LEFT: 10px" width=250>{$DESKRIPSSI_editcontrol} 
</TD></TR>{END DESKRIPSSI_fieldblock}</TABLE>
      <DIV id="buttons_block{$id}" class=downedit><DIV id="required_block{$id}"><IMG src="images/icon_required.gif"> - 
      Required field</DIV>{BEGIN save_button}<SPAN class=buttonborder><INPUT class=button type=submit value=Save></SPAN>{END save_button} 
      {BEGIN reset_button}<SPAN class=buttonborder><INPUT class=button type=reset value=Reset></SPAN>{END reset_button} 
      {BEGIN back_button}<SPAN class=buttonborder><INPUT class=button type=button value="Back to list" {$backbutton_attrs}></SPAN>{END back_button} 
      {BEGIN cancel_button}<SPAN class=buttonborder><INPUT class=button type=button value=Cancel {$cancelbutton_attrs}></SPAN>{END cancel_button} 
      </DIV><B class=xbottom><B class=xb4a></B><B class=xb3a></B><B 
      class=xb2a></B><B class=xb1a></B></B></DIV></DIV><B class=xbottom><B 
      class=xb4b4></B><B class=xb3b4></B><B class=xb2b4></B><B 
      class=xb1b4></B></B>{END flybody}</TD></TR></TABLE>{END body}{$footer} 
</BODY></HTML>
