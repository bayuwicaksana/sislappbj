<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Import namespace="System.Collections"%>
<%@ Import namespace="System.Collections.Specialized"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="System.Data.SqlClient"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Surat Tugas</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 8.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	<script language="JavaScript" type="text/JavaScript"> 
	function saveIt(){ 
	document.execCommand("SaveAs") 
	} 
	</script>
</head>
<body>
	<center>
    <table style="width: 90%" border=0 cellpadding=0 cellspacing=0 >
        <tr >
            <td width=24% align=center><img src="images/bogor.jpg"></td>
            <td width=1%>&nbsp;</td >
            <td colspan=3 align=center><span style="font-family: Verdana; font-size: 14pt">PEMERINTAH KOTA BOGOR<br/>UNIT LAYANAN PENGADAAN (ULP)<br/>Kantor Walikota Bogor Lantai 4<br/>Jl Ir H Djuanda 10 Kota Bogor 16121<br/>Telpon/Faksimili : 0251-8321075 ext 284/0251-8326530<br/>email : ulp@kotabogor.go.id</span></td>
        </tr>
		<tr>
            <td colspan=5 align=center><hr/></td>
		</tr>
		<tr>
            <td colspan=5 align=center><span style="font-family: Verdana; font-size:10pt">BERITA ACARA HASIL PELELANGAN (BAHP)<br/>PAKET PEKERJAAN <input type="text" name="nmpaket" size="50"><br/>TAHUN <%=DateTime.Now.Year.ToString()%><br/>SPSE<br/><br/></span><span style="font-family: Verdana; font-size: 10pt">Nomor : <input type="text" name="nomor" size="50"></span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
	<%
		SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select distinct nama, DESKRIPSSI from pokja where kodepokja in (select distinct kodepokja from aktorpokja where nip = '" + Request["nip"] + "' and tahun = year(getdate()))";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		string namapokja = "";
		string deskripsipokja = "";
		
        while (myReader.Read())
            {
				namapokja = myReader.GetValue(0).ToString();
				deskripsipokja = myReader.GetValue(1).ToString();
            }
        myReader.Close();
	%>
        <tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size: 10pt">Pada hari ini <input type="text" name="hari" size="4"> tanggal <input type="text" name="tanggal" size="100">, yang bertanda tangan di bawah ini selaku <%=deskripsipokja%> Pemerintah  Kota Bogor, telah melaksanakan Evaluasi File Penawaran dengan hasil sebagai berikut : </span></td>
         </tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                Nama Pekerjaan</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="nmpekerjaan" size="50"></span></td>
        </tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                Kode Lelang Elektronik</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="kode" size="7" maxlength=7></span></td>
        </tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                Lokasi Pekerjaan</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="lokasi" ></span></td>
        </tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                SKPD</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="skpd" size="50"></span></td>
        </tr>
        <tr>
            <td valign=top><span style="font-family: Verdana; font-size: 10pt">
                Kelompok Kerja</span></td>
            <td valign=top>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="pokjaulp" ></span></td>
        </tr>
        <tr>
            <td valign=top><span style="font-family: Verdana; font-size: 10pt">
                Sumber Dana</span></td>
            <td valign=top>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt"><input type="text" name="dana" ></span></td>
        </tr>
        <tr>
            <td valign=top><span style="font-family: Verdana; font-size: 10pt">
                Tahun Anggaran</span></td>
            <td valign=top>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt"><input type="text" name="ta" maxlength=4 size=4></span></td>
        </tr>
        <tr>
            <td valign=top><span style="font-family: Verdana; font-size: 10pt">
                Harga Perkiraan Sendiri</span></td>
            <td valign=top>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt"><input type="text" name="hps" size=50></span></td>
        </tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                Jangka waktu pelaksanaan</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="waktu" size="50"></span></td>
        </tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                Metode Penilaian Kualifikasi</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="metode" ></span></td>
        </tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                Metode Pemilihan</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="pemilihan" ></span></td>
        </tr>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                Metode Penyampaian</span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="penyampaian" ></span></td>
        </tr>
        <tr>
            <td valign=top><span style="font-family: Verdana; font-size: 10pt">
                Metode Evaluasi</span></td>
            <td valign=top>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                <input type="text" name="evaluasi" ></span></td>
        </tr>
        <tr>
            <td valign=top><span style="font-family: Verdana; font-size: 10pt">
                Jenis Kontrak</span></td>
            <td valign=top>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt"><input type="text" name="jenis" ></span></td>
        </tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt"><b>A.	PENGUMUNAN</b><br/>Pengumuman e-Lelang Pemilihan Langsung dilaksanakan melalui SPSE pada tanggal <input type="text" name="pengumuman" >.</span></td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt"><b>B.	PENDAFTARAN DAN PENGAMBILAN DOKUMEN PENGADAAN</b><br/>Pendaftaran dan pengambilan dokumen pemilihan dilaksanakan pada SPSE sesuai jadwal yang ditetapkan. Jumlah peserta pelelangan yang mendaftar sebanyak  <input type="text" name="pendaftar" > Penyedia Barang/Jasa sebagaimana yang tercantum dalam aplikasi SPSE.</span></td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt"><b>C.	PENJELASAN DOKUMEN PENGADAAN</b><br/>Penjelasan dokumen pengadaan dilaksanakan pada <input type="text" name="penjelasan" > secara elektronik/online sebagaimana yang tercantum dalam aplikasi SPSE.</span></td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt"><b>D.	PEMASUKAN DAN PEMBUKAAN DOKUMEN PENAWARAN</b><br/>1.	Pengambilan/Download Dokumen Pengadaan dilaksanakan mulai <input type="text" name="d1" size=50>.<br/>2.	Batas akhir pemasukan dan pembukaan dokumen penawaran dilaksanakan pada tanggal <input type="text" name="d2" > sebagaimana yang tercantum dalam aplikasi SPSE.<br/>3.	Penyedia Barang/Jasa yang memasukan Dokumen Penawaran adalah sebanyak <input type="text" name="d3" > Penyedia Barang/Jasa sebagaimana yang tercantum dalam aplikasi SPSE, sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Alamat</td><td align=center width="25%">Harga Penawaran</td></tr>
				<tr><td align=center><input type="text" name="d31a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d31b" ></td><td align=center width="35%"><input type="text" name="d31c" ></td><td align=center width="25%"><input type="text" name="d31d" ></td></tr>
				<tr><td align=center><input type="text" name="d32a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d32b" ></td><td align=center width="35%"><input type="text" name="d32c" ></td><td align=center width="25%"><input type="text" name="d32d" ></td></tr>
				<tr><td align=center><input type="text" name="d33a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d33b" ></td><td align=center width="35%"><input type="text" name="d33c" ></td><td align=center width="25%"><input type="text" name="d33d" ></td></tr>
				<tr><td align=center><input type="text" name="d34a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d34b" ></td><td align=center width="35%"><input type="text" name="d34c" ></td><td align=center width="25%"><input type="text" name="d34d" ></td></tr>
				<tr><td align=center><input type="text" name="d35a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d35b" ></td><td align=center width="35%"><input type="text" name="d35c" ></td><td align=center width="25%"><input type="text" name="d35d" ></td></tr>
				<tr><td align=center><input type="text" name="d36a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d36b" ></td><td align=center width="35%"><input type="text" name="d36c" ></td><td align=center width="25%"><input type="text" name="d36d" ></td></tr>
				<tr><td align=center><input type="text" name="d37a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d37b" ></td><td align=center width="35%"><input type="text" name="d37c" ></td><td align=center width="25%"><input type="text" name="d37d" ></td></tr>
				<tr><td align=center><input type="text" name="d38a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d38b" ></td><td align=center width="35%"><input type="text" name="d38c" ></td><td align=center width="25%"><input type="text" name="d38d" ></td></tr>
				<tr><td align=center><input type="text" name="d39a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d39b" ></td><td align=center width="35%"><input type="text" name="d39c" ></td><td align=center width="25%"><input type="text" name="d39d" ></td></tr>
				<tr><td align=center><input type="text" name="d310a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="d310b" ></td><td align=center width="35%"><input type="text" name="d310c" ></td><td align=center width="25%"><input type="text" name="d310d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt"><b>E.	EVALUASI PENAWARAN</b><br/>1.	KOREKSI ARITMATIK<br/>Koreksi aritmatik dilakukan sebelum dilakukan evaluasi penawaran. Berdasarkan  hasil koreksi aritmatik Pokja ULP menyusun urutan dari penawaran terendah. Setelah dilakukan koreksi maka diperoleh hasil sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Penawaran</td><td align=center width="25%">Harga Terkoreksi</td></tr>
				<tr><td align=center><input type="text" name="e11a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e11b" ></td><td align=center width="35%"><input type="text" name="e11c" ></td><td align=center width="25%"><input type="text" name="e11d" ></td></tr>
				<tr><td align=center><input type="text" name="e12a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e12b" ></td><td align=center width="35%"><input type="text" name="e12c" ></td><td align=center width="25%"><input type="text" name="e12d" ></td></tr>
				<tr><td align=center><input type="text" name="e13a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e13b" ></td><td align=center width="35%"><input type="text" name="e13c" ></td><td align=center width="25%"><input type="text" name="e13d" ></td></tr>
				<tr><td align=center><input type="text" name="e14a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e14b" ></td><td align=center width="35%"><input type="text" name="e14c" ></td><td align=center width="25%"><input type="text" name="e14d" ></td></tr>
				<tr><td align=center><input type="text" name="e15a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e15b" ></td><td align=center width="35%"><input type="text" name="e15c" ></td><td align=center width="25%"><input type="text" name="e15d" ></td></tr>
				<tr><td align=center><input type="text" name="e16a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e16b" ></td><td align=center width="35%"><input type="text" name="e16c" ></td><td align=center width="25%"><input type="text" name="e16d" ></td></tr>
				<tr><td align=center><input type="text" name="e17a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e17b" ></td><td align=center width="35%"><input type="text" name="e17c" ></td><td align=center width="25%"><input type="text" name="e17d" ></td></tr>
				<tr><td align=center><input type="text" name="e18a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e18b" ></td><td align=center width="35%"><input type="text" name="e18c" ></td><td align=center width="25%"><input type="text" name="e18d" ></td></tr>
				<tr><td align=center><input type="text" name="e19a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e19b" ></td><td align=center width="35%"><input type="text" name="e19c" ></td><td align=center width="25%"><input type="text" name="e19d" ></td></tr>
				<tr><td align=center><input type="text" name="e110a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e110b" ></td><td align=center width="35%"><input type="text" name="e110c" ></td><td align=center width="25%"><input type="text" name="e110d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">2.	EVALUASI ADMINISTRASI<br/>a.	Mengadakan penelitian dan penilaian secara seksama terhadap file/data Administrasi sebanyak <input type="text" name="e2a" > file/data Administrasi yang dimulai dari Penyedia dengan nilai penawaran terendah, yang telah dibuka melalui SPSE.<br/>b.	Evaluasi Administrasi dilakukan dengan sistem Gugur berdasarkan  kontrak Gabungan Harga Satuan dan Lumpsum.<br/>c.	Setelah dilakukan evaluasi Administrasi, apabila penawar yang tidak memenuhi persyaratan administrasi sebagaimana ditetapkan dalam  dokumen lelang dan ketentuan peraturan yang berlaku, dinyatakan GUGUR.<br/>d.	Hasil Evaluasi Administrasi adalah sebagai berikut:<br/>1)	Penyedia Barang/Jasa yang tidak memenuhi persyaratan administrasi/GUGUR serta tidak dilanjutkan dengan Evaluasi Teknis sebanyak Nihil penyedia barang/jasa sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center>-</td><td align=center width="35%">-</td><td align=center width="35%">-</td><td align=center width="25%">-</td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">2)	Penyedia Barang/Jasa yang memenuhi persyaratan administrasi dan dilanjutkan dengan Evaluasi Teknis sebanyak <input type="text" name="e2d2" >  penyedia barang/jasa sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center><input type="text" name="e2d21a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d21b" ></td><td align=center width="35%"><input type="text" name="e2d21c" ></td><td align=center width="25%"><input type="text" name="e2d21d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d22a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d22b" ></td><td align=center width="35%"><input type="text" name="e2d22c" ></td><td align=center width="25%"><input type="text" name="e2d22d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d23a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d23b" ></td><td align=center width="35%"><input type="text" name="e2d23c" ></td><td align=center width="25%"><input type="text" name="e2d23d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d24a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d24b" ></td><td align=center width="35%"><input type="text" name="e2d24c" ></td><td align=center width="25%"><input type="text" name="e2d24d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d25a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d25b" ></td><td align=center width="35%"><input type="text" name="e2d25c" ></td><td align=center width="25%"><input type="text" name="e2d25d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d26a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d26b" ></td><td align=center width="35%"><input type="text" name="e2d26c" ></td><td align=center width="25%"><input type="text" name="e2d26d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d27a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d27b" ></td><td align=center width="35%"><input type="text" name="e2d27c" ></td><td align=center width="25%"><input type="text" name="e2d27d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d28a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d28b" ></td><td align=center width="35%"><input type="text" name="e2d28c" ></td><td align=center width="25%"><input type="text" name="e2d28d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d29a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d29b" ></td><td align=center width="35%"><input type="text" name="e2d29c" ></td><td align=center width="25%"><input type="text" name="e2d29d" ></td></tr>
				<tr><td align=center><input type="text" name="e2d210a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e2d210b" ></td><td align=center width="35%"><input type="text" name="e2d210c" ></td><td align=center width="25%"><input type="text" name="e2d210d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">3.	EVALUASI TEKNIS<br/>a.	Mengadakan penelitian dan penilaian secara seksama terhadap dokumen/data Teknis sebanyak <input type="text" name="e3a" > dokumen yang telah memenuhi syarat Administrasi serta dimulai dari nilai penawaran terendah, yang telah dibuka melalui SPSE.<br/>b.	Evaluasi Teknis dilakukan dengan sistem gugur berdasarkan kontrak Gabungan Harga Satuan dan Lumpsum.<br/>c.	Setelah dilakukan evaluasi Teknis, apabila penawar yang tidak memenuhi persyaratan teknis sebagaimana ditetapkan dalam dokumen lelang dan ketentuan peraturan yang berlaku, dinyatakan GUGUR.<br/>d.	Hasil Evaluasi Teknis adalah sebagai berikut:<br/>1)	Penyedia Barang/Jasa yang tidak memenuhi persyaratan teknis dan tidak dilanjutkan dengan Penilaian Harga Penawaran sebanyak <input type="text" name="e3d1" > Penyedia Barang/Jasa sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center><input type="text" name="e3d11a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d11b" ></td><td align=center width="35%"><input type="text" name="e3d11c" ></td><td align=center width="25%"><input type="text" name="e3d11d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d12a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d12b" ></td><td align=center width="35%"><input type="text" name="e3d12c" ></td><td align=center width="25%"><input type="text" name="e3d12d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d13a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d13b" ></td><td align=center width="35%"><input type="text" name="e3d13c" ></td><td align=center width="25%"><input type="text" name="e3d13d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d14a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d14b" ></td><td align=center width="35%"><input type="text" name="e3d14c" ></td><td align=center width="25%"><input type="text" name="e3d14d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d15a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d15b" ></td><td align=center width="35%"><input type="text" name="e3d15c" ></td><td align=center width="25%"><input type="text" name="e3d15d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d16a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d16b" ></td><td align=center width="35%"><input type="text" name="e3d16c" ></td><td align=center width="25%"><input type="text" name="e3d16d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d17a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d17b" ></td><td align=center width="35%"><input type="text" name="e3d17c" ></td><td align=center width="25%"><input type="text" name="e3d17d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d18a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d18b" ></td><td align=center width="35%"><input type="text" name="e3d18c" ></td><td align=center width="25%"><input type="text" name="e3d18d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d19a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d19b" ></td><td align=center width="35%"><input type="text" name="e3d19c" ></td><td align=center width="25%"><input type="text" name="e3d19d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d110a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d110b" ></td><td align=center width="35%"><input type="text" name="e3d110c" ></td><td align=center width="25%"><input type="text" name="e3d110d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">2)	Penyedia Barang/Jasa yang memenuhi persyaratan teknis dan dilanjutkan dengan Penilaian Harga Penawaran sebanyak <input type="text" name="e3d2" > Penyedia Barang/Jasa sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center><input type="text" name="e3d21a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d21b" ></td><td align=center width="35%"><input type="text" name="e3d21c" ></td><td align=center width="25%"><input type="text" name="e3d21d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d22a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d22b" ></td><td align=center width="35%"><input type="text" name="e3d22c" ></td><td align=center width="25%"><input type="text" name="e3d22d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d23a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d23b" ></td><td align=center width="35%"><input type="text" name="e3d23c" ></td><td align=center width="25%"><input type="text" name="e3d23d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d24a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d24b" ></td><td align=center width="35%"><input type="text" name="e3d24c" ></td><td align=center width="25%"><input type="text" name="e3d24d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d25a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d25b" ></td><td align=center width="35%"><input type="text" name="e3d25c" ></td><td align=center width="25%"><input type="text" name="e3d25d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d26a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d26b" ></td><td align=center width="35%"><input type="text" name="e3d26c" ></td><td align=center width="25%"><input type="text" name="e3d26d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d27a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d27b" ></td><td align=center width="35%"><input type="text" name="e3d27c" ></td><td align=center width="25%"><input type="text" name="e3d27d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d28a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d28b" ></td><td align=center width="35%"><input type="text" name="e3d28c" ></td><td align=center width="25%"><input type="text" name="e3d28d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d29a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d29b" ></td><td align=center width="35%"><input type="text" name="e3d29c" ></td><td align=center width="25%"><input type="text" name="e3d29d" ></td></tr>
				<tr><td align=center><input type="text" name="e3d210a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e3d210b" ></td><td align=center width="35%"><input type="text" name="e3d210c" ></td><td align=center width="25%"><input type="text" name="e3d210d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">4.	EVALUASI KEWAJARAN HARGA PENAWARAN<br/>a.	Mengadakan penelitian dan penilaian secara seksama terhadap dokumen/data Harga Penawaran sebanyak <input type="text" name="e4a" > dokumen yang telah memenuhi syarat Teknis serta dimulai dari nilai penawaran terendah, yang telah dibuka melalui SPSE.<br/>b.	Evaluasi Harga Penawaran dilakukan dengan sistem gugur berdasarkan kontrak Gabungan Harga Satuan dan Lumpsum.<br/>c.	Setelah dilakukan evaluasi Harga, apabila penawar yang tidak memenuhi persyaratan Harga Penawaran sebagaimana ditetapkan dalam dokumen lelang dan ketentuan peraturan yang berlaku, dinyatakan GUGUR.<br/>d.	Hasil Evaluasi Harga Penawaran adalah sebagai berikut:<br/>1)	Penyedia Barang/Jasa yang tidak memenuhi persyaratan Harga dan  tidak dilanjutkan dengan Penilaian Harga Penawaran sebanyak  Nihil Penyedia Barang/Jasa sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center>-</td><td align=center width="35%">-</td><td align=center width="35%">-</td><td align=center width="25%">-</td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">2)	Penyedia Barang/Jasa yang memenuhi persyaratan harga dan dilanjutkan dengan Penilaian syarat kualifikasi bagi peserta yang akan ditetapkan sebagai calon pememang dan/atau calon cadangan pemenang sebanyak <input type="text" name="e4d2" >  Penyedia Barang/Jasa sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center><input type="text" name="e4d21a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d21b" ></td><td align=center width="35%"><input type="text" name="e4d21c" ></td><td align=center width="25%"><input type="text" name="e4d21d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d22a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d22b" ></td><td align=center width="35%"><input type="text" name="e4d22c" ></td><td align=center width="25%"><input type="text" name="e4d22d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d23a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d23b" ></td><td align=center width="35%"><input type="text" name="e4d23c" ></td><td align=center width="25%"><input type="text" name="e4d23d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d24a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d24b" ></td><td align=center width="35%"><input type="text" name="e4d24c" ></td><td align=center width="25%"><input type="text" name="e4d24d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d25a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d25b" ></td><td align=center width="35%"><input type="text" name="e4d25c" ></td><td align=center width="25%"><input type="text" name="e4d25d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d26a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d26b" ></td><td align=center width="35%"><input type="text" name="e4d26c" ></td><td align=center width="25%"><input type="text" name="e4d26d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d27a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d27b" ></td><td align=center width="35%"><input type="text" name="e4d27c" ></td><td align=center width="25%"><input type="text" name="e4d27d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d28a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d28b" ></td><td align=center width="35%"><input type="text" name="e4d28c" ></td><td align=center width="25%"><input type="text" name="e4d28d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d29a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d29b" ></td><td align=center width="35%"><input type="text" name="e4d29c" ></td><td align=center width="25%"><input type="text" name="e4d29d" ></td></tr>
				<tr><td align=center><input type="text" name="e4d210a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e4d210b" ></td><td align=center width="35%"><input type="text" name="e4d210c" ></td><td align=center width="25%"><input type="text" name="e4d210d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">5.	EVALUASI PERSYARATAN KUALIFIKASI<br/>a.	Evaluasi persyaratan kualifikasi dilakukan terhadap peserta pemilihan yang ditetapkan sebagai calon pemenang dan/atau calon cadangan pemenang proses pemilihan penyedia barang/jasa sebanyak <input type="text" name="e5a" > penawaran  terbaik yang memenuhi persyaratan administrasi, teknis, dan harga.<br/>b.	Penyedia Barang/Jasa yang ditetapkan sebagai calon pemenang dan/atau calon cadangan pemenang sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center><input type="text" name="e5b1a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b1b" ></td><td align=center width="35%"><input type="text" name="e5b1c" ></td><td align=center width="25%"><input type="text" name="e5b1d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b2a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b2b" ></td><td align=center width="35%"><input type="text" name="e5b2c" ></td><td align=center width="25%"><input type="text" name="e5b2d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b3a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b3b" ></td><td align=center width="35%"><input type="text" name="e5b3c" ></td><td align=center width="25%"><input type="text" name="e5b3d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b4a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b4b" ></td><td align=center width="35%"><input type="text" name="e5b4c" ></td><td align=center width="25%"><input type="text" name="e5b4d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b5a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b5b" ></td><td align=center width="35%"><input type="text" name="e5b5c" ></td><td align=center width="25%"><input type="text" name="e5b5d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b6a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b6b" ></td><td align=center width="35%"><input type="text" name="e5b6c" ></td><td align=center width="25%"><input type="text" name="e5b6d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b7a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b7b" ></td><td align=center width="35%"><input type="text" name="e5b7c" ></td><td align=center width="25%"><input type="text" name="e5b7d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b8a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b8b" ></td><td align=center width="35%"><input type="text" name="e5b8c" ></td><td align=center width="25%"><input type="text" name="e5b8d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b9a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b9b" ></td><td align=center width="35%"><input type="text" name="e5b9c" ></td><td align=center width="25%"><input type="text" name="e5b9d" ></td></tr>
				<tr><td align=center><input type="text" name="e5b10a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="e5b10b" ></td><td align=center width="35%"><input type="text" name="e5b10c" ></td><td align=center width="25%"><input type="text" name="e5b10d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">c.	Mengadakan penilaian terhadap semua data dan informasi yang ada dalam formulir isian Kualifikasi pada aplikasi SPSE sebanyak <input type="text" name="e5c" > file setelah lulus memenuhi persyaratan administrasi, teknis dan harga.<br/>d.	Hasil Evaluasi file kualifikasi pada aplikasi SPSE adalah: semua Penyedia Barang/Jasa sebagaimana dimaksud di atas memenuhi persyaratan kualifikasi sesuai dokumen pengadaan.</span></td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt"><b>F.	PEMBUKTIAN PERSYARATAN KUALIFIKASI</b><br/>1.	Mengadakan penelitian dan penilaian secara seksama terhadap dokumen asli/otentik persyaratan kualifikasi kepada Penyedia Calon Pemenang dan/atau Cadangan Pemenang, yang telah dibuka melalui SPSE.<br/>2.	Pembuktian Kualifikasi dilakukan dengan sistem Gugur berdasarkan kontrak Gabungan Harga Satuan dan Lumpsum.<br/>3.	Setelah dilakukan Pembuktian Kualifikasi, apabila penawar tidak dapat menunjukkan/membuktikan dokumen asli/otentik terhadap persyaratan Kualifikasi sebagaimana data dalam isian kualifikasi secara elektronik pada SPSE, dinyatakan GUGUR.<br/>4.	Terhadap <input type="text" name="f4" > Penyedia Barang/Jasa sebagai Calon Pemenang dan/atau Calon Cadangan Pemenang, dilakukan klarifikasi dan verifikasi nyata (pembuktian kualifikasi) terhadap semua data dan informasi yang ada dalam formulir isian Kualifikasi pada aplikasi SPSE dengan menunjukkan dokumen asli/otentik yang sah serta meminta rekaman/salinannya dan bila diperlukan dilakukan konfirmasi dengan instansi terkait, dengan hasil sebagai berikut:</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="35%">Nama Penyedia Barang/Jasa</td><td align=center width="35%">Harga Terkoreksi</td><td align=center width="25%">Keterangan</td></tr>
				<tr><td align=center><input type="text" name="f41a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f41b" ></td><td align=center width="35%"><input type="text" name="f41c" ></td><td align=center width="25%"><input type="text" name="f41d" ></td></tr>
				<tr><td align=center><input type="text" name="f42a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f42b" ></td><td align=center width="35%"><input type="text" name="f42c" ></td><td align=center width="25%"><input type="text" name="f42d" ></td></tr>
				<tr><td align=center><input type="text" name="f43a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f43b" ></td><td align=center width="35%"><input type="text" name="f43c" ></td><td align=center width="25%"><input type="text" name="f43d" ></td></tr>
				<tr><td align=center><input type="text" name="f44a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f44b" ></td><td align=center width="35%"><input type="text" name="f44c" ></td><td align=center width="25%"><input type="text" name="f44d" ></td></tr>
				<tr><td align=center><input type="text" name="f45a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f45b" ></td><td align=center width="35%"><input type="text" name="f45c" ></td><td align=center width="25%"><input type="text" name="f45d" ></td></tr>
				<tr><td align=center><input type="text" name="f46a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f46b" ></td><td align=center width="35%"><input type="text" name="f46c" ></td><td align=center width="25%"><input type="text" name="f46d" ></td></tr>
				<tr><td align=center><input type="text" name="f47a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f47b" ></td><td align=center width="35%"><input type="text" name="f47c" ></td><td align=center width="25%"><input type="text" name="f47d" ></td></tr>
				<tr><td align=center><input type="text" name="f48a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f48b" ></td><td align=center width="35%"><input type="text" name="f48c" ></td><td align=center width="25%"><input type="text" name="f48d" ></td></tr>
				<tr><td align=center><input type="text" name="f49a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f49b" ></td><td align=center width="35%"><input type="text" name="f49c" ></td><td align=center width="25%"><input type="text" name="f49d" ></td></tr>
				<tr><td align=center><input type="text" name="f410a" size=1 maxlength=2 ></td><td align=center width="35%"><input type="text" name="f410b" ></td><td align=center width="35%"><input type="text" name="f410c" ></td><td align=center width="25%"><input type="text" name="f410d" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt"><b>G.	KESIMPULAN HASIL PEMILIHAN</b><br/>Berdasarkan hasil penilaian/evaluasi Dokumen Penawaran pada setiap tahapan sebagaimana tersebut di atas maka <%=namapokja%> Kota Bogor berkesimpulan dan memutuskan untuk menetapkan  peserta yang memenuhi syarat untuk ditunjuk sebagai pemenang  lelang adalah sebagai berikut :</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>
				<span style="font-family: Verdana; font-size:10pt">
				<table width="90%">
				<tr><td align=center>No.</td><td align=center width="20%">Nama Perusahaan</td><td align=center width="20%">Alamat Perusahaan</td><td align=center width="20%">NPWP</td><td align=center width="20%">Harga Terkoreksi</td><td align=center width="15%">Penetapan</td></tr>
				<tr><td align=center><input type="text" name="ga" size=1 maxlength=2 ></td><td align=center width="20%"><input type="text" name="gb" ></td><td align=center width="20%"><input type="text" name="gc" ></td><td align=center width="20%"><input type="text" name="gd" ></td><td align=center width="20%"><input type="text" name="ge" ></td><td align=center width="15%"><input type="text" name="gf" ></td></tr>
				</table>
				</span>
			</td>
		</tr>
		<tr>
            <td colspan=5 align=left><span style="font-family: Verdana; font-size:10pt">Demikian Berita Acara Hasil Pelelangan (BAHP) ini dibuat dengan sesungguhnya, di tandatangani bersama oleh <%=namapokja%>, untuk dipergunakan sebagaimana mestinya.</span></td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center><span style="font-family: Verdana; font-size:10pt"><b>PEMERINTAH KOTA BOGOR<br/><%=namapokja%></span><hr/></td>
		</tr>
	<%
        ssql = "select distinct nama, kodejabatan from aktor where kodepokja in (select distinct kodepokja from aktor where nip = '" + Request["nip"] + "') and kodejabatan in ('KETUAPJ','NONANGGOTAPJ','POKJAULP') order by kodejabatan";
        myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		string ketua, sekretaris, anggota = "";
		
        while (myReader.Read())
            {
				if (myReader.GetValue(1).ToString() == "KETUAPJ") {
					ketua = myReader.GetValue(0).ToString();
	%>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                <%=ketua%></span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                KETUA/ANGGOTA</span></td>
        </tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
	<%
				}
				if (myReader.GetValue(1).ToString() == "NONANGGOTAPJ") {
					sekretaris = myReader.GetValue(0).ToString();
	%>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                <%=sekretaris%></span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                SEKRETARIS/ANGGOTA</span></td>
        </tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
	<%
				}
				if (myReader.GetValue(1).ToString() == "POKJAULP") {
					anggota = myReader.GetValue(0).ToString();
	%>
        <tr>
            <td><span style="font-family: Verdana; font-size: 10pt">
                <%=anggota%></span></td>
            <td>
                :</td>
            <td colspan="3"><span style="font-family: Verdana; font-size: 10pt">
                ANGGOTA</span></td>
        </tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
	<%
				}
            }
        myReader.Close();
	%>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center>&nbsp;</td>
		</tr>
		<tr>
            <td colspan=5 align=center><hr/></td>
		</tr>
		<tr>
            <td colspan=5 align=center><a href="javascript:saveIt()">Save This Page </a>|<A HREF="javascript:window.print()">Print This Page</A></td>
		</tr>
    </table>
	</center>
</body>
</html>

