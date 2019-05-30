<%@ Page AutoEventWireup="true" Language="c#" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
    <style>
         body {font-family:"Verdana";font-weight:normal;font-size: .7em;color:black;} 
         p {font-family:"Verdana";font-weight:normal;color:black;margin-top: -5px}
         b {font-family:"Verdana";font-weight:bold;color:black;margin-top: -5px}
         H1 { font-family:"Verdana";font-weight:normal;font-size:18pt;color:red }
         H2 { font-family:"Verdana";font-weight:normal;font-size:14pt;color:maroon }
         pre {font-family:"Lucida Console";font-size: .9em}
         .marker {font-weight: bold; color: black;text-decoration: none;}
         .version {color: gray;}
         .error {margin-bottom: 10px;}
         .expandable { text-decoration:underline; font-weight:bold; color:navy; cursor:hand; }
        </style>
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <span><H1>Server Error<hr width=100% size=1 color=silver></H1>
    <h2> <i><%=_ex.Message %></i> </h2></span>
    <font face="Arial, Helvetica, Geneva, SunSans-Regular, sans-serif ">

            <b> Description: </b>Ooops ... There is a bug in our product. We apologize and promise to fix it as soon as we can.

            <br><br>
    <b> Stack trace: </b><%=_stack%>
    </div>
    </form>
</body>
</html>