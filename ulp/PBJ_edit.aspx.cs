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

public partial class CPBJ_Edit : AspNetRunnerPage 
{
    string filename = string.Empty;
    string status = string.Empty;
    string msg = string.Empty;
    string linkdata = string.Empty;
    string formname = string.Empty;
    string onsubmit = string.Empty;
    string bodyonload = string.Empty;
    bool error_happened=false;
    IDictionary<string, object> keys = new Dictionary<string, object>();
    IList<string> showKeys = new List<string>();
    IList<string> showValues = new List<string>();
    IList<string> showRawValues = new List<string>();
    IList<string> showFields = new List<string>();
    IDictionary<string, string> showDetailKeys = new Dictionary<string, string>();
    IDictionary<string, object> rdonlyfields = new Dictionary<string, object>();
    IDictionary<string, object> body = new Dictionary<string, object>();
    IDictionary<string, object> defvalues = new Dictionary<string, object>();
    IList<string> arr_includes = new List<string>();
    bool inlineedit;
    string templatefile;
    bool needvalidate;
    string record_id;
    
    Data.PBJController controller = new Data.PBJController();
    Data.PBJ item = null;
	
	//additional declaration for new field
	//public string pagu;
	//public string hps;
	
    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PBJ";
        strTableNameLocale = "dbo_PBJ";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
                CheckSecurity();
				
		/*
		// load pagu and hps
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select pagu, hps from pbj where kodepbj = '" + Request["editid1"] + "';";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		while (myReader.Read())
        {
            this.pagu = myReader.GetValue(0).ToString();
            this.hps = myReader.GetValue(1).ToString();
        }
        myReader.Close();
		*/
		
        if(Init())
        {
            if(RequestAction == "edited")
            {
                try
                {
                    SaveData();
                }
                catch(Exception saveEx)
                {
                    msg = saveEx.Message;
                    error_happened = true;
                    ShowFailMessage(saveEx);
                }
            }
            BuildBody();
            Message();
            ReadonlyFields();
            Wizards();
            BuildBodyEnd();
            BuildForm();
            if(RequestAction == "edited")
            {
                if(!inlineedit)
                {
                    output.Append(func.BuildOutput(this, @"~\" + templatefile, smarty));
                }
            }
            else
            {
                output.Append(func.BuildOutput(this, @"~\" + templatefile, smarty));
            }
        }
        this.Response.Write(output.ToString());
        this.Response.End();
    }

    private void ShowSuccessMessage()
    {
        if(RequestAction == "edited")
        {
            if ( inlineedit ) 
		    {
			    status ="UPDATED";
			    msg ="Record updated";
		    } 
		    else
            {
			    msg = "<div class=message><<< " + "Record updated" + " >>></div>";
            }
        }
    }

    private void ShowFailMessage(Exception e)
    {
        if(RequestAction == "edited")
        {
            if ( inlineedit ) 
		    {
			    msg ="Record was NOT edited";
		    } 
		    else
            {
			    msg = "<div class=message><<< " + "Record was NOT edited" + " >>></div>";
            }
        }
    }

    private void SaveData()
    {
        if (RequestAction != "edited")
        {
            item = new Data.PBJ();
        }

        Data.PBJ emptyItem = new Data.PBJ();

                //	processing NAMAKEGIATAN - start
                        if(!string.IsNullOrEmpty(Request["value_NAMAKEGIATAN"]))
        {
                                                item.NAMAKEGIATAN = Convert.ToString(Request["value_NAMAKEGIATAN"]);

                    }
        else
        {
            item.NAMAKEGIATAN = emptyItem.NAMAKEGIATAN;
        }
        //	processing NAMAPAKET - start
                        if(!string.IsNullOrEmpty(Request["value_NAMAPAKET"]))
        {
                                                item.NAMAPAKET = Convert.ToString(Request["value_NAMAPAKET"]);

                    }
        else
        {
            item.NAMAPAKET = emptyItem.NAMAPAKET;
        }
        //	processing KODESKPD - start
                        if(!string.IsNullOrEmpty(Request["value_KODESKPD"]))
        {
                                                item.KODESKPD = Convert.ToString(Request["value_KODESKPD"]);

                    }
        else
        {
            item.KODESKPD = emptyItem.KODESKPD;
        }
        //	processing PPK - start
                        if(!string.IsNullOrEmpty(Request["value_PPK"]))
        {
                                                item.PPK = Convert.ToString(Request["value_PPK"]);

                    }
        else
        {
            item.PPK = emptyItem.PPK;
        }
        //	processing PPTK - start
                        if(!string.IsNullOrEmpty(Request["value_PPTK"]))
        {
                                                item.PPTK = Convert.ToString(Request["value_PPTK"]);

                    }
        else
        {
            item.PPTK = emptyItem.PPTK;
        }
        //	processing KODEJENISKEGIATAN - start
                        if(!string.IsNullOrEmpty(Request["value_KODEJENISKEGIATAN"]))
        {
                                                item.KODEJENISKEGIATAN = Convert.ToString(Request["value_KODEJENISKEGIATAN"]);

                    }
        else
        {
            item.KODEJENISKEGIATAN = emptyItem.KODEJENISKEGIATAN;
        }
        //	processing PROSESPENGADAAN - start
                        if(!string.IsNullOrEmpty(Request["value_PROSESPENGADAAN"]))
        {
                                                item.PROSESPENGADAAN = Convert.ToString(Request["value_PROSESPENGADAAN"]);

                    }
        else
        {
            item.PROSESPENGADAAN = emptyItem.PROSESPENGADAAN;
        }
        //	processing TANGGALPENGAJUAN - start
                        if(!string.IsNullOrEmpty(Request["value_TANGGALPENGAJUAN"]))
        {
                                                item.TANGGALPENGAJUAN = Convert.ToDateTime(Request["value_TANGGALPENGAJUAN"]);

                    }
        else
        {
            item.TANGGALPENGAJUAN = emptyItem.TANGGALPENGAJUAN;
        }
        //	processing PEMBAWABERKAS1 - start
                        if(!string.IsNullOrEmpty(Request["value_PEMBAWABERKAS1"]))
        {
                                                item.PEMBAWABERKAS1 = Convert.ToString(Request["value_PEMBAWABERKAS1"]);

                    }
        else
        {
            item.PEMBAWABERKAS1 = emptyItem.PEMBAWABERKAS1;
        }
        //	processing PENERIMABERKAS1 - start
                        if(!string.IsNullOrEmpty(Request["value_PENERIMABERKAS1"]))
        {
                                                item.PENERIMABERKAS1 = Convert.ToString(Request["value_PENERIMABERKAS1"]);

                    }
        else
        {
            item.PENERIMABERKAS1 = emptyItem.PENERIMABERKAS1;
        }
        //	processing PEMBAWABERKAS2 - start
                        if(!string.IsNullOrEmpty(Request["value_PEMBAWABERKAS2"]))
        {
                                                item.PEMBAWABERKAS2 = Convert.ToString(Request["value_PEMBAWABERKAS2"]);

                    }
        else
        {
            item.PEMBAWABERKAS2 = emptyItem.PEMBAWABERKAS2;
        }
        //	processing PENERIMABERKAS2 - start
                        if(!string.IsNullOrEmpty(Request["value_PENERIMABERKAS2"]))
        {
                                                item.PENERIMABERKAS2 = Convert.ToString(Request["value_PENERIMABERKAS2"]);

                    }
        else
        {
            item.PENERIMABERKAS2 = emptyItem.PENERIMABERKAS2;
        }
        //	processing LENGKAP - start
                        if(!string.IsNullOrEmpty(Request["value_LENGKAP"]))
        {
                                                item.LENGKAP = Convert.ToString(Request["value_LENGKAP"]);

                    }
        else
        {
            item.LENGKAP = emptyItem.LENGKAP;
        }
        //	processing DIKEMBALIKAN - start
                        if(!string.IsNullOrEmpty(Request["value_DIKEMBALIKAN"]))
        {
                                                item.DIKEMBALIKAN = Convert.ToString(Request["value_DIKEMBALIKAN"]);

                    }
        else
        {
            item.DIKEMBALIKAN = emptyItem.DIKEMBALIKAN;
        }
        //	processing TANGGALKEMBALI - start
                        if(!string.IsNullOrEmpty(Request["value_TANGGALKEMBALI"]))
        {
                                                item.TANGGALKEMBALI = Convert.ToDateTime(Request["value_TANGGALKEMBALI"]);

                    }
        else
        {
            item.TANGGALKEMBALI = emptyItem.TANGGALKEMBALI;
        }
        //	processing KODESTATUSPBJ - start
                        if(!string.IsNullOrEmpty(Request["value_KODESTATUSPBJ"]))
        {
                                                item.KODESTATUSPBJ = Convert.ToString(Request["value_KODESTATUSPBJ"]);

                    }
        else
        {
            item.KODESTATUSPBJ = emptyItem.KODESTATUSPBJ;
        }
        //	processing CATATAN - start
                        if(!string.IsNullOrEmpty(Request["value_CATATAN"]))
        {
                                                item.CATATAN = Convert.ToString(Request["value_CATATAN"]);

                    }
        else
        {
            item.CATATAN = emptyItem.CATATAN;
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
        //
        //item.KODEPBJ =  Convert.ToString(Request["editid1"]);
        //
        string idx = string.Empty;
        idx = "1";
                                               item.KODEPBJ =  Convert.ToString(Request["editid" + idx]);
        bool abortSaving = false;
                if(!abortSaving)
        {
            item.MarkOld();
            item.Save();
            idx = "1";
                                   item.KODEPBJ =  Convert.ToString(Request["editid" + idx]);

			// save pagu and hps
			SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
			string ssql = "";
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
				SqlCommand myCommand = new SqlCommand();
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

        string keylink="";
	    keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEPBJ.ToString()));

        if(RequestAction == "edited" && inlineedit)
        {
            string masterquery = string.Empty;
	        masterquery="mastertable=dbo%2EPBJ";
	        masterquery += "&masterkey1=" + this.Server.UrlEncode(item.KODEPBJ.ToString());
	        showDetailKeys["KELENGKAPANPBJ"] = masterquery;
	        masterquery="mastertable=dbo%2EPBJ";
	        masterquery += "&masterkey1=" + this.Server.UrlEncode(item.KODEPBJ.ToString());
	        showDetailKeys["ASSIGNMENT"] = masterquery;
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEPBJ.ToString()));

            string value="";

            output.Append("<textarea id=\"data\">");
	        if(showValues.Count > 0)
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
                }
	        }
	        output.Append("</textarea>");
        }
        else
        {
            MODE ctrlMode;
            if(inlineedit)
            {
                ctrlMode = MODE.MODE_INLINE_EDIT;
            }
            else
            {
                ctrlMode = MODE.MODE_EDIT;
            }
            Control control_KODEPBJ = null;
            if(defvalues.ContainsKey("KODEPBJ"))
            {
                control_KODEPBJ = new Control("KODEPBJ", defvalues["KODEPBJ"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_KODEPBJ = new Control("KODEPBJ", item.KODEPBJ, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("KODEPBJ_editcontrol",control_KODEPBJ.BuildEditControl());
            Control control_NAMAKEGIATAN = null;
            if(defvalues.ContainsKey("NAMAKEGIATAN"))
            {
                control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", defvalues["NAMAKEGIATAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", item.NAMAKEGIATAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("NAMAKEGIATAN_editcontrol",control_NAMAKEGIATAN.BuildEditControl());
            Control control_NAMAPAKET = null;
            if(defvalues.ContainsKey("NAMAPAKET"))
            {
                control_NAMAPAKET = new Control("NAMAPAKET", defvalues["NAMAPAKET"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_NAMAPAKET = new Control("NAMAPAKET", item.NAMAPAKET, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("NAMAPAKET_editcontrol",control_NAMAPAKET.BuildEditControl());
            Control control_KODESKPD = null;
            if(defvalues.ContainsKey("KODESKPD"))
            {
                control_KODESKPD = new Control("KODESKPD", defvalues["KODESKPD"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_KODESKPD = new Control("KODESKPD", item.KODESKPD, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_KODESKPD.FieldInfo);
            smarty.Add("KODESKPD_editcontrol",control_KODESKPD.BuildEditControl());
            Control control_PPK = null;
            if(defvalues.ContainsKey("PPK"))
            {
                control_PPK = new Control("PPK", defvalues["PPK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PPK = new Control("PPK", item.PPK, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_PPK.FieldInfo);
            smarty.Add("PPK_editcontrol",control_PPK.BuildEditControl());
            Control control_PPTK = null;
            if(defvalues.ContainsKey("PPTK"))
            {
                control_PPTK = new Control("PPTK", defvalues["PPTK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PPTK = new Control("PPTK", item.PPTK, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_PPTK.FieldInfo);
            smarty.Add("PPTK_editcontrol",control_PPTK.BuildEditControl());
            Control control_KODEJENISKEGIATAN = null;
            if(defvalues.ContainsKey("KODEJENISKEGIATAN"))
            {
                control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", defvalues["KODEJENISKEGIATAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", item.KODEJENISKEGIATAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_KODEJENISKEGIATAN.FieldInfo);
            smarty.Add("KODEJENISKEGIATAN_editcontrol",control_KODEJENISKEGIATAN.BuildEditControl());
            Control control_PROSESPENGADAAN = null;
            if(defvalues.ContainsKey("PROSESPENGADAAN"))
            {
                control_PROSESPENGADAAN = new Control("PROSESPENGADAAN", defvalues["PROSESPENGADAAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PROSESPENGADAAN = new Control("PROSESPENGADAAN", item.PROSESPENGADAAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PROSESPENGADAAN_editcontrol",control_PROSESPENGADAAN.BuildEditControl());
            Control control_TANGGALPENGAJUAN = null;
            if(defvalues.ContainsKey("TANGGALPENGAJUAN"))
            {
                control_TANGGALPENGAJUAN = new Control("TANGGALPENGAJUAN", defvalues["TANGGALPENGAJUAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_TANGGALPENGAJUAN = new Control("TANGGALPENGAJUAN", item.TANGGALPENGAJUAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("TANGGALPENGAJUAN_editcontrol",control_TANGGALPENGAJUAN.BuildEditControl());
            Control control_PEMBAWABERKAS1 = null;
            if(defvalues.ContainsKey("PEMBAWABERKAS1"))
            {
                control_PEMBAWABERKAS1 = new Control("PEMBAWABERKAS1", defvalues["PEMBAWABERKAS1"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PEMBAWABERKAS1 = new Control("PEMBAWABERKAS1", item.PEMBAWABERKAS1, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PEMBAWABERKAS1_editcontrol",control_PEMBAWABERKAS1.BuildEditControl());
            Control control_PENERIMABERKAS1 = null;
            if(defvalues.ContainsKey("PENERIMABERKAS1"))
            {
                control_PENERIMABERKAS1 = new Control("PENERIMABERKAS1", defvalues["PENERIMABERKAS1"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PENERIMABERKAS1 = new Control("PENERIMABERKAS1", item.PENERIMABERKAS1, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PENERIMABERKAS1_editcontrol",control_PENERIMABERKAS1.BuildEditControl());
            Control control_PEMBAWABERKAS2 = null;
            if(defvalues.ContainsKey("PEMBAWABERKAS2"))
            {
                control_PEMBAWABERKAS2 = new Control("PEMBAWABERKAS2", defvalues["PEMBAWABERKAS2"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PEMBAWABERKAS2 = new Control("PEMBAWABERKAS2", item.PEMBAWABERKAS2, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PEMBAWABERKAS2_editcontrol",control_PEMBAWABERKAS2.BuildEditControl());
            Control control_PENERIMABERKAS2 = null;
            if(defvalues.ContainsKey("PENERIMABERKAS2"))
            {
                control_PENERIMABERKAS2 = new Control("PENERIMABERKAS2", defvalues["PENERIMABERKAS2"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PENERIMABERKAS2 = new Control("PENERIMABERKAS2", item.PENERIMABERKAS2, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PENERIMABERKAS2_editcontrol",control_PENERIMABERKAS2.BuildEditControl());
            Control control_LENGKAP = null;
            if(defvalues.ContainsKey("LENGKAP"))
            {
                control_LENGKAP = new Control("LENGKAP", defvalues["LENGKAP"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_LENGKAP = new Control("LENGKAP", item.LENGKAP, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("LENGKAP_editcontrol",control_LENGKAP.BuildEditControl());
            Control control_DIKEMBALIKAN = null;
            if(defvalues.ContainsKey("DIKEMBALIKAN"))
            {
                control_DIKEMBALIKAN = new Control("DIKEMBALIKAN", defvalues["DIKEMBALIKAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_DIKEMBALIKAN = new Control("DIKEMBALIKAN", item.DIKEMBALIKAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("DIKEMBALIKAN_editcontrol",control_DIKEMBALIKAN.BuildEditControl());
            Control control_TANGGALKEMBALI = null;
            if(defvalues.ContainsKey("TANGGALKEMBALI"))
            {
                control_TANGGALKEMBALI = new Control("TANGGALKEMBALI", defvalues["TANGGALKEMBALI"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_TANGGALKEMBALI = new Control("TANGGALKEMBALI", item.TANGGALKEMBALI, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("TANGGALKEMBALI_editcontrol",control_TANGGALKEMBALI.BuildEditControl());
            Control control_KODESTATUSPBJ = null;
            if(defvalues.ContainsKey("KODESTATUSPBJ"))
            {
                control_KODESTATUSPBJ = new Control("KODESTATUSPBJ", defvalues["KODESTATUSPBJ"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_KODESTATUSPBJ = new Control("KODESTATUSPBJ", item.KODESTATUSPBJ, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_KODESTATUSPBJ.FieldInfo);
            smarty.Add("KODESTATUSPBJ_editcontrol",control_KODESTATUSPBJ.BuildEditControl());
            Control control_CATATAN = null;
            if(defvalues.ContainsKey("CATATAN"))
            {
                control_CATATAN = new Control("CATATAN", defvalues["CATATAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_CATATAN = new Control("CATATAN", item.CATATAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("CATATAN_editcontrol",control_CATATAN.BuildEditControl());
        }
    }

    private void BuildBodyEnd()
    {
        body["end"]="</form>" + linkdata +
            "<script>" + bodyonload + "</script>" +
            "<script>SetToFirstControl('editform');</script>";
        smarty.Add("body", body);
    }

    private void Wizards()
    {
        
        if (useAJAX)
        {
            string txt = "";
            Smarty.Table tableInfo = null;
            Smarty.Field fieldInfo = null;
            List<Smarty.LookupField> lookups = null;

	            if ( inlineedit ) 
	            {

		            linkdata = linkdata.Replace("&","&amp;").Replace("<", "&lt;").Replace(">", "&gt;");

		            smarty.Add("linkdata",linkdata);
	            } 
	            else
	            {
		            linkdata = "<script type=\"text/javascript\">\r\n" +
		            "$(document).ready(function(){ \r\n" +
		            linkdata +
		            "});</script>";
	            }
            } 
            else 
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
	        smarty.Add("message_block", true);
	        smarty.Add("message", msg);
        }
    }

    private void BuildBody()
    {
        string includes = GetIncludes();
		if(!string.IsNullOrEmpty(onsubmit))
        {
		    onsubmit = "onsubmit=\"" + onsubmit + "\"";
        }
		body["begin"] = includes + 
		"<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"PBJ_edit.aspx\" " + onsubmit + ">" +
		"<input type=hidden name=\"a\" value=\"edited\">";
        Control control_KODEPBJ = new Control("KODEPBJ", item.KODEPBJ, false, smarty, this.Request, builder, MODE.MODE_LIST);
        body["begin"] +="<input type=\"hidden\" name=\"editid1\" value=\""+ Control.HTMLEncodeSpecialChars(keys["KODEPBJ"].ToString()) + "\">";
	    	    smarty.Add("show_key1", Control.HTMLEncodeSpecialChars(control_KODEPBJ.GetData()));

        smarty.Add("backbutton_attrs","onclick=\"window.location.href='PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN'\"");
	    smarty.Add("save_button",true);
	    smarty.Add("reset_button",true);
	    smarty.Add("back_button",true);
	    
        showKeys.Add(Server.UrlEncode(keys["KODEPBJ"].ToString()));
    }

    private string GetIncludes()
    {
        StringBuilder includes = new StringBuilder();
        if ( !inlineedit ) 
        {
            string validatetype = string.Empty;

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

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_KODEPBJ','" + validatetype + "','KODE PBJ');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_KODESKPD','" + validatetype + "','SKPD');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_PPK','" + validatetype + "','PPK');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_PPTK','" + validatetype + "','PPTK');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_KODEJENISKEGIATAN','" + validatetype + "','JENIS KEGIATAN');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_KODESTATUSPBJ','" + validatetype + "','STATUS');";
		        }

            if(!string.IsNullOrEmpty(bodyonload))
	        {
		        onsubmit = "return validate();";
	        }

		    includes.Append("<script language=\"JavaScript\" src=\"include/jquery.js\"></script>\r\n");
		    includes.Append("<script language=\"JavaScript\" src=\"include/onthefly.js\"></script>\r\n");
		    if (useAJAX) 
			    includes.Append("<script language=\"JavaScript\" src=\"include/ajaxsuggest.js\"></script>\r\n");
		    includes.Append("<script language=\"JavaScript\" src=\"include/jsfunctions.js\"></script>\r\n");
	        includes.Append("<script language=\"JavaScript\">\r\n");
	        includes.Append("var locale_dateformat = '" + Control.locale_info("LOCALE_IDATE", smarty) + "';\r\n" +
	        "var locale_datedelimiter = \"" + Control.locale_info("LOCALE_SDATE", smarty) + "\";\r\n" + 
	        "var bLoading=false;\r\n" + 
	        "var TEXT_PLEASE_SELECT='" + Control.AddSlashes("Please select") + "';\r\n");
	        if (useAJAX) 
            {
	            includes.Append("var SUGGEST_TABLE='PBJ_searchsuggest.aspx';\r\n");
	        }
	        includes.Append("</script>\r\n");
	        if (useAJAX)
		        includes.Append("<div id=\"search_suggest\"></div>\r\n");

	        	        //	include datepicker files
	        includes.Append("<script language=\"JavaScript\" src=\"include/calendar.js\"></script>\r\n");
	        
            


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

    private bool Init()
    {
        inlineedit = ((string)Request["editType"] == "inline");
        record_id = (string)Request["recordID"] ;
        if(inlineedit)
        {
	        templatefile = "PBJ_inline_edit.aspx";
        }
        else
        {
	        templatefile = "PBJ_edit.aspx";
        }

        keys["KODEPBJ"] = Request["editid1"];
        if(keys.Count > 1)
        {
            item = controller.FetchByManyID(keys);
        }
        else
        {
            item = Data.PBJ.FetchByID(Request["editid1"]);
        }

        if(item != null)
        {
            	            bool editable=true;
            if(!editable)
            {
                output.Append("<p>" + "You don't have permissions to access this table" + " <a href=\"PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN\">back</a>");
                return false;
            }
        }
        else
        {
            this.Server.Transfer("~/PBJ_list.aspx?a=search&value=1&SearchFor="+DateTime.Now.Year.ToString()+"&SearchOption=Contains&SearchField=KODEPBJ&orderby=dTANGGALPENGAJUAN");
        }

        return true;
    }


        private bool CheckSecurity()
    {
        //	check if logged in
        if(string.IsNullOrEmpty(UserName) && func.IsAdminUser() && !(BaseCheckSecurity("Edit", OwnerID)))
        {
            this.Response.Write("<p>" + "You don't have permissions to access this table" + "<br>Proceed to <a href=\"admin.aspx'\">Admin Area</a> to set up user permissions</p>");
            this.Response.End();
            return false;
        }

        if(string.IsNullOrEmpty(UserName) || !BaseCheckSecurity(OwnerID, "Edit"))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
            return false;
        }
        return true;
    }
}

