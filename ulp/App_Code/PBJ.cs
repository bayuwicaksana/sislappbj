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
	/// Strongly-typed collection for the PBJ class.
	/// </summary>
	[Serializable]
	public partial class PBJCollection : ActiveList<PBJ, PBJCollection> 
	{	   
		public PBJCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the PBJ table.
	/// </summary>
	[Serializable]
	public partial class PBJ : ActiveRecord<PBJ>
	{
		#region .ctors and Default Settings
		
		public PBJ()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public PBJ(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public PBJ(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public PBJ(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PBJ", TableType.Table, DataService.GetInstance("MyProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKODEPBJ = new TableSchema.TableColumn(schema);
				colvarKODEPBJ.ColumnName = "KODEPBJ";
				colvarKODEPBJ.DataType = DbType.String;
				colvarKODEPBJ.MaxLength = 15;
				colvarKODEPBJ.AutoIncrement = false;
				colvarKODEPBJ.IsNullable = false;
				colvarKODEPBJ.IsPrimaryKey = true;
				colvarKODEPBJ.IsForeignKey = false;
				colvarKODEPBJ.IsReadOnly = false;
				colvarKODEPBJ.DefaultSetting = @"";
				colvarKODEPBJ.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKODEPBJ);
				
				TableSchema.TableColumn colvarNAMAKEGIATAN = new TableSchema.TableColumn(schema);
				colvarNAMAKEGIATAN.ColumnName = "NAMAKEGIATAN";
				colvarNAMAKEGIATAN.DataType = DbType.String;
				colvarNAMAKEGIATAN.MaxLength = 100;
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
				colvarNAMAPAKET.MaxLength = 100;
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
				
				TableSchema.TableColumn colvarPPK = new TableSchema.TableColumn(schema);
				colvarPPK.ColumnName = "PPK";
				colvarPPK.DataType = DbType.String;
				colvarPPK.MaxLength = 18;
				colvarPPK.AutoIncrement = false;
				colvarPPK.IsNullable = true;
				colvarPPK.IsPrimaryKey = false;
				colvarPPK.IsForeignKey = true;
				colvarPPK.IsReadOnly = false;
				colvarPPK.DefaultSetting = @"";
				
					colvarPPK.ForeignKeyTableName = "AKTOR";
				schema.Columns.Add(colvarPPK);
				
				TableSchema.TableColumn colvarPPTK = new TableSchema.TableColumn(schema);
				colvarPPTK.ColumnName = "PPTK";
				colvarPPTK.DataType = DbType.String;
				colvarPPTK.MaxLength = 18;
				colvarPPTK.AutoIncrement = false;
				colvarPPTK.IsNullable = true;
				colvarPPTK.IsPrimaryKey = false;
				colvarPPTK.IsForeignKey = true;
				colvarPPTK.IsReadOnly = false;
				colvarPPTK.DefaultSetting = @"";
				
					colvarPPTK.ForeignKeyTableName = "AKTOR";
				schema.Columns.Add(colvarPPTK);
				
				TableSchema.TableColumn colvarKODEJENISKEGIATAN = new TableSchema.TableColumn(schema);
				colvarKODEJENISKEGIATAN.ColumnName = "KODEJENISKEGIATAN";
				colvarKODEJENISKEGIATAN.DataType = DbType.String;
				colvarKODEJENISKEGIATAN.MaxLength = 10;
				colvarKODEJENISKEGIATAN.AutoIncrement = false;
				colvarKODEJENISKEGIATAN.IsNullable = true;
				colvarKODEJENISKEGIATAN.IsPrimaryKey = false;
				colvarKODEJENISKEGIATAN.IsForeignKey = true;
				colvarKODEJENISKEGIATAN.IsReadOnly = false;
				colvarKODEJENISKEGIATAN.DefaultSetting = @"";
				
					colvarKODEJENISKEGIATAN.ForeignKeyTableName = "JENISKEGIATAN";
				schema.Columns.Add(colvarKODEJENISKEGIATAN);
				
				TableSchema.TableColumn colvarPROSESPENGADAAN = new TableSchema.TableColumn(schema);
				colvarPROSESPENGADAAN.ColumnName = "PROSESPENGADAAN";
				colvarPROSESPENGADAAN.DataType = DbType.String;
				colvarPROSESPENGADAAN.MaxLength = 500;
				colvarPROSESPENGADAAN.AutoIncrement = false;
				colvarPROSESPENGADAAN.IsNullable = true;
				colvarPROSESPENGADAAN.IsPrimaryKey = false;
				colvarPROSESPENGADAAN.IsForeignKey = false;
				colvarPROSESPENGADAAN.IsReadOnly = false;
				colvarPROSESPENGADAAN.DefaultSetting = @"";
				colvarPROSESPENGADAAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPROSESPENGADAAN);
				
				TableSchema.TableColumn colvarTANGGALPENGAJUAN = new TableSchema.TableColumn(schema);
				colvarTANGGALPENGAJUAN.ColumnName = "TANGGALPENGAJUAN";
				colvarTANGGALPENGAJUAN.DataType = DbType.DateTime;
				colvarTANGGALPENGAJUAN.MaxLength = 0;
				colvarTANGGALPENGAJUAN.AutoIncrement = false;
				colvarTANGGALPENGAJUAN.IsNullable = true;
				colvarTANGGALPENGAJUAN.IsPrimaryKey = false;
				colvarTANGGALPENGAJUAN.IsForeignKey = false;
				colvarTANGGALPENGAJUAN.IsReadOnly = false;
				colvarTANGGALPENGAJUAN.DefaultSetting = @"";
				colvarTANGGALPENGAJUAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGALPENGAJUAN);
				
				TableSchema.TableColumn colvarPEMBAWABERKAS1 = new TableSchema.TableColumn(schema);
				colvarPEMBAWABERKAS1.ColumnName = "PEMBAWABERKAS1";
				colvarPEMBAWABERKAS1.DataType = DbType.String;
				colvarPEMBAWABERKAS1.MaxLength = 100;
				colvarPEMBAWABERKAS1.AutoIncrement = false;
				colvarPEMBAWABERKAS1.IsNullable = true;
				colvarPEMBAWABERKAS1.IsPrimaryKey = false;
				colvarPEMBAWABERKAS1.IsForeignKey = false;
				colvarPEMBAWABERKAS1.IsReadOnly = false;
				colvarPEMBAWABERKAS1.DefaultSetting = @"";
				colvarPEMBAWABERKAS1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPEMBAWABERKAS1);
				
				TableSchema.TableColumn colvarPENERIMABERKAS1 = new TableSchema.TableColumn(schema);
				colvarPENERIMABERKAS1.ColumnName = "PENERIMABERKAS1";
				colvarPENERIMABERKAS1.DataType = DbType.String;
				colvarPENERIMABERKAS1.MaxLength = 50;
				colvarPENERIMABERKAS1.AutoIncrement = false;
				colvarPENERIMABERKAS1.IsNullable = true;
				colvarPENERIMABERKAS1.IsPrimaryKey = false;
				colvarPENERIMABERKAS1.IsForeignKey = false;
				colvarPENERIMABERKAS1.IsReadOnly = false;
				colvarPENERIMABERKAS1.DefaultSetting = @"";
				colvarPENERIMABERKAS1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPENERIMABERKAS1);
				
				TableSchema.TableColumn colvarPEMBAWABERKAS2 = new TableSchema.TableColumn(schema);
				colvarPEMBAWABERKAS2.ColumnName = "PEMBAWABERKAS2";
				colvarPEMBAWABERKAS2.DataType = DbType.String;
				colvarPEMBAWABERKAS2.MaxLength = 100;
				colvarPEMBAWABERKAS2.AutoIncrement = false;
				colvarPEMBAWABERKAS2.IsNullable = true;
				colvarPEMBAWABERKAS2.IsPrimaryKey = false;
				colvarPEMBAWABERKAS2.IsForeignKey = false;
				colvarPEMBAWABERKAS2.IsReadOnly = false;
				colvarPEMBAWABERKAS2.DefaultSetting = @"";
				colvarPEMBAWABERKAS2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPEMBAWABERKAS2);
				
				TableSchema.TableColumn colvarPENERIMABERKAS2 = new TableSchema.TableColumn(schema);
				colvarPENERIMABERKAS2.ColumnName = "PENERIMABERKAS2";
				colvarPENERIMABERKAS2.DataType = DbType.String;
				colvarPENERIMABERKAS2.MaxLength = 50;
				colvarPENERIMABERKAS2.AutoIncrement = false;
				colvarPENERIMABERKAS2.IsNullable = true;
				colvarPENERIMABERKAS2.IsPrimaryKey = false;
				colvarPENERIMABERKAS2.IsForeignKey = false;
				colvarPENERIMABERKAS2.IsReadOnly = false;
				colvarPENERIMABERKAS2.DefaultSetting = @"";
				colvarPENERIMABERKAS2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPENERIMABERKAS2);
				
				TableSchema.TableColumn colvarLENGKAP = new TableSchema.TableColumn(schema);
				colvarLENGKAP.ColumnName = "LENGKAP";
				colvarLENGKAP.DataType = DbType.String;
				colvarLENGKAP.MaxLength = 5;
				colvarLENGKAP.AutoIncrement = false;
				colvarLENGKAP.IsNullable = true;
				colvarLENGKAP.IsPrimaryKey = false;
				colvarLENGKAP.IsForeignKey = false;
				colvarLENGKAP.IsReadOnly = false;
				colvarLENGKAP.DefaultSetting = @"";
				colvarLENGKAP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLENGKAP);
				
				TableSchema.TableColumn colvarDIKEMBALIKAN = new TableSchema.TableColumn(schema);
				colvarDIKEMBALIKAN.ColumnName = "DIKEMBALIKAN";
				colvarDIKEMBALIKAN.DataType = DbType.String;
				colvarDIKEMBALIKAN.MaxLength = 5;
				colvarDIKEMBALIKAN.AutoIncrement = false;
				colvarDIKEMBALIKAN.IsNullable = true;
				colvarDIKEMBALIKAN.IsPrimaryKey = false;
				colvarDIKEMBALIKAN.IsForeignKey = false;
				colvarDIKEMBALIKAN.IsReadOnly = false;
				colvarDIKEMBALIKAN.DefaultSetting = @"";
				colvarDIKEMBALIKAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDIKEMBALIKAN);
				
				TableSchema.TableColumn colvarTANGGALKEMBALI = new TableSchema.TableColumn(schema);
				colvarTANGGALKEMBALI.ColumnName = "TANGGALKEMBALI";
				colvarTANGGALKEMBALI.DataType = DbType.DateTime;
				colvarTANGGALKEMBALI.MaxLength = 0;
				colvarTANGGALKEMBALI.AutoIncrement = false;
				colvarTANGGALKEMBALI.IsNullable = true;
				colvarTANGGALKEMBALI.IsPrimaryKey = false;
				colvarTANGGALKEMBALI.IsForeignKey = false;
				colvarTANGGALKEMBALI.IsReadOnly = false;
				colvarTANGGALKEMBALI.DefaultSetting = @"";
				colvarTANGGALKEMBALI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTANGGALKEMBALI);
				
				TableSchema.TableColumn colvarKODESTATUSPBJ = new TableSchema.TableColumn(schema);
				colvarKODESTATUSPBJ.ColumnName = "KODESTATUSPBJ";
				colvarKODESTATUSPBJ.DataType = DbType.String;
				colvarKODESTATUSPBJ.MaxLength = 20;
				colvarKODESTATUSPBJ.AutoIncrement = false;
				colvarKODESTATUSPBJ.IsNullable = true;
				colvarKODESTATUSPBJ.IsPrimaryKey = false;
				colvarKODESTATUSPBJ.IsForeignKey = true;
				colvarKODESTATUSPBJ.IsReadOnly = false;
				colvarKODESTATUSPBJ.DefaultSetting = @"";
				
					colvarKODESTATUSPBJ.ForeignKeyTableName = "STATUSPBJ";
				schema.Columns.Add(colvarKODESTATUSPBJ);
				
				TableSchema.TableColumn colvarCATATAN = new TableSchema.TableColumn(schema);
				colvarCATATAN.ColumnName = "CATATAN";
				colvarCATATAN.DataType = DbType.String;
				colvarCATATAN.MaxLength = 500;
				colvarCATATAN.AutoIncrement = false;
				colvarCATATAN.IsNullable = true;
				colvarCATATAN.IsPrimaryKey = false;
				colvarCATATAN.IsForeignKey = false;
				colvarCATATAN.IsReadOnly = false;
				colvarCATATAN.DefaultSetting = @"";
				colvarCATATAN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCATATAN);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["MyProvider"].AddSchema("PBJ",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("KODEPBJ")]
		public string KODEPBJ 
		{
			get { return GetColumnValue<string>("KODEPBJ"); }

			set { SetColumnValue("KODEPBJ", value); }

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

		  
		[XmlAttribute("PPK")]
		public string PPK 
		{
			get { return GetColumnValue<string>("PPK"); }

			set { SetColumnValue("PPK", value); }

		}

		  
		[XmlAttribute("PPTK")]
		public string PPTK 
		{
			get { return GetColumnValue<string>("PPTK"); }

			set { SetColumnValue("PPTK", value); }

		}

		  
		[XmlAttribute("KODEJENISKEGIATAN")]
		public string KODEJENISKEGIATAN 
		{
			get { return GetColumnValue<string>("KODEJENISKEGIATAN"); }

			set { SetColumnValue("KODEJENISKEGIATAN", value); }

		}

		  
		[XmlAttribute("PROSESPENGADAAN")]
		public string PROSESPENGADAAN 
		{
			get { return GetColumnValue<string>("PROSESPENGADAAN"); }

			set { SetColumnValue("PROSESPENGADAAN", value); }

		}

		  
		[XmlAttribute("TANGGALPENGAJUAN")]
		public DateTime? TANGGALPENGAJUAN 
		{
			get { return GetColumnValue<DateTime?>("TANGGALPENGAJUAN"); }

			set { SetColumnValue("TANGGALPENGAJUAN", value); }

		}

		  
		[XmlAttribute("PEMBAWABERKAS1")]
		public string PEMBAWABERKAS1 
		{
			get { return GetColumnValue<string>("PEMBAWABERKAS1"); }

			set { SetColumnValue("PEMBAWABERKAS1", value); }

		}

		  
		[XmlAttribute("PENERIMABERKAS1")]
		public string PENERIMABERKAS1 
		{
			get { return GetColumnValue<string>("PENERIMABERKAS1"); }

			set { SetColumnValue("PENERIMABERKAS1", value); }

		}

		  
		[XmlAttribute("PEMBAWABERKAS2")]
		public string PEMBAWABERKAS2 
		{
			get { return GetColumnValue<string>("PEMBAWABERKAS2"); }

			set { SetColumnValue("PEMBAWABERKAS2", value); }

		}

		  
		[XmlAttribute("PENERIMABERKAS2")]
		public string PENERIMABERKAS2 
		{
			get { return GetColumnValue<string>("PENERIMABERKAS2"); }

			set { SetColumnValue("PENERIMABERKAS2", value); }

		}

		  
		[XmlAttribute("LENGKAP")]
		public string LENGKAP 
		{
			get { return GetColumnValue<string>("LENGKAP"); }

			set { SetColumnValue("LENGKAP", value); }

		}

		  
		[XmlAttribute("DIKEMBALIKAN")]
		public string DIKEMBALIKAN 
		{
			get { return GetColumnValue<string>("DIKEMBALIKAN"); }

			set { SetColumnValue("DIKEMBALIKAN", value); }

		}

		  
		[XmlAttribute("TANGGALKEMBALI")]
		public DateTime? TANGGALKEMBALI 
		{
			get { return GetColumnValue<DateTime?>("TANGGALKEMBALI"); }

			set { SetColumnValue("TANGGALKEMBALI", value); }

		}

		  
		[XmlAttribute("KODESTATUSPBJ")]
		public string KODESTATUSPBJ 
		{
			get { return GetColumnValue<string>("KODESTATUSPBJ"); }

			set { SetColumnValue("KODESTATUSPBJ", value); }

		}

		  
		[XmlAttribute("CATATAN")]
		public string CATATAN 
		{
			get { return GetColumnValue<string>("CATATAN"); }

			set { SetColumnValue("CATATAN", value); }

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

		  
		[XmlAttribute("TANGGALMODIFIKASI")]
		public DateTime? TANGGALMODIFIKASI 
		{
			get { return GetColumnValue<DateTime?>("TANGGALMODIFIKASI"); }

			set { SetColumnValue("TANGGALMODIFIKASI", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public Data.KELENGKAPANPBJCollection KELENGKAPANPBJRecords()
		{
			return new Data.KELENGKAPANPBJCollection().Where(KELENGKAPANPBJ.Columns.KODEBPJ, KODEPBJ).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AKTOR ActiveRecord object related to this PBJ
		/// 
		/// </summary>
		public Data.AKTOR AKTOR
		{
			get { return Data.AKTOR.FetchByID(this.PPK); }

			set { SetColumnValue("PPK", value.NIP); }

		}

		
		
		/// <summary>
		/// Returns a AKTOR ActiveRecord object related to this PBJ
		/// 
		/// </summary>
		public Data.AKTOR AKTORToPPTK
		{
			get { return Data.AKTOR.FetchByID(this.PPTK); }

			set { SetColumnValue("PPTK", value.NIP); }

		}

		
		
		/// <summary>
		/// Returns a JENISKEGIATAN ActiveRecord object related to this PBJ
		/// 
		/// </summary>
		public Data.JENISKEGIATAN JENISKEGIATAN
		{
			get { return Data.JENISKEGIATAN.FetchByID(this.KODEJENISKEGIATAN); }

			set { SetColumnValue("KODEJENISKEGIATAN", value.KODEJENISKEGIATAN); }

		}

		
		
		/// <summary>
		/// Returns a SKPD ActiveRecord object related to this PBJ
		/// 
		/// </summary>
		public Data.SKPD SKPD
		{
			get { return Data.SKPD.FetchByID(this.KODESKPD); }

			set { SetColumnValue("KODESKPD", value.KODESKPD); }

		}

		
		
		/// <summary>
		/// Returns a STATUSPBJ ActiveRecord object related to this PBJ
		/// 
		/// </summary>
		public Data.STATUSPBJ STATUSPBJ
		{
			get { return Data.STATUSPBJ.FetchByID(this.KODESTATUSPBJ); }

			set { SetColumnValue("KODESTATUSPBJ", value.KODESTATUS); }

		}

		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public Data.KELENGKAPANCollection GetKELENGKAPANCollection() { return PBJ.GetKELENGKAPANCollection(this.KODEPBJ); }

		public static Data.KELENGKAPANCollection GetKELENGKAPANCollection(string varKODEPBJ)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM KELENGKAPAN INNER JOIN KELENGKAPANPBJ ON "+
				"KELENGKAPAN.KODEKELENGKAPAN=KELENGKAPANPBJ.KODEKELENGKAPAN WHERE KELENGKAPANPBJ.KODEBPJ=@KODEBPJ", PBJ.Schema.Provider.Name);
			
			cmd.AddParameter("@KODEBPJ", varKODEPBJ, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			KELENGKAPANCollection coll = new KELENGKAPANCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveKELENGKAPANMap(string varKODEPBJ, KELENGKAPANCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEBPJ=@KODEBPJ", PBJ.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEBPJ", varKODEPBJ);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (KELENGKAPAN item in items)
			{
				KELENGKAPANPBJ varKELENGKAPANPBJ = new KELENGKAPANPBJ();
				varKELENGKAPANPBJ.SetColumnValue("KODEBPJ", varKODEPBJ);
				varKELENGKAPANPBJ.SetColumnValue("KODEKELENGKAPAN", item.GetPrimaryKeyValue());
				varKELENGKAPANPBJ.Save();
			}

		}

		public static void SaveKELENGKAPANMap(string varKODEPBJ, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEBPJ=@KODEBPJ", PBJ.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEBPJ", varKODEPBJ);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					KELENGKAPANPBJ varKELENGKAPANPBJ = new KELENGKAPANPBJ();
					varKELENGKAPANPBJ.SetColumnValue("KODEBPJ", varKODEPBJ);
					varKELENGKAPANPBJ.SetColumnValue("KODEKELENGKAPAN", l.Value);
					varKELENGKAPANPBJ.Save();
				}

			}

		}

		public static void SaveKELENGKAPANMap(string varKODEPBJ , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEBPJ=@KODEBPJ", PBJ.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEBPJ", varKODEPBJ);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				KELENGKAPANPBJ varKELENGKAPANPBJ = new KELENGKAPANPBJ();
				varKELENGKAPANPBJ.SetColumnValue("KODEBPJ", varKODEPBJ);
				varKELENGKAPANPBJ.SetColumnValue("KODEKELENGKAPAN", item);
				varKELENGKAPANPBJ.Save();
			}

		}

		
		public static void DeleteKELENGKAPANMap(string varKODEPBJ) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM KELENGKAPANPBJ WHERE KODEBPJ=@KODEBPJ", PBJ.Schema.Provider.Name);
			cmdDel.AddParameter("@KODEBPJ", varKODEPBJ);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKODEPBJ,string varNAMAKEGIATAN,string varNAMAPAKET,string varKODESKPD,string varPPK,string varPPTK,string varKODEJENISKEGIATAN,string varPROSESPENGADAAN,DateTime? varTANGGALPENGAJUAN,string varPEMBAWABERKAS1,string varPENERIMABERKAS1,string varPEMBAWABERKAS2,string varPENERIMABERKAS2,string varLENGKAP,string varDIKEMBALIKAN,DateTime? varTANGGALKEMBALI,string varKODESTATUSPBJ,string varCATATAN,string varDIBUATOLEH,DateTime? varTANGGALDIBUAT,string varMODIFIKASIOLEH,DateTime? varTANGGALMODIFIKASI)
		{
			PBJ item = new PBJ();
			
			item.KODEPBJ = varKODEPBJ;
			
			item.NAMAKEGIATAN = varNAMAKEGIATAN;
			
			item.NAMAPAKET = varNAMAPAKET;
			
			item.KODESKPD = varKODESKPD;
			
			item.PPK = varPPK;
			
			item.PPTK = varPPTK;
			
			item.KODEJENISKEGIATAN = varKODEJENISKEGIATAN;
			
			item.PROSESPENGADAAN = varPROSESPENGADAAN;
			
			item.TANGGALPENGAJUAN = varTANGGALPENGAJUAN;
			
			item.PEMBAWABERKAS1 = varPEMBAWABERKAS1;
			
			item.PENERIMABERKAS1 = varPENERIMABERKAS1;
			
			item.PEMBAWABERKAS2 = varPEMBAWABERKAS2;
			
			item.PENERIMABERKAS2 = varPENERIMABERKAS2;
			
			item.LENGKAP = varLENGKAP;
			
			item.DIKEMBALIKAN = varDIKEMBALIKAN;
			
			item.TANGGALKEMBALI = varTANGGALKEMBALI;
			
			item.KODESTATUSPBJ = varKODESTATUSPBJ;
			
			item.CATATAN = varCATATAN;
			
			item.DIBUATOLEH = varDIBUATOLEH;
			
			item.TANGGALDIBUAT = varTANGGALDIBUAT;
			
			item.MODIFIKASIOLEH = varMODIFIKASIOLEH;
			
			item.TANGGALMODIFIKASI = varTANGGALMODIFIKASI;
			
		
			if (HttpContext.Current != null)
				item.Save(HttpContext.Current.User.Identity.Name);
			else
				item.Save(Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKODEPBJ,string varNAMAKEGIATAN,string varNAMAPAKET,string varKODESKPD,string varPPK,string varPPTK,string varKODEJENISKEGIATAN,string varPROSESPENGADAAN,DateTime? varTANGGALPENGAJUAN,string varPEMBAWABERKAS1,string varPENERIMABERKAS1,string varPEMBAWABERKAS2,string varPENERIMABERKAS2,string varLENGKAP,string varDIKEMBALIKAN,DateTime? varTANGGALKEMBALI,string varKODESTATUSPBJ,string varCATATAN,string varDIBUATOLEH,DateTime? varTANGGALDIBUAT,string varMODIFIKASIOLEH,DateTime? varTANGGALMODIFIKASI)
		{
			PBJ item = new PBJ();
			
				item.KODEPBJ = varKODEPBJ;
				
				item.NAMAKEGIATAN = varNAMAKEGIATAN;
				
				item.NAMAPAKET = varNAMAPAKET;
				
				item.KODESKPD = varKODESKPD;
				
				item.PPK = varPPK;
				
				item.PPTK = varPPTK;
				
				item.KODEJENISKEGIATAN = varKODEJENISKEGIATAN;
				
				item.PROSESPENGADAAN = varPROSESPENGADAAN;
				
				item.TANGGALPENGAJUAN = varTANGGALPENGAJUAN;
				
				item.PEMBAWABERKAS1 = varPEMBAWABERKAS1;
				
				item.PENERIMABERKAS1 = varPENERIMABERKAS1;
				
				item.PEMBAWABERKAS2 = varPEMBAWABERKAS2;
				
				item.PENERIMABERKAS2 = varPENERIMABERKAS2;
				
				item.LENGKAP = varLENGKAP;
				
				item.DIKEMBALIKAN = varDIKEMBALIKAN;
				
				item.TANGGALKEMBALI = varTANGGALKEMBALI;
				
				item.KODESTATUSPBJ = varKODESTATUSPBJ;
				
				item.CATATAN = varCATATAN;
				
				item.DIBUATOLEH = varDIBUATOLEH;
				
				item.TANGGALDIBUAT = varTANGGALDIBUAT;
				
				item.MODIFIKASIOLEH = varMODIFIKASIOLEH;
				
				item.TANGGALMODIFIKASI = varTANGGALMODIFIKASI;
				
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
			 public static string KODEPBJ = @"KODEPBJ";
			 public static string NAMAKEGIATAN = @"NAMAKEGIATAN";
			 public static string NAMAPAKET = @"NAMAPAKET";
			 public static string KODESKPD = @"KODESKPD";
			 public static string PPK = @"PPK";
			 public static string PPTK = @"PPTK";
			 public static string KODEJENISKEGIATAN = @"KODEJENISKEGIATAN";
			 public static string PROSESPENGADAAN = @"PROSESPENGADAAN";
			 public static string TANGGALPENGAJUAN = @"TANGGALPENGAJUAN";
			 public static string PEMBAWABERKAS1 = @"PEMBAWABERKAS1";
			 public static string PENERIMABERKAS1 = @"PENERIMABERKAS1";
			 public static string PEMBAWABERKAS2 = @"PEMBAWABERKAS2";
			 public static string PENERIMABERKAS2 = @"PENERIMABERKAS2";
			 public static string LENGKAP = @"LENGKAP";
			 public static string DIKEMBALIKAN = @"DIKEMBALIKAN";
			 public static string TANGGALKEMBALI = @"TANGGALKEMBALI";
			 public static string KODESTATUSPBJ = @"KODESTATUSPBJ";
			 public static string CATATAN = @"CATATAN";
			 public static string DIBUATOLEH = @"DIBUATOLEH";
			 public static string TANGGALDIBUAT = @"TANGGALDIBUAT";
			 public static string MODIFIKASIOLEH = @"MODIFIKASIOLEH";
			 public static string TANGGALMODIFIKASI = @"TANGGALMODIFIKASI";
						
		}

		#endregion
	}

}

