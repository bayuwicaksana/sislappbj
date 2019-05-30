Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public Partial Class _Default
	Inherits System.Web.UI.MasterPage
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If Request.QueryString("usrgrp") = "DLP" Then
                menu.InnerHtml = "" & adminMenu()
            End If
            If Request.QueryString("usrgrp") = "SEKRETARIAT" Then
                menu.InnerHtml = "" & ulpMenu()
            End If
            If Request.QueryString("usrgrp") = "ANGGOTA" Then
                menu.InnerHtml = "" & otherMenu()
            End If
            If Request.QueryString("usrgrp") = "SKPD" Then
                menu.InnerHtml = "" & skpdMenu()
            End If
            If Request.QueryString("usrgrp") = "UMUM" Then
                menu.InnerHtml = "" & sekretarisMenu()
            End If
	End Sub

    Function adminMenu() As String
        Dim strHtml As String = ""

    strHTML = strHTML + "<ul>"
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>"
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'>Perekaman Lelang PBJ</a></li>"
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx'>Perekaman Pengadaan Langsung</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Penugasan</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='surat_tugas.aspx?usrgrp=DLP'>Penugasan Anggota ULP</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Akhiri Proses</a>"
		strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='surat_hasil_lelang.aspx?usrgrp=DLP'>Cetak penyampaian hasil pelelangan</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Reporting</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='RptRekapPermohonan.aspx?usrgrp=DLP'>Rekap permohonan lelang</a></li>"
        strHTML = strHTML + "<li><a href='reporting.aspx?usrgrp=DLP'>Daftar permohonan lelang dr SKPD</a></li>"
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=DLP'>Daftar pengadaan langsung di SKPD</a></li>"
        strHTML = strHTML + "<li><a href='StatusPermohonan.aspx?usrgrp=DLP'>Status tender yg aktif</a></li>"
        strHTML = strHTML + "<li><a href='StatusPengajuan.aspx?usrgrp=DLP'>Status permohonan tender</a></li>"
		strHTML = strHTML + "<li><a href='rptsurat_tugas.aspx?usrgrp=DLP'>Daftar Surat Tugas</a></li>"
		strHTML = strHTML + "<li><a href='RptRekapStatus.aspx?usrgrp=DLP'>Rekap Pengajuan Per Status</a></li>"
		strHTML = strHTML + "<li><a href='RptRekapAssignment.aspx?usrgrp=DLP'>Jumlah paket yang sudah/sedang dilaksanakan</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Admin</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='PENGGUNA_list.aspx'>Pengguna</a></li>"
		strHTML = strHTML + "<li><a href='KELOMPOKPENGGUNA_list.aspx'>Kelompok Pengguna</a></li>"
        strHTML = strHTML + "<li><a href='AKTOR_list.aspx'>Aktor</a></li>"
		strHTML = strHTML + "<li><a href='TIPEAKTOR_list.aspx'>Tipe Aktor</a></li>"
		strHTML = strHTML + "<li><a href='JABATANAKTOR_list.aspx'>Jabatan Aktor</a></li>"
        strHTML = strHTML + "<li><a href='KELENGKAPAN_list.aspx'>Kelengkapan</a></li>"
		strHTML = strHTML + "<li><a href='DOKUMEN_list.aspx'>Dokumen</a></li>"
		strHTML = strHTML + "<li><a href='JENISKEGIATAN_list.aspx'>Jenis Kegiatan</a></li>"
		strHTML = strHTML + "<li><a href='SKPD_list.aspx'>SKPD</a></li>"
		strHTML = strHTML + "<li><a href='STATUSPBJ_list.aspx'>Status</a></li>"
		strHTML = strHTML + "<li><a href='POKJA_list.aspx'>POKJA</a></li>"
		strHTML = strHTML + "<li><a href='Tb_Vendor_list.aspx'>VENDOR</a></li>"
      strHTML = strHTML + "</ul>"   
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "</ul>"

        Return strHTML

    End Function

    Function ulpMenu() As String
        Dim strHtml As String = ""

    strHTML = strHTML + "<ul>"
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>"
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'>Perekaman Lelang PBJ</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Penugasan</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='surat_tugas.aspx?usrgrp=DLP'>Penugasan Anggota ULP</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Reporting</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='RptRekapPermohonan.aspx?usrgrp=SEKRETARIAT'>Rekap permohonan lelang</a></li>"
        strHTML = strHTML + "<li><a href='reporting.aspx?usrgrp=SEKRETARIAT'>Daftar permohonan lelang dr SKPD</a></li>"
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=SEKRETARIAT'>Daftar pengadaan langsung di SKPD</a></li>"
        strHTML = strHTML + "<li><a href='StatusPermohonan.aspx?usrgrp=SEKRETARIAT'>Status tender yg aktif</a></li>"
        strHTML = strHTML + "<li><a href='StatusPengajuan.aspx?usrgrp=SEKRETARIAT'>Status permohonan tender</a></li>"
		strHTML = strHTML + "<li><a href='rptsurat_tugas.aspx?usrgrp=SEKRETARIAT'>Daftar Surat Tugas</a></li>"
		strHTML = strHTML + "<li><a href='RptRekapAssignment.aspx?usrgrp=UMUM'>Jumlah paket yang sudah/sedang dilaksanakan</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "</ul>"

        Return strHTML

    End Function

    Function otherMenu() As String
        Dim strHtml As String = ""

    strHTML = strHTML + "<ul>"
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>"
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx?a=search&value=1&SearchFor="+ Session("pusername") + "&SearchOption=Equals&SearchField=PEJABATPENGADAAN'>Perekaman Pengadaan Langsung</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
     strHTML = strHTML + "<li><a href='#'>Berita Acara</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='BAEP.aspx?nip="+ Session("pusername") + "' target='_new'>Cetak BAEP</a></li>"
        strHTML = strHTML + "<li><a href='BAHP.aspx?nip="+ Session("pusername") + "' target='_new'>Cetak BAHP</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "</ul>"

        Return strHTML

    End Function

    Function skpdMenu() As String
        Dim strHtml As String = ""

    strHTML = strHTML + "<ul>"
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>"
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx?a=search&value=1&SearchFor="+ Session("pusername") + "&SearchOption=Equals&SearchField=PEJABATPENGADAAN'>Perekaman Pengadaan Langsung</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Reporting</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=SKPD'>Daftar pengadaan langsung di SKPD</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "</ul>"

        Return strHTML

    End Function

    Function sekretarisMenu() As String
        Dim strHtml As String = ""

    strHTML = strHTML + "<ul>"
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>"
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'>Perekaman Lelang PBJ</a></li>"
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx'>Perekaman Pengadaan Langsung</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Penugasan</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='surat_tugas.aspx?usrgrp=UMUM'>Penugasan Anggota ULP</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Akhiri Proses</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='surat_hasil_lelang.aspx?usrgrp=UMUM'>Cetak penyampaian hasil pelelangan</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "<li><a href='#'>Reporting</a>"
      strHTML = strHTML + "<ul>"
        strHTML = strHTML + "<li><a href='RptRekapPermohonan.aspx?usrgrp=UMUM'>Rekap permohonan lelang</a></li>"
        strHTML = strHTML + "<li><a href='reporting.aspx?usrgrp=UMUM'>Daftar permohonan lelang dr SKPD</a></li>"
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=UMUM'>Daftar pengadaan langsung di SKPD</a></li>"
        strHTML = strHTML + "<li><a href='StatusPermohonan.aspx?usrgrp=UMUM'>Status tender yg aktif</a></li>"
        strHTML = strHTML + "<li><a href='StatusPengajuan.aspx?usrgrp=UMUM'>Status permohonan tender</a></li>"
		strHTML = strHTML + "<li><a href='rptsurat_tugas.aspx?usrgrp=UMUM'>Daftar Surat Tugas</a></li>"
		strHTML = strHTML + "<li><a href='RptRekapAssignment.aspx?usrgrp=UMUM'>Jumlah paket yang sudah/sedang dilaksanakan</a></li>"
      strHTML = strHTML + "</ul>"
    strHTML = strHTML + "</li>"
    strHTML = strHTML + "</ul>"

        Return strHTML

    End Function
End Class
