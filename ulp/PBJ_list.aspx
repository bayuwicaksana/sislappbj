<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PBJ_List.aspx.cs" Inherits="CPBJ_List" %>-->
<html>
<head>
<title>PBJ</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
{BEGIN style_block}
<style>
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
</style>
{END style_block}
<!--[if IE]>
{BEGIN iestyle_block}
<style>
#toplinks_block{$id} * {margin:2px 3px;vertical-align:middle;}
#search_records_block{$id} * {margin:1px 1px;vertical-align:middle}
#recordcontrols{$id} *, #newrecordcontrols{$id} * {margin:1x 1px;vertical-align:middle}
</style>
{END iestyle_block}
<![endif]-->

<link REL="stylesheet" href="include/menuCSS.css" type="text/css">


</head>
<body topmargin=5 {$bodyattrs}>
{BEGIN body}
{$header}

{BEGIN toplinks_block}
<div>
<b class="xtop"><b class="rb1 rb1_top"></b><b class="rb2 rb2_top"></b><b class="rb3 rb3_top"></b><b class="rb4 rb4_top"></b></b>
<div class="top" id="toplinks_block{$id}" >
<span><font style="FONT-FAMILY: Verdana, Arial;">Logged on as</font>&nbsp;<b>{$username}</b>&nbsp;</span>
<span class=buttonborder><input type=button class=button value="Log out" {$logoutlink_attrs}></span>


{BEGIN changepwd_link}
<span class=buttonborder><input type=button class=button value="Change password" {$changepwdlink_attrs}></span>
{END changepwd_link}





</div>
<b class="xbottom"><b class="rb4 rb4_top"></b><b class="rb3 rb3_top"></b><b class="rb2 rb2_top"></b><b class="rb1 rb1_top"></b></b>
</div>
{END toplinks_block}



{BEGIN search_records_block} 
<div id="search_records_top{$id}">
<b class="rb1 rb1_search" ></b><b class="rb2 rb2_search"></b><b class="rb3 rb3_search"></b><b class="rb4 rb4_search"></b>
<div id="search_records_block{$id}" class="main_table_border_P">
{BEGIN searchform}
<span id="searchform{$id}">
<b>Search for </b> &nbsp;&nbsp;&nbsp;
{BEGIN searchform_field}
<select id="ctlSearchField{$id}">
<option value="">Any field</option>
<option value="KODEPBJ" {$KODEPBJ_searchfieldoption}>KODE PBJ</option>
<option value="NAMAKEGIATAN" {$NAMAKEGIATAN_searchfieldoption}>NAMA KEGIATAN</option>
<option value="NAMAPAKET" {$NAMAPAKET_searchfieldoption}>NAMA PAKET</option>
<option value="KODESKPD" {$KODESKPD_searchfieldoption}>SKPD</option>
<option value="PPK" {$PPK_searchfieldoption}>PPK</option>
<option value="PPTK" {$PPTK_searchfieldoption}>PPTK</option>
<option value="KODEJENISKEGIATAN" {$KODEJENISKEGIATAN_searchfieldoption}>JENIS KEGIATAN</option>
<option value="TANGGALPENGAJUAN" {$TANGGALPENGAJUAN_searchfieldoption}>TANGGAL PENGAJUAN</option>
<option value="TANGGALKEMBALI" {$TANGGALKEMBALI_searchfieldoption}>TANGGAL KEMBALI</option>
<option value="LENGKAP" {$LENGKAP_searchfieldoption}>LENGKAP</option>
<option value="DIKEMBALIKAN" {$DIKEMBALIKAN_searchfieldoption}>DIKEMBALIKAN</option>
<option value="KODESTATUSPBJ" {$KODESTATUSPBJ_searchfieldoption}>STATUS</option>
</select>
{END searchform_field}
&nbsp;
{BEGIN searchform_option}
<select id="ctlSearchOption{$id}">
<option value="Contains" {$Contains_searchtypeoption}>Contains</option>
<option value="Equals" {$Equals_searchtypeoption}>Equals</option>
<option value="Starts with ..." {$Starts_with_____searchtypeoption}>Starts with ...</option>
<option value="More than ..." {$More_than_____searchtypeoption}>More than ...</option>
<option value="Less than ..." {$Less_than_____searchtypeoption}>Less than ...</option>
<option value="Equal or more than ..." {$Equal_or_more_than_____searchtypeoption}>Equal or more than ...</option>
<option value="Equal or less than ..." {$Equal_or_less_than_____searchtypeoption}>Equal or less than ...</option>
<option value="Empty" {$Empty_searchtypeoption}>Empty</option>
</select>
{END searchform_option}
&nbsp;
{BEGIN searchform_text}
<input type=text size=20 {$searchfor_attrs}>
{END searchform_text}
&nbsp;
{BEGIN searchform_search}
<span class=buttonborder><input type=button class="button" value="Search" {$searchbutton_attrs}></span>
{END searchform_search}
&nbsp;		
{BEGIN searchform_showall}
<span class=buttonborder><input type=button class="button" value="Show all" {$showallbutton_attrs}></span>
{END searchform_showall}
</span>
{END searchform}

&nbsp;&nbsp;&nbsp;
{BEGIN details_block}
<span id="details_block{$id}">Details found: {$records_found}&nbsp;</span>
{END details_block}
{BEGIN pages_block}
<span id="pages_block{$id}">Page {$page} of {$maxpages}</span>
{END pages_block}

&nbsp;&nbsp;&nbsp;
{BEGIN recordspp_block}
<span id="recordspp_block{$id}">
Records Per Page:
<select {$recordspp_attrs}>
<option value="10" {$rpp10_selected}>10</option>
<option value="20" {$rpp20_selected}>20</option>
<option value="30" {$rpp30_selected}>30</option>
<option value="50" {$rpp50_selected}>50</option>
<option value="100" {$rpp100_selected}>100</option>
<option value="500" {$rpp500_selected}>500</option>
</select>
</span>
{END recordspp_block}
</div>
</div>
{END search_records_block} 

{BEGIN recordcontrols_block}
<div>
<div id="recordcontrols_block{$id}" class="body3">
{BEGIN newrecord_controls}
<span id="newrecord_controls{$id}">
{BEGIN add_link}
<span class=buttonborder><input type=button class="button" value="Add new" {$addlink_attrs}></span>
{END add_link}

</span>
{END newrecord_controls}
{BEGIN record_controls}
<span id="record_controls{$id}">


{BEGIN delete_link}
<span class=buttonborder><input type=button class="button" value="Delete selected" {$deletelink_attrs}></span>
{END delete_link}


</span>
{END record_controls}
</div>
<b class="xbottom"><b class="rb4 rb4_controls"></b><b class="rb3 rb3_controls"></b><b class="rb2 rb2_controls"></b><b class="rb1 rb1_controls"></b></b>
</div>
{END recordcontrols_block}

<div id="usermessage{$id}" class="message"></div>
{BEGIN grid_block}
<div id="grid_block{$id}">
<table name="maintable" class="data" border="0" cellpadding=3 cellspacing=0 width="100%">
{BEGIN grid_header}
<tr valign="top" class=blackshade>
{BEGIN record_header}
<td class="headerlist_left_gif_P">&nbsp;</td>

{BEGIN edit_column}
<td width=50 align="center" class="headerlist"><img src="include/img/icon_edit.gif"></td>
{END edit_column}



{BEGIN view_column}
<td width=50 align="center" class="headerlist"><img src="include/img/icon_view.gif"></td>
{END view_column}

{BEGIN checkbox_column}
<td width=50 align="center" class="headerlist">
<input type=checkbox {$checkboxheader_attrs}>
</td>
{END checkbox_column}
{BEGIN KELENGKAPANPBJ_dtable_column}
<td width=50 class="headerlist">&nbsp;</td>
{END KELENGKAPANPBJ_dtable_column}
<!--
{BEGIN ASSIGNMENT_dtable_column}
<td width=50 class="headerlist">&nbsp;</td>
{END ASSIGNMENT_dtable_column}
-->
{BEGIN KODEPBJ_fieldheadercolumn}
<td class="headerlist">
{BEGIN KODEPBJ_fieldheader}
<a class="tablelinks" {$KODEPBJ_orderlinkattrs}>
KODE PBJ</a>
{END KODEPBJ_fieldheader}
</td>
{END KODEPBJ_fieldheadercolumn}
{BEGIN NAMAKEGIATAN_fieldheadercolumn}
<td class="headerlist">
{BEGIN NAMAKEGIATAN_fieldheader}
<a class="tablelinks" {$NAMAKEGIATAN_orderlinkattrs}>
NAMA KEGIATAN</a>
{END NAMAKEGIATAN_fieldheader}
</td>
{END NAMAKEGIATAN_fieldheadercolumn}
{BEGIN NAMAPAKET_fieldheadercolumn}
<td class="headerlist">
{BEGIN NAMAPAKET_fieldheader}
<a class="tablelinks" {$NAMAPAKET_orderlinkattrs}>
NAMA PAKET</a>
{END NAMAPAKET_fieldheader}
</td>
{END NAMAPAKET_fieldheadercolumn}
{BEGIN KODESKPD_fieldheadercolumn}
<td class="headerlist">
{BEGIN KODESKPD_fieldheader}
<a class="tablelinks" {$KODESKPD_orderlinkattrs}>
SKPD</a>
{END KODESKPD_fieldheader}
</td>
{END KODESKPD_fieldheadercolumn}
{BEGIN PPK_fieldheadercolumn}
<td class="headerlist">
{BEGIN PPK_fieldheader}
<a class="tablelinks" {$PPK_orderlinkattrs}>
PPK</a>
{END PPK_fieldheader}
</td>
{END PPK_fieldheadercolumn}
{BEGIN PPTK_fieldheadercolumn}
<td class="headerlist">
{BEGIN PPTK_fieldheader}
<a class="tablelinks" {$PPTK_orderlinkattrs}>
PPTK</a>
{END PPTK_fieldheader}
</td>
{END PPTK_fieldheadercolumn}
{BEGIN KODEJENISKEGIATAN_fieldheadercolumn}
<td class="headerlist">
{BEGIN KODEJENISKEGIATAN_fieldheader}
<a class="tablelinks" {$KODEJENISKEGIATAN_orderlinkattrs}>
JENIS KEGIATAN</a>
{END KODEJENISKEGIATAN_fieldheader}
</td>
{END KODEJENISKEGIATAN_fieldheadercolumn}
{BEGIN TANGGALPENGAJUAN_fieldheadercolumn}
<td class="headerlist">
{BEGIN TANGGALPENGAJUAN_fieldheader}
<a class="tablelinks" {$TANGGALPENGAJUAN_orderlinkattrs}>
TANGGAL PENGAJUAN</a>
{END TANGGALPENGAJUAN_fieldheader}
</td>
{END TANGGALPENGAJUAN_fieldheadercolumn}
{BEGIN TANGGALKEMBALI_fieldheadercolumn}
<td class="headerlist">
{BEGIN TANGGALKEMBALI_fieldheader}
<a class="tablelinks" {$TANGGALKEMBALI_orderlinkattrs}>
TANGGAL KEMBALI</a>
{END TANGGALKEMBALI_fieldheader}
</td>
{END TANGGALKEMBALI_fieldheadercolumn}
{BEGIN LENGKAP_fieldheadercolumn}
<td class="headerlist">
{BEGIN LENGKAP_fieldheader}
<a class="tablelinks" {$LENGKAP_orderlinkattrs}>
LENGKAP</a>
{END LENGKAP_fieldheader}
</td>
{END LENGKAP_fieldheadercolumn}
{BEGIN DIKEMBALIKAN_fieldheadercolumn}
<td class="headerlist">
{BEGIN DIKEMBALIKAN_fieldheader}
<a class="tablelinks" {$DIKEMBALIKAN_orderlinkattrs}>
DIKEMBALIKAN</a>
{END DIKEMBALIKAN_fieldheader}
</td>
{END DIKEMBALIKAN_fieldheadercolumn}
{BEGIN KODESTATUSPBJ_fieldheadercolumn}
<td class="headerlist_right2">
{BEGIN KODESTATUSPBJ_fieldheader}
<a class="tablelinks" {$KODESTATUSPBJ_orderlinkattrs}>
STATUS</a>
{END KODESTATUSPBJ_fieldheader}
</td>
{END KODESTATUSPBJ_fieldheadercolumn}
<td class="headerlist_right_gif_P">&nbsp;</td>
{BEGIN endrecordheader_block}
<td class=body2></td>
{END endrecordheader_block}

{END record_header}
</tr>
{END grid_header}

{BEGIN grid_row}
<tr valign="top" {$rowstyle} {$rowattrs}>
{BEGIN grid_record}

<td>&nbsp;</td>

{BEGIN edit_column}
<td align="center" valign=middle class=borderbody>
{BEGIN edit_link}
<a class=tablelinks {$editlink_attrs}>Edit</a>
{END edit_link}
</td>
{END edit_column}



{BEGIN view_column}
<td align="center" valign=middle class=borderbody>
{BEGIN view_link}
<a class=tablelinks {$viewlink_attrs} target="new">Tanda Terima</a>
{END view_link}
</td>
{END view_column}

{BEGIN checkbox_column}
<td align="center" valign=middle class=borderbody>
{BEGIN checkbox}
<input type=checkbox {$checkbox_attrs}>
{END checkbox}
</td>
{END checkbox_column}
{BEGIN KELENGKAPANPBJ_dtable_column}
<td align="center" valign=middle class=borderbody>
{BEGIN KELENGKAPANPBJ_dtable_link}
<a  {$KELENGKAPANPBJ_dtablelink_attrs}>KELENGKAPANPBJ{BEGIN KELENGKAPANPBJ_childcount}({$KELENGKAPANPBJ_childnumber})
{END KELENGKAPANPBJ_childcount}
</a>
{END KELENGKAPANPBJ_dtable_link}
</td>
{END KELENGKAPANPBJ_dtable_column}
<!--
{BEGIN ASSIGNMENT_dtable_column}
<td align="center" valign=middle class=borderbody>
{BEGIN ASSIGNMENT_dtable_link}
<a  {$ASSIGNMENT_dtablelink_attrs}>ASSIGNMENT{BEGIN ASSIGNMENT_childcount}({$ASSIGNMENT_childnumber})
{END ASSIGNMENT_childcount}
</a>
{END ASSIGNMENT_dtable_link}
</td>
{END ASSIGNMENT_dtable_column}
-->
{BEGIN KODEPBJ_fieldcolumn}
<td align=center valign=middle class=borderbody {$KODEPBJ_style}>
{$KODEPBJ_value}
</td>
{END KODEPBJ_fieldcolumn}
{BEGIN NAMAKEGIATAN_fieldcolumn}
<td align=center valign=middle class=borderbody {$NAMAKEGIATAN_style}>
{$NAMAKEGIATAN_value}
</td>
{END NAMAKEGIATAN_fieldcolumn}
{BEGIN NAMAPAKET_fieldcolumn}
<td align=center valign=middle class=borderbody {$NAMAPAKET_style}>
{$NAMAPAKET_value}
</td>
{END NAMAPAKET_fieldcolumn}
{BEGIN KODESKPD_fieldcolumn}
<td align=center valign=middle class=borderbody {$KODESKPD_style}>
{$KODESKPD_value}
</td>
{END KODESKPD_fieldcolumn}
{BEGIN PPK_fieldcolumn}
<td align=center valign=middle class=borderbody {$PPK_style}>
{$PPK_value}
</td>
{END PPK_fieldcolumn}
{BEGIN PPTK_fieldcolumn}
<td align=center valign=middle class=borderbody {$PPTK_style}>
{$PPTK_value}
</td>
{END PPTK_fieldcolumn}
{BEGIN KODEJENISKEGIATAN_fieldcolumn}
<td align=center valign=middle class=borderbody {$KODEJENISKEGIATAN_style}>
{$KODEJENISKEGIATAN_value}
</td>
{END KODEJENISKEGIATAN_fieldcolumn}
{BEGIN TANGGALPENGAJUAN_fieldcolumn}
<td align=center valign=middle class=borderbody {$TANGGALPENGAJUAN_style}>
{$TANGGALPENGAJUAN_value}
</td>
{END TANGGALPENGAJUAN_fieldcolumn}
{BEGIN TANGGALKEMBALI_fieldcolumn}
<td align=center valign=middle class=borderbody {$TANGGALKEMBALI_style}>
{$TANGGALKEMBALI_value}
</td>
{END TANGGALKEMBALI_fieldcolumn}
{BEGIN LENGKAP_fieldcolumn}
<td align=center valign=middle class=borderbody {$LENGKAP_style}>
{$LENGKAP_value}
</td>
{END LENGKAP_fieldcolumn}
{BEGIN DIKEMBALIKAN_fieldcolumn}
<td align=center valign=middle class=borderbody {$DIKEMBALIKAN_style}>
{$DIKEMBALIKAN_value}
</td>
{END DIKEMBALIKAN_fieldcolumn}
{BEGIN KODESTATUSPBJ_fieldcolumn}
<td align=center valign=middle  {$KODESTATUSPBJ_style}>
{$KODESTATUSPBJ_value}
</td>
{END KODESTATUSPBJ_fieldcolumn}
<td>&nbsp;</td>
{BEGIN endrecord_block}
<td width=20 class=body2 {$endrecordblock_attrs}>&nbsp;</td>
{END endrecord_block}
{END grid_record}
</tr>
{END grid_row}


{BEGIN grid_footer}
<tr class=blackshade>
{BEGIN record_footer}
    <td class=headerlistdown_left2_P height=15></td>
	{BEGIN edit_column}
	<td class=blackshade>&nbsp;</td>
{END edit_column}
	
		
		
	{BEGIN view_column}
	<td class=blackshade>&nbsp;</td>
{END view_column}
	

{BEGIN checkbox_column}
	<td class=blackshade>&nbsp;</td>
{END checkbox_column}
	
{BEGIN KELENGKAPANPBJ_dtable_column}
	<td class=blackshade>&nbsp;</td>
{END KELENGKAPANPBJ_dtable_column}
{BEGIN ASSIGNMENT_dtable_column}
	<td class=blackshade>&nbsp;</td>
{END ASSIGNMENT_dtable_column}

		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
		<td class=blackshade>&nbsp;</td>
	<td class=headerlistdown_right2_P height=15>&nbsp;</td>
{BEGIN endrecordfooter_block}
    <td width=20 class=body2>&nbsp;</td>
{END endrecordfooter_block}
{END record_footer}
	</tr>
{END grid_footer}
</table>
</div>
{END grid_block}

{BEGIN pagination_block}
<div>
<b class="xtop"><b class="xb1"></b><b class="xb2"></b><b class="xb3"></b><b class="xb4"></b></b>
<div class="xboxcontent">{$pagination}</div>
<b class="xbottom"><b class="xb4"></b><b class="xb3"></b><b class="xb2"></b><b class="xb1"></b></b>
</div>
{END pagination_block}

{BEGIN message_block}
<div>
<b class="xtop"><b class="xb1"></b><b class="xb2"></b><b class="xb3"></b><b class="xb4"></b></b>
<div class="xboxcontent" id="message_block">{$message}</div>
<b class="xbottom"><b class="xb4"></b><b class="xb3"></b><b class="xb2"></b><b class="xb1"></b></b>
</div>
{END message_block}
</div>
{$footer}
{END body}

</body>
</html>


