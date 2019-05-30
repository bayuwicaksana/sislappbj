Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class tambah_penugasan
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim snip As String = Request.QueryString("nip")
		Dim spaket As String = Request.QueryString("pkg")
		Dim sno As String = Request.QueryString("no")
        Dim ssql As String = ""
		Dim nips() As String = snip.Split(";")
		Dim pakets() As String = spaket.Split(";")
		Dim paket As String = ""
		Dim nip As String = ""
        Dim myConnection As New SqlConnection
        Dim myCommand As New SqlCommand
        Dim myCommand1 As New SqlCommand
		Dim kodePokja As String = ""
		Dim myReader As SqlDataReader

			myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)

			For Each paket In pakets
				For Each nip In nips
					kodePokja = nip
				Next
				myCommand1.CommandText = "select nip from aktorpokja where kodepokja = '" + kodePokja + "' and tahun ="+DateTime.Now.Year.ToString()+""
				myCommand1.CommandType = System.Data.CommandType.Text
				myCommand1.Connection = myConnection
				myConnection.Open()
				myReader = myCommand1.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
				While (myReader.Read())
						ssql = ssql + "insert into assignment values('"+myReader.GetValue(0)+"','"+paket+"','"+sno+"',getdate(),'"+kodePokja+"');"
				End While
				myReader.Close()

				ssql = ssql + "update pbj set kodestatuspbj='PENERBITAN' where kodepbj='"+paket+"';"
			Next

			'Response.Write(ssql)
			'Response.End()

		 Try
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
		
		'Response.Write("Data Succsessfully saved ...<br/><input type='submit' value='Close' onclick='window.close();'>")
		Response.Redirect("surat_tugas.aspx?usrgrp=" & Request.QueryString("usrgrp"))
    End Sub
End Class
