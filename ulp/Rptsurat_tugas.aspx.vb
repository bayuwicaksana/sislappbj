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

Partial Public Class Rptsurat_tugas
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
		dim yr as string
		
		yr=ddlTA.text()
		if yr="" then yr=now.year()
		
        'Load data
        ssql = "select distinct pbj.kodepbj, namakegiatan, namapaket, tanggalpengajuan, skpd.deskripsi as skpd, jk.deskripsi as jeniskegiatan, s.nosurattugas "
		ssql = ssql + "from pbj "
		ssql = ssql + "inner join skpd_tahun on (pbj.kodeskpd = skpd_tahun.kodeskpd and skpd_tahun.tahun =" & yr & ") "
		ssql = ssql + "inner join skpd on skpd.kodeskpd = skpd_tahun.kodeskpd "
		ssql = ssql + "inner join jeniskegiatan jk on pbj.kodejeniskegiatan = jk.kodejeniskegiatan "
		ssql = ssql + "left join assignment s on s.kodepbj = pbj.kodepbj "
		ssql = ssql + "where year(tanggalpengajuan) = " & yr & "  and month(tanggalPengajuan) between '" & ddlBM1.SelectedValue() & "' and '" & ddlBM2.SelectedValue() & "' and pbj.lengkap='YA' and pbj.dikembalikan='TIDAK' and s.nosurattugas is not null order by s.nosurattugas asc;"
		'Response.Write(ssql)
		'Response.End()

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>No Surat Tugas</td><td>SKPD Pemohon</td><td>Nama Kegiatan</td><td>Nama Paket</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
		sImgOnly = ""
        Jdata = 0
		ctr4stat = 1
        While (myReader.Read())
            strBody = strBody & "<tr valign='top'>"
			
			strBody = strBody & "<td class='tablerow'><a class='RowLink' href='javascript: void(0)' onclick=""window.open('surat_tugas.aspx?usrgrp=" & Request.QueryString("usrgrp") & "&action=prn&nosurattugas=" & myReader.GetValue(6) & "&', 'windowname1', 'width=1024, height=768, scrollbars=1, menubar=1'); return false;"">" & myReader.GetValue(6) & "</a></td>"
			
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(4) & "</td>"
			tmpOldSKPD = myReader.GetValue(4).ToString()
			
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(2) & "</td>"
            
            strBody = strBody & "</tr>"
            
        End While

        myReader.Close()

        Return strHeader & strBody & strFooter

    End Function

	Sub PrintMonitor()
		' Global Variables
		Dim myFile As String
        Dim myFiles As String
        Dim theData As String
		Dim strID As String = Request.QueryString("nosurattugas")
		Dim sValOnly As String
		Dim strTmp4Split as String
		Dim tmpWords(2) As String 
		Dim sSql As String = ""
		Dim tmpAnggota As String = ""
		Dim oldNIP As String = ""

		'Read Template File
		myFile = Server.MapPath("report1.htm")
		Dim objReader As New System.IO.StreamReader(myFile)
		theData = objReader.ReadToEnd
		objReader.Close()

        'read from pbj
		ssql = ssql + "select distinct a.nosurattugas, ( " 
		ssql = ssql + "select distinct NAMA from dbo.AKTOR inner join AKTORPOKJA on AKTOR.NIP = AKTORPOKJA.NIP where AKTORPOKJA.KODEJABATAN = 'KETUAULP' "
		ssql = ssql + ") as ketua, ( "
		ssql = ssql + "select distinct deskripsi from jabatanaktor where KODEJABATAN = 'KETUAULP' "
		ssql = ssql + ") as jabatan, skpd.deskripsi as skpd, CONVERT(VARCHAR(10), getdate(), 103) as tgl, ( "
		ssql = ssql + "	select distinct NIP from dbo.AKTORPOKJA where KODEJABATAN = 'KETUAULP' "
		ssql = ssql + ") as nip "
		ssql = ssql + "from dbo.ASSIGNMENT a "
		ssql = ssql + "inner join aktor ak on a.NIP = ak.nip "
		ssql = ssql + "inner join pbj on a.kodepbj=pbj.kodepbj "
		ssql = ssql + "inner join skpd on pbj.kodeskpd = skpd.kodeskpd "
		ssql = ssql + "where a.nosurattugas = '" & strID & "' and pbj.lengkap='YA' and pbj.dikembalikan='TIDAK'"

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
			theData = theData.Replace("[NO_SURAT]", myReader1.GetValue(0).ToString())
            theData = theData.Replace("[NAMA_KETUA]", myReader1.GetValue(1).ToString())
            theData = theData.Replace("[JABATAN_KETUA]", myReader1.GetValue(2).ToString())
            theData = theData.Replace("[SKPD]", myReader1.GetValue(3).ToString())
            theData = theData.Replace("[TANGGAL]", myReader1.GetValue(4).ToString())
			theData = theData.Replace("[NIP_KETUA]", myReader1.GetValue(5).ToString())
            theData = theData.Replace("[KETUA_ULP]", myReader1.GetValue(1).ToString())
        End While
        myReader1.Close()

        Dim myCommand2 As New SqlCommand()
        myCommand2.CommandText = "select distinct nama from aktor where nip in (select distinct nip from ASSIGNMENT where nosurattugas = '" & strID & "')"
        myCommand2.CommandType = CommandType.Text
        myCommand2.Connection = myConnection
        myConnection.Open()
        Dim myReader2 As SqlDataReader = myCommand2.ExecuteReader(CommandBehavior.CloseConnection)
		Dim i As Integer = 1
		While myReader2.Read()
			tmpAnggota = tmpAnggota + i.ToString() + ". " + myReader2.GetValue(0).ToString() + "<br/>"
			i = i + 1
        End While
		theData = theData.Replace("[LIST_ANGGOTA]", tmpAnggota)
        myReader2.Close()

        Dim myCommand3 As New SqlCommand()
        myCommand3.CommandText = "select distinct namapaket, namakegiatan from pbj where kodepbj in (select distinct kodepbj from ASSIGNMENT where nosurattugas = '" & strID & "') and pbj.lengkap='YA' and pbj.dikembalikan='TIDAK'"
        myCommand3.CommandType = CommandType.Text
        myCommand3.Connection = myConnection
        myConnection.Open()
        Dim myReader3 As SqlDataReader = myCommand3.ExecuteReader(CommandBehavior.CloseConnection)
		Dim j As Integer = 1
		Dim tmpPaket as String = ""
		While myReader3.Read()
			tmpPaket = tmpPaket + "&nbsp;&nbsp;&nbsp;" + j.ToString() + ". " + myReader3.GetValue(0).ToString() + " pada kegiatan " + myReader3.GetValue(1).ToString() + "<br/>"
			j = j + 1
        End While
		theData = theData.Replace("[LIST_PAKET]", tmpPaket)
        myReader3.Close()

        myFiles = Server.MapPath("rptOutput1.aspx")
        Dim objWriter As System.IO.StreamWriter
        Try
            objWriter = New System.IO.StreamWriter(myFiles)
            objWriter.Write(theData)
            objWriter.Close()
        Catch Ex As Exception
            'ErrInfo = Ex.Message
        End Try
        Response.Redirect("rptOutput1.aspx")
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If String.IsNullOrEmpty(Session("pusername")) Then
			Response.Redirect("login.aspx?message=expired")
		Else
			If Request.QueryString("kdta") <> "" Then
				ddlTA.DataBind()
				ddlTA.Items.FindByValue(Request.QueryString("kdta")).Selected = true
			End If
			
            If Request.QueryString("action") = "prn" Then
                PrintMonitor()
            End If
			if not ispostback() then
				ddlTA.Text = Now.Year()
				ddlBM1.Text = Now.Month()
				ddlBM2.Text = Now.Month()
			end if
			Msg.InnerHtml = "" & LoadMonitor()
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

    
End Class
