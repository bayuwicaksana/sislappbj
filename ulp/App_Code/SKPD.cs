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
	/// Strongly-typed collection for the SKPD class.
	/// </summary>
	[Serializable]
	public partial class SKPDCollection : ActiveList<SKPD, SKPDCollection> 
	{	   
		public SKPDCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SKPD table.
	/// </summary>
	[Serializable]
	public partial class SKPD : ActiveRecord<SKPD>
	{
		#region .ctors and Default Settings
		
		public SKPD()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SKPD(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SKPD(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SKPD(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SKPD", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODESKPD = new TableSchema.TableColumn(schema);
				colvarKODESKPD.ColumnName = "KODESKPD";
				colvarKODESKPD.DataType = DbType.String;
				colvarKODESKPD.MaxLength = 10;
				colvarKODESKPD.AutoIncrement = false;
				colvarKODESKPD.IsNullable = false;
				colvarKODESKPD.IsPrimaryKey = true;
				colvarKODESKPD.IsForeignKey = false;
				colvarKODESKPD.IsReadOnly = false;
				colvarKODESKPD.DefaultSetting = @"";
				colvarKODESKPD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODESKPD);
				
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
				
				TableSchema.TableColumn colvarALAMAT = new TableSchema.TableColumn(schema);
				colvarALAMAT.ColumnName = "ALAMAT";
				colvarALAMAT.DataType = DbType.String;
				colvarALAMAT.MaxLength = 500;
				colvarALAMAT.AutoIncrement = false;
				colvarALAMAT.IsNullable = true;
				colvarALAMAT.IsPrimaryKey = false;
				colvarALAMAT.IsForeignKey = false;
				colvarALAMAT.IsReadOnly = false;
				colvarALAMAT.DefaultSetting = @"";
				colvarALAMAT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarALAMAT);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("SKPD",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODESKPD")]
		public string KODESKPD 
		{
			get { return GetColumnValue<string>("KODESKPD"); }

			set { SetColumnValue("KODESKPD", value); }

		}

		  
		[XmlAttribute("DESKRIPSI")]
		public string DESKRIPSI 
		{
			get { return GetColumnValue<string>("DESKRIPSI"); }

			set { SetColumnValue("DESKRIPSI", value); }

		}

		  
		[XmlAttribute("ALAMAT")]
		public string ALAMAT 
		{
			get { return GetColumnValue<string>("ALAMAT"); }

			set { SetColumnValue("ALAMAT", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.PBJCollection PBJRecords()
		{
			return new Data.PBJCollection().Where(PBJ.Columns.KODESKPD, KODESKPD).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODESKPD,string varDESKRIPSI,string varALAMAT)
		{
			SKPD item = new SKPD();
			
			item.KODESKPD = varKODESKPD;
			
			item.DESKRIPSI = varDESKRIPSI;
			
			item.ALAMAT = varALAMAT;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODESKPD,string varDESKRIPSI,string varALAMAT)
		{
			SKPD item = new SKPD();
			
				item.KODESKPD = varKODESKPD;
				
				item.DESKRIPSI = varDESKRIPSI;
				
				item.ALAMAT = varALAMAT;
				
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
			 public static string KODESKPD = @"KODESKPD";
			 public static string DESKRIPSI = @"DESKRIPSI";
			 public static string ALAMAT = @"ALAMAT";
						
		}

		#endregion
	}

}

