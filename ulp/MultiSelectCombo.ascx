<%@ Control Language="c#" AutoEventWireup="false" %>
<%@ Import namespace="System.Collections"%>
<%@ Import namespace="System.Collections.Specialized"%>
<!--
**********************************************************************************************
Copyright (C) Software Paradigms (I) Pvt. Ltd, 2007
http://www.spi.com
Author: Rajdeep Podder
Email : podder.rajdeep@gmail.com
**********************************************************************************************
**********************************************************************************************
Notice: This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    
    SPI and Author will not be responsible for any errors or issues because
    of the use of this component in other projects
**********************************************************************************************
-->
<script runat="server">
private NameValueCollection m_oValueCollection;
private string m_sDropDownColor = "#FFFFFF";
private double m_iMaxWidth = 90;
private int m_iMaxWidthNo = 10;
private int m_iMaxHeightNo = 1;
private double m_iMaxHeight = 24.5;
private string m_sLeft = "10";
private string m_sTop = "10";
private int m_iTop = 10;
private string m_sName = "MultiSelect";
private string m_sDisableMethod = "";
private string m_sOnChange = "";
private string m_sMaxListSize = "0";
private string m_sMaxListHeight = "4";


// *******************************************************************************
// properties
// *******************************************************************************

public NameValueCollection ListItems
{
	set 
	{ 
		m_oValueCollection = value;
		m_iMaxWidthNo = GetMaxWidth(m_oValueCollection);
		if (m_iMaxWidthNo > 10)
		{
			m_iMaxWidth = 9.5 * m_iMaxWidthNo - (m_iMaxWidthNo - 10)*3.2;
		}
		else
		{
			m_iMaxWidth = 9.5 * m_iMaxWidthNo;			
		}
		m_iMaxHeightNo = GetMaxHeight(m_oValueCollection);
		m_iMaxHeight = 24.5 * m_iMaxHeightNo;
	}
	get { return m_oValueCollection; }
}
public string BackColor
{
	set { m_sDropDownColor = value; }
	get { return m_sDropDownColor; }
}
public string Name
{
	set { m_sName = value; }
	get { return m_sName; }
}
public string Top
{
	set { m_sTop = value;
		  m_iTop = Convert.ToInt32(value); }
	get { return m_sTop; }
}
public string Left
{
	set { m_sLeft = value; }
	get { return m_sLeft; }	
}

public string DisableMethod
{
	set { m_sDisableMethod = value; }
	get { return m_sDisableMethod; }	
}

public string OnChange
{
	set { m_sOnChange = value; }
	get { return m_sOnChange; }	
}

public string MaxSize
{
	set { m_sMaxListSize = value; }
	get { return m_sMaxListSize; }	
}

public string MaxListHeight
{
	set { m_sMaxListHeight = value; }
	get { return m_sMaxListHeight; }	
}

// *******************************************************************************
// end of properties
// *******************************************************************************

private int GetMaxWidth(NameValueCollection oItems)
{
	string[] sKeyCltn =  oItems.AllKeys;
	int iMaxLength = 8;
	if (oItems != null)
	{
		for (int iCount=0; iCount < sKeyCltn.Length; iCount++)
		{
			string sValues = oItems[sKeyCltn[iCount]];
			if (sValues.Length > iMaxLength)
			{
				iMaxLength = sValues.Length;
			}
		}
	}
	iMaxLength = iMaxLength + 3;
	
	return iMaxLength;
}
		
private int GetMaxHeight(NameValueCollection oItems)
{
	string[] sKeyCltn =  oItems.AllKeys;
	int iMaxHeight = 1;
	iMaxHeight = sKeyCltn.Length + 1;
	if (iMaxHeight > Convert.ToInt32(this.m_sMaxListHeight))
	{
		iMaxHeight = Convert.ToInt32(this.m_sMaxListHeight);
	}
	return iMaxHeight;
}

</script>
<script language="javascript">
var TotalCount = 0;
var ComName="";
var DropDownHeight = 0;
function ExpandDiv(bExpand)
{
	var dropDownDiv = document.getElementById("dropDownBox_" + ComName);
	var imgId = document.getElementById("idComboButton_"+ ComName);
	var dropDownDiv = document.getElementById("dropDownBox_" + ComName);
	
	if (bExpand == null)
	{	
		if (dropDownDiv.style.display == "none")
		{
			//EnableAllComboBoxes(false);
			<%
			if (this.m_sDisableMethod != "")
			{%>
			<%=this.m_sDisableMethod + "(false)"%>
			<%}%>
			ExpandDropDown(1);
			imgId.src = "Images/comboovercoll.gif";			
		}
		else
		{
	//		setMainListBox();
			dropDownDiv.style.display = "none";
			//EnableAllComboBoxes(true);
			<%
			if (this.m_sDisableMethod != "")
			{%>
			<%=this.m_sDisableMethod + "(true)"%>
			<%}%>		
			imgId.src = "Images/combooverexp.gif";			
		}
	}
	else
	{
		if (bExpand == true)
		{
			//EnableAllComboBoxes(false);
			<%
			if (this.m_sDisableMethod != "")
			{%>
			<%=this.m_sDisableMethod + "(false)"%>
			<%}%>
			ExpandDropDown(1);
			imgId.src = "Images/comboovercoll.gif";
		}
		else
		{
			dropDownDiv.style.display = "none";
			//EnableAllComboBoxes(true);
			<%
			if (this.m_sDisableMethod != "")
			{%>
			<%=this.m_sDisableMethod + "(true)"%>
			<%}%>		
			imgId.src = "Images/combooverexp.gif";
		}
	}
}
function ExpandDropDown(iHeight)
{
	var dropDownDiv = document.getElementById("dropDownBox_" + ComName);	
	if (iHeight < DropDownHeight + 1)
	{		
		dropDownDiv.style.height = (iHeight * 12) + "px";
		dropDownDiv.style.display = "block";
		iHeight++;
		window.setTimeout("ExpandDropDown(" + iHeight+ ")",2);
	}
}
function setMainListBox()
{
	var oAllCheckBox= document.getElementById(ComName+"_Check_All");	
	var oCmdList = document.getElementById("idListBox_"+ ComName);
	var iMaxListSize = <%=this.m_sMaxListSize%>
	
	RemoveAll(oCmdList);	
		
	/*/if (oAllCheckBox.checked == true)
	{		
		oCmdList.options[0] = new Option("All","0");
		<%=this.m_sOnChange%>
		return true;
	}*/
	
	var iSize = 1;
	for (var i=0; i < TotalCount; i++)
	{
		var oTempCheckBox= document.getElementById(ComName+"_Check_"+i);
		
		if (oTempCheckBox.checked == true)
		{
			if (iMaxListSize > 0)
			{
				if (iSize <= iMaxListSize)
				{
					oCmdList.size = iSize;
				}
			}
			else
			{
				oCmdList.size = iSize;
			}
			oCmdList.options[iSize-1] = new Option(oTempCheckBox.name, oTempCheckBox.value);			
			iSize++;
		}
	}

	<%=this.m_sOnChange%>
}

function RemoveAll(ListBoxId)
{
	for (var i=(ListBoxId.options.length-1); i>=0; i--)
	{
		ListBoxId.options[i] = null;
	}	
	ListBoxId.size = 1;
	ListBoxId.options[0] = new Option("None","-1");
}
function CheckRelatedCheckBox(CheckBoxId)
{	
	var oTempCheckBox= document.getElementById(CheckBoxId);
	if (oTempCheckBox.checked == true)
	{
		oTempCheckBox.checked = false;
	}
	else
	{
		oTempCheckBox.checked = true;
	}
	oTempCheckBox.onclick();
}
function OnCheckAll()
{
	var oAllCheckBox= document.getElementById(ComName+"_Check_All");	
	
		for (var i=0; i < TotalCount; i++)
		{
			var oTempCheckBox= document.getElementById(ComName+"_Check_"+i);
			oTempCheckBox.checked = oAllCheckBox.checked;			
		}
	setMainListBox();
}

function OnCheckAny(obj)
{
	var oAllCheckBox= document.getElementById(ComName+"_Check_All");	
	if (oAllCheckBox.checked == true &&
		document.getElementById(obj).checked == false)
	{
		oAllCheckBox.checked = false;		
	}
	var bAllChecked = true;
	for (var i=0; i < TotalCount; i++)
	{
		var oTempCheckBox= document.getElementById(ComName+"_Check_"+i);
		if (oTempCheckBox.checked == false)
		{
			bAllChecked = false;
		}
	}
	if (bAllChecked == true)
	{
		oAllCheckBox.checked = true;
		OnCheckAll();
		return true;
	}
	setMainListBox();
}

function OnComboMouseOver()
{
	var imgId = document.getElementById("idComboButton_"+ ComName);
	var dropDownDiv = document.getElementById("dropDownBox_" + ComName);
	if (dropDownDiv.style.display == "block")
	{
		imgId.src = "Images/comboovercoll.gif";
	}
	else
	{
		imgId.src = "Images/combooverexp.gif";
	}
	//OnDivOver();
}
function OnComboMouseOut()
{
	var imgId = document.getElementById("idComboButton_" + ComName);
	var dropDownDiv = document.getElementById("dropDownBox_" + ComName);
	if (dropDownDiv.style.display == "block")
	{
		imgId.src = "Images/combolostcoll.gif";
	}
	else
	{
		imgId.src = "Images/combolostexp.gif";
	}
	//OnDivOut();
}
function IsDropDownExpanded()
{
	var dropDownDiv = document.getElementById("dropDownBox_" + ComName);
	if (dropDownDiv.style.display == "block")
	{
		return true;
	}
	else
	{
		return false;
	}
}
function validateMultiSelectCombo(sName, bSupressMessage) 
{	
	var idMainListBox = document.getElementById("idListBox_"+ComName);
	if (idMainListBox.length == 0 ||
		idMainListBox.options[0].value == "-1")
	{
		if (bSupressMessage == null ||
			bSupressMessage == false)
			{
				alert("The " + sName + " field is blank. Please enter a value.");
			}
		return false;
	}
	return true;	
}

function GetDataListFromMultiSelectCombo()
{
	var idMainListBox = document.getElementById("idListBox_"+ComName);
	var sValue = "";

	for (var i=0; i < idMainListBox.length; i++)
	{
		if (idMainListBox.options[0].value == "0")
		{
			return oMultiSelectComboBox_All_Options_<%=this.m_sName%>;
		}
		
		if (sValue != "")
		{
			sValue += ";"
		}
		sValue += idMainListBox.options[i].value;
	}
	return sValue;
}
var oMultiSelectComboBox_<%=this.m_sName%> = false;
var oMultiSelectComboBox_All_Options_<%=this.m_sName%> = "";
function OnDivOver()
{	
	oMultiSelectComboBox_<%=this.m_sName%> = true;	
}
function OnDivOut()
{	
	oMultiSelectComboBox_<%=this.m_sName%> = false;	
}
document.onmousedown = MouseDown;

function MouseDown()
{	
	if (oMultiSelectComboBox_<%=this.m_sName%> == false &&
		event.srcElement != document.getElementById("idComboButton_<%=this.m_sName%>"))
	{
		ExpandDiv(false);
	}
	return true;
}

function OnTdOver(controlId)
{
	var oTDCntrl = document.getElementById("ListTD_" + controlId);
	var oSpanCntrl = document.getElementById("SPAN_" + controlId);
	oTDCntrl.bgColor="#0000CC";
	oSpanCntrl.style.color = "#FFFFFF";
	
	return true;
}

function OnTdOut(controlId)
{
	var oTDCntrl = document.getElementById("ListTD_" + controlId);
	var oSpanCntrl = document.getElementById("SPAN_" + controlId);
	oTDCntrl.bgColor = "<%=this.m_sDropDownColor%>";
	oSpanCntrl.style.color = "#000000";
	
	return true;
}
</script>
<table><tr><td>
<select id="idListBox_<%=this.m_sName%>" multiple="true" size="1" style="WIDTH:<%=this.m_iMaxWidth%>;" onmouseover="OnDivOver()" onmouseout="OnDivOut()">
	<option value="-1">None</option>
</select>
<img id="idComboButton_<%=this.m_sName%>" src="Images/combolostexp.gif" align="absbottom" onmouseover="OnComboMouseOver()" onmouseout="OnComboMouseOut()" onclick="ExpandDiv()"><br>
<div id="dropDownBox_<%=this.m_sName%>" onmouseover="OnDivOver()" onmouseout="OnDivOut()"
	style="BORDER-TOP-WIDTH:thick; BORDER-LEFT-WIDTH:thick; Z-INDEX:2; BORDER-LEFT-COLOR:#d4d0c8; 
	BORDER-BOTTOM-WIDTH:thick; BORDER-BOTTOM-COLOR:#d4d0c8; HEIGHT:<%=this.m_iMaxHeight%>; WIDTH:<%=this.m_iMaxWidth%>; 
	BORDER-TOP-COLOR:#d4d0c8; POSITION:absolute; BORDER-RIGHT-WIDTH:thick; BORDER-RIGHT-COLOR:#d4d0c8; 
	layer-background-color:#99CCFF; BACKGROUND-COLOR:<%=this.m_sDropDownColor%>; 
	DISPLAY:none; overflow=auto;border-left: 1px gray solid; border-bottom: 1px gray solid;
	border-top: 1px gray solid;border-right: 1px gray solid;">
<table>
<tr><td id="ListTD_<%=this.m_sName%>_All" onmouseover="OnTdOver('<%=this.m_sName%>_All')" onmouseout="OnTdOut('<%=this.m_sName%>_All')" nowrap>
			<input type="checkbox" id="<%=(this.m_sName+ "_Check_All")%>" onclick="OnCheckAll()">
			<span id="SPAN_<%=this.m_sName%>_All" style="FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-SIZE: 10pt; cursor:pointer;" onclick="CheckRelatedCheckBox('<%=(this.m_sName+ "_Check_All")%>')" UNSELECTABLE="on">All</span>
			<script language="javascript">			
			ComName = "<%=this.m_sName%>";
			</script>
		</td>
	</tr>
<%if (m_oValueCollection != null)
{
	string[] sKeyCltn =  m_oValueCollection.AllKeys;
	
	for (int icount= 0; icount < sKeyCltn.Length; icount++)
	{
		string sValue = m_oValueCollection[sKeyCltn[icount]];
		%>
		<tr><td id="ListTD_<%=this.m_sName%>_<%=icount.ToString()%>" onmouseover="OnTdOver('<%=this.m_sName%>_<%=icount.ToString()%>')" onmouseout="OnTdOut('<%=this.m_sName%>_<%=icount.ToString()%>')" nowrap>
			<input type="checkbox" id="<%=(this.m_sName+ "_Check_" + icount.ToString())%>" onclick="OnCheckAny('<%=(this.m_sName+ "_Check_" + icount.ToString())%>')" name="<%=sValue%>" value="<%=sKeyCltn[icount]%>">
			<span id="SPAN_<%=this.m_sName%>_<%=icount.ToString()%>" style="FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-SIZE: 10pt; cursor:pointer;" onclick="CheckRelatedCheckBox('<%=(this.m_sName+ "_Check_" + icount.ToString())%>')" UNSELECTABLE="on"><%=sValue%></span>
			<script language="javascript">
			if (oMultiSelectComboBox_All_Options_<%=this.m_sName%> != "")
			{
				oMultiSelectComboBox_All_Options_<%=this.m_sName%> += ";";
			}
			oMultiSelectComboBox_All_Options_<%=this.m_sName%> += "<%=sKeyCltn[icount]%>";
			TotalCount = TotalCount + 1;
			</script>
		</td>
		</tr>		
		<%				
	}
}%>
</table>
</div>
</td></tr></table>
<script language="javascript">
var tempDropDownDiv = document.getElementById("dropDownBox_"+ComName);
var tempHeight = tempDropDownDiv.style.height;
tempHeight = tempHeight.substring(0,tempHeight.indexOf("px"));
DropDownHeight = (tempHeight/12);
</script>