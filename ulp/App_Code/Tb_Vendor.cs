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
	/// Strongly-typed collection for the Tb_Vendor class.
	/// </summary>
	[Serializable]
	public partial class Tb_VendorCollection : ActiveList<Tb_Vendor, Tb_VendorCollection> 
	{	   
		public Tb_VendorCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Tb_Vendor table.
	/// </summary>
	[Serializable]
	public partial class Tb_Vendor : ActiveRecord<Tb_Vendor>
	{
		#region .ctors and Default Settings
		
		public Tb_Vendor()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Tb_Vendor(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Tb_Vendor(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Tb_Vendor(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tb_Vendor", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKD_VENDOR = new TableSchema.TableColumn(schema);
				colvarKD_VENDOR.ColumnName = "KD_VENDOR";
				colvarKD_VENDOR.DataType = DbType.Int32;
				colvarKD_VENDOR.MaxLength = 0;
				colvarKD_VENDOR.AutoIncrement = true;
				colvarKD_VENDOR.IsNullable = false;
				colvarKD_VENDOR.IsPrimaryKey = true;
				colvarKD_VENDOR.IsForeignKey = false;
				colvarKD_VENDOR.IsReadOnly = false;
				colvarKD_VENDOR.DefaultSetting = @"";
				colvarKD_VENDOR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKD_VENDOR);
				
				TableSchema.TableColumn colvarNAMA = new TableSchema.TableColumn(schema);
				colvarNAMA.ColumnName = "NAMA";
				colvarNAMA.DataType = DbType.String;
				colvarNAMA.MaxLength = 255;
				colvarNAMA.AutoIncrement = false;
				colvarNAMA.IsNullable = true;
				colvarNAMA.IsPrimaryKey = false;
				colvarNAMA.IsForeignKey = false;
				colvarNAMA.IsReadOnly = false;
				colvarNAMA.DefaultSetting = @"";
				colvarNAMA.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNAMA);
				
				TableSchema.TableColumn colvarALAMAT = new TableSchema.TableColumn(schema);
				colvarALAMAT.ColumnName = "ALAMAT";
				colvarALAMAT.DataType = DbType.String;
				colvarALAMAT.MaxLength = 255;
				colvarALAMAT.AutoIncrement = false;
				colvarALAMAT.IsNullable = true;
				colvarALAMAT.IsPrimaryKey = false;
				colvarALAMAT.IsForeignKey = false;
				colvarALAMAT.IsReadOnly = false;
				colvarALAMAT.DefaultSetting = @"";
				colvarALAMAT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarALAMAT);
				
				TableSchema.TableColumn colvarNPWP = new TableSchema.TableColumn(schema);
				colvarNPWP.ColumnName = "NPWP";
				colvarNPWP.DataType = DbType.String;
				colvarNPWP.MaxLength = 255;
				colvarNPWP.AutoIncrement = false;
				colvarNPWP.IsNullable = true;
				colvarNPWP.IsPrimaryKey = false;
				colvarNPWP.IsForeignKey = false;
				colvarNPWP.IsReadOnly = false;
				colvarNPWP.DefaultSetting = @"";
				colvarNPWP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNPWP);
				
				TableSchema.TableColumn colvarTELEPON = new TableSchema.TableColumn(schema);
				colvarTELEPON.ColumnName = "TELEPON";
				colvarTELEPON.DataType = DbType.String;
				colvarTELEPON.MaxLength = 50;
				colvarTELEPON.AutoIncrement = false;
				colvarTELEPON.IsNullable = true;
				colvarTELEPON.IsPrimaryKey = false;
				colvarTELEPON.IsForeignKey = false;
				colvarTELEPON.IsReadOnly = false;
				colvarTELEPON.DefaultSetting = @"";
				colvarTELEPON.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTELEPON);
				
				TableSchema.TableColumn colvarFAX = new TableSchema.TableColumn(schema);
				colvarFAX.ColumnName = "FAX";
				colvarFAX.DataType = DbType.String;
				colvarFAX.MaxLength = 50;
				colvarFAX.AutoIncrement = false;
				colvarFAX.IsNullable = true;
				colvarFAX.IsPrimaryKey = false;
				colvarFAX.IsForeignKey = false;
				colvarFAX.IsReadOnly = false;
				colvarFAX.DefaultSetting = @"";
				colvarFAX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFAX);
				
				TableSchema.TableColumn colvarEMAIL = new TableSchema.TableColumn(schema);
				colvarEMAIL.ColumnName = "EMAIL";
				colvarEMAIL.DataType = DbType.String;
				colvarEMAIL.MaxLength = 50;
				colvarEMAIL.AutoIncrement = false;
				colvarEMAIL.IsNullable = true;
				colvarEMAIL.IsPrimaryKey = false;
				colvarEMAIL.IsForeignKey = false;
				colvarEMAIL.IsReadOnly = false;
				colvarEMAIL.DefaultSetting = @"";
				colvarEMAIL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEMAIL);
				
				TableSchema.TableColumn colvarSTATUS = new TableSchema.TableColumn(schema);
				colvarSTATUS.ColumnName = "STATUS";
				colvarSTATUS.DataType = DbType.Boolean;
				colvarSTATUS.MaxLength = 0;
				colvarSTATUS.AutoIncrement = false;
				colvarSTATUS.IsNullable = true;
				colvarSTATUS.IsPrimaryKey = false;
				colvarSTATUS.IsForeignKey = false;
				colvarSTATUS.IsReadOnly = false;
				colvarSTATUS.DefaultSetting = @"";
				colvarSTATUS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSTATUS);
				
				TableSchema.TableColumn colvarTANGGAL_DIBUAT = new TableSchema.TableColumn(schema);
				colvarTANGGAL_DIBUAT.ColumnName = "TANGGAL_DIBUAT";
				colvarTANGGAL_DIBUAT.DataType = DbType.DateTime;
				colvarTANGGAL_DIBUAT.MaxLength = 0;
				colvarTANGGAL_DIBUAT.AutoIncrement = false;
				colvarTANGGAL_DIBUAT.IsNullable = true;
				colvarTANGGAL_DIBUAT.IsPrimaryKey = false;
				colvarTANGGAL_DIBUAT.IsForeignKey = false;
				colvarTANGGAL_DIBUAT.IsReadOnly = false;
				colvarTANGGAL_DIBUAT.DefaultSetting = @"";
				colvarTANGGAL_DIBUAT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGAL_DIBUAT);
				
				TableSchema.TableColumn colvarDIBUAT_OLEH = new TableSchema.TableColumn(schema);
				colvarDIBUAT_OLEH.ColumnName = "DIBUAT_OLEH";
				colvarDIBUAT_OLEH.DataType = DbType.String;
				colvarDIBUAT_OLEH.MaxLength = 50;
				colvarDIBUAT_OLEH.AutoIncrement = false;
				colvarDIBUAT_OLEH.IsNullable = true;
				colvarDIBUAT_OLEH.IsPrimaryKey = false;
				colvarDIBUAT_OLEH.IsForeignKey = false;
				colvarDIBUAT_OLEH.IsReadOnly = false;
				colvarDIBUAT_OLEH.DefaultSetting = @"";
				colvarDIBUAT_OLEH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDIBUAT_OLEH);
				
				TableSchema.TableColumn colvarTANGGAL_MODIFIKASI = new TableSchema.TableColumn(schema);
				colvarTANGGAL_MODIFIKASI.ColumnName = "TANGGAL_MODIFIKASI";
				colvarTANGGAL_MODIFIKASI.DataType = DbType.DateTime;
				colvarTANGGAL_MODIFIKASI.MaxLength = 0;
				colvarTANGGAL_MODIFIKASI.AutoIncrement = false;
				colvarTANGGAL_MODIFIKASI.IsNullable = true;
				colvarTANGGAL_MODIFIKASI.IsPrimaryKey = false;
				colvarTANGGAL_MODIFIKASI.IsForeignKey = false;
				colvarTANGGAL_MODIFIKASI.IsReadOnly = false;
				colvarTANGGAL_MODIFIKASI.DefaultSetting = @"";
				colvarTANGGAL_MODIFIKASI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGAL_MODIFIKASI);
				
				TableSchema.TableColumn colvarMODIFIKASI_OLEH = new TableSchema.TableColumn(schema);
				colvarMODIFIKASI_OLEH.ColumnName = "MODIFIKASI_OLEH";
				colvarMODIFIKASI_OLEH.DataType = DbType.String;
				colvarMODIFIKASI_OLEH.MaxLength = 50;
				colvarMODIFIKASI_OLEH.AutoIncrement = false;
				colvarMODIFIKASI_OLEH.IsNullable = true;
				colvarMODIFIKASI_OLEH.IsPrimaryKey = false;
				colvarMODIFIKASI_OLEH.IsForeignKey = false;
				colvarMODIFIKASI_OLEH.IsReadOnly = false;
				colvarMODIFIKASI_OLEH.DefaultSetting = @"";
				colvarMODIFIKASI_OLEH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMODIFIKASI_OLEH);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("Tb_Vendor",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KD_VENDOR")]
		public int KD_VENDOR 
		{
			get { return GetColumnValue<int>("KD_VENDOR"); }

			set { SetColumnValue("KD_VENDOR", value); }

		}

		  
		[XmlAttribute("NAMA")]
		public string NAMA 
		{
			get { return GetColumnValue<string>("NAMA"); }

			set { SetColumnValue("NAMA", value); }

		}

		  
		[XmlAttribute("ALAMAT")]
		public string ALAMAT 
		{
			get { return GetColumnValue<string>("ALAMAT"); }

			set { SetColumnValue("ALAMAT", value); }

		}

		  
		[XmlAttribute("NPWP")]
		public string NPWP 
		{
			get { return GetColumnValue<string>("NPWP"); }

			set { SetColumnValue("NPWP", value); }

		}

		  
		[XmlAttribute("TELEPON")]
		public string TELEPON 
		{
			get { return GetColumnValue<string>("TELEPON"); }

			set { SetColumnValue("TELEPON", value); }

		}

		  
		[XmlAttribute("FAX")]
		public string FAX 
		{
			get { return GetColumnValue<string>("FAX"); }

			set { SetColumnValue("FAX", value); }

		}

		  
		[XmlAttribute("EMAIL")]
		public string EMAIL 
		{
			get { return GetColumnValue<string>("EMAIL"); }

			set { SetColumnValue("EMAIL", value); }

		}

		  
		[XmlAttribute("STATUS")]
		public bool? STATUS 
		{
			get { return GetColumnValue<bool?>("STATUS"); }

			set { SetColumnValue("STATUS", value); }

		}

		  
		[XmlAttribute("TANGGAL_DIBUAT")]
		public DateTime? TANGGAL_DIBUAT 
		{
			get { return GetColumnValue<DateTime?>("TANGGAL_DIBUAT"); }

			set { SetColumnValue("TANGGAL_DIBUAT", value); }

		}

		  
		[XmlAttribute("DIBUAT_OLEH")]
		public string DIBUAT_OLEH 
		{
			get { return GetColumnValue<string>("DIBUAT_OLEH"); }

			set { SetColumnValue("DIBUAT_OLEH", value); }

		}

		  
		[XmlAttribute("TANGGAL_MODIFIKASI")]
		public DateTime? TANGGAL_MODIFIKASI 
		{
			get { return GetColumnValue<DateTime?>("TANGGAL_MODIFIKASI"); }

			set { SetColumnValue("TANGGAL_MODIFIKASI", value); }

		}

		  
		[XmlAttribute("MODIFIKASI_OLEH")]
		public string MODIFIKASI_OLEH 
		{
			get { return GetColumnValue<string>("MODIFIKASI_OLEH"); }

			set { SetColumnValue("MODIFIKASI_OLEH", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		/*public Data.Tb_KontrakCollection Tb_KontrakRecords()
		{
			return new Data.Tb_KontrakCollection().Where(Tb_Kontrak.Columns.KD_VENDOR, KD_VENDOR).Load();
		}*/

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNAMA,string varALAMAT,string varNPWP,string varTELEPON,string varFAX,string varEMAIL,bool? varSTATUS,DateTime? varTANGGAL_DIBUAT,string varDIBUAT_OLEH,DateTime? varTANGGAL_MODIFIKASI,string varMODIFIKASI_OLEH)
		{
			Tb_Vendor item = new Tb_Vendor();
			
			item.NAMA = varNAMA;
			
			item.ALAMAT = varALAMAT;
			
			item.NPWP = varNPWP;
			
			item.TELEPON = varTELEPON;
			
			item.FAX = varFAX;
			
			item.EMAIL = varEMAIL;
			
			item.STATUS = varSTATUS;
			
			item.TANGGAL_DIBUAT = varTANGGAL_DIBUAT;
			
			item.DIBUAT_OLEH = varDIBUAT_OLEH;
			
			item.TANGGAL_MODIFIKASI = varTANGGAL_MODIFIKASI;
			
			item.MODIFIKASI_OLEH = varMODIFIKASI_OLEH;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varKD_VENDOR,string varNAMA,string varALAMAT,string varNPWP,string varTELEPON,string varFAX,string varEMAIL,bool? varSTATUS,DateTime? varTANGGAL_DIBUAT,string varDIBUAT_OLEH,DateTime? varTANGGAL_MODIFIKASI,string varMODIFIKASI_OLEH)
		{
			Tb_Vendor item = new Tb_Vendor();
			
				item.KD_VENDOR = varKD_VENDOR;
				
				item.NAMA = varNAMA;
				
				item.ALAMAT = varALAMAT;
				
				item.NPWP = varNPWP;
				
				item.TELEPON = varTELEPON;
				
				item.FAX = varFAX;
				
				item.EMAIL = varEMAIL;
				
				item.STATUS = varSTATUS;
				
				item.TANGGAL_DIBUAT = varTANGGAL_DIBUAT;
				
				item.DIBUAT_OLEH = varDIBUAT_OLEH;
				
				item.TANGGAL_MODIFIKASI = varTANGGAL_MODIFIKASI;
				
				item.MODIFIKASI_OLEH = varMODIFIKASI_OLEH;
				
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
			 public static string KD_VENDOR = @"KD_VENDOR";
			 public static string NAMA = @"NAMA";
			 public static string ALAMAT = @"ALAMAT";
			 public static string NPWP = @"NPWP";
			 public static string TELEPON = @"TELEPON";
			 public static string FAX = @"FAX";
			 public static string EMAIL = @"EMAIL";
			 public static string STATUS = @"STATUS";
			 public static string TANGGAL_DIBUAT = @"TANGGAL_DIBUAT";
			 public static string DIBUAT_OLEH = @"DIBUAT_OLEH";
			 public static string TANGGAL_MODIFIKASI = @"TANGGAL_MODIFIKASI";
			 public static string MODIFIKASI_OLEH = @"MODIFIKASI_OLEH";
						
		}

		#endregion
	}

}

