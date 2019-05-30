using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace Data
{
    /// <summary>
    /// Controller class for Orders
    /// </summary>
    public partial class PBJController
    {


		
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(
                                        String 
                            KODEPBJ
                            , 
                            String 
                            NAMAKEGIATAN
                            , 
                            String 
                            NAMAPAKET
                            , 
                            String 
                            KODESKPD
                            , 
                            String 
                            PPK
                            , 
                            String 
                            PPTK
                            , 
                            String 
                            KODEJENISKEGIATAN
                            , 
                            String 
                            PROSESPENGADAAN
                            , 
                            DateTime 
                            TANGGALPENGAJUAN
                            , 
                            String 
                            PEMBAWABERKAS1
                            , 
                            String 
                            PENERIMABERKAS1
                            , 
                            String 
                            PEMBAWABERKAS2
                            , 
                            String 
                            PENERIMABERKAS2
                            , 
                            String 
                            LENGKAP
                            , 
                            String 
                            DIKEMBALIKAN
                            , 
                            DateTime 
                            TANGGALKEMBALI
                            , 
                            String 
                            KODESTATUSPBJ
                            , 
                            String 
                            CATATAN
            )
	    {		
			PBJ item = new PBJ();
			
			item.KODEPBJ = KODEPBJ;
			item.NAMAKEGIATAN = NAMAKEGIATAN;
			item.NAMAPAKET = NAMAPAKET;
			item.KODESKPD = KODESKPD;
			item.PPK = PPK;
			item.PPTK = PPTK;
			item.KODEJENISKEGIATAN = KODEJENISKEGIATAN;
			item.PROSESPENGADAAN = PROSESPENGADAAN;
			item.TANGGALPENGAJUAN = TANGGALPENGAJUAN;
			item.PEMBAWABERKAS1 = PEMBAWABERKAS1;
			item.PENERIMABERKAS1 = PENERIMABERKAS1;
			item.PEMBAWABERKAS2 = PEMBAWABERKAS2;
			item.PENERIMABERKAS2 = PENERIMABERKAS2;
			item.LENGKAP = LENGKAP;
			item.DIKEMBALIKAN = DIKEMBALIKAN;
			item.TANGGALKEMBALI = TANGGALKEMBALI;
			item.KODESTATUSPBJ = KODESTATUSPBJ;
			item.CATATAN = CATATAN;
		    item.Save("");
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update( String  KODEPBJ,  String  NAMAKEGIATAN,  String  NAMAPAKET,  String  KODESKPD,  String  PPK,  String  PPTK,  String  KODEJENISKEGIATAN,  String  PROSESPENGADAAN,  DateTime  TANGGALPENGAJUAN,  String  PEMBAWABERKAS1,  String  PENERIMABERKAS1,  String  PEMBAWABERKAS2,  String  PENERIMABERKAS2,  String  LENGKAP,  String  DIKEMBALIKAN,  DateTime  TANGGALKEMBALI,  String  KODESTATUSPBJ,  String  CATATAN)
		{
			PBJ item = new PBJ();
			
			item.KODEPBJ = KODEPBJ;
			item.NAMAKEGIATAN = NAMAKEGIATAN;
			item.NAMAPAKET = NAMAPAKET;
			item.KODESKPD = KODESKPD;
			item.PPK = PPK;
			item.PPTK = PPTK;
			item.KODEJENISKEGIATAN = KODEJENISKEGIATAN;
			item.PROSESPENGADAAN = PROSESPENGADAAN;
			item.TANGGALPENGAJUAN = TANGGALPENGAJUAN;
			item.PEMBAWABERKAS1 = PEMBAWABERKAS1;
			item.PENERIMABERKAS1 = PENERIMABERKAS1;
			item.PEMBAWABERKAS2 = PEMBAWABERKAS2;
			item.PENERIMABERKAS2 = PENERIMABERKAS2;
			item.LENGKAP = LENGKAP;
			item.DIKEMBALIKAN = DIKEMBALIKAN;
			item.TANGGALKEMBALI = TANGGALKEMBALI;
			item.KODESTATUSPBJ = KODESTATUSPBJ;
			item.CATATAN = CATATAN;
		    item.MarkOld();
		    item.Save("");		
	    }
    }

}
