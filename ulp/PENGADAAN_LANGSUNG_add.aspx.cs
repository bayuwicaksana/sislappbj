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

public partial class CPENGADAAN_LANGSUNG_Add : AspNetRunnerPage 
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
    
    Data.PENGADAAN_LANGSUNGController controller = new Data.PENGADAAN_LANGSUNGController();
    Data.PENGADAAN_LANGSUNG item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGADAAN_LANGSUNG";
        strTableNameLocale = "dbo_PENGADAAN_LANGSUNG";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
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
        item = new Data.PENGADAAN_LANGSUNG();
                //	processing KODEPENGADAANLANGSUNG - start
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select count(*), year(getdate()) from pengadaan_langsung where year(tanggalkontrak)=year(getdate());";
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
        item.KODEPENGADAANLANGSUNG = Convert.ToString(Request["value_KODESKPD"]).Replace(".", "") + ".L" + Convert.ToString(iYear) + Convert.ToString(iPbjCtr);

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
                //	processing TANGGALKONTRAK - start
                        if(!string.IsNullOrEmpty(Request["value_TANGGALKONTRAK"]))
        {
                                                                                                item.TANGGALKONTRAK = Convert.ToDateTime(Request["value_TANGGALKONTRAK"]);
                    }
                //	processing PAGU - start
                        if(!string.IsNullOrEmpty(Request["value_PAGU"]))
        {
                                                                                                item.PAGU = Convert.ToDecimal(Request["value_PAGU"]);
                    }
                //	processing HPS - start
                        if(!string.IsNullOrEmpty(Request["value_HPS"]))
        {
                                                                                                item.HPS = Convert.ToDecimal(Request["value_HPS"]);
                    }
                //	processing NILAIKONTRAK - start
                        if(!string.IsNullOrEmpty(Request["value_NILAIKONTRAK"]))
        {
                                                                                                item.NILAIKONTRAK = Convert.ToDecimal(Request["value_NILAIKONTRAK"]);
                    }
                //	processing PEMENANG - start
                        if(!string.IsNullOrEmpty(Request["value_PEMENANG"]))
        {
                                                                                                item.PEMENANG = Convert.ToString(Request["value_PEMENANG"]);
                    }
                //	processing KETERANGAN - start
                        if(!string.IsNullOrEmpty(Request["value_KETERANGAN"]))
        {
                                                                                                item.KETERANGAN = Convert.ToString(Request["value_KETERANGAN"]);
                    }
                //	processing PEJABATPENGADAAN - start
                item.PEJABATPENGADAAN = UserName;

                //	processing MENGETAHUI - start
                        if(!string.IsNullOrEmpty(Request["value_MENGETAHUI"]))
        {
                                                                                                item.MENGETAHUI = Convert.ToString(Request["value_MENGETAHUI"]);
                    }
                bool abortSaving = false;
        
        
        if(!abortSaving)
        {
            item.Save();
			
			// save jenis pengadaan
			ssql = "update PENGADAAN_LANGSUNG set JENISPENGADAAN = '" + Convert.ToString(Request["value_PEJABATPENGADAAN"]) + "' where KODEPENGADAANLANGSUNG = '" + item.KODEPENGADAANLANGSUNG + "';";
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
			// end of save jenis pengadaan
		
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
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEPENGADAANLANGSUNG.ToString()));

	        string keylink="";
	        keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEPENGADAANLANGSUNG.ToString()));

            string value="";

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
            Control control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", item.TANGGALKONTRAK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	TANGGALKONTRAK - Short Date
		        
		                                value = control_TANGGALKONTRAK.GetData();
			            value = control_TANGGALKONTRAK.ProcessLargeText(value,"field=TANGGALKONTRAK" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("TANGGALKONTRAK");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PAGU = new Control("PAGU", item.PAGU, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PAGU - Number
		        
		                                value = control_PAGU.GetData();
			            value = control_PAGU.ProcessLargeText(value,"field=PAGU" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("PAGU");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_HPS = new Control("HPS", item.HPS, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	HPS - Number
		        
		                                value = control_HPS.GetData();
			            value = control_HPS.ProcessLargeText(value,"field=HPS" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("HPS");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_NILAIKONTRAK = new Control("NILAIKONTRAK", item.NILAIKONTRAK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	NILAIKONTRAK - Number
		        
		                                value = control_NILAIKONTRAK.GetData();
			            value = control_NILAIKONTRAK.ProcessLargeText(value,"field=NILAIKONTRAK" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("NILAIKONTRAK");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PEMENANG = new Control("PEMENANG", item.PEMENANG, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PEMENANG - 
		        
		                                value = control_PEMENANG.GetData();
			            value = control_PEMENANG.ProcessLargeText(value,"field=PEMENANG" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("PEMENANG");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_KETERANGAN = new Control("KETERANGAN", item.KETERANGAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KETERANGAN - 
		        
		                                func.PopulateLookupFields(control_KETERANGAN.FieldInfo);
			            value=control_KETERANGAN.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("KETERANGAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", item.PEJABATPENGADAAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	PEJABATPENGADAAN - 
		        
		                                func.PopulateLookupFields(control_PEJABATPENGADAAN.FieldInfo);
			            value=control_PEJABATPENGADAAN.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("PEJABATPENGADAAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_MENGETAHUI = new Control("MENGETAHUI", item.MENGETAHUI, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	MENGETAHUI - 
		        
		                                func.PopulateLookupFields(control_MENGETAHUI.FieldInfo);
			            value=control_MENGETAHUI.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("MENGETAHUI");
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
            object TANGGALKONTRAK_value = null;
            if(defvalues.ContainsKey("TANGGALKONTRAK"))
            {
                TANGGALKONTRAK_value = defvalues["TANGGALKONTRAK"];
            }
            else if(isCopy)
            {
                TANGGALKONTRAK_value = item.TANGGALKONTRAK;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_TANGGALKONTRAK = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("TANGGALKONTRAK")))
            {
                edit_control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", detailkeys["TANGGALKONTRAK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", TANGGALKONTRAK_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("TANGGALKONTRAK_editcontrol", edit_control_TANGGALKONTRAK.BuildEditControl());
            object PAGU_value = null;
            if(defvalues.ContainsKey("PAGU"))
            {
                PAGU_value = defvalues["PAGU"];
            }
            else if(isCopy)
            {
                PAGU_value = item.PAGU;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PAGU = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PAGU")))
            {
                edit_control_PAGU = new Control("PAGU", detailkeys["PAGU"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PAGU = new Control("PAGU", PAGU_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("PAGU_editcontrol", edit_control_PAGU.BuildEditControl());
            object HPS_value = null;
            if(defvalues.ContainsKey("HPS"))
            {
                HPS_value = defvalues["HPS"];
            }
            else if(isCopy)
            {
                HPS_value = item.HPS;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_HPS = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("HPS")))
            {
                edit_control_HPS = new Control("HPS", detailkeys["HPS"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_HPS = new Control("HPS", HPS_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("HPS_editcontrol", edit_control_HPS.BuildEditControl());
            object NILAIKONTRAK_value = null;
            if(defvalues.ContainsKey("NILAIKONTRAK"))
            {
                NILAIKONTRAK_value = defvalues["NILAIKONTRAK"];
            }
            else if(isCopy)
            {
                NILAIKONTRAK_value = item.NILAIKONTRAK;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_NILAIKONTRAK = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("NILAIKONTRAK")))
            {
                edit_control_NILAIKONTRAK = new Control("NILAIKONTRAK", detailkeys["NILAIKONTRAK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_NILAIKONTRAK = new Control("NILAIKONTRAK", NILAIKONTRAK_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("NILAIKONTRAK_editcontrol", edit_control_NILAIKONTRAK.BuildEditControl());
            object PEMENANG_value = null;
            if(defvalues.ContainsKey("PEMENANG"))
            {
                PEMENANG_value = defvalues["PEMENANG"];
            }
            else if(isCopy)
            {
                PEMENANG_value = item.PEMENANG;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PEMENANG = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PEMENANG")))
            {
                edit_control_PEMENANG = new Control("PEMENANG", detailkeys["PEMENANG"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PEMENANG = new Control("PEMENANG", PEMENANG_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("PEMENANG_editcontrol", edit_control_PEMENANG.BuildEditControl());
            object KETERANGAN_value = null;
            if(defvalues.ContainsKey("KETERANGAN"))
            {
                KETERANGAN_value = defvalues["KETERANGAN"];
            }
            else if(isCopy)
            {
                KETERANGAN_value = item.KETERANGAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KETERANGAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KETERANGAN")))
            {
                edit_control_KETERANGAN = new Control("KETERANGAN", detailkeys["KETERANGAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KETERANGAN = new Control("KETERANGAN", KETERANGAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_KETERANGAN.FieldInfo);
                        smarty.Add("KETERANGAN_editcontrol", edit_control_KETERANGAN.BuildEditControl());
            object PEJABATPENGADAAN_value = null;
            if(defvalues.ContainsKey("PEJABATPENGADAAN"))
            {
                PEJABATPENGADAAN_value = defvalues["PEJABATPENGADAAN"];
            }
            else if(isCopy)
            {
                PEJABATPENGADAAN_value = item.PEJABATPENGADAAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_PEJABATPENGADAAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("PEJABATPENGADAAN")))
            {
                edit_control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", detailkeys["PEJABATPENGADAAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", PEJABATPENGADAAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_PEJABATPENGADAAN.FieldInfo);
                        smarty.Add("PEJABATPENGADAAN_editcontrol", edit_control_PEJABATPENGADAAN.BuildEditControl());
            object MENGETAHUI_value = null;
            if(defvalues.ContainsKey("MENGETAHUI"))
            {
                MENGETAHUI_value = defvalues["MENGETAHUI"];
            }
            else if(isCopy)
            {
                MENGETAHUI_value = item.MENGETAHUI;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_MENGETAHUI = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("MENGETAHUI")))
            {
                edit_control_MENGETAHUI = new Control("MENGETAHUI", detailkeys["MENGETAHUI"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_MENGETAHUI = new Control("MENGETAHUI", MENGETAHUI_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_MENGETAHUI.FieldInfo);
                        smarty.Add("MENGETAHUI_editcontrol", edit_control_MENGETAHUI.BuildEditControl());
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
        if(defvalues.ContainsKey("KODEPOKJA"))
        {
            fvalue = defvalues["KODEPOKJA"];
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
                item = Data.PENGADAAN_LANGSUNG.FetchByID(Request["copyid1"]);
                isCopy = true;
	        }
	        else
	        {
                 item = Data.PENGADAAN_LANGSUNG.FetchByID(Request["editid1"]);
	        }

                        //	clear key fields
	            defvalues["KODEPENGADAANLANGSUNG"] = item.KODEPENGADAANLANGSUNG;
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
		    "<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"PENGADAAN_LANGSUNG_add.aspx\" " + onsubmit + ">" +
		    "<input type=hidden name=\"a\" value=\"added\">";
		    smarty.Add("backbutton_attrs","onclick=\"window.location.href='PENGADAAN_LANGSUNG_list.aspx?a=return'\"");
		    smarty.Add("back_button",true);
	    }
	    else
	    {
		    formname = "editform" + (string)Request["id"];
		    body["begin"]= "<form name=\"editform" + (string)Request["id"] + "\" encType=\"multipart/form-data\" method=\"post\" action=\"PENGADAAN_LANGSUNG_add.aspx\" " + onsubmit + " target=\"flyframe" + (string)Request["id"] + "\">" +
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
				        linkdata += "define_fly('value_NAMAKEGIATAN_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_NAMAKEGIATAN','" + validatetype + "','NAMA KEGIATAN');";
                    }
		        }

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_NAMAPAKET_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_NAMAPAKET','" + validatetype + "','NAMA PAKET');";
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
				        linkdata += "define_fly('value_TANGGALKONTRAK_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_TANGGALKONTRAK','" + validatetype + "','TANGGAL KONTRAK');";
                    }
		        }

            
            			        			            validatetype="IsNumeric";
		        		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_PAGU_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_PAGU','" + validatetype + "','PAGU');";
                    }
		        }

            
            			        			            validatetype="IsNumeric";
		        		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_HPS_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_HPS','" + validatetype + "','HPS');";
                    }
		        }

            
            			        			            validatetype="IsNumeric";
		        		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_NILAIKONTRAK_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_NILAIKONTRAK','" + validatetype + "','NILAI KONTRAK');";
                    }
		        }

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_PEMENANG_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_PEMENANG','" + validatetype + "','PEMENANG');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KETERANGAN_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KETERANGAN','" + validatetype + "','JENIS KEGIATAN');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_PEJABATPENGADAAN_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_PEJABATPENGADAAN','" + validatetype + "','PEJABAT PENGADAAN');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_MENGETAHUI_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_MENGETAHUI','" + validatetype + "','MENGETAHUI');";
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
	            includes.Append("var SUGGEST_TABLE='PENGADAAN_LANGSUNG_searchsuggest.aspx';\r\n");
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

            


            smarty.Add("NAMAKEGIATAN_fieldblock",true);
            smarty.Add("NAMAPAKET_fieldblock",true);
            smarty.Add("KODESKPD_fieldblock",true);
            smarty.Add("TANGGALKONTRAK_fieldblock",true);
            smarty.Add("PAGU_fieldblock",true);
            smarty.Add("HPS_fieldblock",true);
            smarty.Add("NILAIKONTRAK_fieldblock",true);
            smarty.Add("PEMENANG_fieldblock",true);
            smarty.Add("KETERANGAN_fieldblock",true);
            smarty.Add("PEJABATPENGADAAN_fieldblock",true);
            smarty.Add("MENGETAHUI_fieldblock",true);
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
	        templatefile = "PENGADAAN_LANGSUNG_inline_add.aspx";
        }
        else
        {
	        templatefile = "PENGADAAN_LANGSUNG_add.aspx";
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

    }

