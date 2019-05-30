Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class tambah_kelengkapanpbj
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim sKelengkapanPBJ As String = Request.QueryString("lkppbj")
		Dim spaket As String = Request.QueryString("masterkey1")
		Dim soleh As String = Request.QueryString("oleh")
        Dim ssql As String = ""
		Dim lkppbjs() As String = sKelengkapanPBJ.Split(";")
		Dim ctrLkp As Integer = 0
		Dim lkppbj As String = ""

		ssql = ssql + "delete from kelengkapanpbj where kodebpj = '"+spaket+"';"
		For Each lkppbj In lkppbjs
			ssql = ssql + "insert into kelengkapanpbj (kodebpj,kodekelengkapan,tanggalditerima,penerimakelengkapan) values('"+spaket+"','"+lkppbj+"',getdate(),'"+soleh+"');"
			ctrLkp = ctrLkp + 1
		Next
		If ctrLkp = 3 Then
			ssql = ssql + "update pbj set kodestatuspbj = 'DITERIMA', lengkap='YA', dikembalikan='TIDAK' where kodepbj = '"+spaket+"';"
		Else
			ssql = ssql + "update pbj set kodestatuspbj = 'DIKEMBALIKAN', lengkap='TIDAK', dikembalikan='YA' where kodepbj = '"+spaket+"';"
		End If

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
		
		Response.Redirect("KELENGKAPANPBJ_list.aspx?masterkey1="+spaket+"&mastertable=PBJ")
    End Sub
End Class
