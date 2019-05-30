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

Partial Public Class RptRekapPermohonan
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
        Dim strFooter, strTotalBeforeFooter As String
        Dim sImgOnly As String
        Dim Jdata As Integer
		Dim ctr4stat As Integer
		Dim tot1, tot2, tot3, tot4, tot5, tot6, tot7, tot8, tot9, tot10, tot11, tot12, tot13 As Integer

        'Load data
        ssql = "execute [spRptRekapPermohonan] " & ddlTA.SelectedValue() & " "
 

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>No</td><td>SKPD</td><td>JAN</td><td>PEB</td><td>MAR</td><td>APR</td><td>MEI</td><td>JUN</td><td>JUL</td><td>AGS</td><td>SEP</td><td>OKT</td><td>NOP</td><td>DES</td><td>TOTAL</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
	sImgOnly = ""

        Jdata = 0
		tot1 = tot2 = tot3 = tot4 = tot5 = tot6 = tot7 = tot8 = tot9 = tot10 = tot11 = tot12 = tot13 = 0
        While (myReader.Read())
            Jdata = Jdata + 1
            strBody = strBody & "<tr valign='top'>"
	    strBody = strBody & "<td class='tablerow'>" & jdata & "</td>"
	    strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(0) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(2) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(3) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(4) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(5) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(6) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(7) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(8) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(9) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(10) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(11) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(12) & "</td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(13) & "</td>"
            strBody = strBody & "</tr>"
			tot1 = tot1 + Convert.toInt32(myReader.GetValue(1).ToString())
			tot2 = tot2 + Convert.toInt32(myReader.GetValue(2).ToString())
			tot3 = tot3 + Convert.toInt32(myReader.GetValue(3).ToString())
			tot4 = tot4 + Convert.toInt32(myReader.GetValue(4).ToString())
			tot5 = tot5 + Convert.toInt32(myReader.GetValue(5).ToString())
			tot6 = tot6 + Convert.toInt32(myReader.GetValue(6).ToString())
			tot7 = tot7 + Convert.toInt32(myReader.GetValue(7).ToString())
			tot8 = tot8 + Convert.toInt32(myReader.GetValue(8).ToString())
			tot9 = tot9 + Convert.toInt32(myReader.GetValue(9).ToString())
			tot10 = tot11 + Convert.toInt32(myReader.GetValue(10).ToString())
			tot11 = tot11 + Convert.toInt32(myReader.GetValue(11).ToString())
			tot12 = tot12 + Convert.toInt32(myReader.GetValue(12).ToString())
			tot13 = tot13 + Convert.toInt32(myReader.GetValue(13).ToString())
        End While

        myReader.Close()
		
		strTotalBeforeFooter = "<tr valign='top'><td class='tablerow'>&nbsp;</td><td class='tablerow'>Total</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot1.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot2.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot3.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot4.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot5.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot6.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot7.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot8.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot9.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot10.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot11.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot12.ToString() & "</td>"
		strTotalBeforeFooter = strTotalBeforeFooter & "<td class='tablerow'>" & tot13.ToString() & "</td></tr>"
		
		'Read Template File
		myFile = Server.MapPath("rekapPermohonanLelang.html")
		Dim objReader As New System.IO.StreamReader(myFile)
		theData = objReader.ReadToEnd
		objReader.Close()

        ' Replace special tags with value from db
		theData = theData.Replace("[jan]", tot1.ToString())
        theData = theData.Replace("[feb]", tot2.ToString())
        theData = theData.Replace("[mar]", tot3.ToString())
        theData = theData.Replace("[apr]", tot4.ToString())
        theData = theData.Replace("[mei]", tot5.ToString())
		theData = theData.Replace("[jun]", tot6.ToString())
        theData = theData.Replace("[jul]", tot7.ToString())
		theData = theData.Replace("[ags]", tot8.ToString())
        theData = theData.Replace("[sep]", tot9.ToString())
        theData = theData.Replace("[okt]", tot10.ToString())
        theData = theData.Replace("[nov]", tot11.ToString())
        theData = theData.Replace("[des]", tot12.ToString())
        theData = theData.Replace("[year]", ddlTA.SelectedValue())
		
		'write to output file
		myFiles = Server.MapPath("rekapPermohonanLelang.htm")
        Dim objWriter As System.IO.StreamWriter
        Try
            objWriter = New System.IO.StreamWriter(myFiles)
            objWriter.Write(theData)
            objWriter.Close()
        Catch Ex As Exception
            'ErrInfo = Ex.Message
        End Try
        'Response.Redirect("rekapPermohonanLelang.cshtml")
		
        Return "<center><font face='verdana' size='3' color='black'><b>REKAPITULASI PERMOHONAN LELANG TAHUN " & ddlTA.SelectedValue() & " </b></font></center> <br><br>" &strHeader & strBody & strTotalBeforeFooter & strFooter

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
		Msg.InnerHtml = "" & LoadMonitor() & "<br/><br/><center><iframe src='rekapPermohonanLelang.htm' width=600 height=400 frameBorder=0></iframe></center>"
		'Graph.InnerHtml = "<center><img src='rekapPermohonanLelang.cshtml' /></center>"
    End Sub

    

	

End Class
