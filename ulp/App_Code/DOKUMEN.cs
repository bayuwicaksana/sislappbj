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
	/// Strongly-typed collection for the DOKUMEN class.
	/// </summary>
	[Serializable]
	public partial class DOKUMENCollection : ActiveList<DOKUMEN, DOKUMENCollection> 
	{	   
		public DOKUMENCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the DOKUMEN table.
	/// </summary>
	[Serializable]
	public partial class DOKUMEN : ActiveRecord<DOKUMEN>
	{
		#region .ctors and Default Settings
		
		public DOKUMEN()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public DOKUMEN(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public DOKUMEN(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public DOKUMEN(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DOKUMEN", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEDOKUMEN = new TableSchema.TableColumn(schema);
				colvarKODEDOKUMEN.ColumnName = "KODEDOKUMEN";
				colvarKODEDOKUMEN.DataType = DbType.String;
				colvarKODEDOKUMEN.MaxLength = 10;
				colvarKODEDOKUMEN.AutoIncrement = false;
				colvarKODEDOKUMEN.IsNullable = false;
				colvarKODEDOKUMEN.IsPrimaryKey = true;
				colvarKODEDOKUMEN.IsForeignKey = false;
				colvarKODEDOKUMEN.IsReadOnly = false;
				colvarKODEDOKUMEN.DefaultSetting = @"";
				colvarKODEDOKUMEN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEDOKUMEN);
				
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
				DataService.Providers["MyProvider"].AddSchema("DOKUMEN",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEDOKUMEN")]
		public string KODEDOKUMEN 
		{
			get { return GetColumnValue<string>("KODEDOKUMEN"); }

			set { SetColumnValue("KODEDOKUMEN", value); }

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
			return new Data.KELENGKAPANCollection().Where(KELENGKAPAN.Columns.KODEDOKUMEN, KODEDOKUMEN).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEDOKUMEN,string varDESKRIPSI)
		{
			DOKUMEN item = new DOKUMEN();
			
			item.KODEDOKUMEN = varKODEDOKUMEN;
			
			item.DESKRIPSI = varDESKRIPSI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEDOKUMEN,string varDESKRIPSI)
		{
			DOKUMEN item = new DOKUMEN();
			
				item.KODEDOKUMEN = varKODEDOKUMEN;
				
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
			 public static string KODEDOKUMEN = @"KODEDOKUMEN";
			 public static string DESKRIPSI = @"DESKRIPSI";
						
		}

		#endregion
	}

}

