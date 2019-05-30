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

public partial class CPENGADAAN_LANGSUNG_Edit : AspNetRunnerPage 
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
    
    Data.PENGADAAN_LANGSUNGController controller = new Data.PENGADAAN_LANGSUNGController();
    Data.PENGADAAN_LANGSUNG item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGADAAN_LANGSUNG";
        strTableNameLocale = "dbo_PENGADAAN_LANGSUNG";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
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
            item = new Data.PENGADAAN_LANGSUNG();
        }

        Data.PENGADAAN_LANGSUNG emptyItem = new Data.PENGADAAN_LANGSUNG();

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
        //	processing TANGGALKONTRAK - start
                        if(!string.IsNullOrEmpty(Request["value_TANGGALKONTRAK"]))
        {
                                                item.TANGGALKONTRAK = Convert.ToDateTime(Request["value_TANGGALKONTRAK"]);

                    }
        else
        {
            item.TANGGALKONTRAK = emptyItem.TANGGALKONTRAK;
        }
        //	processing PAGU - start
                        if(!string.IsNullOrEmpty(Request["value_PAGU"]))
        {
                                                item.PAGU = Convert.ToDecimal(Request["value_PAGU"]);

                    }
        else
        {
            item.PAGU = emptyItem.PAGU;
        }
        //	processing HPS - start
                        if(!string.IsNullOrEmpty(Request["value_HPS"]))
        {
                                                item.HPS = Convert.ToDecimal(Request["value_HPS"]);

                    }
        else
        {
            item.HPS = emptyItem.HPS;
        }
        //	processing NILAIKONTRAK - start
                        if(!string.IsNullOrEmpty(Request["value_NILAIKONTRAK"]))
        {
                                                item.NILAIKONTRAK = Convert.ToDecimal(Request["value_NILAIKONTRAK"]);

                    }
        else
        {
            item.NILAIKONTRAK = emptyItem.NILAIKONTRAK;
        }
        //	processing PEMENANG - start
                        if(!string.IsNullOrEmpty(Request["value_PEMENANG"]))
        {
                                                item.PEMENANG = Convert.ToString(Request["value_PEMENANG"]);

                    }
        else
        {
            item.PEMENANG = emptyItem.PEMENANG;
        }
        //	processing KETERANGAN - start
                        if(!string.IsNullOrEmpty(Request["value_KETERANGAN"]))
        {
                                                item.KETERANGAN = Convert.ToString(Request["value_KETERANGAN"]);

                    }
        else
        {
            item.KETERANGAN = emptyItem.KETERANGAN;
        }
        //	processing PEJABATPENGADAAN - start
        item.PEJABATPENGADAAN = UserName;

        //	processing MENGETAHUI - start
                        if(!string.IsNullOrEmpty(Request["value_MENGETAHUI"]))
        {
                                                item.MENGETAHUI = Convert.ToString(Request["value_MENGETAHUI"]);

                    }
        else
        {
            item.MENGETAHUI = emptyItem.MENGETAHUI;
        }
        //
        //item.KODEPENGADAANLANGSUNG =  Convert.ToString(Request["editid1"]);
        //
        string idx = string.Empty;
        idx = "1";
                                               item.KODEPENGADAANLANGSUNG =  Convert.ToString(Request["editid" + idx]);
        bool abortSaving = false;
        if(!abortSaving)
        {
            item.MarkOld();
            item.Save();
            idx = "1";
            item.KODEPENGADAANLANGSUNG =  Convert.ToString(Request["editid" + idx]);
			/*
			if (!string.IsNullOrEmpty(Request["value_PEJABATPENGADAAN"])) {
				// save jenis pengadaan
				SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
				string ssql = "update PENGADAAN_LANGSUNG set JENISPENGADAAN = '" + Convert.ToString(Request["value_PEJABATPENGADAAN"]) + "' where KODEPENGADAANLANGSUNG = '" + item.KODEPENGADAANLANGSUNG + "';";
				SqlCommand myCommand = new SqlCommand();
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
			}
			*/
            ShowSuccessMessage();
                    }
    }

    private void BuildForm()
    {
        /////////////////////////////////////////////////////////////
        //	prepare Edit Controls
        /////////////////////////////////////////////////////////////

        string keylink="";
	    keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODEPENGADAANLANGSUNG.ToString()));

        if(RequestAction == "edited" && inlineedit)
        {
            string masterquery = string.Empty;
        	
	        showKeys.Add(Control.HTMLEncodeSpecialChars(item.KODEPENGADAANLANGSUNG.ToString()));

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
            Control control_TANGGALKONTRAK = null;
            if(defvalues.ContainsKey("TANGGALKONTRAK"))
            {
                control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", defvalues["TANGGALKONTRAK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", item.TANGGALKONTRAK, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("TANGGALKONTRAK_editcontrol",control_TANGGALKONTRAK.BuildEditControl());
            Control control_PAGU = null;
            if(defvalues.ContainsKey("PAGU"))
            {
                control_PAGU = new Control("PAGU", defvalues["PAGU"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PAGU = new Control("PAGU", item.PAGU, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PAGU_editcontrol",control_PAGU.BuildEditControl());
            Control control_HPS = null;
            if(defvalues.ContainsKey("HPS"))
            {
                control_HPS = new Control("HPS", defvalues["HPS"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_HPS = new Control("HPS", item.HPS, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("HPS_editcontrol",control_HPS.BuildEditControl());
            Control control_NILAIKONTRAK = null;
            if(defvalues.ContainsKey("NILAIKONTRAK"))
            {
                control_NILAIKONTRAK = new Control("NILAIKONTRAK", defvalues["NILAIKONTRAK"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_NILAIKONTRAK = new Control("NILAIKONTRAK", item.NILAIKONTRAK, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("NILAIKONTRAK_editcontrol",control_NILAIKONTRAK.BuildEditControl());
            Control control_PEMENANG = null;
            if(defvalues.ContainsKey("PEMENANG"))
            {
                control_PEMENANG = new Control("PEMENANG", defvalues["PEMENANG"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PEMENANG = new Control("PEMENANG", item.PEMENANG, false, smarty, this.Request, builder, ctrlMode);
            }
                        smarty.Add("PEMENANG_editcontrol",control_PEMENANG.BuildEditControl());
            Control control_KETERANGAN = null;
            if(defvalues.ContainsKey("KETERANGAN"))
            {
                control_KETERANGAN = new Control("KETERANGAN", defvalues["KETERANGAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_KETERANGAN = new Control("KETERANGAN", item.KETERANGAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_KETERANGAN.FieldInfo);
            smarty.Add("KETERANGAN_editcontrol",control_KETERANGAN.BuildEditControl());
            Control control_PEJABATPENGADAAN = null;
            if(defvalues.ContainsKey("PEJABATPENGADAAN"))
            {
                control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", defvalues["PEJABATPENGADAAN"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", item.PEJABATPENGADAAN, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_PEJABATPENGADAAN.FieldInfo);
            smarty.Add("PEJABATPENGADAAN_editcontrol",control_PEJABATPENGADAAN.BuildEditControl());
            Control control_MENGETAHUI = null;
            if(defvalues.ContainsKey("MENGETAHUI"))
            {
                control_MENGETAHUI = new Control("MENGETAHUI", defvalues["MENGETAHUI"], false, smarty, this.Request, builder, ctrlMode);
            }
            else
            {
                control_MENGETAHUI = new Control("MENGETAHUI", item.MENGETAHUI, false, smarty, this.Request, builder, ctrlMode);
            }
                        func.PopulateLookupFields(control_MENGETAHUI.FieldInfo);
            smarty.Add("MENGETAHUI_editcontrol",control_MENGETAHUI.BuildEditControl());
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
		"<form name=\"editform\" encType=\"multipart/form-data\" method=\"post\" action=\"PENGADAAN_LANGSUNG_edit.aspx\" " + onsubmit + ">" +
		"<input type=hidden name=\"a\" value=\"edited\">";
        Control control_KODEPENGADAANLANGSUNG = new Control("KODEPENGADAANLANGSUNG", item.KODEPENGADAANLANGSUNG, false, smarty, this.Request, builder, MODE.MODE_LIST);
        body["begin"] +="<input type=\"hidden\" name=\"editid1\" value=\""+ Control.HTMLEncodeSpecialChars(keys["KODEPENGADAANLANGSUNG"].ToString()) + "\">";
	    	    smarty.Add("show_key1", Control.HTMLEncodeSpecialChars(control_KODEPENGADAANLANGSUNG.GetData()));

        smarty.Add("backbutton_attrs","onclick=\"window.location.href='PENGADAAN_LANGSUNG_list.aspx?a=return'\"");
	    smarty.Add("save_button",true);
	    smarty.Add("reset_button",true);
	    smarty.Add("back_button",true);
	    
        showKeys.Add(Server.UrlEncode(keys["KODEPENGADAANLANGSUNG"].ToString()));
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
			        bodyonload += "define('value_NAMAKEGIATAN','" + validatetype + "','NAMA KEGIATAN');";
		        }

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_NAMAPAKET','" + validatetype + "','NAMA PAKET');";
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
			        bodyonload += "define('value_TANGGALKONTRAK','" + validatetype + "','TANGGAL KONTRAK');";
		        }

            
            			        			            validatetype="IsNumeric";
		        		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_PAGU','" + validatetype + "','PAGU');";
		        }

            
            			        			            validatetype="IsNumeric";
		        		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_HPS','" + validatetype + "','HPS');";
		        }

            
            			        			            validatetype="IsNumeric";
		        		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_NILAIKONTRAK','" + validatetype + "','NILAI KONTRAK');";
		        }

            
            			        			            validatetype="";
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_PEMENANG','" + validatetype + "','PEMENANG');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_KETERANGAN','" + validatetype + "','JENIS KEGIATAN');";
		        }

            
            			        validatetype = string.Empty;
		        			        //validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_PEJABATPENGADAAN','" + validatetype + "','PEJABAT PENGADAAN');";
		        }

            
            			        validatetype = string.Empty;
		        			        validatetype += "IsRequired";
		        if(!string.IsNullOrEmpty(validatetype))
		        {
			        bodyonload += "define('value_MENGETAHUI','" + validatetype + "','MENGETAHUI');";
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
	            includes.Append("var SUGGEST_TABLE='PENGADAAN_LANGSUNG_searchsuggest.aspx';\r\n");
	        }
	        includes.Append("</script>\r\n");
	        if (useAJAX)
		        includes.Append("<div id=\"search_suggest\"></div>\r\n");

	        	        //	include datepicker files
	        includes.Append("<script language=\"JavaScript\" src=\"include/calendar.js\"></script>\r\n");

            


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

    private bool Init()
    {
        inlineedit = ((string)Request["editType"] == "inline");
        record_id = (string)Request["recordID"] ;
        if(inlineedit)
        {
	        templatefile = "PENGADAAN_LANGSUNG_inline_edit.aspx";
        }
        else
        {
	        templatefile = "PENGADAAN_LANGSUNG_edit.aspx";
        }

        keys["KODEPENGADAANLANGSUNG"] = Request["editid1"];
        if(keys.Count > 1)
        {
            item = controller.FetchByManyID(keys);
        }
        else
        {
            item = Data.PENGADAAN_LANGSUNG.FetchByID(Request["editid1"]);
        }

        if(item != null)
        {
            	            bool editable=true;
            if(!editable)
            {
                output.Append("<p>" + "You don't have permissions to access this table" + " <a href=\"PENGADAAN_LANGSUNG_list.aspx?a=return\">back</a>");
                return false;
            }
        }
        else
        {
            this.Server.Transfer("~/PENGADAAN_LANGSUNG_list.aspx?a=return");
        }

        return true;
    }


    }

