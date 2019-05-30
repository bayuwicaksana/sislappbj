<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="StatusPermohonan.aspx.cs" Inherits="StatusPermohonan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <table width="95%" __designer:mapid="172">
            <tr align="center" __designer:mapid="173">
                <td __designer:mapid="174">
                    Status Permohonan<br />
                </td>
            </tr>
            <tr align="center" __designer:mapid="175">
                <td __designer:mapid="176">
                    <asp:GridView ID="gridStatus" runat="server" CellPadding="4" 
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
    </p>
</asp:Content>

