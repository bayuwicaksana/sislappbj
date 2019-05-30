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

Partial Public Class RptRekapAssignment
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
        ssql = "select nama, COUNT(kodepbj), kodepokja from dbo.ViewRekapAssignment "
		ssql=ssql & " where tahun='" & ddlTA.SelectedValue() & "' and kodepokja <> 'PJ.GD' group by nama, kodepokja "
		
		'Response.Write(ssql)
 

        myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
        myCommand.CommandText = ssql
        myCommand.CommandType = System.Data.CommandType.Text
        myCommand.Connection = myConnection
        myConnection.Open()
        myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        strHeader = "<center><table width='70%' > <tr class='tableheader' align='center' bgcolor='silver' style='color:white'><td>No</td><td>NAMA POKJA</td><td>JUMLAH AKUMULASI</td></tr>"
        strFooter = "</table></center>"
        strBody = ""
		sImgOnly = ""

		'Read Template File
		myFile = Server.MapPath("rekapPaketPerPokja.html")
		Dim objReader As New System.IO.StreamReader(myFile)
		theData = objReader.ReadToEnd
		objReader.Close()

		Dim pokja1, pokja2, pokja3, pokja4, pokja5, pokja6 As String
		Dim tot1, tot2, tot3, tot4, tot5, tot6 As Integer
		tot1 = tot2 = tot3 = tot4 = tot5 = tot6 = 0
		pokja1 = "."
		pokja2 = "."
		pokja3 = "."
		pokja4 = "."
		pokja5 = "."
		pokja6 = "."

        Jdata = 0
        While (myReader.Read())
            Jdata = Jdata + 1
            strBody = strBody & "<tr valign='top'>"
			strBody = strBody & "<td class='tablerow'>" & jdata & "</td>"
			strBody = strBody & "<td class='tablerow'><a href='detailAssignment.aspx?usrgrp=" & Request.QueryString("usrgrp") & "&pokjaid=" & myReader.GetValue(2) & "&tahun=" & ddlTA.SelectedValue() & "' target='new' >" & myReader.GetValue(0) & "</a></td>"
            strBody = strBody & "<td class='tablerow'>" & myReader.GetValue(1) & "</td>"
            strBody = strBody & "</tr>"
			If Jdata = 1 Then
				pokja1 = myReader.GetValue(0)
				tot1 = Convert.toInt32(myReader.GetValue(1).ToString())
				'Response.write(tot1.ToString())
			End If
			If Jdata = 2 Then
				pokja2 = myReader.GetValue(0)
				tot2 = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If Jdata = 3 Then
				pokja3 = myReader.GetValue(0)
				tot3 = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If Jdata = 4 Then
				pokja4 = myReader.GetValue(0)
				tot4 = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If Jdata = 5 Then
				pokja5 = myReader.GetValue(0)
				tot5 = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
			If Jdata = 6 Then
				pokja6 = myReader.GetValue(0)
				tot6 = Convert.toInt32(myReader.GetValue(1).ToString())
			End If
        End While

        theData = theData.Replace("[POKJA1]", pokja1)
        theData = theData.Replace("[POKJA2]", pokja2)
        theData = theData.Replace("[POKJA3]", pokja3)
        theData = theData.Replace("[POKJA4]", pokja4)
        theData = theData.Replace("[POKJA5]", pokja5)
        theData = theData.Replace("[POKJA6]", pokja6)
        theData = theData.Replace("[JUMLAH1]", tot1.ToString())
        theData = theData.Replace("[JUMLAH2]", tot2.ToString())
        theData = theData.Replace("[JUMLAH3]", tot3.ToString())
        theData = theData.Replace("[JUMLAH4]", tot4.ToString())
        theData = theData.Replace("[JUMLAH5]", tot5.ToString())
        theData = theData.Replace("[JUMLAH6]", tot6.ToString())
        theData = theData.Replace("[year]", ddlTA.SelectedValue())

        myReader.Close()

		'write to output file
		myFiles = Server.MapPath("rekapPaketPerPokja.htm")
        Dim objWriter As System.IO.StreamWriter
        Try
            objWriter = New System.IO.StreamWriter(myFiles)
            objWriter.Write(theData)
            objWriter.Close()
        Catch Ex As Exception
            'ErrInfo = Ex.Message
        End Try

        Return "<center><font face='verdana' size='3' color='black'><b>jumlah paket yang sudah/sedang dilaksanakan oleh pokja tahun " & ddlTA.SelectedValue() & " </b></font></center> <br><br>" &strHeader & strBody & strFooter

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
		Msg.InnerHtml = "" & LoadMonitor() & "<br/><br/><center><iframe src='rekapPaketPerPokja.htm' width=600 height=400 frameBorder=0></iframe></center>"
    End Sub

End Class
