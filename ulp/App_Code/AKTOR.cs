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
	/// Strongly-typed collection for the AKTOR class.
	/// </summary>
	[Serializable]
	public partial class AKTORCollection : ActiveList<AKTOR, AKTORCollection> 
	{	   
		public AKTORCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the AKTOR table.
	/// </summary>
	[Serializable]
	public partial class AKTOR : ActiveRecord<AKTOR>
	{
		#region .ctors and Default Settings
		
		public AKTOR()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public AKTOR(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public AKTOR(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public AKTOR(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("AKTOR", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNIP = new TableSchema.TableColumn(schema);
				colvarNIP.ColumnName = "NIP";
				colvarNIP.DataType = DbType.String;
				colvarNIP.MaxLength = 18;
				colvarNIP.AutoIncrement = false;
				colvarNIP.IsNullable = false;
				colvarNIP.IsPrimaryKey = true;
				colvarNIP.IsForeignKey = false;
				colvarNIP.IsReadOnly = false;
				colvarNIP.DefaultSetting = @"";
				colvarNIP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNIP);
				
				TableSchema.TableColumn colvarNAMA = new TableSchema.TableColumn(schema);
				colvarNAMA.ColumnName = "NAMA";
				colvarNAMA.DataType = DbType.String;
				colvarNAMA.MaxLength = 255;
				colvarNAMA.AutoIncrement = false;
				colvarNAMA.IsNullable = true;
				colvarNAMA.IsPrimaryKey = false;
				colvarNAMA.IsForeignKey = false;
				colvarNAMA.IsReadOnly = false;
				colvarNAMA.DefaultSetting = @"";
				colvarNAMA.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNAMA);
				
				TableSchema.TableColumn colvarKODEJABATAN = new TableSchema.TableColumn(schema);
				colvarKODEJABATAN.ColumnName = "KODEJABATAN";
				colvarKODEJABATAN.DataType = DbType.String;
				colvarKODEJABATAN.MaxLength = 50;
				colvarKODEJABATAN.AutoIncrement = false;
				colvarKODEJABATAN.IsNullable = true;
				colvarKODEJABATAN.IsPrimaryKey = false;
				colvarKODEJABATAN.IsForeignKey = true;
				colvarKODEJABATAN.IsReadOnly = false;
				colvarKODEJABATAN.DefaultSetting = @"";
				
					colvarKODEJABATAN.ForeignKeyTableName = "JABATANAKTOR";
				schema.Columns.Add(colvarKODEJABATAN);
				
				TableSchema.TableColumn colvarKODETIPE = new TableSchema.TableColumn(schema);
				colvarKODETIPE.ColumnName = "KODETIPE";
				colvarKODETIPE.DataType = DbType.String;
				colvarKODETIPE.MaxLength = 10;
				colvarKODETIPE.AutoIncrement = false;
				colvarKODETIPE.IsNullable = true;
				colvarKODETIPE.IsPrimaryKey = false;
				colvarKODETIPE.IsForeignKey = true;
				colvarKODETIPE.IsReadOnly = false;
				colvarKODETIPE.DefaultSetting = @"";
				
					colvarKODETIPE.ForeignKeyTableName = "TIPEAKTOR";
				schema.Columns.Add(colvarKODETIPE);
				
				TableSchema.TableColumn colvarKODEPOKJA = new TableSchema.TableColumn(schema);
				colvarKODEPOKJA.ColumnName = "KODEPOKJA";
				colvarKODEPOKJA.DataType = DbType.String;
				colvarKODEPOKJA.MaxLength = 5;
				colvarKODEPOKJA.AutoIncrement = false;
				colvarKODEPOKJA.IsNullable = true;
				colvarKODEPOKJA.IsPrimaryKey = false;
				colvarKODEPOKJA.IsForeignKey = true;
				colvarKODEPOKJA.IsReadOnly = false;
				colvarKODEPOKJA.DefaultSetting = @"";
				
					colvarKODEPOKJA.ForeignKeyTableName = "POKJA";
				schema.Columns.Add(colvarKODEPOKJA);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("AKTOR",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("NIP")]
		public string NIP 
		{
			get { return GetColumnValue<string>("NIP"); }

			set { SetColumnValue("NIP", value); }

		}

		  
		[XmlAttribute("NAMA")]
		public string NAMA 
		{
			get { return GetColumnValue<string>("NAMA"); }

			set { SetColumnValue("NAMA", value); }

		}

		  
		[XmlAttribute("KODEJABATAN")]
		public string KODEJABATAN 
		{
			get { return GetColumnValue<string>("KODEJABATAN"); }

			set { SetColumnValue("KODEJABATAN", value); }

		}

		  
		[XmlAttribute("KODETIPE")]
		public string KODETIPE 
		{
			get { return GetColumnValue<string>("KODETIPE"); }

			set { SetColumnValue("KODETIPE", value); }

		}

		  
		[XmlAttribute("KODEPOKJA")]
		public string KODEPOKJA 
		{
			get { return GetColumnValue<string>("KODEPOKJA"); }

			set { SetColumnValue("KODEPOKJA", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.PENGADAAN_LANGSUNGCollection PENGADAAN_LANGSUNGRecords()
		{
			return new Data.PENGADAAN_LANGSUNGCollection().Where(PENGADAAN_LANGSUNG.Columns.PEJABATPENGADAAN, NIP).Load();
		}

		public Data.PENGADAAN_LANGSUNGCollection PENGADAAN_LANGSUNGRecordsFromAKTOR()
		{
			return new Data.PENGADAAN_LANGSUNGCollection().Where(PENGADAAN_LANGSUNG.Columns.MENGETAHUI, NIP).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a POKJA ActiveRecord object related to this AKTOR
		/// 
		/// </summary>
		public Data.POKJA POKJA
		{
			get { return Data.POKJA.FetchByID(this.KODEPOKJA); }

			set { SetColumnValue("KODEPOKJA", value.KODEPOKJA); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNIP,string varNAMA,string varKODEJABATAN,string varKODETIPE,string varKODEPOKJA)
		{
			AKTOR item = new AKTOR();
			
			item.NIP = varNIP;
			
			item.NAMA = varNAMA;
			
			item.KODEJABATAN = varKODEJABATAN;
			
			item.KODETIPE = varKODETIPE;
			
			item.KODEPOKJA = varKODEPOKJA;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varNIP,string varNAMA,string varKODEJABATAN,string varKODETIPE,string varKODEPOKJA)
		{
			AKTOR item = new AKTOR();
			
				item.NIP = varNIP;
				
				item.NAMA = varNAMA;
				
				item.KODEJABATAN = varKODEJABATAN;
				
				item.KODETIPE = varKODETIPE;
				
				item.KODEPOKJA = varKODEPOKJA;
				
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
			 public static string NIP = @"NIP";
			 public static string NAMA = @"NAMA";
			 public static string KODEJABATAN = @"KODEJABATAN";
			 public static string KODETIPE = @"KODETIPE";
			 public static string KODEPOKJA = @"KODEPOKJA";
						
		}

		#endregion
	}

}

