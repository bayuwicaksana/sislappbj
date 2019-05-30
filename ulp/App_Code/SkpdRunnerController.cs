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
    public partial class SKPDController
    {


		
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(
                                        String 
                            KODESKPD
                            , 
                            String 
                            DESKRIPSI
                            , 
                            String 
                            ALAMAT
            )
	    {		
			SKPD item = new SKPD();
			
			item.KODESKPD = KODESKPD;
			item.DESKRIPSI = DESKRIPSI;
			item.ALAMAT = ALAMAT;
		    item.Save("");
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update( String  KODESKPD,  String  DESKRIPSI,  String  ALAMAT)
		{
			SKPD item = new SKPD();
			
			item.KODESKPD = KODESKPD;
			item.DESKRIPSI = DESKRIPSI;
			item.ALAMAT = ALAMAT;
		    item.MarkOld();
		    item.Save("");		
	    }
    }

}
