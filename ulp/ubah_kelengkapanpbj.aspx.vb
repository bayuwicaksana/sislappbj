Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class ubah_kelengkapanpbj
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim kdpaket As String = Request.QueryString("pbj")
		Dim kdkeg As String = Request.QueryString("lkp")
        Dim tglTerima As String = Request.QueryString("tgl")
		Dim sOleh As String = Request.QueryString("oleh")
        Dim ssql As String = "update kelengkapanpbj set tanggalditerima='"+tglTerima+"',penerimakelengkapan='"+sOleh+"' where kodebpj='"+kdpaket+"' and kodekelengkapan='"+kdkeg+"';"
		Response.Write(ssql)
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
		
		Response.Redirect("KELENGKAPANPBJ_list.aspx?mastertable=PBJ&masterkey1="+kdpaket)
    End Sub
End Class
