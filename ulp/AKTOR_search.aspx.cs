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

public partial class CAKTOR_Search : AspNetRunnerPage
{
    int mypage = 1;
    int id = 1;
    string key;
    string templatefile = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.AKTOR";
        strTableNameLocale = "dbo_AKTOR";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            // mandatory entry so compiler knows what table is processing
                        CheckSecurity();
            BuildForm();
            BuildBody();
            output.Append(func.BuildOutput(this, @"~\AKTOR_search.aspx", smarty));

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
            includes.Append("var SUGGEST_TABLE = \"AKTOR_searchsuggest.aspx\";\r\n");
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
	    includes.Append("document.getElementById('second_NAMA').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NAMA'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_KODEJABATAN').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODEJABATAN'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_KODETIPE').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODETIPE'].value==\"Between\" ? '' : 'none'; ");
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
        
        smarty.Add("NIP_editcontrol", control_NIP.BuildEditControl());
        control1_NIP = new Control("NIP", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
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
                options.Append("<OPTION VALUE=\"Contains\" " + ((opt=="Contains")?"selected":"") + ">" + "Contains" + "</option>");
        options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        options.Append("<OPTION VALUE=\"Starts with ...\" " + ((opt=="Starts with ...")?"selected":"") + ">" + "Starts with ..." + "</option>");
        options.Append("<OPTION VALUE=\"More than ...\" " + ((opt=="More than ...")?"selected":"") + ">" + "More than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Less than ...\" " + ((opt=="Less than ...")?"selected":"") + ">" + "Less than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Equal or more than ...\" " + ((opt=="Equal or more than ...")?"selected":"") + ">" + "Equal or more than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Equal or less than ...\" " + ((opt=="Equal or less than ...")?"selected":"") + ">" + "Equal or less than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Between\" " + ((opt=="Between")?"selected":"") + ">" + "Between" + "</option>");
        options.Append("<OPTION VALUE=\"Empty\" " + ((opt=="Empty")?"selected":"") + ">" + "Empty" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_NIP\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_NIP", searchtype);
        //	edit format
                editformats["NIP"] = "Text field";
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
        // KODEJABATAN 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODEJABATAN"];
	        not = Asearchnot["KODEJABATAN"];
	        value = Asearchfor["KODEJABATAN"];
        }

        Control control_KODEJABATAN = null;
        Control control1_KODEJABATAN = null;

        control_KODEJABATAN = new Control("KODEJABATAN", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_KODEJABATAN.FieldInfo);

        smarty.Add("KODEJABATAN_editcontrol", control_KODEJABATAN.BuildEditControl());
        control1_KODEJABATAN = new Control("KODEJABATAN", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_KODEJABATAN.FieldInfo);
        smarty.Add("KODEJABATAN_editcontrol1", control1_KODEJABATAN.BuildEditControl());

        IDictionary<string, string> KODEJABATAN_fieldblock = new Dictionary<string, string>();
	    KODEJABATAN_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODEJABATAN\">";
	    KODEJABATAN_fieldblock["end"]=string.Empty;
	    smarty.Add("KODEJABATAN_fieldblock", KODEJABATAN_fieldblock);

        string KODEJABATAN_notbox="name=\"not_KODEJABATAN\"";
        if(not)
        {
	        KODEJABATAN_notbox +=" checked";
        }
        smarty.Add("KODEJABATAN_notbox",KODEJABATAN_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODEJABATAN\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODEJABATAN", searchtype);
        //	edit format
                editformats["KODEJABATAN"] = "Lookup wizard";
        // KODETIPE 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODETIPE"];
	        not = Asearchnot["KODETIPE"];
	        value = Asearchfor["KODETIPE"];
        }

        Control control_KODETIPE = null;
        Control control1_KODETIPE = null;

        control_KODETIPE = new Control("KODETIPE", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_KODETIPE.FieldInfo);

        smarty.Add("KODETIPE_editcontrol", control_KODETIPE.BuildEditControl());
        control1_KODETIPE = new Control("KODETIPE", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_KODETIPE.FieldInfo);
        smarty.Add("KODETIPE_editcontrol1", control1_KODETIPE.BuildEditControl());

        IDictionary<string, string> KODETIPE_fieldblock = new Dictionary<string, string>();
	    KODETIPE_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODETIPE\">";
	    KODETIPE_fieldblock["end"]=string.Empty;
	    smarty.Add("KODETIPE_fieldblock", KODETIPE_fieldblock);

        string KODETIPE_notbox="name=\"not_KODETIPE\"";
        if(not)
        {
	        KODETIPE_notbox +=" checked";
        }
        smarty.Add("KODETIPE_notbox",KODETIPE_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODETIPE\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODETIPE", searchtype);
        //	edit format
                editformats["KODETIPE"] = "Lookup wizard";
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
                contents_block["begin"] += "action=\"AKTOR_list.aspx\"" ;
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
