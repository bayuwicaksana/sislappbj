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
    public partial class KELENGKAPANPBJController
    {

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchReaderByID( String  Kodebpj,  String  Kodekelengkapan)		
        {
            Query qry = new Query(KELENGKAPANPBJ.Schema);    
            qry.QueryType = QueryType.Select;
            qry.AddWhere("KODEBPJ",Kodebpj).AND("KODEKELENGKAPAN",Kodekelengkapan);
     
            return qry.ExecuteReader();		
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public KELENGKAPANPBJ FetchForDelete( String  Kodebpj,  String  Kodekelengkapan)		
        {
            Query qry = new Query(KELENGKAPANPBJ.Schema);    
            qry.QueryType = QueryType.Select;
            qry.AddWhere("KODEBPJ",Kodebpj).AND("KODEKELENGKAPAN",Kodekelengkapan);
     
            KELENGKAPANPBJCollection items = new KELENGKAPANPBJCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            if(items != null && items.Count > 0)
            {
                return items[0];
            }	

            return null;	
        }
		
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(
                                        String 
                            KODEBPJ
                            , 
                            String 
                            KODEKELENGKAPAN
                            , 
                            DateTime 
                            TANGGALDITERIMA
                            , 
                            String 
                            PENERIMAKELENGKAPAN
            )
	    {		
			KELENGKAPANPBJ item = new KELENGKAPANPBJ();
			
			item.KODEBPJ = KODEBPJ;
			item.KODEKELENGKAPAN = KODEKELENGKAPAN;
			item.TANGGALDITERIMA = TANGGALDITERIMA;
			item.PENERIMAKELENGKAPAN = PENERIMAKELENGKAPAN;
		    item.Save("");
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update( String  KODEBPJ,  String  KODEKELENGKAPAN,  DateTime  TANGGALDITERIMA,  String  PENERIMAKELENGKAPAN)
		{
			KELENGKAPANPBJ item = new KELENGKAPANPBJ();
			
			item.KODEBPJ = KODEBPJ;
			item.KODEKELENGKAPAN = KODEKELENGKAPAN;
			item.TANGGALDITERIMA = TANGGALDITERIMA;
			item.PENERIMAKELENGKAPAN = PENERIMAKELENGKAPAN;
		    item.MarkOld();
		    item.Save("");		
	    }
    }

}
