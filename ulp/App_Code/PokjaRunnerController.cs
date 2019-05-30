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
    public partial class POKJAController
    {


		
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(
                                        String 
                            KODEPOKJA
                            , 
                            String 
                            NAMA
                            , 
                            String 
                            DESKRIPSSI
            )
	    {		
			POKJA item = new POKJA();
			
			item.KODEPOKJA = KODEPOKJA;
			item.NAMA = NAMA;
			item.DESKRIPSSI = DESKRIPSSI;
		    item.Save("");
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update( String  KODEPOKJA,  String  NAMA,  String  DESKRIPSSI)
		{
			POKJA item = new POKJA();
			
			item.KODEPOKJA = KODEPOKJA;
			item.NAMA = NAMA;
			item.DESKRIPSSI = DESKRIPSSI;
		    item.MarkOld();
		    item.Save("");		
	    }
    }

}
