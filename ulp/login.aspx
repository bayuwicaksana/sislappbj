<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="CLogin"%>-->
<html>
<head>
<title>Login</title>
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
#delimiter {margin:2px}
</style>
<!--[if IE]>
<style>
#main_block {padding:10px 10px 5px 10px;}
#inmain_block {margin:0 0px;width:100%}
#fields_block td {padding:3px 14px}
#username_block td {padding-top:13px}
#remember_block td {padding-bottom:13px}
</style>
<![endif]-->
</head>
<body>
{$header}
{BEGIN body}

<table align=center ><tr><td >
<div>
<img src="images/LOGINBG.png" />
</div>



<div style="position:relative; top:-280px; left:320px">
<div  >


<table cellpadding=4 cellspacing=0 border=0 >
<tr > 
	<td align=right width="50%" > 
		<div align="Right">Username:</div>
	</td>
	<td width="50%" > 
		<input name=username {$username_attrs}>
	</td>
</tr>
<tr > 
	<td align=right width="50%" > 
		<div align="Right">Password:</div>
	</td>
	<td width="50%" > 
		<input type=password name=password {$password_attrs}>
	</td>
</tr>
<tr > 
	<td align=right width="50%" > 
		<div align="Right">Remember Password:</div>
	</td>
	<td width="50%" > 
		<input type=checkbox {$rememberbox_attrs}>
	</td>
</tr>
<tr > 
	<td align=right width="50%" > 
		
	</td>
	<td width="50%" > 
		
	</td>
</tr>

<tr > 
	<td align=right width="50%" > 
		
	</td>
	<td width="50%" > 
		<div >
		<span > <input type=submit value="Submit" > &nbsp; <a {$guestlink_attrs} class="tablelinks">Login as Guest</a> </span>
	</div>
	</td>
</tr>

</table>
<div id="buttons_block" >
	
	{BEGIN message_block}
	<div>
	<font color=red>{$message}</font>
	</div>
	{END message_block}
	<div ></div>
	<div>
	
	</div>
</div>

</div>
</div>

</td></tr></table>
{END body}
{$footer}

</body>
</html>
