<%@ Page Language="VB" AutoEventWireup="true" CodeFile="tanda_terima.aspx.vb" Inherits="tanda_terima" MasterPageFile="~/Default.master" Title="Tanda Terima"%>
<asp:Content ID="Content1" Runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
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
            <td width="40%" align="right">Bulan : </td>
            <td align='left'>
                <asp:DropDownList ID="ddlBM" runat="server" DataSourceID="sqlDtSrcBM" DataTextField="BULAN" DataValueField="BULAN" AutoPostBack="True">
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
    SelectCommand="select KODESKPD as KD_SKPD, DESKRIPSI as NAMA from SKPD order by DESKRIPSI">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td width="40%" align="right">Jenis Kegiatan/Paket : </td>
            <td align='left'>
                <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="sqlDtSrcStatus" DataTextField="DESC_STATUS" DataValueField="KD_STATUS" AutoPostBack=true OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
					<asp:ListItem Value="-" Text="-- pilih jenis paket pekerjaan --" />
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlDtSrcStatus"
    runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    SelectCommand="SELECT DISTINCT KODEJENISKEGIATAN as [KD_STATUS], DESKRIPSI as [DESC_STATUS] FROM [JENISKEGIATAN]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan=2>&nbsp;</td>
        </tr>
        <tr>
            <td colspan=2 align="center" >
                <asp:Button ID="btnRetrieve" runat="server" Text="Lihat" />
                <asp:Button ID="btnUpdate" runat="server" Text="Clear" visible="true" />
                <asp:Button ID="btnDelete" runat="server" Text="Hapus" visible="false" />
                <asp:Button ID="btnPrint" runat="server" Text="Laporan" visible="false" /></td>
        </tr>
    </table>      
	</center>
    <br />
    <div id="Msg" style="width: 100%;" runat="server">
    </div>
    <br />
	<table width="70%" cellpadding=0 cellspacing=0><tr><td align='left'>
	 <asp:Button ID="btnCreate" runat="server" Text="Tambah" visible="false" />
	</td></tr></table>
</div>

</asp:Content>
