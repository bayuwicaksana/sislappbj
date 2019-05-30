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

Partial Public Class tanda_terima
    Inherits System.Web.UI.Page

    Function LoadMonitor() As String
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
		Dim ctr4stat As Integer

        'Load data
        ssql = "select kodepbj, namakegiatan, namapaket, tanggalpengajuan, skpd.deskripsi as skpd, jk.deskripsi as jeniskegiatan, s.deskripsi as [status] "
		ssql = ssql + "from pbj "
		ssql = ssql + "inner join skpd on pbj.kodeskpd = skpd.kodeskpd "
		ssql = ssql + "inner join jeniskegiatan jk on pbj.kodejeniskegiatan = jk.kodejeniskegiatan "
		ssql = ssql + "inner join statuspbj s on pbj.kodestatuspbj = s.kodestatus "
		ssql = ssql + "where year(tanggalpengajuan) = " & ddlTA.SelectedValue() & " and month(tanggalpengajuan)=" & ddlBM.SelectedValue() & " and pbj.kodeskpd='" & ddlSKPD.SelectedValue() & "' and pbj.kodejeniskegiatan = '" & ddlStatus.SelectedValue() & "'"
		'Response.Write(ssql)
		'Response.End()

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>Nama Kegiatan</td><td>Nama Paket</td><td>Tanggal Pengajuan</td><td>SKPD</td><td>Jenis Kegiatan</td><td>Status</td><td >Action</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
		sImgOnly = ""
        Jdata = 0
		ctr4stat = 1
        While (myReader.Read())
            Jdata = Jdata + 1
            strBody = strBody & "<tr valign='top'><td class='tablerow'>" & myReader.GetValue(1) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(2) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(3) & "</a></td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(4) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(5) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(6) & "</td>"
            strBody = strBody & "<td width='200px' align='center'><a class='RowLink' href='javascript: void(0)' onclick=""window.open('tanda_terima.aspx?usrgrp=" & Request.QueryString("usrgrp") & "&action=prn&kdpbj=" & myReader.GetValue(0) & "&', 'windowname1', 'width=1024, height=768, scrollbars=1, menubar=1'); return false;"">Cetak</a></td>"
            strBody = strBody & "</tr>"
            ctr4stat = ctr4stat + 1
        End While

        myReader.Close()

        Return strHeader & strBody & strFooter

    End Function
	
    Function DaysInBahasa(sDaysInEnglish As String) As String
		Dim sNamaHari As String = ""
		Select Case sDaysInEnglish
			Case "Sunday"
				sNamaHari = "Minggu" 
			Case "Monday"
				sNamaHari = "Senin"
			Case "Tuesday"
				sNamaHari = "Selasa"
			Case "Wednesday"
				sNamaHari = "Rabu" 
			Case "Thursday"
				sNamaHari = "Kamis"
			Case "Friday"
				sNamaHari = "Jumat"
			Case "Saturday"
				sNamaHari = "Sabtu"
			Case Else
				sNamaHari = " "
		End Select
		Return sNamaHari
    End Function

	Sub PrintMonitor()
		' Global Variables
		Dim myFile As String
        Dim myFiles As String
        Dim theData As String
		Dim strID As String = Request.QueryString("editid1")
		Dim sValOnly As String
		Dim strTmp4Split as String
		Dim tmpWords(2) As String 
		Dim sSql As String = ""

		'Read Template File
		myFile = Server.MapPath("report.htm")
		Dim objReader As New System.IO.StreamReader(myFile)
		theData = objReader.ReadToEnd
		objReader.Close()

        'read from pbj
		ssql = ssql + "select datename(dw,tanggalpengajuan) as hari, CONVERT(VARCHAR(10), tanggalpengajuan, 103), skpd.deskripsi as skpd, " 
		ssql = ssql + "ppk.Nama, pptk.Nama, "
		ssql = ssql + "namakegiatan, namapaket, pembawaberkas1, jk.deskripsi as jeniskegiatan, prosespengadaan, ( "
		ssql = ssql + "select (case when kpbj.kodekelengkapan is NULL then 'TIDAK' else 'YA' end) from kelengkapanpbj kpbj inner join kelengkapan k on kpbj.kodekelengkapan = k.kodekelengkapan where kodebpj = pbj.kodepbj and kodedokumen = 'HPS' and kodejeniskegiatan = pbj.kodejeniskegiatan "
		ssql = ssql + ") as hps, ( "
		ssql = ssql + "select (case when kpbj.kodekelengkapan is NULL then 'TIDAK' else 'YA' end) from kelengkapanpbj kpbj inner join kelengkapan k on kpbj.kodekelengkapan = k.kodekelengkapan where kodebpj = pbj.kodepbj and kodedokumen = 'DRAFT' and kodejeniskegiatan = pbj.kodejeniskegiatan "
		ssql = ssql + ") as draftkontrak, ( "
		ssql = ssql + "select (case when kpbj.kodekelengkapan is NULL then 'TIDAK' else 'YA' end) from kelengkapanpbj kpbj inner join kelengkapan k on kpbj.kodekelengkapan = k.kodekelengkapan where kodebpj = pbj.kodepbj and kodedokumen not in ('DRAFT','HPS') and kodejeniskegiatan = pbj.kodejeniskegiatan "
		ssql = ssql + ") as otherdocs, catatan, lengkap, dikembalikan, datename(dw,tanggalkembali), CONVERT(VARCHAR(10), tanggalkembali, 103), pembawaberkas2, penerimaberkas1, penerimaberkas2 "
		ssql = ssql + "from pbj "
		ssql = ssql + "inner join skpd on pbj.kodeskpd = skpd.kodeskpd "
		ssql = ssql + "inner join jeniskegiatan jk on pbj.kodejeniskegiatan = jk.kodejeniskegiatan "
		ssql = ssql + "inner join aktor ppk on pbj.ppk = ppk.nip and ppk.kodejabatan = 'PPK' "
		ssql = ssql + "inner join aktor pptk on pbj.pptk = pptk.nip and pptk.kodejabatan = 'PPTK' "
		ssql = ssql + "where pbj.kodepbj = '" & strID & "'"
		
		'Response.Write(ssql)
		'Response.End()

        Dim myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        Dim myCommand1 As New SqlCommand()
        myCommand1.CommandText = sSql
        myCommand1.CommandType = CommandType.Text
        myCommand1.Connection = myConnection
        myConnection.Open()
        Dim myReader1 As SqlDataReader = myCommand1.ExecuteReader(CommandBehavior.CloseConnection)
		sValOnly = ""
        While myReader1.Read()
            ' Replace special tags with value from db
            theData = theData.Replace("[HARI]", DaysInBahasa(myReader1.GetValue(0).ToString()))
            theData = theData.Replace("[TANGGAL]", myReader1.GetValue(1).ToString())
            theData = theData.Replace("[SKPD]", myReader1.GetValue(2).ToString())
            theData = theData.Replace("[PPK]", myReader1.GetValue(3).ToString())
            theData = theData.Replace("[PPTK]", myReader1.GetValue(4).ToString())
            theData = theData.Replace("[KEGIATAN]", myReader1.GetValue(5).ToString())
            theData = theData.Replace("[PAKET]", myReader1.GetValue(6).ToString())
			theData = theData.Replace("[BAWA_BERKAS]", myReader1.GetValue(7).ToString())
            theData = theData.Replace("[JENIS]", myReader1.GetValue(8).ToString())
            theData = theData.Replace("[PROSES_ADA]", myReader1.GetValue(9).ToString())
			theData = theData.Replace("[YA_TIDAK1]", myReader1.GetValue(10).ToString())
            theData = theData.Replace("[YA_TIDAK2]", myReader1.GetValue(11).ToString())
			theData = theData.Replace("[YA_TIDAK3]", myReader1.GetValue(12).ToString())
            theData = theData.Replace("[CATATAN]", myReader1.GetValue(13).ToString())
            theData = theData.Replace("[LENGKAP_TIDAK]", myReader1.GetValue(14).ToString())
            theData = theData.Replace("[BALIK_TIDAK]", myReader1.GetValue(15).ToString())
            theData = theData.Replace("[HARI_KEMBALI]", DaysInBahasa(myReader1.GetValue(16).ToString()))
            theData = theData.Replace("[TGL_KEMBALI]", myReader1.GetValue(17).ToString())
            theData = theData.Replace("[PEMBAWA_KEMBALI]", myReader1.GetValue(18).ToString())
            theData = theData.Replace("[PENERIMA1]", myReader1.GetValue(19).ToString())
			theData = theData.Replace("[PENERIMA2]", myReader1.GetValue(20).ToString())
            theData = theData.Replace("[PEMBAWA1]", myReader1.GetValue(7).ToString())
			theData = theData.Replace("[PEMBAWA2]", myReader1.GetValue(18).ToString())
        End While
        myReader1.Close()

        myFiles = Server.MapPath("rptOutput.aspx")
        Dim objWriter As System.IO.StreamWriter
        Try
            objWriter = New System.IO.StreamWriter(myFiles)
            objWriter.Write(theData)
            objWriter.Close()
        Catch Ex As Exception
            'ErrInfo = Ex.Message
        End Try
        Response.Redirect("rptOutput.aspx")
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If Request.QueryString("kdta") <> "" Then
				ddlTA.DataBind()
				ddlTA.Items.FindByValue(Request.QueryString("kdta")).Selected = true
			End If
			If Request.QueryString("kdbln") <> "" Then
				ddlBM.DataBind()
				ddlBM.Items.FindByValue(Request.QueryString("kdbln")).Selected = true
			End If
            If Request.QueryString("kdskpd") <> "" Then
				ddlSKPD.DataBind()
				ddlSKPD.Items.FindByValue(Request.QueryString("kdskpd")).Selected = true
			End If
            If Request.QueryString("action") = "prn" Then
                PrintMonitor()
            End If
			if not ispostback() then
				ddlTA.Text = Now.Year()
			end if
	End Sub



    Protected Sub hlnkLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sLoginURL As String = ConfigurationManager.AppSettings("LoginFile")
        If sLoginURL = "" Then
            Response.Write("<script language=javascript>alert(' " + "Login page isnt set" + "');</script>")
            Return
        End If
        Session("User") = Nothing
        Session.Clear()
        Response.Redirect(sLoginURL)
    End Sub

    Protected Sub btnRetrieve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
		Msg.InnerHtml = "" & LoadMonitor()
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '
    End Sub

    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
	'
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
		'
    End Sub

	Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
		Response.redirect("tanda_terima.aspx?usrgrp=" & Request.QueryString("usrgrp"))
    End Sub

	Protected Sub chkSelect_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
		 Dim chkTest As CheckBox = DirectCast(sender, CheckBox)
		 Dim grdRow As GridViewRow = DirectCast(chkTest.NamingContainer, GridViewRow)
		 'TextBox txtname = (TextBox)grdRow.FindControl("txtName");
		 Dim txtConsCnt As TextBox = DirectCast(grdRow.FindControl("txtConsCnt"), TextBox)
		 Dim txtConsCnt1 As TextBox = DirectCast(grdRow.FindControl("txtConsCnt1"), TextBox)
		 If chkTest.Checked Then
			 txtConsCnt.ReadOnly = False
			 txtConsCnt1.ReadOnly = False
			 txtConsCnt.ForeColor = System.Drawing.Color.Black
			 txtConsCnt1.ForeColor = System.Drawing.Color.Black
		 Else
			 txtConsCnt.ReadOnly = True
			 txtConsCnt1.ReadOnly = True
			 txtConsCnt.ForeColor = System.Drawing.Color.Blue
			 txtConsCnt1.ForeColor = System.Drawing.Color.Blue
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

    Protected Sub ddlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlStatus.SelectedIndexChanged
	'
    End Sub

    Protected Sub ddlBM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBM.SelectedIndexChanged
	'
    End Sub

    Protected Sub ddlTA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTA.SelectedIndexChanged
	'
    End Sub

    Protected Sub ddlSKPD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSKPD.SelectedIndexChanged
	'
    End Sub

End Class
