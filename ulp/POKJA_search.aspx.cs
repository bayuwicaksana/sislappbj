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

public partial class CPOKJA_Search : AspNetRunnerPage
{
    int mypage = 1;
    int id = 1;
    string key;
    string templatefile = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.POKJA";
        strTableNameLocale = "dbo_POKJA";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            // mandatory entry so compiler knows what table is processing
                        BuildForm();
            BuildBody();
            output.Append(func.BuildOutput(this, @"~\POKJA_search.aspx", smarty));

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
            includes.Append("var SUGGEST_TABLE = \"POKJA_searchsuggest.aspx\";\r\n");
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
	    includes.Append("document.getElementById('second_KODEPOKJA').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODEPOKJA'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_NAMA').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NAMA'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_DESKRIPSSI').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_DESKRIPSSI'].value==\"Between\" ? '' : 'none'; ");
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

                includes.Append("$(document).ready(function() {");
	        includes.Append("document.forms.editform.value_KODEPOKJA.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_KODEPOKJA,'advanced')};");
	        includes.Append("document.forms.editform.value1_KODEPOKJA.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_KODEPOKJA,'advanced1')};");
	        includes.Append("document.forms.editform.value_KODEPOKJA.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_KODEPOKJA,'advanced')};");
	        includes.Append("document.forms.editform.value1_KODEPOKJA.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_KODEPOKJA,'advanced1')};");
	        includes.Append("document.forms.editform.value_NAMA.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_NAMA,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMA.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_NAMA,'advanced1')};");
	        includes.Append("document.forms.editform.value_NAMA.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_NAMA,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMA.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_NAMA,'advanced1')};");
	        includes.Append("document.forms.editform.value_DESKRIPSSI.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_DESKRIPSSI,'advanced')};");
	        includes.Append("document.forms.editform.value1_DESKRIPSSI.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_DESKRIPSSI,'advanced1')};");
	        includes.Append("document.forms.editform.value_DESKRIPSSI.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_DESKRIPSSI,'advanced')};");
	        includes.Append("document.forms.editform.value1_DESKRIPSSI.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_DESKRIPSSI,'advanced1')};");
        includes.Append("});");
        includes.Append("</script>");
        includes.Append("<div id=\"search_suggest\"></div>");

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

        // KODEPOKJA 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODEPOKJA"];
	        not = Asearchnot["KODEPOKJA"];
	        value = Asearchfor["KODEPOKJA"];
        }

        Control control_KODEPOKJA = null;
        Control control1_KODEPOKJA = null;

        control_KODEPOKJA = new Control("KODEPOKJA", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("KODEPOKJA_editcontrol", control_KODEPOKJA.BuildEditControl());
        control1_KODEPOKJA = new Control("KODEPOKJA", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("KODEPOKJA_editcontrol1", control1_KODEPOKJA.BuildEditControl());

        IDictionary<string, string> KODEPOKJA_fieldblock = new Dictionary<string, string>();
	    KODEPOKJA_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODEPOKJA\">";
	    KODEPOKJA_fieldblock["end"]=string.Empty;
	    smarty.Add("KODEPOKJA_fieldblock", KODEPOKJA_fieldblock);

        string KODEPOKJA_notbox="name=\"not_KODEPOKJA\"";
        if(not)
        {
	        KODEPOKJA_notbox +=" checked";
        }
        smarty.Add("KODEPOKJA_notbox",KODEPOKJA_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODEPOKJA\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODEPOKJA", searchtype);
        //	edit format
                editformats["KODEPOKJA"] = "Text field";
        // NAMA 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["NAMA"];
	        not = Asearchnot["NAMA"];
	        value = Asearchfor["NAMA"];
        }

        Control control_NAMA = null;
        Control control1_NAMA = null;

        control_NAMA = new Control("NAMA", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("NAMA_editcontrol", control_NAMA.BuildEditControl());
        control1_NAMA = new Control("NAMA", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("NAMA_editcontrol1", control1_NAMA.BuildEditControl());

        IDictionary<string, string> NAMA_fieldblock = new Dictionary<string, string>();
	    NAMA_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"NAMA\">";
	    NAMA_fieldblock["end"]=string.Empty;
	    smarty.Add("NAMA_fieldblock", NAMA_fieldblock);

        string NAMA_notbox="name=\"not_NAMA\"";
        if(not)
        {
	        NAMA_notbox +=" checked";
        }
        smarty.Add("NAMA_notbox",NAMA_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_NAMA\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_NAMA", searchtype);
        //	edit format
                editformats["NAMA"] = "Text field";
        // DESKRIPSSI 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["DESKRIPSSI"];
	        not = Asearchnot["DESKRIPSSI"];
	        value = Asearchfor["DESKRIPSSI"];
        }

        Control control_DESKRIPSSI = null;
        Control control1_DESKRIPSSI = null;

        control_DESKRIPSSI = new Control("DESKRIPSSI", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("DESKRIPSSI_editcontrol", control_DESKRIPSSI.BuildEditControl());
        control1_DESKRIPSSI = new Control("DESKRIPSSI", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("DESKRIPSSI_editcontrol1", control1_DESKRIPSSI.BuildEditControl());

        IDictionary<string, string> DESKRIPSSI_fieldblock = new Dictionary<string, string>();
	    DESKRIPSSI_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"DESKRIPSSI\">";
	    DESKRIPSSI_fieldblock["end"]=string.Empty;
	    smarty.Add("DESKRIPSSI_fieldblock", DESKRIPSSI_fieldblock);

        string DESKRIPSSI_notbox="name=\"not_DESKRIPSSI\"";
        if(not)
        {
	        DESKRIPSSI_notbox +=" checked";
        }
        smarty.Add("DESKRIPSSI_notbox",DESKRIPSSI_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_DESKRIPSSI\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_DESKRIPSSI", searchtype);
        //	edit format
                editformats["DESKRIPSSI"] = "Text field";
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
        if(Asearchfor.ContainsKey("KODEPOKJA"))
        {
            fvalue = Asearchfor["KODEPOKJA"];
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
                contents_block["begin"] += "action=\"POKJA_list.aspx\"" ;
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
