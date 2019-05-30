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
using System.Data.SqlClient;
#endregion

public partial class CKELENGKAPANPBJ_Edit : AspNetRunnerPage 
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
    
    Data.KELENGKAPANPBJController controller = new Data.KELENGKAPANPBJController();
    Data.KELENGKAPANPBJ item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.KELENGKAPANPBJ";
        strTableNameLocale = "dbo_KELENGKAPANPBJ";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
                CheckSecurity();
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
		string sOleh = "";
		DateTime tgTerima =  new DateTime(1970, 1, 1, 0, 0, 0, 1);
		
        if (RequestAction != "edited")
        {
            item = new Data.KELENGKAPANPBJ();
        }

        Data.KELENGKAPANPBJ emptyItem = new Data.KELENGKAPANPBJ();

                //	processing TANGGALDITERIMA - start
                        if(!string.IsNullOrEmpty(Request["value_TANGGALDITERIMA"]))
        {
                                                item.TANGGALDITERIMA = Convert.ToDateTime(Request["value_TANGGALDITERIMA"]);

                    }
        else
        {
            item.TANGGALDITERIMA = emptyItem.TANGGALDITERIMA;
        }
		tgTerima = Convert.ToDateTime(item.TANGGALDITERIMA);
		
        //	processing PENERIMAKELENGKAPAN - start
                        if(!string.IsNullOrEmpty(Request["value_PENERIMAKELENGKAPAN"]))
        {
                                                item.PENERIMAKELENGKAPAN = Convert.ToString(Request["value_PENERIMAKELENGKAPAN"]);

                    }
        else
        {
            item.PENERIMAKELENGKAPAN = emptyItem.PENERIMAKELENGKAPAN;
        }
		sOleh = Convert.ToString(item.PENERIMAKELENGKAPAN);
        
        //
        //item.KODEBPJ =  Convert.ToString(Request["editid1"]);
        //
        //item.KODEKELENGKAPAN =  Convert.ToString(Request["editid2"]);
        //
        string idx = string.Empty;
		string sKodeBPJ = "";
		string sKodeLkp = "";
		
        idx = "1";
                                               item.KODEBPJ =  Convert.ToString(Request["editid" + idx]);
        idx = "2";
                                               item.KODEKELENGKAPAN =  Convert.ToString(Request["editid" + idx]);
        bool abortSaving = false;
                if(!abortSaving)
        {
            item.MarkOld();
            //item.Save();
            idx = "1";
                                   item.KODEBPJ =  Convert.ToString(Request["editid" + idx]);
								   sKodeBPJ = Convert.ToString(item.KODEBPJ);
            idx = "2";
                                   item.KODEKELENGKAPAN =  Convert.ToString(Request["editid" + idx]);
								   sKodeLkp = Convert.ToString(item.KODEKELENGKAPAN);
			Response.Redirect("ubah_kelengkapanpbj.aspx?pbj="+sKodeBPJ+"&lkp="+sKodeLkp+"&tgl="+String.Format("{0:yyyy-MM-dd}", tgTerima)+"&oleh="+sOleh);
            ShowSuccessMessage();
                    }
    }

    private void BuildForm()
    {
        /////////////////////////////////////////////////////////////
        //	prepare Edit Controls
        /////////////////////////////////////////////////////////////

        string keylink="";
	    keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEBPJ.ToString()));
	    keylink +="&key2=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEKELENGKAPAN.ToString()));

        if(RequestAction == "edited" && inlineedit)
        {
            string masterquery = string.Empty;
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEBPJ.ToString()));
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEKELENGKAPAN.ToString()));

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
            Control control_KODEBPJ = null;
            if(defvalues.ContainsKey("KODEBPJ"))
            {
                control_KODEBPJ = new Control("KODEBPJ", defvalues["KODEBPJ"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_KODEBPJ = new Control("KODEBPJ", item.KODEBPJ, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_KODEBPJ.FieldInfo);
            smarty.Add("KODEBPJ_editcontrol",control_KODEBPJ.BuildEditControl());
            Control control_KODEKELENGKAPAN = null;
            if(defvalues.ContainsKey("KODEKELENGKAPAN"))
            {
                control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", defvalues["KODEKELENGKAPAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", item.KODEKELENGKAPAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_KODEKELENGKAPAN.FieldInfo);
            smarty.Add("KODEKELENGKAPAN_editcontrol",control_KODEKELENGKAPAN.BuildEditControl());
            Control control_TANGGALDITERIMA = null;
            if(defvalues.ContainsKey("TANGGALDITERIMA"))
            {
                control_TANGGALDITERIMA = new Control("TANGGALDITERIMA", defvalues["TANGGALDITERIMA"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_TANGGALDITERIMA = new Control("TANGGALDITERIMA", item.TANGGALDITERIMA, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("TANGGALDITERIMA_editcontrol",control_TANGGALDITERIMA.BuildEditControl());
            Control control_PENERIMAKELENGKAPAN = null;
            if(defvalues.ContainsKey("PENERIMAKELENGKAPAN"))
            {
                control_PENERIMAKELENGKAPAN = new Control("PENERIMAKELENGKAPAN", defvalues["PENERIMAKELENGKAPAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PENERIMAKELENGKAPAN = new Control("PENERIMAKELENGKAPAN", item.PENERIMAKELENGKAPAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PENERIMAKELENGKAPAN_editcontrol",control_PENERIMAKELENGKAPAN.BuildEditControl());
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
		"<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"KELENGKAPANPBJ_edit.aspx\" " + onsubmit + ">" +
		"<input type=hidden name=\"a\" value=\"edited\">";
        Control control_KODEBPJ = new Control("KODEBPJ", item.KODEBPJ, false, smarty, this.Request, builder, MODE.MODE_LIST);
        body["begin"] +="<input type=\"hidden\" name=\"editid1\" value=\""+ Control.HTMLEncodeSpecialChars(keys["KODEBPJ"].ToString()) + "\">";
	    	    smarty.Add("show_key1", Control.HTMLEncodeSpecialChars(control_KODEBPJ.GetData()));
        Control control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", item.KODEKELENGKAPAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
        body["begin"] +="<input type=\"hidden\" name=\"editid2\" value=\""+ Control.HTMLEncodeSpecialChars(keys["KODEKELENGKAPAN"].ToString()) + "\">";
	    	    smarty.Add("show_key2", Control.HTMLEncodeSpecialChars(control_KODEKELENGKAPAN.GetData()));

        smarty.Add("backbutton_attrs","onclick=\"window.location.href='KELENGKAPANPBJ_list.aspx?a=return'\"");
	    smarty.Add("save_button",true);
	    smarty.Add("reset_button",true);
	    smarty.Add("back_button",true);
	    
        showKeys.Add(Server.UrlEncode(keys["KODEBPJ"].ToString()));
        showKeys.Add(Server.UrlEncode(keys["KODEKELENGKAPAN"].ToString()));
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

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_KODEBPJ','" + validatetype + "','KODE BPJ');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_KODEKELENGKAPAN','" + validatetype + "','KODE KELENGKAPAN');";
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
	            includes.Append("var SUGGEST_TABLE='KELENGKAPANPBJ_searchsuggest.aspx';\r\n");
	        }
	        includes.Append("</script>\r\n");
	        if (useAJAX)
		        includes.Append("<div id=\"search_suggest\"></div>\r\n");

	        	        //	include datepicker files
	        includes.Append("<script language=\"JavaScript\" src=\"include/calendar.js\"></script>\r\n");

            


	        smarty.Add("KODEBPJ_fieldblock",true);
	        smarty.Add("KODEKELENGKAPAN_fieldblock",true);
	        smarty.Add("TANGGALDITERIMA_fieldblock",true);
	        smarty.Add("PENERIMAKELENGKAPAN_fieldblock",true);
        }

        return includes.ToString();
    }

    private bool Init()
    {
        inlineedit = ((string)Request["editType"] == "inline");
        record_id = (string)Request["recordID"] ;
        if(inlineedit)
        {
	        templatefile = "KELENGKAPANPBJ_inline_edit.aspx";
        }
        else
        {
	        templatefile = "KELENGKAPANPBJ_edit.aspx";
        }

        keys["KODEBPJ"] = Request["editid1"];
        keys["KODEKELENGKAPAN"] = Request["editid2"];
        if(keys.Count > 1)
        {
            item = controller.FetchByManyID(keys);
        }
        else
        {
            item = Data.KELENGKAPANPBJ.FetchByID(Request["editid1"]);
        }

        if(item != null)
        {
            	            bool editable=true;
            if(!editable)
            {
                output.Append("<p>" + "You don't have permissions to access this table" + " <a href=\"KELENGKAPANPBJ_list.aspx?a=return\">back</a>");
                return false;
            }
        }
        else
        {
            this.Server.Transfer("~/KELENGKAPANPBJ_list.aspx?a=return");
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

