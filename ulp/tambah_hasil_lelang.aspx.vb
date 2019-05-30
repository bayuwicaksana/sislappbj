Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class tambah_hasil_lelang
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim spaket As String = Request.QueryString("kodepbj")
		Dim sno As String = Request.QueryString("no")
		Dim stglPenetapan As String = Request.QueryString("tgl1")
		Dim snama As String = Request.QueryString("nama")
		Dim sharga As String = Request.QueryString("harga")
		Dim salamat As String = Request.QueryString("addr")
		Dim stglSanggah As String = Request.QueryString("tgl2")
 		Dim snego As String = Request.QueryString("nego")
       Dim ssql As String = ""
        Dim myConnection As New SqlConnection
        Dim myCommand As New SqlCommand
		Dim myReader As SqlDataReader

		myConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString.ToString)

		ssql = ssql + "insert into hasil_lelang values('"+spaket+"','"+sno+"',getdate(),'"+stglPenetapan+"','"+snama+"',"+sharga+",'"+salamat+"','"+stglSanggah+"',"+snego+"); "
		ssql = ssql + "update PBJ set kodestatuspbj = 'SELESAI'  where kodepbj = '"+spaket+"'; "

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
		Response.Redirect("surat_hasil_lelang.aspx?usrgrp=" & Request.QueryString("usrgrp"))
    End Sub
End Class
