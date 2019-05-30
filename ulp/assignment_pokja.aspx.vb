Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class assignment_pokja
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim snip As String = Request.QueryString("nip")
		Dim spokja As String = Request.QueryString("usrgrp")
        Dim ssql As String = ""
		Dim nips() As String = snip.Split(";")
		Dim pokjas() As String = spokja.Split(";")
		Dim pokja As String = ""
		Dim nip As String = ""
        Dim myConnection As New SqlConnection
        Dim myCommand As New SqlCommand
		Dim kodePokja As String = ""

		For Each nip In nips
				For Each pokja In pokjas
					kodePokja = pokja
				Next
				'ssql = ssql + "update aktor set kodepokja = '"+kodePokja+"' where nip = '"+nip+"';"
				ssql = ssql + "insert into AKTORPOKJA values ('"+nip+"',"+DateTime.Now.Year.ToString()+",'"+kodePokja+"','POKJAULP');"
		Next

		'Response.Write(ssql)
		'Response.End()

		 Try
			myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
			myCommand.CommandText = ssql
			myCommand.CommandType = System.Data.CommandType.Text
			myCommand.Connection = myConnection
			myConnection.Open()

			recAfected = myCommand.ExecuteNonQuery()

		 Catch ex As System.Data.SqlClient.SqlException
			 Dim errorMsg As String = "Error in Updation"
			 errorMsg = errorMsg & ex.Message
			 Throw New Exception(errorMsg)
		 Finally
			myCommand.Dispose()
			myConnection.Close()
			myConnection.Dispose()
		 End Try
		
		'Response.Write("Data Succsessfully saved ...<br/><input type='submit' value='Close' onclick='window.close();'>")
		Response.Redirect("POKJA_list.aspx")
    End Sub
End Class
