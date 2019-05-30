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
	/// Strongly-typed collection for the STATUSPBJ class.
	/// </summary>
	[Serializable]
	public partial class STATUSPBJCollection : ActiveList<STATUSPBJ, STATUSPBJCollection> 
	{	   
		public STATUSPBJCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the STATUSPBJ table.
	/// </summary>
	[Serializable]
	public partial class STATUSPBJ : ActiveRecord<STATUSPBJ>
	{
		#region .ctors and Default Settings
		
		public STATUSPBJ()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public STATUSPBJ(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public STATUSPBJ(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public STATUSPBJ(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("STATUSPBJ", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODESTATUS = new TableSchema.TableColumn(schema);
				colvarKODESTATUS.ColumnName = "KODESTATUS";
				colvarKODESTATUS.DataType = DbType.String;
				colvarKODESTATUS.MaxLength = 20;
				colvarKODESTATUS.AutoIncrement = false;
				colvarKODESTATUS.IsNullable = false;
				colvarKODESTATUS.IsPrimaryKey = true;
				colvarKODESTATUS.IsForeignKey = false;
				colvarKODESTATUS.IsReadOnly = false;
				colvarKODESTATUS.DefaultSetting = @"";
				colvarKODESTATUS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODESTATUS);
				
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
				
				TableSchema.TableColumn colvarURUTAN = new TableSchema.TableColumn(schema);
				colvarURUTAN.ColumnName = "URUTAN";
				colvarURUTAN.DataType = DbType.Int32;
				colvarURUTAN.MaxLength = 0;
				colvarURUTAN.AutoIncrement = false;
				colvarURUTAN.IsNullable = true;
				colvarURUTAN.IsPrimaryKey = false;
				colvarURUTAN.IsForeignKey = false;
				colvarURUTAN.IsReadOnly = false;
				colvarURUTAN.DefaultSetting = @"";
				colvarURUTAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarURUTAN);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("STATUSPBJ",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODESTATUS")]
		public string KODESTATUS 
		{
			get { return GetColumnValue<string>("KODESTATUS"); }

			set { SetColumnValue("KODESTATUS", value); }

		}

		  
		[XmlAttribute("DESKRIPSI")]
		public string DESKRIPSI 
		{
			get { return GetColumnValue<string>("DESKRIPSI"); }

			set { SetColumnValue("DESKRIPSI", value); }

		}

		  
		[XmlAttribute("URUTAN")]
		public int? URUTAN 
		{
			get { return GetColumnValue<int?>("URUTAN"); }

			set { SetColumnValue("URUTAN", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.PBJCollection PBJRecords()
		{
			return new Data.PBJCollection().Where(PBJ.Columns.KODESTATUSPBJ, KODESTATUS).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODESTATUS,string varDESKRIPSI,int? varURUTAN)
		{
			STATUSPBJ item = new STATUSPBJ();
			
			item.KODESTATUS = varKODESTATUS;
			
			item.DESKRIPSI = varDESKRIPSI;
			
			item.URUTAN = varURUTAN;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODESTATUS,string varDESKRIPSI,int? varURUTAN)
		{
			STATUSPBJ item = new STATUSPBJ();
			
				item.KODESTATUS = varKODESTATUS;
				
				item.DESKRIPSI = varDESKRIPSI;
				
				item.URUTAN = varURUTAN;
				
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
			 public static string KODESTATUS = @"KODESTATUS";
			 public static string DESKRIPSI = @"DESKRIPSI";
			 public static string URUTAN = @"URUTAN";
						
		}

		#endregion
	}

}

