<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="StatusPengajuan.aspx.cs" Inherits="StatusPengajuan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="width: 64px; height: 17px">
                Kriteria</td>
            <td style="width: 121px; height: 17px">
                SKPD</td>
            <td style="width: 234px; height: 17px">
                <asp:DropDownList ID="SKPDList" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 432px; height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 64px; height: 17px">
            </td>
            <td style="width: 121px; height: 17px">
                Periode Pengajuan</td>
            <td style="width: 234px; height: 17px">
            &nbsp;<asp:DropDownList ID="bulanList" runat="server">
                </asp:DropDownList>
&nbsp;-
                <asp:DropDownList ID="TahunList" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 432px; height: 17px">
            </td>
        </tr>
        <tr>
            <td style="width: 64px">
                &nbsp;</td>
            <td style="width: 121px">
                Jenis Kegiatan</td>
            <td style="width: 234px">
                <asp:DropDownList ID="JenisList" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 432px">
                <asp:Button ID="CariButton" runat="server" onclick="CariButton_Click" 
                    Text="Cari" Width="51px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                        ForeColor="#333333"  Width="100%" PageSize="50" 
              style="border-collapse:collapse; border-width:1px; border-style:Solid; border:'1'" >
        <SelectedRowStyle CssClass="GridSelected" BackColor="#FFCC66" Font-Bold="True" 
                            ForeColor="#663399" />
        <AlternatingRowStyle CssClass="tablerow" BackColor="#E0E0E0" />
        <EmptyDataRowStyle BorderStyle="None" Borderwidth="0px" Font-Bold="True" 
                            HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle CssClass="tablerow" BackColor="White"  />
        <HeaderStyle VerticalAlign="Middle"  HorizontalAlign="Center" CssClass="tableheader"></HeaderStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

