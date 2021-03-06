<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MultiSelectDropDown.ascx.cs" Inherits="MultiDropdownSample.MultiSelectDropDown" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<HTML>
	<HEAD>
		<TITLE>MultiselectionDropdown</TITLE>
	</HEAD>
	<meta content="False" name="vs_snapToGrid">
	<meta content="True" name="vs_showGrid">
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<script language="javascript">
			function SelectedIndexChanged(ctlId)
			{
   				var control = document.getElementById(ctlId+'DDList'); 
				var strSelText='';
				for(var i = 0; i < control.length; i ++)
				{ 
					if(control.options[i].selected)
					{
						strSelText +=control.options[i].text + ',';
					}
				}
				if (strSelText.length>0)
					strSelText=strSelText.substring(0,strSelText.length-1);
				var ddLabel = document.getElementById(ctlId+"DDLabel"); 
				ddLabel.innerHTML = strSelText;
				ddLabel.innerText  = strSelText;
				ddLabel.title = strSelText;
			}

			function OpenListBox(ctlId)
			{
				var lstBox = document.getElementById(ctlId+"DDList");
				if (lstBox.style.visibility == "visible")				
				{ CloseListBox(ctlId) ; }
				else
				{
					lstBox.style.visibility = "visible"; 
					lstBox.style.height="100px";
				}
			}

			function CloseListBox(ctlId)
			{
				var panel = document.getElementById(ctlId+"Panel2");
				var tabl = document.getElementById(ctlId+"Table2");
				var lstBox = document.getElementById(ctlId+"DDList");
				lstBox.style.visibility = "hidden"; 
				lstBox.style.height="0px";
				panel.style.height=tabl.style.height;
			}
	</script>
	<asp:panel id="Panel2" Height="1px" runat="server" Width="160px" BackColor="White">
		<TABLE id="Table2" style="TABLE-LAYOUT: fixed; HEIGHT: 24px" cellSpacing="0" borderColorDark="#cccccc"
			cellPadding="0" width="100%" borderColorLight="#7eb3e3" border="1" runat="server">
			<TR id="rowDD" style="HEIGHT: 15px" runat="server">
				<TD noWrap>
					<asp:Label id="DDLabel" style="CURSOR: default" runat="server" Width="134px" ToolTip="" Font-Size="Smaller"
						Font-Names="Arial" BorderColor="Transparent" BorderStyle="None" height="15px"></asp:Label></TD>
				<TD id="colDDImage" style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; BACKGROUND-COLOR: #7eb3e3"
					width="20" background="Image/DDImage.bmp" runat="server"></TD>
			</TR>
		</TABLE>
		<DIV style="Z-INDEX: 9999; POSITION: absolute">
			<asp:ListBox id="DDList" Height="72px" runat="server" Width="100%" SelectionMode="Multiple"></asp:ListBox></DIV>
	</asp:panel>
</HTML>
