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
	/// Strongly-typed collection for the PENGADAAN_LANGSUNG class.
	/// </summary>
	[Serializable]
	public partial class PENGADAAN_LANGSUNGCollection : ActiveList<PENGADAAN_LANGSUNG, PENGADAAN_LANGSUNGCollection> 
	{	   
		public PENGADAAN_LANGSUNGCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the PENGADAAN_LANGSUNG table.
	/// </summary>
	[Serializable]
	public partial class PENGADAAN_LANGSUNG : ActiveRecord<PENGADAAN_LANGSUNG>
	{
		#region .ctors and Default Settings
		
		public PENGADAAN_LANGSUNG()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public PENGADAAN_LANGSUNG(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public PENGADAAN_LANGSUNG(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public PENGADAAN_LANGSUNG(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PENGADAAN_LANGSUNG", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEPENGADAANLANGSUNG = new TableSchema.TableColumn(schema);
				colvarKODEPENGADAANLANGSUNG.ColumnName = "KODEPENGADAANLANGSUNG";
				colvarKODEPENGADAANLANGSUNG.DataType = DbType.String;
				colvarKODEPENGADAANLANGSUNG.MaxLength = 50;
				colvarKODEPENGADAANLANGSUNG.AutoIncrement = false;
				colvarKODEPENGADAANLANGSUNG.IsNullable = false;
				colvarKODEPENGADAANLANGSUNG.IsPrimaryKey = true;
				colvarKODEPENGADAANLANGSUNG.IsForeignKey = false;
				colvarKODEPENGADAANLANGSUNG.IsReadOnly = false;
				colvarKODEPENGADAANLANGSUNG.DefaultSetting = @"";
				colvarKODEPENGADAANLANGSUNG.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEPENGADAANLANGSUNG);
				
				TableSchema.TableColumn colvarNAMAKEGIATAN = new TableSchema.TableColumn(schema);
				colvarNAMAKEGIATAN.ColumnName = "NAMAKEGIATAN";
				colvarNAMAKEGIATAN.DataType = DbType.String;
				colvarNAMAKEGIATAN.MaxLength = 255;
				colvarNAMAKEGIATAN.AutoIncrement = false;
				colvarNAMAKEGIATAN.IsNullable = true;
				colvarNAMAKEGIATAN.IsPrimaryKey = false;
				colvarNAMAKEGIATAN.IsForeignKey = false;
				colvarNAMAKEGIATAN.IsReadOnly = false;
				colvarNAMAKEGIATAN.DefaultSetting = @"";
				colvarNAMAKEGIATAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNAMAKEGIATAN);
				
				TableSchema.TableColumn colvarNAMAPAKET = new TableSchema.TableColumn(schema);
				colvarNAMAPAKET.ColumnName = "NAMAPAKET";
				colvarNAMAPAKET.DataType = DbType.String;
				colvarNAMAPAKET.MaxLength = 255;
				colvarNAMAPAKET.AutoIncrement = false;
				colvarNAMAPAKET.IsNullable = true;
				colvarNAMAPAKET.IsPrimaryKey = false;
				colvarNAMAPAKET.IsForeignKey = false;
				colvarNAMAPAKET.IsReadOnly = false;
				colvarNAMAPAKET.DefaultSetting = @"";
				colvarNAMAPAKET.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNAMAPAKET);
				
				TableSchema.TableColumn colvarKODESKPD = new TableSchema.TableColumn(schema);
				colvarKODESKPD.ColumnName = "KODESKPD";
				colvarKODESKPD.DataType = DbType.String;
				colvarKODESKPD.MaxLength = 10;
				colvarKODESKPD.AutoIncrement = false;
				colvarKODESKPD.IsNullable = true;
				colvarKODESKPD.IsPrimaryKey = false;
				colvarKODESKPD.IsForeignKey = true;
				colvarKODESKPD.IsReadOnly = false;
				colvarKODESKPD.DefaultSetting = @"";
				
					colvarKODESKPD.ForeignKeyTableName = "SKPD";
				schema.Columns.Add(colvarKODESKPD);
				
				TableSchema.TableColumn colvarTANGGALKONTRAK = new TableSchema.TableColumn(schema);
				colvarTANGGALKONTRAK.ColumnName = "TANGGALKONTRAK";
				colvarTANGGALKONTRAK.DataType = DbType.DateTime;
				colvarTANGGALKONTRAK.MaxLength = 0;
				colvarTANGGALKONTRAK.AutoIncrement = false;
				colvarTANGGALKONTRAK.IsNullable = true;
				colvarTANGGALKONTRAK.IsPrimaryKey = false;
				colvarTANGGALKONTRAK.IsForeignKey = false;
				colvarTANGGALKONTRAK.IsReadOnly = false;
				colvarTANGGALKONTRAK.DefaultSetting = @"";
				colvarTANGGALKONTRAK.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGALKONTRAK);
				
				TableSchema.TableColumn colvarPAGU = new TableSchema.TableColumn(schema);
				colvarPAGU.ColumnName = "PAGU";
				colvarPAGU.DataType = DbType.Currency;
				colvarPAGU.MaxLength = 0;
				colvarPAGU.AutoIncrement = false;
				colvarPAGU.IsNullable = true;
				colvarPAGU.IsPrimaryKey = false;
				colvarPAGU.IsForeignKey = false;
				colvarPAGU.IsReadOnly = false;
				colvarPAGU.DefaultSetting = @"";
				colvarPAGU.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPAGU);
				
				TableSchema.TableColumn colvarHPS = new TableSchema.TableColumn(schema);
				colvarHPS.ColumnName = "HPS";
				colvarHPS.DataType = DbType.Currency;
				colvarHPS.MaxLength = 0;
				colvarHPS.AutoIncrement = false;
				colvarHPS.IsNullable = true;
				colvarHPS.IsPrimaryKey = false;
				colvarHPS.IsForeignKey = false;
				colvarHPS.IsReadOnly = false;
				colvarHPS.DefaultSetting = @"";
				colvarHPS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHPS);
				
				TableSchema.TableColumn colvarNILAIKONTRAK = new TableSchema.TableColumn(schema);
				colvarNILAIKONTRAK.ColumnName = "NILAIKONTRAK";
				colvarNILAIKONTRAK.DataType = DbType.Currency;
				colvarNILAIKONTRAK.MaxLength = 0;
				colvarNILAIKONTRAK.AutoIncrement = false;
				colvarNILAIKONTRAK.IsNullable = true;
				colvarNILAIKONTRAK.IsPrimaryKey = false;
				colvarNILAIKONTRAK.IsForeignKey = false;
				colvarNILAIKONTRAK.IsReadOnly = false;
				colvarNILAIKONTRAK.DefaultSetting = @"";
				colvarNILAIKONTRAK.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNILAIKONTRAK);
				
				TableSchema.TableColumn colvarPEMENANG = new TableSchema.TableColumn(schema);
				colvarPEMENANG.ColumnName = "PEMENANG";
				colvarPEMENANG.DataType = DbType.String;
				colvarPEMENANG.MaxLength = 255;
				colvarPEMENANG.AutoIncrement = false;
				colvarPEMENANG.IsNullable = true;
				colvarPEMENANG.IsPrimaryKey = false;
				colvarPEMENANG.IsForeignKey = false;
				colvarPEMENANG.IsReadOnly = false;
				colvarPEMENANG.DefaultSetting = @"";
				colvarPEMENANG.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPEMENANG);
				
				TableSchema.TableColumn colvarKETERANGAN = new TableSchema.TableColumn(schema);
				colvarKETERANGAN.ColumnName = "KETERANGAN";
				colvarKETERANGAN.DataType = DbType.String;
				colvarKETERANGAN.MaxLength = 255;
				colvarKETERANGAN.AutoIncrement = false;
				colvarKETERANGAN.IsNullable = true;
				colvarKETERANGAN.IsPrimaryKey = false;
				colvarKETERANGAN.IsForeignKey = false;
				colvarKETERANGAN.IsReadOnly = false;
				colvarKETERANGAN.DefaultSetting = @"";
				colvarKETERANGAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKETERANGAN);
				
				TableSchema.TableColumn colvarPEJABATPENGADAAN = new TableSchema.TableColumn(schema);
				colvarPEJABATPENGADAAN.ColumnName = "PEJABATPENGADAAN";
				colvarPEJABATPENGADAAN.DataType = DbType.String;
				colvarPEJABATPENGADAAN.MaxLength = 18;
				colvarPEJABATPENGADAAN.AutoIncrement = false;
				colvarPEJABATPENGADAAN.IsNullable = true;
				colvarPEJABATPENGADAAN.IsPrimaryKey = false;
				colvarPEJABATPENGADAAN.IsForeignKey = true;
				colvarPEJABATPENGADAAN.IsReadOnly = false;
				colvarPEJABATPENGADAAN.DefaultSetting = @"";
				
					colvarPEJABATPENGADAAN.ForeignKeyTableName = "AKTOR";
				schema.Columns.Add(colvarPEJABATPENGADAAN);
				
				TableSchema.TableColumn colvarMENGETAHUI = new TableSchema.TableColumn(schema);
				colvarMENGETAHUI.ColumnName = "MENGETAHUI";
				colvarMENGETAHUI.DataType = DbType.String;
				colvarMENGETAHUI.MaxLength = 18;
				colvarMENGETAHUI.AutoIncrement = false;
				colvarMENGETAHUI.IsNullable = true;
				colvarMENGETAHUI.IsPrimaryKey = false;
				colvarMENGETAHUI.IsForeignKey = true;
				colvarMENGETAHUI.IsReadOnly = false;
				colvarMENGETAHUI.DefaultSetting = @"";
				
					colvarMENGETAHUI.ForeignKeyTableName = "AKTOR";
				schema.Columns.Add(colvarMENGETAHUI);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("PENGADAAN_LANGSUNG",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEPENGADAANLANGSUNG")]
		public string KODEPENGADAANLANGSUNG 
		{
			get { return GetColumnValue<string>("KODEPENGADAANLANGSUNG"); }

			set { SetColumnValue("KODEPENGADAANLANGSUNG", value); }

		}

		  
		[XmlAttribute("NAMAKEGIATAN")]
		public string NAMAKEGIATAN 
		{
			get { return GetColumnValue<string>("NAMAKEGIATAN"); }

			set { SetColumnValue("NAMAKEGIATAN", value); }

		}

		  
		[XmlAttribute("NAMAPAKET")]
		public string NAMAPAKET 
		{
			get { return GetColumnValue<string>("NAMAPAKET"); }

			set { SetColumnValue("NAMAPAKET", value); }

		}

		  
		[XmlAttribute("KODESKPD")]
		public string KODESKPD 
		{
			get { return GetColumnValue<string>("KODESKPD"); }

			set { SetColumnValue("KODESKPD", value); }

		}

		  
		[XmlAttribute("TANGGALKONTRAK")]
		public DateTime? TANGGALKONTRAK 
		{
			get { return GetColumnValue<DateTime?>("TANGGALKONTRAK"); }

			set { SetColumnValue("TANGGALKONTRAK", value); }

		}

		  
		[XmlAttribute("PAGU")]
		public decimal? PAGU 
		{
			get { return GetColumnValue<decimal?>("PAGU"); }

			set { SetColumnValue("PAGU", value); }

		}

		  
		[XmlAttribute("HPS")]
		public decimal? HPS 
		{
			get { return GetColumnValue<decimal?>("HPS"); }

			set { SetColumnValue("HPS", value); }

		}

		  
		[XmlAttribute("NILAIKONTRAK")]
		public decimal? NILAIKONTRAK 
		{
			get { return GetColumnValue<decimal?>("NILAIKONTRAK"); }

			set { SetColumnValue("NILAIKONTRAK", value); }

		}

		  
		[XmlAttribute("PEMENANG")]
		public string PEMENANG 
		{
			get { return GetColumnValue<string>("PEMENANG"); }

			set { SetColumnValue("PEMENANG", value); }

		}

		  
		[XmlAttribute("KETERANGAN")]
		public string KETERANGAN 
		{
			get { return GetColumnValue<string>("KETERANGAN"); }

			set { SetColumnValue("KETERANGAN", value); }

		}

		  
		[XmlAttribute("PEJABATPENGADAAN")]
		public string PEJABATPENGADAAN 
		{
			get { return GetColumnValue<string>("PEJABATPENGADAAN"); }

			set { SetColumnValue("PEJABATPENGADAAN", value); }

		}

		  
		[XmlAttribute("MENGETAHUI")]
		public string MENGETAHUI 
		{
			get { return GetColumnValue<string>("MENGETAHUI"); }

			set { SetColumnValue("MENGETAHUI", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AKTOR ActiveRecord object related to this PENGADAAN_LANGSUNG
		/// 
		/// </summary>
		public Data.AKTOR AKTOR
		{
			get { return Data.AKTOR.FetchByID(this.PEJABATPENGADAAN); }

			set { SetColumnValue("PEJABATPENGADAAN", value.NIP); }

		}

		
		
		/// <summary>
		/// Returns a AKTOR ActiveRecord object related to this PENGADAAN_LANGSUNG
		/// 
		/// </summary>
		public Data.AKTOR AKTORToMENGETAHUI
		{
			get { return Data.AKTOR.FetchByID(this.MENGETAHUI); }

			set { SetColumnValue("MENGETAHUI", value.NIP); }

		}

		
		
		/// <summary>
		/// Returns a SKPD ActiveRecord object related to this PENGADAAN_LANGSUNG
		/// 
		/// </summary>
		public Data.SKPD SKPD
		{
			get { return Data.SKPD.FetchByID(this.KODESKPD); }

			set { SetColumnValue("KODESKPD", value.KODESKPD); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEPENGADAANLANGSUNG,string varNAMAKEGIATAN,string varNAMAPAKET,string varKODESKPD,DateTime? varTANGGALKONTRAK,decimal? varPAGU,decimal? varHPS,decimal? varNILAIKONTRAK,string varPEMENANG,string varKETERANGAN,string varPEJABATPENGADAAN,string varMENGETAHUI)
		{
			PENGADAAN_LANGSUNG item = new PENGADAAN_LANGSUNG();
			
			item.KODEPENGADAANLANGSUNG = varKODEPENGADAANLANGSUNG;
			
			item.NAMAKEGIATAN = varNAMAKEGIATAN;
			
			item.NAMAPAKET = varNAMAPAKET;
			
			item.KODESKPD = varKODESKPD;
			
			item.TANGGALKONTRAK = varTANGGALKONTRAK;
			
			item.PAGU = varPAGU;
			
			item.HPS = varHPS;
			
			item.NILAIKONTRAK = varNILAIKONTRAK;
			
			item.PEMENANG = varPEMENANG;
			
			item.KETERANGAN = varKETERANGAN;
			
			item.PEJABATPENGADAAN = varPEJABATPENGADAAN;
			
			item.MENGETAHUI = varMENGETAHUI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEPENGADAANLANGSUNG,string varNAMAKEGIATAN,string varNAMAPAKET,string varKODESKPD,DateTime? varTANGGALKONTRAK,decimal? varPAGU,decimal? varHPS,decimal? varNILAIKONTRAK,string varPEMENANG,string varKETERANGAN,string varPEJABATPENGADAAN,string varMENGETAHUI)
		{
			PENGADAAN_LANGSUNG item = new PENGADAAN_LANGSUNG();
			
				item.KODEPENGADAANLANGSUNG = varKODEPENGADAANLANGSUNG;
				
				item.NAMAKEGIATAN = varNAMAKEGIATAN;
				
				item.NAMAPAKET = varNAMAPAKET;
				
				item.KODESKPD = varKODESKPD;
				
				item.TANGGALKONTRAK = varTANGGALKONTRAK;
				
				item.PAGU = varPAGU;
				
				item.HPS = varHPS;
				
				item.NILAIKONTRAK = varNILAIKONTRAK;
				
				item.PEMENANG = varPEMENANG;
				
				item.KETERANGAN = varKETERANGAN;
				
				item.PEJABATPENGADAAN = varPEJABATPENGADAAN;
				
				item.MENGETAHUI = varMENGETAHUI;
				
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
			 public static string KODEPENGADAANLANGSUNG = @"KODEPENGADAANLANGSUNG";
			 public static string NAMAKEGIATAN = @"NAMAKEGIATAN";
			 public static string NAMAPAKET = @"NAMAPAKET";
			 public static string KODESKPD = @"KODESKPD";
			 public static string TANGGALKONTRAK = @"TANGGALKONTRAK";
			 public static string PAGU = @"PAGU";
			 public static string HPS = @"HPS";
			 public static string NILAIKONTRAK = @"NILAIKONTRAK";
			 public static string PEMENANG = @"PEMENANG";
			 public static string KETERANGAN = @"KETERANGAN";
			 public static string PEJABATPENGADAAN = @"PEJABATPENGADAAN";
			 public static string MENGETAHUI = @"MENGETAHUI";
						
		}

		#endregion
	}

}

