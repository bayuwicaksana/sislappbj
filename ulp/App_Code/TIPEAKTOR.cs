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
	/// Strongly-typed collection for the TIPEAKTOR class.
	/// </summary>
	[Serializable]
	public partial class TIPEAKTORCollection : ActiveList<TIPEAKTOR, TIPEAKTORCollection> 
	{	   
		public TIPEAKTORCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the TIPEAKTOR table.
	/// </summary>
	[Serializable]
	public partial class TIPEAKTOR : ActiveRecord<TIPEAKTOR>
	{
		#region .ctors and Default Settings
		
		public TIPEAKTOR()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public TIPEAKTOR(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public TIPEAKTOR(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public TIPEAKTOR(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TIPEAKTOR", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODETIPE = new TableSchema.TableColumn(schema);
				colvarKODETIPE.ColumnName = "KODETIPE";
				colvarKODETIPE.DataType = DbType.String;
				colvarKODETIPE.MaxLength = 10;
				colvarKODETIPE.AutoIncrement = false;
				colvarKODETIPE.IsNullable = false;
				colvarKODETIPE.IsPrimaryKey = true;
				colvarKODETIPE.IsForeignKey = false;
				colvarKODETIPE.IsReadOnly = false;
				colvarKODETIPE.DefaultSetting = @"";
				colvarKODETIPE.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODETIPE);
				
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
				DataService.Providers["MyProvider"].AddSchema("TIPEAKTOR",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODETIPE")]
		public string KODETIPE 
		{
			get { return GetColumnValue<string>("KODETIPE"); }

			set { SetColumnValue("KODETIPE", value); }

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
			return new Data.AKTORCollection().Where(AKTOR.Columns.KODETIPE, KODETIPE).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODETIPE,string varDESKRIPSI)
		{
			TIPEAKTOR item = new TIPEAKTOR();
			
			item.KODETIPE = varKODETIPE;
			
			item.DESKRIPSI = varDESKRIPSI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODETIPE,string varDESKRIPSI)
		{
			TIPEAKTOR item = new TIPEAKTOR();
			
				item.KODETIPE = varKODETIPE;
				
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
			 public static string KODETIPE = @"KODETIPE";
			 public static string DESKRIPSI = @"DESKRIPSI";
						
		}

		#endregion
	}

}

