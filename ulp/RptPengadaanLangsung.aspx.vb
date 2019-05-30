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

Partial Public Class RptPengadaanLangsung
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
		if ddlSKPD.SelectedValue()="All" then
			ssql = "execute [spRptPengadaanLangsung]" & ddlBM1.SelectedValue() & ", " & ddlBM2.SelectedValue() & ", " & ddlTA.SelectedValue() & ",'%%' "
		else
			ssql = "execute [spRptPengadaanLangsung]" & ddlBM1.SelectedValue() & ", " & ddlBM2.SelectedValue() & ", " & ddlTA.SelectedValue() & ",'" & ddlSKPD.SelectedValue() & "' "
		end if

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)


	
        strHeader = "<center>   <table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>No</td><td>SKPD</td><td>Nama Kegiatan</td><td>Nama Paket</td><td>Pagu</td><td>HPS</td><td>Nilai Kontrak</td><td>Tanggal Kontrak</td><td>Pemenang</td><td>Jenis Kegiatan</td><td>Jenis Pengadaan</td><td>PPK</td><td>Pejabat</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
	    sImgOnly = ""

        Jdata = 0
        While (myReader.Read())
            Jdata = Jdata + 1
            strBody = strBody & "<tr valign='top'>"
			strBody = strBody & "<td class='tablerow'>" & jdata & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(0) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(2) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & string.format("{0:#,##0.00}", myReader.GetValue(3)) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & string.format("{0:#,##0.00}", myReader.GetValue(4)) & "</a></td>"
            strBody = strBody & "<td class='tablerow'>" & string.format("{0:#,##0.00}", myReader.GetValue(5)) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(6) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(7) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(8) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(9) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(10) & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(11) & "</td>"
            strBody = strBody & "</tr>"
        End While

        myReader.Close()

        Return "<center><font face='verdana' size='3' color='black'><b>LAPORAN PENGADAAN LANGSUNG BARANG/JASA PEMERINTAH TAHUN " & ddlTA.SelectedValue() & " <br>DI LINGKUNGAN PEMERINTAH KOTA BOGOR</b></font></center> <br><br>" & strHeader & strBody & strFooter

    End Function

    
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If String.IsNullOrEmpty(Session("pusername")) Then
			Response.Redirect("login.aspx?message=expired")
		Else
			If Request.QueryString("kdta") <> "" Then
				ddlTA.DataBind()
				ddlTA.Items.FindByValue(Request.QueryString("kdta")).Selected = true
			End If
			If Request.QueryString("kdbln") <> "" Then
				ddlBM1.DataBind()
				ddlBM1.Items.FindByValue(Request.QueryString("kdbln")).Selected = true
				
				ddlBM2.DataBind()
				ddlBM2.Items.FindByValue(Request.QueryString("kdbln")).Selected = true
			End If
            		If Request.QueryString("kdskpd") <> "" Then
				ddlSKPD.DataBind()
				ddlSKPD.Items.FindByValue(Request.QueryString("kdskpd")).Selected = true
			End If
            
			if not ispostback() then
				ddlTA.Text = Now.Year()
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

    

	

End Class
