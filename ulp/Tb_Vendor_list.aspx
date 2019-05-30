<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Tb_Vendor_List.aspx.cs" Inherits="CTb_Vendor_List" %>-->
<html>
<head>
<title>Vendor</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
{BEGIN style_block}
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
<body topmargin=5 {$bodyattrs}>
{BEGIN body}
{$header}

<div id="height10{$id}0">
<b class="xtop"><b class="xb1b"></b><b class="xb2b"></b><b class="xb3b"></b><b class="xb4b"></b></b>
{BEGIN toplinks_block}
<div id="toplinks_block{$id}" class="upeditmenu">
<span><font style="FONT-FAMILY: Verdana, Arial;">Logged on</font></span>
<span class=buttonborder><input type=button class=button value="Log out" {$logoutlink_attrs}></span>

{BEGIN changepwd_link}
<span class=buttonborder><input type=button class=button value="Change password" {$changepwdlink_attrs}></span>
{END changepwd_link}

</div>
{END toplinks_block}
{BEGIN search_records_block}<DIV id="search_records_top{$id}"><B 
class="rb1 rb1_search"></B><B class="rb2 rb2_search"></B><B 
class="rb3 rb3_search"></B><B class="rb4 rb4_search"></B>
<DIV id="search_records_block{$id}" class=main_table_border_P>{BEGIN searchform}<SPAN id="searchform{$id}"><B>Search for 
</B>&nbsp;&nbsp;&nbsp;
                {BEGIN searchform_field}
                <select id="ctlSearchField{$id}">
                <option value="">Any field</option>
                <option value="KD_VENDOR" {$KD_VENDOR_searchfieldoption}>KD VENDOR</option>
                <option value="NAMA" {$NAMA_searchfieldoption}>NAMA VENDOR</option>
                <option value="ALAMAT" {$ALAMAT_searchfieldoption}>ALAMAT</option>
                <option value="NPWP" {$NPWP_searchfieldoption}>NPWP</option>
                <option value="TELEPON" {$TELEPON_searchfieldoption}>TELEPON</option>
                <option value="FAX" {$FAX_searchfieldoption}>FAX</option>
                <option value="EMAIL" {$EMAIL_searchfieldoption}>EMAIL</option>
                <option value="STATUS" {$STATUS_searchfieldoption}>STATUS</option>
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
            &nbsp;&nbsp;&nbsp; 
                {BEGIN details_block}
                <span>Details found: {$records_found}</span>
                {END details_block}
            
                {BEGIN pages_block}
                <span>Page {$page} of {$maxpages}</span>
                {END pages_block}
		{END searchform}
		&nbsp;&nbsp;&nbsp; 
        {BEGIN recordspp_block}<SPAN id="recordspp_block{$id}">Records Per Page: <SELECT {$recordspp_attrs}> 
  <OPTION value="10" {$rpp10_selected} id="replace_18">10</OPTION> <OPTION value="20" {$rpp20_selected} id="replace_19">20</OPTION> <OPTION value="30" {$rpp30_selected} id="replace_20">30</OPTION> <OPTION value="50" {$rpp50_selected} id="replace_21">50</OPTION> <OPTION value="100" {$rpp100_selected} id="replace_22">100</OPTION> <OPTION value="500" {$rpp500_selected} id="replace_23">500</OPTION></SELECT> </SPAN>{END recordspp_block}
        </div>
	</div>
	{END search_records_block}
{BEGIN recordcontrols_block}<DIV>
<DIV id="recordcontrols_block{$id}" class=body3>{BEGIN newrecord_controls}<SPAN id="newrecord_controls{$id}">{BEGIN add_link}<SPAN class=buttonborder><INPUT class=button type=button value="Add new" {$addlink_attrs}></SPAN> 
{END add_link}</SPAN>{END newrecord_controls}{BEGIN record_controls}<SPAN id="record_controls{$id}">{BEGIN delete_link}<SPAN class=buttonborder><INPUT class=button type=button value="Delete selected" {$deletelink_attrs}></SPAN> 
{END delete_link}</SPAN>{END record_controls}</DIV><B class=xbottom><B class="rb4 rb4_controls"></B><B 
class="rb3 rb3_controls"></B><B class="rb2 rb2_controls"></B><B 
class="rb1 rb1_controls"></B></B></DIV>{END recordcontrols_block}
<div style="height:100%">
{BEGIN grid_block}
<div id="grid_block{$id}">
<table width="100%" name="maintable" border=0 cellpadding=3 cellspacing=0 class="data">
{BEGIN grid_header}
<tr valign="top">
{BEGIN record_header}
<td class="headerlist">&nbsp;</td>

{BEGIN edit_column}
<td width=50 align="center" class="headerlist"><img src="include/img/icon_edit.gif"></td>
{END edit_column}




{BEGIN checkbox_column}
<td width=50 align="center" class="headerlist">
<input type=checkbox {$checkboxheader_attrs}>
</td>
{END checkbox_column}

{BEGIN Tb_Kontrak_dtable_column}
<td width=50 class="headerlist">&nbsp;</td>
{END Tb_Kontrak_dtable_column}

{BEGIN KD_VENDOR_fieldheadercolumn}
    <td class="headerlist" align=center>
{BEGIN KD_VENDOR_fieldheader}
<a class="tablelinks" {$KD_VENDOR_orderlinkattrs}>
KD VENDOR</a>
{END KD_VENDOR_fieldheader}
</td>
{END KD_VENDOR_fieldheadercolumn}
{BEGIN NAMA_fieldheadercolumn}
    <td class="headerlist" align=center>
{BEGIN NAMA_fieldheader}
<a class="tablelinks" {$NAMA_orderlinkattrs}>
NAMA VENDOR</a>
{END NAMA_fieldheader}
</td>
{END NAMA_fieldheadercolumn}
{BEGIN ALAMAT_fieldheadercolumn}
    <td class="headerlist" align=center>
{BEGIN ALAMAT_fieldheader}
<a class="tablelinks" {$ALAMAT_orderlinkattrs}>
ALAMAT</a>
{END ALAMAT_fieldheader}
</td>
{END ALAMAT_fieldheadercolumn}
{BEGIN NPWP_fieldheadercolumn}
    <td class="headerlist" align=center>
{BEGIN NPWP_fieldheader}
<a class="tablelinks" {$NPWP_orderlinkattrs}>
NPWP</a>
{END NPWP_fieldheader}
</td>
{END NPWP_fieldheadercolumn}
{BEGIN TELEPON_fieldheadercolumn}
    <td class="headerlist" align=center>
{BEGIN TELEPON_fieldheader}
<a class="tablelinks" {$TELEPON_orderlinkattrs}>
TELEPON</a>
{END TELEPON_fieldheader}
</td>
{END TELEPON_fieldheadercolumn}
{BEGIN FAX_fieldheadercolumn}
    <td class="headerlist" align=center>
{BEGIN FAX_fieldheader}
<a class="tablelinks" {$FAX_orderlinkattrs}>
FAX</a>
{END FAX_fieldheader}
</td>
{END FAX_fieldheadercolumn}
{BEGIN EMAIL_fieldheadercolumn}
    <td class="headerlist" align=center>
{BEGIN EMAIL_fieldheader}
<a class="tablelinks" {$EMAIL_orderlinkattrs}>
EMAIL</a>
{END EMAIL_fieldheader}
</td>
{END EMAIL_fieldheadercolumn}
{BEGIN STATUS_fieldheadercolumn}
    <td class="headerlist_right2" align=center>
{BEGIN STATUS_fieldheader}
<a class="tablelinks" {$STATUS_orderlinkattrs}>
STATUS</a>
{END STATUS_fieldheader}
</td>
{END STATUS_fieldheadercolumn}

{BEGIN endrecordheader_block}
<td class="table_right"></td>
{END endrecordheader_block}
{END record_header}
</tr>
{END grid_header}


{BEGIN grid_row}
<tr valign="top" {$rowstyle} {$rowattrs}>
{BEGIN grid_record}

<td>&nbsp;</td>

{BEGIN edit_column}
<td align="center" valign=middle>
{BEGIN edit_link}
<a class=tablelinks {$editlink_attrs}>Edit</a>
{END edit_link}
</td>
{END edit_column}




{BEGIN checkbox_column}
<td align="center" valign=middle>
{BEGIN checkbox}
<input type=checkbox {$checkbox_attrs}>
{END checkbox}
</td>
{END checkbox_column}

{BEGIN Tb_Kontrak_dtable_column}
<td align="center" valign=middle class=borderbody>
{BEGIN Tb_Kontrak_dtable_link}
<a  {$Tb_Kontrak_dtablelink_attrs}>Kontrak{BEGIN Tb_Kontrak_childcount}({$Tb_Kontrak_childnumber})
{END Tb_Kontrak_childcount}
</a>
{END Tb_Kontrak_dtable_link}
</td>
{END Tb_Kontrak_dtable_column}

{BEGIN KD_VENDOR_fieldcolumn}
<td align=center valign=middle class=borderbody {$KD_VENDOR_style}>
{$KD_VENDOR_value}
</td>
{END KD_VENDOR_fieldcolumn}
{BEGIN NAMA_fieldcolumn}
<td align=center valign=middle class=borderbody {$NAMA_style}>
{$NAMA_value}
</td>
{END NAMA_fieldcolumn}
{BEGIN ALAMAT_fieldcolumn}
<td align=center valign=middle class=borderbody {$ALAMAT_style}>
{$ALAMAT_value}
</td>
{END ALAMAT_fieldcolumn}
{BEGIN NPWP_fieldcolumn}
<td align=center valign=middle class=borderbody {$NPWP_style}>
{$NPWP_value}
</td>
{END NPWP_fieldcolumn}
{BEGIN TELEPON_fieldcolumn}
<td align=center valign=middle class=borderbody {$TELEPON_style}>
{$TELEPON_value}
</td>
{END TELEPON_fieldcolumn}
{BEGIN FAX_fieldcolumn}
<td align=center valign=middle class=borderbody {$FAX_style}>
{$FAX_value}
</td>
{END FAX_fieldcolumn}
{BEGIN EMAIL_fieldcolumn}
<td align=center valign=middle class=borderbody {$EMAIL_style}>
{$EMAIL_value}
</td>
{END EMAIL_fieldcolumn}
{BEGIN STATUS_fieldcolumn}
<td align=center valign=middle class=borderbody {$STATUS_style}>
{$STATUS_value}
</td>
{END STATUS_fieldcolumn}

{BEGIN endrecord_block}
<td width=20 class=table_right {$endrecordblock_attrs}>&nbsp;</td>
{END endrecord_block}
{END grid_record}
</tr>
{END grid_row}
	
</table>
</div>
{END grid_block}
</div>
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


