Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class ubah_paket
    Inherits System.Web.UI.Page

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim recAfected As Integer = 0
		Dim kdpaket As String = Request.QueryString("kdpaket")
		Dim nmpaket As String = Request.QueryString("nmpaket")
		Dim kdkeg As String = Request.QueryString("kdkeg")
		
		Dim nokontrak As String = Request.QueryString("nokontrak")
		nokontrak = nokontrak.Replace("[dan]", "&")
		
		Dim ppk As String = Request.QueryString("ppk")
		Dim kdjenis As String = Request.QueryString("kdjenis")
        Dim kdkec As String = Request.QueryString("kdkec")
		Dim kdkel As String = Request.QueryString("kdkel")
        Dim ssql As String = "update Tb_Paket_pekerjaan set nama='"+nmpaket+"',kd_kegiatan="+kdkeg+",no_kontrak='"+nokontrak+"',nip_ppk='"+ppk+"',kd_jenis='"+kdjenis+"',kd_kecamatan='"+kdkec+"',kd_kelurahan='"+kdkel+"' where kd_paket="+kdpaket+";"
		Response.Write(ssql)

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
		
		IF kdjenis = "JASALAIN" THEN
			Response.Redirect("VIEW_PAKET_JASA_LAINNYA_list.aspx?a=search&value=1&SearchFor=2014&SearchOption=Contains&SearchField=NO_KONTRAK&orderby=dKD_PAKET")
		END IF
		IF kdjenis = "KONSTRUKSI" THEN
			Response.Redirect("VIEW_PAKET_KONSTRUKSI_list.aspx?a=search&value=1&SearchFor=2014&SearchOption=Contains&SearchField=NO_KONTRAK&orderby=dKD_PAKET")
		END IF
		IF kdjenis = "KONSULTASI" THEN
			Response.Redirect("VIEW_PAKET_KONSULTASI_list.aspx?a=search&value=1&SearchFor=2014&SearchOption=Contains&SearchField=NO_KONTRAK&orderby=dKD_PAKET")
		END IF
		IF kdjenis = "PENGADAAN" THEN
			Response.Redirect("VIEW_PAKET_PENGADAAN_list.aspx?a=search&value=1&SearchFor=2014&SearchOption=Contains&SearchField=NO_KONTRAK&orderby=dKD_PAKET")
		END IF
    End Sub
End Class
