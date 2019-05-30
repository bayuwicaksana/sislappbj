Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class hapus_penugasan
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim sno As String = Request.QueryString("nosurat")
        Dim ssql As String = ""

		ssql = ssql + "update pbj set kodestatuspbj='DITERIMA' where kodepbj in (select kodepbj from assignment where nosurattugas='"+sno+"');"
		ssql = ssql + "delete from assignment where nosurattugas='"+sno+"';"

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
		Response.Redirect("surat_tugas.aspx?usrgrp=" & Request.QueryString("usrgrp"))
    End Sub
End Class
