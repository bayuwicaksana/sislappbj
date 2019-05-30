<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="AKTOR_List.aspx.cs" Inherits="CAKTOR_List" %>-->
<html>
<head>
<title>AKTOR</title>
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

<link REL="stylesheet" href="include/menuCSS.css" type="text/css">

<!--[if IE]>
{BEGIN iestyle_block}
<style>
#toplinks_block{$id} * {margin:2px 3px;vertical-align:middle;}
#search_records_block{$id} * {margin:1px 1px;vertical-align:middle}
#recordcontrols{$id} *, #newrecordcontrols{$id} * {margin:1x 1px;vertical-align:middle}
</style>
{END iestyle_block}
<![endif]-->

</head>
<body topmargin=5 {$bodyattrs}>
{BEGIN body}
{$header}
{BEGIN mastertable_block}
<div id="mastertable_block{$id}">
{$showmasterfile}
<a {$backtomasterlink_attrs} class="toplinks"><b>Back to Master table</b></a>
<br>
</div>
{END mastertable_block}

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
<option value="NIP" {$NIP_searchfieldoption}>NIP</option>
<option value="NAMA" {$NAMA_searchfieldoption}>NAMA</option>
<option value="KODEJABATAN" {$KODEJABATAN_searchfieldoption}>JABATAN</option>
<option value="KODETIPE" {$KODETIPE_searchfieldoption}>TIPE</option>
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




{BEGIN checkbox_column}
<td width=50 align="center" class="headerlist">
<input type=checkbox {$checkboxheader_attrs}>
</td>
{END checkbox_column}

{BEGIN PBJ_dtable_column}
<td width=50 class="headerlist">&nbsp;</td>
{END PBJ_dtable_column}
{BEGIN ASSIGNMENT_dtable_column}
<td width=50 class="headerlist">&nbsp;</td>
{END ASSIGNMENT_dtable_column}

{BEGIN NIP_fieldheadercolumn}
<td class="headerlist">
{BEGIN NIP_fieldheader}
<a class="tablelinks" {$NIP_orderlinkattrs}>
NIP</a>
{END NIP_fieldheader}
</td>
{END NIP_fieldheadercolumn}
{BEGIN NAMA_fieldheadercolumn}
<td class="headerlist">
{BEGIN NAMA_fieldheader}
<a class="tablelinks" {$NAMA_orderlinkattrs}>
NAMA</a>
{END NAMA_fieldheader}
</td>
{END NAMA_fieldheadercolumn}
{BEGIN KODEJABATAN_fieldheadercolumn}
<td class="headerlist">
{BEGIN KODEJABATAN_fieldheader}
<a class="tablelinks" {$KODEJABATAN_orderlinkattrs}>
JABATAN</a>
{END KODEJABATAN_fieldheader}
</td>
{END KODEJABATAN_fieldheadercolumn}
{BEGIN KODETIPE_fieldheadercolumn}
<td class="headerlist_right2">
{BEGIN KODETIPE_fieldheader}
<a class="tablelinks" {$KODETIPE_orderlinkattrs}>
TIPE</a>
{END KODETIPE_fieldheader}
</td>
{END KODETIPE_fieldheadercolumn}
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




{BEGIN checkbox_column}
<td align="center" valign=middle class=borderbody>
{BEGIN checkbox}
<input type=checkbox {$checkbox_attrs}>
{END checkbox}
</td>
{END checkbox_column}

{BEGIN PBJ_dtable_column}
<td align="center" valign=middle class=borderbody>
{BEGIN PBJ_dtable_link}
<a  {$PBJ_dtablelink_attrs}>PBJ{BEGIN PBJ_childcount}({$PBJ_childnumber})
{END PBJ_childcount}
</a>
{END PBJ_dtable_link}
</td>
{END PBJ_dtable_column}
{BEGIN ASSIGNMENT_dtable_column}
<td align="center" valign=middle class=borderbody>
{BEGIN ASSIGNMENT_dtable_link}
<a  {$ASSIGNMENT_dtablelink_attrs}>ASSIGNMENT{BEGIN ASSIGNMENT_childcount}({$ASSIGNMENT_childnumber})
{END ASSIGNMENT_childcount}
</a>
{END ASSIGNMENT_dtable_link}
</td>
{END ASSIGNMENT_dtable_column}

{BEGIN NIP_fieldcolumn}
<td align=center valign=middle class=borderbody {$NIP_style}>
{$NIP_value}
</td>
{END NIP_fieldcolumn}
{BEGIN NAMA_fieldcolumn}
<td align=center valign=middle class=borderbody {$NAMA_style}>
{$NAMA_value}
</td>
{END NAMA_fieldcolumn}
{BEGIN KODEJABATAN_fieldcolumn}
<td align=center valign=middle class=borderbody {$KODEJABATAN_style}>
{$KODEJABATAN_value}
</td>
{END KODEJABATAN_fieldcolumn}
{BEGIN KODETIPE_fieldcolumn}
<td align=center valign=middle  {$KODETIPE_style}>
{$KODETIPE_value}
</td>
{END KODETIPE_fieldcolumn}
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
	
		
		
		

{BEGIN checkbox_column}
	<td class=blackshade>&nbsp;</td>
{END checkbox_column}
	
{BEGIN PBJ_dtable_column}
	<td class=blackshade>&nbsp;</td>
{END PBJ_dtable_column}
{BEGIN ASSIGNMENT_dtable_column}
	<td class=blackshade>&nbsp;</td>
{END ASSIGNMENT_dtable_column}

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


