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
using Data;
#endregion

public partial class CASSIGNMENT_Search : AspNetRunnerPage
{
    int mypage = 1;
    int id = 1;
    string key;
    string templatefile = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.ASSIGNMENT";
        strTableNameLocale = "dbo_ASSIGNMENT";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            // mandatory entry so compiler knows what table is processing
                        CheckSecurity();
            BuildForm();
            BuildBody();
            output.Append(func.BuildOutput(this, @"~\ASSIGNMENT_search.aspx", smarty));

            this.Response.Write(output.ToString());
            this.Response.End();
    }

    private string GetIncludes()
    {
        StringBuilder includes = new StringBuilder();
		includes.Append("<script language=\"JavaScript\" src=\"include/calendar.js\"></script>\r\n");
        includes.Append("<script language=\"JavaScript\" src=\"include/jsfunctions.js\"></script>\r\n");
        includes.Append("<script language=\"JavaScript\" src=\"include/jquery.js\"></script>\r\n");
        if (useAJAX) 
        {
            includes.Append("<script language=\"JavaScript\" src=\"include/onthefly.js\"></script>\r\n");
            includes.Append("<script language=\"JavaScript\" src=\"include/ajaxsuggest.js\"></script>\r\n");
        }
        includes.Append("<script language=\"JavaScript\" type=\"text/javascript\">\r\n");
        includes.Append("var locale_dateformat = '" + Control.locale_info("LOCALE_IDATE", smarty) + "';\r\n");
        includes.Append("var locale_datedelimiter = \"" + Control.locale_info("LOCALE_SDATE", smarty) + "\";\r\n");
        includes.Append("var bLoading=false;\r\n");
        includes.Append("var TEXT_PLEASE_SELECT='" + Control.AddSlashes("Please select") + "';\r\n");
        if (useAJAX) 
        {
            includes.Append("var SUGGEST_TABLE = \"ASSIGNMENT_searchsuggest.aspx\";\r\n");
        }
	    includes.Append("var detect = navigator.userAgent.toLowerCase();");
        includes.Append("function checkIt(string)");
        includes.Append("{");
	    includes.Append("place = detect.indexOf(string) + 1;");
	    includes.Append("thestring = string;");
	    includes.Append("return place;");
        includes.Append("}");
        includes.Append("function ShowHideControls()");
        includes.Append("{");
	    includes.Append("document.getElementById('second_NIP').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NIP'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_KODEPBJ').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODEPBJ'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("return false;");
        includes.Append("}");
        includes.Append("function ResetControls()");
        includes.Append("{");
	    includes.Append("var i;");
	    includes.Append("e = document.forms[0].elements; ");
	    includes.Append("for (i=0;i<e.length;i++)"); 
	    includes.Append("{");
		includes.Append("if (e[i].name!='type' && e[i].className!='button' && e[i].type!='hidden')");
		includes.Append("{");
		includes.Append("if(e[i].type=='select-one')");
		includes.Append("e[i].selectedIndex=0;");
	    includes.Append("else if(e[i].type=='select-multiple')");
		includes.Append("{");
		includes.Append("var j;");
		includes.Append("for(j=0;j<e[i].options.length;j++)");
		includes.Append("e[i].options[j].selected=false;");
		includes.Append("}");
		includes.Append("else if(e[i].type=='checkbox' || e[i].type=='radio')");
		includes.Append("e[i].checked=false;");
	    includes.Append("else ");
		includes.Append("e[i].value = ''; ");
		includes.Append("}");
		includes.Append("else if(e[i].name.substr(0,6)=='value_' && e[i].type=='hidden')");
		includes.Append("e[i].value = ''; ");
	    includes.Append("}");
	    includes.Append("ShowHideControls();	");
	    includes.Append("return false;");
        includes.Append("}");

                includes.Append("function OnKeyDown(e)");
        includes.Append("{ if(!e) e = window.event; ");
        includes.Append("if (e.keyCode == 13){ e.cancel = true; document.forms[0].submit();} }");
        includes.Append("</script>");

        return includes.ToString();
    }

    protected void BuildForm()
    {
        string all_checkbox="value=\"and\"";
        string any_checkbox="value=\"or\"";

        if(Asearchtype == "or")
        {
	        any_checkbox +=" checked";
        }
        else
        {
	        all_checkbox +=" checked";
        }
        smarty.Add("any_checkbox",any_checkbox);
        smarty.Add("all_checkbox",all_checkbox);

        IDictionary<string, string> editformats = new Dictionary<string, string>();
        string opt = "";
        bool not = false;
        string value = string.Empty;
        StringBuilder options = new StringBuilder();
        string searchtype = string.Empty;

        // NIP 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["NIP"];
	        not = Asearchnot["NIP"];
	        value = Asearchfor["NIP"];
        }

        Control control_NIP = null;
        Control control1_NIP = null;

        control_NIP = new Control("NIP", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_NIP.FieldInfo);

        smarty.Add("NIP_editcontrol", control_NIP.BuildEditControl());
        control1_NIP = new Control("NIP", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_NIP.FieldInfo);
        smarty.Add("NIP_editcontrol1", control1_NIP.BuildEditControl());

        IDictionary<string, string> NIP_fieldblock = new Dictionary<string, string>();
	    NIP_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"NIP\">";
	    NIP_fieldblock["end"]=string.Empty;
	    smarty.Add("NIP_fieldblock", NIP_fieldblock);

        string NIP_notbox="name=\"not_NIP\"";
        if(not)
        {
	        NIP_notbox +=" checked";
        }
        smarty.Add("NIP_notbox",NIP_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_NIP\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_NIP", searchtype);
        //	edit format
                editformats["NIP"] = "Lookup wizard";
        // KODEPBJ 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODEPBJ"];
	        not = Asearchnot["KODEPBJ"];
	        value = Asearchfor["KODEPBJ"];
        }

        Control control_KODEPBJ = null;
        Control control1_KODEPBJ = null;

        control_KODEPBJ = new Control("KODEPBJ", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_KODEPBJ.FieldInfo);

        smarty.Add("KODEPBJ_editcontrol", control_KODEPBJ.BuildEditControl());
        control1_KODEPBJ = new Control("KODEPBJ", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_KODEPBJ.FieldInfo);
        smarty.Add("KODEPBJ_editcontrol1", control1_KODEPBJ.BuildEditControl());

        IDictionary<string, string> KODEPBJ_fieldblock = new Dictionary<string, string>();
	    KODEPBJ_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODEPBJ\">";
	    KODEPBJ_fieldblock["end"]=string.Empty;
	    smarty.Add("KODEPBJ_fieldblock", KODEPBJ_fieldblock);

        string KODEPBJ_notbox="name=\"not_KODEPBJ\"";
        if(not)
        {
	        KODEPBJ_notbox +=" checked";
        }
        smarty.Add("KODEPBJ_notbox",KODEPBJ_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODEPBJ\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODEPBJ", searchtype);
        //	edit format
                editformats["KODEPBJ"] = "Lookup wizard";
    }

    protected void BuildBody()
    {
        string linkdata="";

        linkdata += "<script type=\"text/javascript\">\r\n";
        object value = null;
        if(Asearchfor.ContainsKey(""))
        {
            value = Asearchfor[""] ;
        }
        object fvalue = null;
        if(Asearchfor.ContainsKey("NIP"))
        {
            fvalue = Asearchfor["NIP"];
        }

        if (useAJAX) 
        {
            Smarty.Table tableInfo = null;
            Smarty.Field fieldInfo = null;
            List<Smarty.LookupField> lookups = null;
            string txt = ""; 

        }
        else
        {
        }
        linkdata += "</script>\r\n";


        IDictionary<string, object> body = new Dictionary<string, object>();
        body["begin"] = GetIncludes();
        body["end"] = linkdata + "<script>ShowHideControls()</script>";
        smarty.Add("body", body);

        IDictionary<string, object> contents_block = new Dictionary<string, object>();
        contents_block["begin"]="<form method=\"POST\"";
                contents_block["begin"] += "action=\"ASSIGNMENT_list.aspx\"" ;
        contents_block["begin"] += "name=\"editform\"><input type=\"hidden\" id=\"a\" name=\"a\" value=\"advsearch\">";
        contents_block["end"] ="</form>";
        smarty.Add("contents_block",contents_block);

        smarty.Add("searchbutton_attrs","name=\"SearchButton\" onclick=\"javascript:document.forms.editform.submit();\"");
        smarty.Add("resetbutton_attrs","onclick=\"return ResetControls();\"");
        smarty.Add("backbutton_attrs","onclick=\"javascript: document.forms.editform.a.value='return'; document.forms.editform.submit();\"");
        smarty.Add("conditions_block",true);
        smarty.Add("search_button",true);
        smarty.Add("reset_button",true);
        smarty.Add("back_button",true);
    }

        private bool CheckSecurity()
    {
        if(string.IsNullOrEmpty(UserName))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
	        return false;
        }
                if(!BaseCheckSecurity(OwnerID, "Search"))
        {
                }
        return true;
    }

    private string Asearchtype
    {
        get
        {
            return (string)SessionPropertyGet("type", string.Empty);
        }
        set
        {
            SessionPropertySet("type", value);
        }
    }
    
    private int Search
    {
        get
        {
            return (int)SessionPropertyGet(strTableName + "_search", -1);
        }
        set
        {
            SessionPropertySet(strTableName + "_search", value);
        }
    }

    private IDictionary<string, string> Asearchopt
    {
        get
        {
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchopt", new Dictionary<string, string>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchopt", value);
        }
    }

    private IDictionary<string, bool> Asearchnot
    {
        get
        {
            return (IDictionary<string, bool>)SessionPropertyGet(strTableName + "_asearchnot", new Dictionary<string, bool>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchnot", value);
        }
    }

    private IDictionary<string, string> Asearchfor
    {
        get
        {
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchfor", new Dictionary<string, string>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfor", value);
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
