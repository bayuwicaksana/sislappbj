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
	/// Strongly-typed collection for the POKJA class.
	/// </summary>
	[Serializable]
	public partial class POKJACollection : ActiveList<POKJA, POKJACollection> 
	{	   
		public POKJACollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the POKJA table.
	/// </summary>
	[Serializable]
	public partial class POKJA : ActiveRecord<POKJA>
	{
		#region .ctors and Default Settings
		
		public POKJA()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public POKJA(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public POKJA(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public POKJA(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("POKJA", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEPOKJA = new TableSchema.TableColumn(schema);
				colvarKODEPOKJA.ColumnName = "KODEPOKJA";
				colvarKODEPOKJA.DataType = DbType.String;
				colvarKODEPOKJA.MaxLength = 5;
				colvarKODEPOKJA.AutoIncrement = false;
				colvarKODEPOKJA.IsNullable = false;
				colvarKODEPOKJA.IsPrimaryKey = true;
				colvarKODEPOKJA.IsForeignKey = false;
				colvarKODEPOKJA.IsReadOnly = false;
				colvarKODEPOKJA.DefaultSetting = @"";
				colvarKODEPOKJA.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEPOKJA);
				
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
				
				TableSchema.TableColumn colvarDESKRIPSSI = new TableSchema.TableColumn(schema);
				colvarDESKRIPSSI.ColumnName = "DESKRIPSSI";
				colvarDESKRIPSSI.DataType = DbType.String;
				colvarDESKRIPSSI.MaxLength = 500;
				colvarDESKRIPSSI.AutoIncrement = false;
				colvarDESKRIPSSI.IsNullable = true;
				colvarDESKRIPSSI.IsPrimaryKey = false;
				colvarDESKRIPSSI.IsForeignKey = false;
				colvarDESKRIPSSI.IsReadOnly = false;
				colvarDESKRIPSSI.DefaultSetting = @"";
				colvarDESKRIPSSI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDESKRIPSSI);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("POKJA",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEPOKJA")]
		public string KODEPOKJA 
		{
			get { return GetColumnValue<string>("KODEPOKJA"); }

			set { SetColumnValue("KODEPOKJA", value); }

		}

		  
		[XmlAttribute("NAMA")]
		public string NAMA 
		{
			get { return GetColumnValue<string>("NAMA"); }

			set { SetColumnValue("NAMA", value); }

		}

		  
		[XmlAttribute("DESKRIPSSI")]
		public string DESKRIPSSI 
		{
			get { return GetColumnValue<string>("DESKRIPSSI"); }

			set { SetColumnValue("DESKRIPSSI", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.AKTORCollection AKTORRecords()
		{
			return new Data.AKTORCollection().Where(AKTOR.Columns.KODEPOKJA, KODEPOKJA).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEPOKJA,string varNAMA,string varDESKRIPSSI)
		{
			POKJA item = new POKJA();
			
			item.KODEPOKJA = varKODEPOKJA;
			
			item.NAMA = varNAMA;
			
			item.DESKRIPSSI = varDESKRIPSSI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEPOKJA,string varNAMA,string varDESKRIPSSI)
		{
			POKJA item = new POKJA();
			
				item.KODEPOKJA = varKODEPOKJA;
				
				item.NAMA = varNAMA;
				
				item.DESKRIPSSI = varDESKRIPSSI;
				
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
			 public static string KODEPOKJA = @"KODEPOKJA";
			 public static string NAMA = @"NAMA";
			 public static string DESKRIPSSI = @"DESKRIPSSI";
						
		}

		#endregion
	}

}

