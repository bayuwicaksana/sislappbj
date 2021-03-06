<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!--<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="CMenu"%>-->
<html>
<head>
<title>PBJ</title>
<link REL="stylesheet" href="include/style.css" type="text/css">
<!--[if IE]>
<link REL="stylesheet" href="include/styleIE.css" type="text/css">
<![endif]-->

<style>
#toplinks_block {padding:2px 5px}
#toplinks_block > * {margin:4px 6px;vertical-align:middle;}
#menu_block {clear:left;margin-top:10px;}
#menu_block div {float:left;}
#menu_block div div {margin-right:1px;float:none;}
#menu_block a {white-space:nowrap;}
.menuitem {padding:6px 18px 10px 13px;margin-bottom:1px}
.menuitem_active {padding:6px 18px 11px 13px;}
#search_records_block {padding:9px 10px 13px 10px;text-align:right}
#search_records_block > * {margin:2px 2px;vertical-align:middle}
#details_block, #pages_block {white-space:nowrap}
#recordcontrols_block {padding:13px 10px 9px 10px;text-align:right}
#recordcontrols > *,#newrecordcontrols > * {margin:2px 2px;vertical-align:middle}
#search_records_top {clear:left}
#message_block {text-align:center;}
#grid_block {margin-top:10px;}
.headerlist_right2 *,.headerlist * {vertical-align:middle}
.grid_recordheader {padding:0 5px 5px}
.grid_recordheader * {margin:0px 5px; vertical-align:middle}
#mastertable_block {margin:10px 0}
</style>

<!--[if IE]>

<style>
#toplinks_block * {margin:2px 3px;vertical-align:middle;}
#search_records_block * {margin:1px 1px;vertical-align:middle}
#recordcontrols *, #newrecordcontrols * {margin:1x 1px;vertical-align:middle}
</style>

<![endif]-->

<link REL="stylesheet" href="include/menuCSS.css" type="text/css">


</head>
<BODY>
<form id="form1" runat="server">
<table width="100%"  border="0" cellpadding="0" cellspacing="0" style="background-repeat:no-repeat">
  <tr>
    <td  align="left"  style="width: 100%; background:repeat url(images/HeaderulpFill.jpg);">
	<img src="images/Headerulp1.jpg"   />
    </td>
  </tr>
  
</table>
<div id="menu" runat="server" style="width: 100%;">
</div>
<div>
<b class="xtop"><b class="rb1 rb1_top"></b><b class="rb2 rb2_top"></b><b class="rb3 rb3_top"></b><b class="rb4 rb4_top"></b></b>

<div class="top" id="toplinks_block" >
<span><font style="FONT-FAMILY: Verdana, Arial;">Logged on</font></span>
<span class=buttonborder><input type=button class=button value="Log out" onclick="window.location.href='login.aspx?a=logout';"></span>
<span class=buttonborder><input type=button class=button value="Change password" onclick="window.location.href='changepwd.aspx';return false;"></span>
</div>

<b class="xbottom"><b class="rb4 rb4_top"></b><b class="rb3 rb3_top"></b><b class="rb2 rb2_top"></b><b class="rb1 rb1_top"></b></b>
</div>
    <asp:Panel ID="Panel1" runat="server">
    <br />
        <table width="95%">
            <tr align="center">
                <td>
                    <H1>Daftar Paket Pekerjaan Yang Belum Diproses</H1></td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Label ID="LabelInfo" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:GridView ID="gridJadwalLokal" runat="server" 
                        CellPadding="4" ForeColor="#333333" PageSize="50" 
                        style="border-collapse:collapse; border-width:1px; border-style:Solid; border:'1'" 
                        Width="100%" EmptyDataText="Tidak ada data" AutoGenerateColumns="False"
                        OnRowDataBound="gridJadwalLokal_RowDataBound" OnRowCommand="gridJadwalLokal_RowCommand"
                        >

                        <Columns>
	                        <asp:TemplateField HeaderText="Kegiatan" SortExpression="pbj.NAMAKEGIATAN">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelKegiatan" runat="server" Text='<%# Eval("Kegiatan") %>' EnableViewState="False"></asp:Literal>
			                        <asp:HiddenField ID="hKodePbj" runat="server" Visible="false" Value='<%# Eval("KodePbj") %>' />
		                        </itemtemplate>
                            </asp:TemplateField> 

	                        <asp:TemplateField HeaderText="Paket" SortExpression="pbj.NAMAPAKET">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelTahapan" runat="server" Text='<%# Eval("Tahapan") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>	
	
	                        <asp:TemplateField HeaderText="Jenis Kegiatan" SortExpression="pbj.KODEJENISKEGIATAN">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelJenis" runat="server" Text='<%# Eval("Jenis Kegiatan") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tanggal Pengajuan" SortExpression="pbj.TANGGALPENGAJUAN">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelTanggal" runat="server" Text='<%# Eval("Tanggal Pengajuan", "{0:d}") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PPK" SortExpression="c.Nama">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelPembawa" runat="server" Text='<%# Eval("PPK") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PPTK" SortExpression="d.Nama">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelPenerima" runat="server" Text='<%# Eval("PPTK") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>
							
							<asp:TemplateField HeaderText="Pokja" SortExpression="p.Nama">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelNama" runat="server" Text='<%# Eval("POKJA") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Surat Tugas" SortExpression="a.NOSURATTUGAS">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelTugas" runat="server" Text='<%# Eval("Surat Tugas") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status" SortExpression="pbjStatus.DESKRIPSI">
		                        <itemtemplate>
			                        <asp:Literal ID="LabelStatus" runat="server" Text='<%# Eval("Status") %>' EnableViewState="False"></asp:Literal>
		                        </itemtemplate>
                            </asp:TemplateField>
                                 
	                        <asp:TemplateField HeaderText="Action">
		                        <itemtemplate>
			                        <asp:DropDownList ID="actionList" runat="server"></asp:DropDownList>
			                        <asp:ImageButton ID="goImage" runat="server" ImageUrl="~/images/go.gif" CommandName="action" CommandArgument='<%#DataBinder.Eval(Container,"RowIndex")%>' ImageAlign="AbsMiddle" />
                                    <asp:TextBox ID="txtKodeLelang" runat="server" Width="50px" Text="#Lelang"></asp:TextBox>
		                        </itemtemplate>
                                <itemstyle wrap="False" />
                            </asp:TemplateField>
                        </Columns>

                        <SelectedRowStyle BackColor="#FFCC66" CssClass="GridSelected" Font-Bold="True" 
                            ForeColor="#663399" />
                        <AlternatingRowStyle BackColor="#E0E0E0" CssClass="tablerow" />
                        <EmptyDataRowStyle BorderStyle="None" Borderwidth="0px" Font-Bold="True" 
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle BackColor="White" CssClass="tablerow" />
                        <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 88%;">
            <tr>
                <td class="style2">
                    <b>Status Koneksi SPSE:</b> <asp:Label ID="lpseStatusLabel" runat="server" Text="Label"></asp:Label></td>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <b>Parameter Koneksi SPSE:</b> <asp:Label ID="pgParameterLabel" runat="server" Text="Label"></asp:Label></td>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table width="95%">
            <tr align="center">
                <td>
                    <H1>Jadwal Paket Pekerjaan Yang Sedang Diproses</H1></td>
            </tr>
            <tr align="center">
                <td>
                    <asp:GridView ID="gridJadwal" runat="server" CellPadding="4" 
                        ForeColor="#333333"  Width="100%" PageSize="50" 
              style="border-collapse:collapse; border-width:1px; border-style:Solid; border:'1'" 
                        EmptyDataText="Tidak ada data" >
        <SelectedRowStyle CssClass="GridSelected" BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <AlternatingRowStyle CssClass="tablerow" BackColor="#E0E0E0" />
        <EmptyDataRowStyle BorderStyle="None" Borderwidth="0px" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle CssClass="tablerow" BackColor="White"  />
        <HeaderStyle VerticalAlign="Middle"  HorizontalAlign="Center" CssClass="tableheader"></HeaderStyle>
        
    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</BODY>
</HTML>
