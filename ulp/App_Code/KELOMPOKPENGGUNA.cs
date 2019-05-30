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
	/// Strongly-typed collection for the KELOMPOKPENGGUNA class.
	/// </summary>
	[Serializable]
	public partial class KELOMPOKPENGGUNACollection : ActiveList<KELOMPOKPENGGUNA, KELOMPOKPENGGUNACollection> 
	{	   
		public KELOMPOKPENGGUNACollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the KELOMPOKPENGGUNA table.
	/// </summary>
	[Serializable]
	public partial class KELOMPOKPENGGUNA : ActiveRecord<KELOMPOKPENGGUNA>
	{
		#region .ctors and Default Settings
		
		public KELOMPOKPENGGUNA()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public KELOMPOKPENGGUNA(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public KELOMPOKPENGGUNA(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public KELOMPOKPENGGUNA(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("KELOMPOKPENGGUNA", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEKELOMPOK = new TableSchema.TableColumn(schema);
				colvarKODEKELOMPOK.ColumnName = "KODEKELOMPOK";
				colvarKODEKELOMPOK.DataType = DbType.String;
				colvarKODEKELOMPOK.MaxLength = 20;
				colvarKODEKELOMPOK.AutoIncrement = false;
				colvarKODEKELOMPOK.IsNullable = false;
				colvarKODEKELOMPOK.IsPrimaryKey = true;
				colvarKODEKELOMPOK.IsForeignKey = false;
				colvarKODEKELOMPOK.IsReadOnly = false;
				colvarKODEKELOMPOK.DefaultSetting = @"";
				colvarKODEKELOMPOK.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEKELOMPOK);
				
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
				DataService.Providers["MyProvider"].AddSchema("KELOMPOKPENGGUNA",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEKELOMPOK")]
		public string KODEKELOMPOK 
		{
			get { return GetColumnValue<string>("KODEKELOMPOK"); }

			set { SetColumnValue("KODEKELOMPOK", value); }

		}

		  
		[XmlAttribute("DESKRIPSI")]
		public string DESKRIPSI 
		{
			get { return GetColumnValue<string>("DESKRIPSI"); }

			set { SetColumnValue("DESKRIPSI", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.PENGGUNACollection PENGGUNARecords()
		{
			return new Data.PENGGUNACollection().Where(PENGGUNA.Columns.KODEKELOMPOK, KODEKELOMPOK).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEKELOMPOK,string varDESKRIPSI)
		{
			KELOMPOKPENGGUNA item = new KELOMPOKPENGGUNA();
			
			item.KODEKELOMPOK = varKODEKELOMPOK;
			
			item.DESKRIPSI = varDESKRIPSI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEKELOMPOK,string varDESKRIPSI)
		{
			KELOMPOKPENGGUNA item = new KELOMPOKPENGGUNA();
			
				item.KODEKELOMPOK = varKODEKELOMPOK;
				
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
			 public static string KODEKELOMPOK = @"KODEKELOMPOK";
			 public static string DESKRIPSI = @"DESKRIPSI";
						
		}

		#endregion
	}

}

