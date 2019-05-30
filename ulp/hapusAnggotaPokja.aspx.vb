Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class hapusAnggotaPokja
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim snip As String = Request.QueryString("nip")
		Dim skodepokja As String = Request.QueryString("kodepokja")
        Dim ssql As String = ""

		ssql = ssql + "delete from AKTORPOKJA where nip='"+snip+"' and tahun = "+DateTime.Now.Year.ToString()+" and kodepokja = '"+skodepokja +"';"

		'Response.Write(ssql)
		'Response.End()

        Dim myConnection As New SqlConnection
        Dim myCommand As New SqlCommand

		 Try
			myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)
			myCommand.CommandText = ssql
			myCommand.CommandType = System.Data.CommandType.Text
			myCommand.Connection = myConnection
			myConnection.Open()

			recAfected = myCommand.ExecuteNonQuery()

		 Catch ex As System.Data.SqlClient.SqlException
			 Dim errorMsg As String = "Error in Insertion"
			 errorMsg = errorMsg & ex.Message
			 Throw New Exception(errorMsg)
		 Finally
			myCommand.Dispose()
			myConnection.Close()
			myConnection.Dispose()
		 End Try
		
		'Response.Write("Data Succsessfully deleted ...<br/><input type='submit' value='Close' onclick='window.close();'>")
		Response.Redirect("POKJA_edit.aspx?editid1=" & Request.QueryString("kodepokja"))
    End Sub
End Class
