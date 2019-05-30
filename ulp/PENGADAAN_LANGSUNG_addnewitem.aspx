<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="PENGADAAN_LANGSUNG_Addnewitem.aspx.cs" Inherits="CPENGADAAN_LANGSUNG_Addnewitem" %>-->
<html>
<head><title>PENGADAAN LANGSUNG</title>
{BEGIN add_new_item}
{BEGIN fastTypeNAjax}
        <script>	
	        {$dispelement}.value = '{$data1}';
	        {$element}.value = '{$data2}';
	        {$dispelement}.focus();
	        if({$element}.onchange)
		        {$element}.onchange();
	        window.close();		
        </script>
{END fastTypeNAjax}
{BEGIN notfastTypeNAjax}
        <script>	

	        window.opener.create_option({$element}, '{$data1}', '{$data0}'); 
	        {$element}.options[{$element}.options.length-1].selected = true;		
	        {$element}.focus();
	        if({$element}.onchange)
		        {$element}.onchange();
        {BEGIN notAjaxcategoryField}
	        window.opener.arr_{$obj}[opener.arr_{$obj}.length]='{$data0}';
	        window.opener.arr_{$obj}[opener.arr_{$obj}.length]='{$data1}';
	        window.opener.arr_{$obj}[opener.arr_{$obj}.length]='{$category}';
        {END notAjaxcategoryField}
	        window.close();	
        	
        </script>
{END notfastTypeNAjax}
<link REL="stylesheet" href="include/style.css" type="text/css">
<body onload="document.forms[0].newitem.focus();">
<form method=post>
<div align=center><input type=text name=newitem size=30 maxlength=100>
<br><br><input class=button type=submit value="{$save_msg}" name=submit1>
<input class=button type=button onClick='window.close();return false;' value="{$close_window_msg}">
{END add_new_item}
</div>
</form>
</body>
</html>
