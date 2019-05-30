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
	/// Strongly-typed collection for the JENISKEGIATAN class.
	/// </summary>
	[Serializable]
	public partial class JENISKEGIATANCollection : ActiveList<JENISKEGIATAN, JENISKEGIATANCollection> 
	{	   
		public JENISKEGIATANCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the JENISKEGIATAN table.
	/// </summary>
	[Serializable]
	public partial class JENISKEGIATAN : ActiveRecord<JENISKEGIATAN>
	{
		#region .ctors and Default Settings
		
		public JENISKEGIATAN()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public JENISKEGIATAN(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public JENISKEGIATAN(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public JENISKEGIATAN(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("JENISKEGIATAN", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEJENISKEGIATAN = new TableSchema.TableColumn(schema);
				colvarKODEJENISKEGIATAN.ColumnName = "KODEJENISKEGIATAN";
				colvarKODEJENISKEGIATAN.DataType = DbType.String;
				colvarKODEJENISKEGIATAN.MaxLength = 10;
				colvarKODEJENISKEGIATAN.AutoIncrement = false;
				colvarKODEJENISKEGIATAN.IsNullable = false;
				colvarKODEJENISKEGIATAN.IsPrimaryKey = true;
				colvarKODEJENISKEGIATAN.IsForeignKey = false;
				colvarKODEJENISKEGIATAN.IsReadOnly = false;
				colvarKODEJENISKEGIATAN.DefaultSetting = @"";
				colvarKODEJENISKEGIATAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEJENISKEGIATAN);
				
				TableSchema.TableColumn colvarDESKRIPSI = new TableSchema.TableColumn(schema);
				colvarDESKRIPSI.ColumnName = "DESKRIPSI";
				colvarDESKRIPSI.DataType = DbType.String;
				colvarDESKRIPSI.MaxLength = 200;
				colvarDESKRIPSI.AutoIncrement = false;
				colvarDESKRIPSI.IsNullable = true;
				colvarDESKRIPSI.IsPrimaryKey = false;
				colvarDESKRIPSI.IsForeignKey = false;
				colvarDESKRIPSI.IsReadOnly = false;
				colvarDESKRIPSI.DefaultSetting = @"";
				colvarDESKRIPSI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDESKRIPSI);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("JENISKEGIATAN",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEJENISKEGIATAN")]
		public string KODEJENISKEGIATAN 
		{
			get { return GetColumnValue<string>("KODEJENISKEGIATAN"); }

			set { SetColumnValue("KODEJENISKEGIATAN", value); }

		}

		  
		[XmlAttribute("DESKRIPSI")]
		public string DESKRIPSI 
		{
			get { return GetColumnValue<string>("DESKRIPSI"); }

			set { SetColumnValue("DESKRIPSI", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.KELENGKAPANCollection KELENGKAPANRecords()
		{
			return new Data.KELENGKAPANCollection().Where(KELENGKAPAN.Columns.KODEJENISKEGIATAN, KODEJENISKEGIATAN).Load();
		}

		public Data.PBJCollection PBJRecords()
		{
			return new Data.PBJCollection().Where(PBJ.Columns.KODEJENISKEGIATAN, KODEJENISKEGIATAN).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEJENISKEGIATAN,string varDESKRIPSI)
		{
			JENISKEGIATAN item = new JENISKEGIATAN();
			
			item.KODEJENISKEGIATAN = varKODEJENISKEGIATAN;
			
			item.DESKRIPSI = varDESKRIPSI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEJENISKEGIATAN,string varDESKRIPSI)
		{
			JENISKEGIATAN item = new JENISKEGIATAN();
			
				item.KODEJENISKEGIATAN = varKODEJENISKEGIATAN;
				
				item.DESKRIPSI = varDESKRIPSI;
				
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
			 public static string KODEJENISKEGIATAN = @"KODEJENISKEGIATAN";
			 public static string DESKRIPSI = @"DESKRIPSI";
						
		}

		#endregion
	}

}

