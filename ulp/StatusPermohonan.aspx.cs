using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Configuration;
using System.Data.SqlClient;

public partial class StatusPermohonan : System.Web.UI.Page
{
    private NpgsqlDataAdapter NpAdapter;
    private System.Data.DataSet dset = null;
    private System.Data.DataTable dtsource = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(Session["pusername"]  as string)) {
			Response.Redirect("login.aspx?message=expired");
		} else {
			BindGrid();
		}
    }

    private void BindGrid()
    {
        NpgsqlConnection pgConnection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PGConnectionString"].ConnectionString);
        NpgsqlDataReader pgReader = null;
        NpgsqlCommand pgCommand = new NpgsqlCommand();

        string ssql = "select distinct paket.pkt_id, lelang_seleksi.lls_id, pkt_nama, stk_nama, " +
                        "(select peg.peg_nama from anggota_panitia ap inner join pegawai peg on ap.peg_id = peg.peg_id where ap.agp_jabatan = 'K' and ap.pnt_id = paket.pnt_id) as ketua, " +
                        "(select peg.peg_nama from anggota_panitia ap inner join pegawai peg on ap.peg_id = peg.peg_id where ap.agp_jabatan = 'S' and ap.pnt_id = paket.pnt_id) as sekretaris, " +
                        "(select peg.peg_nama from anggota_panitia ap inner join pegawai peg on ap.peg_id = peg.peg_id where ap.agp_jabatan = 'A' and ap.pnt_id = paket.pnt_id limit 1 offset 0) as anggota1, " +
                        "(select peg.peg_nama from anggota_panitia ap inner join pegawai peg on ap.peg_id = peg.peg_id where ap.agp_jabatan = 'A' and ap.pnt_id = paket.pnt_id limit 1 offset 1) as anggota2, " +
                        "(select peg.peg_nama from anggota_panitia ap inner join pegawai peg on ap.peg_id = peg.peg_id where ap.agp_jabatan = 'A' and ap.pnt_id = paket.pnt_id limit 1 offset 2) as anggota3, " +
                        "pnt_no_sk, pnt_nama, " +
                        "to_char(jadwal.dtj_tglawal,'DD-MM-YYYY HH12:MI:SS') as dtj_tglawal, to_char(j.dtj_tglakhir,'DD-MM-YYYY HH12:MI:SS') dtj_tglakhir, pkt_pagu, " +
                        "(case kgr_id " +
                            "when 0 then 'Pengadaan Barang' " +
                            "when 1 then 'Jasa Konsultansi' " +
                            "when 2 then 'Pekerjaan Konstruksi' " +
                            "else 'Jasa Lainnya' " +
                        "end) as kgr_nama, " +
                        "pkt_hps, lls_diulang_karena, p.peg_nama as ppk, " +
                        "( " +
                        "select distinct rkn_nama " +
                        "from peserta " +
                        "left join rekanan on peserta.rkn_id = rekanan.rkn_id " +
                        "left join nilai_evaluasi on nilai_evaluasi.psr_id = peserta.psr_id " +
                        "left join evaluasi on nilai_evaluasi.eva_id = evaluasi.eva_id " +
                        "where is_pemenang=1 and eva_jenis = 3 and peserta.lls_id = lelang_seleksi.lls_id and peserta.auditupdate in " +
                        "( " +
                        "select p.auditupdate from peserta p where p.lls_id = lelang_seleksi.lls_id order by p.auditupdate desc limit 1 " +
                        ") " +
                        "and evaluasi.eva_versi in " +
                        "( " +
                        "select e.eva_versi from evaluasi e where e.lls_id = lelang_seleksi.lls_id order by e.eva_versi desc limit 1 " +
                        ") " +
                        ") as pemenang, " +
                        "( " +
                        "select distinct nev_harga_terkoreksi " +
                        "from peserta " +
                        "left join rekanan on peserta.rkn_id = rekanan.rkn_id " +
                        "left join nilai_evaluasi on nilai_evaluasi.psr_id = peserta.psr_id " +
                        "left join evaluasi on nilai_evaluasi.eva_id = evaluasi.eva_id " +
                        "where is_pemenang=1 and eva_jenis = 3 and peserta.lls_id = lelang_seleksi.lls_id and peserta.auditupdate in " +
                        "( " +
                        "select p.auditupdate from peserta p where p.lls_id = lelang_seleksi.lls_id order by p.auditupdate desc limit 1 " +
                        ") " +
                        "and evaluasi.eva_versi in " +
                        "( " +
                        "select e.eva_versi from evaluasi e where e.lls_id = lelang_seleksi.lls_id order by e.eva_versi desc limit 1 " +
                        ") " +
                        ") as nilai_kontrak, " +
                        "( " +
                        "select distinct s.sppbj_no from sppbj s where s.lls_id = lelang_seleksi.lls_id " +
                        ") as no_sppbj, " +
                        "( " +
                        "select distinct k.kontrak_no from kontrak k where k.lls_id = lelang_seleksi.lls_id " +
                        ") as no_kontrak, " +
                        "( " +
                        "select distinct to_char(k2.kontrak_mulai,'DD-MM-YYYY HH12:MI:SS') from kontrak k2 where k2.lls_id = lelang_seleksi.lls_id " +
                        ") as tglawal_kontrak, " +
                        "( " +
                        "select distinct to_char(k3.kontrak_akhir, 'DD-MM-YYYY HH12:MI:SS') from kontrak k3 where k3.lls_id = lelang_seleksi.lls_id " +
                        ") as tglakhir_kontrak " +
                        "from paket " +
                        "inner join satuan_kerja on paket.stk_id = satuan_kerja.stk_id " +
                        "inner join panitia on paket.pnt_id = panitia.pnt_id " +
                        "inner join anggota_panitia on paket.pnt_id = anggota_panitia.pnt_id " +
                        "inner join pegawai on anggota_panitia.peg_id = pegawai.peg_id  " +
                        "inner join ppk on paket.ppk_id = ppk.ppk_id " +
                        "inner join pegawai as p on ppk.peg_id = p.peg_id " +
                        "inner join lelang_seleksi on paket.pkt_id = lelang_seleksi.pkt_id and lelang_seleksi.lls_versi_lelang in (select lls_versi_lelang from lelang_seleksi as ls where ls.pkt_id=paket.pkt_id order by lls_versi_lelang desc limit 1) " +
                        "inner join jadwal on jadwal.lls_id = lelang_seleksi.lls_id and jadwal.thp_id in (18807,18808) " +
                        "inner join jadwal as j on j.lls_id = lelang_seleksi.lls_id and j.thp_id in (18803) " +
                        "where EXTRACT(YEAR FROM pkt_tgl_buat) = EXTRACT(YEAR FROM now()) and panitia.audituser in  ('SARIAGENCY', 'ANIKAGENCY') and jadwal.dtj_tglawal is not null and jadwal.dtj_tglakhir is not null and  lls_status = 1  " +
                        "order by dtj_tglawal";

        try
        {
            pgConnection.Open();

			// fill grid part
            dset = new DataSet("npdata");
            NpAdapter = new NpgsqlDataAdapter();
            NpAdapter.SelectCommand = new NpgsqlCommand(ssql, pgConnection);
            NpAdapter.Fill(dset, "npdata");
            dtsource = dset.Tables["npdata"];

            gridStatus.DataSource = dtsource;
            gridStatus.DataBind();

			// modify local db
            pgCommand.Connection = pgConnection;
            pgCommand.CommandType = CommandType.Text;
            pgCommand.CommandText = ssql;

            pgReader = pgCommand.ExecuteReader();

            while (pgReader.Read())
            {
				SetKontrakPemenang(pgReader["pemenang"].ToString(), pgReader["nilai_kontrak"].ToString(), pgReader["lls_id"].ToString());
            }

            pgConnection.Close();
            pgCommand.Dispose();
            pgReader = null;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void SetKontrakPemenang(string pemenang, string kontrak, string kodepbj)
    {
		if (string.IsNullOrEmpty(pemenang)) { 
		} else {
			SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
			int result = 0;

			string ssql = " update PBJ set PEMENANG = '" + pemenang + "', KONTRAK ='" + kontrak + "', KODESTATUSPBJ = 'BAHP' where KODELELANGSPSE = '" + kodepbj + "' and KODESTATUSPBJ not in ('BAHP','SELESAI')";
			
			//Response.Write(ssql);
			//Response.End();

			SqlCommand myCommand = new SqlCommand();
			myCommand.CommandText = ssql;
			myCommand.CommandType = CommandType.Text;
			myCommand.Connection = myConnection;
			myConnection.Open();

			result = myCommand.ExecuteNonQuery();

			myConnection.Close();
		}
    }
	
}