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
    public partial class PENGADAAN_LANGSUNGController
    {


		
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(
                                        String 
                            NAMAKEGIATAN
                            , 
                            String 
                            NAMAPAKET
                            , 
                            String 
                            KODESKPD
                            , 
                            DateTime 
                            TANGGALKONTRAK
                            , 
                            Decimal 
                            PAGU
                            , 
                            Decimal 
                            HPS
                            , 
                            Decimal 
                            NILAIKONTRAK
                            , 
                            String 
                            PEMENANG
                            , 
                            String 
                            KETERANGAN
                            , 
                            String 
                            PEJABATPENGADAAN
                            , 
                            String 
                            MENGETAHUI
            )
	    {		
			PENGADAAN_LANGSUNG item = new PENGADAAN_LANGSUNG();
			
			item.NAMAKEGIATAN = NAMAKEGIATAN;
			item.NAMAPAKET = NAMAPAKET;
			item.KODESKPD = KODESKPD;
			item.TANGGALKONTRAK = TANGGALKONTRAK;
			item.PAGU = PAGU;
			item.HPS = HPS;
			item.NILAIKONTRAK = NILAIKONTRAK;
			item.PEMENANG = PEMENANG;
			item.KETERANGAN = KETERANGAN;
			item.PEJABATPENGADAAN = PEJABATPENGADAAN;
			item.MENGETAHUI = MENGETAHUI;
		    item.Save("");
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update( String  KODEPENGADAANLANGSUNG,  String  NAMAKEGIATAN,  String  NAMAPAKET,  String  KODESKPD,  DateTime  TANGGALKONTRAK,  Decimal  PAGU,  Decimal  HPS,  Decimal  NILAIKONTRAK,  String  PEMENANG,  String  KETERANGAN,  String  PEJABATPENGADAAN,  String  MENGETAHUI)
		{
			PENGADAAN_LANGSUNG item = new PENGADAAN_LANGSUNG();
			
			item.KODEPENGADAANLANGSUNG = KODEPENGADAANLANGSUNG;
			item.NAMAKEGIATAN = NAMAKEGIATAN;
			item.NAMAPAKET = NAMAPAKET;
			item.KODESKPD = KODESKPD;
			item.TANGGALKONTRAK = TANGGALKONTRAK;
			item.PAGU = PAGU;
			item.HPS = HPS;
			item.NILAIKONTRAK = NILAIKONTRAK;
			item.PEMENANG = PEMENANG;
			item.KETERANGAN = KETERANGAN;
			item.PEJABATPENGADAAN = PEJABATPENGADAAN;
			item.MENGETAHUI = MENGETAHUI;
		    item.MarkOld();
		    item.Save("");		
	    }
    }

}
