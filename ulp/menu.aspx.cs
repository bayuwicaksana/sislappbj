#region " using "
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Smarty;
using System.Configuration;
using System.Data.SqlClient;
using Npgsql;

#endregion

public partial class CMenu : AspNetRunnerPage
{
    private NpgsqlDataAdapter NpAdapter;
    private System.Data.DataSet dset = null;
    private System.Data.DataTable dtsource = null;

    private SqlDataAdapter SqlAdapter;
    private System.Data.DataSet dset2 = null;
    private System.Data.DataTable dtsource2 = null;

    string _cbMessage = "";
    string type = string.Empty;

    public void RaiseCallbackEvent(String eventArgument)
    {
        try
        {
            Page.ClientScript.ValidateEvent("actionList", "actionList");
            _cbMessage = "Correct event raised callback.";
        }
        catch (Exception ex)
        {
            _cbMessage = "Incorrect event raised callback.";
        }
    }

    void Page_Load( object sender,  System.EventArgs e) 
    {
        CheckSecurity();
           
        //show appropriate menu based on user group
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select distinct kodekelompok from pengguna where KODEPENGGUNA = '" + UserName + "';";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

        while (myReader.Read())
        {
            type = myReader.GetValue(0).ToString();

            if (type == "DLP")
            {
                menu.InnerHtml = adminMenu();
            }
            else if (type == "SEKRETARIAT")
            {
                menu.InnerHtml = ulpMenu();
            }
			else if (type == "ANGGOTA")
			{
                menu.InnerHtml = anggotaMenu();
			}
			else if (type == "SKPD")
			{
                menu.InnerHtml = skpdMenu();
			}
            else
            {
                menu.InnerHtml = otherMenu();
            }
        }

        myReader.Close();

        if (!IsPostBack)
        {
            ClientScriptManager cs = Page.ClientScript;
            String cbReference = cs.GetCallbackEventReference("'" +
                Page.UniqueID + "'", "arg", "ReceiveServerData", "",
                "ProcessCallBackError", false);
            String callbackScript = "function CallTheServer(arg, context) {" +
                cbReference + "; }";
            cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer",
                callbackScript, true);

            GridLokalLoad(type);

            LPSELoad(type);
			
			LPSESync();
        }

    }

    private void LPSELoad(string type)
    {
        NpgsqlConnection pgConnection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PGConnectionString"].ConnectionString);
        string ssql = string.Empty;
		string hardCodeHandler = string.Empty;

        if (type == "ANGGOTA")
        {
			if (UserName == "197005231997031003") {
                hardCodeHandler = "and ltrim(rtrim(replace(replace(peg_nip, ' ', ''),'	',''))) like '%19700523199703100%' ";
			} else if (UserName == "197505272006041015") {
                hardCodeHandler = "and ltrim(rtrim(replace(replace(peg_nip, ' ', ''),'	',''))) like '%19750527200604101%' ";
			} else if (UserName == "197904192008011003") {
                hardCodeHandler = "and ltrim(rtrim(replace(replace(peg_nip, ' ', ''),'	',''))) like '%19790419200801100%' ";
			} else if (UserName == "198210032009122002") {
                hardCodeHandler = "and ltrim(rtrim(replace(replace(peg_nip, ' ', ''),'	',''))) like '%198210032009022002%' ";
			} else {
                hardCodeHandler = "and ltrim(rtrim(replace(replace(peg_nip, ' ', ''),'	',''))) like '%" + UserName + "%' ";
			}

			ssql = "select distinct paket.pkt_nama Paket, tahap.thp_nama Tahapan, jadwal.dtj_tglawal Awal, jadwal.dtj_tglakhir Akhir " +
                                //"peg_nama Nama, ltrim(rtrim(replace(peg_nip, ' ', ''))) NIP " +
                            "from jadwal  " +
                                "inner join tahap on tahap.thp_id = jadwal.thp_id  " +
                                "inner join lelang_seleksi on lelang_seleksi.lls_id = jadwal.lls_id and lelang_seleksi.lls_status = 1  " +
                                "inner join paket on paket.pkt_id = lelang_seleksi.pkt_id and paket.pkt_status = 1  " +
                                "inner join paket_panitia on paket.pkt_id = paket_panitia.pkt_id  " +
                                "inner join anggota_panitia on anggota_panitia.pnt_id = paket_panitia.pnt_id  " +
                                "inner join pegawai on pegawai.peg_id = anggota_panitia.peg_id " +
                            "where 1=1 " +
                                "and date_part('day', jadwal.dtj_tglakhir) = date_part('day', now()) AND date_part('month', jadwal.dtj_tglakhir) = date_part('month', now()) AND date_part('year', jadwal.dtj_tglakhir) = date_part('year', now()) " +
                                "and jadwal.lls_id = lelang_seleksi.lls_id " + hardCodeHandler + 
                            "order by jadwal.dtj_tglawal, jadwal.dtj_tglakhir";
                            //jadwal.lls_id, 

        }
        else
        {
            ssql = "select distinct paket.pkt_nama Paket, tahap.thp_nama Tahapan, jadwal.dtj_tglawal Awal, jadwal.dtj_tglakhir Akhir " +
                                //"peg_nama Nama, ltrim(rtrim(replace(peg_nip, ' ', ''))) NIP " +
                            "from jadwal  " +
                                "inner join tahap on tahap.thp_id = jadwal.thp_id  " +
                                "inner join lelang_seleksi on lelang_seleksi.lls_id = jadwal.lls_id and lelang_seleksi.lls_status = 1  " +
                                "inner join paket on paket.pkt_id = lelang_seleksi.pkt_id and paket.pkt_status = 1  " +
                                "inner join paket_panitia on paket.pkt_id = paket_panitia.pkt_id  " +
                                "inner join anggota_panitia on anggota_panitia.pnt_id = paket_panitia.pnt_id  " +
                                "inner join pegawai on pegawai.peg_id = anggota_panitia.peg_id " +
                            "where 1=1 " +
                                "and date_part('day', jadwal.dtj_tglakhir) = date_part('day', now()) AND date_part('month', jadwal.dtj_tglakhir) = date_part('month', now()) AND date_part('year', jadwal.dtj_tglakhir) = date_part('year', now()) " +
                                "and jadwal.lls_id = lelang_seleksi.lls_id " +
                                //"and ltrim(rtrim(replace(replace(peg_nip, ' ', ''),'	',''))) like '%" + UserName + "%' " +
                            "order by jadwal.dtj_tglawal, jadwal.dtj_tglakhir";
                            //jadwal.lls_id,   
        }

        //NpgsqlCommand myCommand = new NpgsqlCommand();

        //myCommand.CommandText = ssql;
        //myCommand.CommandType = CommandType.Text;
        //myCommand.Connection = pgConnection;

        try
        {

            pgConnection.Open();

            //NpgsqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            /*
            while (myReader.Read())
            {

            }
            */

            dset = new DataSet("npdata");
            NpAdapter = new NpgsqlDataAdapter();
            NpAdapter.SelectCommand = new NpgsqlCommand(ssql, pgConnection);
            NpAdapter.Fill(dset, "npdata");
            dtsource = dset.Tables["npdata"];

            gridJadwal.DataSource = dtsource;
            gridJadwal.DataBind();
            //gridJadwal.SetDataBinding(dset, "npdata");

            //myReader.Close();

            lpseStatusLabel.Text = "Tersambung";
            pgParameterLabel.Text = ConfigurationManager.ConnectionStrings["PGConnectionString"].ConnectionString.Substring(0, 20);

        }
        catch (Exception ex)
        {
            lpseStatusLabel.Text = "Terputus" + " (Pesan Kesalahan: " + ex.Message + ")";
            pgParameterLabel.Text = ConfigurationManager.ConnectionStrings["PGConnectionString"].ConnectionString;
        }
    }
	
	private void LPSESync()
    {
        NpgsqlConnection pgConnection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PGConnectionString"].ConnectionString);
        NpgsqlDataReader pgReader = null;
        NpgsqlCommand pgCommand = new NpgsqlCommand();

        string ssql = string.Empty;

        
            ssql = "select distinct lelang_seleksi.lls_id, tahap.thp_nama Tahapan " +
					" from jadwal " +
					" inner join tahap on tahap.thp_id = jadwal.thp_id  " +
					" inner join lelang_seleksi on lelang_seleksi.lls_id = jadwal.lls_id and lelang_seleksi.lls_status = 1 " +
					" where 1=1 " +
					" and date_part('day', jadwal.dtj_tglakhir) = date_part('day', now()) AND date_part('month', jadwal.dtj_tglakhir) = date_part('month', now()) AND date_part('year', jadwal.dtj_tglakhir) = date_part('year', now()) " +
					" and jadwal.lls_id = lelang_seleksi.lls_id " +
					" and tahap.thp_nama = 'Penandatanganan  kontrak'";

        try
        {
            pgConnection.Open();

            pgCommand.Connection = pgConnection;
            pgCommand.CommandType = CommandType.Text;
            pgCommand.CommandText = ssql;

            pgReader = pgCommand.ExecuteReader();

            while (pgReader.Read())
            {
                SetStatus(pgReader["lls_id"].ToString(), "BAHP"); 
            }

            pgConnection.Close();
            pgCommand.Dispose();
            pgReader = null;

        }
        catch (Exception ex)
        {
            lpseStatusLabel.Text = "Terputus" + " (Pesan Kesalahan: " + ex.Message + ")";
            pgParameterLabel.Text = ConfigurationManager.ConnectionStrings["PGConnectionString"].ConnectionString;
        }
    }

    private int IsExistKodeLelang(string kode)
    {
        NpgsqlConnection pgConnection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PGConnectionString"].ConnectionString);
        NpgsqlDataReader pgReader = null;
        NpgsqlCommand pgCommand = new NpgsqlCommand();

        string ssql = string.Empty;

        int result = 0;

        ssql = "select distinct lelang_seleksi.lls_id, tahap.thp_nama Tahapan " +
                " from jadwal " +
                " inner join tahap on tahap.thp_id = jadwal.thp_id  " +
                " inner join lelang_seleksi on lelang_seleksi.lls_id = jadwal.lls_id and lelang_seleksi.lls_status = 1 " +
                " where 1=1 " +
                " and lelang_seleksi.lls_id = '" + kode + "'";

        try
        {
            pgConnection.Open();

            pgCommand.Connection = pgConnection;
            pgCommand.CommandType = CommandType.Text;
            pgCommand.CommandText = ssql;

            pgReader = pgCommand.ExecuteReader();

            while (pgReader.Read())
            {
                result = 1;
            }

            pgConnection.Close();
            pgCommand.Dispose();
            pgReader = null;

            return result;

        }
        catch (Exception ex)
        {
            result = 9;

            return result;
        }
    }


    private void GridLokalLoad(string type)
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = string.Empty;

        if (type == "ANGGOTA")
        {
            ssql = "select distinct pbj.KodePbj, pbj.NAMAKEGIATAN [Kegiatan], " +
                        "pbj.NAMAPAKET [Tahapan], " +
                        "pbj.KODEJENISKEGIATAN [Jenis Kegiatan], " +
                        "pbj.TANGGALPENGAJUAN [Tanggal Pengajuan], " +
                        "c.Nama [PPK], " +
                        "d.Nama [PPTK], " +
                        "p.NAMA POKJA, " +
                        "a.NOSURATTUGAS [Surat Tugas], " +
                        "pbjStatus.DESKRIPSI [Status] " +
                    "from PBJ pbj " +
                        "inner join STATUSPBJ pbjStatus on pbj.KODESTATUSPBJ = pbjStatus.KODESTATUS " +
                        "inner join ASSIGNMENT a on a.KODEPBJ = pbj.KODEPBJ " +
						"inner join AKTOR b on a.NIP = b.NIP " +
						"inner join AKTOR c on pbj.PPK = c.NIP " +
						"inner join AKTOR d on pbj.PPTK = d.NIP " +
                        "inner join POKJA p on p.KODEPOKJA = a.KODEPOKJA " +
                    "where pbj.KODESTATUSPBJ IN ('PENGAJUAN','DITERIMA','KOORDINASI','PENERBITAN') AND a.NIP = '" + UserName + "' and year(tanggalpengajuan)=year(getdate()) " +
                        "order by pbj.TANGGALPENGAJUAN";
        }
        else
        {
            ssql = "select distinct pbj.KodePbj, pbj.NAMAKEGIATAN [Kegiatan], " +
                        "pbj.NAMAPAKET [Tahapan], " +
                        "pbj.KODEJENISKEGIATAN [Jenis Kegiatan], " +
                        "pbj.TANGGALPENGAJUAN [Tanggal Pengajuan], " +
                        "c.Nama [PPK], " +
                        "d.Nama [PPTK], " +
                        "p.NAMA POKJA, " +
                        "a.NOSURATTUGAS [Surat Tugas], " +
                        "pbjStatus.DESKRIPSI [Status] " +
                    "from PBJ pbj " +
                        "inner join STATUSPBJ pbjStatus on pbj.KODESTATUSPBJ = pbjStatus.KODESTATUS " +
                        "inner join ASSIGNMENT a on a.KODEPBJ = pbj.KODEPBJ " +
						"inner join AKTOR b on a.NIP = b.NIP " +
						"inner join AKTOR c on pbj.PPK = c.NIP " +
						"inner join AKTOR d on pbj.PPTK = d.NIP " +
                        "inner join POKJA p on p.KODEPOKJA = a.KODEPOKJA " +
                    //"where a.NIP = '" + Session["pusername"] + "' " +
					"where pbj.KODESTATUSPBJ IN ('PENGAJUAN','DITERIMA','KOORDINASI','PENERBITAN') and year(tanggalpengajuan)=year(getdate()) " +
                        "order by pbj.TANGGALPENGAJUAN";
        }

        try
        {

            sqlConnection.Open();

            dset2 = new DataSet("npdata2");
            SqlAdapter = new SqlDataAdapter();
            SqlAdapter.SelectCommand = new SqlCommand(ssql, sqlConnection);
            SqlAdapter.Fill(dset2, "npdata2");
            dtsource2 = dset2.Tables["npdata2"];

            gridJadwalLokal.DataSource = dtsource2;
            gridJadwalLokal.DataBind();

        }
        catch (Exception ex)
        {
        }
    }

    protected void gridJadwalLokal_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        DropDownList actionList = e.Row.FindControl("actionList") as DropDownList;
		ImageButton goImage = e.Row.FindControl("goImage") as ImageButton;

        if (actionList != null)
        {
            ListItemCollection items = actionList.Items;

            items.Add(new ListItem("", ""));
			
            if (type == "ANGGOTA")
            {
                items.Add(new ListItem("Kembali ke SKPD", "DIKEMBALIKAN"));
                //items.Add(new ListItem("Surat Tugas", "SURATTUGAS"));
                items.Add(new ListItem("Proses Lelang", "PROSES"));
				items.Add(new ListItem("Koordinasi SKPD", "KOORDINASI"));
                //items.Add(new ListItem("BA Pelelangan", "BAHP"));
				items.Add(new ListItem("Dibatalkan Oleh SKPD", "BATAL"));
            }
			else
			{
				actionList.Visible = false;
				goImage.Visible = false;
			}
        }
    }

    protected void gridJadwalLokal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "action")
        {

            GridViewRow row = gridJadwalLokal.Rows[Convert.ToInt32(e.CommandArgument)];
            DropDownList actionList = row.FindControl("actionList") as DropDownList;
            HiddenField hKodePbj = row.FindControl("hKodePbj") as HiddenField;
            TextBox txtKodeLelang = row.FindControl("txtKodeLelang") as TextBox;

            if (actionList != null)
            {
                string actionId = actionList.SelectedValue;
                
                if (!string.IsNullOrEmpty(actionId))
                {
                    if (actionId == "PROSES")
                    {
                        if (txtKodeLelang.Text == "#Lelang" || string.IsNullOrEmpty(txtKodeLelang.Text))
                        { 
                            LabelInfo.Text = "Silahkan masukkan nomor lelang yang terdaftar di SPSE.";
                        }
                        else
                        {
                            int exist = IsExistKodeLelang(txtKodeLelang.Text);

                            if (exist ==  1)
                                SetStatus(hKodePbj.Value, actionId, txtKodeLelang.Text);
                            else if (exist == 0) 
                                LabelInfo.Text = "Nomor lelang " + txtKodeLelang.Text + " tidak terdaftar di SPSE.";  
                            else
                                LabelInfo.Text = "Tidak dapat mengakses data SPSE.";
                        }
                    }
                    else
                    {
                        SetStatus(hKodePbj.Value, actionId, txtKodeLelang.Text);
                    }
                }
            }

            //gridJadwalLokal.DataBind();
            GridLokalLoad(type);
        }
    }

    protected void SetStatus(string kodeBpj, string statusId, string kodeLelang)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int result = 0;

		kodeLelang = (kodeLelang == "#Lelang" ? "" : kodeLelang);
		
        string ssql = string.Format("update PBJ set KODESTATUSPBJ = '{0}', KODELELANGSPSE = '{1}' where KODEPBJ = '{2}' and KODESTATUSPBJ not in ('BAHP','SELESAI')", statusId, kodeLelang, kodeBpj);

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();

        result = myCommand.ExecuteNonQuery();

        myConnection.Close();

    }

    protected void SetStatus(string kodeBpj, string statusId)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int result = 0;

        string ssql = string.Format("update PBJ set KODESTATUSPBJ = '{0}' where KODELELANGSPSE = '{1}' and KODESTATUSPBJ not in ('BAHP','SELESAI')", statusId, kodeBpj);

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();

        result = myCommand.ExecuteNonQuery();

        myConnection.Close();

    }

	protected string otherMenu()
    {
        string strHTML;
        strHTML = "";

    strHTML = strHTML + "<ul>";
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>";
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'>Perekaman Lelang PBJ</a></li>";
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField='>Perekaman Pengadaan Langsung</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Penugasan</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='surat_tugas.aspx?usrgrp=UMUM'>Penugasan Anggota ULP</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Akhiri Proses</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='surat_hasil_lelang.aspx?usrgrp=UMUM'>Cetak penyampaian hasil pelelangan</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Reporting</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='RptRekapPermohonan.aspx?usrgrp=UMUM'>Rekap permohonan lelang</a></li>";
        strHTML = strHTML + "<li><a href='reporting.aspx?usrgrp=UMUM'>Daftar permohonan lelang dr SKPD</a></li>";
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=UMUM'>Daftar pengadaan langsung di SKPD</a></li>";
        strHTML = strHTML + "<li><a href='StatusPermohonan.aspx?usrgrp=UMUM'>Status tender yg aktif</a></li>";
        strHTML = strHTML + "<li><a href='StatusPengajuan.aspx?usrgrp=UMUM'>Status permohonan tender</a></li>";
		strHTML = strHTML + "<li><a href='rptsurat_tugas.aspx?usrgrp=UMUM'>Daftar Surat Tugas</a></li>";
		strHTML = strHTML + "<li><a href='RptRekapAssignment.aspx?usrgrp=UMUM'>Jumlah paket yang sudah/sedang dilaksanakan</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "</ul>";

		return strHTML;
    }
	
	protected string ulpMenu()
    {
        string strHTML;
        strHTML = "";

    strHTML = strHTML + "<ul>";
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>";
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'>Perekaman Lelang PBJ</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Penugasan</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='surat_tugas.aspx?usrgrp=SEKRETARIAT'>Penugasan Anggota ULP</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Akhiri Proses</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='surat_hasil_lelang.aspx?usrgrp=SEKRETARIAT'>Cetak penyampaian hasil pelelangan</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Reporting</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='RptRekapPermohonan.aspx?usrgrp=SEKRETARIAT'>Rekap permohonan lelang</a></li>";
        strHTML = strHTML + "<li><a href='reporting.aspx?usrgrp=SEKRETARIAT'>Daftar permohonan lelang dr SKPD</a></li>";
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=SEKRETARIAT'>Daftar pengadaan langsung di SKPD</a></li>";
        strHTML = strHTML + "<li><a href='StatusPermohonan.aspx?usrgrp=SEKRETARIAT'>Status tender yg aktif</a></li>";
        strHTML = strHTML + "<li><a href='StatusPengajuan.aspx?usrgrp=SEKRETARIAT'>Status permohonan tender</a></li>";
		strHTML = strHTML + "<li><a href='rptsurat_tugas.aspx?usrgrp=SEKRETARIAT'>Daftar Surat Tugas</a></li>";
		strHTML = strHTML + "<li><a href='RptRekapAssignment.aspx?usrgrp=SEKRETARIAT'>Jumlah paket yang sudah/sedang dilaksanakan</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "</ul>";

		return strHTML;
    }
	
	protected string adminMenu()
    {
        string strHTML;
        strHTML = "";

    strHTML = strHTML + "<ul>";
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>";
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'>Perekaman Lelang PBJ</a></li>";
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField='>Perekaman Pengadaan Langsung</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Penugasan</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='surat_tugas.aspx?usrgrp=DLP'>Penugasan Anggota ULP</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Akhiri Proses</a>";
		strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='surat_hasil_lelang.aspx?usrgrp=DLP'>Cetak penyampaian hasil pelelangan</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Reporting</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='RptRekapPermohonan.aspx?usrgrp=DLP'>Rekap permohonan lelang</a></li>";
        strHTML = strHTML + "<li><a href='reporting.aspx?usrgrp=DLP'>Daftar permohonan lelang dr SKPD</a></li>";
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=DLP'>Daftar pengadaan langsung di SKPD</a></li>";
        strHTML = strHTML + "<li><a href='StatusPermohonan.aspx?usrgrp=DLP'>Status tender yg aktif</a></li>";
        strHTML = strHTML + "<li><a href='StatusPengajuan.aspx?usrgrp=DLP'>Status permohonan tender</a></li>";
		strHTML = strHTML + "<li><a href='rptsurat_tugas.aspx?usrgrp=DLP'>Daftar Surat Tugas</a></li>";
		strHTML = strHTML + "<li><a href='RptRekapStatus.aspx?usrgrp=DLP'>Rekap Pengajuan Per Status</a>";
		strHTML = strHTML + "<li><a href='RptRekapAssignment.aspx?usrgrp=DLP'>Jumlah paket yang sudah/sedang dilaksanakan</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Admin</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='PENGGUNA_list.aspx'>Pengguna</a></li>";
		strHTML = strHTML + "<li><a href='KELOMPOKPENGGUNA_list.aspx'>Kelompok Pengguna</a></li>";
        strHTML = strHTML + "<li><a href='AKTOR_list.aspx'>Aktor</a></li>";
		strHTML = strHTML + "<li><a href='TIPEAKTOR_list.aspx'>Tipe Aktor</a></li>";
		strHTML = strHTML + "<li><a href='JABATANAKTOR_list.aspx'>Jabatan Aktor</a></li>";
        strHTML = strHTML + "<li><a href='KELENGKAPAN_list.aspx'>Kelengkapan</a></li>";
		strHTML = strHTML + "<li><a href='DOKUMEN_list.aspx'>Dokumen</a></li>";
		strHTML = strHTML + "<li><a href='JENISKEGIATAN_list.aspx'>Jenis Kegiatan</a></li>";
		strHTML = strHTML + "<li><a href='SKPD_list.aspx'>SKPD</a></li>";
		strHTML = strHTML + "<li><a href='STATUSPBJ_list.aspx'>Status</a></li>";
		strHTML = strHTML + "<li><a href='POKJA_list.aspx'>POKJA</a></li>";
		strHTML = strHTML + "<li><a href='Tb_Vendor_list.aspx'>VENDOR</a></li>";
      strHTML = strHTML + "</ul>";   
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "</ul>";

		return strHTML;
    }
	
	protected string anggotaMenu()
    {
        string strHTML;
        strHTML = "";

    strHTML = strHTML + "<ul>";
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>";
	strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx?a=search&value=1&SearchFor="+ UserName + "&SearchOption=Equals&SearchField=PEJABATPENGADAAN'>Perekaman Pengadaan Langsung</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Berita Acara</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='BAEP.aspx?nip="+ UserName + "' target='_new'>Cetak BAEP</a></li>";
        strHTML = strHTML + "<li><a href='BAHP.aspx?nip="+ UserName + "' target='_new'>Cetak BAHP</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "</ul>";

		return strHTML;
    }
	
	protected string skpdMenu()
    {
        string strHTML;
        strHTML = "";

    strHTML = strHTML + "<ul>";
    strHTML = strHTML + "<li><a href='menu.aspx'>Home</a></li>";
    strHTML = strHTML + "<li><a href='#'>Pengadaan Barang/Jasa</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='PENGADAAN_LANGSUNG_list.aspx?a=search&value=1&SearchFor="+ UserName + "&SearchOption=Equals&SearchField=PEJABATPENGADAAN'>Perekaman Pengadaan Langsung</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "<li><a href='#'>Reporting</a>";
      strHTML = strHTML + "<ul>";
        strHTML = strHTML + "<li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=SKPD'>Daftar pengadaan langsung di SKPD</a></li>";
      strHTML = strHTML + "</ul>";
    strHTML = strHTML + "</li>";
    strHTML = strHTML + "</ul>";

		return strHTML;
    }
	
    private bool CheckSecurity()
    {
        if(string.IsNullOrEmpty(UserName))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
	        return false;
        }
        
        return true;
    }
}
