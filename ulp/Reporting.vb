#Region " using "
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.Threading
Imports System.Globalization
Imports System.Text
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Text.RegularExpressions
#End Region

Partial Public Class Reporting
    Inherits System.Web.UI.Page

    Function LoadData() As String
        Dim ssql As String = ""
		Dim nmKeg As String = ""
		Dim myConnection As New SqlConnection
        Dim myCommand As New SqlCommand
        Dim myReader As SqlDataReader
        Dim strHeader As String
        Dim strBody As String
        Dim strFooter As String
        Dim sImgOnly As String
        Dim Jdata As Integer
		dim SubCount as integer
		Dim ctr4stat As Integer
		dim skpd as string	

        'Load data
        ssql = "select * from ViewRekapPengajuan where skpd is not null and year(tanggalPengajuan)= '" & ddlTA.SelectedValue() & "' and month(tanggalPengajuan) between '" & ddlBM1.SelectedValue() & "' and '" & ddlBM2.SelectedValue() & "' "
		if ddlStatus.SelectedValue()<>"All" then
			ssql=ssql & " and KODESTATUSPBJ='" & ddlStatus.SelectedValue() & "' "
		end if
		'Response.Write(ssql)
		'Response.End()

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' border=1 cellpadding=0 cellspacing=0> <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>JML PENGAJUAN</td><td>NO</td><td>HARI</td><td>TGL DAFTAR</td><td>PPK</td><td>PPTK</td><td>JENIS PENGADAAN</td><td >KEGIATAN</td><td >PAKET</td><td >PEMBAWA BERKAS</td><td>STATUS</td><td>PAGU</td><td>HPS</td><td>PEMENANG</td><td>KONTRAK</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
		sImgOnly = ""
        Jdata = 0
		ctr4stat = 1
		skpd=""
        While (myReader.Read())
            Jdata = Jdata + 1
            
			if (skpd <> myReader.GetValue(0)) then
				skpd = myReader.GetValue(0)
				strBody = strBody & "<tr valign='top'><td colspan='13'>" & myReader.GetValue(0) & "</td></tr>"
				SubCount=1
			end if
            strBody = strBody & "<tr valign='top'>"
			strBody = strBody & "<td class='tablerow'>" & Jdata & "</td>"
			strBody = strBody & "<td class='tablerow'>" & SubCount & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(2) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(3) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(4) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(5) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(6) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(7) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(8) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(9) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & String.Format("{0:#,##0.00}", myReader.GetValue(11)) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & String.Format("{0:#,##0.00}", myReader.GetValue(12)) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(13) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & String.Format("{0:#,##0.00}", myReader.GetValue(14)) & "</td>"
			strBody = strBody & "</tr>"
            
			SubCount = SubCount + 1
        End While

        myReader.Close()

        Return "<center><font face='verdana' size='3' color='black'><b>PENGAJUAN LELANG SKPD " & ddlTA.SelectedValue() & " <br>STATUS : " & ddlstatus.SelectedValue() & "</b></font></center> <br><br>" & strHeader & strBody & strFooter

    End Function

	

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If String.IsNullOrEmpty(Session("pusername")) Then
			Response.Redirect("login.aspx?message=expired")
		Else
			If Request.QueryString("kdta") <> "" Then
				ddlTA.DataBind()
				ddlTA.Items.FindByValue(Request.QueryString("kdta")).Selected = true
			End If
			If Request.QueryString("kdStatus") <> "" Then
				ddlStatus.DataBind()
				ddlStatus.Items.FindByValue(Request.QueryString("kdStatus")).Selected = true
			End If
  
            
			if not ispostback() then
				ddlTA.Text = Now.Year()
				ddlBM1.Text = Now.Month()
				ddlBM2.Text = Now.Month()
			end if
			
			dv.InnerHtml=LoadData()
		End If
	End Sub

	Protected Sub hlkBackToMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim sMenuURL As String = ConfigurationManager.AppSettings("MenuFile")
		If sMenuURL = [String].Empty Then
			Response.Write("<script language=javascript>alert('Menu page isn't set');</script>")
			Return
		End If

		'ClearSession()
		Response.Redirect(sMenuURL)
	End Sub
    
	 Protected Sub btnRetrieve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
		dv.InnerHtml=LoadData()
     End Sub

	

	
End Class
