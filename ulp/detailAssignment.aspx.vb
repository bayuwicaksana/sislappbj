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

Partial Public Class detailAssignment
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
        ssql = "select distinct d.NAMAPAKET, e.DESKRIPSI "
		ssql=ssql & " from dbo.ASSIGNMENT a "
		ssql=ssql & " inner join dbo.PBJ d on d.KODEPBJ = a.KODEPBJ "
		ssql=ssql & " inner join  dbo.POKJA c on c.KODEPOKJA = a.KODEPOKJA "
		ssql=ssql & " inner join dbo.SKPD e on e.KODESKPD = d.KODESKPD "
		ssql=ssql & " where c.KODEPOKJA = '" & Request.QueryString("pokjaid") & "' and YEAR(TGLPENETAPAN) = " & Request.QueryString("tahun")
		
		'Response.Write(ssql)
 
        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>No</td><td>NAMA PAKET</td><td>SKPD</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
	sImgOnly = ""

        Jdata = 0
        While (myReader.Read())
            Jdata = Jdata + 1
            strBody = strBody & "<tr valign='top'>"
			strBody = strBody & "<td class='tablerow'>" & jdata & "</td>"
			strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(0) & "</a></td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
            strBody = strBody & "</tr>"
        End While

        myReader.Close()

        Return "<center><font face='verdana' size='3' color='black'><b>Detail Paket Yang Sudah/Sedang Dikerjakan</b></font></center> <br><br>" &strHeader & strBody & strFooter

    End Function

    
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			'If Request.QueryString("kdta") <> "" Then
			'	ddlTA.DataBind()
			'	ddlTA.Items.FindByValue(Request.QueryString("kdta")).Selected = true
			'End If
			
			'if not ispostback() then
			'	ddlTA.Text = Now.Year()
			'end if

		Msg.InnerHtml = "" & LoadMonitor()
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
