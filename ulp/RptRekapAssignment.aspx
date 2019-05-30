<%@ Page Language="VB" AutoEventWireup="true" CodeFile="RptRekapAssignment.aspx.vb" Inherits="RptRekapAssignment" MasterPageFile="~/Default.master" Title="REKAP PENUGASAN"%>
<asp:Content ID="Content1" Runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
          <script language="javascript" type="text/javascript">
				function printDiv(divID) {
					//Get the HTML of div
					var divElements = document.getElementById(divID).innerHTML;
					//Get the HTML of whole page
					var oldPage = document.body.innerHTML;

					//Reset the page's HTML with div's HTML only
					document.body.innerHTML = "<html><head><title></title></head><body>" + divElements + "</body>";

					//Print Page
					window.print();

					//Restore orignal HTML
					document.body.innerHTML = oldPage;

				  
				}
			</script> 
		  
		  
		  <br />
		  <center>

	
    <table width="70%" cellpadding=2 cellspacing=3 bgcolor="ffeccf">
        <tr>
            <td colspan=2>&nbsp;</td>
        </tr>
        <tr>
            <td width="40%" align="right">Tahun : </td>
            <td align='left'>
                <asp:DropDownList ID="ddlTA" runat="server" DataSourceID="sqlDtSrcTA" DataTextField="THN_ANGGARAN" DataValueField="THN_ANGGARAN" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlDtSrcTA"
    runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    SelectCommand="with yearlist as (select 2010 as year union all select yl.year + 1 as year from yearlist yl where yl.year + 1 <= YEAR('2020-12-31')) select year as THN_ANGGARAN from yearlist order by year desc;">
                </asp:SqlDataSource>
            </td>
        </tr>
        
        
       
        <tr>
            <td colspan=2 align="center" >
                <asp:Button ID="btnRetrieve" runat="server" Text="Lihat" />
                <input type="button" value="Cetak" onclick="javascript:printDiv('ctl00_ContentPlaceHolder1_Msg')" />
				</td>
        </tr>
    </table>      
	</center>
    <br />
    <div id="Msg" style="width: 100%;" runat="server">
    </div>
    <br />
	
</div>

</asp:Content>
