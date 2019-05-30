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
	/// Strongly-typed collection for the JABATANAKTOR class.
	/// </summary>
	[Serializable]
	public partial class JABATANAKTORCollection : ActiveList<JABATANAKTOR, JABATANAKTORCollection> 
	{	   
		public JABATANAKTORCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the JABATANAKTOR table.
	/// </summary>
	[Serializable]
	public partial class JABATANAKTOR : ActiveRecord<JABATANAKTOR>
	{
		#region .ctors and Default Settings
		
		public JABATANAKTOR()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public JABATANAKTOR(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public JABATANAKTOR(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public JABATANAKTOR(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("JABATANAKTOR", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEJABATAN = new TableSchema.TableColumn(schema);
				colvarKODEJABATAN.ColumnName = "KODEJABATAN";
				colvarKODEJABATAN.DataType = DbType.String;
				colvarKODEJABATAN.MaxLength = 50;
				colvarKODEJABATAN.AutoIncrement = false;
				colvarKODEJABATAN.IsNullable = false;
				colvarKODEJABATAN.IsPrimaryKey = true;
				colvarKODEJABATAN.IsForeignKey = false;
				colvarKODEJABATAN.IsReadOnly = false;
				colvarKODEJABATAN.DefaultSetting = @"";
				colvarKODEJABATAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEJABATAN);
				
				TableSchema.TableColumn colvarDESKRIPSI = new TableSchema.TableColumn(schema);
				colvarDESKRIPSI.ColumnName = "DESKRIPSI";
				colvarDESKRIPSI.DataType = DbType.String;
				colvarDESKRIPSI.MaxLength = 100;
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
				DataService.Providers["MyProvider"].AddSchema("JABATANAKTOR",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEJABATAN")]
		public string KODEJABATAN 
		{
			get { return GetColumnValue<string>("KODEJABATAN"); }

			set { SetColumnValue("KODEJABATAN", value); }

		}

		  
		[XmlAttribute("DESKRIPSI")]
		public string DESKRIPSI 
		{
			get { return GetColumnValue<string>("DESKRIPSI"); }

			set { SetColumnValue("DESKRIPSI", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.AKTORCollection AKTORRecords()
		{
			return new Data.AKTORCollection().Where(AKTOR.Columns.KODEJABATAN, KODEJABATAN).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEJABATAN,string varDESKRIPSI)
		{
			JABATANAKTOR item = new JABATANAKTOR();
			
			item.KODEJABATAN = varKODEJABATAN;
			
			item.DESKRIPSI = varDESKRIPSI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEJABATAN,string varDESKRIPSI)
		{
			JABATANAKTOR item = new JABATANAKTOR();
			
				item.KODEJABATAN = varKODEJABATAN;
				
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
			 public static string KODEJABATAN = @"KODEJABATAN";
			 public static string DESKRIPSI = @"DESKRIPSI";
						
		}

		#endregion
	}

}

