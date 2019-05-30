namespace Smarty
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SubSonic;
    using System.IO;
    using System.Web;
    using System.Web.UI;
	using System.Configuration;
	using System.Data.SqlClient;

    public class Language
    {
        Page page;
        public Language(Page page)
        {
            this.page = page;
        }

        public string Current
        {
            get
            {
                if (page.Session["language"] != null)
                {
                    return page.Session["language"].ToString();
                }
                else
                {
                    return "English";
                }
            }
        }
    }

    public class Factory
    {
        static public Builder CreateBuilder()
        {
            Builder builder = new Builder();
            DataProvider provider = DataService.Providers["MyProvider"];
                Table tableAKTOR = new Table();
                tableAKTOR.ShortName = "AKTOR";
                tableAKTOR.TableName = "dbo.AKTOR";
                            tableAKTOR.DataSourceTable = "dbo.AKTOR";
                tableAKTOR.OwnerID = "";
                    Field AKTOR_NIP = new Field();
                    AKTOR_NIP.Name = "NIP";
        	        
        	        
        	        

                    AKTOR_NIP.LinkNewWindow = 0;
                    AKTOR_NIP.LinkDisplay = 0;
                    AKTOR_NIP.LinkParam = "";

        	        AKTOR_NIP.FieldType = 200;
        	        AKTOR_NIP.EditFormat = "Text field";
        	        AKTOR_NIP.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        AKTOR_NIP.NeedEncode = true;

                    AKTOR_NIP.ControlType = 0;

        	        AKTOR_NIP.GoodName = "NIP";
        	                	        AKTOR_NIP.FullName = "NIP";
        	         AKTOR_NIP.IsRequired = true;
        	                	        
        	        
        	        AKTOR_NIP.Index = 1;
        	        
        	                	                	        AKTOR_NIP.EditParams = "";
        	                	        AKTOR_NIP.EditParams = AKTOR_NIP.EditParams + " maxlength=18";
        	                	                		                	        AKTOR_NIP.FieldPermissions = true;

        	        
                                        AKTOR_NIP.Container = tableAKTOR;
        	        tableAKTOR.Fields.Add("NIP", AKTOR_NIP);
                    Field AKTOR_NAMA = new Field();
                    AKTOR_NAMA.Name = "NAMA";
        	        
        	        
        	        

                    AKTOR_NAMA.LinkNewWindow = 0;
                    AKTOR_NAMA.LinkDisplay = 0;
                    AKTOR_NAMA.LinkParam = "";

        	        AKTOR_NAMA.FieldType = 200;
        	        AKTOR_NAMA.EditFormat = "Text field";
        	        AKTOR_NAMA.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        AKTOR_NAMA.NeedEncode = true;

                    AKTOR_NAMA.ControlType = 0;

        	        AKTOR_NAMA.GoodName = "NAMA";
        	                	        AKTOR_NAMA.FullName = "NAMA";
        	        
        	                	        
        	        
        	        AKTOR_NAMA.Index = 2;
        	        
        	                	                	        AKTOR_NAMA.EditParams = "";
        	                	        AKTOR_NAMA.EditParams = AKTOR_NAMA.EditParams + " maxlength=255";
        	                	                		                	        AKTOR_NAMA.FieldPermissions = true;

        	        
                                        AKTOR_NAMA.Container = tableAKTOR;
        	        tableAKTOR.Fields.Add("NAMA", AKTOR_NAMA);
                    Field AKTOR_KODEJABATAN = new Field();
                    AKTOR_KODEJABATAN.Name = "KODEJABATAN";
        	        AKTOR_KODEJABATAN.Label = "JABATAN";
        	        
        	        

                    AKTOR_KODEJABATAN.LinkNewWindow = 0;
                    AKTOR_KODEJABATAN.LinkDisplay = 0;
                    AKTOR_KODEJABATAN.LinkParam = "";

        	        AKTOR_KODEJABATAN.FieldType = 200;
        	        AKTOR_KODEJABATAN.EditFormat = "Lookup wizard";
        	        AKTOR_KODEJABATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	        AKTOR_KODEJABATAN.LookupType = 1;
        	                	        AKTOR_KODEJABATAN.LookupWhere = "";
        	        AKTOR_KODEJABATAN.LinkField = "[KODEJABATAN]";
        	                	        AKTOR_KODEJABATAN.DisplayField = "[DESKRIPSI]";
        	        AKTOR_KODEJABATAN.LookupTable = "dbo.JABATANAKTOR";
        	                	                	                	        AKTOR_KODEJABATAN.NeedEncode = true;

                    AKTOR_KODEJABATAN.ControlType = 0;

        	        AKTOR_KODEJABATAN.GoodName = "KODEJABATAN";
        	                	        AKTOR_KODEJABATAN.FullName = "KODEJABATAN";
        	        
        	                	        
        	        
        	        AKTOR_KODEJABATAN.Index = 3;
        	        
        	                	                	                		                	        AKTOR_KODEJABATAN.FieldPermissions = true;

        	        
                                            AKTOR_KODEJABATAN.AddNewItem =  false ;
                                                    AKTOR_KODEJABATAN.AdvancedAdd = true;
		                    AKTOR_KODEJABATAN.AddPage = "JABATANAKTOR_add.aspx";
                        AKTOR_KODEJABATAN.LinkField = "KODEJABATAN";
                        AKTOR_KODEJABATAN.DisplayField = "DESKRIPSI";
                        AKTOR_KODEJABATAN.LookupTable = "dbo.JABATANAKTOR";
                        AKTOR_KODEJABATAN.StrSize = 1;
                        		                                                
                                                		
		                                        		     AKTOR_KODEJABATAN.OrderBy = "KODEJABATAN";
		                                            AKTOR_KODEJABATAN.Container = tableAKTOR;
        	        tableAKTOR.Fields.Add("KODEJABATAN", AKTOR_KODEJABATAN);
                    Field AKTOR_KODETIPE = new Field();
                    AKTOR_KODETIPE.Name = "KODETIPE";
        	        AKTOR_KODETIPE.Label = "TIPE";
        	        
        	        

                    AKTOR_KODETIPE.LinkNewWindow = 0;
                    AKTOR_KODETIPE.LinkDisplay = 0;
                    AKTOR_KODETIPE.LinkParam = "";

        	        AKTOR_KODETIPE.FieldType = 200;
        	        AKTOR_KODETIPE.EditFormat = "Lookup wizard";
        	        AKTOR_KODETIPE.ViewFormat = "";
        	        
        	        
        	        
        	                	        AKTOR_KODETIPE.LookupType = 1;
        	                	        AKTOR_KODETIPE.LookupWhere = "";
        	        AKTOR_KODETIPE.LinkField = "[KODETIPE]";
        	                	        AKTOR_KODETIPE.DisplayField = "[DESKRIPSI]";
        	        AKTOR_KODETIPE.LookupTable = "dbo.TIPEAKTOR";
        	                	                	                	        AKTOR_KODETIPE.NeedEncode = true;

                    AKTOR_KODETIPE.ControlType = 0;

        	        AKTOR_KODETIPE.GoodName = "KODETIPE";
        	                	        AKTOR_KODETIPE.FullName = "KODETIPE";
        	        
        	                	        
        	        
        	        AKTOR_KODETIPE.Index = 4;
        	        
        	                	                	                		                	        AKTOR_KODETIPE.FieldPermissions = true;

        	        
                                            AKTOR_KODETIPE.AddNewItem =  false ;
                                                    AKTOR_KODETIPE.AdvancedAdd = true;
		                    AKTOR_KODETIPE.AddPage = "TIPEAKTOR_add.aspx";
                        AKTOR_KODETIPE.LinkField = "KODETIPE";
                        AKTOR_KODETIPE.DisplayField = "DESKRIPSI";
                        AKTOR_KODETIPE.LookupTable = "dbo.TIPEAKTOR";
                        AKTOR_KODETIPE.StrSize = 1;
                        		                                                
                                                		
		                                        		     AKTOR_KODETIPE.OrderBy = "KODETIPE";
		                                            AKTOR_KODETIPE.Container = tableAKTOR;
        	        tableAKTOR.Fields.Add("KODETIPE", AKTOR_KODETIPE);
                builder.Tables.Add("dbo.AKTOR", tableAKTOR);
                builder.SubSonicTables.Add("AKTOR", tableAKTOR);
                Table tableTIPEAKTOR = new Table();
                tableTIPEAKTOR.ShortName = "TIPEAKTOR";
                tableTIPEAKTOR.TableName = "dbo.TIPEAKTOR";
                            tableTIPEAKTOR.DataSourceTable = "dbo.TIPEAKTOR";
                tableTIPEAKTOR.OwnerID = "";
                    Field TIPEAKTOR_KODETIPE = new Field();
                    TIPEAKTOR_KODETIPE.Name = "KODETIPE";
        	        TIPEAKTOR_KODETIPE.Label = "KODE TIPE";
        	        
        	        

                    TIPEAKTOR_KODETIPE.LinkNewWindow = 0;
                    TIPEAKTOR_KODETIPE.LinkDisplay = 0;
                    TIPEAKTOR_KODETIPE.LinkParam = "";

        	        TIPEAKTOR_KODETIPE.FieldType = 200;
        	        TIPEAKTOR_KODETIPE.EditFormat = "Text field";
        	        TIPEAKTOR_KODETIPE.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        TIPEAKTOR_KODETIPE.NeedEncode = true;

                    TIPEAKTOR_KODETIPE.ControlType = 0;

        	        TIPEAKTOR_KODETIPE.GoodName = "KODETIPE";
        	                	        TIPEAKTOR_KODETIPE.FullName = "KODETIPE";
        	         TIPEAKTOR_KODETIPE.IsRequired = true;
        	                	        
        	        
        	        TIPEAKTOR_KODETIPE.Index = 1;
        	        
        	                	                	        TIPEAKTOR_KODETIPE.EditParams = "";
        	                	        TIPEAKTOR_KODETIPE.EditParams = TIPEAKTOR_KODETIPE.EditParams + " maxlength=10";
        	                	                		                	        TIPEAKTOR_KODETIPE.FieldPermissions = true;

        	        
                                        TIPEAKTOR_KODETIPE.Container = tableTIPEAKTOR;
        	        tableTIPEAKTOR.Fields.Add("KODETIPE", TIPEAKTOR_KODETIPE);
                    Field TIPEAKTOR_DESKRIPSI = new Field();
                    TIPEAKTOR_DESKRIPSI.Name = "DESKRIPSI";
        	        
        	        
        	        

                    TIPEAKTOR_DESKRIPSI.LinkNewWindow = 0;
                    TIPEAKTOR_DESKRIPSI.LinkDisplay = 0;
                    TIPEAKTOR_DESKRIPSI.LinkParam = "";

        	        TIPEAKTOR_DESKRIPSI.FieldType = 200;
        	        TIPEAKTOR_DESKRIPSI.EditFormat = "Text field";
        	        TIPEAKTOR_DESKRIPSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        TIPEAKTOR_DESKRIPSI.NeedEncode = true;

                    TIPEAKTOR_DESKRIPSI.ControlType = 0;

        	        TIPEAKTOR_DESKRIPSI.GoodName = "DESKRIPSI";
        	                	        TIPEAKTOR_DESKRIPSI.FullName = "DESKRIPSI";
        	        
        	                	        
        	        
        	        TIPEAKTOR_DESKRIPSI.Index = 2;
        	        
        	                	                	        TIPEAKTOR_DESKRIPSI.EditParams = "";
        	                	        TIPEAKTOR_DESKRIPSI.EditParams = TIPEAKTOR_DESKRIPSI.EditParams + " maxlength=100";
        	                	                		                	        TIPEAKTOR_DESKRIPSI.FieldPermissions = true;

        	        
                                        TIPEAKTOR_DESKRIPSI.Container = tableTIPEAKTOR;
        	        tableTIPEAKTOR.Fields.Add("DESKRIPSI", TIPEAKTOR_DESKRIPSI);
                builder.Tables.Add("dbo.TIPEAKTOR", tableTIPEAKTOR);
                builder.SubSonicTables.Add("TIPEAKTOR", tableTIPEAKTOR);
                Table tableSTATUSPBJ = new Table();
                tableSTATUSPBJ.ShortName = "STATUSPBJ";
                tableSTATUSPBJ.TableName = "dbo.STATUSPBJ";
                            tableSTATUSPBJ.DataSourceTable = "dbo.STATUSPBJ";
                tableSTATUSPBJ.OwnerID = "";
                    Field STATUSPBJ_KODESTATUS = new Field();
                    STATUSPBJ_KODESTATUS.Name = "KODESTATUS";
        	        STATUSPBJ_KODESTATUS.Label = "KODE STATUS";
        	        
        	        

                    STATUSPBJ_KODESTATUS.LinkNewWindow = 0;
                    STATUSPBJ_KODESTATUS.LinkDisplay = 0;
                    STATUSPBJ_KODESTATUS.LinkParam = "";

        	        STATUSPBJ_KODESTATUS.FieldType = 200;
        	        STATUSPBJ_KODESTATUS.EditFormat = "Text field";
        	        STATUSPBJ_KODESTATUS.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        STATUSPBJ_KODESTATUS.NeedEncode = true;

                    STATUSPBJ_KODESTATUS.ControlType = 0;

        	        STATUSPBJ_KODESTATUS.GoodName = "KODESTATUS";
        	                	        STATUSPBJ_KODESTATUS.FullName = "KODESTATUS";
        	         STATUSPBJ_KODESTATUS.IsRequired = true;
        	                	        
        	        
        	        STATUSPBJ_KODESTATUS.Index = 1;
        	        
        	                	                	        STATUSPBJ_KODESTATUS.EditParams = "";
        	                	        STATUSPBJ_KODESTATUS.EditParams = STATUSPBJ_KODESTATUS.EditParams + " maxlength=20";
        	                	                		                	        STATUSPBJ_KODESTATUS.FieldPermissions = true;

        	        
                                        STATUSPBJ_KODESTATUS.Container = tableSTATUSPBJ;
        	        tableSTATUSPBJ.Fields.Add("KODESTATUS", STATUSPBJ_KODESTATUS);
                    Field STATUSPBJ_DESKRIPSI = new Field();
                    STATUSPBJ_DESKRIPSI.Name = "DESKRIPSI";
        	        
        	        
        	        

                    STATUSPBJ_DESKRIPSI.LinkNewWindow = 0;
                    STATUSPBJ_DESKRIPSI.LinkDisplay = 0;
                    STATUSPBJ_DESKRIPSI.LinkParam = "";

        	        STATUSPBJ_DESKRIPSI.FieldType = 200;
        	        STATUSPBJ_DESKRIPSI.EditFormat = "Text field";
        	        STATUSPBJ_DESKRIPSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        STATUSPBJ_DESKRIPSI.NeedEncode = true;

                    STATUSPBJ_DESKRIPSI.ControlType = 0;

        	        STATUSPBJ_DESKRIPSI.GoodName = "DESKRIPSI";
        	                	        STATUSPBJ_DESKRIPSI.FullName = "DESKRIPSI";
        	        
        	                	        
        	        
        	        STATUSPBJ_DESKRIPSI.Index = 2;
        	        
        	                	                	        STATUSPBJ_DESKRIPSI.EditParams = "";
        	                	        STATUSPBJ_DESKRIPSI.EditParams = STATUSPBJ_DESKRIPSI.EditParams + " maxlength=100";
        	                	                		                	        STATUSPBJ_DESKRIPSI.FieldPermissions = true;

        	        
                                        STATUSPBJ_DESKRIPSI.Container = tableSTATUSPBJ;
        	        tableSTATUSPBJ.Fields.Add("DESKRIPSI", STATUSPBJ_DESKRIPSI);
                    Field STATUSPBJ_URUTAN = new Field();
                    STATUSPBJ_URUTAN.Name = "URUTAN";
        	        
        	        
        	        

                    STATUSPBJ_URUTAN.LinkNewWindow = 0;
                    STATUSPBJ_URUTAN.LinkDisplay = 0;
                    STATUSPBJ_URUTAN.LinkParam = "";

        	        STATUSPBJ_URUTAN.FieldType = 3;
        	        STATUSPBJ_URUTAN.EditFormat = "Text field";
        	        STATUSPBJ_URUTAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        STATUSPBJ_URUTAN.NeedEncode = true;

                    STATUSPBJ_URUTAN.ControlType = 0;

        	        STATUSPBJ_URUTAN.GoodName = "URUTAN";
        	                	        STATUSPBJ_URUTAN.FullName = "URUTAN";
        	         STATUSPBJ_URUTAN.IsRequired = true;
        	                	        
        	        
        	        STATUSPBJ_URUTAN.Index = 3;
        	        
        	                	                	        STATUSPBJ_URUTAN.EditParams = "";
        	                	                	                		                	        STATUSPBJ_URUTAN.FieldPermissions = true;

        	        
                                        STATUSPBJ_URUTAN.Container = tableSTATUSPBJ;
        	        tableSTATUSPBJ.Fields.Add("URUTAN", STATUSPBJ_URUTAN);
                builder.Tables.Add("dbo.STATUSPBJ", tableSTATUSPBJ);
                builder.SubSonicTables.Add("STATUSPBJ", tableSTATUSPBJ);
                Table tableSKPD = new Table();
                tableSKPD.ShortName = "SKPD";
                tableSKPD.TableName = "dbo.SKPD";
                            tableSKPD.DataSourceTable = "dbo.SKPD";
                tableSKPD.OwnerID = "";
                    Field SKPD_KODESKPD = new Field();
                    SKPD_KODESKPD.Name = "KODESKPD";
        	        SKPD_KODESKPD.Label = "KODE SKPD";
        	        
        	        

                    SKPD_KODESKPD.LinkNewWindow = 0;
                    SKPD_KODESKPD.LinkDisplay = 0;
                    SKPD_KODESKPD.LinkParam = "";

        	        SKPD_KODESKPD.FieldType = 200;
        	        SKPD_KODESKPD.EditFormat = "Text field";
        	        SKPD_KODESKPD.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        SKPD_KODESKPD.NeedEncode = true;

                    SKPD_KODESKPD.ControlType = 0;

        	        SKPD_KODESKPD.GoodName = "KODESKPD";
        	                	        SKPD_KODESKPD.FullName = "KODESKPD";
        	         SKPD_KODESKPD.IsRequired = true;
        	                	        
        	        
        	        SKPD_KODESKPD.Index = 1;
        	        
        	                	                	        SKPD_KODESKPD.EditParams = "";
        	                	        SKPD_KODESKPD.EditParams = SKPD_KODESKPD.EditParams + " maxlength=10";
        	                	                		                	        SKPD_KODESKPD.FieldPermissions = true;

        	        
                                        SKPD_KODESKPD.Container = tableSKPD;
        	        tableSKPD.Fields.Add("KODESKPD", SKPD_KODESKPD);
                    Field SKPD_DESKRIPSI = new Field();
                    SKPD_DESKRIPSI.Name = "DESKRIPSI";
        	        
        	        
        	        

                    SKPD_DESKRIPSI.LinkNewWindow = 0;
                    SKPD_DESKRIPSI.LinkDisplay = 0;
                    SKPD_DESKRIPSI.LinkParam = "";

        	        SKPD_DESKRIPSI.FieldType = 200;
        	        SKPD_DESKRIPSI.EditFormat = "Text field";
        	        SKPD_DESKRIPSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        SKPD_DESKRIPSI.NeedEncode = true;

                    SKPD_DESKRIPSI.ControlType = 0;

        	        SKPD_DESKRIPSI.GoodName = "DESKRIPSI";
        	                	        SKPD_DESKRIPSI.FullName = "DESKRIPSI";
        	        
        	                	        
        	        
        	        SKPD_DESKRIPSI.Index = 2;
        	        
        	                	                	        SKPD_DESKRIPSI.EditParams = "";
        	                	        SKPD_DESKRIPSI.EditParams = SKPD_DESKRIPSI.EditParams + " maxlength=200";
        	                	                		                	        SKPD_DESKRIPSI.FieldPermissions = true;

        	        
                                        SKPD_DESKRIPSI.Container = tableSKPD;
        	        tableSKPD.Fields.Add("DESKRIPSI", SKPD_DESKRIPSI);
                    Field SKPD_ALAMAT = new Field();
                    SKPD_ALAMAT.Name = "ALAMAT";
        	        
        	        
        	        

                    SKPD_ALAMAT.LinkNewWindow = 0;
                    SKPD_ALAMAT.LinkDisplay = 0;
                    SKPD_ALAMAT.LinkParam = "";

        	        SKPD_ALAMAT.FieldType = 200;
        	        SKPD_ALAMAT.EditFormat = "Text field";
        	        SKPD_ALAMAT.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        SKPD_ALAMAT.NeedEncode = true;

                    SKPD_ALAMAT.ControlType = 0;

        	        SKPD_ALAMAT.GoodName = "ALAMAT";
        	                	        SKPD_ALAMAT.FullName = "ALAMAT";
        	        
        	                	        
        	        
        	        SKPD_ALAMAT.Index = 3;
        	        
        	                	                	        SKPD_ALAMAT.EditParams = "";
        	                	        SKPD_ALAMAT.EditParams = SKPD_ALAMAT.EditParams + " maxlength=500";
        	                	                		                	        SKPD_ALAMAT.FieldPermissions = true;

        	        
                                        SKPD_ALAMAT.Container = tableSKPD;
        	        tableSKPD.Fields.Add("ALAMAT", SKPD_ALAMAT);
                builder.Tables.Add("dbo.SKPD", tableSKPD);
                builder.SubSonicTables.Add("SKPD", tableSKPD);
                Table tablePENGGUNA = new Table();
                tablePENGGUNA.ShortName = "PENGGUNA";
                tablePENGGUNA.TableName = "dbo.PENGGUNA";
                            tablePENGGUNA.DataSourceTable = "dbo.PENGGUNA";
                tablePENGGUNA.OwnerID = "";
                    Field PENGGUNA_KODEPENGGUNA = new Field();
                    PENGGUNA_KODEPENGGUNA.Name = "KODEPENGGUNA";
        	        PENGGUNA_KODEPENGGUNA.Label = "KODE PENGGUNA";
        	        
        	        

                    PENGGUNA_KODEPENGGUNA.LinkNewWindow = 0;
                    PENGGUNA_KODEPENGGUNA.LinkDisplay = 0;
                    PENGGUNA_KODEPENGGUNA.LinkParam = "";

        	        PENGGUNA_KODEPENGGUNA.FieldType = 200;
        	        PENGGUNA_KODEPENGGUNA.EditFormat = "Text field";
        	        PENGGUNA_KODEPENGGUNA.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PENGGUNA_KODEPENGGUNA.NeedEncode = true;

                    PENGGUNA_KODEPENGGUNA.ControlType = 0;

        	        PENGGUNA_KODEPENGGUNA.GoodName = "KODEPENGGUNA";
        	                	        PENGGUNA_KODEPENGGUNA.FullName = "KODEPENGGUNA";
        	         PENGGUNA_KODEPENGGUNA.IsRequired = true;
        	                	        
        	        
        	        PENGGUNA_KODEPENGGUNA.Index = 1;
        	        
        	                	                	        PENGGUNA_KODEPENGGUNA.EditParams = "";
        	                	        PENGGUNA_KODEPENGGUNA.EditParams = PENGGUNA_KODEPENGGUNA.EditParams + " maxlength=50";
        	                	                		                	        PENGGUNA_KODEPENGGUNA.FieldPermissions = true;

        	        
                                        PENGGUNA_KODEPENGGUNA.Container = tablePENGGUNA;
        	        tablePENGGUNA.Fields.Add("KODEPENGGUNA", PENGGUNA_KODEPENGGUNA);
                    Field PENGGUNA_NAMA = new Field();
                    PENGGUNA_NAMA.Name = "NAMA";
        	        PENGGUNA_NAMA.Label = "NAMA PENGGUNA";
        	        
        	        

                    PENGGUNA_NAMA.LinkNewWindow = 0;
                    PENGGUNA_NAMA.LinkDisplay = 0;
                    PENGGUNA_NAMA.LinkParam = "";

        	        PENGGUNA_NAMA.FieldType = 200;
        	        PENGGUNA_NAMA.EditFormat = "Text field";
        	        PENGGUNA_NAMA.ViewFormat = "";
        	        
        	        PENGGUNA_NAMA.FastType = true;
        	        
        	                	                	                	        PENGGUNA_NAMA.NeedEncode = true;

                    PENGGUNA_NAMA.ControlType = 1;

        	        PENGGUNA_NAMA.GoodName = "NAMA";
        	                	        PENGGUNA_NAMA.FullName = "NAMA";
        	         PENGGUNA_NAMA.IsRequired = true;
        	                	        
        	        
        	        PENGGUNA_NAMA.Index = 2;
        	        
        	                	                	        PENGGUNA_NAMA.EditParams = "";
        	                	        PENGGUNA_NAMA.EditParams = PENGGUNA_NAMA.EditParams + " maxlength=100";
        	                	                		                	        PENGGUNA_NAMA.FieldPermissions = true;

        	        
                                        PENGGUNA_NAMA.Container = tablePENGGUNA;
        	        tablePENGGUNA.Fields.Add("NAMA", PENGGUNA_NAMA);
                    Field PENGGUNA_KATAKUNCI = new Field();
                    PENGGUNA_KATAKUNCI.Name = "KATAKUNCI";
        	        PENGGUNA_KATAKUNCI.Label = "KATA KUNCI";
        	        
        	        

                    PENGGUNA_KATAKUNCI.LinkNewWindow = 0;
                    PENGGUNA_KATAKUNCI.LinkDisplay = 0;
                    PENGGUNA_KATAKUNCI.LinkParam = "";

        	        PENGGUNA_KATAKUNCI.FieldType = 200;
        	        PENGGUNA_KATAKUNCI.EditFormat = "Text field";
        	        PENGGUNA_KATAKUNCI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PENGGUNA_KATAKUNCI.NeedEncode = true;

                    PENGGUNA_KATAKUNCI.ControlType = 0;

        	        PENGGUNA_KATAKUNCI.GoodName = "KATAKUNCI";
        	                	        PENGGUNA_KATAKUNCI.FullName = "KATAKUNCI";
        	         PENGGUNA_KATAKUNCI.IsRequired = true;
        	                	        
        	        
        	        PENGGUNA_KATAKUNCI.Index = 3;
        	        
        	                	                	        PENGGUNA_KATAKUNCI.EditParams = "";
        	                	        PENGGUNA_KATAKUNCI.EditParams = PENGGUNA_KATAKUNCI.EditParams + " maxlength=20";
        	                	                		                	        PENGGUNA_KATAKUNCI.FieldPermissions = true;

        	        
                                        PENGGUNA_KATAKUNCI.Container = tablePENGGUNA;
        	        tablePENGGUNA.Fields.Add("KATAKUNCI", PENGGUNA_KATAKUNCI);
                    Field PENGGUNA_AKTIF = new Field();
                    PENGGUNA_AKTIF.Name = "AKTIF";
        	        
        	        
        	        

                    PENGGUNA_AKTIF.LinkNewWindow = 0;
                    PENGGUNA_AKTIF.LinkDisplay = 0;
                    PENGGUNA_AKTIF.LinkParam = "";

        	        PENGGUNA_AKTIF.FieldType = 11;
        	        PENGGUNA_AKTIF.EditFormat = "Checkbox";
        	        PENGGUNA_AKTIF.ViewFormat = "Checkbox";
        	        
        	        
        	        
        	                	                	        
                    PENGGUNA_AKTIF.ControlType = 0;

        	        PENGGUNA_AKTIF.GoodName = "AKTIF";
        	                	        PENGGUNA_AKTIF.FullName = "AKTIF";
        	        
        	                	        
        	        
        	        PENGGUNA_AKTIF.Index = 4;
        	        
        	                	                	                		        
        	        
                                        PENGGUNA_AKTIF.Container = tablePENGGUNA;
        	        tablePENGGUNA.Fields.Add("AKTIF", PENGGUNA_AKTIF);
                    Field PENGGUNA_LOGINTERAKHIR = new Field();
                    PENGGUNA_LOGINTERAKHIR.Name = "LOGINTERAKHIR";
        	        
        	        
        	        

                    PENGGUNA_LOGINTERAKHIR.LinkNewWindow = 0;
                    PENGGUNA_LOGINTERAKHIR.LinkDisplay = 0;
                    PENGGUNA_LOGINTERAKHIR.LinkParam = "";

        	        PENGGUNA_LOGINTERAKHIR.FieldType = 135;
        	        PENGGUNA_LOGINTERAKHIR.EditFormat = "Date";
        	        PENGGUNA_LOGINTERAKHIR.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        PENGGUNA_LOGINTERAKHIR.NeedEncode = true;

                    PENGGUNA_LOGINTERAKHIR.ControlType = 0;

        	        PENGGUNA_LOGINTERAKHIR.GoodName = "LOGINTERAKHIR";
        	                	        PENGGUNA_LOGINTERAKHIR.FullName = "LOGINTERAKHIR";
        	        
        	                	        
        	        
        	        PENGGUNA_LOGINTERAKHIR.Index = 5;
        	         PENGGUNA_LOGINTERAKHIR.DateEditType = 13;
        	                	                	                		        
        	        
                                        PENGGUNA_LOGINTERAKHIR.Container = tablePENGGUNA;
        	        tablePENGGUNA.Fields.Add("LOGINTERAKHIR", PENGGUNA_LOGINTERAKHIR);
                    Field PENGGUNA_KODEKELOMPOK = new Field();
                    PENGGUNA_KODEKELOMPOK.Name = "KODEKELOMPOK";
        	        PENGGUNA_KODEKELOMPOK.Label = "KELOMPOK PENGGUNA";
        	        
        	        

                    PENGGUNA_KODEKELOMPOK.LinkNewWindow = 0;
                    PENGGUNA_KODEKELOMPOK.LinkDisplay = 0;
                    PENGGUNA_KODEKELOMPOK.LinkParam = "";

        	        PENGGUNA_KODEKELOMPOK.FieldType = 200;
        	        PENGGUNA_KODEKELOMPOK.EditFormat = "Lookup wizard";
        	        PENGGUNA_KODEKELOMPOK.ViewFormat = "";
        	        
        	        
        	        
        	                	        PENGGUNA_KODEKELOMPOK.LookupType = 1;
        	                	        PENGGUNA_KODEKELOMPOK.LookupWhere = "";
        	        PENGGUNA_KODEKELOMPOK.LinkField = "[KODEKELOMPOK]";
        	                	        PENGGUNA_KODEKELOMPOK.DisplayField = "[DESKRIPSI]";
        	        PENGGUNA_KODEKELOMPOK.LookupTable = "dbo.KELOMPOKPENGGUNA";
        	                	                	                	        PENGGUNA_KODEKELOMPOK.NeedEncode = true;

                    PENGGUNA_KODEKELOMPOK.ControlType = 0;

        	        PENGGUNA_KODEKELOMPOK.GoodName = "KODEKELOMPOK";
        	                	        PENGGUNA_KODEKELOMPOK.FullName = "KODEKELOMPOK";
        	         PENGGUNA_KODEKELOMPOK.IsRequired = true;
        	                	        
        	        
        	        PENGGUNA_KODEKELOMPOK.Index = 6;
        	        
        	                	                	                		                	        PENGGUNA_KODEKELOMPOK.FieldPermissions = true;

        	        
                                            PENGGUNA_KODEKELOMPOK.AddNewItem =  false ;
                                                    PENGGUNA_KODEKELOMPOK.AdvancedAdd = true;
		                    PENGGUNA_KODEKELOMPOK.AddPage = "KELOMPOKPENGGUNA_add.aspx";
                        PENGGUNA_KODEKELOMPOK.LinkField = "KODEKELOMPOK";
                        PENGGUNA_KODEKELOMPOK.DisplayField = "DESKRIPSI";
                        PENGGUNA_KODEKELOMPOK.LookupTable = "dbo.KELOMPOKPENGGUNA";
                        PENGGUNA_KODEKELOMPOK.StrSize = 1;
                        		                                                
                                                		
		                                        		     PENGGUNA_KODEKELOMPOK.OrderBy = "KODEKELOMPOK";
		                                            PENGGUNA_KODEKELOMPOK.Container = tablePENGGUNA;
        	        tablePENGGUNA.Fields.Add("KODEKELOMPOK", PENGGUNA_KODEKELOMPOK);
                builder.Tables.Add("dbo.PENGGUNA", tablePENGGUNA);
                builder.SubSonicTables.Add("PENGGUNA", tablePENGGUNA);
                Table tablePBJ = new Table();
                tablePBJ.ShortName = "PBJ";
                tablePBJ.TableName = "dbo.PBJ";
                            tablePBJ.DataSourceTable = "dbo.PBJ";
                tablePBJ.OwnerID = "";
                    Field PBJ_KODEPBJ = new Field();
                    PBJ_KODEPBJ.Name = "KODEPBJ";
        	        PBJ_KODEPBJ.Label = "KODE PBJ";
        	        
        	        

                    PBJ_KODEPBJ.LinkNewWindow = 0;
                    PBJ_KODEPBJ.LinkDisplay = 0;
                    PBJ_KODEPBJ.LinkParam = "";

        	        PBJ_KODEPBJ.FieldType = 200;
        	        PBJ_KODEPBJ.EditFormat = "Text field";
        	        PBJ_KODEPBJ.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_KODEPBJ.NeedEncode = true;

                    PBJ_KODEPBJ.ControlType = 0;

        	        PBJ_KODEPBJ.GoodName = "KODEPBJ";
        	                	        PBJ_KODEPBJ.FullName = "KODEPBJ";
        	         PBJ_KODEPBJ.IsRequired = true;
        	                	        
        	        
        	        PBJ_KODEPBJ.Index = 1;
        	        
        	                	                	        PBJ_KODEPBJ.EditParams = "";
        	                	        PBJ_KODEPBJ.EditParams = PBJ_KODEPBJ.EditParams + " maxlength=15";
        	                	                		                	        PBJ_KODEPBJ.FieldPermissions = true;

        	        
                                        PBJ_KODEPBJ.Container = tablePBJ;
        	        tablePBJ.Fields.Add("KODEPBJ", PBJ_KODEPBJ);
                    Field PBJ_NAMAKEGIATAN = new Field();
                    PBJ_NAMAKEGIATAN.Name = "NAMAKEGIATAN";
        	        PBJ_NAMAKEGIATAN.Label = "NAMA KEGIATAN";
        	        
        	        

                    PBJ_NAMAKEGIATAN.LinkNewWindow = 0;
                    PBJ_NAMAKEGIATAN.LinkDisplay = 0;
                    PBJ_NAMAKEGIATAN.LinkParam = "";

        	        PBJ_NAMAKEGIATAN.FieldType = 200;
        	        PBJ_NAMAKEGIATAN.EditFormat = "Text field";
        	        PBJ_NAMAKEGIATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_NAMAKEGIATAN.NeedEncode = true;

                    PBJ_NAMAKEGIATAN.ControlType = 0;

        	        PBJ_NAMAKEGIATAN.GoodName = "NAMAKEGIATAN";
        	                	        PBJ_NAMAKEGIATAN.FullName = "NAMAKEGIATAN";
        	        
        	                	        
        	        
        	        PBJ_NAMAKEGIATAN.Index = 2;
        	        
        	                	                	        PBJ_NAMAKEGIATAN.EditParams = "";
        	                	        PBJ_NAMAKEGIATAN.EditParams = PBJ_NAMAKEGIATAN.EditParams + " maxlength=500 size=70";
        	                	                		                	        PBJ_NAMAKEGIATAN.FieldPermissions = true;

        	        
                                        PBJ_NAMAKEGIATAN.Container = tablePBJ;
        	        tablePBJ.Fields.Add("NAMAKEGIATAN", PBJ_NAMAKEGIATAN);
                    Field PBJ_NAMAPAKET = new Field();
                    PBJ_NAMAPAKET.Name = "NAMAPAKET";
        	        PBJ_NAMAPAKET.Label = "NAMA PAKET";
        	        
        	        

                    PBJ_NAMAPAKET.LinkNewWindow = 0;
                    PBJ_NAMAPAKET.LinkDisplay = 0;
                    PBJ_NAMAPAKET.LinkParam = "";

        	        PBJ_NAMAPAKET.FieldType = 200;
        	        PBJ_NAMAPAKET.EditFormat = "Text field";
        	        PBJ_NAMAPAKET.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_NAMAPAKET.NeedEncode = true;

                    PBJ_NAMAPAKET.ControlType = 0;

        	        PBJ_NAMAPAKET.GoodName = "NAMAPAKET";
        	                	        PBJ_NAMAPAKET.FullName = "NAMAPAKET";
        	        
        	                	        
        	        
        	        PBJ_NAMAPAKET.Index = 3;
        	        
        	                	                	        PBJ_NAMAPAKET.EditParams = "";
        	                	        PBJ_NAMAPAKET.EditParams = PBJ_NAMAPAKET.EditParams + " maxlength=500 size=70";
        	                	                		                	        PBJ_NAMAPAKET.FieldPermissions = true;

        	        
                                        PBJ_NAMAPAKET.Container = tablePBJ;
        	        tablePBJ.Fields.Add("NAMAPAKET", PBJ_NAMAPAKET);
                    Field PBJ_KODESKPD = new Field();
                    PBJ_KODESKPD.Name = "KODESKPD";
        	        PBJ_KODESKPD.Label = "SKPD";
        	        
        	        

                    PBJ_KODESKPD.LinkNewWindow = 0;
                    PBJ_KODESKPD.LinkDisplay = 0;
                    PBJ_KODESKPD.LinkParam = "";

        	        PBJ_KODESKPD.FieldType = 200;
        	        PBJ_KODESKPD.EditFormat = "Lookup wizard";
        	        PBJ_KODESKPD.ViewFormat = "";
        	        
        	        
        	        
        	                	        PBJ_KODESKPD.LookupType = 1;
        	                	        PBJ_KODESKPD.LookupWhere = "";
        	        PBJ_KODESKPD.LinkField = "[KODESKPD]";
        	                	        PBJ_KODESKPD.DisplayField = "[DESKRIPSI]";
        	        PBJ_KODESKPD.LookupTable = "dbo.SKPD";
        	                	                	                	        PBJ_KODESKPD.NeedEncode = true;

                    PBJ_KODESKPD.ControlType = 0;

        	        PBJ_KODESKPD.GoodName = "KODESKPD";
        	                	        PBJ_KODESKPD.FullName = "KODESKPD";
        	         PBJ_KODESKPD.IsRequired = true;
        	                	        
        	        
        	        PBJ_KODESKPD.Index = 4;
        	        
        	                	                	                		                	        PBJ_KODESKPD.FieldPermissions = true;

        	        
                                            PBJ_KODESKPD.AddNewItem =  false ;
                                                PBJ_KODESKPD.LinkField = "KODESKPD";
                        PBJ_KODESKPD.DisplayField = "DESKRIPSI";
                        PBJ_KODESKPD.LookupTable = "dbo.SKPD";
                        PBJ_KODESKPD.StrSize = 1;
                        		                                                
                                                		
		                                        		     PBJ_KODESKPD.OrderBy = "DESKRIPSI";
		                                            PBJ_KODESKPD.Container = tablePBJ;
        	        tablePBJ.Fields.Add("KODESKPD", PBJ_KODESKPD);
                    Field PBJ_PPK = new Field();
                    PBJ_PPK.Name = "PPK";
        	        
        	        
        	        

                    PBJ_PPK.LinkNewWindow = 0;
                    PBJ_PPK.LinkDisplay = 0;
                    PBJ_PPK.LinkParam = "";

        	        PBJ_PPK.FieldType = 200;
        	        PBJ_PPK.EditFormat = "Lookup wizard";
        	        PBJ_PPK.ViewFormat = "";
        	        
        	        
        	        
        	                	        PBJ_PPK.LookupType = 1;
        	                	        PBJ_PPK.LookupWhere = "";
        	        PBJ_PPK.LinkField = "[NIP]";
        	                	        PBJ_PPK.DisplayField = "[NAMA]";
        	        PBJ_PPK.LookupTable = "dbo.TMP_PPK";
        	                	                	                	        PBJ_PPK.NeedEncode = true;

                    PBJ_PPK.ControlType = 0;

        	        PBJ_PPK.GoodName = "PPK";
        	                	        PBJ_PPK.FullName = "PPK";
        	         PBJ_PPK.IsRequired = true;
        	                	        
        	        
        	        PBJ_PPK.Index = 5;
        	        
        	                	                	                		                	        PBJ_PPK.FieldPermissions = true;

        	        
                                            PBJ_PPK.AddNewItem =  false ;
                                                PBJ_PPK.LinkField = "NIP";
                        PBJ_PPK.DisplayField = "NAMA";
                        PBJ_PPK.LookupTable = "dbo.TMP_PPK";
                        PBJ_PPK.StrSize = 1;
                        		                                                
                                                		
		                                        		     PBJ_PPK.OrderBy = "NAMA";
		                                            PBJ_PPK.Container = tablePBJ;
        	        tablePBJ.Fields.Add("PPK", PBJ_PPK);
                    Field PBJ_PPTK = new Field();
                    PBJ_PPTK.Name = "PPTK";
        	        
        	        
        	        

                    PBJ_PPTK.LinkNewWindow = 0;
                    PBJ_PPTK.LinkDisplay = 0;
                    PBJ_PPTK.LinkParam = "";

        	        PBJ_PPTK.FieldType = 200;
        	        PBJ_PPTK.EditFormat = "Lookup wizard";
        	        PBJ_PPTK.ViewFormat = "";
        	        
        	        
        	        
        	                	        PBJ_PPTK.LookupType = 1;
        	                	        PBJ_PPTK.LookupWhere = "";
        	        PBJ_PPTK.LinkField = "[NIP]";
        	                	        PBJ_PPTK.DisplayField = "[NAMA]";
        	        PBJ_PPTK.LookupTable = "dbo.TMP_PPTK";
        	                	                	                	        PBJ_PPTK.NeedEncode = true;

                    PBJ_PPTK.ControlType = 0;

        	        PBJ_PPTK.GoodName = "PPTK";
        	                	        PBJ_PPTK.FullName = "PPTK";
        	         PBJ_PPTK.IsRequired = true;
        	                	        
        	        
        	        PBJ_PPTK.Index = 6;
        	        
        	                	                	                		                	        PBJ_PPTK.FieldPermissions = true;

        	        
                                            PBJ_PPTK.AddNewItem =  false ;
                                                PBJ_PPTK.LinkField = "NIP";
                        PBJ_PPTK.DisplayField = "NAMA";
                        PBJ_PPTK.LookupTable = "dbo.TMP_PPTK";
                        PBJ_PPTK.StrSize = 1;
                        		                                                
                                                		
		                                        		     PBJ_PPTK.OrderBy = "NAMA";
		                                            PBJ_PPTK.Container = tablePBJ;
        	        tablePBJ.Fields.Add("PPTK", PBJ_PPTK);
                    Field PBJ_KODEJENISKEGIATAN = new Field();
                    PBJ_KODEJENISKEGIATAN.Name = "KODEJENISKEGIATAN";
        	        PBJ_KODEJENISKEGIATAN.Label = "JENIS KEGIATAN";
        	        
        	        

                    PBJ_KODEJENISKEGIATAN.LinkNewWindow = 0;
                    PBJ_KODEJENISKEGIATAN.LinkDisplay = 0;
                    PBJ_KODEJENISKEGIATAN.LinkParam = "";

        	        PBJ_KODEJENISKEGIATAN.FieldType = 200;
        	        PBJ_KODEJENISKEGIATAN.EditFormat = "Lookup wizard";
        	        PBJ_KODEJENISKEGIATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	        PBJ_KODEJENISKEGIATAN.LookupType = 1;
        	                	        PBJ_KODEJENISKEGIATAN.LookupWhere = "";
        	        PBJ_KODEJENISKEGIATAN.LinkField = "[KODEJENISKEGIATAN]";
        	                	        PBJ_KODEJENISKEGIATAN.DisplayField = "[DESKRIPSI]";
        	        PBJ_KODEJENISKEGIATAN.LookupTable = "dbo.JENISKEGIATAN";
        	                	                	                	        PBJ_KODEJENISKEGIATAN.NeedEncode = true;

                    PBJ_KODEJENISKEGIATAN.ControlType = 0;

        	        PBJ_KODEJENISKEGIATAN.GoodName = "KODEJENISKEGIATAN";
        	                	        PBJ_KODEJENISKEGIATAN.FullName = "KODEJENISKEGIATAN";
        	         PBJ_KODEJENISKEGIATAN.IsRequired = true;
        	                	        
        	        
        	        PBJ_KODEJENISKEGIATAN.Index = 7;
        	        
        	                	                	                		                	        PBJ_KODEJENISKEGIATAN.FieldPermissions = true;

        	        
                                            PBJ_KODEJENISKEGIATAN.AddNewItem =  false ;
                                                PBJ_KODEJENISKEGIATAN.LinkField = "KODEJENISKEGIATAN";
                        PBJ_KODEJENISKEGIATAN.DisplayField = "DESKRIPSI";
                        PBJ_KODEJENISKEGIATAN.LookupTable = "dbo.JENISKEGIATAN";
                        PBJ_KODEJENISKEGIATAN.StrSize = 1;
                        		                                                
                                                		
		                                        		     PBJ_KODEJENISKEGIATAN.OrderBy = "KODEJENISKEGIATAN";
		                                            PBJ_KODEJENISKEGIATAN.Container = tablePBJ;
        	        tablePBJ.Fields.Add("KODEJENISKEGIATAN", PBJ_KODEJENISKEGIATAN);
                    Field PBJ_PROSESPENGADAAN = new Field();
                    PBJ_PROSESPENGADAAN.Name = "PROSESPENGADAAN";
        	        PBJ_PROSESPENGADAAN.Label = "PROSES PENGADAAN";
        	        
        	        

                    PBJ_PROSESPENGADAAN.LinkNewWindow = 0;
                    PBJ_PROSESPENGADAAN.LinkDisplay = 0;
                    PBJ_PROSESPENGADAAN.LinkParam = "";

        	        PBJ_PROSESPENGADAAN.FieldType = 200;
        	        PBJ_PROSESPENGADAAN.EditFormat = "Text field";
        	        PBJ_PROSESPENGADAAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_PROSESPENGADAAN.NeedEncode = true;

                    PBJ_PROSESPENGADAAN.ControlType = 0;

        	        PBJ_PROSESPENGADAAN.GoodName = "PROSESPENGADAAN";
        	                	        PBJ_PROSESPENGADAAN.FullName = "PROSESPENGADAAN";
        	        
        	                	        
        	        
        	        PBJ_PROSESPENGADAAN.Index = 8;
        	        
        	                	                	        PBJ_PROSESPENGADAAN.EditParams = "";
        	                	        PBJ_PROSESPENGADAAN.EditParams = PBJ_PROSESPENGADAAN.EditParams + " maxlength=500";
        	                	                		                	        PBJ_PROSESPENGADAAN.FieldPermissions = true;

        	        
                                        PBJ_PROSESPENGADAAN.Container = tablePBJ;
        	        tablePBJ.Fields.Add("PROSESPENGADAAN", PBJ_PROSESPENGADAAN);
                    Field PBJ_TANGGALPENGAJUAN = new Field();
                    PBJ_TANGGALPENGAJUAN.Name = "TANGGALPENGAJUAN";
        	        PBJ_TANGGALPENGAJUAN.Label = "TANGGAL PENGAJUAN";
        	        
        	        

                    PBJ_TANGGALPENGAJUAN.LinkNewWindow = 0;
                    PBJ_TANGGALPENGAJUAN.LinkDisplay = 0;
                    PBJ_TANGGALPENGAJUAN.LinkParam = "";

        	        PBJ_TANGGALPENGAJUAN.FieldType = 135;
        	        PBJ_TANGGALPENGAJUAN.EditFormat = "Date";
        	        PBJ_TANGGALPENGAJUAN.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        PBJ_TANGGALPENGAJUAN.NeedEncode = true;

                    PBJ_TANGGALPENGAJUAN.ControlType = 0;

        	        PBJ_TANGGALPENGAJUAN.GoodName = "TANGGALPENGAJUAN";
        	                	        PBJ_TANGGALPENGAJUAN.FullName = "TANGGALPENGAJUAN";
        	        
        	                	        
        	        
        	        PBJ_TANGGALPENGAJUAN.Index = 9;
        	         PBJ_TANGGALPENGAJUAN.DateEditType = 11;
        	                	                	                		                	        PBJ_TANGGALPENGAJUAN.FieldPermissions = true;

        	        
                                        PBJ_TANGGALPENGAJUAN.Container = tablePBJ;
        	        tablePBJ.Fields.Add("TANGGALPENGAJUAN", PBJ_TANGGALPENGAJUAN);
                    Field PBJ_PEMBAWABERKAS1 = new Field();
                    PBJ_PEMBAWABERKAS1.Name = "PEMBAWABERKAS1";
        	        PBJ_PEMBAWABERKAS1.Label = "PEMBAWA BERKAS 1";
        	        
        	        

                    PBJ_PEMBAWABERKAS1.LinkNewWindow = 0;
                    PBJ_PEMBAWABERKAS1.LinkDisplay = 0;
                    PBJ_PEMBAWABERKAS1.LinkParam = "";

        	        PBJ_PEMBAWABERKAS1.FieldType = 200;
        	        PBJ_PEMBAWABERKAS1.EditFormat = "Text field";
        	        PBJ_PEMBAWABERKAS1.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_PEMBAWABERKAS1.NeedEncode = true;

                    PBJ_PEMBAWABERKAS1.ControlType = 0;

        	        PBJ_PEMBAWABERKAS1.GoodName = "PEMBAWABERKAS1";
        	                	        PBJ_PEMBAWABERKAS1.FullName = "PEMBAWABERKAS1";
        	        
        	                	        
        	        
        	        PBJ_PEMBAWABERKAS1.Index = 10;
        	        
        	                	                	        PBJ_PEMBAWABERKAS1.EditParams = "";
        	                	        PBJ_PEMBAWABERKAS1.EditParams = PBJ_PEMBAWABERKAS1.EditParams + " maxlength=100";
        	                	                		                	        PBJ_PEMBAWABERKAS1.FieldPermissions = true;

        	        
                                        PBJ_PEMBAWABERKAS1.Container = tablePBJ;
        	        tablePBJ.Fields.Add("PEMBAWABERKAS1", PBJ_PEMBAWABERKAS1);
                    Field PBJ_PENERIMABERKAS1 = new Field();
                    PBJ_PENERIMABERKAS1.Name = "PENERIMABERKAS1";
        	        PBJ_PENERIMABERKAS1.Label = "PENERIMA BERKAS 1";
        	        
        	        

                    PBJ_PENERIMABERKAS1.LinkNewWindow = 0;
                    PBJ_PENERIMABERKAS1.LinkDisplay = 0;
                    PBJ_PENERIMABERKAS1.LinkParam = "";

        	        PBJ_PENERIMABERKAS1.FieldType = 200;
        	        PBJ_PENERIMABERKAS1.EditFormat = "Text field";
        	        PBJ_PENERIMABERKAS1.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_PENERIMABERKAS1.NeedEncode = true;

                    PBJ_PENERIMABERKAS1.ControlType = 0;

        	        PBJ_PENERIMABERKAS1.GoodName = "PENERIMABERKAS1";
        	                	        PBJ_PENERIMABERKAS1.FullName = "PENERIMABERKAS1";
        	        
        	                	        
        	        
        	        PBJ_PENERIMABERKAS1.Index = 11;
        	        
        	                	                	        PBJ_PENERIMABERKAS1.EditParams = "";
        	                	        PBJ_PENERIMABERKAS1.EditParams = PBJ_PENERIMABERKAS1.EditParams + " maxlength=50";
        	                	                		                	        PBJ_PENERIMABERKAS1.FieldPermissions = true;

        	        
                                        PBJ_PENERIMABERKAS1.Container = tablePBJ;
        	        tablePBJ.Fields.Add("PENERIMABERKAS1", PBJ_PENERIMABERKAS1);
                    Field PBJ_PEMBAWABERKAS2 = new Field();
                    PBJ_PEMBAWABERKAS2.Name = "PEMBAWABERKAS2";
        	        PBJ_PEMBAWABERKAS2.Label = "PEMBAWA BERKAS 2";
        	        
        	        

                    PBJ_PEMBAWABERKAS2.LinkNewWindow = 0;
                    PBJ_PEMBAWABERKAS2.LinkDisplay = 0;
                    PBJ_PEMBAWABERKAS2.LinkParam = "";

        	        PBJ_PEMBAWABERKAS2.FieldType = 200;
        	        PBJ_PEMBAWABERKAS2.EditFormat = "Text field";
        	        PBJ_PEMBAWABERKAS2.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_PEMBAWABERKAS2.NeedEncode = true;

                    PBJ_PEMBAWABERKAS2.ControlType = 0;

        	        PBJ_PEMBAWABERKAS2.GoodName = "PEMBAWABERKAS2";
        	                	        PBJ_PEMBAWABERKAS2.FullName = "PEMBAWABERKAS2";
        	        
        	                	        
        	        
        	        PBJ_PEMBAWABERKAS2.Index = 12;
        	        
        	                	                	        PBJ_PEMBAWABERKAS2.EditParams = "";
        	                	        PBJ_PEMBAWABERKAS2.EditParams = PBJ_PEMBAWABERKAS2.EditParams + " maxlength=100";
        	                	                		                	        PBJ_PEMBAWABERKAS2.FieldPermissions = true;

        	        
                                        PBJ_PEMBAWABERKAS2.Container = tablePBJ;
        	        tablePBJ.Fields.Add("PEMBAWABERKAS2", PBJ_PEMBAWABERKAS2);
                    Field PBJ_PENERIMABERKAS2 = new Field();
                    PBJ_PENERIMABERKAS2.Name = "PENERIMABERKAS2";
        	        PBJ_PENERIMABERKAS2.Label = "PENERIMA BERKAS 2";
        	        
        	        

                    PBJ_PENERIMABERKAS2.LinkNewWindow = 0;
                    PBJ_PENERIMABERKAS2.LinkDisplay = 0;
                    PBJ_PENERIMABERKAS2.LinkParam = "";

        	        PBJ_PENERIMABERKAS2.FieldType = 200;
        	        PBJ_PENERIMABERKAS2.EditFormat = "Text field";
        	        PBJ_PENERIMABERKAS2.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_PENERIMABERKAS2.NeedEncode = true;

                    PBJ_PENERIMABERKAS2.ControlType = 0;

        	        PBJ_PENERIMABERKAS2.GoodName = "PENERIMABERKAS2";
        	                	        PBJ_PENERIMABERKAS2.FullName = "PENERIMABERKAS2";
        	        
        	                	        
        	        
        	        PBJ_PENERIMABERKAS2.Index = 13;
        	        
        	                	                	        PBJ_PENERIMABERKAS2.EditParams = "";
        	                	        PBJ_PENERIMABERKAS2.EditParams = PBJ_PENERIMABERKAS2.EditParams + " maxlength=50";
        	                	                		                	        PBJ_PENERIMABERKAS2.FieldPermissions = true;

        	        
                                        PBJ_PENERIMABERKAS2.Container = tablePBJ;
        	        tablePBJ.Fields.Add("PENERIMABERKAS2", PBJ_PENERIMABERKAS2);
                    Field PBJ_LENGKAP = new Field();
                    PBJ_LENGKAP.Name = "LENGKAP";
        	        
        	        
        	        

                    PBJ_LENGKAP.LinkNewWindow = 0;
                    PBJ_LENGKAP.LinkDisplay = 0;
                    PBJ_LENGKAP.LinkParam = "";

        	        PBJ_LENGKAP.FieldType = 200;
        	        PBJ_LENGKAP.EditFormat = "Lookup wizard";
        	        PBJ_LENGKAP.ViewFormat = "";
        	        
        	        
        	        
        	                	        PBJ_LENGKAP.LookupType = 0;
        	                	                	                	                	        PBJ_LENGKAP.NeedEncode = true;

                    PBJ_LENGKAP.ControlType = 0;

        	        PBJ_LENGKAP.GoodName = "LENGKAP";
        	                	        PBJ_LENGKAP.FullName = "LENGKAP";
        	        
        	                	        
        	        
        	        PBJ_LENGKAP.Index = 14;
        	        
        	                	                	                		                	        PBJ_LENGKAP.FieldPermissions = true;

        	        
                                            PBJ_LENGKAP.AddNewItem =  false ;
                                                PBJ_LENGKAP.LinkField = "";
                        PBJ_LENGKAP.DisplayField = "";
                        PBJ_LENGKAP.LookupTable = "";
                        PBJ_LENGKAP.StrSize = 1;
                                                    int dPBJ_LENGKAP = 0;
		                    PBJ_LENGKAP.Arr.Add(dPBJ_LENGKAP,"YA");
		                    dPBJ_LENGKAP = dPBJ_LENGKAP + 1;
		                    PBJ_LENGKAP.Arr.Add(dPBJ_LENGKAP,"TIDAK");
		                    dPBJ_LENGKAP = dPBJ_LENGKAP + 1;
                    PBJ_LENGKAP.Container = tablePBJ;
				        PBJ_LENGKAP.LookupFields.Add(new LookupField("YA", "YA"));
				        PBJ_LENGKAP.LookupFields.Add(new LookupField("TIDAK", "TIDAK"));
        	        tablePBJ.Fields.Add("LENGKAP", PBJ_LENGKAP);
                    Field PBJ_DIKEMBALIKAN = new Field();
                    PBJ_DIKEMBALIKAN.Name = "DIKEMBALIKAN";
        	        
        	        
        	        

                    PBJ_DIKEMBALIKAN.LinkNewWindow = 0;
                    PBJ_DIKEMBALIKAN.LinkDisplay = 0;
                    PBJ_DIKEMBALIKAN.LinkParam = "";

        	        PBJ_DIKEMBALIKAN.FieldType = 200;
        	        PBJ_DIKEMBALIKAN.EditFormat = "Lookup wizard";
        	        PBJ_DIKEMBALIKAN.ViewFormat = "";
        	        
        	        
        	        
        	                	        PBJ_DIKEMBALIKAN.LookupType = 0;
        	                	                	                	                	        PBJ_DIKEMBALIKAN.NeedEncode = true;

                    PBJ_DIKEMBALIKAN.ControlType = 0;

        	        PBJ_DIKEMBALIKAN.GoodName = "DIKEMBALIKAN";
        	                	        PBJ_DIKEMBALIKAN.FullName = "DIKEMBALIKAN";
        	        
        	                	        
        	        
        	        PBJ_DIKEMBALIKAN.Index = 15;
        	        
        	                	                	                		                	        PBJ_DIKEMBALIKAN.FieldPermissions = true;

        	        
                                            PBJ_DIKEMBALIKAN.AddNewItem =  false ;
                                                PBJ_DIKEMBALIKAN.LinkField = "";
                        PBJ_DIKEMBALIKAN.DisplayField = "";
                        PBJ_DIKEMBALIKAN.LookupTable = "";
                        PBJ_DIKEMBALIKAN.StrSize = 1;
                                                    int dPBJ_DIKEMBALIKAN = 0;
		                    PBJ_DIKEMBALIKAN.Arr.Add(dPBJ_DIKEMBALIKAN,"YA");
		                    dPBJ_DIKEMBALIKAN = dPBJ_DIKEMBALIKAN + 1;
		                    PBJ_DIKEMBALIKAN.Arr.Add(dPBJ_DIKEMBALIKAN,"TIDAK");
		                    dPBJ_DIKEMBALIKAN = dPBJ_DIKEMBALIKAN + 1;
                    PBJ_DIKEMBALIKAN.Container = tablePBJ;
				        PBJ_DIKEMBALIKAN.LookupFields.Add(new LookupField("YA", "YA"));
				        PBJ_DIKEMBALIKAN.LookupFields.Add(new LookupField("TIDAK", "TIDAK"));
        	        tablePBJ.Fields.Add("DIKEMBALIKAN", PBJ_DIKEMBALIKAN);
                    Field PBJ_TANGGALKEMBALI = new Field();
                    PBJ_TANGGALKEMBALI.Name = "TANGGALKEMBALI";
        	        PBJ_TANGGALKEMBALI.Label = "TANGGAL KEMBALI";
        	        
        	        

                    PBJ_TANGGALKEMBALI.LinkNewWindow = 0;
                    PBJ_TANGGALKEMBALI.LinkDisplay = 0;
                    PBJ_TANGGALKEMBALI.LinkParam = "";

        	        PBJ_TANGGALKEMBALI.FieldType = 135;
        	        PBJ_TANGGALKEMBALI.EditFormat = "Date";
        	        PBJ_TANGGALKEMBALI.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        PBJ_TANGGALKEMBALI.NeedEncode = true;

                    PBJ_TANGGALKEMBALI.ControlType = 0;

        	        PBJ_TANGGALKEMBALI.GoodName = "TANGGALKEMBALI";
        	                	        PBJ_TANGGALKEMBALI.FullName = "TANGGALKEMBALI";
        	        
        	                	        
        	        
        	        PBJ_TANGGALKEMBALI.Index = 16;
        	         PBJ_TANGGALKEMBALI.DateEditType = 11;
        	                	                	                		                	        PBJ_TANGGALKEMBALI.FieldPermissions = true;

        	        
                                        PBJ_TANGGALKEMBALI.Container = tablePBJ;
        	        tablePBJ.Fields.Add("TANGGALKEMBALI", PBJ_TANGGALKEMBALI);
                    Field PBJ_KODESTATUSPBJ = new Field();
                    PBJ_KODESTATUSPBJ.Name = "KODESTATUSPBJ";
        	        PBJ_KODESTATUSPBJ.Label = "STATUS";
        	        
        	        

                    PBJ_KODESTATUSPBJ.LinkNewWindow = 0;
                    PBJ_KODESTATUSPBJ.LinkDisplay = 0;
                    PBJ_KODESTATUSPBJ.LinkParam = "";

        	        PBJ_KODESTATUSPBJ.FieldType = 200;
        	        PBJ_KODESTATUSPBJ.EditFormat = "Lookup wizard";
        	        PBJ_KODESTATUSPBJ.ViewFormat = "";
        	        
        	        
        	        
        	                	        PBJ_KODESTATUSPBJ.LookupType = 1;
        	                	        PBJ_KODESTATUSPBJ.LookupWhere = "";
        	        PBJ_KODESTATUSPBJ.LinkField = "[KODESTATUS]";
        	                	        PBJ_KODESTATUSPBJ.DisplayField = "[DESKRIPSI]";
        	        PBJ_KODESTATUSPBJ.LookupTable = "dbo.STATUSPBJ";
        	                	                	                	        PBJ_KODESTATUSPBJ.NeedEncode = true;

                    PBJ_KODESTATUSPBJ.ControlType = 0;

        	        PBJ_KODESTATUSPBJ.GoodName = "KODESTATUSPBJ";
        	                	        PBJ_KODESTATUSPBJ.FullName = "KODESTATUSPBJ";
        	         PBJ_KODESTATUSPBJ.IsRequired = true;
        	                	        
        	        
        	        PBJ_KODESTATUSPBJ.Index = 17;
        	        
        	                	                	                		                	        PBJ_KODESTATUSPBJ.FieldPermissions = true;

        	        
                                            PBJ_KODESTATUSPBJ.AddNewItem =  false ;
                                                PBJ_KODESTATUSPBJ.LinkField = "KODESTATUS";
                        PBJ_KODESTATUSPBJ.DisplayField = "DESKRIPSI";
                        PBJ_KODESTATUSPBJ.LookupTable = "dbo.STATUSPBJ";
                        PBJ_KODESTATUSPBJ.StrSize = 1;
                        		                                                
                                                		
		                                        		     PBJ_KODESTATUSPBJ.OrderBy = "URUTAN";
		                                            PBJ_KODESTATUSPBJ.Container = tablePBJ;
        	        tablePBJ.Fields.Add("KODESTATUSPBJ", PBJ_KODESTATUSPBJ);
                    Field PBJ_CATATAN = new Field();
                    PBJ_CATATAN.Name = "CATATAN";
        	        PBJ_CATATAN.Label = "TAMBAHAN KELENGKAPAN";
        	        
        	        

                    PBJ_CATATAN.LinkNewWindow = 0;
                    PBJ_CATATAN.LinkDisplay = 0;
                    PBJ_CATATAN.LinkParam = "";

        	        PBJ_CATATAN.FieldType = 200;
        	        PBJ_CATATAN.EditFormat = "Text field";
        	        PBJ_CATATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_CATATAN.NeedEncode = true;

                    PBJ_CATATAN.ControlType = 0;

        	        PBJ_CATATAN.GoodName = "CATATAN";
        	                	        PBJ_CATATAN.FullName = "CATATAN";
        	        
        	                	        
        	        
        	        PBJ_CATATAN.Index = 18;
        	        
        	                	                	        PBJ_CATATAN.EditParams = "";
        	                	        PBJ_CATATAN.EditParams = PBJ_CATATAN.EditParams + " maxlength=500";
        	                	                		                	        PBJ_CATATAN.FieldPermissions = true;

        	        
                                        PBJ_CATATAN.Container = tablePBJ;
        	        tablePBJ.Fields.Add("CATATAN", PBJ_CATATAN);
                    Field PBJ_DIBUATOLEH = new Field();
                    PBJ_DIBUATOLEH.Name = "DIBUATOLEH";
        	        
        	        
        	        

                    PBJ_DIBUATOLEH.LinkNewWindow = 0;
                    PBJ_DIBUATOLEH.LinkDisplay = 0;
                    PBJ_DIBUATOLEH.LinkParam = "";

        	        PBJ_DIBUATOLEH.FieldType = 200;
        	        PBJ_DIBUATOLEH.EditFormat = "Text field";
        	        PBJ_DIBUATOLEH.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_DIBUATOLEH.NeedEncode = true;

                    PBJ_DIBUATOLEH.ControlType = 0;

        	        PBJ_DIBUATOLEH.GoodName = "DIBUATOLEH";
        	                	        PBJ_DIBUATOLEH.FullName = "DIBUATOLEH";
        	        
        	                	        
        	        
        	        PBJ_DIBUATOLEH.Index = 19;
        	        
        	                	                	        PBJ_DIBUATOLEH.EditParams = "";
        	                	        PBJ_DIBUATOLEH.EditParams = PBJ_DIBUATOLEH.EditParams + " maxlength=50";
        	                	                		        
        	        
                                        PBJ_DIBUATOLEH.Container = tablePBJ;
        	        tablePBJ.Fields.Add("DIBUATOLEH", PBJ_DIBUATOLEH);
                    Field PBJ_TANGGALDIBUAT = new Field();
                    PBJ_TANGGALDIBUAT.Name = "TANGGALDIBUAT";
        	        
        	        
        	        

                    PBJ_TANGGALDIBUAT.LinkNewWindow = 0;
                    PBJ_TANGGALDIBUAT.LinkDisplay = 0;
                    PBJ_TANGGALDIBUAT.LinkParam = "";

        	        PBJ_TANGGALDIBUAT.FieldType = 135;
        	        PBJ_TANGGALDIBUAT.EditFormat = "Date";
        	        PBJ_TANGGALDIBUAT.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        PBJ_TANGGALDIBUAT.NeedEncode = true;

                    PBJ_TANGGALDIBUAT.ControlType = 0;

        	        PBJ_TANGGALDIBUAT.GoodName = "TANGGALDIBUAT";
        	                	        PBJ_TANGGALDIBUAT.FullName = "TANGGALDIBUAT";
        	        
        	                	        
        	        
        	        PBJ_TANGGALDIBUAT.Index = 20;
        	         PBJ_TANGGALDIBUAT.DateEditType = 13;
        	                	                	                		        
        	        
                                        PBJ_TANGGALDIBUAT.Container = tablePBJ;
        	        tablePBJ.Fields.Add("TANGGALDIBUAT", PBJ_TANGGALDIBUAT);
                    Field PBJ_MODIFIKASIOLEH = new Field();
                    PBJ_MODIFIKASIOLEH.Name = "MODIFIKASIOLEH";
        	        
        	        
        	        

                    PBJ_MODIFIKASIOLEH.LinkNewWindow = 0;
                    PBJ_MODIFIKASIOLEH.LinkDisplay = 0;
                    PBJ_MODIFIKASIOLEH.LinkParam = "";

        	        PBJ_MODIFIKASIOLEH.FieldType = 200;
        	        PBJ_MODIFIKASIOLEH.EditFormat = "Text field";
        	        PBJ_MODIFIKASIOLEH.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PBJ_MODIFIKASIOLEH.NeedEncode = true;

                    PBJ_MODIFIKASIOLEH.ControlType = 0;

        	        PBJ_MODIFIKASIOLEH.GoodName = "MODIFIKASIOLEH";
        	                	        PBJ_MODIFIKASIOLEH.FullName = "MODIFIKASIOLEH";
        	        
        	                	        
        	        
        	        PBJ_MODIFIKASIOLEH.Index = 21;
        	        
        	                	                	        PBJ_MODIFIKASIOLEH.EditParams = "";
        	                	        PBJ_MODIFIKASIOLEH.EditParams = PBJ_MODIFIKASIOLEH.EditParams + " maxlength=50";
        	                	                		        
        	        
                                        PBJ_MODIFIKASIOLEH.Container = tablePBJ;
        	        tablePBJ.Fields.Add("MODIFIKASIOLEH", PBJ_MODIFIKASIOLEH);
                    Field PBJ_TANGGALMODIFIKASI = new Field();
                    PBJ_TANGGALMODIFIKASI.Name = "TANGGALMODIFIKASI";
        	        
        	        
        	        

                    PBJ_TANGGALMODIFIKASI.LinkNewWindow = 0;
                    PBJ_TANGGALMODIFIKASI.LinkDisplay = 0;
                    PBJ_TANGGALMODIFIKASI.LinkParam = "";

        	        PBJ_TANGGALMODIFIKASI.FieldType = 135;
        	        PBJ_TANGGALMODIFIKASI.EditFormat = "Date";
        	        PBJ_TANGGALMODIFIKASI.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        PBJ_TANGGALMODIFIKASI.NeedEncode = true;

                    PBJ_TANGGALMODIFIKASI.ControlType = 0;

        	        PBJ_TANGGALMODIFIKASI.GoodName = "TANGGALMODIFIKASI";
        	                	        PBJ_TANGGALMODIFIKASI.FullName = "TANGGALMODIFIKASI";
        	        
        	                	        
        	        
        	        PBJ_TANGGALMODIFIKASI.Index = 22;
        	         PBJ_TANGGALMODIFIKASI.DateEditType = 13;
        	                	                	                		        
        	        
                                        PBJ_TANGGALMODIFIKASI.Container = tablePBJ;
        	        tablePBJ.Fields.Add("TANGGALMODIFIKASI", PBJ_TANGGALMODIFIKASI);
                builder.Tables.Add("dbo.PBJ", tablePBJ);
                builder.SubSonicTables.Add("PBJ", tablePBJ);
                Table tableKELOMPOKPENGGUNA = new Table();
                tableKELOMPOKPENGGUNA.ShortName = "KELOMPOKPENGGUNA";
                tableKELOMPOKPENGGUNA.TableName = "dbo.KELOMPOKPENGGUNA";
                            tableKELOMPOKPENGGUNA.DataSourceTable = "dbo.KELOMPOKPENGGUNA";
                tableKELOMPOKPENGGUNA.OwnerID = "";
                    Field KELOMPOKPENGGUNA_KODEKELOMPOK = new Field();
                    KELOMPOKPENGGUNA_KODEKELOMPOK.Name = "KODEKELOMPOK";
        	        KELOMPOKPENGGUNA_KODEKELOMPOK.Label = "KODE KELOMPOK";
        	        
        	        

                    KELOMPOKPENGGUNA_KODEKELOMPOK.LinkNewWindow = 0;
                    KELOMPOKPENGGUNA_KODEKELOMPOK.LinkDisplay = 0;
                    KELOMPOKPENGGUNA_KODEKELOMPOK.LinkParam = "";

        	        KELOMPOKPENGGUNA_KODEKELOMPOK.FieldType = 200;
        	        KELOMPOKPENGGUNA_KODEKELOMPOK.EditFormat = "Text field";
        	        KELOMPOKPENGGUNA_KODEKELOMPOK.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        KELOMPOKPENGGUNA_KODEKELOMPOK.NeedEncode = true;

                    KELOMPOKPENGGUNA_KODEKELOMPOK.ControlType = 0;

        	        KELOMPOKPENGGUNA_KODEKELOMPOK.GoodName = "KODEKELOMPOK";
        	                	        KELOMPOKPENGGUNA_KODEKELOMPOK.FullName = "KODEKELOMPOK";
        	         KELOMPOKPENGGUNA_KODEKELOMPOK.IsRequired = true;
        	                	        
        	        
        	        KELOMPOKPENGGUNA_KODEKELOMPOK.Index = 1;
        	        
        	                	                	        KELOMPOKPENGGUNA_KODEKELOMPOK.EditParams = "";
        	                	        KELOMPOKPENGGUNA_KODEKELOMPOK.EditParams = KELOMPOKPENGGUNA_KODEKELOMPOK.EditParams + " maxlength=20";
        	                	                		                	        KELOMPOKPENGGUNA_KODEKELOMPOK.FieldPermissions = true;

        	        
                                        KELOMPOKPENGGUNA_KODEKELOMPOK.Container = tableKELOMPOKPENGGUNA;
        	        tableKELOMPOKPENGGUNA.Fields.Add("KODEKELOMPOK", KELOMPOKPENGGUNA_KODEKELOMPOK);
                    Field KELOMPOKPENGGUNA_DESKRIPSI = new Field();
                    KELOMPOKPENGGUNA_DESKRIPSI.Name = "DESKRIPSI";
        	        
        	        
        	        

                    KELOMPOKPENGGUNA_DESKRIPSI.LinkNewWindow = 0;
                    KELOMPOKPENGGUNA_DESKRIPSI.LinkDisplay = 0;
                    KELOMPOKPENGGUNA_DESKRIPSI.LinkParam = "";

        	        KELOMPOKPENGGUNA_DESKRIPSI.FieldType = 200;
        	        KELOMPOKPENGGUNA_DESKRIPSI.EditFormat = "Text field";
        	        KELOMPOKPENGGUNA_DESKRIPSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        KELOMPOKPENGGUNA_DESKRIPSI.NeedEncode = true;

                    KELOMPOKPENGGUNA_DESKRIPSI.ControlType = 0;

        	        KELOMPOKPENGGUNA_DESKRIPSI.GoodName = "DESKRIPSI";
        	                	        KELOMPOKPENGGUNA_DESKRIPSI.FullName = "DESKRIPSI";
        	        
        	                	        
        	        
        	        KELOMPOKPENGGUNA_DESKRIPSI.Index = 2;
        	        
        	                	                	        KELOMPOKPENGGUNA_DESKRIPSI.EditParams = "";
        	                	        KELOMPOKPENGGUNA_DESKRIPSI.EditParams = KELOMPOKPENGGUNA_DESKRIPSI.EditParams + " maxlength=100";
        	                	                		                	        KELOMPOKPENGGUNA_DESKRIPSI.FieldPermissions = true;

        	        
                                        KELOMPOKPENGGUNA_DESKRIPSI.Container = tableKELOMPOKPENGGUNA;
        	        tableKELOMPOKPENGGUNA.Fields.Add("DESKRIPSI", KELOMPOKPENGGUNA_DESKRIPSI);
                builder.Tables.Add("dbo.KELOMPOKPENGGUNA", tableKELOMPOKPENGGUNA);
                builder.SubSonicTables.Add("KELOMPOKPENGGUNA", tableKELOMPOKPENGGUNA);
                Table tablePOKJA = new Table();
                tablePOKJA.ShortName = "POKJA";
                tablePOKJA.TableName = "dbo.POKJA";
                            tablePOKJA.DataSourceTable = "dbo.POKJA";
                tablePOKJA.OwnerID = "";
                    Field POKJA_KODEPOKJA = new Field();
                    POKJA_KODEPOKJA.Name = "KODEPOKJA";
        	        POKJA_KODEPOKJA.Label = "KODE POKJA";
        	        
        	        

                    POKJA_KODEPOKJA.LinkNewWindow = 0;
                    POKJA_KODEPOKJA.LinkDisplay = 0;
                    POKJA_KODEPOKJA.LinkParam = "";

        	        POKJA_KODEPOKJA.FieldType = 200;
        	        POKJA_KODEPOKJA.EditFormat = "Text field";
        	        POKJA_KODEPOKJA.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        POKJA_KODEPOKJA.NeedEncode = true;

                    POKJA_KODEPOKJA.ControlType = 0;

        	        POKJA_KODEPOKJA.GoodName = "KODEPOKJA";
        	                	        POKJA_KODEPOKJA.FullName = "KODEPOKJA";
        	         POKJA_KODEPOKJA.IsRequired = true;
        	                	        
        	        
        	        POKJA_KODEPOKJA.Index = 1;
        	        
        	                	                	        POKJA_KODEPOKJA.EditParams = "";
        	                	        POKJA_KODEPOKJA.EditParams = POKJA_KODEPOKJA.EditParams + " maxlength=5";
        	                	                		                	        POKJA_KODEPOKJA.FieldPermissions = true;

        	        
                                        POKJA_KODEPOKJA.Container = tablePOKJA;
        	        tablePOKJA.Fields.Add("KODEPOKJA", POKJA_KODEPOKJA);
                    Field POKJA_NAMA = new Field();
                    POKJA_NAMA.Name = "NAMA";
        	        
        	        
        	        

                    POKJA_NAMA.LinkNewWindow = 0;
                    POKJA_NAMA.LinkDisplay = 0;
                    POKJA_NAMA.LinkParam = "";

        	        POKJA_NAMA.FieldType = 200;
        	        POKJA_NAMA.EditFormat = "Text field";
        	        POKJA_NAMA.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        POKJA_NAMA.NeedEncode = true;

                    POKJA_NAMA.ControlType = 0;

        	        POKJA_NAMA.GoodName = "NAMA";
        	                	        POKJA_NAMA.FullName = "NAMA";
        	        
        	                	        
        	        
        	        POKJA_NAMA.Index = 2;
        	        
        	                	                	        POKJA_NAMA.EditParams = "";
        	                	        POKJA_NAMA.EditParams = POKJA_NAMA.EditParams + " maxlength=100";
        	                	                		                	        POKJA_NAMA.FieldPermissions = true;

        	        
                                        POKJA_NAMA.Container = tablePOKJA;
        	        tablePOKJA.Fields.Add("NAMA", POKJA_NAMA);
                    Field POKJA_DESKRIPSSI = new Field();
                    POKJA_DESKRIPSSI.Name = "DESKRIPSSI";
        	        POKJA_DESKRIPSSI.Label = "DESKRIPSI";
        	        
        	        

                    POKJA_DESKRIPSSI.LinkNewWindow = 0;
                    POKJA_DESKRIPSSI.LinkDisplay = 0;
                    POKJA_DESKRIPSSI.LinkParam = "";

        	        POKJA_DESKRIPSSI.FieldType = 200;
        	        POKJA_DESKRIPSSI.EditFormat = "Text field";
        	        POKJA_DESKRIPSSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        POKJA_DESKRIPSSI.NeedEncode = true;

                    POKJA_DESKRIPSSI.ControlType = 0;

        	        POKJA_DESKRIPSSI.GoodName = "DESKRIPSSI";
        	                	        POKJA_DESKRIPSSI.FullName = "DESKRIPSSI";
        	        
        	                	        
        	        
        	        POKJA_DESKRIPSSI.Index = 3;
        	        
        	                	                	        POKJA_DESKRIPSSI.EditParams = "";
        	                	        POKJA_DESKRIPSSI.EditParams = POKJA_DESKRIPSSI.EditParams + " maxlength=500";
        	                	                		                	        POKJA_DESKRIPSSI.FieldPermissions = true;

        	        
                                        POKJA_DESKRIPSSI.Container = tablePOKJA;
        	        tablePOKJA.Fields.Add("DESKRIPSSI", POKJA_DESKRIPSSI);
                builder.Tables.Add("dbo.POKJA", tablePOKJA);
                builder.SubSonicTables.Add("POKJA", tablePOKJA);
                Table tablePENGADAAN_LANGSUNG = new Table();
                tablePENGADAAN_LANGSUNG.ShortName = "PENGADAAN_LANGSUNG";
                tablePENGADAAN_LANGSUNG.TableName = "dbo.PENGADAAN_LANGSUNG";
                            tablePENGADAAN_LANGSUNG.DataSourceTable = "dbo.PENGADAAN_LANGSUNG";
                tablePENGADAAN_LANGSUNG.OwnerID = "";
                    Field PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG = new Field();
                    PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.Name = "KODEPENGADAANLANGSUNG";
        	        
        	        
        	        

                    PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.LinkParam = "";

        	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.FieldType = 200;
        	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.EditFormat = "Text field";
        	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.NeedEncode = true;

                    PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.ControlType = 0;

        	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.GoodName = "KODEPENGADAANLANGSUNG";
        	                	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.FullName = "KODEPENGADAANLANGSUNG";
        	        
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.Index = 1;
        	        
        	                	                	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.EditParams = "";
        	                	        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.EditParams = PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.EditParams + " maxlength=50";
        	                	                		        
        	        
                                        PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("KODEPENGADAANLANGSUNG", PENGADAAN_LANGSUNG_KODEPENGADAANLANGSUNG);
                    Field PENGADAAN_LANGSUNG_NAMAKEGIATAN = new Field();
                    PENGADAAN_LANGSUNG_NAMAKEGIATAN.Name = "NAMAKEGIATAN";
        	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.Label = "NAMA KEGIATAN";
        	        
        	        

                    PENGADAAN_LANGSUNG_NAMAKEGIATAN.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_NAMAKEGIATAN.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_NAMAKEGIATAN.LinkParam = "";

        	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.FieldType = 200;
        	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.EditFormat = "Text field";
        	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.NeedEncode = true;

                    PENGADAAN_LANGSUNG_NAMAKEGIATAN.ControlType = 0;

        	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.GoodName = "NAMAKEGIATAN";
        	                	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.FullName = "NAMAKEGIATAN";
        	         PENGADAAN_LANGSUNG_NAMAKEGIATAN.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.Index = 2;
        	        
        	                	                	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.EditParams = "";
        	                	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.EditParams = PENGADAAN_LANGSUNG_NAMAKEGIATAN.EditParams + " maxlength=255";
        	                	                		                	        PENGADAAN_LANGSUNG_NAMAKEGIATAN.FieldPermissions = true;

        	        
                                        PENGADAAN_LANGSUNG_NAMAKEGIATAN.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("NAMAKEGIATAN", PENGADAAN_LANGSUNG_NAMAKEGIATAN);
                    Field PENGADAAN_LANGSUNG_NAMAPAKET = new Field();
                    PENGADAAN_LANGSUNG_NAMAPAKET.Name = "NAMAPAKET";
        	        PENGADAAN_LANGSUNG_NAMAPAKET.Label = "NAMA PAKET";
        	        
        	        

                    PENGADAAN_LANGSUNG_NAMAPAKET.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_NAMAPAKET.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_NAMAPAKET.LinkParam = "";

        	        PENGADAAN_LANGSUNG_NAMAPAKET.FieldType = 200;
        	        PENGADAAN_LANGSUNG_NAMAPAKET.EditFormat = "Text field";
        	        PENGADAAN_LANGSUNG_NAMAPAKET.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        PENGADAAN_LANGSUNG_NAMAPAKET.NeedEncode = true;

                    PENGADAAN_LANGSUNG_NAMAPAKET.ControlType = 0;

        	        PENGADAAN_LANGSUNG_NAMAPAKET.GoodName = "NAMAPAKET";
        	                	        PENGADAAN_LANGSUNG_NAMAPAKET.FullName = "NAMAPAKET";
        	         PENGADAAN_LANGSUNG_NAMAPAKET.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_NAMAPAKET.Index = 3;
        	        
        	                	                	        PENGADAAN_LANGSUNG_NAMAPAKET.EditParams = "";
        	                	        PENGADAAN_LANGSUNG_NAMAPAKET.EditParams = PENGADAAN_LANGSUNG_NAMAPAKET.EditParams + " maxlength=255";
        	                	                		                	        PENGADAAN_LANGSUNG_NAMAPAKET.FieldPermissions = true;

        	        
                                        PENGADAAN_LANGSUNG_NAMAPAKET.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("NAMAPAKET", PENGADAAN_LANGSUNG_NAMAPAKET);
                    Field PENGADAAN_LANGSUNG_KODESKPD = new Field();
                    PENGADAAN_LANGSUNG_KODESKPD.Name = "KODESKPD";
        	        PENGADAAN_LANGSUNG_KODESKPD.Label = "SKPD";
        	        
        	        

                    PENGADAAN_LANGSUNG_KODESKPD.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_KODESKPD.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_KODESKPD.LinkParam = "";

        	        PENGADAAN_LANGSUNG_KODESKPD.FieldType = 200;
        	        PENGADAAN_LANGSUNG_KODESKPD.EditFormat = "Lookup wizard";
        	        PENGADAAN_LANGSUNG_KODESKPD.ViewFormat = "";
        	        
        	        
        	        
        	                	        PENGADAAN_LANGSUNG_KODESKPD.LookupType = 1;
        	                	        PENGADAAN_LANGSUNG_KODESKPD.LookupWhere = "";
        	        PENGADAAN_LANGSUNG_KODESKPD.LinkField = "[KODESKPD]";
        	                	        PENGADAAN_LANGSUNG_KODESKPD.DisplayField = "[DESKRIPSI]";
        	        PENGADAAN_LANGSUNG_KODESKPD.LookupTable = "dbo.SKPD";
        	                	                	                	        PENGADAAN_LANGSUNG_KODESKPD.NeedEncode = true;

                    PENGADAAN_LANGSUNG_KODESKPD.ControlType = 0;

        	        PENGADAAN_LANGSUNG_KODESKPD.GoodName = "KODESKPD";
        	                	        PENGADAAN_LANGSUNG_KODESKPD.FullName = "KODESKPD";
        	         PENGADAAN_LANGSUNG_KODESKPD.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_KODESKPD.Index = 4;
        	        
        	                	                	                		                	        PENGADAAN_LANGSUNG_KODESKPD.FieldPermissions = true;

        	        
                                            PENGADAAN_LANGSUNG_KODESKPD.AddNewItem =  false ;
                                                PENGADAAN_LANGSUNG_KODESKPD.LinkField = "KODESKPD";
                        PENGADAAN_LANGSUNG_KODESKPD.DisplayField = "DESKRIPSI";
                        PENGADAAN_LANGSUNG_KODESKPD.LookupTable = "dbo.SKPD";
                        PENGADAAN_LANGSUNG_KODESKPD.StrSize = 1;
                        		                                                
                                                		
		                                        		     PENGADAAN_LANGSUNG_KODESKPD.OrderBy = "DESKRIPSI";
		                                            PENGADAAN_LANGSUNG_KODESKPD.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("KODESKPD", PENGADAAN_LANGSUNG_KODESKPD);
                    Field PENGADAAN_LANGSUNG_TANGGALKONTRAK = new Field();
                    PENGADAAN_LANGSUNG_TANGGALKONTRAK.Name = "TANGGALKONTRAK";
        	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.Label = "TANGGAL KONTRAK";
        	        
        	        

                    PENGADAAN_LANGSUNG_TANGGALKONTRAK.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_TANGGALKONTRAK.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_TANGGALKONTRAK.LinkParam = "";

        	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.FieldType = 135;
        	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.EditFormat = "Date";
        	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.NeedEncode = true;

                    PENGADAAN_LANGSUNG_TANGGALKONTRAK.ControlType = 0;

        	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.GoodName = "TANGGALKONTRAK";
        	                	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.FullName = "TANGGALKONTRAK";
        	         PENGADAAN_LANGSUNG_TANGGALKONTRAK.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.Index = 5;
        	         PENGADAAN_LANGSUNG_TANGGALKONTRAK.DateEditType = 11;
        	                	                	                		                	        PENGADAAN_LANGSUNG_TANGGALKONTRAK.FieldPermissions = true;

        	        
                                        PENGADAAN_LANGSUNG_TANGGALKONTRAK.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("TANGGALKONTRAK", PENGADAAN_LANGSUNG_TANGGALKONTRAK);
                    Field PENGADAAN_LANGSUNG_PAGU = new Field();
                    PENGADAAN_LANGSUNG_PAGU.Name = "PAGU";
        	        
        	        
        	        

                    PENGADAAN_LANGSUNG_PAGU.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_PAGU.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_PAGU.LinkParam = "";

        	        PENGADAAN_LANGSUNG_PAGU.FieldType = 6;
        	        PENGADAAN_LANGSUNG_PAGU.EditFormat = "Text field";
        	        PENGADAAN_LANGSUNG_PAGU.ViewFormat = "Number";
        	        
        	        
        	        
        	                	                	                	        PENGADAAN_LANGSUNG_PAGU.NeedEncode = true;

                    PENGADAAN_LANGSUNG_PAGU.ControlType = 0;

        	        PENGADAAN_LANGSUNG_PAGU.GoodName = "PAGU";
        	                	        PENGADAAN_LANGSUNG_PAGU.FullName = "PAGU";
        	        
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_PAGU.Index = 6;
        	        
        	                	                	        PENGADAAN_LANGSUNG_PAGU.EditParams = "";
        	                	                	                		                	        PENGADAAN_LANGSUNG_PAGU.FieldPermissions = true;

        	        
                                        PENGADAAN_LANGSUNG_PAGU.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("PAGU", PENGADAAN_LANGSUNG_PAGU);
                    Field PENGADAAN_LANGSUNG_HPS = new Field();
                    PENGADAAN_LANGSUNG_HPS.Name = "HPS";
        	        
        	        
        	        

                    PENGADAAN_LANGSUNG_HPS.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_HPS.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_HPS.LinkParam = "";

        	        PENGADAAN_LANGSUNG_HPS.FieldType = 6;
        	        PENGADAAN_LANGSUNG_HPS.EditFormat = "Text field";
        	        PENGADAAN_LANGSUNG_HPS.ViewFormat = "Number";
        	        
        	        
        	        
        	                	                	                	        PENGADAAN_LANGSUNG_HPS.NeedEncode = true;

                    PENGADAAN_LANGSUNG_HPS.ControlType = 0;

        	        PENGADAAN_LANGSUNG_HPS.GoodName = "HPS";
        	                	        PENGADAAN_LANGSUNG_HPS.FullName = "HPS";
        	        
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_HPS.Index = 7;
        	        
        	                	                	        PENGADAAN_LANGSUNG_HPS.EditParams = "";
        	                	                	                		                	        PENGADAAN_LANGSUNG_HPS.FieldPermissions = true;

        	        
                                        PENGADAAN_LANGSUNG_HPS.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("HPS", PENGADAAN_LANGSUNG_HPS);
                    Field PENGADAAN_LANGSUNG_NILAIKONTRAK = new Field();
                    PENGADAAN_LANGSUNG_NILAIKONTRAK.Name = "NILAIKONTRAK";
        	        PENGADAAN_LANGSUNG_NILAIKONTRAK.Label = "NILAI KONTRAK";
        	        
        	        

                    PENGADAAN_LANGSUNG_NILAIKONTRAK.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_NILAIKONTRAK.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_NILAIKONTRAK.LinkParam = "";

        	        PENGADAAN_LANGSUNG_NILAIKONTRAK.FieldType = 6;
        	        PENGADAAN_LANGSUNG_NILAIKONTRAK.EditFormat = "Text field";
        	        PENGADAAN_LANGSUNG_NILAIKONTRAK.ViewFormat = "Number";
        	        
        	        
        	        
        	                	                	                	        PENGADAAN_LANGSUNG_NILAIKONTRAK.NeedEncode = true;

                    PENGADAAN_LANGSUNG_NILAIKONTRAK.ControlType = 0;

        	        PENGADAAN_LANGSUNG_NILAIKONTRAK.GoodName = "NILAIKONTRAK";
        	                	        PENGADAAN_LANGSUNG_NILAIKONTRAK.FullName = "NILAIKONTRAK";
        	        
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_NILAIKONTRAK.Index = 8;
        	        
        	                	                	        PENGADAAN_LANGSUNG_NILAIKONTRAK.EditParams = "";
        	                	                	                		                	        PENGADAAN_LANGSUNG_NILAIKONTRAK.FieldPermissions = true;

        	        
                                        PENGADAAN_LANGSUNG_NILAIKONTRAK.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("NILAIKONTRAK", PENGADAAN_LANGSUNG_NILAIKONTRAK);
                    Field PENGADAAN_LANGSUNG_PEMENANG = new Field();
                    PENGADAAN_LANGSUNG_PEMENANG.Name = "PEMENANG";
        	        
        	        
        	        

                    PENGADAAN_LANGSUNG_PEMENANG.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_PEMENANG.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_PEMENANG.LinkParam = "";

        	        PENGADAAN_LANGSUNG_PEMENANG.FieldType = 200;
        	        PENGADAAN_LANGSUNG_PEMENANG.EditFormat = "Lookup wizard";
        	        PENGADAAN_LANGSUNG_PEMENANG.ViewFormat = "";
					
					//adaptation to change edit format from textbox to combo
					PENGADAAN_LANGSUNG_PEMENANG.LookupType = 0;
					//end of adaptation
					
        	                	                	                	        PENGADAAN_LANGSUNG_PEMENANG.NeedEncode = true;

                    PENGADAAN_LANGSUNG_PEMENANG.ControlType = 0;

        	        PENGADAAN_LANGSUNG_PEMENANG.GoodName = "PEMENANG";
        	                	        PENGADAAN_LANGSUNG_PEMENANG.FullName = "PEMENANG";
        	         PENGADAAN_LANGSUNG_PEMENANG.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_PEMENANG.Index = 9;
        	        
        	        //PENGADAAN_LANGSUNG_PEMENANG.EditParams = "";
        	        //PENGADAAN_LANGSUNG_PEMENANG.EditParams = PENGADAAN_LANGSUNG_PEMENANG.EditParams + " maxlength=255";
        	                	                		                	        PENGADAAN_LANGSUNG_PEMENANG.FieldPermissions = true;

					//adaptation to change edit format from textbox to combo
					PENGADAAN_LANGSUNG_PEMENANG.AddNewItem =  false ;
					PENGADAAN_LANGSUNG_PEMENANG.LinkField = "";
					PENGADAAN_LANGSUNG_PEMENANG.DisplayField = "";
					PENGADAAN_LANGSUNG_PEMENANG.LookupTable = "";
					PENGADAAN_LANGSUNG_PEMENANG.StrSize = 1;
					int dPENGADAAN_LANGSUNG_PEMENANG = 0;
					//loop
					SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
					string ssql = "select NAMA from Tb_Vendor order by NAMA";
					SqlCommand myCommand = new SqlCommand();
					myCommand.CommandText = ssql;
					myCommand.CommandType = CommandType.Text;
					myCommand.Connection = myConnection;
					myConnection.Open();
					SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

					while (myReader.Read())
					{
						PENGADAAN_LANGSUNG_PEMENANG.Arr.Add(dPENGADAAN_LANGSUNG_PEMENANG,myReader.GetValue(0).ToString());
						dPENGADAAN_LANGSUNG_PEMENANG = dPENGADAAN_LANGSUNG_PEMENANG + 1;
					}
					myReader.Close();
					//end loop
					//end of adaptation
					
                                        PENGADAAN_LANGSUNG_PEMENANG.Container = tablePENGADAAN_LANGSUNG;

					//adaptation to change edit format from textbox to combo
					ssql = "select NAMA from Tb_Vendor order by NAMA";
					myCommand = new SqlCommand();
					myCommand.CommandText = ssql;
					myCommand.CommandType = CommandType.Text;
					myCommand.Connection = myConnection;
					myConnection.Open();
					myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

					while (myReader.Read())
					{
						PENGADAAN_LANGSUNG_PEMENANG.LookupFields.Add(new LookupField(myReader.GetValue(0).ToString(),myReader.GetValue(0).ToString()));
					}
					myReader.Close();
					//end loop
					//end of adaptation

        	        tablePENGADAAN_LANGSUNG.Fields.Add("PEMENANG", PENGADAAN_LANGSUNG_PEMENANG);
                    Field PENGADAAN_LANGSUNG_KETERANGAN = new Field();
                    PENGADAAN_LANGSUNG_KETERANGAN.Name = "KETERANGAN";
        	        PENGADAAN_LANGSUNG_KETERANGAN.Label = "JENIS KEGIATAN";
        	        
        	        

                    PENGADAAN_LANGSUNG_KETERANGAN.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_KETERANGAN.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_KETERANGAN.LinkParam = "";

        	        PENGADAAN_LANGSUNG_KETERANGAN.FieldType = 200;
        	        PENGADAAN_LANGSUNG_KETERANGAN.EditFormat = "Lookup wizard";
        	        PENGADAAN_LANGSUNG_KETERANGAN.ViewFormat = "";
        	        
        	        
        	        
        	                	        PENGADAAN_LANGSUNG_KETERANGAN.LookupType = 1;
        	                	        PENGADAAN_LANGSUNG_KETERANGAN.LookupWhere = "";
        	        PENGADAAN_LANGSUNG_KETERANGAN.LinkField = "[KODEJENISKEGIATAN]";
        	                	        PENGADAAN_LANGSUNG_KETERANGAN.DisplayField = "[DESKRIPSI]";
        	        PENGADAAN_LANGSUNG_KETERANGAN.LookupTable = "dbo.JENISKEGIATAN";
        	                	                	                	        PENGADAAN_LANGSUNG_KETERANGAN.NeedEncode = true;

                    PENGADAAN_LANGSUNG_KETERANGAN.ControlType = 0;

        	        PENGADAAN_LANGSUNG_KETERANGAN.GoodName = "KETERANGAN";
        	                	        PENGADAAN_LANGSUNG_KETERANGAN.FullName = "KETERANGAN";
        	         PENGADAAN_LANGSUNG_KETERANGAN.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_KETERANGAN.Index = 10;
        	        
        	                	                	                		                	        PENGADAAN_LANGSUNG_KETERANGAN.FieldPermissions = true;

        	        
                                            PENGADAAN_LANGSUNG_KETERANGAN.AddNewItem =  false ;
                                                PENGADAAN_LANGSUNG_KETERANGAN.LinkField = "KODEJENISKEGIATAN";
                        PENGADAAN_LANGSUNG_KETERANGAN.DisplayField = "DESKRIPSI";
                        PENGADAAN_LANGSUNG_KETERANGAN.LookupTable = "dbo.JENISKEGIATAN";
                        PENGADAAN_LANGSUNG_KETERANGAN.StrSize = 1;
                        		                                                
                                                		
		                                        		     PENGADAAN_LANGSUNG_KETERANGAN.OrderBy = "KODEJENISKEGIATAN";
		                                            PENGADAAN_LANGSUNG_KETERANGAN.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("KETERANGAN", PENGADAAN_LANGSUNG_KETERANGAN);
                    Field PENGADAAN_LANGSUNG_PEJABATPENGADAAN = new Field();
                    PENGADAAN_LANGSUNG_PEJABATPENGADAAN.Name = "PEJABATPENGADAAN";
        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.Label = "PEJABAT PENGADAAN";
        	        
        	        

                    PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LinkParam = "";

        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.FieldType = 200;
        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.EditFormat = "Lookup wizard";
        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.ViewFormat = "";
        	        
        	        
        	        
        	                	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LookupType = 1;
        	                	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LookupWhere = "";
        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LinkField = "[KODEJENISPENGADAAN]";
        	                	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.DisplayField = "[DESKRIPSI]";
        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LookupTable = "dbo.JENISPENGADAAN";
        	                	                	                	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.NeedEncode = true;

                    PENGADAAN_LANGSUNG_PEJABATPENGADAAN.ControlType = 0;

        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.GoodName = "PEJABATPENGADAAN";
        	                	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.FullName = "PEJABATPENGADAAN";
        	         PENGADAAN_LANGSUNG_PEJABATPENGADAAN.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.Index = 11;
        	        
        	                	                	                		                	        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.FieldPermissions = true;

        	        
                                            PENGADAAN_LANGSUNG_PEJABATPENGADAAN.AddNewItem =  false ;
                                                PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LinkField = "KODEJENISPENGADAAN";
                        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.DisplayField = "DESKRIPSI";
                        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.LookupTable = "dbo.JENISPENGADAAN";
                        PENGADAAN_LANGSUNG_PEJABATPENGADAAN.StrSize = 1;
                        		                                                
                                                		
		                                        		     PENGADAAN_LANGSUNG_PEJABATPENGADAAN.OrderBy = "KODEJENISPENGADAAN";
		                                            PENGADAAN_LANGSUNG_PEJABATPENGADAAN.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("PEJABATPENGADAAN", PENGADAAN_LANGSUNG_PEJABATPENGADAAN);
                    Field PENGADAAN_LANGSUNG_MENGETAHUI = new Field();
                    PENGADAAN_LANGSUNG_MENGETAHUI.Name = "MENGETAHUI";
        	        
        	        
        	        

                    PENGADAAN_LANGSUNG_MENGETAHUI.LinkNewWindow = 0;
                    PENGADAAN_LANGSUNG_MENGETAHUI.LinkDisplay = 0;
                    PENGADAAN_LANGSUNG_MENGETAHUI.LinkParam = "";

        	        PENGADAAN_LANGSUNG_MENGETAHUI.FieldType = 200;
        	        PENGADAAN_LANGSUNG_MENGETAHUI.EditFormat = "Lookup wizard";
        	        PENGADAAN_LANGSUNG_MENGETAHUI.ViewFormat = "";
        	        
        	        
        	        
        	                	        PENGADAAN_LANGSUNG_MENGETAHUI.LookupType = 1;
        	                	        PENGADAAN_LANGSUNG_MENGETAHUI.LookupWhere = "";
        	        PENGADAAN_LANGSUNG_MENGETAHUI.LinkField = "[NIP]";
        	                	        PENGADAAN_LANGSUNG_MENGETAHUI.DisplayField = "[NAMA]";
        	        PENGADAAN_LANGSUNG_MENGETAHUI.LookupTable = "dbo.AKTOR";
        	                	                	                	        PENGADAAN_LANGSUNG_MENGETAHUI.NeedEncode = true;

                    PENGADAAN_LANGSUNG_MENGETAHUI.ControlType = 0;

        	        PENGADAAN_LANGSUNG_MENGETAHUI.GoodName = "MENGETAHUI";
        	                	        PENGADAAN_LANGSUNG_MENGETAHUI.FullName = "MENGETAHUI";
        	         PENGADAAN_LANGSUNG_MENGETAHUI.IsRequired = true;
        	                	        
        	        
        	        PENGADAAN_LANGSUNG_MENGETAHUI.Index = 12;
        	        
        	                	                	                		                	        PENGADAAN_LANGSUNG_MENGETAHUI.FieldPermissions = true;

        	        
                                            PENGADAAN_LANGSUNG_MENGETAHUI.AddNewItem =  false ;
                                                PENGADAAN_LANGSUNG_MENGETAHUI.LinkField = "NIP";
                        PENGADAAN_LANGSUNG_MENGETAHUI.DisplayField = "NAMA";
                        PENGADAAN_LANGSUNG_MENGETAHUI.LookupTable = "dbo.AKTOR";
                        PENGADAAN_LANGSUNG_MENGETAHUI.StrSize = 1;
                        		                                                
                                                		
		                                        		     PENGADAAN_LANGSUNG_MENGETAHUI.OrderBy = "NAMA";
		                                            PENGADAAN_LANGSUNG_MENGETAHUI.Container = tablePENGADAAN_LANGSUNG;
        	        tablePENGADAAN_LANGSUNG.Fields.Add("MENGETAHUI", PENGADAAN_LANGSUNG_MENGETAHUI);
                builder.Tables.Add("dbo.PENGADAAN_LANGSUNG", tablePENGADAAN_LANGSUNG);
                builder.SubSonicTables.Add("PENGADAAN_LANGSUNG", tablePENGADAAN_LANGSUNG);
                Table tableKELENGKAPANPBJ = new Table();
                tableKELENGKAPANPBJ.ShortName = "KELENGKAPANPBJ";
                tableKELENGKAPANPBJ.TableName = "dbo.KELENGKAPANPBJ";
                            tableKELENGKAPANPBJ.DataSourceTable = "dbo.KELENGKAPANPBJ";
                tableKELENGKAPANPBJ.OwnerID = "";
                    Field KELENGKAPANPBJ_KODEBPJ = new Field();
                    KELENGKAPANPBJ_KODEBPJ.Name = "KODEBPJ";
        	        KELENGKAPANPBJ_KODEBPJ.Label = "KEGIATAN/PAKET";
        	        
        	        

                    KELENGKAPANPBJ_KODEBPJ.LinkNewWindow = 0;
                    KELENGKAPANPBJ_KODEBPJ.LinkDisplay = 0;
                    KELENGKAPANPBJ_KODEBPJ.LinkParam = "";

        	        KELENGKAPANPBJ_KODEBPJ.FieldType = 200;
        	        KELENGKAPANPBJ_KODEBPJ.EditFormat = "Lookup wizard";
        	        KELENGKAPANPBJ_KODEBPJ.ViewFormat = "";
        	        
        	        
        	        
        	                	        KELENGKAPANPBJ_KODEBPJ.LookupType = 1;
        	                	        KELENGKAPANPBJ_KODEBPJ.LookupWhere = "";
        	        KELENGKAPANPBJ_KODEBPJ.LinkField = "[KODEPBJ]";
        	                	        KELENGKAPANPBJ_KODEBPJ.DisplayField = "[NAMAPAKET]";
        	        KELENGKAPANPBJ_KODEBPJ.LookupTable = "dbo.PBJ";
        	                	                	                	        KELENGKAPANPBJ_KODEBPJ.NeedEncode = true;

                    KELENGKAPANPBJ_KODEBPJ.ControlType = 0;

        	        KELENGKAPANPBJ_KODEBPJ.GoodName = "KODEBPJ";
        	                	        KELENGKAPANPBJ_KODEBPJ.FullName = "KODEBPJ";
        	         KELENGKAPANPBJ_KODEBPJ.IsRequired = true;
        	                	        
        	        
        	        KELENGKAPANPBJ_KODEBPJ.Index = 1;
        	        
        	                	                	                		                	        KELENGKAPANPBJ_KODEBPJ.FieldPermissions = true;

        	        
                                            KELENGKAPANPBJ_KODEBPJ.AddNewItem =  false ;
                                                    KELENGKAPANPBJ_KODEBPJ.AdvancedAdd = true;
		                    KELENGKAPANPBJ_KODEBPJ.AddPage = "PBJ_add.aspx";
                        KELENGKAPANPBJ_KODEBPJ.LinkField = "KODEPBJ";
                        KELENGKAPANPBJ_KODEBPJ.DisplayField = "NAMAPAKET";
                        KELENGKAPANPBJ_KODEBPJ.LookupTable = "dbo.PBJ";
                        KELENGKAPANPBJ_KODEBPJ.StrSize = 1;
                        		                                                
                                                		
		                                        		     KELENGKAPANPBJ_KODEBPJ.OrderBy = "KODEPBJ";
		                                            KELENGKAPANPBJ_KODEBPJ.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("KODEBPJ", KELENGKAPANPBJ_KODEBPJ);
                    Field KELENGKAPANPBJ_KODEKELENGKAPAN = new Field();
                    KELENGKAPANPBJ_KODEKELENGKAPAN.Name = "KODEKELENGKAPAN";
        	        KELENGKAPANPBJ_KODEKELENGKAPAN.Label = "KELENGKAPAN";
        	        
        	        

                    KELENGKAPANPBJ_KODEKELENGKAPAN.LinkNewWindow = 0;
                    KELENGKAPANPBJ_KODEKELENGKAPAN.LinkDisplay = 0;
                    KELENGKAPANPBJ_KODEKELENGKAPAN.LinkParam = "";

        	        KELENGKAPANPBJ_KODEKELENGKAPAN.FieldType = 200;
        	        KELENGKAPANPBJ_KODEKELENGKAPAN.EditFormat = "Lookup wizard";
        	        KELENGKAPANPBJ_KODEKELENGKAPAN.ViewFormat = "";
        	        
        	        
        	        
        	                	        KELENGKAPANPBJ_KODEKELENGKAPAN.LookupType = 1;
        	                	        KELENGKAPANPBJ_KODEKELENGKAPAN.LookupWhere = "";
        	        KELENGKAPANPBJ_KODEKELENGKAPAN.LinkField = "[KODEKELENGKAPAN]";
        	                	        KELENGKAPANPBJ_KODEKELENGKAPAN.DisplayField = "[KODEKELENGKAPAN]";
        	        KELENGKAPANPBJ_KODEKELENGKAPAN.LookupTable = "dbo.KELENGKAPAN";
        	                	                	                	        KELENGKAPANPBJ_KODEKELENGKAPAN.NeedEncode = true;

                    KELENGKAPANPBJ_KODEKELENGKAPAN.ControlType = 0;

        	        KELENGKAPANPBJ_KODEKELENGKAPAN.GoodName = "KODEKELENGKAPAN";
        	                	        KELENGKAPANPBJ_KODEKELENGKAPAN.FullName = "KODEKELENGKAPAN";
        	         KELENGKAPANPBJ_KODEKELENGKAPAN.IsRequired = true;
        	                	        
        	        
        	        KELENGKAPANPBJ_KODEKELENGKAPAN.Index = 2;
        	        
        	                	                	                		                	        KELENGKAPANPBJ_KODEKELENGKAPAN.FieldPermissions = true;

        	        
                                            KELENGKAPANPBJ_KODEKELENGKAPAN.AddNewItem =  false ;
                                                    KELENGKAPANPBJ_KODEKELENGKAPAN.AdvancedAdd = true;
		                    KELENGKAPANPBJ_KODEKELENGKAPAN.AddPage = "KELENGKAPAN_add.aspx";
                        KELENGKAPANPBJ_KODEKELENGKAPAN.LinkField = "KODEKELENGKAPAN";
                        KELENGKAPANPBJ_KODEKELENGKAPAN.DisplayField = "KODEKELENGKAPAN";
                        KELENGKAPANPBJ_KODEKELENGKAPAN.LookupTable = "dbo.KELENGKAPAN";
                        KELENGKAPANPBJ_KODEKELENGKAPAN.StrSize = 1;
                        		                                                
                                                		
		                                        		     KELENGKAPANPBJ_KODEKELENGKAPAN.OrderBy = "KODEJENISKEGIATAN";
		                                            KELENGKAPANPBJ_KODEKELENGKAPAN.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("KODEKELENGKAPAN", KELENGKAPANPBJ_KODEKELENGKAPAN);
                    Field KELENGKAPANPBJ_TANGGALDITERIMA = new Field();
                    KELENGKAPANPBJ_TANGGALDITERIMA.Name = "TANGGALDITERIMA";
        	        KELENGKAPANPBJ_TANGGALDITERIMA.Label = "TANGGAL DITERIMA";
        	        
        	        

                    KELENGKAPANPBJ_TANGGALDITERIMA.LinkNewWindow = 0;
                    KELENGKAPANPBJ_TANGGALDITERIMA.LinkDisplay = 0;
                    KELENGKAPANPBJ_TANGGALDITERIMA.LinkParam = "";

        	        KELENGKAPANPBJ_TANGGALDITERIMA.FieldType = 135;
        	        KELENGKAPANPBJ_TANGGALDITERIMA.EditFormat = "Date";
        	        KELENGKAPANPBJ_TANGGALDITERIMA.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        KELENGKAPANPBJ_TANGGALDITERIMA.NeedEncode = true;

                    KELENGKAPANPBJ_TANGGALDITERIMA.ControlType = 0;

        	        KELENGKAPANPBJ_TANGGALDITERIMA.GoodName = "TANGGALDITERIMA";
        	                	        KELENGKAPANPBJ_TANGGALDITERIMA.FullName = "TANGGALDITERIMA";
        	        
        	                	        
        	        
        	        KELENGKAPANPBJ_TANGGALDITERIMA.Index = 3;
        	         KELENGKAPANPBJ_TANGGALDITERIMA.DateEditType = 11;
        	                	                	                		                	        KELENGKAPANPBJ_TANGGALDITERIMA.FieldPermissions = true;

        	        
                                        KELENGKAPANPBJ_TANGGALDITERIMA.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("TANGGALDITERIMA", KELENGKAPANPBJ_TANGGALDITERIMA);
                    Field KELENGKAPANPBJ_PENERIMAKELENGKAPAN = new Field();
                    KELENGKAPANPBJ_PENERIMAKELENGKAPAN.Name = "PENERIMAKELENGKAPAN";
        	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.Label = "PENERIMA KELENGKAPAN";
        	        
        	        

                    KELENGKAPANPBJ_PENERIMAKELENGKAPAN.LinkNewWindow = 0;
                    KELENGKAPANPBJ_PENERIMAKELENGKAPAN.LinkDisplay = 0;
                    KELENGKAPANPBJ_PENERIMAKELENGKAPAN.LinkParam = "";

        	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.FieldType = 200;
        	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.EditFormat = "Text field";
        	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.NeedEncode = true;

                    KELENGKAPANPBJ_PENERIMAKELENGKAPAN.ControlType = 0;

        	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.GoodName = "PENERIMAKELENGKAPAN";
        	                	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.FullName = "PENERIMAKELENGKAPAN";
        	        
        	                	        
        	        
        	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.Index = 4;
        	        
        	                	                	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.EditParams = "";
        	                	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.EditParams = KELENGKAPANPBJ_PENERIMAKELENGKAPAN.EditParams + " maxlength=50";
        	                	                		                	        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.FieldPermissions = true;

        	        
                                        KELENGKAPANPBJ_PENERIMAKELENGKAPAN.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("PENERIMAKELENGKAPAN", KELENGKAPANPBJ_PENERIMAKELENGKAPAN);
                    Field KELENGKAPANPBJ_TANGGALMODIFIKASI = new Field();
                    KELENGKAPANPBJ_TANGGALMODIFIKASI.Name = "TANGGALMODIFIKASI";
        	        
        	        
        	        

                    KELENGKAPANPBJ_TANGGALMODIFIKASI.LinkNewWindow = 0;
                    KELENGKAPANPBJ_TANGGALMODIFIKASI.LinkDisplay = 0;
                    KELENGKAPANPBJ_TANGGALMODIFIKASI.LinkParam = "";

        	        KELENGKAPANPBJ_TANGGALMODIFIKASI.FieldType = 135;
        	        KELENGKAPANPBJ_TANGGALMODIFIKASI.EditFormat = "Date";
        	        KELENGKAPANPBJ_TANGGALMODIFIKASI.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        KELENGKAPANPBJ_TANGGALMODIFIKASI.NeedEncode = true;

                    KELENGKAPANPBJ_TANGGALMODIFIKASI.ControlType = 0;

        	        KELENGKAPANPBJ_TANGGALMODIFIKASI.GoodName = "TANGGALMODIFIKASI";
        	                	        KELENGKAPANPBJ_TANGGALMODIFIKASI.FullName = "TANGGALMODIFIKASI";
        	        
        	                	        
        	        
        	        KELENGKAPANPBJ_TANGGALMODIFIKASI.Index = 5;
        	         KELENGKAPANPBJ_TANGGALMODIFIKASI.DateEditType = 13;
        	                	                	                		        
        	        
                                        KELENGKAPANPBJ_TANGGALMODIFIKASI.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("TANGGALMODIFIKASI", KELENGKAPANPBJ_TANGGALMODIFIKASI);
                    Field KELENGKAPANPBJ_DIBUATOLEH = new Field();
                    KELENGKAPANPBJ_DIBUATOLEH.Name = "DIBUATOLEH";
        	        
        	        
        	        

                    KELENGKAPANPBJ_DIBUATOLEH.LinkNewWindow = 0;
                    KELENGKAPANPBJ_DIBUATOLEH.LinkDisplay = 0;
                    KELENGKAPANPBJ_DIBUATOLEH.LinkParam = "";

        	        KELENGKAPANPBJ_DIBUATOLEH.FieldType = 200;
        	        KELENGKAPANPBJ_DIBUATOLEH.EditFormat = "Text field";
        	        KELENGKAPANPBJ_DIBUATOLEH.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        KELENGKAPANPBJ_DIBUATOLEH.NeedEncode = true;

                    KELENGKAPANPBJ_DIBUATOLEH.ControlType = 0;

        	        KELENGKAPANPBJ_DIBUATOLEH.GoodName = "DIBUATOLEH";
        	                	        KELENGKAPANPBJ_DIBUATOLEH.FullName = "DIBUATOLEH";
        	        
        	                	        
        	        
        	        KELENGKAPANPBJ_DIBUATOLEH.Index = 6;
        	        
        	                	                	        KELENGKAPANPBJ_DIBUATOLEH.EditParams = "";
        	                	        KELENGKAPANPBJ_DIBUATOLEH.EditParams = KELENGKAPANPBJ_DIBUATOLEH.EditParams + " maxlength=50";
        	                	                		        
        	        
                                        KELENGKAPANPBJ_DIBUATOLEH.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("DIBUATOLEH", KELENGKAPANPBJ_DIBUATOLEH);
                    Field KELENGKAPANPBJ_TANGGALDIBUAT = new Field();
                    KELENGKAPANPBJ_TANGGALDIBUAT.Name = "TANGGALDIBUAT";
        	        
        	        
        	        

                    KELENGKAPANPBJ_TANGGALDIBUAT.LinkNewWindow = 0;
                    KELENGKAPANPBJ_TANGGALDIBUAT.LinkDisplay = 0;
                    KELENGKAPANPBJ_TANGGALDIBUAT.LinkParam = "";

        	        KELENGKAPANPBJ_TANGGALDIBUAT.FieldType = 135;
        	        KELENGKAPANPBJ_TANGGALDIBUAT.EditFormat = "Date";
        	        KELENGKAPANPBJ_TANGGALDIBUAT.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        KELENGKAPANPBJ_TANGGALDIBUAT.NeedEncode = true;

                    KELENGKAPANPBJ_TANGGALDIBUAT.ControlType = 0;

        	        KELENGKAPANPBJ_TANGGALDIBUAT.GoodName = "TANGGALDIBUAT";
        	                	        KELENGKAPANPBJ_TANGGALDIBUAT.FullName = "TANGGALDIBUAT";
        	        
        	                	        
        	        
        	        KELENGKAPANPBJ_TANGGALDIBUAT.Index = 7;
        	         KELENGKAPANPBJ_TANGGALDIBUAT.DateEditType = 13;
        	                	                	                		        
        	        
                                        KELENGKAPANPBJ_TANGGALDIBUAT.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("TANGGALDIBUAT", KELENGKAPANPBJ_TANGGALDIBUAT);
                    Field KELENGKAPANPBJ_MODIFIKASIOLEH = new Field();
                    KELENGKAPANPBJ_MODIFIKASIOLEH.Name = "MODIFIKASIOLEH";
        	        
        	        
        	        

                    KELENGKAPANPBJ_MODIFIKASIOLEH.LinkNewWindow = 0;
                    KELENGKAPANPBJ_MODIFIKASIOLEH.LinkDisplay = 0;
                    KELENGKAPANPBJ_MODIFIKASIOLEH.LinkParam = "";

        	        KELENGKAPANPBJ_MODIFIKASIOLEH.FieldType = 200;
        	        KELENGKAPANPBJ_MODIFIKASIOLEH.EditFormat = "Text field";
        	        KELENGKAPANPBJ_MODIFIKASIOLEH.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        KELENGKAPANPBJ_MODIFIKASIOLEH.NeedEncode = true;

                    KELENGKAPANPBJ_MODIFIKASIOLEH.ControlType = 0;

        	        KELENGKAPANPBJ_MODIFIKASIOLEH.GoodName = "MODIFIKASIOLEH";
        	                	        KELENGKAPANPBJ_MODIFIKASIOLEH.FullName = "MODIFIKASIOLEH";
        	        
        	                	        
        	        
        	        KELENGKAPANPBJ_MODIFIKASIOLEH.Index = 8;
        	        
        	                	                	        KELENGKAPANPBJ_MODIFIKASIOLEH.EditParams = "";
        	                	        KELENGKAPANPBJ_MODIFIKASIOLEH.EditParams = KELENGKAPANPBJ_MODIFIKASIOLEH.EditParams + " maxlength=50";
        	                	                		        
        	        
                                        KELENGKAPANPBJ_MODIFIKASIOLEH.Container = tableKELENGKAPANPBJ;
        	        tableKELENGKAPANPBJ.Fields.Add("MODIFIKASIOLEH", KELENGKAPANPBJ_MODIFIKASIOLEH);
                builder.Tables.Add("dbo.KELENGKAPANPBJ", tableKELENGKAPANPBJ);
                builder.SubSonicTables.Add("KELENGKAPANPBJ", tableKELENGKAPANPBJ);
                Table tableKELENGKAPAN = new Table();
                tableKELENGKAPAN.ShortName = "KELENGKAPAN";
                tableKELENGKAPAN.TableName = "dbo.KELENGKAPAN";
                            tableKELENGKAPAN.DataSourceTable = "dbo.KELENGKAPAN";
                tableKELENGKAPAN.OwnerID = "";
                    Field KELENGKAPAN_KODEKELENGKAPAN = new Field();
                    KELENGKAPAN_KODEKELENGKAPAN.Name = "KODEKELENGKAPAN";
        	        KELENGKAPAN_KODEKELENGKAPAN.Label = "KODE KELENGKAPAN";
        	        
        	        

                    KELENGKAPAN_KODEKELENGKAPAN.LinkNewWindow = 0;
                    KELENGKAPAN_KODEKELENGKAPAN.LinkDisplay = 0;
                    KELENGKAPAN_KODEKELENGKAPAN.LinkParam = "";

        	        KELENGKAPAN_KODEKELENGKAPAN.FieldType = 200;
        	        KELENGKAPAN_KODEKELENGKAPAN.EditFormat = "Text field";
        	        KELENGKAPAN_KODEKELENGKAPAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        KELENGKAPAN_KODEKELENGKAPAN.NeedEncode = true;

                    KELENGKAPAN_KODEKELENGKAPAN.ControlType = 0;

        	        KELENGKAPAN_KODEKELENGKAPAN.GoodName = "KODEKELENGKAPAN";
        	                	        KELENGKAPAN_KODEKELENGKAPAN.FullName = "KODEKELENGKAPAN";
        	         KELENGKAPAN_KODEKELENGKAPAN.IsRequired = true;
        	                	        
        	        
        	        KELENGKAPAN_KODEKELENGKAPAN.Index = 1;
        	        
        	                	                	        KELENGKAPAN_KODEKELENGKAPAN.EditParams = "";
        	                	        KELENGKAPAN_KODEKELENGKAPAN.EditParams = KELENGKAPAN_KODEKELENGKAPAN.EditParams + " maxlength=10";
        	                	                		                	        KELENGKAPAN_KODEKELENGKAPAN.FieldPermissions = true;

        	        
                                        KELENGKAPAN_KODEKELENGKAPAN.Container = tableKELENGKAPAN;
        	        tableKELENGKAPAN.Fields.Add("KODEKELENGKAPAN", KELENGKAPAN_KODEKELENGKAPAN);
                    Field KELENGKAPAN_KODEDOKUMEN = new Field();
                    KELENGKAPAN_KODEDOKUMEN.Name = "KODEDOKUMEN";
        	        KELENGKAPAN_KODEDOKUMEN.Label = "DOKUMEN";
        	        
        	        

                    KELENGKAPAN_KODEDOKUMEN.LinkNewWindow = 0;
                    KELENGKAPAN_KODEDOKUMEN.LinkDisplay = 0;
                    KELENGKAPAN_KODEDOKUMEN.LinkParam = "";

        	        KELENGKAPAN_KODEDOKUMEN.FieldType = 200;
        	        KELENGKAPAN_KODEDOKUMEN.EditFormat = "Lookup wizard";
        	        KELENGKAPAN_KODEDOKUMEN.ViewFormat = "";
        	        
        	        
        	        
        	                	        KELENGKAPAN_KODEDOKUMEN.LookupType = 1;
        	                	        KELENGKAPAN_KODEDOKUMEN.LookupWhere = "";
        	        KELENGKAPAN_KODEDOKUMEN.LinkField = "[KODEDOKUMEN]";
        	                	        KELENGKAPAN_KODEDOKUMEN.DisplayField = "[DESKRIPSI]";
        	        KELENGKAPAN_KODEDOKUMEN.LookupTable = "dbo.DOKUMEN";
        	                	                	                	        KELENGKAPAN_KODEDOKUMEN.NeedEncode = true;

                    KELENGKAPAN_KODEDOKUMEN.ControlType = 0;

        	        KELENGKAPAN_KODEDOKUMEN.GoodName = "KODEDOKUMEN";
        	                	        KELENGKAPAN_KODEDOKUMEN.FullName = "KODEDOKUMEN";
        	         KELENGKAPAN_KODEDOKUMEN.IsRequired = true;
        	                	        
        	        
        	        KELENGKAPAN_KODEDOKUMEN.Index = 2;
        	        
        	                	                	                		                	        KELENGKAPAN_KODEDOKUMEN.FieldPermissions = true;

        	        
                                            KELENGKAPAN_KODEDOKUMEN.AddNewItem =  false ;
                                                    KELENGKAPAN_KODEDOKUMEN.AdvancedAdd = true;
		                    KELENGKAPAN_KODEDOKUMEN.AddPage = "DOKUMEN_add.aspx";
                        KELENGKAPAN_KODEDOKUMEN.LinkField = "KODEDOKUMEN";
                        KELENGKAPAN_KODEDOKUMEN.DisplayField = "DESKRIPSI";
                        KELENGKAPAN_KODEDOKUMEN.LookupTable = "dbo.DOKUMEN";
                        KELENGKAPAN_KODEDOKUMEN.StrSize = 1;
                        		                                                
                                                		
		                                        		     KELENGKAPAN_KODEDOKUMEN.OrderBy = "KODEDOKUMEN";
		                                            KELENGKAPAN_KODEDOKUMEN.Container = tableKELENGKAPAN;
        	        tableKELENGKAPAN.Fields.Add("KODEDOKUMEN", KELENGKAPAN_KODEDOKUMEN);
                    Field KELENGKAPAN_KODEJENISKEGIATAN = new Field();
                    KELENGKAPAN_KODEJENISKEGIATAN.Name = "KODEJENISKEGIATAN";
        	        KELENGKAPAN_KODEJENISKEGIATAN.Label = "JENIS KEGIATAN";
        	        
        	        

                    KELENGKAPAN_KODEJENISKEGIATAN.LinkNewWindow = 0;
                    KELENGKAPAN_KODEJENISKEGIATAN.LinkDisplay = 0;
                    KELENGKAPAN_KODEJENISKEGIATAN.LinkParam = "";

        	        KELENGKAPAN_KODEJENISKEGIATAN.FieldType = 200;
        	        KELENGKAPAN_KODEJENISKEGIATAN.EditFormat = "Lookup wizard";
        	        KELENGKAPAN_KODEJENISKEGIATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	        KELENGKAPAN_KODEJENISKEGIATAN.LookupType = 1;
        	                	        KELENGKAPAN_KODEJENISKEGIATAN.LookupWhere = "";
        	        KELENGKAPAN_KODEJENISKEGIATAN.LinkField = "[KODEJENISKEGIATAN]";
        	                	        KELENGKAPAN_KODEJENISKEGIATAN.DisplayField = "[DESKRIPSI]";
        	        KELENGKAPAN_KODEJENISKEGIATAN.LookupTable = "dbo.JENISKEGIATAN";
        	                	                	                	        KELENGKAPAN_KODEJENISKEGIATAN.NeedEncode = true;

                    KELENGKAPAN_KODEJENISKEGIATAN.ControlType = 0;

        	        KELENGKAPAN_KODEJENISKEGIATAN.GoodName = "KODEJENISKEGIATAN";
        	                	        KELENGKAPAN_KODEJENISKEGIATAN.FullName = "KODEJENISKEGIATAN";
        	         KELENGKAPAN_KODEJENISKEGIATAN.IsRequired = true;
        	                	        
        	        
        	        KELENGKAPAN_KODEJENISKEGIATAN.Index = 3;
        	        
        	                	                	                		                	        KELENGKAPAN_KODEJENISKEGIATAN.FieldPermissions = true;

        	        
                                            KELENGKAPAN_KODEJENISKEGIATAN.AddNewItem =  false ;
                                                    KELENGKAPAN_KODEJENISKEGIATAN.AdvancedAdd = true;
		                    KELENGKAPAN_KODEJENISKEGIATAN.AddPage = "JENISKEGIATAN_add.aspx";
                        KELENGKAPAN_KODEJENISKEGIATAN.LinkField = "KODEJENISKEGIATAN";
                        KELENGKAPAN_KODEJENISKEGIATAN.DisplayField = "DESKRIPSI";
                        KELENGKAPAN_KODEJENISKEGIATAN.LookupTable = "dbo.JENISKEGIATAN";
                        KELENGKAPAN_KODEJENISKEGIATAN.StrSize = 1;
                        		                                                
                                                		
		                                        		     KELENGKAPAN_KODEJENISKEGIATAN.OrderBy = "KODEJENISKEGIATAN";
		                                            KELENGKAPAN_KODEJENISKEGIATAN.Container = tableKELENGKAPAN;
        	        tableKELENGKAPAN.Fields.Add("KODEJENISKEGIATAN", KELENGKAPAN_KODEJENISKEGIATAN);
                builder.Tables.Add("dbo.KELENGKAPAN", tableKELENGKAPAN);
                builder.SubSonicTables.Add("KELENGKAPAN", tableKELENGKAPAN);
                Table tableJENISKEGIATAN = new Table();
                tableJENISKEGIATAN.ShortName = "JENISKEGIATAN";
                tableJENISKEGIATAN.TableName = "dbo.JENISKEGIATAN";
                            tableJENISKEGIATAN.DataSourceTable = "dbo.JENISKEGIATAN";
                tableJENISKEGIATAN.OwnerID = "";
                    Field JENISKEGIATAN_KODEJENISKEGIATAN = new Field();
                    JENISKEGIATAN_KODEJENISKEGIATAN.Name = "KODEJENISKEGIATAN";
        	        JENISKEGIATAN_KODEJENISKEGIATAN.Label = "KODE JENIS KEGIATAN";
        	        
        	        

                    JENISKEGIATAN_KODEJENISKEGIATAN.LinkNewWindow = 0;
                    JENISKEGIATAN_KODEJENISKEGIATAN.LinkDisplay = 0;
                    JENISKEGIATAN_KODEJENISKEGIATAN.LinkParam = "";

        	        JENISKEGIATAN_KODEJENISKEGIATAN.FieldType = 200;
        	        JENISKEGIATAN_KODEJENISKEGIATAN.EditFormat = "Text field";
        	        JENISKEGIATAN_KODEJENISKEGIATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        JENISKEGIATAN_KODEJENISKEGIATAN.NeedEncode = true;

                    JENISKEGIATAN_KODEJENISKEGIATAN.ControlType = 0;

        	        JENISKEGIATAN_KODEJENISKEGIATAN.GoodName = "KODEJENISKEGIATAN";
        	                	        JENISKEGIATAN_KODEJENISKEGIATAN.FullName = "KODEJENISKEGIATAN";
        	         JENISKEGIATAN_KODEJENISKEGIATAN.IsRequired = true;
        	                	        
        	        
        	        JENISKEGIATAN_KODEJENISKEGIATAN.Index = 1;
        	        
        	                	                	        JENISKEGIATAN_KODEJENISKEGIATAN.EditParams = "";
        	                	        JENISKEGIATAN_KODEJENISKEGIATAN.EditParams = JENISKEGIATAN_KODEJENISKEGIATAN.EditParams + " maxlength=10";
        	                	                		                	        JENISKEGIATAN_KODEJENISKEGIATAN.FieldPermissions = true;

        	        
                                        JENISKEGIATAN_KODEJENISKEGIATAN.Container = tableJENISKEGIATAN;
        	        tableJENISKEGIATAN.Fields.Add("KODEJENISKEGIATAN", JENISKEGIATAN_KODEJENISKEGIATAN);
                    Field JENISKEGIATAN_DESKRIPSI = new Field();
                    JENISKEGIATAN_DESKRIPSI.Name = "DESKRIPSI";
        	        
        	        
        	        

                    JENISKEGIATAN_DESKRIPSI.LinkNewWindow = 0;
                    JENISKEGIATAN_DESKRIPSI.LinkDisplay = 0;
                    JENISKEGIATAN_DESKRIPSI.LinkParam = "";

        	        JENISKEGIATAN_DESKRIPSI.FieldType = 200;
        	        JENISKEGIATAN_DESKRIPSI.EditFormat = "Text field";
        	        JENISKEGIATAN_DESKRIPSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        JENISKEGIATAN_DESKRIPSI.NeedEncode = true;

                    JENISKEGIATAN_DESKRIPSI.ControlType = 0;

        	        JENISKEGIATAN_DESKRIPSI.GoodName = "DESKRIPSI";
        	                	        JENISKEGIATAN_DESKRIPSI.FullName = "DESKRIPSI";
        	        
        	                	        
        	        
        	        JENISKEGIATAN_DESKRIPSI.Index = 2;
        	        
        	                	                	        JENISKEGIATAN_DESKRIPSI.EditParams = "";
        	                	        JENISKEGIATAN_DESKRIPSI.EditParams = JENISKEGIATAN_DESKRIPSI.EditParams + " maxlength=200";
        	                	                		                	        JENISKEGIATAN_DESKRIPSI.FieldPermissions = true;

        	        
                                        JENISKEGIATAN_DESKRIPSI.Container = tableJENISKEGIATAN;
        	        tableJENISKEGIATAN.Fields.Add("DESKRIPSI", JENISKEGIATAN_DESKRIPSI);
                builder.Tables.Add("dbo.JENISKEGIATAN", tableJENISKEGIATAN);
                builder.SubSonicTables.Add("JENISKEGIATAN", tableJENISKEGIATAN);
                Table tableJABATANAKTOR = new Table();
                tableJABATANAKTOR.ShortName = "JABATANAKTOR";
                tableJABATANAKTOR.TableName = "dbo.JABATANAKTOR";
                            tableJABATANAKTOR.DataSourceTable = "dbo.JABATANAKTOR";
                tableJABATANAKTOR.OwnerID = "";
                    Field JABATANAKTOR_KODEJABATAN = new Field();
                    JABATANAKTOR_KODEJABATAN.Name = "KODEJABATAN";
        	        JABATANAKTOR_KODEJABATAN.Label = "KODE JABATAN";
        	        
        	        

                    JABATANAKTOR_KODEJABATAN.LinkNewWindow = 0;
                    JABATANAKTOR_KODEJABATAN.LinkDisplay = 0;
                    JABATANAKTOR_KODEJABATAN.LinkParam = "";

        	        JABATANAKTOR_KODEJABATAN.FieldType = 200;
        	        JABATANAKTOR_KODEJABATAN.EditFormat = "Text field";
        	        JABATANAKTOR_KODEJABATAN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        JABATANAKTOR_KODEJABATAN.NeedEncode = true;

                    JABATANAKTOR_KODEJABATAN.ControlType = 0;

        	        JABATANAKTOR_KODEJABATAN.GoodName = "KODEJABATAN";
        	                	        JABATANAKTOR_KODEJABATAN.FullName = "KODEJABATAN";
        	         JABATANAKTOR_KODEJABATAN.IsRequired = true;
        	                	        
        	        
        	        JABATANAKTOR_KODEJABATAN.Index = 1;
        	        
        	                	                	        JABATANAKTOR_KODEJABATAN.EditParams = "";
        	                	        JABATANAKTOR_KODEJABATAN.EditParams = JABATANAKTOR_KODEJABATAN.EditParams + " maxlength=50";
        	                	                		                	        JABATANAKTOR_KODEJABATAN.FieldPermissions = true;

        	        
                                        JABATANAKTOR_KODEJABATAN.Container = tableJABATANAKTOR;
        	        tableJABATANAKTOR.Fields.Add("KODEJABATAN", JABATANAKTOR_KODEJABATAN);
                    Field JABATANAKTOR_DESKRIPSI = new Field();
                    JABATANAKTOR_DESKRIPSI.Name = "DESKRIPSI";
        	        
        	        
        	        

                    JABATANAKTOR_DESKRIPSI.LinkNewWindow = 0;
                    JABATANAKTOR_DESKRIPSI.LinkDisplay = 0;
                    JABATANAKTOR_DESKRIPSI.LinkParam = "";

        	        JABATANAKTOR_DESKRIPSI.FieldType = 200;
        	        JABATANAKTOR_DESKRIPSI.EditFormat = "Text field";
        	        JABATANAKTOR_DESKRIPSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        JABATANAKTOR_DESKRIPSI.NeedEncode = true;

                    JABATANAKTOR_DESKRIPSI.ControlType = 0;

        	        JABATANAKTOR_DESKRIPSI.GoodName = "DESKRIPSI";
        	                	        JABATANAKTOR_DESKRIPSI.FullName = "DESKRIPSI";
        	        
        	                	        
        	        
        	        JABATANAKTOR_DESKRIPSI.Index = 2;
        	        
        	                	                	        JABATANAKTOR_DESKRIPSI.EditParams = "";
        	                	        JABATANAKTOR_DESKRIPSI.EditParams = JABATANAKTOR_DESKRIPSI.EditParams + " maxlength=100";
        	                	                		                	        JABATANAKTOR_DESKRIPSI.FieldPermissions = true;

        	        
                                        JABATANAKTOR_DESKRIPSI.Container = tableJABATANAKTOR;
        	        tableJABATANAKTOR.Fields.Add("DESKRIPSI", JABATANAKTOR_DESKRIPSI);
                builder.Tables.Add("dbo.JABATANAKTOR", tableJABATANAKTOR);
                builder.SubSonicTables.Add("JABATANAKTOR", tableJABATANAKTOR);
                Table tableDOKUMEN = new Table();
                tableDOKUMEN.ShortName = "DOKUMEN";
                tableDOKUMEN.TableName = "dbo.DOKUMEN";
                            tableDOKUMEN.DataSourceTable = "dbo.DOKUMEN";
                tableDOKUMEN.OwnerID = "";
                    Field DOKUMEN_KODEDOKUMEN = new Field();
                    DOKUMEN_KODEDOKUMEN.Name = "KODEDOKUMEN";
        	        DOKUMEN_KODEDOKUMEN.Label = "KODE DOKUMEN";
        	        
        	        

                    DOKUMEN_KODEDOKUMEN.LinkNewWindow = 0;
                    DOKUMEN_KODEDOKUMEN.LinkDisplay = 0;
                    DOKUMEN_KODEDOKUMEN.LinkParam = "";

        	        DOKUMEN_KODEDOKUMEN.FieldType = 200;
        	        DOKUMEN_KODEDOKUMEN.EditFormat = "Text field";
        	        DOKUMEN_KODEDOKUMEN.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        DOKUMEN_KODEDOKUMEN.NeedEncode = true;

                    DOKUMEN_KODEDOKUMEN.ControlType = 0;

        	        DOKUMEN_KODEDOKUMEN.GoodName = "KODEDOKUMEN";
        	                	        DOKUMEN_KODEDOKUMEN.FullName = "KODEDOKUMEN";
        	         DOKUMEN_KODEDOKUMEN.IsRequired = true;
        	                	        
        	        
        	        DOKUMEN_KODEDOKUMEN.Index = 1;
        	        
        	                	                	        DOKUMEN_KODEDOKUMEN.EditParams = "";
        	                	        DOKUMEN_KODEDOKUMEN.EditParams = DOKUMEN_KODEDOKUMEN.EditParams + " maxlength=10";
        	                	                		                	        DOKUMEN_KODEDOKUMEN.FieldPermissions = true;

        	        
                                        DOKUMEN_KODEDOKUMEN.Container = tableDOKUMEN;
        	        tableDOKUMEN.Fields.Add("KODEDOKUMEN", DOKUMEN_KODEDOKUMEN);
                    Field DOKUMEN_DESKRIPSI = new Field();
                    DOKUMEN_DESKRIPSI.Name = "DESKRIPSI";
        	        
        	        
        	        

                    DOKUMEN_DESKRIPSI.LinkNewWindow = 0;
                    DOKUMEN_DESKRIPSI.LinkDisplay = 0;
                    DOKUMEN_DESKRIPSI.LinkParam = "";

        	        DOKUMEN_DESKRIPSI.FieldType = 200;
        	        DOKUMEN_DESKRIPSI.EditFormat = "Text field";
        	        DOKUMEN_DESKRIPSI.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        DOKUMEN_DESKRIPSI.NeedEncode = true;

                    DOKUMEN_DESKRIPSI.ControlType = 0;

        	        DOKUMEN_DESKRIPSI.GoodName = "DESKRIPSI";
        	                	        DOKUMEN_DESKRIPSI.FullName = "DESKRIPSI";
        	        
        	                	        
        	        
        	        DOKUMEN_DESKRIPSI.Index = 2;
        	        
        	                	                	        DOKUMEN_DESKRIPSI.EditParams = "";
        	                	        DOKUMEN_DESKRIPSI.EditParams = DOKUMEN_DESKRIPSI.EditParams + " maxlength=200";
        	                	                		                	        DOKUMEN_DESKRIPSI.FieldPermissions = true;

        	        
                                        DOKUMEN_DESKRIPSI.Container = tableDOKUMEN;
        	        tableDOKUMEN.Fields.Add("DESKRIPSI", DOKUMEN_DESKRIPSI);
                builder.Tables.Add("dbo.DOKUMEN", tableDOKUMEN);
                builder.SubSonicTables.Add("DOKUMEN", tableDOKUMEN);
                Table tableASSIGNMENT = new Table();
                tableASSIGNMENT.ShortName = "ASSIGNMENT";
                tableASSIGNMENT.TableName = "dbo.ASSIGNMENT";
                            tableASSIGNMENT.DataSourceTable = "dbo.ASSIGNMENT";
                tableASSIGNMENT.OwnerID = "";
                    Field ASSIGNMENT_NIP = new Field();
                    ASSIGNMENT_NIP.Name = "NIP";
        	        ASSIGNMENT_NIP.Label = "NAMA";
        	        
        	        

                    ASSIGNMENT_NIP.LinkNewWindow = 0;
                    ASSIGNMENT_NIP.LinkDisplay = 0;
                    ASSIGNMENT_NIP.LinkParam = "";

        	        ASSIGNMENT_NIP.FieldType = 200;
        	        ASSIGNMENT_NIP.EditFormat = "Lookup wizard";
        	        ASSIGNMENT_NIP.ViewFormat = "";
        	        
        	        
        	        
        	                	        ASSIGNMENT_NIP.LookupType = 1;
        	                	        ASSIGNMENT_NIP.LookupWhere = "";
        	        ASSIGNMENT_NIP.LinkField = "[NIP]";
        	                	        ASSIGNMENT_NIP.DisplayField = "[NAMA]";
        	        ASSIGNMENT_NIP.LookupTable = "dbo.AKTOR";
        	                	                	                	        ASSIGNMENT_NIP.NeedEncode = true;

                    ASSIGNMENT_NIP.ControlType = 0;

        	        ASSIGNMENT_NIP.GoodName = "NIP";
        	                	        ASSIGNMENT_NIP.FullName = "NIP";
        	         ASSIGNMENT_NIP.IsRequired = true;
        	                	        
        	        
        	        ASSIGNMENT_NIP.Index = 1;
        	        
        	                	                	                		                	        ASSIGNMENT_NIP.FieldPermissions = true;

        	        
                                            ASSIGNMENT_NIP.AddNewItem =  false ;
                                                    ASSIGNMENT_NIP.AdvancedAdd = true;
		                    ASSIGNMENT_NIP.AddPage = "AKTOR_add.aspx";
                        ASSIGNMENT_NIP.LinkField = "NIP";
                        ASSIGNMENT_NIP.DisplayField = "NAMA";
                        ASSIGNMENT_NIP.LookupTable = "dbo.AKTOR";
                        ASSIGNMENT_NIP.StrSize = 1;
                        		                                                
                                                		
		                                        		     ASSIGNMENT_NIP.OrderBy = "NIP";
		                                            ASSIGNMENT_NIP.Container = tableASSIGNMENT;
        	        tableASSIGNMENT.Fields.Add("NIP", ASSIGNMENT_NIP);
                    Field ASSIGNMENT_KODEPBJ = new Field();
                    ASSIGNMENT_KODEPBJ.Name = "KODEPBJ";
        	        ASSIGNMENT_KODEPBJ.Label = "KEGIATAN/PAKET";
        	        
        	        

                    ASSIGNMENT_KODEPBJ.LinkNewWindow = 0;
                    ASSIGNMENT_KODEPBJ.LinkDisplay = 0;
                    ASSIGNMENT_KODEPBJ.LinkParam = "";

        	        ASSIGNMENT_KODEPBJ.FieldType = 200;
        	        ASSIGNMENT_KODEPBJ.EditFormat = "Lookup wizard";
        	        ASSIGNMENT_KODEPBJ.ViewFormat = "";
        	        
        	        
        	        
        	                	        ASSIGNMENT_KODEPBJ.LookupType = 1;
        	                	        ASSIGNMENT_KODEPBJ.LookupWhere = "";
        	        ASSIGNMENT_KODEPBJ.LinkField = "[KODEPBJ]";
        	                	        ASSIGNMENT_KODEPBJ.DisplayField = "[NAMAPAKET]";
        	        ASSIGNMENT_KODEPBJ.LookupTable = "dbo.PBJ";
        	                	                	                	        ASSIGNMENT_KODEPBJ.NeedEncode = true;

                    ASSIGNMENT_KODEPBJ.ControlType = 0;

        	        ASSIGNMENT_KODEPBJ.GoodName = "KODEPBJ";
        	                	        ASSIGNMENT_KODEPBJ.FullName = "KODEPBJ";
        	         ASSIGNMENT_KODEPBJ.IsRequired = true;
        	                	        
        	        
        	        ASSIGNMENT_KODEPBJ.Index = 2;
        	        
        	                	                	                		                	        ASSIGNMENT_KODEPBJ.FieldPermissions = true;

        	        
                                            ASSIGNMENT_KODEPBJ.AddNewItem =  false ;
                                                    ASSIGNMENT_KODEPBJ.AdvancedAdd = true;
		                    ASSIGNMENT_KODEPBJ.AddPage = "PBJ_add.aspx";
                        ASSIGNMENT_KODEPBJ.LinkField = "KODEPBJ";
                        ASSIGNMENT_KODEPBJ.DisplayField = "NAMAPAKET";
                        ASSIGNMENT_KODEPBJ.LookupTable = "dbo.PBJ";
                        ASSIGNMENT_KODEPBJ.StrSize = 1;
                        		                                                
                                                		
		                                        		     ASSIGNMENT_KODEPBJ.OrderBy = "KODEPBJ";
		                                            ASSIGNMENT_KODEPBJ.Container = tableASSIGNMENT;
        	        tableASSIGNMENT.Fields.Add("KODEPBJ", ASSIGNMENT_KODEPBJ);
                    Field ASSIGNMENT_NOSURATTUGAS = new Field();
                    ASSIGNMENT_NOSURATTUGAS.Name = "NOSURATTUGAS";
        	        ASSIGNMENT_NOSURATTUGAS.Label = "NO SURAT TUGAS";
        	        
        	        

                    ASSIGNMENT_NOSURATTUGAS.LinkNewWindow = 0;
                    ASSIGNMENT_NOSURATTUGAS.LinkDisplay = 0;
                    ASSIGNMENT_NOSURATTUGAS.LinkParam = "";

        	        ASSIGNMENT_NOSURATTUGAS.FieldType = 200;
        	        ASSIGNMENT_NOSURATTUGAS.EditFormat = "Text field";
        	        ASSIGNMENT_NOSURATTUGAS.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        ASSIGNMENT_NOSURATTUGAS.NeedEncode = true;

                    ASSIGNMENT_NOSURATTUGAS.ControlType = 0;

        	        ASSIGNMENT_NOSURATTUGAS.GoodName = "NOSURATTUGAS";
        	                	        ASSIGNMENT_NOSURATTUGAS.FullName = "NOSURATTUGAS";
        	         ASSIGNMENT_NOSURATTUGAS.IsRequired = true;
        	                	        
        	        
        	        ASSIGNMENT_NOSURATTUGAS.Index = 3;
        	        
        	                	                	        ASSIGNMENT_NOSURATTUGAS.EditParams = "";
        	                	        ASSIGNMENT_NOSURATTUGAS.EditParams = ASSIGNMENT_NOSURATTUGAS.EditParams + " maxlength=50";
        	                	                		                	        ASSIGNMENT_NOSURATTUGAS.FieldPermissions = true;

        	        
                                        ASSIGNMENT_NOSURATTUGAS.Container = tableASSIGNMENT;
        	        tableASSIGNMENT.Fields.Add("NOSURATTUGAS", ASSIGNMENT_NOSURATTUGAS);
                builder.Tables.Add("dbo.ASSIGNMENT", tableASSIGNMENT);
                builder.SubSonicTables.Add("ASSIGNMENT", tableASSIGNMENT);

                Table tableTb_Vendor = new Table();
                tableTb_Vendor.ShortName = "Tb_Vendor";
                tableTb_Vendor.TableName = "dbo.Tb_Vendor";
                            tableTb_Vendor.DataSourceTable = "dbo.Tb_Vendor";
                tableTb_Vendor.OwnerID = "";
                    Field Tb_Vendor_KD_VENDOR = new Field();
                    Tb_Vendor_KD_VENDOR.Name = "KD_VENDOR";
        	        Tb_Vendor_KD_VENDOR.Label = "KD VENDOR";
        	        
        	        

                    Tb_Vendor_KD_VENDOR.LinkNewWindow = 0;
                    Tb_Vendor_KD_VENDOR.LinkDisplay = 0;
                    Tb_Vendor_KD_VENDOR.LinkParam = "";

        	        Tb_Vendor_KD_VENDOR.FieldType = 3;
        	        Tb_Vendor_KD_VENDOR.EditFormat = "Text field";
        	        Tb_Vendor_KD_VENDOR.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_KD_VENDOR.NeedEncode = true;

                    Tb_Vendor_KD_VENDOR.ControlType = 0;

        	        Tb_Vendor_KD_VENDOR.GoodName = "KD_VENDOR";
        	                	        Tb_Vendor_KD_VENDOR.FullName = "KD_VENDOR";
        	         Tb_Vendor_KD_VENDOR.IsRequired = true;
        	                	        
        	        
        	        Tb_Vendor_KD_VENDOR.Index = 1;
        	        
        	                	                	        Tb_Vendor_KD_VENDOR.EditParams = "";
        	                	                	                		                	        Tb_Vendor_KD_VENDOR.FieldPermissions = true;

        	        
                                        Tb_Vendor_KD_VENDOR.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("KD_VENDOR", Tb_Vendor_KD_VENDOR);
                    Field Tb_Vendor_NAMA = new Field();
                    Tb_Vendor_NAMA.Name = "NAMA";
        	        Tb_Vendor_NAMA.Label = "NAMA VENDOR";
        	        
        	        

                    Tb_Vendor_NAMA.LinkNewWindow = 0;
                    Tb_Vendor_NAMA.LinkDisplay = 0;
                    Tb_Vendor_NAMA.LinkParam = "";

        	        Tb_Vendor_NAMA.FieldType = 200;
        	        Tb_Vendor_NAMA.EditFormat = "Text field";
        	        Tb_Vendor_NAMA.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_NAMA.NeedEncode = true;

                    Tb_Vendor_NAMA.ControlType = 0;

        	        Tb_Vendor_NAMA.GoodName = "NAMA";
        	                	        Tb_Vendor_NAMA.FullName = "NAMA";
        	        
        	                	        
        	        
        	        Tb_Vendor_NAMA.Index = 2;
        	        
        	                	                	        Tb_Vendor_NAMA.EditParams = "";
        	                	        Tb_Vendor_NAMA.EditParams = Tb_Vendor_NAMA.EditParams + " maxlength=255";
        	                	                		                	        Tb_Vendor_NAMA.FieldPermissions = true;

        	        
                                        Tb_Vendor_NAMA.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("NAMA", Tb_Vendor_NAMA);
                    Field Tb_Vendor_ALAMAT = new Field();
                    Tb_Vendor_ALAMAT.Name = "ALAMAT";
        	        
        	        
        	        

                    Tb_Vendor_ALAMAT.LinkNewWindow = 0;
                    Tb_Vendor_ALAMAT.LinkDisplay = 0;
                    Tb_Vendor_ALAMAT.LinkParam = "";

        	        Tb_Vendor_ALAMAT.FieldType = 200;
        	        Tb_Vendor_ALAMAT.EditFormat = "Text field";
        	        Tb_Vendor_ALAMAT.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_ALAMAT.NeedEncode = true;

                    Tb_Vendor_ALAMAT.ControlType = 0;

        	        Tb_Vendor_ALAMAT.GoodName = "ALAMAT";
        	                	        Tb_Vendor_ALAMAT.FullName = "ALAMAT";
        	        
        	                	        
        	        
        	        Tb_Vendor_ALAMAT.Index = 3;
        	        
        	                	                	        Tb_Vendor_ALAMAT.EditParams = "";
        	                	        Tb_Vendor_ALAMAT.EditParams = Tb_Vendor_ALAMAT.EditParams + " maxlength=255";
        	                	                		                	        Tb_Vendor_ALAMAT.FieldPermissions = true;

        	        
                                        Tb_Vendor_ALAMAT.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("ALAMAT", Tb_Vendor_ALAMAT);
                    Field Tb_Vendor_NPWP = new Field();
                    Tb_Vendor_NPWP.Name = "NPWP";
        	        
        	        
        	        

                    Tb_Vendor_NPWP.LinkNewWindow = 0;
                    Tb_Vendor_NPWP.LinkDisplay = 0;
                    Tb_Vendor_NPWP.LinkParam = "";

        	        Tb_Vendor_NPWP.FieldType = 200;
        	        Tb_Vendor_NPWP.EditFormat = "Text field";
        	        Tb_Vendor_NPWP.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_NPWP.NeedEncode = true;

                    Tb_Vendor_NPWP.ControlType = 0;

        	        Tb_Vendor_NPWP.GoodName = "NPWP";
        	                	        Tb_Vendor_NPWP.FullName = "NPWP";
        	        
        	                	        
        	        
        	        Tb_Vendor_NPWP.Index = 4;
        	        
        	                	                	        Tb_Vendor_NPWP.EditParams = "";
        	                	        Tb_Vendor_NPWP.EditParams = Tb_Vendor_NPWP.EditParams + " maxlength=255";
        	                	                		                	        Tb_Vendor_NPWP.FieldPermissions = true;

        	        
                                        Tb_Vendor_NPWP.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("NPWP", Tb_Vendor_NPWP);
                    Field Tb_Vendor_TELEPON = new Field();
                    Tb_Vendor_TELEPON.Name = "TELEPON";
        	        
        	        
        	        

                    Tb_Vendor_TELEPON.LinkNewWindow = 0;
                    Tb_Vendor_TELEPON.LinkDisplay = 0;
                    Tb_Vendor_TELEPON.LinkParam = "";

        	        Tb_Vendor_TELEPON.FieldType = 200;
        	        Tb_Vendor_TELEPON.EditFormat = "Text field";
        	        Tb_Vendor_TELEPON.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_TELEPON.NeedEncode = true;

                    Tb_Vendor_TELEPON.ControlType = 0;

        	        Tb_Vendor_TELEPON.GoodName = "TELEPON";
        	                	        Tb_Vendor_TELEPON.FullName = "TELEPON";
        	        
        	                	        
        	        
        	        Tb_Vendor_TELEPON.Index = 5;
        	        
        	                	                	        Tb_Vendor_TELEPON.EditParams = "";
        	                	        Tb_Vendor_TELEPON.EditParams = Tb_Vendor_TELEPON.EditParams + " maxlength=50";
        	                	                		                	        Tb_Vendor_TELEPON.FieldPermissions = true;

        	        
                                        Tb_Vendor_TELEPON.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("TELEPON", Tb_Vendor_TELEPON);
                    Field Tb_Vendor_FAX = new Field();
                    Tb_Vendor_FAX.Name = "FAX";
        	        
        	        
        	        

                    Tb_Vendor_FAX.LinkNewWindow = 0;
                    Tb_Vendor_FAX.LinkDisplay = 0;
                    Tb_Vendor_FAX.LinkParam = "";

        	        Tb_Vendor_FAX.FieldType = 200;
        	        Tb_Vendor_FAX.EditFormat = "Text field";
        	        Tb_Vendor_FAX.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_FAX.NeedEncode = true;

                    Tb_Vendor_FAX.ControlType = 0;

        	        Tb_Vendor_FAX.GoodName = "FAX";
        	                	        Tb_Vendor_FAX.FullName = "FAX";
        	        
        	                	        
        	        
        	        Tb_Vendor_FAX.Index = 6;
        	        
        	                	                	        Tb_Vendor_FAX.EditParams = "";
        	                	        Tb_Vendor_FAX.EditParams = Tb_Vendor_FAX.EditParams + " maxlength=50";
        	                	                		                	        Tb_Vendor_FAX.FieldPermissions = true;

        	        
                                        Tb_Vendor_FAX.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("FAX", Tb_Vendor_FAX);
                    Field Tb_Vendor_EMAIL = new Field();
                    Tb_Vendor_EMAIL.Name = "EMAIL";
        	        
        	        
        	        

                    Tb_Vendor_EMAIL.LinkNewWindow = 0;
                    Tb_Vendor_EMAIL.LinkDisplay = 0;
                    Tb_Vendor_EMAIL.LinkParam = "";

        	        Tb_Vendor_EMAIL.FieldType = 200;
        	        Tb_Vendor_EMAIL.EditFormat = "Text field";
        	        Tb_Vendor_EMAIL.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_EMAIL.NeedEncode = true;

                    Tb_Vendor_EMAIL.ControlType = 0;

        	        Tb_Vendor_EMAIL.GoodName = "EMAIL";
        	                	        Tb_Vendor_EMAIL.FullName = "EMAIL";
        	        
        	                	        
        	        
        	        Tb_Vendor_EMAIL.Index = 7;
        	        
        	                	                	        Tb_Vendor_EMAIL.EditParams = "";
        	                	        Tb_Vendor_EMAIL.EditParams = Tb_Vendor_EMAIL.EditParams + " maxlength=50";
        	                	                		                	        Tb_Vendor_EMAIL.FieldPermissions = true;

        	        
                                        Tb_Vendor_EMAIL.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("EMAIL", Tb_Vendor_EMAIL);
                    Field Tb_Vendor_STATUS = new Field();
                    Tb_Vendor_STATUS.Name = "STATUS";
        	        
        	        
        	        

                    Tb_Vendor_STATUS.LinkNewWindow = 0;
                    Tb_Vendor_STATUS.LinkDisplay = 0;
                    Tb_Vendor_STATUS.LinkParam = "";

        	        Tb_Vendor_STATUS.FieldType = 11;
        	        Tb_Vendor_STATUS.EditFormat = "Checkbox";
        	        Tb_Vendor_STATUS.ViewFormat = "Checkbox";
        	        
        	        
        	        
        	                	                	        
                    Tb_Vendor_STATUS.ControlType = 0;

        	        Tb_Vendor_STATUS.GoodName = "STATUS";
        	                	        Tb_Vendor_STATUS.FullName = "STATUS";
        	        
        	                	        
        	        
        	        Tb_Vendor_STATUS.Index = 8;
        	        
        	                	                	                		                	        Tb_Vendor_STATUS.FieldPermissions = true;

        	        
                                        Tb_Vendor_STATUS.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("STATUS", Tb_Vendor_STATUS);
                    Field Tb_Vendor_TANGGAL_DIBUAT = new Field();
                    Tb_Vendor_TANGGAL_DIBUAT.Name = "TANGGAL_DIBUAT";
        	        Tb_Vendor_TANGGAL_DIBUAT.Label = "TANGGAL DIBUAT";
        	        
        	        

                    Tb_Vendor_TANGGAL_DIBUAT.LinkNewWindow = 0;
                    Tb_Vendor_TANGGAL_DIBUAT.LinkDisplay = 0;
                    Tb_Vendor_TANGGAL_DIBUAT.LinkParam = "";

        	        Tb_Vendor_TANGGAL_DIBUAT.FieldType = 135;
        	        Tb_Vendor_TANGGAL_DIBUAT.EditFormat = "Date";
        	        Tb_Vendor_TANGGAL_DIBUAT.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_TANGGAL_DIBUAT.NeedEncode = true;

                    Tb_Vendor_TANGGAL_DIBUAT.ControlType = 0;

        	        Tb_Vendor_TANGGAL_DIBUAT.GoodName = "TANGGAL_DIBUAT";
        	                	        Tb_Vendor_TANGGAL_DIBUAT.FullName = "TANGGAL_DIBUAT";
        	        
        	                	        
        	        
        	        Tb_Vendor_TANGGAL_DIBUAT.Index = 9;
        	         Tb_Vendor_TANGGAL_DIBUAT.DateEditType = 13;
        	                	                	                		        
        	        
                                        Tb_Vendor_TANGGAL_DIBUAT.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("TANGGAL_DIBUAT", Tb_Vendor_TANGGAL_DIBUAT);
                    Field Tb_Vendor_DIBUAT_OLEH = new Field();
                    Tb_Vendor_DIBUAT_OLEH.Name = "DIBUAT_OLEH";
        	        Tb_Vendor_DIBUAT_OLEH.Label = "DIBUAT OLEH";
        	        
        	        

                    Tb_Vendor_DIBUAT_OLEH.LinkNewWindow = 0;
                    Tb_Vendor_DIBUAT_OLEH.LinkDisplay = 0;
                    Tb_Vendor_DIBUAT_OLEH.LinkParam = "";

        	        Tb_Vendor_DIBUAT_OLEH.FieldType = 200;
        	        Tb_Vendor_DIBUAT_OLEH.EditFormat = "Text field";
        	        Tb_Vendor_DIBUAT_OLEH.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_DIBUAT_OLEH.NeedEncode = true;

                    Tb_Vendor_DIBUAT_OLEH.ControlType = 0;

        	        Tb_Vendor_DIBUAT_OLEH.GoodName = "DIBUAT_OLEH";
        	                	        Tb_Vendor_DIBUAT_OLEH.FullName = "DIBUAT_OLEH";
        	        
        	                	        
        	        
        	        Tb_Vendor_DIBUAT_OLEH.Index = 10;
        	        
        	                	                	        Tb_Vendor_DIBUAT_OLEH.EditParams = "";
        	                	        Tb_Vendor_DIBUAT_OLEH.EditParams = Tb_Vendor_DIBUAT_OLEH.EditParams + " maxlength=50";
        	                	                		        
        	        
                                        Tb_Vendor_DIBUAT_OLEH.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("DIBUAT_OLEH", Tb_Vendor_DIBUAT_OLEH);
                    Field Tb_Vendor_TANGGAL_MODIFIKASI = new Field();
                    Tb_Vendor_TANGGAL_MODIFIKASI.Name = "TANGGAL_MODIFIKASI";
        	        Tb_Vendor_TANGGAL_MODIFIKASI.Label = "TANGGAL MODIFIKASI";
        	        
        	        

                    Tb_Vendor_TANGGAL_MODIFIKASI.LinkNewWindow = 0;
                    Tb_Vendor_TANGGAL_MODIFIKASI.LinkDisplay = 0;
                    Tb_Vendor_TANGGAL_MODIFIKASI.LinkParam = "";

        	        Tb_Vendor_TANGGAL_MODIFIKASI.FieldType = 135;
        	        Tb_Vendor_TANGGAL_MODIFIKASI.EditFormat = "Date";
        	        Tb_Vendor_TANGGAL_MODIFIKASI.ViewFormat = "Short Date";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_TANGGAL_MODIFIKASI.NeedEncode = true;

                    Tb_Vendor_TANGGAL_MODIFIKASI.ControlType = 0;

        	        Tb_Vendor_TANGGAL_MODIFIKASI.GoodName = "TANGGAL_MODIFIKASI";
        	                	        Tb_Vendor_TANGGAL_MODIFIKASI.FullName = "TANGGAL_MODIFIKASI";
        	        
        	                	        
        	        
        	        Tb_Vendor_TANGGAL_MODIFIKASI.Index = 11;
        	         Tb_Vendor_TANGGAL_MODIFIKASI.DateEditType = 13;
        	                	                	                		        
        	        
                                        Tb_Vendor_TANGGAL_MODIFIKASI.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("TANGGAL_MODIFIKASI", Tb_Vendor_TANGGAL_MODIFIKASI);
                    Field Tb_Vendor_MODIFIKASI_OLEH = new Field();
                    Tb_Vendor_MODIFIKASI_OLEH.Name = "MODIFIKASI_OLEH";
        	        Tb_Vendor_MODIFIKASI_OLEH.Label = "MODIFIKASI OLEH";
        	        
        	        

                    Tb_Vendor_MODIFIKASI_OLEH.LinkNewWindow = 0;
                    Tb_Vendor_MODIFIKASI_OLEH.LinkDisplay = 0;
                    Tb_Vendor_MODIFIKASI_OLEH.LinkParam = "";

        	        Tb_Vendor_MODIFIKASI_OLEH.FieldType = 200;
        	        Tb_Vendor_MODIFIKASI_OLEH.EditFormat = "Text field";
        	        Tb_Vendor_MODIFIKASI_OLEH.ViewFormat = "";
        	        
        	        
        	        
        	                	                	                	        Tb_Vendor_MODIFIKASI_OLEH.NeedEncode = true;

                    Tb_Vendor_MODIFIKASI_OLEH.ControlType = 0;

        	        Tb_Vendor_MODIFIKASI_OLEH.GoodName = "MODIFIKASI_OLEH";
        	                	        Tb_Vendor_MODIFIKASI_OLEH.FullName = "MODIFIKASI_OLEH";
        	        
        	                	        
        	        
        	        Tb_Vendor_MODIFIKASI_OLEH.Index = 12;
        	        
        	                	                	        Tb_Vendor_MODIFIKASI_OLEH.EditParams = "";
        	                	        Tb_Vendor_MODIFIKASI_OLEH.EditParams = Tb_Vendor_MODIFIKASI_OLEH.EditParams + " maxlength=50";
        	                	                		        
        	        
                                        Tb_Vendor_MODIFIKASI_OLEH.Container = tableTb_Vendor;
        	        tableTb_Vendor.Fields.Add("MODIFIKASI_OLEH", Tb_Vendor_MODIFIKASI_OLEH);
                builder.Tables.Add("dbo.Tb_Vendor", tableTb_Vendor);
                builder.SubSonicTables.Add("Tb_Vendor", tableTb_Vendor);
				
			builder.LONG_BINARY =     "LONG BINARY DATA - CANNOT BE DISPLAYED";
            builder.NO =              "No";
            builder.YES =             "Yes";
            builder.CLOSE_WINDOW =    "Close window";
            builder.MORE =            "More";
            builder.PICKUP_DATE =     "Click Here to Pick up the date";
            builder.ADD_NEW =         "Add new";
            builder.PLEASE_SELECT =   "Please select";
            builder.FILENAME =        "Filename";
            builder.KEEP =            "Keep";
            builder.DELETE =          "Delete";
            builder.UPDATE =          "Update";
            builder.ERR_HAPPENED =    "error happened";
            builder.TECH_INFO =       "Technical information";
            builder.ERR_DESC =        "Error description";
            builder.URL =             "URL";
            builder.SQL_QUERY =       "SQL query";
            builder.RteType     =     "BASIC";
            return builder;
        }
    }
}
