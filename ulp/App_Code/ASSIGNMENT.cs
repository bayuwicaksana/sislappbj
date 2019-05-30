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
	/// Strongly-typed collection for the ASSIGNMENT class.
	/// </summary>
	[Serializable]
	public partial class ASSIGNMENTCollection : ActiveList<ASSIGNMENT, ASSIGNMENTCollection> 
	{	   
		public ASSIGNMENTCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ASSIGNMENT table.
	/// </summary>
	[Serializable]
	public partial class ASSIGNMENT : ActiveRecord<ASSIGNMENT>
	{
		#region .ctors and Default Settings
		
		public ASSIGNMENT()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ASSIGNMENT(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ASSIGNMENT(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ASSIGNMENT(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ASSIGNMENT", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNIP = new TableSchema.TableColumn(schema);
				colvarNIP.ColumnName = "NIP";
				colvarNIP.DataType = DbType.String;
				colvarNIP.MaxLength = 18;
				colvarNIP.AutoIncrement = false;
				colvarNIP.IsNullable = true;
				colvarNIP.IsPrimaryKey = false;
				colvarNIP.IsForeignKey = true;
				colvarNIP.IsReadOnly = false;
				colvarNIP.DefaultSetting = @"";
				
					colvarNIP.ForeignKeyTableName = "AKTOR";
				schema.Columns.Add(colvarNIP);
				
				TableSchema.TableColumn colvarKODEPBJ = new TableSchema.TableColumn(schema);
				colvarKODEPBJ.ColumnName = "KODEPBJ";
				colvarKODEPBJ.DataType = DbType.String;
				colvarKODEPBJ.MaxLength = 15;
				colvarKODEPBJ.AutoIncrement = false;
				colvarKODEPBJ.IsNullable = true;
				colvarKODEPBJ.IsPrimaryKey = false;
				colvarKODEPBJ.IsForeignKey = true;
				colvarKODEPBJ.IsReadOnly = false;
				colvarKODEPBJ.DefaultSetting = @"";
				
					colvarKODEPBJ.ForeignKeyTableName = "PBJ";
				schema.Columns.Add(colvarKODEPBJ);
				
				TableSchema.TableColumn colvarNOSURATTUGAS = new TableSchema.TableColumn(schema);
				colvarNOSURATTUGAS.ColumnName = "NOSURATTUGAS";
				colvarNOSURATTUGAS.DataType = DbType.String;
				colvarNOSURATTUGAS.MaxLength = 50;
				colvarNOSURATTUGAS.AutoIncrement = false;
				colvarNOSURATTUGAS.IsNullable = true;
				colvarNOSURATTUGAS.IsPrimaryKey = false;
				colvarNOSURATTUGAS.IsForeignKey = false;
				colvarNOSURATTUGAS.IsReadOnly = false;
				colvarNOSURATTUGAS.DefaultSetting = @"";
				colvarNOSURATTUGAS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNOSURATTUGAS);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("ASSIGNMENT",schema);
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

		  
		[XmlAttribute("KODEPBJ")]
		public string KODEPBJ 
		{
			get { return GetColumnValue<string>("KODEPBJ"); }

			set { SetColumnValue("KODEPBJ", value); }

		}

		  
		[XmlAttribute("NOSURATTUGAS")]
		public string NOSURATTUGAS 
		{
			get { return GetColumnValue<string>("NOSURATTUGAS"); }

			set { SetColumnValue("NOSURATTUGAS", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AKTOR ActiveRecord object related to this ASSIGNMENT
		/// 
		/// </summary>
		public Data.AKTOR AKTOR
		{
			get { return Data.AKTOR.FetchByID(this.NIP); }

			set { SetColumnValue("NIP", value.NIP); }

		}

		
		
		/// <summary>
		/// Returns a PBJ ActiveRecord object related to this ASSIGNMENT
		/// 
		/// </summary>
		public Data.PBJ PBJ
		{
			get { return Data.PBJ.FetchByID(this.KODEPBJ); }

			set { SetColumnValue("KODEPBJ", value.KODEPBJ); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNIP,string varKODEPBJ,string varNOSURATTUGAS)
		{
			ASSIGNMENT item = new ASSIGNMENT();
			
			item.NIP = varNIP;
			
			item.KODEPBJ = varKODEPBJ;
			
			item.NOSURATTUGAS = varNOSURATTUGAS;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varNIP,string varKODEPBJ,string varNOSURATTUGAS)
		{
			ASSIGNMENT item = new ASSIGNMENT();
			
				item.NIP = varNIP;
				
				item.KODEPBJ = varKODEPBJ;
				
				item.NOSURATTUGAS = varNOSURATTUGAS;
				
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
			 public static string KODEPBJ = @"KODEPBJ";
			 public static string NOSURATTUGAS = @"NOSURATTUGAS";
						
		}

		#endregion
	}

}

