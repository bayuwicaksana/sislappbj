<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Changepwd.aspx.cs" Inherits="CChangepwd"%>-->
<html>
<head>
<title>Change password</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->
<style>
#center_block {width:30%;margin:0 auto;}
#contents_block {text-align:center;}
#header_block {white-space:nowrap;height:25px;padding:0 10px 5px;text-align:center;}
#main_block {padding:10px 0 5px 0;text-align:center;}
#inmain_block {margin:0 10px}
#fields_block {width:100%;margin:0;padding:10px}
#header_block > span {margin:0 5px}
#buttons_block {padding:10px 10px 5px}
#buttons_block div {padding:3px}
</style>
<!--[if IE]>
<style>
#main_block {padding:10px 10px 5px 10px;}
#inmain_block {margin:0 0px;width:100%}
#fields_block td {padding:3px 14px}
#oldpassword_block td {padding-top:13px}
#confirmpassword_block td {padding-bottom:13px}
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
<b><font size=+1>Change password</font></b>
</div>
<div id="main_block" class="xboxcontentb" >
<div id="inmain_block" class="xboxcontentb" >

<b class="xtop"><b class="xb1"></b><b class="xb2"></b><b class="xb3"></b><b class="xb4"></b></b>
<table cellpadding=4 cellspacing=0 border=0 id="fields_block" class="loginshade">
<tr id="oldpassword_block"> 
	<td align=right width="50%" class=loginshade> 
		<div align="left">Old password:</div>
	</td>
	<td width="50%" class=loginshade> 
		<input name="opass" type="password" {$opass_attrs}>
	</td>
</tr>
<tr id="newpassword_block"> 
	<td align=right width="50%" class=loginshade> 
		<div align="left">New password:</div>
	</td>
	<td width="50%" class=loginshade> 
		<input type=password name="newpass" {$npass_attrs}>
	</td>
</tr>
<tr id="confirmpassword_block"> 
	<td align=right width="50%" class=loginshade> 
		<div align="left">Confirm password:</div>
	</td>
	<td width="50%" class=loginshade> 
		<input type=password name="cpass" {$cpass_attrs}>
	</td>
</tr>
</table>
<div id="buttons_block" class="downedit">
	<div id="submit_block">
	<span class=buttonborder><input type=submit value="Submit" class=button></span>
	</div>
	<div>
	<a {$backlink_attrs}>Back</a>
	</div>
	{BEGIN message_block}
	<div>
	<font color=red>{$message}</font>
	</div>
	{END message_block}
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

