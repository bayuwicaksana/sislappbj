#define DEBUG
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

public partial class CTb_Vendor_Add : AspNetRunnerPage 
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
    
    Data.Tb_VendorController controller = new Data.Tb_VendorController();
    Data.Tb_Vendor item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.Tb_Vendor";
        strTableNameLocale = "dbo_Tb_Vendor";
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
        item = new Data.Tb_Vendor();

        //	processing KD_VENDOR - start
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = " select top 1 KD_VENDOR from Tb_Vendor order by KD_VENDOR desc ";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

        int iPbjCtr = 0;
		while (myReader.Read())
        {
            iPbjCtr = Convert.ToInt32(myReader.GetValue(0).ToString()) + 1;
        }
        myReader.Close();
		
        //if(!string.IsNullOrEmpty(Request["value_KD_VENDOR"]))
        //{
        //                                                                                        item.KD_VENDOR = Convert.ToInt32(Request["value_KD_VENDOR"]);
        //} else {
		//	item.KD_VENDOR = iPbjCtr;
		//}
		
		//	processing NAMA - start
                        if(!string.IsNullOrEmpty(Request["value_NAMA"]))
        {
                                                                                                item.NAMA = Convert.ToString(Request["value_NAMA"]);
                    }
                //	processing ALAMAT - start
                        if(!string.IsNullOrEmpty(Request["value_ALAMAT"]))
        {
                                                                                                item.ALAMAT = Convert.ToString(Request["value_ALAMAT"]);
                    }
                //	processing NPWP - start
                        if(!string.IsNullOrEmpty(Request["value_NPWP"]))
        {
                                                                                                item.NPWP = Convert.ToString(Request["value_NPWP"]);
                    }
                //	processing TELEPON - start
                        if(!string.IsNullOrEmpty(Request["value_TELEPON"]))
        {
                                                                                                item.TELEPON = Convert.ToString(Request["value_TELEPON"]);
                    }
                //	processing FAX - start
                        if(!string.IsNullOrEmpty(Request["value_FAX"]))
        {
                                                                                                item.FAX = Convert.ToString(Request["value_FAX"]);
                    }
                //	processing EMAIL - start
                        if(!string.IsNullOrEmpty(Request["value_EMAIL"]))
        {
                                                                                                item.EMAIL = Convert.ToString(Request["value_EMAIL"]);
                    }
                //	processing STATUS - start
                        if(!string.IsNullOrEmpty(Request["value_STATUS"]))
        {
                                                                        if((string)Request["value_STATUS"] == "on")
                        {
                            item.STATUS = true;
                        }
                    }
                bool abortSaving = false;
        
        
        if(!abortSaving)
        {
            //item.Save();
			
			// save vendor
			ssql = "insert into Tb_Vendor values ("+iPbjCtr+",'"+item.NAMA+"','"+item.ALAMAT+"','"+item.NPWP+"','"+item.TELEPON+"','"+item.FAX+"','"+item.EMAIL+"',1,getdate(),'admin',getdate(),'admin');";
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
			// end of save vendor
			
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
	        masterquery="mastertable=dbo%2ETb%5FVendor";
	        masterquery += "&masterkey1=" + this.Server.UrlEncode(item.KD_VENDOR.ToString());
	        showDetailKeys["dbo.Tb_Kontrak"] = masterquery;
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KD_VENDOR.ToString()));

	        string keylink="";
	        keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KD_VENDOR.ToString()));

            string value="";

            value="";
            Control control_NAMA = new Control("NAMA", item.NAMA, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	NAMA - 
		        
		                                value = control_NAMA.GetData();
			            value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("NAMA");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_ALAMAT = new Control("ALAMAT", item.ALAMAT, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	ALAMAT - 
		        
		                                value = control_ALAMAT.GetData();
			            value = control_ALAMAT.ProcessLargeText(value,"field=ALAMAT" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("ALAMAT");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_NPWP = new Control("NPWP", item.NPWP, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	NPWP - 
		        
		                                value = control_NPWP.GetData();
			            value = control_NPWP.ProcessLargeText(value,"field=NPWP" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("NPWP");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_TELEPON = new Control("TELEPON", item.TELEPON, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	TELEPON - 
		        
		                                value = control_TELEPON.GetData();
			            value = control_TELEPON.ProcessLargeText(value,"field=TELEPON" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("TELEPON");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_FAX = new Control("FAX", item.FAX, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	FAX - 
		        
		                                value = control_FAX.GetData();
			            value = control_FAX.ProcessLargeText(value,"field=FAX" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("FAX");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_EMAIL = new Control("EMAIL", item.EMAIL, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	EMAIL - 
		        
		                                value = control_EMAIL.GetData();
			            value = control_EMAIL.ProcessLargeText(value,"field=EMAIL" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("EMAIL");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_STATUS = new Control("STATUS", item.STATUS, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	STATUS - Checkbox
		        
		        			            value = control_STATUS.GetData();
		        showValues.Add(value);
		        showFields.Add("STATUS");
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
            
            object NAMA_value = null;
            if(defvalues.ContainsKey("NAMA"))
            {
                NAMA_value = defvalues["NAMA"];
            }
            else if(isCopy)
            {
                NAMA_value = item.NAMA;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_NAMA = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("NAMA")))
            {
                edit_control_NAMA = new Control("NAMA", detailkeys["NAMA"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_NAMA = new Control("NAMA", NAMA_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("NAMA_editcontrol", edit_control_NAMA.BuildEditControl());
            object ALAMAT_value = null;
            if(defvalues.ContainsKey("ALAMAT"))
            {
                ALAMAT_value = defvalues["ALAMAT"];
            }
            else if(isCopy)
            {
                ALAMAT_value = item.ALAMAT;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_ALAMAT = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("ALAMAT")))
            {
                edit_control_ALAMAT = new Control("ALAMAT", detailkeys["ALAMAT"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_ALAMAT = new Control("ALAMAT", ALAMAT_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("ALAMAT_editcontrol", edit_control_ALAMAT.BuildEditControl());
            object NPWP_value = null;
            if(defvalues.ContainsKey("NPWP"))
            {
                NPWP_value = defvalues["NPWP"];
            }
            else if(isCopy)
            {
                NPWP_value = item.NPWP;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_NPWP = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("NPWP")))
            {
                edit_control_NPWP = new Control("NPWP", detailkeys["NPWP"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_NPWP = new Control("NPWP", NPWP_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("NPWP_editcontrol", edit_control_NPWP.BuildEditControl());
            object TELEPON_value = null;
            if(defvalues.ContainsKey("TELEPON"))
            {
                TELEPON_value = defvalues["TELEPON"];
            }
            else if(isCopy)
            {
                TELEPON_value = item.TELEPON;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_TELEPON = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("TELEPON")))
            {
                edit_control_TELEPON = new Control("TELEPON", detailkeys["TELEPON"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_TELEPON = new Control("TELEPON", TELEPON_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("TELEPON_editcontrol", edit_control_TELEPON.BuildEditControl());
            object FAX_value = null;
            if(defvalues.ContainsKey("FAX"))
            {
                FAX_value = defvalues["FAX"];
            }
            else if(isCopy)
            {
                FAX_value = item.FAX;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_FAX = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("FAX")))
            {
                edit_control_FAX = new Control("FAX", detailkeys["FAX"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_FAX = new Control("FAX", FAX_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("FAX_editcontrol", edit_control_FAX.BuildEditControl());
            object EMAIL_value = null;
            if(defvalues.ContainsKey("EMAIL"))
            {
                EMAIL_value = defvalues["EMAIL"];
            }
            else if(isCopy)
            {
                EMAIL_value = item.EMAIL;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_EMAIL = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("EMAIL")))
            {
                edit_control_EMAIL = new Control("EMAIL", detailkeys["EMAIL"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_EMAIL = new Control("EMAIL", EMAIL_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("EMAIL_editcontrol", edit_control_EMAIL.BuildEditControl());
            object STATUS_value = null;
            if(defvalues.ContainsKey("STATUS"))
            {
                STATUS_value = defvalues["STATUS"];
            }
            else if(isCopy)
            {
                STATUS_value = item.STATUS;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_STATUS = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("STATUS")))
            {
                edit_control_STATUS = new Control("STATUS", detailkeys["STATUS"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_STATUS = new Control("STATUS", STATUS_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("STATUS_editcontrol", edit_control_STATUS.BuildEditControl());
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
        if(defvalues.ContainsKey("KD_USER"))
        {
            fvalue = defvalues["KD_USER"];
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
                item = Data.Tb_Vendor.FetchByID(Request["copyid1"]);
                isCopy = true;
	        }
	        else
	        {
                 item = Data.Tb_Vendor.FetchByID(Request["editid1"]);
	        }

                        //	clear key fields
	            defvalues["KD_VENDOR"] = item.KD_VENDOR;
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
		    "<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"Tb_Vendor_add.aspx\" " + onsubmit + ">" +
		    "<input type=hidden name=\"a\" value=\"added\">";
		    smarty.Add("backbutton_attrs","onclick=\"window.location.href='Tb_Vendor_list.aspx?a=return'\"");
		    smarty.Add("back_button",true);
	    }
	    else
	    {
		    formname = "editform" + (string)Request["id"];
		    body["begin"]= "<form name=\"editform" + (string)Request["id"] + "\" encType=\"multipart/form-data\" method=\"post\" action=\"Tb_Vendor_add.aspx\" " + onsubmit + " target=\"flyframe" + (string)Request["id"] + "\">" +
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
	            includes.Append("var SUGGEST_TABLE='Tb_Vendor_searchsuggest.aspx';\r\n");
	        }
	        if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
	        {
		        includes.Append("</script>\r\n");
		        if (useAJAX)
			        includes.Append("<div id=\"search_suggest\"></div>\r\n");
	        }


            


            smarty.Add("NAMA_fieldblock",true);
            smarty.Add("ALAMAT_fieldblock",true);
            smarty.Add("NPWP_fieldblock",true);
            smarty.Add("TELEPON_fieldblock",true);
            smarty.Add("FAX_fieldblock",true);
            smarty.Add("EMAIL_fieldblock",true);
            smarty.Add("STATUS_fieldblock",true);
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
	        templatefile = "Tb_Vendor_inline_add.aspx";
        }
        else
        {
	        templatefile = "Tb_Vendor_add.aspx";
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

