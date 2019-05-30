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
using System.Web;
using System.Threading;

namespace Data
{
	/// <summary>
	/// Strongly-typed collection for the KELENGKAPAN class.
	/// </summary>
	[Serializable]
	public partial class KELENGKAPANCollection : ActiveList<KELENGKAPAN, KELENGKAPANCollection> 
	{	   
		public KELENGKAPANCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the KELENGKAPAN table.
	/// </summary>
	[Serializable]
	public partial class KELENGKAPAN : ActiveRecord<KELENGKAPAN>
	{
		#region .ctors and Default Settings
		
		public KELENGKAPAN()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public KELENGKAPAN(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public KELENGKAPAN(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public KELENGKAPAN(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}

		
		protected static void SetSQLProps() { GetTableSchema(); }

		
		#endregion
		
		#region Schema and Query Accessor
		public static Query CreateQuery() { return new Query(Schema); }

		
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}

		}

		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("KELENGKAPAN", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEKELENGKAPAN = new TableSchema.TableColumn(schema);
				colvarKODEKELENGKAPAN.ColumnName = "KODEKELENGKAPAN";
				colvarKODEKELENGKAPAN.DataType = DbType.String;
				colvarKODEKELENGKAPAN.MaxLength = 10;
				colvarKODEKELENGKAPAN.AutoIncrement = false;
				colvarKODEKELENGKAPAN.IsNullable = false;
				colvarKODEKELENGKAPAN.IsPrimaryKey = true;
				colvarKODEKELENGKAPAN.IsForeignKey = false;
				colvarKODEKELENGKAPAN.IsReadOnly = false;
				colvarKODEKELENGKAPAN.DefaultSetting = @"";
				colvarKODEKELENGKAPAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEKELENGKAPAN);
				
				TableSchema.TableColumn colvarKODEDOKUMEN = new TableSchema.TableColumn(schema);
				colvarKODEDOKUMEN.ColumnName = "KODEDOKUMEN";
				colvarKODEDOKUMEN.DataType = DbType.String;
				colvarKODEDOKUMEN.MaxLength = 10;
				colvarKODEDOKUMEN.AutoIncrement = false;
				colvarKODEDOKUMEN.IsNullable = true;
				colvarKODEDOKUMEN.IsPrimaryKey = false;
				colvarKODEDOKUMEN.IsForeignKey = true;
				colvarKODEDOKUMEN.IsReadOnly = false;
				colvarKODEDOKUMEN.DefaultSetting = @"";
				
					colvarKODEDOKUMEN.ForeignKeyTableName = "DOKUMEN";
				schema.Columns.Add(colvarKODEDOKUMEN);
				
				TableSchema.TableColumn colvarKODEJENISKEGIATAN = new TableSchema.TableColumn(schema);
				colvarKODEJENISKEGIATAN.ColumnName = "KODEJENISKEGIATAN";
				colvarKODEJENISKEGIATAN.DataType = DbType.String;
				colvarKODEJENISKEGIATAN.MaxLength = 10;
				colvarKODEJENISKEGIATAN.AutoIncrement = false;
				colvarKODEJENISKEGIATAN.IsNullable = true;
				colvarKODEJENISKEGIATAN.IsPrimaryKey = false;
				colvarKODEJENISKEGIATAN.IsForeignKey = true;
				colvarKODEJENISKEGIATAN.IsReadOnly = false;
				colvarKODEJENISKEGIATAN.DefaultSetting = @"";
				
					colvarKODEJENISKEGIATAN.ForeignKeyTableName = "JENISKEGIATAN";
				schema.Columns.Add(colvarKODEJENISKEGIATAN);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("KELENGKAPAN",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEKELENGKAPAN")]
		public string KODEKELENGKAPAN 
		{
			get { return GetColumnValue<string>("KODEKELENGKAPAN"); }

			set { SetColumnValue("KODEKELENGKAPAN", value); }

		}

		  
		[XmlAttribute("KODEDOKUMEN")]
		public string KODEDOKUMEN 
		{
			get { return GetColumnValue<string>("KODEDOKUMEN"); }

			set { SetColumnValue("KODEDOKUMEN", value); }

		}

		  
		[XmlAttribute("KODEJENISKEGIATAN")]
		public string KODEJENISKEGIATAN 
		{
			get { return GetColumnValue<string>("KODEJENISKEGIATAN"); }

			set { SetColumnValue("KODEJENISKEGIATAN", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.KELENGKAPANPBJCollection KELENGKAPANPBJRecords()
		{
			return new Data.KELENGKAPANPBJCollection().Where(KELENGKAPANPBJ.Columns.KODEKELENGKAPAN, KODEKELENGKAPAN).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a DOKUMEN ActiveRecord object related to this KELENGKAPAN
		/// 
		/// </summary>
		public Data.DOKUMEN DOKUMEN
		{
			get { return Data.DOKUMEN.FetchByID(this.KODEDOKUMEN); }

			set { SetColumnValue("KODEDOKUMEN", value.KODEDOKUMEN); }

		}

		
		
		/// <summary>
		/// Returns a JENISKEGIATAN ActiveRecord object related to this KELENGKAPAN
		/// 
		/// </summary>
		public Data.JENISKEGIATAN JENISKEGIATAN
		{
			get { return Data.JENISKEGIATAN.FetchByID(this.KODEJENISKEGIATAN); }

			set { SetColumnValue("KODEJENISKEGIATAN", value.KODEJENISKEGIATAN); }

		}

		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public Data.PBJCollection GetPBJCollection() { return KELENGKAPAN.GetPBJCollection(this.KODEKELENGKAPAN); }

		public static Data.PBJCollection GetPBJCollection(string varKODEKELENGKAPAN)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM PBJ INNER JOIN KELENGKAPANPBJ ON "+
				"PBJ.KODEPBJ=KELENGKAPANPBJ.KODEBPJ WHERE KELENGKAPANPBJ.KODEKELENGKAPAN=@KODEKELENGKAPAN", KELENGKAPAN.Schema.Provider.Name);
			
			cmd.AddParameter("@KODEKELENGKAPAN", varKODEKELENGKAPAN, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			PBJCollection coll = new PBJCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SavePBJMap(string varKODEKELENGKAPAN, PBJCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEKELENGKAPAN=@KODEKELENGKAPAN", KELENGKAPAN.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEKELENGKAPAN", varKODEKELENGKAPAN);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (PBJ item in items)
			{
				KELENGKAPANPBJ varKELENGKAPANPBJ = new KELENGKAPANPBJ();
				varKELENGKAPANPBJ.SetColumnValue("KODEKELENGKAPAN", varKODEKELENGKAPAN);
				varKELENGKAPANPBJ.SetColumnValue("KODEBPJ", item.GetPrimaryKeyValue());
				varKELENGKAPANPBJ.Save();
			}

		}

		public static void SavePBJMap(string varKODEKELENGKAPAN, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEKELENGKAPAN=@KODEKELENGKAPAN", KELENGKAPAN.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEKELENGKAPAN", varKODEKELENGKAPAN);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					KELENGKAPANPBJ varKELENGKAPANPBJ = new KELENGKAPANPBJ();
					varKELENGKAPANPBJ.SetColumnValue("KODEKELENGKAPAN", varKODEKELENGKAPAN);
					varKELENGKAPANPBJ.SetColumnValue("KODEBPJ", l.Value);
					varKELENGKAPANPBJ.Save();
				}

			}

		}

		public static void SavePBJMap(string varKODEKELENGKAPAN , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEKELENGKAPAN=@KODEKELENGKAPAN", KELENGKAPAN.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEKELENGKAPAN", varKODEKELENGKAPAN);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				KELENGKAPANPBJ varKELENGKAPANPBJ = new KELENGKAPANPBJ();
				varKELENGKAPANPBJ.SetColumnValue("KODEKELENGKAPAN", varKODEKELENGKAPAN);
				varKELENGKAPANPBJ.SetColumnValue("KODEBPJ", item);
				varKELENGKAPANPBJ.Save();
			}

		}

		
		public static void DeletePBJMap(string varKODEKELENGKAPAN) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEKELENGKAPAN=@KODEKELENGKAPAN", KELENGKAPAN.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEKELENGKAPAN", varKODEKELENGKAPAN);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEKELENGKAPAN,string varKODEDOKUMEN,string varKODEJENISKEGIATAN)
		{
			KELENGKAPAN item = new KELENGKAPAN();
			
			item.KODEKELENGKAPAN = varKODEKELENGKAPAN;
			
			item.KODEDOKUMEN = varKODEDOKUMEN;
			
			item.KODEJENISKEGIATAN = varKODEJENISKEGIATAN;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEKELENGKAPAN,string varKODEDOKUMEN,string varKODEJENISKEGIATAN)
		{
			KELENGKAPAN item = new KELENGKAPAN();
			
				item.KODEKELENGKAPAN = varKODEKELENGKAPAN;
				
				item.KODEDOKUMEN = varKODEDOKUMEN;
				
				item.KODEJENISKEGIATAN = varKODEJENISKEGIATAN;
				
			item.IsNew = false;
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
		#region Columns Struct
		public struct Columns
		{
			int i;
			 public static string KODEKELENGKAPAN = @"KODEKELENGKAPAN";
			 public static string KODEDOKUMEN = @"KODEDOKUMEN";
			 public static string KODEJENISKEGIATAN = @"KODEJENISKEGIATAN";
						
		}

		#endregion
	}

}

