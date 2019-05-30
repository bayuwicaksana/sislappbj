<%@ Page Language="VB" AutoEventWireup="true" CodeFile="RptPengadaanLangsung.aspx.vb" Inherits="RptPengadaanLangsung" MasterPageFile="~/Default.master" Title="LAPORAN PENGADAAN LANGSUNG"%>
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

		  
		  
		  <center>

	
<br>
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
            <td width="40%" align="right">Bulan : </td>
            <td align='left'>
                <asp:DropDownList ID="ddlBM1" runat="server" DataSourceID="sqlDtSrcBM" DataTextField="BULAN" DataValueField="BULAN" AutoPostBack="True">
                </asp:DropDownList> 
		s/d 
		<asp:DropDownList ID="ddlBM2" runat="server" DataSourceID="sqlDtSrcBM" DataTextField="BULAN" DataValueField="BULAN" AutoPostBack="True">
                </asp:DropDownList>

                <asp:SqlDataSource ID="sqlDtSrcBM"
    runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    SelectCommand="with monthlist as (select 1 as bulan union all select yl.bulan + 1 as bulan from monthlist yl where yl.bulan + 1 <= MONTH('2020-12-31')) select bulan from monthlist order by bulan asc;">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td width="40%" align="right">SKPD : </td>
            <td align='left'>
                <asp:DropDownList ID="ddlSKPD" runat="server" DataSourceID="sqlDtSrcSKPD" DataTextField="NAMA" DataValueField="KD_SKPD" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlDtSrcSKPD"
    runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    SelectCommand="select KODESKPD as KD_SKPD, DESKRIPSI as NAMA from SKPD union select 'All','All' order by DESKRIPSI">
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
