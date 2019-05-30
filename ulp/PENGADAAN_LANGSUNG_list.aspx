<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PENGADAAN_LANGSUNG_List.aspx.cs" Inherits="CPENGADAAN_LANGSUNG_List" %>--><HTML><HEAD><TITLE>PENGADAAN LANGSUNG</TITLE>
<LINK REL="stylesheet" href="include/style.css" type="text/css"></LINK><!--[if IE]><LINK REL="stylesheet" href="include/styleIE.css" type="text/css"></LINK><![endif]-->{BEGIN style_block}
<STYLE>
#toplinks_block{$id} {padding:2px 5px}
#toplinks_block{$id} > * {margin:4px 6px;vertical-align:middle;}
#menu_block{$id} {clear:left;margin-top:10px;}
#menu_block{$id} div {float:left;}
#menu_block{$id} div div {margin-right:1px;float:none;}
#menu_block{$id} a {white-space:nowrap;}
.menuitem {padding:6px 18px 10px 13px;margin-bottom:1px}
.menuitem_active {padding:6px 18px 11px 13px;}
#search_records_block{$id} {padding:9px 10px 13px 10px;text-align:right}
#search_records_block{$id} > * {margin:2px 2px;vertical-align:middle}
#details_block{$id}, #pages_block{$id} {white-space:nowrap}
#recordcontrols_block{$id} {padding:13px 10px 9px 10px;text-align:right}
#recordcontrols{$id} > *,#newrecordcontrols{$id} > * {margin:2px 2px;vertical-align:middle}
#search_records_top{$id} {clear:left}
#message_block{$id} {text-align:center;}
#grid_block{$id} {margin-top:10px;}
.headerlist_right2 *,.headerlist * {vertical-align:middle}
.grid_recordheader {padding:0 5px 5px}
.grid_recordheader * {margin:0px 5px; vertical-align:middle}
#mastertable_block{$id} {margin:10px 0}
</STYLE>
{END style_block}<!--[if IE]>{BEGIN iestyle_block}
<STYLE>
#toplinks_block{$id} * {margin:2px 3px;vertical-align:middle;}
#search_records_block{$id} * {margin:1px 1px;vertical-align:middle}
#recordcontrols{$id} *, #newrecordcontrols{$id} * {margin:1x 1px;vertical-align:middle}
</STYLE>
{END iestyle_block}<![endif]-->
<link REL="stylesheet" href="include/menuCSS.css" type="text/css">

</head>
<BODY topMargin=5 {$bodyattrs}>{BEGIN body}{$header} 

{BEGIN toplinks_block}<DIV><B class=xtop><B class="rb1 rb1_top"></B><B 
class="rb2 rb2_top"></B><B class="rb3 rb3_top"></B><B 
class="rb4 rb4_top"></B></B>
<div class="top" id="toplinks_block" >
<span><font style="FONT-FAMILY: Verdana, Arial;">Logged on</font></span>
<span class=buttonborder><input type=button class=button value="Log out" onclick="window.location.href='login.aspx?a=logout';"></span>
<span class=buttonborder><input type=button class=button value="Change password" onclick="window.location.href='changepwd.aspx';return false;"></span>
</div>
<B class=xbottom><B class="rb4 rb4_top"></B><B class="rb3 rb3_top"></B><B 
class="rb2 rb2_top"></B><B class="rb1 rb1_top"></B></B></DIV>{END toplinks_block}
{BEGIN search_records_block}<DIV id="search_records_top{$id}"><B 
class="rb1 rb1_search"></B><B class="rb2 rb2_search"></B><B 
class="rb3 rb3_search"></B><B class="rb4 rb4_search"></B>
<DIV id="search_records_block{$id}" class=main_table_border_P>{BEGIN searchform}<SPAN id="searchform{$id}"><B>Search for 
</B>&nbsp;&nbsp;&nbsp; {BEGIN searchform_field}<SELECT id="ctlSearchField{$id}"> <OPTION value id="replace_3">Any field</OPTION> 
  <OPTION value="NAMAKEGIATAN" {$NAMAKEGIATAN_searchfieldoption} id="replace_4">NAMA KEGIATAN</OPTION> <OPTION value="NAMAPAKET" {$NAMAPAKET_searchfieldoption} id="replace_5">NAMA PAKET</OPTION> <OPTION value="KODESKPD" {$KODESKPD_searchfieldoption} id="replace_6">SKPD</OPTION> <OPTION value="TANGGALKONTRAK" {$TANGGALKONTRAK_searchfieldoption} id="replace_7">TANGGAL KONTRAK</OPTION> <OPTION value="PAGU" {$PAGU_searchfieldoption} id="replace_8">PAGU</OPTION> <OPTION value="HPS" {$HPS_searchfieldoption} id="replace_9">HPS</OPTION> <OPTION value="NILAIKONTRAK" {$NILAIKONTRAK_searchfieldoption} id="replace_10">NILAI KONTRAK</OPTION> <OPTION value="PEMENANG" {$PEMENANG_searchfieldoption} id="replace_11">PEMENANG</OPTION> <OPTION value="KETERANGAN" {$KETERANGAN_searchfieldoption} id="replace_12">JENIS KEGIATAN</OPTION> <OPTION value="PEJABATPENGADAAN" {$PEJABATPENGADAAN_searchfieldoption} id="replace_13">PEJABAT PENGADAAN</OPTION> <OPTION value="MENGETAHUI" {$MENGETAHUI_searchfieldoption} id="replace_14">MENGETAHUI</OPTION></SELECT>{END searchform_field} &nbsp; {BEGIN searchform_option}<SELECT id="ctlSearchOption{$id}"> <OPTION value="Contains" {$Contains_searchtypeoption} id="replace_15">Contains</OPTION> <OPTION value="Equals" {$Equals_searchtypeoption} id="replace_16">Equals</OPTION> <OPTION value="Starts with ..." {$Starts_with_____searchtypeoption} id="replace_17">Starts with ...</OPTION> <OPTION value="More than ..." {$More_than_____searchtypeoption} id="replace_18">More than ...</OPTION> <OPTION value="Less than ..." {$Less_than_____searchtypeoption} id="replace_19">Less than ...</OPTION> 
  <OPTION value="Equal or more than ..." {$Equal_or_more_than_____searchtypeoption} id="replace_20">Equal or more than ...</OPTION> 
  <OPTION value="Equal or less than ..." {$Equal_or_less_than_____searchtypeoption} id="replace_21">Equal or less than ...</OPTION> 
  <OPTION value="Empty" {$Empty_searchtypeoption} id="replace_22">Empty</OPTION></SELECT>{END searchform_option} &nbsp; {BEGIN searchform_text}<INPUT {$searchfor_attrs}>{END searchform_text} &nbsp; {BEGIN searchform_search}<SPAN class=buttonborder><INPUT class=button type=button value=Search {$searchbutton_attrs}></SPAN>{END searchform_search} 
&nbsp; <!-- {BEGIN searchform_showall}<SPAN class=buttonborder><INPUT class=button type=button value="Show all" {$showallbutton_attrs}></SPAN>{END searchform_showall} --> 
</SPAN>{END searchform}&nbsp;&nbsp;&nbsp; {BEGIN details_block}<SPAN id="details_block{$id}">Details found: {$records_found}&nbsp;</SPAN>{END details_block} 
{BEGIN pages_block}<SPAN id="pages_block{$id}">Page {$page} 
of {$maxpages}</SPAN>{END pages_block} 
&nbsp;&nbsp;&nbsp; {BEGIN recordspp_block}<SPAN id="recordspp_block{$id}">Records Per Page: <SELECT {$recordspp_attrs}> 
  <OPTION value="10" {$rpp10_selected} id="replace_26">10</OPTION> <OPTION value="20" {$rpp20_selected} id="replace_27">20</OPTION> <OPTION value="30" {$rpp30_selected} id="replace_28">30</OPTION> <OPTION value="50" {$rpp50_selected} id="replace_29">50</OPTION> <OPTION value="100" {$rpp100_selected} id="replace_30">100</OPTION> <OPTION value="500" {$rpp500_selected} id="replace_31">500</OPTION></SELECT> </SPAN>{END recordspp_block}</DIV></DIV>{END search_records_block}
{BEGIN recordcontrols_block}<DIV>
<DIV id="recordcontrols_block{$id}" class=body3>{BEGIN newrecord_controls}<SPAN id="newrecord_controls{$id}">{BEGIN add_link}<SPAN class=buttonborder><INPUT class=button type=button value="Add new" {$addlink_attrs}></SPAN> 
{END add_link}</SPAN>{END newrecord_controls}{BEGIN record_controls}<SPAN id="record_controls{$id}">{BEGIN delete_link}<SPAN class=buttonborder><INPUT class=button type=button value="Delete selected" {$deletelink_attrs}></SPAN>{END delete_link} 
{BEGIN exportselected_link}<SPAN class=buttonborder><INPUT class=button type=button value="Export selected" {$exportselectedlink_attrs}></SPAN>{END exportselected_link} 
{BEGIN printselected_link}<SPAN class=buttonborder><INPUT class=button type=button value="Print selected" {$printselectedlink_attrs}></SPAN>{END printselected_link} 
</SPAN>{END record_controls}</DIV><B class=xbottom><B class="rb4 rb4_controls"></B><B 
class="rb3 rb3_controls"></B><B class="rb2 rb2_controls"></B><B 
class="rb1 rb1_controls"></B></B></DIV>{END recordcontrols_block}
<DIV id="usermessage{$id}" class=message></DIV>
{BEGIN grid_block}<DIV id="grid_block{$id}">
<TABLE class=data cellSpacing=0 cellPadding=3 width="100%" border=0 
name="maintable">
  <TBODY>
  {BEGIN grid_header}<TR class=blackshade vAlign=top>{BEGIN record_header}
    <TD class=headerlist_left_gif_P>&nbsp;</TD>
    {BEGIN edit_column}<TD class=headerlist width=50 align=center><IMG src="include/img/icon_edit.gif"></IMG></TD>{END edit_column}
    {BEGIN checkbox_column}<TD class=headerlist width=50 align=center><INPUT type=checkbox {$checkboxheader_attrs}> 
    </TD>{END checkbox_column}
    {BEGIN NAMAKEGIATAN_fieldheadercolumn}<TD class=headerlist>{BEGIN NAMAKEGIATAN_fieldheader}<A class=tablelinks 
      {$NAMAKEGIATAN_orderlinkattrs}>NAMA KEGIATAN</A> {END NAMAKEGIATAN_fieldheader}</TD>{END NAMAKEGIATAN_fieldheadercolumn}
    {BEGIN NAMAPAKET_fieldheadercolumn}<TD class=headerlist>{BEGIN NAMAPAKET_fieldheader}<A class=tablelinks 
      {$NAMAPAKET_orderlinkattrs}>NAMA PAKET</A> {END NAMAPAKET_fieldheader}</TD>{END NAMAPAKET_fieldheadercolumn}
    {BEGIN KODESKPD_fieldheadercolumn}<TD class=headerlist>{BEGIN KODESKPD_fieldheader}<A class=tablelinks 
      {$KODESKPD_orderlinkattrs}>SKPD</A> {END KODESKPD_fieldheader}</TD>{END KODESKPD_fieldheadercolumn}
    {BEGIN TANGGALKONTRAK_fieldheadercolumn}<TD class=headerlist>{BEGIN TANGGALKONTRAK_fieldheader}<A class=tablelinks 
      {$TANGGALKONTRAK_orderlinkattrs}>TANGGAL KONTRAK</A> {END TANGGALKONTRAK_fieldheader}</TD>{END TANGGALKONTRAK_fieldheadercolumn}
    {BEGIN PAGU_fieldheadercolumn}<TD class=headerlist>{BEGIN PAGU_fieldheader}<A class=tablelinks 
      {$PAGU_orderlinkattrs}>PAGU</A> {END PAGU_fieldheader}</TD>{END PAGU_fieldheadercolumn}
    {BEGIN HPS_fieldheadercolumn}<TD class=headerlist>{BEGIN HPS_fieldheader}<A class=tablelinks 
      {$HPS_orderlinkattrs}>HPS</A> {END HPS_fieldheader}</TD>{END HPS_fieldheadercolumn}
    {BEGIN NILAIKONTRAK_fieldheadercolumn}<TD class=headerlist>{BEGIN NILAIKONTRAK_fieldheader}<A class=tablelinks 
      {$NILAIKONTRAK_orderlinkattrs}>NILAI KONTRAK</A> {END NILAIKONTRAK_fieldheader}</TD>{END NILAIKONTRAK_fieldheadercolumn}
    {BEGIN PEMENANG_fieldheadercolumn}<TD class=headerlist>{BEGIN PEMENANG_fieldheader}<A class=tablelinks 
      {$PEMENANG_orderlinkattrs}>PEMENANG</A> {END PEMENANG_fieldheader}</TD>{END PEMENANG_fieldheadercolumn}
    {BEGIN KETERANGAN_fieldheadercolumn}<TD class=headerlist>{BEGIN KETERANGAN_fieldheader}<A class=tablelinks 
      {$KETERANGAN_orderlinkattrs}>JENIS KEGIATAN</A> {END KETERANGAN_fieldheader}</TD>{END KETERANGAN_fieldheadercolumn}
    {BEGIN PEJABATPENGADAAN_fieldheadercolumn}<TD class=headerlist>{BEGIN PEJABATPENGADAAN_fieldheader}<A class=tablelinks 
      {$PEJABATPENGADAAN_orderlinkattrs}>PEJABAT PENGADAAN</A> {END PEJABATPENGADAAN_fieldheader}</TD>{END PEJABATPENGADAAN_fieldheadercolumn}
    {BEGIN MENGETAHUI_fieldheadercolumn}<TD class=headerlist_right2>{BEGIN MENGETAHUI_fieldheader}<A class=tablelinks 
      {$MENGETAHUI_orderlinkattrs}>PPK</A> {END MENGETAHUI_fieldheader}</TD>{END MENGETAHUI_fieldheadercolumn}
    <TD class=headerlist_right_gif_P>&nbsp;</TD>
    {BEGIN endrecordheader_block}<TD class=body2></TD>{END endrecordheader_block}{END record_header}</TR>{END grid_header}
  {BEGIN grid_row}<TR vAlign=top {$rowattrs} {$rowstyle}>{BEGIN grid_record}
    <TD>&nbsp;</TD>
    {BEGIN edit_column}<TD class=borderbody vAlign=middle align=center>{BEGIN edit_link}<A class=tablelinks {$editlink_attrs}>Edit</A> {END edit_link}</TD>{END edit_column}
    {BEGIN checkbox_column}<TD class=borderbody vAlign=middle align=center>{BEGIN checkbox}<INPUT type=checkbox {$checkbox_attrs}> {END checkbox}</TD>{END checkbox_column}
    {BEGIN NAMAKEGIATAN_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$NAMAKEGIATAN_style}>{$NAMAKEGIATAN_value} </TD>{END NAMAKEGIATAN_fieldcolumn}
    {BEGIN NAMAPAKET_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$NAMAPAKET_style}>{$NAMAPAKET_value} </TD>{END NAMAPAKET_fieldcolumn}
    {BEGIN KODESKPD_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$KODESKPD_style}>{$KODESKPD_value} </TD>{END KODESKPD_fieldcolumn}
    {BEGIN TANGGALKONTRAK_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$TANGGALKONTRAK_style}>{$TANGGALKONTRAK_value} </TD>{END TANGGALKONTRAK_fieldcolumn}
    {BEGIN PAGU_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$PAGU_style}>{$PAGU_value} </TD>{END PAGU_fieldcolumn}
    {BEGIN HPS_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$HPS_style}>{$HPS_value} </TD>{END HPS_fieldcolumn}
    {BEGIN NILAIKONTRAK_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$NILAIKONTRAK_style}>{$NILAIKONTRAK_value} </TD>{END NILAIKONTRAK_fieldcolumn}
    {BEGIN PEMENANG_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$PEMENANG_style}>{$PEMENANG_value} </TD>{END PEMENANG_fieldcolumn}
    {BEGIN KETERANGAN_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$KETERANGAN_style}>{$KETERANGAN_value} </TD>{END KETERANGAN_fieldcolumn}
    {BEGIN PEJABATPENGADAAN_fieldcolumn}<TD class=borderbody vAlign=middle align=center {$PEJABATPENGADAAN_style}>{$PEJABATPENGADAAN_value} </TD>{END PEJABATPENGADAAN_fieldcolumn}
    {BEGIN MENGETAHUI_fieldcolumn}<TD vAlign=middle align=center {$MENGETAHUI_style}>{$MENGETAHUI_value} </TD>{END MENGETAHUI_fieldcolumn}
    <TD>&nbsp;</TD>
    {BEGIN endrecord_block}<TD class=body2 width=20 {$endrecordblock_attrs}>&nbsp;</TD>{END endrecord_block}{END grid_record}</TR>{END grid_row}
  {BEGIN grid_footer}<TR class=blackshade>{BEGIN record_footer}
    <TD class=headerlistdown_left2_P height=15></TD>
    {BEGIN edit_column}<TD class=blackshade>&nbsp;</TD>{END edit_column}
    {BEGIN checkbox_column}<TD class=blackshade>&nbsp;</TD>{END checkbox_column}
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=blackshade>&nbsp;</TD>
    <TD class=headerlistdown_right2_P height=15>&nbsp;</TD>
    {BEGIN endrecordfooter_block}<TD class=body2 width=20>&nbsp;</TD>{END endrecordfooter_block}{END record_footer}</TR>{END grid_footer}</TBODY></TABLE></DIV>{END grid_block}
{BEGIN pagination_block}<DIV><B class=xtop><B class=xb1></B><B 
class=xb2></B><B class=xb3></B><B class=xb4></B></B>
<DIV class=xboxcontent>{$pagination}</DIV><B 
class=xbottom><B class=xb4></B><B class=xb3></B><B class=xb2></B><B 
class=xb1></B></B></DIV>{END pagination_block}
{BEGIN message_block}<DIV><B class=xtop><B class=xb1></B><B class=xb2></B><B 
class=xb3></B><B class=xb4></B></B>
<DIV id=message_block class=xboxcontent>{$message}</DIV><B 
class=xbottom><B class=xb4></B><B class=xb3></B><B class=xb2></B><B 
class=xb1></B></B></DIV>{END message_block}
<DIV></DIV>{$footer} 
{END body}</BODY></HTML>
