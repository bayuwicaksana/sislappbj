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
using Data;
#endregion

public partial class CTb_Vendor_Search : AspNetRunnerPage
{
    int mypage = 1;
    int id = 1;
    string key;
    string templatefile = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.Tb_Vendor";
        strTableNameLocale = "dbo_Tb_Vendor";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            // mandatory entry so compiler knows what table is processing
                        CheckSecurity();
            BuildForm();
            BuildBody();
            output.Append(func.BuildOutput(this, @"~\Tb_Vendor_search.aspx", smarty));

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
            includes.Append("var SUGGEST_TABLE = \"Tb_Vendor_searchsuggest.aspx\";\r\n");
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
	    includes.Append("document.getElementById('second_KD_VENDOR').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KD_VENDOR'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_NAMA').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NAMA'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_ALAMAT').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_ALAMAT'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_NPWP').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NPWP'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_TELEPON').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_TELEPON'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_FAX').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_FAX'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_EMAIL').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_EMAIL'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_STATUS').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_STATUS'].value==\"Between\" ? '' : 'none'; ");
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
	        includes.Append("document.forms.editform.value_KD_VENDOR.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_KD_VENDOR,'advanced')};");
	        includes.Append("document.forms.editform.value1_KD_VENDOR.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_KD_VENDOR,'advanced1')};");
	        includes.Append("document.forms.editform.value_KD_VENDOR.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_KD_VENDOR,'advanced')};");
	        includes.Append("document.forms.editform.value1_KD_VENDOR.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_KD_VENDOR,'advanced1')};");
	        includes.Append("document.forms.editform.value_NAMA.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_NAMA,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMA.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_NAMA,'advanced1')};");
	        includes.Append("document.forms.editform.value_NAMA.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_NAMA,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMA.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_NAMA,'advanced1')};");
	        includes.Append("document.forms.editform.value_ALAMAT.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_ALAMAT,'advanced')};");
	        includes.Append("document.forms.editform.value1_ALAMAT.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_ALAMAT,'advanced1')};");
	        includes.Append("document.forms.editform.value_ALAMAT.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_ALAMAT,'advanced')};");
	        includes.Append("document.forms.editform.value1_ALAMAT.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_ALAMAT,'advanced1')};");
	        includes.Append("document.forms.editform.value_NPWP.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_NPWP,'advanced')};");
	        includes.Append("document.forms.editform.value1_NPWP.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_NPWP,'advanced1')};");
	        includes.Append("document.forms.editform.value_NPWP.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_NPWP,'advanced')};");
	        includes.Append("document.forms.editform.value1_NPWP.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_NPWP,'advanced1')};");
	        includes.Append("document.forms.editform.value_TELEPON.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_TELEPON,'advanced')};");
	        includes.Append("document.forms.editform.value1_TELEPON.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_TELEPON,'advanced1')};");
	        includes.Append("document.forms.editform.value_TELEPON.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_TELEPON,'advanced')};");
	        includes.Append("document.forms.editform.value1_TELEPON.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_TELEPON,'advanced1')};");
	        includes.Append("document.forms.editform.value_FAX.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_FAX,'advanced')};");
	        includes.Append("document.forms.editform.value1_FAX.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_FAX,'advanced1')};");
	        includes.Append("document.forms.editform.value_FAX.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_FAX,'advanced')};");
	        includes.Append("document.forms.editform.value1_FAX.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_FAX,'advanced1')};");
	        includes.Append("document.forms.editform.value_EMAIL.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_EMAIL,'advanced')};");
	        includes.Append("document.forms.editform.value1_EMAIL.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_EMAIL,'advanced1')};");
	        includes.Append("document.forms.editform.value_EMAIL.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_EMAIL,'advanced')};");
	        includes.Append("document.forms.editform.value1_EMAIL.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_EMAIL,'advanced1')};");
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

        // KD_VENDOR 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KD_VENDOR"];
	        not = Asearchnot["KD_VENDOR"];
	        value = Asearchfor["KD_VENDOR"];
        }

        Control control_KD_VENDOR = null;
        Control control1_KD_VENDOR = null;

        control_KD_VENDOR = new Control("KD_VENDOR", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("KD_VENDOR_editcontrol", control_KD_VENDOR.BuildEditControl());
        control1_KD_VENDOR = new Control("KD_VENDOR", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("KD_VENDOR_editcontrol1", control1_KD_VENDOR.BuildEditControl());

        IDictionary<string, string> KD_VENDOR_fieldblock = new Dictionary<string, string>();
	    KD_VENDOR_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KD_VENDOR\">";
	    KD_VENDOR_fieldblock["end"]=string.Empty;
	    smarty.Add("KD_VENDOR_fieldblock", KD_VENDOR_fieldblock);

        string KD_VENDOR_notbox="name=\"not_KD_VENDOR\"";
        if(not)
        {
	        KD_VENDOR_notbox +=" checked";
        }
        smarty.Add("KD_VENDOR_notbox",KD_VENDOR_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KD_VENDOR\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KD_VENDOR", searchtype);
        //	edit format
                editformats["KD_VENDOR"] = "Text field";
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
        // ALAMAT 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["ALAMAT"];
	        not = Asearchnot["ALAMAT"];
	        value = Asearchfor["ALAMAT"];
        }

        Control control_ALAMAT = null;
        Control control1_ALAMAT = null;

        control_ALAMAT = new Control("ALAMAT", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("ALAMAT_editcontrol", control_ALAMAT.BuildEditControl());
        control1_ALAMAT = new Control("ALAMAT", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("ALAMAT_editcontrol1", control1_ALAMAT.BuildEditControl());

        IDictionary<string, string> ALAMAT_fieldblock = new Dictionary<string, string>();
	    ALAMAT_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"ALAMAT\">";
	    ALAMAT_fieldblock["end"]=string.Empty;
	    smarty.Add("ALAMAT_fieldblock", ALAMAT_fieldblock);

        string ALAMAT_notbox="name=\"not_ALAMAT\"";
        if(not)
        {
	        ALAMAT_notbox +=" checked";
        }
        smarty.Add("ALAMAT_notbox",ALAMAT_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_ALAMAT\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_ALAMAT", searchtype);
        //	edit format
                editformats["ALAMAT"] = "Text field";
        // NPWP 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["NPWP"];
	        not = Asearchnot["NPWP"];
	        value = Asearchfor["NPWP"];
        }

        Control control_NPWP = null;
        Control control1_NPWP = null;

        control_NPWP = new Control("NPWP", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("NPWP_editcontrol", control_NPWP.BuildEditControl());
        control1_NPWP = new Control("NPWP", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("NPWP_editcontrol1", control1_NPWP.BuildEditControl());

        IDictionary<string, string> NPWP_fieldblock = new Dictionary<string, string>();
	    NPWP_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"NPWP\">";
	    NPWP_fieldblock["end"]=string.Empty;
	    smarty.Add("NPWP_fieldblock", NPWP_fieldblock);

        string NPWP_notbox="name=\"not_NPWP\"";
        if(not)
        {
	        NPWP_notbox +=" checked";
        }
        smarty.Add("NPWP_notbox",NPWP_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_NPWP\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_NPWP", searchtype);
        //	edit format
                editformats["NPWP"] = "Text field";
        // TELEPON 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["TELEPON"];
	        not = Asearchnot["TELEPON"];
	        value = Asearchfor["TELEPON"];
        }

        Control control_TELEPON = null;
        Control control1_TELEPON = null;

        control_TELEPON = new Control("TELEPON", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("TELEPON_editcontrol", control_TELEPON.BuildEditControl());
        control1_TELEPON = new Control("TELEPON", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("TELEPON_editcontrol1", control1_TELEPON.BuildEditControl());

        IDictionary<string, string> TELEPON_fieldblock = new Dictionary<string, string>();
	    TELEPON_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"TELEPON\">";
	    TELEPON_fieldblock["end"]=string.Empty;
	    smarty.Add("TELEPON_fieldblock", TELEPON_fieldblock);

        string TELEPON_notbox="name=\"not_TELEPON\"";
        if(not)
        {
	        TELEPON_notbox +=" checked";
        }
        smarty.Add("TELEPON_notbox",TELEPON_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_TELEPON\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_TELEPON", searchtype);
        //	edit format
                editformats["TELEPON"] = "Text field";
        // FAX 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["FAX"];
	        not = Asearchnot["FAX"];
	        value = Asearchfor["FAX"];
        }

        Control control_FAX = null;
        Control control1_FAX = null;

        control_FAX = new Control("FAX", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("FAX_editcontrol", control_FAX.BuildEditControl());
        control1_FAX = new Control("FAX", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("FAX_editcontrol1", control1_FAX.BuildEditControl());

        IDictionary<string, string> FAX_fieldblock = new Dictionary<string, string>();
	    FAX_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"FAX\">";
	    FAX_fieldblock["end"]=string.Empty;
	    smarty.Add("FAX_fieldblock", FAX_fieldblock);

        string FAX_notbox="name=\"not_FAX\"";
        if(not)
        {
	        FAX_notbox +=" checked";
        }
        smarty.Add("FAX_notbox",FAX_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_FAX\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_FAX", searchtype);
        //	edit format
                editformats["FAX"] = "Text field";
        // EMAIL 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["EMAIL"];
	        not = Asearchnot["EMAIL"];
	        value = Asearchfor["EMAIL"];
        }

        Control control_EMAIL = null;
        Control control1_EMAIL = null;

        control_EMAIL = new Control("EMAIL", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("EMAIL_editcontrol", control_EMAIL.BuildEditControl());
        control1_EMAIL = new Control("EMAIL", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("EMAIL_editcontrol1", control1_EMAIL.BuildEditControl());

        IDictionary<string, string> EMAIL_fieldblock = new Dictionary<string, string>();
	    EMAIL_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"EMAIL\">";
	    EMAIL_fieldblock["end"]=string.Empty;
	    smarty.Add("EMAIL_fieldblock", EMAIL_fieldblock);

        string EMAIL_notbox="name=\"not_EMAIL\"";
        if(not)
        {
	        EMAIL_notbox +=" checked";
        }
        smarty.Add("EMAIL_notbox",EMAIL_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_EMAIL\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_EMAIL", searchtype);
        //	edit format
                editformats["EMAIL"] = "Text field";
        // STATUS 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["STATUS"];
	        not = Asearchnot["STATUS"];
	        value = Asearchfor["STATUS"];
        }

        Control control_STATUS = null;
        Control control1_STATUS = null;

        control_STATUS = new Control("STATUS", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("STATUS_editcontrol", control_STATUS.BuildEditControl());
        control1_STATUS = new Control("STATUS", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("STATUS_editcontrol1", control1_STATUS.BuildEditControl());

        IDictionary<string, string> STATUS_fieldblock = new Dictionary<string, string>();
	    STATUS_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"STATUS\">";
	    STATUS_fieldblock["end"]=string.Empty;
	    smarty.Add("STATUS_fieldblock", STATUS_fieldblock);

        string STATUS_notbox="name=\"not_STATUS\"";
        if(not)
        {
	        STATUS_notbox +=" checked";
        }
        smarty.Add("STATUS_notbox",STATUS_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_STATUS\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_STATUS", searchtype);
        //	edit format
                editformats["STATUS"] = "Checkbox";
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
        if(Asearchfor.ContainsKey("KD_USER"))
        {
            fvalue = Asearchfor["KD_USER"];
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
                contents_block["begin"] += "action=\"Tb_Vendor_list.aspx\"" ;
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
