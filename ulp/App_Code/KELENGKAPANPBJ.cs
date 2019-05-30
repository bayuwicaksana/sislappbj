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
	/// Strongly-typed collection for the KELENGKAPANPBJ class.
	/// </summary>
	[Serializable]
	public partial class KELENGKAPANPBJCollection : ActiveList<KELENGKAPANPBJ, KELENGKAPANPBJCollection> 
	{	   
		public KELENGKAPANPBJCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the KELENGKAPANPBJ table.
	/// </summary>
	[Serializable]
	public partial class KELENGKAPANPBJ : ActiveRecord<KELENGKAPANPBJ>
	{
		#region .ctors and Default Settings
		
		public KELENGKAPANPBJ()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public KELENGKAPANPBJ(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public KELENGKAPANPBJ(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public KELENGKAPANPBJ(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("KELENGKAPANPBJ", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEBPJ = new TableSchema.TableColumn(schema);
				colvarKODEBPJ.ColumnName = "KODEBPJ";
				colvarKODEBPJ.DataType = DbType.String;
				colvarKODEBPJ.MaxLength = 15;
				colvarKODEBPJ.AutoIncrement = false;
				colvarKODEBPJ.IsNullable = false;
				colvarKODEBPJ.IsPrimaryKey = true;
				colvarKODEBPJ.IsForeignKey = true;
				colvarKODEBPJ.IsReadOnly = false;
				colvarKODEBPJ.DefaultSetting = @"";
				
					colvarKODEBPJ.ForeignKeyTableName = "PBJ";
				schema.Columns.Add(colvarKODEBPJ);
				
				TableSchema.TableColumn colvarKODEKELENGKAPAN = new TableSchema.TableColumn(schema);
				colvarKODEKELENGKAPAN.ColumnName = "KODEKELENGKAPAN";
				colvarKODEKELENGKAPAN.DataType = DbType.String;
				colvarKODEKELENGKAPAN.MaxLength = 10;
				colvarKODEKELENGKAPAN.AutoIncrement = false;
				colvarKODEKELENGKAPAN.IsNullable = false;
				colvarKODEKELENGKAPAN.IsPrimaryKey = true;
				colvarKODEKELENGKAPAN.IsForeignKey = true;
				colvarKODEKELENGKAPAN.IsReadOnly = false;
				colvarKODEKELENGKAPAN.DefaultSetting = @"";
				
					colvarKODEKELENGKAPAN.ForeignKeyTableName = "KELENGKAPAN";
				schema.Columns.Add(colvarKODEKELENGKAPAN);
				
				TableSchema.TableColumn colvarTANGGALDITERIMA = new TableSchema.TableColumn(schema);
				colvarTANGGALDITERIMA.ColumnName = "TANGGALDITERIMA";
				colvarTANGGALDITERIMA.DataType = DbType.DateTime;
				colvarTANGGALDITERIMA.MaxLength = 0;
				colvarTANGGALDITERIMA.AutoIncrement = false;
				colvarTANGGALDITERIMA.IsNullable = true;
				colvarTANGGALDITERIMA.IsPrimaryKey = false;
				colvarTANGGALDITERIMA.IsForeignKey = false;
				colvarTANGGALDITERIMA.IsReadOnly = false;
				colvarTANGGALDITERIMA.DefaultSetting = @"";
				colvarTANGGALDITERIMA.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGALDITERIMA);
				
				TableSchema.TableColumn colvarPENERIMAKELENGKAPAN = new TableSchema.TableColumn(schema);
				colvarPENERIMAKELENGKAPAN.ColumnName = "PENERIMAKELENGKAPAN";
				colvarPENERIMAKELENGKAPAN.DataType = DbType.String;
				colvarPENERIMAKELENGKAPAN.MaxLength = 50;
				colvarPENERIMAKELENGKAPAN.AutoIncrement = false;
				colvarPENERIMAKELENGKAPAN.IsNullable = true;
				colvarPENERIMAKELENGKAPAN.IsPrimaryKey = false;
				colvarPENERIMAKELENGKAPAN.IsForeignKey = false;
				colvarPENERIMAKELENGKAPAN.IsReadOnly = false;
				colvarPENERIMAKELENGKAPAN.DefaultSetting = @"";
				colvarPENERIMAKELENGKAPAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPENERIMAKELENGKAPAN);
				
				TableSchema.TableColumn colvarTANGGALMODIFIKASI = new TableSchema.TableColumn(schema);
				colvarTANGGALMODIFIKASI.ColumnName = "TANGGALMODIFIKASI";
				colvarTANGGALMODIFIKASI.DataType = DbType.DateTime;
				colvarTANGGALMODIFIKASI.MaxLength = 0;
				colvarTANGGALMODIFIKASI.AutoIncrement = false;
				colvarTANGGALMODIFIKASI.IsNullable = true;
				colvarTANGGALMODIFIKASI.IsPrimaryKey = false;
				colvarTANGGALMODIFIKASI.IsForeignKey = false;
				colvarTANGGALMODIFIKASI.IsReadOnly = false;
				colvarTANGGALMODIFIKASI.DefaultSetting = @"";
				colvarTANGGALMODIFIKASI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGALMODIFIKASI);
				
				TableSchema.TableColumn colvarDIBUATOLEH = new TableSchema.TableColumn(schema);
				colvarDIBUATOLEH.ColumnName = "DIBUATOLEH";
				colvarDIBUATOLEH.DataType = DbType.String;
				colvarDIBUATOLEH.MaxLength = 50;
				colvarDIBUATOLEH.AutoIncrement = false;
				colvarDIBUATOLEH.IsNullable = true;
				colvarDIBUATOLEH.IsPrimaryKey = false;
				colvarDIBUATOLEH.IsForeignKey = false;
				colvarDIBUATOLEH.IsReadOnly = false;
				colvarDIBUATOLEH.DefaultSetting = @"";
				colvarDIBUATOLEH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDIBUATOLEH);
				
				TableSchema.TableColumn colvarTANGGALDIBUAT = new TableSchema.TableColumn(schema);
				colvarTANGGALDIBUAT.ColumnName = "TANGGALDIBUAT";
				colvarTANGGALDIBUAT.DataType = DbType.DateTime;
				colvarTANGGALDIBUAT.MaxLength = 0;
				colvarTANGGALDIBUAT.AutoIncrement = false;
				colvarTANGGALDIBUAT.IsNullable = true;
				colvarTANGGALDIBUAT.IsPrimaryKey = false;
				colvarTANGGALDIBUAT.IsForeignKey = false;
				colvarTANGGALDIBUAT.IsReadOnly = false;
				colvarTANGGALDIBUAT.DefaultSetting = @"";
				colvarTANGGALDIBUAT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGALDIBUAT);
				
				TableSchema.TableColumn colvarMODIFIKASIOLEH = new TableSchema.TableColumn(schema);
				colvarMODIFIKASIOLEH.ColumnName = "MODIFIKASIOLEH";
				colvarMODIFIKASIOLEH.DataType = DbType.String;
				colvarMODIFIKASIOLEH.MaxLength = 50;
				colvarMODIFIKASIOLEH.AutoIncrement = false;
				colvarMODIFIKASIOLEH.IsNullable = true;
				colvarMODIFIKASIOLEH.IsPrimaryKey = false;
				colvarMODIFIKASIOLEH.IsForeignKey = false;
				colvarMODIFIKASIOLEH.IsReadOnly = false;
				colvarMODIFIKASIOLEH.DefaultSetting = @"";
				colvarMODIFIKASIOLEH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMODIFIKASIOLEH);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("KELENGKAPANPBJ",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEBPJ")]
		public string KODEBPJ 
		{
			get { return GetColumnValue<string>("KODEBPJ"); }

			set { SetColumnValue("KODEBPJ", value); }

		}

		  
		[XmlAttribute("KODEKELENGKAPAN")]
		public string KODEKELENGKAPAN 
		{
			get { return GetColumnValue<string>("KODEKELENGKAPAN"); }

			set { SetColumnValue("KODEKELENGKAPAN", value); }

		}

		  
		[XmlAttribute("TANGGALDITERIMA")]
		public DateTime? TANGGALDITERIMA 
		{
			get { return GetColumnValue<DateTime?>("TANGGALDITERIMA"); }

			set { SetColumnValue("TANGGALDITERIMA", value); }

		}

		  
		[XmlAttribute("PENERIMAKELENGKAPAN")]
		public string PENERIMAKELENGKAPAN 
		{
			get { return GetColumnValue<string>("PENERIMAKELENGKAPAN"); }

			set { SetColumnValue("PENERIMAKELENGKAPAN", value); }

		}

		  
		[XmlAttribute("TANGGALMODIFIKASI")]
		public DateTime? TANGGALMODIFIKASI 
		{
			get { return GetColumnValue<DateTime?>("TANGGALMODIFIKASI"); }

			set { SetColumnValue("TANGGALMODIFIKASI", value); }

		}

		  
		[XmlAttribute("DIBUATOLEH")]
		public string DIBUATOLEH 
		{
			get { return GetColumnValue<string>("DIBUATOLEH"); }

			set { SetColumnValue("DIBUATOLEH", value); }

		}

		  
		[XmlAttribute("TANGGALDIBUAT")]
		public DateTime? TANGGALDIBUAT 
		{
			get { return GetColumnValue<DateTime?>("TANGGALDIBUAT"); }

			set { SetColumnValue("TANGGALDIBUAT", value); }

		}

		  
		[XmlAttribute("MODIFIKASIOLEH")]
		public string MODIFIKASIOLEH 
		{
			get { return GetColumnValue<string>("MODIFIKASIOLEH"); }

			set { SetColumnValue("MODIFIKASIOLEH", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a KELENGKAPAN ActiveRecord object related to this KELENGKAPANPBJ
		/// 
		/// </summary>
		public Data.KELENGKAPAN KELENGKAPAN
		{
			get { return Data.KELENGKAPAN.FetchByID(this.KODEKELENGKAPAN); }

			set { SetColumnValue("KODEKELENGKAPAN", value.KODEKELENGKAPAN); }

		}

		
		
		/// <summary>
		/// Returns a PBJ ActiveRecord object related to this KELENGKAPANPBJ
		/// 
		/// </summary>
		public Data.PBJ PBJ
		{
			get { return Data.PBJ.FetchByID(this.KODEBPJ); }

			set { SetColumnValue("KODEBPJ", value.KODEPBJ); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEBPJ,string varKODEKELENGKAPAN,DateTime? varTANGGALDITERIMA,string varPENERIMAKELENGKAPAN,DateTime? varTANGGALMODIFIKASI,string varDIBUATOLEH,DateTime? varTANGGALDIBUAT,string varMODIFIKASIOLEH)
		{
			KELENGKAPANPBJ item = new KELENGKAPANPBJ();
			
			item.KODEBPJ = varKODEBPJ;
			
			item.KODEKELENGKAPAN = varKODEKELENGKAPAN;
			
			item.TANGGALDITERIMA = varTANGGALDITERIMA;
			
			item.PENERIMAKELENGKAPAN = varPENERIMAKELENGKAPAN;
			
			item.TANGGALMODIFIKASI = varTANGGALMODIFIKASI;
			
			item.DIBUATOLEH = varDIBUATOLEH;
			
			item.TANGGALDIBUAT = varTANGGALDIBUAT;
			
			item.MODIFIKASIOLEH = varMODIFIKASIOLEH;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEBPJ,string varKODEKELENGKAPAN,DateTime? varTANGGALDITERIMA,string varPENERIMAKELENGKAPAN,DateTime? varTANGGALMODIFIKASI,string varDIBUATOLEH,DateTime? varTANGGALDIBUAT,string varMODIFIKASIOLEH)
		{
			KELENGKAPANPBJ item = new KELENGKAPANPBJ();
			
				item.KODEBPJ = varKODEBPJ;
				
				item.KODEKELENGKAPAN = varKODEKELENGKAPAN;
				
				item.TANGGALDITERIMA = varTANGGALDITERIMA;
				
				item.PENERIMAKELENGKAPAN = varPENERIMAKELENGKAPAN;
				
				item.TANGGALMODIFIKASI = varTANGGALMODIFIKASI;
				
				item.DIBUATOLEH = varDIBUATOLEH;
				
				item.TANGGALDIBUAT = varTANGGALDIBUAT;
				
				item.MODIFIKASIOLEH = varMODIFIKASIOLEH;
				
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
			 public static string KODEBPJ = @"KODEBPJ";
			 public static string KODEKELENGKAPAN = @"KODEKELENGKAPAN";
			 public static string TANGGALDITERIMA = @"TANGGALDITERIMA";
			 public static string PENERIMAKELENGKAPAN = @"PENERIMAKELENGKAPAN";
			 public static string TANGGALMODIFIKASI = @"TANGGALMODIFIKASI";
			 public static string DIBUATOLEH = @"DIBUATOLEH";
			 public static string TANGGALDIBUAT = @"TANGGALDIBUAT";
			 public static string MODIFIKASIOLEH = @"MODIFIKASIOLEH";
						
		}

		#endregion
	}

}

