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
#endregion

public partial class CPENGGUNA_Add : AspNetRunnerPage 
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
    
    Data.PENGGUNAController controller = new Data.PENGGUNAController();
    Data.PENGGUNA item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGGUNA";
        strTableNameLocale = "dbo_PENGGUNA";
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
        item = new Data.PENGGUNA();
                //	processing KODEPENGGUNA - start
                        if(!string.IsNullOrEmpty(Request["value_KODEPENGGUNA"]))
        {
                                                                                                item.KODEPENGGUNA = Convert.ToString(Request["value_KODEPENGGUNA"]);
                    }
                //	processing NAMA - start
                        if(!string.IsNullOrEmpty(Request["value_NAMA"]))
        {
                                                                                                item.NAMA = Convert.ToString(Request["value_NAMA"]);
                    }
                //	processing KATAKUNCI - start
                        if(!string.IsNullOrEmpty(Request["value_KATAKUNCI"]))
        {
                                                                                                item.KATAKUNCI = Convert.ToString(Request["value_KATAKUNCI"]);
                    }
                //	processing KODEKELOMPOK - start
                        if(!string.IsNullOrEmpty(Request["value_KODEKELOMPOK"]))
        {
                                                                                                item.KODEKELOMPOK = Convert.ToString(Request["value_KODEKELOMPOK"]);
                    }
                bool abortSaving = false;
        
        //      insert masterkey value if exists and if not specified
           if(Mastertable =="dbo.KELOMPOKPENGGUNA")
           {
                   if(string.IsNullOrEmpty(Request["value_KODEKELOMPOK"]))
                   {

                                           item.KODEKELOMPOK =  Convert.ToString(Session[strTableName + "_masterkey1"]);
                        }
           }

        if(!abortSaving)
        {
            item.Save();
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
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEPENGGUNA.ToString()));

	        string keylink="";
	        keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEPENGGUNA.ToString()));

            string value="";

            value="";
            Control control_KODEPENGGUNA = new Control("KODEPENGGUNA", item.KODEPENGGUNA, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODEPENGGUNA - 
		        
		                                value = control_KODEPENGGUNA.GetData();
			            value = control_KODEPENGGUNA.ProcessLargeText(value,"field=KODEPENGGUNA" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("KODEPENGGUNA");
		        		        showRawValues.Add(string.Empty);
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
            Control control_KATAKUNCI = new Control("KATAKUNCI", item.KATAKUNCI, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KATAKUNCI - 
		        
		                                value = control_KATAKUNCI.GetData();
			            value = control_KATAKUNCI.ProcessLargeText(value,"field=KATAKUNCI" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("KATAKUNCI");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_KODEKELOMPOK = new Control("KODEKELOMPOK", item.KODEKELOMPOK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODEKELOMPOK - 
		        
		                                func.PopulateLookupFields(control_KODEKELOMPOK.FieldInfo);
			            value=control_KODEKELOMPOK.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("KODEKELOMPOK");
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
                        detailkeys["KODETIPE"] = (string)this.Session[strTableName + "_masterkey1"];

            object KODEPENGGUNA_value = null;
            if(defvalues.ContainsKey("KODEPENGGUNA"))
            {
                KODEPENGGUNA_value = defvalues["KODEPENGGUNA"];
            }
            else if(isCopy)
            {
                KODEPENGGUNA_value = item.KODEPENGGUNA;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODEPENGGUNA = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODEPENGGUNA")))
            {
                edit_control_KODEPENGGUNA = new Control("KODEPENGGUNA", detailkeys["KODEPENGGUNA"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODEPENGGUNA = new Control("KODEPENGGUNA", KODEPENGGUNA_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("KODEPENGGUNA_editcontrol", edit_control_KODEPENGGUNA.BuildEditControl());
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
            object KATAKUNCI_value = null;
            if(defvalues.ContainsKey("KATAKUNCI"))
            {
                KATAKUNCI_value = defvalues["KATAKUNCI"];
            }
            else if(isCopy)
            {
                KATAKUNCI_value = item.KATAKUNCI;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KATAKUNCI = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KATAKUNCI")))
            {
                edit_control_KATAKUNCI = new Control("KATAKUNCI", detailkeys["KATAKUNCI"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KATAKUNCI = new Control("KATAKUNCI", KATAKUNCI_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("KATAKUNCI_editcontrol", edit_control_KATAKUNCI.BuildEditControl());
            object KODEKELOMPOK_value = null;
            if(defvalues.ContainsKey("KODEKELOMPOK"))
            {
                KODEKELOMPOK_value = defvalues["KODEKELOMPOK"];
            }
            else if(isCopy)
            {
                KODEKELOMPOK_value = item.KODEKELOMPOK;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODEKELOMPOK = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODEKELOMPOK")))
            {
                edit_control_KODEKELOMPOK = new Control("KODEKELOMPOK", detailkeys["KODEKELOMPOK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODEKELOMPOK = new Control("KODEKELOMPOK", KODEKELOMPOK_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_KODEKELOMPOK.FieldInfo);
                        smarty.Add("KODEKELOMPOK_editcontrol", edit_control_KODEKELOMPOK.BuildEditControl());
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
        if(defvalues.ContainsKey("NIP"))
        {
            fvalue = defvalues["NIP"];
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
                item = Data.PENGGUNA.FetchByID(Request["copyid1"]);
                isCopy = true;
	        }
	        else
	        {
                 item = Data.PENGGUNA.FetchByID(Request["editid1"]);
	        }

                        //	clear key fields
	            defvalues["KODEPENGGUNA"] = item.KODEPENGGUNA;
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
		    "<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"PENGGUNA_add.aspx\" " + onsubmit + ">" +
		    "<input type=hidden name=\"a\" value=\"added\">";
		    smarty.Add("backbutton_attrs","onclick=\"window.location.href='PENGGUNA_list.aspx?a=return'\"");
		    smarty.Add("back_button",true);
	    }
	    else
	    {
		    formname = "editform" + (string)Request["id"];
		    body["begin"]= "<form name=\"editform" + (string)Request["id"] + "\" encType=\"multipart/form-data\" method=\"post\" action=\"PENGGUNA_add.aspx\" " + onsubmit + " target=\"flyframe" + (string)Request["id"] + "\">" +
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
				        linkdata += "define_fly('value_KODEPENGGUNA_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODEPENGGUNA','" + validatetype + "','KODE PENGGUNA');";
                    }
		        }

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_NAMA_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_NAMA','" + validatetype + "','NAMA PENGGUNA');";
                    }
		        }

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KATAKUNCI_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KATAKUNCI','" + validatetype + "','KATA KUNCI');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KODEKELOMPOK_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODEKELOMPOK','" + validatetype + "','KELOMPOK PENGGUNA');";
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
	            includes.Append("var SUGGEST_TABLE='PENGGUNA_searchsuggest.aspx';\r\n");
	        }
	        if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
	        {
		        includes.Append("</script>\r\n");
		        if (useAJAX)
			        includes.Append("<div id=\"search_suggest\"></div>\r\n");
	        }


            


            smarty.Add("KODEPENGGUNA_fieldblock",true);
            smarty.Add("NAMA_fieldblock",true);
            smarty.Add("KATAKUNCI_fieldblock",true);
            smarty.Add("KODEKELOMPOK_fieldblock",true);
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
	        templatefile = "PENGGUNA_inline_add.aspx";
        }
        else
        {
	        templatefile = "PENGGUNA_add.aspx";
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

