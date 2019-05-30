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

public partial class CKELENGKAPAN_Search : AspNetRunnerPage
{
    int mypage = 1;
    int id = 1;
    string key;
    string templatefile = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.KELENGKAPAN";
        strTableNameLocale = "dbo_KELENGKAPAN";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            // mandatory entry so compiler knows what table is processing
                        CheckSecurity();
            BuildForm();
            BuildBody();
            output.Append(func.BuildOutput(this, @"~\KELENGKAPAN_search.aspx", smarty));

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
            includes.Append("var SUGGEST_TABLE = \"KELENGKAPAN_searchsuggest.aspx\";\r\n");
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
	    includes.Append("document.getElementById('second_KODEKELENGKAPAN').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODEKELENGKAPAN'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_KODEDOKUMEN').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODEDOKUMEN'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_KODEJENISKEGIATAN').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODEJENISKEGIATAN'].value==\"Between\" ? '' : 'none'; ");
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

        // KODEKELENGKAPAN 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODEKELENGKAPAN"];
	        not = Asearchnot["KODEKELENGKAPAN"];
	        value = Asearchfor["KODEKELENGKAPAN"];
        }

        Control control_KODEKELENGKAPAN = null;
        Control control1_KODEKELENGKAPAN = null;

        control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("KODEKELENGKAPAN_editcontrol", control_KODEKELENGKAPAN.BuildEditControl());
        control1_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("KODEKELENGKAPAN_editcontrol1", control1_KODEKELENGKAPAN.BuildEditControl());

        IDictionary<string, string> KODEKELENGKAPAN_fieldblock = new Dictionary<string, string>();
	    KODEKELENGKAPAN_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODEKELENGKAPAN\">";
	    KODEKELENGKAPAN_fieldblock["end"]=string.Empty;
	    smarty.Add("KODEKELENGKAPAN_fieldblock", KODEKELENGKAPAN_fieldblock);

        string KODEKELENGKAPAN_notbox="name=\"not_KODEKELENGKAPAN\"";
        if(not)
        {
	        KODEKELENGKAPAN_notbox +=" checked";
        }
        smarty.Add("KODEKELENGKAPAN_notbox",KODEKELENGKAPAN_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Contains\" " + ((opt=="Contains")?"selected":"") + ">" + "Contains" + "</option>");
        options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        options.Append("<OPTION VALUE=\"Starts with ...\" " + ((opt=="Starts with ...")?"selected":"") + ">" + "Starts with ..." + "</option>");
        options.Append("<OPTION VALUE=\"More than ...\" " + ((opt=="More than ...")?"selected":"") + ">" + "More than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Less than ...\" " + ((opt=="Less than ...")?"selected":"") + ">" + "Less than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Equal or more than ...\" " + ((opt=="Equal or more than ...")?"selected":"") + ">" + "Equal or more than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Equal or less than ...\" " + ((opt=="Equal or less than ...")?"selected":"") + ">" + "Equal or less than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Between\" " + ((opt=="Between")?"selected":"") + ">" + "Between" + "</option>");
        options.Append("<OPTION VALUE=\"Empty\" " + ((opt=="Empty")?"selected":"") + ">" + "Empty" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODEKELENGKAPAN\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODEKELENGKAPAN", searchtype);
        //	edit format
                editformats["KODEKELENGKAPAN"] = "Text field";
        // KODEDOKUMEN 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODEDOKUMEN"];
	        not = Asearchnot["KODEDOKUMEN"];
	        value = Asearchfor["KODEDOKUMEN"];
        }

        Control control_KODEDOKUMEN = null;
        Control control1_KODEDOKUMEN = null;

        control_KODEDOKUMEN = new Control("KODEDOKUMEN", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_KODEDOKUMEN.FieldInfo);

        smarty.Add("KODEDOKUMEN_editcontrol", control_KODEDOKUMEN.BuildEditControl());
        control1_KODEDOKUMEN = new Control("KODEDOKUMEN", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_KODEDOKUMEN.FieldInfo);
        smarty.Add("KODEDOKUMEN_editcontrol1", control1_KODEDOKUMEN.BuildEditControl());

        IDictionary<string, string> KODEDOKUMEN_fieldblock = new Dictionary<string, string>();
	    KODEDOKUMEN_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODEDOKUMEN\">";
	    KODEDOKUMEN_fieldblock["end"]=string.Empty;
	    smarty.Add("KODEDOKUMEN_fieldblock", KODEDOKUMEN_fieldblock);

        string KODEDOKUMEN_notbox="name=\"not_KODEDOKUMEN\"";
        if(not)
        {
	        KODEDOKUMEN_notbox +=" checked";
        }
        smarty.Add("KODEDOKUMEN_notbox",KODEDOKUMEN_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODEDOKUMEN\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODEDOKUMEN", searchtype);
        //	edit format
                editformats["KODEDOKUMEN"] = "Lookup wizard";
        // KODEJENISKEGIATAN 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODEJENISKEGIATAN"];
	        not = Asearchnot["KODEJENISKEGIATAN"];
	        value = Asearchfor["KODEJENISKEGIATAN"];
        }

        Control control_KODEJENISKEGIATAN = null;
        Control control1_KODEJENISKEGIATAN = null;

        control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_KODEJENISKEGIATAN.FieldInfo);

        smarty.Add("KODEJENISKEGIATAN_editcontrol", control_KODEJENISKEGIATAN.BuildEditControl());
        control1_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_KODEJENISKEGIATAN.FieldInfo);
        smarty.Add("KODEJENISKEGIATAN_editcontrol1", control1_KODEJENISKEGIATAN.BuildEditControl());

        IDictionary<string, string> KODEJENISKEGIATAN_fieldblock = new Dictionary<string, string>();
	    KODEJENISKEGIATAN_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODEJENISKEGIATAN\">";
	    KODEJENISKEGIATAN_fieldblock["end"]=string.Empty;
	    smarty.Add("KODEJENISKEGIATAN_fieldblock", KODEJENISKEGIATAN_fieldblock);

        string KODEJENISKEGIATAN_notbox="name=\"not_KODEJENISKEGIATAN\"";
        if(not)
        {
	        KODEJENISKEGIATAN_notbox +=" checked";
        }
        smarty.Add("KODEJENISKEGIATAN_notbox",KODEJENISKEGIATAN_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODEJENISKEGIATAN\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODEJENISKEGIATAN", searchtype);
        //	edit format
                editformats["KODEJENISKEGIATAN"] = "Lookup wizard";
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
                contents_block["begin"] += "action=\"KELENGKAPAN_list.aspx\"" ;
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
