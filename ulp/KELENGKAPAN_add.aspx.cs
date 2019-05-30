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

public partial class CKELENGKAPAN_Add : AspNetRunnerPage 
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
    
    Data.KELENGKAPANController controller = new Data.KELENGKAPANController();
    Data.KELENGKAPAN item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.KELENGKAPAN";
        strTableNameLocale = "dbo_KELENGKAPAN";
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
        item = new Data.KELENGKAPAN();
                //	processing KODEKELENGKAPAN - start
                        if(!string.IsNullOrEmpty(Request["value_KODEKELENGKAPAN"]))
        {
                                                                                                item.KODEKELENGKAPAN = Convert.ToString(Request["value_KODEKELENGKAPAN"]);
                    }
                //	processing KODEDOKUMEN - start
                        if(!string.IsNullOrEmpty(Request["value_KODEDOKUMEN"]))
        {
                                                                                                item.KODEDOKUMEN = Convert.ToString(Request["value_KODEDOKUMEN"]);
                    }
                //	processing KODEJENISKEGIATAN - start
                        if(!string.IsNullOrEmpty(Request["value_KODEJENISKEGIATAN"]))
        {
                                                                                                item.KODEJENISKEGIATAN = Convert.ToString(Request["value_KODEJENISKEGIATAN"]);
                    }
                bool abortSaving = false;
        
        //      insert masterkey value if exists and if not specified
           if(Mastertable =="dbo.JENISKEGIATAN")
           {
                   if(string.IsNullOrEmpty(Request["value_KODEJENISKEGIATAN"]))
                   {

                                           item.KODEJENISKEGIATAN =  Convert.ToString(Session[strTableName + "_masterkey1"]);
                        }
           }
           if(Mastertable =="dbo.DOKUMEN")
           {
                   if(string.IsNullOrEmpty(Request["value_KODEDOKUMEN"]))
                   {

                                           item.KODEDOKUMEN =  Convert.ToString(Session[strTableName + "_masterkey1"]);
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
	        masterquery="mastertable=dbo%2EKELENGKAPAN";
	        masterquery += "&masterkey1=" + this.Server.UrlEncode(item.KODEKELENGKAPAN.ToString());
	        showDetailKeys["dbo.KELENGKAPANPBJ"] = masterquery;
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEKELENGKAPAN.ToString()));

	        string keylink="";
	        keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEKELENGKAPAN.ToString()));

            string value="";

            value="";
            Control control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", item.KODEKELENGKAPAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODEKELENGKAPAN - 
		        
		                                value = control_KODEKELENGKAPAN.GetData();
			            value = control_KODEKELENGKAPAN.ProcessLargeText(value,"field=KODEKELENGKAPAN" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("KODEKELENGKAPAN");
		        		        showRawValues.Add(string.Empty);
            value="";
            Control control_KODEDOKUMEN = new Control("KODEDOKUMEN", item.KODEDOKUMEN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	KODEDOKUMEN - 
		        
		                                func.PopulateLookupFields(control_KODEDOKUMEN.FieldInfo);
			            value=control_KODEDOKUMEN.DisplayLookupWizard();
		        showValues.Add(value);
		        showFields.Add("KODEDOKUMEN");
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

            object KODEKELENGKAPAN_value = null;
            if(defvalues.ContainsKey("KODEKELENGKAPAN"))
            {
                KODEKELENGKAPAN_value = defvalues["KODEKELENGKAPAN"];
            }
            else if(isCopy)
            {
                KODEKELENGKAPAN_value = item.KODEKELENGKAPAN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODEKELENGKAPAN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODEKELENGKAPAN")))
            {
                edit_control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", detailkeys["KODEKELENGKAPAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", KODEKELENGKAPAN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                                    smarty.Add("KODEKELENGKAPAN_editcontrol", edit_control_KODEKELENGKAPAN.BuildEditControl());
            object KODEDOKUMEN_value = null;
            if(defvalues.ContainsKey("KODEDOKUMEN"))
            {
                KODEDOKUMEN_value = defvalues["KODEDOKUMEN"];
            }
            else if(isCopy)
            {
                KODEDOKUMEN_value = item.KODEDOKUMEN;
            }
            if(inlineedit == ADD_MODE.ADD_INLINE)
            {
                ctrlMode = MODE.MODE_INLINE_ADD;
            }
            else
            {
                ctrlMode = MODE.MODE_ADD;
            }
            Control edit_control_KODEDOKUMEN = null;

            if(!string.IsNullOrEmpty(Mastertable) && (detailkeys.ContainsKey("KODEDOKUMEN")))
            {
                edit_control_KODEDOKUMEN = new Control("KODEDOKUMEN", detailkeys["KODEDOKUMEN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                                edit_control_KODEDOKUMEN = new Control("KODEDOKUMEN", KODEDOKUMEN_value, false, smarty, this.Request, builder, ctrlMode);
            }

                        func.PopulateLookupFields(edit_control_KODEDOKUMEN.FieldInfo);
                        smarty.Add("KODEDOKUMEN_editcontrol", edit_control_KODEDOKUMEN.BuildEditControl());
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
                item = Data.KELENGKAPAN.FetchByID(Request["copyid1"]);
                isCopy = true;
	        }
	        else
	        {
                 item = Data.KELENGKAPAN.FetchByID(Request["editid1"]);
	        }

                        //	clear key fields
	            defvalues["KODEKELENGKAPAN"] = item.KODEKELENGKAPAN;
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
		    "<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"KELENGKAPAN_add.aspx\" " + onsubmit + ">" +
		    "<input type=hidden name=\"a\" value=\"added\">";
		    smarty.Add("backbutton_attrs","onclick=\"window.location.href='KELENGKAPAN_list.aspx?a=return'\"");
		    smarty.Add("back_button",true);
	    }
	    else
	    {
		    formname = "editform" + (string)Request["id"];
		    body["begin"]= "<form name=\"editform" + (string)Request["id"] + "\" encType=\"multipart/form-data\" method=\"post\" action=\"KELENGKAPAN_add.aspx\" " + onsubmit + " target=\"flyframe" + (string)Request["id"] + "\">" +
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
				        linkdata += "define_fly('value_KODEKELENGKAPAN_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODEKELENGKAPAN','" + validatetype + "','KODE KELENGKAPAN');";
                    }
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        needvalidate = true;
			        if(inlineedit == ADD_MODE.ADD_ONTHEFLY)
                    {
				        linkdata += "define_fly('value_KODEDOKUMEN_" + (string)Request["id"] + "','" + validatetype + "');";
                    }
			        else
                    {
				        bodyonload += "define('value_KODEDOKUMEN','" + validatetype + "','DOKUMEN');";
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
	            includes.Append("var SUGGEST_TABLE='KELENGKAPAN_searchsuggest.aspx';\r\n");
	        }
	        if(inlineedit != ADD_MODE.ADD_ONTHEFLY)
	        {
		        includes.Append("</script>\r\n");
		        if (useAJAX)
			        includes.Append("<div id=\"search_suggest\"></div>\r\n");
	        }


            


            smarty.Add("KODEKELENGKAPAN_fieldblock",true);
            smarty.Add("KODEDOKUMEN_fieldblock",true);
            smarty.Add("KODEJENISKEGIATAN_fieldblock",true);
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
	        templatefile = "KELENGKAPAN_inline_add.aspx";
        }
        else
        {
	        templatefile = "KELENGKAPAN_add.aspx";
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

