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
	/// Strongly-typed collection for the PENGGUNA class.
	/// </summary>
	[Serializable]
	public partial class PENGGUNACollection : ActiveList<PENGGUNA, PENGGUNACollection> 
	{	   
		public PENGGUNACollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the PENGGUNA table.
	/// </summary>
	[Serializable]
	public partial class PENGGUNA : ActiveRecord<PENGGUNA>
	{
		#region .ctors and Default Settings
		
		public PENGGUNA()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public PENGGUNA(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public PENGGUNA(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public PENGGUNA(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PENGGUNA", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEPENGGUNA = new TableSchema.TableColumn(schema);
				colvarKODEPENGGUNA.ColumnName = "KODEPENGGUNA";
				colvarKODEPENGGUNA.DataType = DbType.String;
				colvarKODEPENGGUNA.MaxLength = 50;
				colvarKODEPENGGUNA.AutoIncrement = false;
				colvarKODEPENGGUNA.IsNullable = false;
				colvarKODEPENGGUNA.IsPrimaryKey = true;
				colvarKODEPENGGUNA.IsForeignKey = false;
				colvarKODEPENGGUNA.IsReadOnly = false;
				colvarKODEPENGGUNA.DefaultSetting = @"";
				colvarKODEPENGGUNA.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEPENGGUNA);
				
				TableSchema.TableColumn colvarNAMA = new TableSchema.TableColumn(schema);
				colvarNAMA.ColumnName = "NAMA";
				colvarNAMA.DataType = DbType.String;
				colvarNAMA.MaxLength = 100;
				colvarNAMA.AutoIncrement = false;
				colvarNAMA.IsNullable = true;
				colvarNAMA.IsPrimaryKey = false;
				colvarNAMA.IsForeignKey = false;
				colvarNAMA.IsReadOnly = false;
				colvarNAMA.DefaultSetting = @"";
				colvarNAMA.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNAMA);
				
				TableSchema.TableColumn colvarKATAKUNCI = new TableSchema.TableColumn(schema);
				colvarKATAKUNCI.ColumnName = "KATAKUNCI";
				colvarKATAKUNCI.DataType = DbType.String;
				colvarKATAKUNCI.MaxLength = 20;
				colvarKATAKUNCI.AutoIncrement = false;
				colvarKATAKUNCI.IsNullable = true;
				colvarKATAKUNCI.IsPrimaryKey = false;
				colvarKATAKUNCI.IsForeignKey = false;
				colvarKATAKUNCI.IsReadOnly = false;
				colvarKATAKUNCI.DefaultSetting = @"";
				colvarKATAKUNCI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKATAKUNCI);
				
				TableSchema.TableColumn colvarAKTIF = new TableSchema.TableColumn(schema);
				colvarAKTIF.ColumnName = "AKTIF";
				colvarAKTIF.DataType = DbType.Boolean;
				colvarAKTIF.MaxLength = 0;
				colvarAKTIF.AutoIncrement = false;
				colvarAKTIF.IsNullable = true;
				colvarAKTIF.IsPrimaryKey = false;
				colvarAKTIF.IsForeignKey = false;
				colvarAKTIF.IsReadOnly = false;
				colvarAKTIF.DefaultSetting = @"";
				colvarAKTIF.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAKTIF);
				
				TableSchema.TableColumn colvarLOGINTERAKHIR = new TableSchema.TableColumn(schema);
				colvarLOGINTERAKHIR.ColumnName = "LOGINTERAKHIR";
				colvarLOGINTERAKHIR.DataType = DbType.DateTime;
				colvarLOGINTERAKHIR.MaxLength = 0;
				colvarLOGINTERAKHIR.AutoIncrement = false;
				colvarLOGINTERAKHIR.IsNullable = true;
				colvarLOGINTERAKHIR.IsPrimaryKey = false;
				colvarLOGINTERAKHIR.IsForeignKey = false;
				colvarLOGINTERAKHIR.IsReadOnly = false;
				colvarLOGINTERAKHIR.DefaultSetting = @"";
				colvarLOGINTERAKHIR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLOGINTERAKHIR);
				
				TableSchema.TableColumn colvarKODEKELOMPOK = new TableSchema.TableColumn(schema);
				colvarKODEKELOMPOK.ColumnName = "KODEKELOMPOK";
				colvarKODEKELOMPOK.DataType = DbType.String;
				colvarKODEKELOMPOK.MaxLength = 20;
				colvarKODEKELOMPOK.AutoIncrement = false;
				colvarKODEKELOMPOK.IsNullable = true;
				colvarKODEKELOMPOK.IsPrimaryKey = false;
				colvarKODEKELOMPOK.IsForeignKey = true;
				colvarKODEKELOMPOK.IsReadOnly = false;
				colvarKODEKELOMPOK.DefaultSetting = @"";
				
					colvarKODEKELOMPOK.ForeignKeyTableName = "KELOMPOKPENGGUNA";
				schema.Columns.Add(colvarKODEKELOMPOK);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("PENGGUNA",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEPENGGUNA")]
		public string KODEPENGGUNA 
		{
			get { return GetColumnValue<string>("KODEPENGGUNA"); }

			set { SetColumnValue("KODEPENGGUNA", value); }

		}

		  
		[XmlAttribute("NAMA")]
		public string NAMA 
		{
			get { return GetColumnValue<string>("NAMA"); }

			set { SetColumnValue("NAMA", value); }

		}

		  
		[XmlAttribute("KATAKUNCI")]
		public string KATAKUNCI 
		{
			get { return GetColumnValue<string>("KATAKUNCI"); }

			set { SetColumnValue("KATAKUNCI", value); }

		}

		  
		[XmlAttribute("AKTIF")]
		public bool? AKTIF 
		{
			get { return GetColumnValue<bool?>("AKTIF"); }

			set { SetColumnValue("AKTIF", value); }

		}

		  
		[XmlAttribute("LOGINTERAKHIR")]
		public DateTime? LOGINTERAKHIR 
		{
			get { return GetColumnValue<DateTime?>("LOGINTERAKHIR"); }

			set { SetColumnValue("LOGINTERAKHIR", value); }

		}

		  
		[XmlAttribute("KODEKELOMPOK")]
		public string KODEKELOMPOK 
		{
			get { return GetColumnValue<string>("KODEKELOMPOK"); }

			set { SetColumnValue("KODEKELOMPOK", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a KELOMPOKPENGGUNA ActiveRecord object related to this PENGGUNA
		/// 
		/// </summary>
		public Data.KELOMPOKPENGGUNA KELOMPOKPENGGUNA
		{
			get { return Data.KELOMPOKPENGGUNA.FetchByID(this.KODEKELOMPOK); }

			set { SetColumnValue("KODEKELOMPOK", value.KODEKELOMPOK); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEPENGGUNA,string varNAMA,string varKATAKUNCI,bool? varAKTIF,DateTime? varLOGINTERAKHIR,string varKODEKELOMPOK)
		{
			PENGGUNA item = new PENGGUNA();
			
			item.KODEPENGGUNA = varKODEPENGGUNA;
			
			item.NAMA = varNAMA;
			
			item.KATAKUNCI = varKATAKUNCI;
			
			item.AKTIF = varAKTIF;
			
			item.LOGINTERAKHIR = varLOGINTERAKHIR;
			
			item.KODEKELOMPOK = varKODEKELOMPOK;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEPENGGUNA,string varNAMA,string varKATAKUNCI,bool? varAKTIF,DateTime? varLOGINTERAKHIR,string varKODEKELOMPOK)
		{
			PENGGUNA item = new PENGGUNA();
			
				item.KODEPENGGUNA = varKODEPENGGUNA;
				
				item.NAMA = varNAMA;
				
				item.KATAKUNCI = varKATAKUNCI;
				
				item.AKTIF = varAKTIF;
				
				item.LOGINTERAKHIR = varLOGINTERAKHIR;
				
				item.KODEKELOMPOK = varKODEKELOMPOK;
				
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
			 public static string KODEPENGGUNA = @"KODEPENGGUNA";
			 public static string NAMA = @"NAMA";
			 public static string KATAKUNCI = @"KATAKUNCI";
			 public static string AKTIF = @"AKTIF";
			 public static string LOGINTERAKHIR = @"LOGINTERAKHIR";
			 public static string KODEKELOMPOK = @"KODEKELOMPOK";
						
		}

		#endregion
	}

}

