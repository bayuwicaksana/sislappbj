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

Partial Public Class RptRekapStatus
    Inherits System.Web.UI.Page

    Function LoadMonitor() As String
		' Global Variables
		Dim myFile As String
        Dim myFiles As String
        Dim theData As String
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
        ssql = "Select kodestatusPBJ, COUNT(*) as jml from [dbo].[ViewStatusPengajuan] "
		ssql=ssql & " where year(tanggalpengajuan)='" & ddlTA.SelectedValue() & "' and month(tanggalPengajuan) between '" & ddlBM1.SelectedValue() & "' and '" & ddlBM2.SelectedValue() & "' group by kodestatusPBJ "
 

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>No</td><td>STATUS</td><td>JUMLAH</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
	sImgOnly = ""

		'Read Template File
		myFile = Server.MapPath("rekapPengajuanPerStatus.html")
		Dim objReader As New System.IO.StreamReader(myFile)
		theData = objReader.ReadToEnd
		objReader.Close()
		
		Dim totBahp, totKembali, totTerima, totTerbit, totProses, totSelesai As Integer
		totKembali = totTerima = totTerbit = totProses = totSelesai = 0
		totBahp = 0
		
        Jdata = 0
        While (myReader.Read())
            Jdata = Jdata + 1
            strBody = strBody & "<tr valign='top'>"
			strBody = strBody & "<td class='tablerow'>" & jdata & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(0) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
            strBody = strBody & "</tr>"
			If myReader.GetValue(0) = "BAHP" Then
				totBahp = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If myReader.GetValue(0) = "DIKEMBALIKAN" Then
				totKembali = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If myReader.GetValue(0) = "DITERIMA" Then
				totTerima = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If myReader.GetValue(0) = "PENERBITAN" Then
				totTerbit = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If myReader.GetValue(0) = "PROSES" Then
				totProses = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If myReader.GetValue(0) = "SELESAI" Then
				totSelesai = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
        End While
        theData = theData.Replace("[BAHP]", totBahp.ToString())
        theData = theData.Replace("[DIKEMBALIKAN]", totKembali.ToString())
        theData = theData.Replace("[DITERIMA]", totTerima.ToString())
        theData = theData.Replace("[PENERBITAN]", totTerbit.ToString())
        theData = theData.Replace("[PROSES]", totProses.ToString())
        theData = theData.Replace("[SELESAI]", totSelesai.ToString())
        theData = theData.Replace("[year]", ddlTA.SelectedValue())

        myReader.Close()
		
		'write to output file
		myFiles = Server.MapPath("rekapPengajuanPerStatus.htm")
        Dim objWriter As System.IO.StreamWriter
        Try
            objWriter = New System.IO.StreamWriter(myFiles)
            objWriter.Write(theData)
            objWriter.Close()
        Catch Ex As Exception
            'ErrInfo = Ex.Message
        End Try

        Return "<center><font face='verdana' size='3' color='black'><b>REKAPITULASI PENGAJUAN PER STATUS TAHUN " & ddlTA.SelectedValue() & " </b></font></center> <br><br>" &strHeader & strBody & strFooter

    End Function

    
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If String.IsNullOrEmpty(Session("pusername")) Then
			Response.Redirect("login.aspx?message=expired")
		Else
			If Request.QueryString("kdta") <> "" Then
				ddlTA.DataBind()
				ddlTA.Items.FindByValue(Request.QueryString("kdta")).Selected = true
			End If
			
			if not ispostback() then
				ddlTA.Text = Now.Year()
				ddlBM1.Text = Now.Month()
				ddlBM2.Text = Now.Month()
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
		Msg.InnerHtml = "" & LoadMonitor() & "<br/><br/><center><iframe src='rekapPengajuanPerStatus.htm' width=600 height=400 frameBorder=0></iframe></center>"
    End Sub

    

	

End Class
