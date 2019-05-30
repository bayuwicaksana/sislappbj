Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class ResetAnggotaPokja
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim sno As String = Request.QueryString("usrgrp")
        Dim ssql As String = ""

		'ssql = ssql + "update AKTOR set KODEPOKJA = null where KODEPOKJA ='"+sno+"';"
		ssql = ssql + "delete from AKTORPOKJA where KODEPOKJA ='"+sno+"' and TAHUN ="+DateTime.Now.Year.ToString()+";"

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
			 Dim errorMsg As String = "Error in Deletion"
			 errorMsg = errorMsg & ex.Message
			 Throw New Exception(errorMsg)
		 Finally
			myCommand.Dispose()
			myConnection.Close()
			myConnection.Dispose()
		 End Try
		
		'Response.Write("POKJA Member Succsessfully reseted ...<br/><a href='POKJA_edit.aspx?editid1='" & Request.QueryString("usrgrp") & ">Back to POKJA edit</a>")
		'Response.Redirect("surat_tugas.aspx?usrgrp=" & Request.QueryString("usrgrp"))
    End Sub
End Class
