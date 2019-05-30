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

Partial Public Class surat_hasil_lelang
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
		Dim tmpOldNoSurat as String = ""
		Dim tmpOldSKPD as String = ""
		Dim year As String = ddlTA.Text
		
		If year = "" Then 
			year = Now.Year()
		End If

        'Load data
		If Request.QueryString("pagenumber") Is Nothing Then
			ssql = "exec dbo.spPagingSuratHasilLelang 1, 10, " & year & ";"
		Else
			ssql = "exec dbo.spPagingSuratHasilLelang " & Request.QueryString("pagenumber") & ", 10, " & year & ";"
		End If 
		'Response.Write(ssql)
		'Response.End()

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>No Surat</td><td>SKPD Pemohon</td><td>Nama Kegiatan</td><td>Nama Paket</td><td >Action</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
		sImgOnly = ""
        Jdata = 0
		ctr4stat = 1
        While (myReader.Read())
            strBody = strBody & "<tr valign='top'>"
			strBody = strBody & "<td class='tablerow'><a class='RowLink' href='javascript: void(0)' onclick=""window.open('surat_hasil_lelang.aspx?usrgrp=" & Request.QueryString("usrgrp") & "&action=prn&nosurat=" & myReader.GetValue(6) & "&', 'windowname1', 'width=1024, height=768, scrollbars=1, menubar=1'); return false;"">" & myReader.GetValue(6) & "</a></td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(4) & "</td>"
			tmpOldSKPD = myReader.GetValue(4).ToString()
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(2) & "</td>"
			if myReader.GetValue(6).ToString() = "" Then
				strBody = strBody & "<td width='200px' align='center'><a href='CreateSuratHasilLelang.aspx?usrgrp=" & Request.QueryString("usrgrp") & "&kodepbj=" & myReader.GetValue(0).ToString() & "'>create</a></td>"
				tmpOldNoSurat = myReader.GetValue(6).ToString()
			else 
				strBody = strBody & "<td width='200px' align='center'><a href='hapus_hasil_lelang.aspx?usrgrp=" & Request.QueryString("usrgrp") & "&nosurat=" & myReader.GetValue(6).ToString() & "'>delete</a></td>"
				tmpOldNoSurat = myReader.GetValue(6).ToString()
			end if
            strBody = strBody & "</tr>"
			Jdata = Convert.toInt32(myReader.GetValue(8).ToString())
        End While

        myReader.Close()
		
		strFooter = strFooter & "<br/><center>Page : "
		While (ctr4stat < Jdata) 
			strFooter = strFooter & "<a href='surat_hasil_lelang.aspx?usrgrp=" & Request.QueryString("usrgrp") & "&pagenumber=" & ctr4stat.ToString() & "'>" & ctr4stat.ToString() & "</a> &nbsp; "
			ctr4stat = ctr4stat + 1
		End While
		strFooter = strFooter & "</center>"

        Return strHeader & strBody & strFooter

    End Function

	Sub PrintMonitor()
		' Global Variables
		Dim myFile As String
        Dim myFiles As String
        Dim theData As String
		Dim strID As String = Request.QueryString("nosurat")
		Dim sValOnly As String
		Dim strTmp4Split as String
		Dim tmpWords(2) As String 
		Dim sSql As String = ""
		Dim tmpAnggota As String = ""
		Dim oldNIP As String = ""

		'Read Template File
		myFile = Server.MapPath("report2.htm")
		Dim objReader As New System.IO.StreamReader(myFile)
		theData = objReader.ReadToEnd
		objReader.Close()

        'read from pbj
		ssql = ssql + "select distinct CONVERT(VARCHAR(10), a.TGLSURATHASILLELANG, 103) as tglsurat, a.NOSURATHASILLELANG, ( "
		ssql = ssql + "select distinct NAMA from dbo.AKTOR inner join AKTORPOKJA on AKTOR.NIP = AKTORPOKJA.NIP where AKTORPOKJA.KODEJABATAN = 'KETUAULP' "
		ssql = ssql + ") as ketua, pbj.NAMAPAKET, skpd.deskripsi as skpd, CONVERT(VARCHAR(10), tglpenetapan, 103) as tgl, ( "
		ssql = ssql + "select distinct NIP from dbo.AKTORPOKJA where KODEJABATAN = 'KETUAULP' "
		ssql = ssql + ") as nip, a.PEMENANG, 'Rp. '+convert(varchar(50), CAST(a.HARGAPEMENANG as money), -1) amount, a.ALAMATPEMENANG, CONVERT(VARCHAR(10), a.TGLSANGGAH, 103) as tglsanggah, 'Rp. '+convert(varchar(50), CAST(a.HARGANEGO as money), -1) nego "
		ssql = ssql + "from dbo.HASIL_LELANG a "
		ssql = ssql + "inner join pbj on a.kodepbj=pbj.kodepbj "
		ssql = ssql + "inner join skpd_tahun on (pbj.kodeskpd = skpd_tahun.kodeskpd and skpd_tahun.tahun = year(pbj.tanggalpengajuan)) "
		ssql = ssql + "inner join skpd on skpd.kodeskpd = skpd_tahun.kodeskpd "
		ssql = ssql + "where a.NOSURATHASILLELANG = '" & strID & "'"

		'Response.Write(ssql)
		'Response.End()

        Dim myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        Dim myCommand1 As New SqlCommand()
        myCommand1.CommandText = sSql
        myCommand1.CommandType = CommandType.Text
        myCommand1.Connection = myConnection
        myConnection.Open()
        Dim myReader1 As SqlDataReader = myCommand1.ExecuteReader(CommandBehavior.CloseConnection)
		While myReader1.Read()
            ' Replace special tags with value from db
			theData = theData.Replace("[TGL_SURAT]", myReader1.GetValue(0).ToString())
			theData = theData.Replace("[NO_SURAT]", myReader1.GetValue(1).ToString())
            theData = theData.Replace("[NAMA_PAKET]", myReader1.GetValue(3).ToString())
            theData = theData.Replace("[NAMA_SKPD]", myReader1.GetValue(4).ToString())
            theData = theData.Replace("[TGL_PENETAPAN]", myReader1.GetValue(5).ToString())
            theData = theData.Replace("[NAMA_PEMENANG]", myReader1.GetValue(7).ToString())
			theData = theData.Replace("[HARGA]", myReader1.GetValue(8).ToString())
            theData = theData.Replace("[ADDR]", myReader1.GetValue(9).ToString())
            theData = theData.Replace("[TGL_SANGGAH]", myReader1.GetValue(10).ToString())
            theData = theData.Replace("[KETUA_ULP]", myReader1.GetValue(2).ToString())
            theData = theData.Replace("[NIP_KETUA]", myReader1.GetValue(6).ToString())
			theData = theData.Replace("[NEGO]", myReader1.GetValue(11).ToString())
        End While
        myReader1.Close()

        myFiles = Server.MapPath("rptOutput2.aspx")
        Dim objWriter As System.IO.StreamWriter
        Try
            objWriter = New System.IO.StreamWriter(myFiles)
            objWriter.Write(theData)
            objWriter.Close()
        Catch Ex As Exception
            'ErrInfo = Ex.Message
        End Try
        Response.Redirect("rptOutput2.aspx")
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If String.IsNullOrEmpty(Session("pusername")) Then
			Response.Redirect("login.aspx?message=expired")
		Else
            If Request.QueryString("action") = "prn" Then
                PrintMonitor()
            End If
			if not ispostback() then
				ddlTA.Text = Now.Year()
				Msg.InnerHtml = "" & LoadMonitor()
			end if
		End If
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
		Response.redirect("surat_tugas.aspx?usrgrp=" & Request.QueryString("usrgrp"))
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
