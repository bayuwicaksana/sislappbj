#region " using "
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.IO;
using Smarty;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
#endregion

public partial class CPBJ_Add : AspNetRunnerPage 
{
    string filename = string.Empty;
    string status = string.Empty;
    string msg = string.Empty;
    string linkdata = string.Empty;
    string formname = string.Empty;
    string onsubmit = string.Empty;
    string bodyonload = string.Empty;
    bool error_happened=false;
    IList<string> showKeys = new List<string>();
    IList<string> showKeyValues = new List<string>();
    IList<string> showValues = new List<string>();
    IList<string> showRawValues = new List<string>();
    IList<string> showFields = new List<string>();
    IDictionary<string, string> showDetailKeys = new Dictionary<string, string>();
    IDictionary<string, object> rdonlyfields = new Dictionary<string, object>();
    IDictionary<string, object> body = new Dictionary<string, object>();
    IDictionary<string, object> defvalues = new Dictionary<string, object>();
    IList<string> arr_includes = new List<string>();
    ADD_MODE inlineedit;
    string templatefile;
    bool needvalidate;
    object record_id;
    bool isCopy = false;
    
    Data.PBJController controller = new Data.PBJController();
    Data.PBJ item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PBJ";
        strTableNameLocale = "dbo_PBJ";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
                CheckSecurity();
        Init();
        if(RequestAction == "added")
        {
            try
            {
                SaveData();
            }
            catch(Exception saveEx)
            {
                msg = saveEx.Message;
                error_happened = true;
                ShowFailMessage();
            }
        }
        CopyRecord();
        BuildBody();
        Message();
        ReadonlyFields();
        Wizards();
        BuildBodyEnd();
        BuildForm();
        Message();

        if(RequestAction == "added")
        {
            if(inlineedit != ADD_MODE.ADD_INLINE && inlineedit != ADD_MODE.ADD_ONTHEFLY)
            {
                output.Append(func.BuildOutput(this, @"~\" + templatefile, smarty));
            }
        }
        else
        {
            output.Append(func.BuildOutput(this, @"~\" + templatefile, smarty));
        }
        this.Response.Write(output.ToString());
        this.Response.End();
    }

    private void ShowSuccessMessage()
    {
        if ( inlineedit == ADD_MODE.ADD_INLINE ) 
		{
			status ="ADDED";
			msg = "Record was added";
		} 
		else
        {
			msg = "<div class=message><<< " + "Record was added" + " >>></div>";
        }
    }

    private void ShowFailMessage()
    {
        if ( inlineedit == ADD_MODE.ADD_INLINE ) 
		{
			msg = "Record was NOT added" + ": " + msg;
		} 
		else
        {
			msg = "<div class=message><<< " + "Record was NOT added" + ": " + msg + " >>></div>";
        }
    }

    private void SaveData()
    {
        item = new Data.PBJ();
		
        //	processing KODEPBJ - start
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select count(*), year(getdate()) from pbj where year(tanggalpengajuan)=year(getdate());";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

        int iPbjCtr = 0;
		int iYear = 0;
		while (myReader.Read())
        {
            iPbjCtr = Convert.ToInt32(myReader.GetValue(0).ToString()) + 1;
            iYear = Convert.ToInt32(myReader.GetValue(1).ToString());
        }
        myReader.Close();
		
        if(!string.IsNullOrEmpty(Request["value_KODEPBJ"]))
        {
                                                                                                item.KODEPBJ = Convert.ToString(Request["value_KODEPBJ"]);
        } else {
			item.KODEPBJ = Convert.ToString(Request["value_KODESKPD"]).Replace(".", "") + "." + Convert.ToString(iYear) + Convert.ToString(iPbjCtr);
		}
		
                //	processing NAMAKEGIATAN - start
                        if(!string.IsNullOrEmpty(Request["value_NAMAKEGIATAN"]))
        {
                                                                                                item.NAMAKEGIATAN = Convert.ToString(Request["value_NAMAKEGIATAN"]);
                    }
                //	processing NAMAPAKET - start
                        if(!string.IsNullOrEmpty(Request["value_NAMAPAKET"]))
        {
                                                                                                item.NAMAPAKET = Convert.ToString(Request["value_NAMAPAKET"]);
                    }
                //	processing KODESKPD - start
                        if(!string.IsNullOrEmpty(Request["value_KODESKPD"]))
        {
                                                                                                item.KODESKPD = Convert.ToString(Request["value_KODESKPD"]);
                    }
                //	processing PPK - start
                        if(!string.IsNullOrEmpty(Request["value_PPK"]))
        {
                                                                                                item.PPK = Convert.ToString(Request["value_PPK"]);
                    }
                //	processing PPTK - start
                        if(!string.IsNullOrEmpty(Request["value_PPTK"]))
        {
                                                                                                item.PPTK = Convert.ToString(Request["value_PPTK"]);
                    }
                //	processing KODEJENISKEGIATAN - start
                        if(!string.IsNullOrEmpty(Request["value_KODEJENISKEGIATAN"]))
        {
                                                                                                item.KODEJENISKEGIATAN = Convert.ToString(Request["value_KODEJENISKEGIATAN"]);
                    }
                //	processing PROSESPENGADAAN - start
                        if(!string.IsNullOrEmpty(Request["value_PROSESPENGADAAN"]))
        {
                                                                                                item.PROSESPENGADAAN = Convert.ToString(Request["value_PROSESPENGADAAN"]);
                    }
                //	processing TANGGALPENGAJUAN - start
                        if(!string.IsNullOrEmpty(Request["value_TANGGALPENGAJUAN"]))
        {
                                                                                                item.TANGGALPENGAJUAN = Convert.ToDateTime(Request["value_TANGGALPENGAJUAN"]);
                    }
                //	processing PEMBAWABERKAS1 - start
                        if(!string.IsNullOrEmpty(Request["value_PEMBAWABERKAS1"]))
        {
                                                                                                item.PEMBAWABERKAS1 = Convert.ToString(Request["value_PEMBAWABERKAS1"]);
                    }
                //	processing PENERIMABERKAS1 - start
                        if(!string.IsNullOrEmpty(Request["value_PENERIMABERKAS1"]))
        {
                                                                                                item.PENERIMABERKAS1 = Convert.ToString(Request["value_PENERIMABERKAS1"]);
                    }
                //	processing PEMBAWABERKAS2 - start
                        if(!string.IsNullOrEmpty(Request["value_PEMBAWABERKAS2"]))
        {
                                                                                                item.PEMBAWABERKAS2 = Convert.ToString(Request["value_PEMBAWABERKAS2"]);
                    }
                //	processing PENERIMABERKAS2 - start
                        if(!string.IsNullOrEmpty(Request["value_PENERIMABERKAS2"]))
        {
                                                                                                item.PENERIMABERKAS2 = Convert.ToString(Request["value_PENERIMABERKAS2"]);
                    }
                //	processing LENGKAP - start
                        if(!string.IsNullOrEmpty(Request["value_LENGKAP"]))
        {
                                                                                                item.LENGKAP = Convert.ToString(Request["value_LENGKAP"]);
                    }
                //	processing DIKEMBALIKAN - start
                        if(!string.IsNullOrEmpty(Request["value_DIKEMBALIKAN"]))
        {
                                                                                                item.DIKEMBALIKAN = Convert.ToString(Request["value_DIKEMBALIKAN"]);
                    }
                //	processing TANGGALKEMBALI - start
                        if(!string.IsNullOrEmpty(Request["value_TANGGALKEMBALI"]))
        {
                                                                                                item.TANGGALKEMBALI = Convert.ToDateTime(Request["value_TANGGALKEMBALI"]);
                    }
                //	processing KODESTATUSPBJ - start
                        if(!string.IsNullOrEmpty(Request["value_KODESTATUSPBJ"]))
        {
                                                                                                //item.KODESTATUSPBJ = Convert.ToString(Request["value_KODESTATUSPBJ"]);
                    } else {
												item.KODESTATUSPBJ = "DITERIMA";
	}
                //	processing CATATAN - start
                        if(!string.IsNullOrEmpty(Request["value_CATATAN"]))
        {
                                                                                                item.CATATAN = Convert.ToString(Request["value_CATATAN"]);
                    }
                //	processing PAGU
				string sPAGU = "";
                        if(!string.IsNullOrEmpty(Request["value_PAGU"]))
        {
                                                                                                sPAGU = Convert.ToString(Request["value_PAGU"]);
                    }
                //	processing HPS
				string sHPS = "";
                        if(!string.IsNullOrEmpty(Request["value_HPS"]))
        {
                                                                                                sHPS = Convert.ToString(Request["value_HPS"]);
                    }
                bool abortSaving = false;
        
        
        if(!abortSaving)
        {
            item.Save();

			// save pagu and hps
			if (!string.IsNullOrEmpty(sPAGU) && !string.IsNullOrEmpty(sHPS)) {
				ssql = "update PBJ set PAGU = " + sPAGU + ", HPS = " + sHPS + " where KODEPBJ = '" + item.KODEPBJ + "';";
			}
			if (!string.IsNullOrEmpty(sPAGU) && string.IsNullOrEmpty(sHPS)) {
				ssql = "update PBJ set PAGU = " + sPAGU + " where KODEPBJ = '" + item.KODEPBJ + "';";
			}
			if (string.IsNullOrEmpty(sPAGU) && !string.IsNullOrEmpty(sHPS)) {
				ssql = "update PBJ set HPS = " + sHPS + " where KODEPBJ = '" + item.KODEPBJ + "';";
			}
			if (string.IsNullOrEmpty(sPAGU) && string.IsNullOrEmpty(sHPS)) {
				ssql = "";
			}
			if (!string.IsNullOrEmpty(ssql)) {
				myCommand = new SqlCommand();
				myCommand.CommandText = ssql;
				myCommand.CommandType = CommandType.Text;
				myCommand.Connection = myConnection;
				myConnection.Open();
					
				int recAffected = 0;
				recAffected = myCommand.ExecuteNonQuery();
				
				myCommand.Dispose();
				myConnection.Close();
				myConnection.Dispose();
			}
			// end of save pagu and hps

			ShowSuccessMessage();
        }
    }

    private void BuildForm()
    {
        /////////////////////////////////////////////////////////////
        //	prepare Edit Controls
        /////////////////////////////////////////////////////////////
        if(RequestAction == "added")
        {
            string masterquery="";
	        masterquery="mastertable=dbo%2EPBJ";
	        masterquery += "&masterkey1=" + this.Server.UrlEncode(item.KODEPBJ.ToString());
	        showDetailKeys["dbo.KELENGKAPANPBJ"] = masterquery;
	        masterquery="mastertable=dbo%2EPBJ";
	        masterquery += "&masterkey1=" + this.Server.UrlEncode(item.KODEPBJ.ToString());
	        showDetailKeys["dbo.ASSIGNMENT"] = masterquery;
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEPBJ.ToString()));

	        string keylink="";
	        keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEPBJ.ToString()));

            string value="";

            value="";
            Control control_KODEPBJ = new Control("KODEPBJ", item.KODEPBJ, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODEPBJ - 
		        
		                                value = control_KODEPBJ.GetData();
			            value = control_KODEPBJ.ProcessLargeText(value,"field=KODEPBJ" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("KODEPBJ");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", item.NAMAKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	NAMAKEGIATAN - 
		        
		                                value = control_NAMAKEGIATAN.GetData();
			            value = control_NAMAKEGIATAN.ProcessLargeText(value,"field=NAMAKEGIATAN" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("NAMAKEGIATAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_NAMAPAKET = new Control("NAMAPAKET", item.NAMAPAKET, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	NAMAPAKET - 
		        
		                                value = control_NAMAPAKET.GetData();
			            value = control_NAMAPAKET.ProcessLargeText(value,"field=NAMAPAKET" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("NAMAPAKET");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_KODESKPD = new Control("KODESKPD", item.KODESKPD, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODESKPD - 
		        
		                                func.PopulateLookupFields(control_KODESKPD.FieldInfo);
			            value=control_KODESKPD.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("KODESKPD");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PPK = new Control("PPK", item.PPK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PPK - 
		        
		                                func.PopulateLookupFields(control_PPK.FieldInfo);
			            value=control_PPK.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("PPK");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PPTK = new Control("PPTK", item.PPTK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PPTK - 
		        
		                                func.PopulateLookupFields(control_PPTK.FieldInfo);
			            value=control_PPTK.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("PPTK");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", item.KODEJENISKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODEJENISKEGIATAN - 
		        
		                                func.PopulateLookupFields(control_KODEJENISKEGIATAN.FieldInfo);
			            value=control_KODEJENISKEGIATAN.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("KODEJENISKEGIATAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PROSESPENGADAAN = new Control("PROSESPENGADAAN", item.PROSESPENGADAAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PROSESPENGADAAN - 
		        
		                                value = control_PROSESPENGADAAN.GetData();
			            value = control_PROSESPENGADAAN.ProcessLargeText(value,"field=PROSESPENGADAAN" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("PROSESPENGADAAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_TANGGALPENGAJUAN = new Control("TANGGALPENGAJUAN", item.TANGGALPENGAJUAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	TANGGALPENGAJUAN - Short Date
		        
		                                value = control_TANGGALPENGAJUAN.GetData();
			            value = control_TANGGALPENGAJUAN.ProcessLargeText(value,"field=TANGGALPENGAJUAN" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("TANGGALPENGAJUAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PEMBAWABERKAS1 = new Control("PEMBAWABERKAS1", item.PEMBAWABERKAS1, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PEMBAWABERKAS1 - 
		        
		                                value = control_PEMBAWABERKAS1.GetData();
			            value = control_PEMBAWABERKAS1.ProcessLargeText(value,"field=PEMBAWABERKAS1" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("PEMBAWABERKAS1");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PENERIMABERKAS1 = new Control("PENERIMABERKAS1", item.PENERIMABERKAS1, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PENERIMABERKAS1 - 
		        
		                                value = control_PENERIMABERKAS1.GetData();
			            value = control_PENERIMABERKAS1.ProcessLargeText(value,"field=PENERIMABERKAS1" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("PENERIMABERKAS1");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PEMBAWABERKAS2 = new Control("PEMBAWABERKAS2", item.PEMBAWABERKAS2, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PEMBAWABERKAS2 - 
		        
		                                value = control_PEMBAWABERKAS2.GetData();
			            value = control_PEMBAWABERKAS2.ProcessLargeText(value,"field=PEMBAWABERKAS2" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("PEMBAWABERKAS2");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PENERIMABERKAS2 = new Control("PENERIMABERKAS2", item.PENERIMABERKAS2, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PENERIMABERKAS2 - 
		        
		                                value = control_PENERIMABERKAS2.GetData();
			            value = control_PENERIMABERKAS2.ProcessLargeText(value,"field=PENERIMABERKAS2" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("PENERIMABERKAS2");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_LENGKAP = new Control("LENGKAP", item.LENGKAP, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	LENGKAP - 
		        
		                                value = control_LENGKAP.GetData();
			            value = control_LENGKAP.ProcessLargeText(value,"field=LENGKAP" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("LENGKAP");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_DIKEMBALIKAN = new Control("DIKEMBALIKAN", item.DIKEMBALIKAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	DIKEMBALIKAN - 
		        
		                                value = control_DIKEMBALIKAN.GetData();
			            value = control_DIKEMBALIKAN.ProcessLargeText(value,"field=DIKEMBALIKAN" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("DIKEMBALIKAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_TANGGALKEMBALI = new Control("TANGGALKEMBALI", item.TANGGALKEMBALI, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	TANGGALKEMBALI - Short Date
		        
		                                value = control_TANGGALKEMBALI.GetData();
			            value = control_TANGGALKEMBALI.ProcessLargeText(value,"field=TANGGALKEMBALI" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("TANGGALKEMBALI");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_KODESTATUSPBJ = new Control("KODESTATUSPBJ", item.KODESTATUSPBJ, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODESTATUSPBJ - 
		        
		                                func.PopulateLookupFields(control_KODESTATUSPBJ.FieldInfo);
			            value=control_KODESTATUSPBJ.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("KODESTATUSPBJ");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_CATATAN = new Control("CATATAN", item.CATATAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	CATATAN - 
		        
		                                value = control_CATATAN.GetData();
			            value = control_CATATAN.ProcessLargeText(value,"field=CATATAN" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("CATATAN");
		        		        showRawValues.Add(string.Empty);
        }

        if(RequestAction =="added" && inlineedit == ADD_MODE.ADD_ONTHEFLY)
        {
            output.Append("<textarea id=\"data\">");
		    output.Append("added");
            output.Append(Control.print_inline_array(showKeys));
            output.Append("\n");
		    output.Append(Control.print_inline_array(showKeyValues));
            output.Append("\n");
	        output.Append("</textarea>");
        }

        if ( RequestAction =="added" && inlineedit == ADD_MODE.ADD_INLINE ) 
        {
	        output.Append("<textarea id=\"data\">");
	        if(showValues.Count > 0  && !error_happened)
	        {
			    output.Append("saved");
		        output.Append(Control.print_inline_array(showKeys));
                output.Append("\n");
		        output.Append(Control.print_inline_array(showValues));
                output.Append("\n");
		        output.Append(Control.print_inline_array(showFields));
                output.Append("\n");
		        output.Append(Control.print_inline_array(showRawValues));
                output.Append("\n");
		        output.Append(Control.print_inline_array(showDetailKeys.Values));
                output.Append("\n");
	        }
	        else
	        {
		        if(status=="DECLINED")
                {
			        output.Append("decli");
                }
		        else
                {
			        output.Append("error");
                    output.Append(msg);
                }
	        }
	        output.Append("</textarea>");
        }
        else
        {
            MODE ctrlMode;
            IDictionary<string, object> detailkeys = new Dictionary<string, object>();
            
            object KODEPBJ_value = null;
            if(defvalues.ContainsKey("KODEPBJ"))
            {
                KODEPBJ_value = defvalues["KODEPBJ"];
            }
            else if(isCopy)
            {
                KODEPBJ_value = item.KODEPBJ;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODEPBJ = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODEPBJ")))
            {
                edit_control_KODEPBJ = new Control("KODEPBJ", detailkeys["KODEPBJ"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODEPBJ = new Control("KODEPBJ", KODEPBJ_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("KODEPBJ_editcontrol", edit_control_KODEPBJ.BuildEditControl());
            object NAMAKEGIATAN_value = null;
            if(defvalues.ContainsKey("NAMAKEGIATAN"))
            {
                NAMAKEGIATAN_value = defvalues["NAMAKEGIATAN"];
            }
            else if(isCopy)
            {
                NAMAKEGIATAN_value = item.NAMAKEGIATAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_NAMAKEGIATAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("NAMAKEGIATAN")))
            {
                edit_control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", detailkeys["NAMAKEGIATAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", NAMAKEGIATAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("NAMAKEGIATAN_editcontrol", edit_control_NAMAKEGIATAN.BuildEditControl());
            object NAMAPAKET_value = null;
            if(defvalues.ContainsKey("NAMAPAKET"))
            {
                NAMAPAKET_value = defvalues["NAMAPAKET"];
            }
            else if(isCopy)
            {
                NAMAPAKET_value = item.NAMAPAKET;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_NAMAPAKET = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("NAMAPAKET")))
            {
                edit_control_NAMAPAKET = new Control("NAMAPAKET", detailkeys["NAMAPAKET"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_NAMAPAKET = new Control("NAMAPAKET", NAMAPAKET_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("NAMAPAKET_editcontrol", edit_control_NAMAPAKET.BuildEditControl());
            object KODESKPD_value = null;
            if(defvalues.ContainsKey("KODESKPD"))
            {
                KODESKPD_value = defvalues["KODESKPD"];
            }
            else if(isCopy)
            {
                KODESKPD_value = item.KODESKPD;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODESKPD = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODESKPD")))
            {
                edit_control_KODESKPD = new Control("KODESKPD", detailkeys["KODESKPD"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODESKPD = new Control("KODESKPD", KODESKPD_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_KODESKPD.FieldInfo);
                        smarty.Add("KODESKPD_editcontrol", edit_control_KODESKPD.BuildEditControl());
            object PPK_value = null;
            if(defvalues.ContainsKey("PPK"))
            {
                PPK_value = defvalues["PPK"];
            }
            else if(isCopy)
            {
                PPK_value = item.PPK;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PPK = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PPK")))
            {
                edit_control_PPK = new Control("PPK", detailkeys["PPK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PPK = new Control("PPK", PPK_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_PPK.FieldInfo);
                        smarty.Add("PPK_editcontrol", edit_control_PPK.BuildEditControl());
            object PPTK_value = null;
            if(defvalues.ContainsKey("PPTK"))
            {
                PPTK_value = defvalues["PPTK"];
            }
            else if(isCopy)
            {
                PPTK_value = item.PPTK;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PPTK = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PPTK")))
            {
                edit_control_PPTK = new Control("PPTK", detailkeys["PPTK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PPTK = new Control("PPTK", PPTK_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_PPTK.FieldInfo);
                        smarty.Add("PPTK_editcontrol", edit_control_PPTK.BuildEditControl());
            object KODEJENISKEGIATAN_value = null;
            if(defvalues.ContainsKey("KODEJENISKEGIATAN"))
            {
                KODEJENISKEGIATAN_value = defvalues["KODEJENISKEGIATAN"];
            }
            else if(isCopy)
            {
                KODEJENISKEGIATAN_value = item.KODEJENISKEGIATAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODEJENISKEGIATAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODEJENISKEGIATAN")))
            {
                edit_control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", detailkeys["KODEJENISKEGIATAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", KODEJENISKEGIATAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_KODEJENISKEGIATAN.FieldInfo);
                        smarty.Add("KODEJENISKEGIATAN_editcontrol", edit_control_KODEJENISKEGIATAN.BuildEditControl());
            object PROSESPENGADAAN_value = null;
            if(defvalues.ContainsKey("PROSESPENGADAAN"))
            {
                PROSESPENGADAAN_value = defvalues["PROSESPENGADAAN"];
            }
            else if(isCopy)
            {
                PROSESPENGADAAN_value = item.PROSESPENGADAAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PROSESPENGADAAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PROSESPENGADAAN")))
            {
                edit_control_PROSESPENGADAAN = new Control("PROSESPENGADAAN", detailkeys["PROSESPENGADAAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PROSESPENGADAAN = new Control("PROSESPENGADAAN", PROSESPENGADAAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("PROSESPENGADAAN_editcontrol", edit_control_PROSESPENGADAAN.BuildEditControl());
            object TANGGALPENGAJUAN_value = null;
            if(defvalues.ContainsKey("TANGGALPENGAJUAN"))
            {
                TANGGALPENGAJUAN_value = defvalues["TANGGALPENGAJUAN"];
            }
            else if(isCopy)
            {
                TANGGALPENGAJUAN_value = item.TANGGALPENGAJUAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_TANGGALPENGAJUAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("TANGGALPENGAJUAN")))
            {
                edit_control_TANGGALPENGAJUAN = new Control("TANGGALPENGAJUAN", detailkeys["TANGGALPENGAJUAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_TANGGALPENGAJUAN = new Control("TANGGALPENGAJUAN", TANGGALPENGAJUAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("TANGGALPENGAJUAN_editcontrol", edit_control_TANGGALPENGAJUAN.BuildEditControl());
            object PEMBAWABERKAS1_value = null;
            if(defvalues.ContainsKey("PEMBAWABERKAS1"))
            {
                PEMBAWABERKAS1_value = defvalues["PEMBAWABERKAS1"];
            }
            else if(isCopy)
            {
                PEMBAWABERKAS1_value = item.PEMBAWABERKAS1;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PEMBAWABERKAS1 = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PEMBAWABERKAS1")))
            {
                edit_control_PEMBAWABERKAS1 = new Control("PEMBAWABERKAS1", detailkeys["PEMBAWABERKAS1"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PEMBAWABERKAS1 = new Control("PEMBAWABERKAS1", PEMBAWABERKAS1_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("PEMBAWABERKAS1_editcontrol", edit_control_PEMBAWABERKAS1.BuildEditControl());
            object PENERIMABERKAS1_value = null;
            if(defvalues.ContainsKey("PENERIMABERKAS1"))
            {
                PENERIMABERKAS1_value = defvalues["PENERIMABERKAS1"];
            }
            else if(isCopy)
            {
                PENERIMABERKAS1_value = item.PENERIMABERKAS1;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PENERIMABERKAS1 = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PENERIMABERKAS1")))
            {
                edit_control_PENERIMABERKAS1 = new Control("PENERIMABERKAS1", detailkeys["PENERIMABERKAS1"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PENERIMABERKAS1 = new Control("PENERIMABERKAS1", PENERIMABERKAS1_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("PENERIMABERKAS1_editcontrol", edit_control_PENERIMABERKAS1.BuildEditControl());
            object PEMBAWABERKAS2_value = null;
            if(defvalues.ContainsKey("PEMBAWABERKAS2"))
            {
                PEMBAWABERKAS2_value = defvalues["PEMBAWABERKAS2"];
            }
            else if(isCopy)
            {
                PEMBAWABERKAS2_value = item.PEMBAWABERKAS2;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PEMBAWABERKAS2 = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PEMBAWABERKAS2")))
            {
                edit_control_PEMBAWABERKAS2 = new Control("PEMBAWABERKAS2", detailkeys["PEMBAWABERKAS2"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PEMBAWABERKAS2 = new Control("PEMBAWABERKAS2", PEMBAWABERKAS2_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("PEMBAWABERKAS2_editcontrol", edit_control_PEMBAWABERKAS2.BuildEditControl());
            object PENERIMABERKAS2_value = null;
            if(defvalues.ContainsKey("PENERIMABERKAS2"))
            {
                PENERIMABERKAS2_value = defvalues["PENERIMABERKAS2"];
            }
            else if(isCopy)
            {
                PENERIMABERKAS2_value = item.PENERIMABERKAS2;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PENERIMABERKAS2 = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PENERIMABERKAS2")))
            {
                edit_control_PENERIMABERKAS2 = new Control("PENERIMABERKAS2", detailkeys["PENERIMABERKAS2"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PENERIMABERKAS2 = new Control("PENERIMABERKAS2", PENERIMABERKAS2_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("PENERIMABERKAS2_editcontrol", edit_control_PENERIMABERKAS2.BuildEditControl());
            object LENGKAP_value = null;
            if(defvalues.ContainsKey("LENGKAP"))
            {
                LENGKAP_value = defvalues["LENGKAP"];
            }
            else if(isCopy)
            {
                LENGKAP_value = item.LENGKAP;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_LENGKAP = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("LENGKAP")))
            {
                edit_control_LENGKAP = new Control("LENGKAP", detailkeys["LENGKAP"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_LENGKAP = new Control("LENGKAP", LENGKAP_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("LENGKAP_editcontrol", edit_control_LENGKAP.BuildEditControl());
            object DIKEMBALIKAN_value = null;
            if(defvalues.ContainsKey("DIKEMBALIKAN"))
            {
                DIKEMBALIKAN_value = defvalues["DIKEMBALIKAN"];
            }
            else if(isCopy)
            {
                DIKEMBALIKAN_value = item.DIKEMBALIKAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_DIKEMBALIKAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("DIKEMBALIKAN")))
            {
                edit_control_DIKEMBALIKAN = new Control("DIKEMBALIKAN", detailkeys["DIKEMBALIKAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_DIKEMBALIKAN = new Control("DIKEMBALIKAN", DIKEMBALIKAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("DIKEMBALIKAN_editcontrol", edit_control_DIKEMBALIKAN.BuildEditControl());
            object TANGGALKEMBALI_value = null;
            if(defvalues.ContainsKey("TANGGALKEMBALI"))
            {
                TANGGALKEMBALI_value = defvalues["TANGGALKEMBALI"];
            }
            else if(isCopy)
            {
                TANGGALKEMBALI_value = item.TANGGALKEMBALI;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_TANGGALKEMBALI = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("TANGGALKEMBALI")))
            {
                edit_control_TANGGALKEMBALI = new Control("TANGGALKEMBALI", detailkeys["TANGGALKEMBALI"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_TANGGALKEMBALI = new Control("TANGGALKEMBALI", TANGGALKEMBALI_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("TANGGALKEMBALI_editcontrol", edit_control_TANGGALKEMBALI.BuildEditControl());
            object KODESTATUSPBJ_value = null;
            if(defvalues.ContainsKey("KODESTATUSPBJ"))
            {
                KODESTATUSPBJ_value = defvalues["KODESTATUSPBJ"];
            }
            else if(isCopy)
            {
                KODESTATUSPBJ_value = item.KODESTATUSPBJ;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODESTATUSPBJ = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODESTATUSPBJ")))
            {
                edit_control_KODESTATUSPBJ = new Control("KODESTATUSPBJ", detailkeys["KODESTATUSPBJ"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODESTATUSPBJ = new Control("KODESTATUSPBJ", KODESTATUSPBJ_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_KODESTATUSPBJ.FieldInfo);
                        smarty.Add("KODESTATUSPBJ_editcontrol", edit_control_KODESTATUSPBJ.BuildEditControl());
            object CATATAN_value = null;
            if(defvalues.ContainsKey("CATATAN"))
            {
                CATATAN_value = defvalues["CATATAN"];
            }
            else if(isCopy)
            {
                CATATAN_value = item.CATATAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_CATATAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("CATATAN")))
            {
                edit_control_CATATAN = new Control("CATATAN", detailkeys["CATATAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_CATATAN = new Control("CATATAN", CATATAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("CATATAN_editcontrol", edit_control_CATATAN.BuildEditControl());
        }
    }

    private void BuildBodyEnd()
    {
        if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
        {
	        body["end"] = "</form>" + linkdata + "<script>" + bodyonload + "</script>";
	        smarty.Add("body", body);
	        smarty.Add("flybody",true);
        }
        else
        {
	        smarty.Add("flybody", body);
	        smarty.Add("body", true);
        }
    }

    private void Wizards()
    {
        record_id= Request["recordID"];
        object value = null;
        if(defvalues.ContainsKey(""))
        {
            value = defvalues[""];
        }
        object fvalue = null;
        if(defvalues.ContainsKey("KODEPBJ"))
        {
            fvalue = defvalues["KODEPBJ"];
        }
        if (useAJAX)
        {
            if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
            {
                record_id = Request["id"];
            }
            Smarty.Table tableInfo = null;
            Smarty.Field fieldInfo = null;
            string txt = "";
            List<Smarty.LookupField> lookups = null;

            if ( inlineedit == ADD_MODE.ADD_INLINE ) 
	        {
		        linkdata = linkdata.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
            }
	        else 
	        {
		        linkdata += "SetToFirstControl('" + formname + "');";
		        if(inlineedit == ADD_MODE.ADD_SIMPLE)
		        {
			        linkdata = "<script type=\"text/javascript\">\r\n" +
			        "$(document).ready(function(){ \r\n" +
			        linkdata +
			        "});</script>";
		        }
		        else
		        {
			        linkdata = GetIncludes()  + "\r\n" + linkdata;
			        string includes="var s;";
			        foreach(string file in arr_includes)
			        {
			            includes += "s = document.createElement('script');s.src = '" + file + @"';\r\n" +
			            "document.getElementsByTagName('HEAD')[0].appendChild(s);\r\n";
			        }			
			        linkdata = includes + "\r\n" + linkdata;

			        if(RequestAction != "added")
			        {
                        linkdata = linkdata.Replace("\\", "\\\\").Replace("\r", "\\r").Replace("\n", "\\n");
			            Response.Write(linkdata);
			            Response.Write("\n");
			        }
			        else if(RequestAction == "added" && (error_happened || status=="DECLINED"))
			        {
			            Response.Write("<textarea id=\"data\">decli");
			            Response.Write(Control.HTMLEncodeSpecialChars(linkdata));
			            Response.Write("</textarea>");
			        }

		        }
	        }
        }
        else 
        {
        }
    }

    private void CopyRecord()
    {
        //	copy record
        if(Request["copyid1"] != null || Request["editid1"] != null)
        {
	        if(Request["copyid1"] != null)
	        {
                item = Data.PBJ.FetchByID(Request["copyid1"]);
                isCopy = true;
	        }
	        else
	        {
                 item = Data.PBJ.FetchByID(Request["editid1"]);
	        }

                        //	clear key fields
	            defvalues["KODEPBJ"] = item.KODEPBJ;
        }
        else if(defvalues.Count == 0)
        {
        }

        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
        {
        }
    }

    private void ReadonlyFields()
    {
        //	show readonly fields
    }

    private void Message()
    {
        if(!string.IsNullOrEmpty(msg))
        {
	        smarty["message_block"] = true;
	        smarty["message"] = msg;
        }
    }

    private void BuildBody()
    {
	    formname = "editform";
	    if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
	    {
            string includes = GetIncludes();
		    if(!string.IsNullOrEmpty(onsubmit))
            {
			    onsubmit = "onsubmit=\"" + onsubmit + "\"";
            }
		    body["begin"] = includes + 
		    "<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"PBJ_add.aspx\" " + onsubmit + ">" +
		    "<input type=hidden name=\"a\" value=\"added\">";
		    smarty.Add("backbutton_attrs","onclick=\"window.location.href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'\"");
		    smarty.Add("back_button",true);
	    }
	    else
	    {
		    formname = "editform" + (string)Request["id"];
		    body["begin"]= "<form name=\"editform" + (string)Request["id"] + "\" encType=\"multipart/form-data\" method=\"post\" action=\"PBJ_add.aspx\" " + onsubmit + " target=\"flyframe" + (string)Request["id"] + "\">" +
		    "<input type=hidden name=\"a\" value=\"added\">" + 
		    "<input type=hidden name=\"editType\" value=\"onthefly\">" + 
		    "<input type=hidden name=\"table\" value=\"" + (string)Request["table"] + "\">" +
		    "<input type=hidden name=\"field\" value=\"" + (string)Request["field"] + "\">" +
		    "<input type=hidden name=\"category\" value=\"" + (string)Request["category"] + "\">" +
            "<input type=hidden name=\"id\" value=\"" + (string)Request["id"] + "\">";
		    smarty.Add("cancelbutton_attrs","onclick=\"RemoveFlyDiv('" + (string)Request["id"] + "');\"");
		    smarty.Add("cancel_button",true);
	    }
	    smarty.Add("save_button",true);
	    smarty.Add("reset_button",true);
    }

    private string GetIncludes()
    {
        StringBuilder includes = new StringBuilder();
        if ( inlineedit != ADD_MODE.ADD_INLINE ) 
        {
            string validatetype = string.Empty;
            needvalidate = false;

            if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
            {
		        includes.Append("<script language=\"JavaScript\" src=\"include/validate.js\"></script>\r\n");
                includes.Append("<script type=\"text/javascript\">\r\n");
	            includes.AppendFormat("var TEXT_FIELDS_REQUIRED='{0}';\r\n", Control.jsreplace("The Following fields are Required"));
	            includes.AppendFormat("var TEXT_FIELDS_ZIPCODES='{0}';\r\n", Control.jsreplace("The Following fields must be valid Zipcodes"));
	            includes.AppendFormat("var TEXT_FIELDS_EMAILS='{0}';\r\n", Control.jsreplace("The Following fields must be valid Emails"));
	            includes.AppendFormat("var TEXT_FIELDS_NUMBERS='{0}';\r\n", Control.jsreplace("The Following fields must be Numbers"));
	            includes.AppendFormat("var TEXT_FIELDS_CURRENCY='{0}';\r\n", Control.jsreplace("The Following fields must be currency"));
	            includes.AppendFormat("var TEXT_FIELDS_PHONE='{0}';\r\n", Control.jsreplace("The Following fields must be Phone Numbers"));
	            includes.AppendFormat("var TEXT_FIELDS_PASSWORD1='{0}';\r\n",Control.jsreplace("The Following fields must be valid Passwords"));
	            includes.AppendFormat("var TEXT_FIELDS_PASSWORD2='{0}';\r\n", Control.jsreplace("should be at least 4 characters long"));
	            includes.AppendFormat("var TEXT_FIELDS_PASSWORD3='{0}';\r\n", Control.jsreplace("Cannot be 'password'"));
	            includes.AppendFormat("var TEXT_FIELDS_STATE='{0}';\r\n", Control.jsreplace("The Following fields must be State Names"));
	            includes.AppendFormat("var TEXT_FIELDS_SSN='{0}';\r\n", Control.jsreplace("The Following fields must be Social Security Numbers"));
	            includes.AppendFormat("var TEXT_FIELDS_DATE='{0}';\r\n", Control.jsreplace("The Following fields must be valid dates"));
	            includes.AppendFormat("var TEXT_FIELDS_TIME='{0}';\r\n", Control.jsreplace("The Following fields must be valid time in 24-hours format"));
	            includes.AppendFormat("var TEXT_FIELDS_CC='{0}';\r\n", Control.jsreplace("The Following fields must be valid Credit Card Numbers"));
	            includes.Append( "</script>\r\n");
            }
            else
            {
                includes.Append("<script type=\"text/javascript\">\r\n");
	            includes.AppendFormat("var TEXT_INLINE_FIELD_REQUIRED='{0}';\r\n", Control.jsreplace("Required field"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_ZIPCODE='{0}';\r\n", Control.jsreplace("Field should be a valid zipcode"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_EMAIL='{0}';\r\n", Control.jsreplace("Field should be a valid email address"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_NUMBER='{0}';\r\n", Control.jsreplace("Field should be a valid number"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_CURRENCY='{0}';\r\n", Control.jsreplace("Field should be a valid currency"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_PHONE='{0}';\r\n", Control.jsreplace("Field should be a valid phone number"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_PASSWORD1='{0}';\r\n",Control.jsreplace("Field can not be 'password'"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_PASSWORD2='{0}';\r\n", Control.jsreplace("Field should be at least 4 characters long"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_STATE='{0}';\r\n", Control.jsreplace("Field should be a valid US state name"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_SSN='{0}';\r\n", Control.jsreplace("Field should be a valid Social Security Number"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_DATE='{0}';\r\n", Control.jsreplace("Field should be a valid date"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_TIME='{0}';\r\n", Control.jsreplace("Field should be a valid time in 24-hour format"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_CC='{0}';\r\n", Control.jsreplace("Field should be a valid credit card number"));
	            includes.AppendFormat("var TEXT_INLINE_FIELD_SSN='{0}';\r\n", Control.jsreplace("Field should be a valid Social Security Number"));
	            includes.Append( "</script>\r\n");
            }

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KODEPBJ_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODEPBJ','" + validatetype + "','KODE PBJ');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KODESKPD_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODESKPD','" + validatetype + "','SKPD');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_PPK_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_PPK','" + validatetype + "','PPK');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_PPTK_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_PPTK','" + validatetype + "','PPTK');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KODEJENISKEGIATAN_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODEJENISKEGIATAN','" + validatetype + "','JENIS KEGIATAN');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KODESTATUSPBJ_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODESTATUSPBJ','" + validatetype + "','STATUS');";
                    }
		        }

            if(needvalidate)
	        {
		        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                {
			        onsubmit = "return validate_fly(this);";
                }
		        else
                {
			        onsubmit = "return validate();";
                }
		        //bodyonload = "onload=\"" + bodyonload + "\"";
	        }

            if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
	        {
		        includes.Append("<script language=\"JavaScript\" src=\"include/jquery.js\"></script>\r\n");
		        includes.Append("<script language=\"JavaScript\" src=\"include/onthefly.js\"></script>\r\n");
		        if (useAJAX) 
			        includes.Append("<script language=\"JavaScript\" src=\"include/ajaxsuggest.js\"></script>\r\n");
		        includes.Append("<script language=\"JavaScript\" src=\"include/jsfunctions.js\"></script>\r\n");
	        }
	        if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
	        {
		        includes.Append("<script language=\"JavaScript\">\r\n");
	        }
	        includes.Append("var locale_dateformat = '" + Control.locale_info("LOCALE_IDATE", smarty) + "';\r\n" +
	        "var locale_datedelimiter = \"" + Control.locale_info("LOCALE_SDATE", smarty) + "\";\r\n" + 
	        "var bLoading=false;\r\n" + 
	        "var TEXT_PLEASE_SELECT='" + Control.AddSlashes("Please select") + "';\r\n");
	        if (useAJAX) 
            {
	            includes.Append("var SUGGEST_TABLE='PBJ_searchsuggest.aspx';\r\n");
	        }
	        if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
	        {
		        includes.Append("</script>\r\n");
		        if (useAJAX)
			        includes.Append("<div id=\"search_suggest\"></div>\r\n");
	        }

	        	        //	include datepicker files
	        if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
            {
		        includes.Append("<script language=\"JavaScript\" src=\"include/calendar.js\"></script>\r\n");
            }
	        else
            {
		        arr_includes.Add("include/calendar.js");
            }
	        
            


            smarty.Add("KODEPBJ_fieldblock",true);
            smarty.Add("NAMAKEGIATAN_fieldblock",true);
            smarty.Add("NAMAPAKET_fieldblock",true);
            smarty.Add("KODESKPD_fieldblock",true);
            smarty.Add("PPK_fieldblock",true);
            smarty.Add("PPTK_fieldblock",true);
            smarty.Add("KODEJENISKEGIATAN_fieldblock",true);
            smarty.Add("PROSESPENGADAAN_fieldblock",true);
            smarty.Add("TANGGALPENGAJUAN_fieldblock",true);
            smarty.Add("PEMBAWABERKAS1_fieldblock",true);
            smarty.Add("PENERIMABERKAS1_fieldblock",true);
            smarty.Add("PEMBAWABERKAS2_fieldblock",true);
            smarty.Add("PENERIMABERKAS2_fieldblock",true);
            smarty.Add("LENGKAP_fieldblock",true);
            smarty.Add("DIKEMBALIKAN_fieldblock",true);
            smarty.Add("TANGGALKEMBALI_fieldblock",true);
            smarty.Add("KODESTATUSPBJ_fieldblock",true);
            smarty.Add("CATATAN_fieldblock",true);
        }

        return includes.ToString();
    }

    private void Init()
    {
        if((string)Request["editType"] == "inline")
        {
	        inlineedit = ADD_MODE.ADD_INLINE;
        }
        else if((string)Request["editType"] == "onthefly")
        {
	        inlineedit = ADD_MODE.ADD_ONTHEFLY;
        }
        else
        {
	        inlineedit = ADD_MODE.ADD_SIMPLE;
        }
        if(inlineedit == ADD_MODE.ADD_INLINE)
        {
	        templatefile = "PBJ_inline_add.aspx";
        }
        else
        {
	        templatefile = "PBJ_add.aspx";
        }
    }

    private string Mastertable
    {
        get
        {
            return (string)SessionPropertyGet(strTableName + "_mastertable", string.Empty);
        }
        set
        {
            SessionPropertySet(strTableName + "_mastertable", value);
        }
    }

        private bool CheckSecurity()
    {
        //	check if logged in
                if(string.IsNullOrEmpty(UserName) && func.IsAdminUser() && !(func.CheckSecurity(strTableName, "Add", OwnerID)))
        {
            this.Response.Write("<p>" + "You don't have permissions to access this table" + "<br>Proceed to <a href=\"admin.aspx'\">Admin Area</a> to set up user permissions</p>");
            this.Response.End();
            return false;
        }

        if(string.IsNullOrEmpty(UserName) || !func.CheckSecurity(strTableName, "Add", OwnerID))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
            return false;
        }
        return true;
    }
}

