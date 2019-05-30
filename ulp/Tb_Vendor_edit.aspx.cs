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
#endregion

public partial class CTb_Vendor_Edit : AspNetRunnerPage 
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
            item = new Data.Tb_Vendor();
        }

        Data.Tb_Vendor emptyItem = new Data.Tb_Vendor();

                //	processing NAMA - start
                        if(!string.IsNullOrEmpty(Request["value_NAMA"]))
        {
                                                item.NAMA = Convert.ToString(Request["value_NAMA"]);

                    }
        else
        {
            item.NAMA = emptyItem.NAMA;
        }
        //	processing ALAMAT - start
                        if(!string.IsNullOrEmpty(Request["value_ALAMAT"]))
        {
                                                item.ALAMAT = Convert.ToString(Request["value_ALAMAT"]);

                    }
        else
        {
            item.ALAMAT = emptyItem.ALAMAT;
        }
        //	processing NPWP - start
                        if(!string.IsNullOrEmpty(Request["value_NPWP"]))
        {
                                                item.NPWP = Convert.ToString(Request["value_NPWP"]);

                    }
        else
        {
            item.NPWP = emptyItem.NPWP;
        }
        //	processing TELEPON - start
                        if(!string.IsNullOrEmpty(Request["value_TELEPON"]))
        {
                                                item.TELEPON = Convert.ToString(Request["value_TELEPON"]);

                    }
        else
        {
            item.TELEPON = emptyItem.TELEPON;
        }
        //	processing FAX - start
                        if(!string.IsNullOrEmpty(Request["value_FAX"]))
        {
                                                item.FAX = Convert.ToString(Request["value_FAX"]);

                    }
        else
        {
            item.FAX = emptyItem.FAX;
        }
        //	processing EMAIL - start
                        if(!string.IsNullOrEmpty(Request["value_EMAIL"]))
        {
                                                item.EMAIL = Convert.ToString(Request["value_EMAIL"]);

                    }
        else
        {
            item.EMAIL = emptyItem.EMAIL;
        }
        //	processing STATUS - start
                        if(!string.IsNullOrEmpty(Request["value_STATUS"]))
        {
                                                                                    string checkboxVal = (string)Request["value_STATUS"];
                        checkboxVal = checkboxVal.ToLower();
                        if(checkboxVal == "on")
                        {
                            item.STATUS = true;
                        }
                        else
                        {
                            item.STATUS = false;
                        }
                        

                    }
        else
        {
            item.STATUS = emptyItem.STATUS;
        }
        //
        //item.KD_VENDOR =  Convert.ToString(Request["editid1"]);
        //
        string idx = string.Empty;
        idx = "1";
                                               item.KD_VENDOR =  Convert.ToInt32(Request["editid" + idx]);
        bool abortSaving = false;
                if(!abortSaving)
        {
            item.MarkOld();
            item.Save();
            idx = "1";
                                   item.KD_VENDOR =  Convert.ToInt32(Request["editid" + idx]);
            ShowSuccessMessage();
                    }
    }

    private void BuildForm()
    {
        /////////////////////////////////////////////////////////////
        //	prepare Edit Controls
        /////////////////////////////////////////////////////////////

        string keylink="";
	    keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KD_VENDOR.ToString()));

        if(RequestAction == "edited" && inlineedit)
        {
            string masterquery = string.Empty;
	        masterquery="mastertable=dbo%2ETb%5FVendor";
	        masterquery += "&masterkey1=" + this.Server.UrlEncode(item.KD_VENDOR.ToString());
	        showDetailKeys["Tb_Kontrak"] = masterquery;
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KD_VENDOR.ToString()));

            string value="";

            Control control_NAMA = new Control("NAMA", item.NAMA, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	NAMA - 
		         value="";
		                                value = control_NAMA.GetData();
			            value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("NAMA");
		        		        showRawValues.Add(string.Empty);
            Control control_ALAMAT = new Control("ALAMAT", item.ALAMAT, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	ALAMAT - 
		         value="";
		                                value = control_ALAMAT.GetData();
			            value = control_ALAMAT.ProcessLargeText(value,"field=ALAMAT" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("ALAMAT");
		        		        showRawValues.Add(string.Empty);
            Control control_NPWP = new Control("NPWP", item.NPWP, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	NPWP - 
		         value="";
		                                value = control_NPWP.GetData();
			            value = control_NPWP.ProcessLargeText(value,"field=NPWP" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("NPWP");
		        		        showRawValues.Add(string.Empty);
            Control control_TELEPON = new Control("TELEPON", item.TELEPON, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	TELEPON - 
		         value="";
		                                value = control_TELEPON.GetData();
			            value = control_TELEPON.ProcessLargeText(value,"field=TELEPON" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("TELEPON");
		        		        showRawValues.Add(string.Empty);
            Control control_FAX = new Control("FAX", item.FAX, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	FAX - 
		         value="";
		                                value = control_FAX.GetData();
			            value = control_FAX.ProcessLargeText(value,"field=FAX" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("FAX");
		        		        showRawValues.Add(string.Empty);
            Control control_EMAIL = new Control("EMAIL", item.EMAIL, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	EMAIL - 
		         value="";
		                                value = control_EMAIL.GetData();
			            value = control_EMAIL.ProcessLargeText(value,"field=EMAIL" + keylink,"",MODE.MODE_LIST);
		        showValues.Add(value);
		        showFields.Add("EMAIL");
		        		        showRawValues.Add(string.Empty);
            Control control_STATUS = new Control("STATUS", item.STATUS, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        ////////////////////////////////////////////
	        //	STATUS - Checkbox
		         value="";
		        			            value = control_STATUS.GetData();
		        showValues.Add(value);
		        showFields.Add("STATUS");
		        		        showRawValues.Add(string.Empty);
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
            Control control_NAMA = null;
            if(defvalues.ContainsKey("NAMA"))
            {
                control_NAMA = new Control("NAMA", defvalues["NAMA"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_NAMA = new Control("NAMA", item.NAMA, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("NAMA_editcontrol",control_NAMA.BuildEditControl());
            Control control_ALAMAT = null;
            if(defvalues.ContainsKey("ALAMAT"))
            {
                control_ALAMAT = new Control("ALAMAT", defvalues["ALAMAT"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_ALAMAT = new Control("ALAMAT", item.ALAMAT, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("ALAMAT_editcontrol",control_ALAMAT.BuildEditControl());
            Control control_NPWP = null;
            if(defvalues.ContainsKey("NPWP"))
            {
                control_NPWP = new Control("NPWP", defvalues["NPWP"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_NPWP = new Control("NPWP", item.NPWP, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("NPWP_editcontrol",control_NPWP.BuildEditControl());
            Control control_TELEPON = null;
            if(defvalues.ContainsKey("TELEPON"))
            {
                control_TELEPON = new Control("TELEPON", defvalues["TELEPON"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_TELEPON = new Control("TELEPON", item.TELEPON, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("TELEPON_editcontrol",control_TELEPON.BuildEditControl());
            Control control_FAX = null;
            if(defvalues.ContainsKey("FAX"))
            {
                control_FAX = new Control("FAX", defvalues["FAX"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_FAX = new Control("FAX", item.FAX, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("FAX_editcontrol",control_FAX.BuildEditControl());
            Control control_EMAIL = null;
            if(defvalues.ContainsKey("EMAIL"))
            {
                control_EMAIL = new Control("EMAIL", defvalues["EMAIL"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_EMAIL = new Control("EMAIL", item.EMAIL, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("EMAIL_editcontrol",control_EMAIL.BuildEditControl());
            Control control_STATUS = null;
            if(defvalues.ContainsKey("STATUS"))
            {
                control_STATUS = new Control("STATUS", defvalues["STATUS"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_STATUS = new Control("STATUS", item.STATUS, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("STATUS_editcontrol",control_STATUS.BuildEditControl());
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
		"<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"Tb_Vendor_edit.aspx\" " + onsubmit + ">" +
		"<input type=hidden name=\"a\" value=\"edited\">";
        Control control_KD_VENDOR = new Control("KD_VENDOR", item.KD_VENDOR, false, smarty, this.Request, builder, MODE.MODE_LIST);
        body["begin"] +="<input type=\"hidden\" name=\"editid1\" value=\""+ Control.HTMLEncodeSpecialChars(keys["KD_VENDOR"].ToString()) + "\">";
	    	    smarty.Add("show_key1", Control.HTMLEncodeSpecialChars(control_KD_VENDOR.GetData()));

        smarty.Add("backbutton_attrs","onclick=\"window.location.href='Tb_Vendor_list.aspx?a=return'\"");
	    smarty.Add("save_button",true);
	    smarty.Add("reset_button",true);
	    smarty.Add("back_button",true);
	    
        showKeys.Add(Server.UrlEncode(keys["KD_VENDOR"].ToString()));
    }

    private string GetIncludes()
    {
        StringBuilder includes = new StringBuilder();
        if ( !inlineedit ) 
        {
            string validatetype = string.Empty;

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
	            includes.Append("var SUGGEST_TABLE='Tb_Vendor_searchsuggest.aspx';\r\n");
	        }
	        includes.Append("</script>\r\n");
	        if (useAJAX)
		        includes.Append("<div id=\"search_suggest\"></div>\r\n");


            


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

    private bool Init()
    {
        inlineedit = ((string)Request["editType"] == "inline");
        record_id = (string)Request["recordID"] ;
        if(inlineedit)
        {
	        templatefile = "Tb_Vendor_inline_edit.aspx";
        }
        else
        {
	        templatefile = "Tb_Vendor_edit.aspx";
        }

        keys["KD_VENDOR"] = Request["editid1"];
        if(keys.Count > 1)
        {
            item = controller.FetchByManyID(keys);
        }
        else
        {
            item = Data.Tb_Vendor.FetchByID(Request["editid1"]);
        }

        if(item != null)
        {
            	            bool editable=true;
            if(!editable)
            {
                output.Append("<p>" + "You don't have permissions to access this table" + " <a href=\"Tb_Vendor_list.aspx?a=return\">back</a>");
                return false;
            }
        }
        else
        {
            this.Server.Transfer("~/Tb_Vendor_list.aspx?a=return");
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

