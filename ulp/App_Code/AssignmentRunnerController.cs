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
    public partial class ASSIGNMENTController
    {
		public ASSIGNMENTController()
		{
            foreach (TableSchema.TableColumn col in ASSIGNMENT.Schema.Columns)
            {
                col.IsPrimaryKey = false;
            }
            ASSIGNMENT.Schema.Columns.GetColumn("NIP").IsPrimaryKey = true;
            ASSIGNMENT.Schema.Columns.GetColumn("KODEPBJ").IsPrimaryKey = true;
		}
		
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete( String Nip,  String Kodepbj)
        {
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("NIP",Nip).AND("KODEPBJ",Kodepbj);
            qry.Execute();
            return (true);
        }        

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchReaderByID( String  Nip,  String  Kodepbj)		
        {
            Query qry = new Query(ASSIGNMENT.Schema);    
            qry.QueryType = QueryType.Select;
            qry.AddWhere("NIP",Nip).AND("KODEPBJ",Kodepbj);
     
            return qry.ExecuteReader();		
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENT FetchForDelete( String  Nip,  String  Kodepbj)		
        {
            Query qry = new Query(ASSIGNMENT.Schema);    
            qry.QueryType = QueryType.Select;
            qry.AddWhere("NIP",Nip).AND("KODEPBJ",Kodepbj);
     
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
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
                            NOSURATTUGAS
                            , 
                            String 
                            NIP
                            , 
                            String 
                            KODEPBJ
            )
	    {		
			ASSIGNMENT item = new ASSIGNMENT();
			
			item.NOSURATTUGAS = NOSURATTUGAS;
			item.NIP = NIP;
			item.KODEPBJ = KODEPBJ;
		    item.Save("");
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update( String  NOSURATTUGAS,  String  NIP,  String  KODEPBJ)
		{
			ASSIGNMENT item = new ASSIGNMENT();
			
			item.NOSURATTUGAS = NOSURATTUGAS;
			item.NIP = NIP;
			item.KODEPBJ = KODEPBJ;
		    item.MarkOld();
		    item.Save("");		
	    }
    }

}
