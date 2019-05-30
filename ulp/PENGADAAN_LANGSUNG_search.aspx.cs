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

public partial class CPENGADAAN_LANGSUNG_Search : AspNetRunnerPage
{
    int mypage = 1;
    int id = 1;
    string key;
    string templatefile = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGADAAN_LANGSUNG";
        strTableNameLocale = "dbo_PENGADAAN_LANGSUNG";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            // mandatory entry so compiler knows what table is processing
                        BuildForm();
            BuildBody();
            output.Append(func.BuildOutput(this, @"~\PENGADAAN_LANGSUNG_search.aspx", smarty));

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
            includes.Append("var SUGGEST_TABLE = \"PENGADAAN_LANGSUNG_searchsuggest.aspx\";\r\n");
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
	    includes.Append("document.getElementById('second_NAMAKEGIATAN').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NAMAKEGIATAN'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_NAMAPAKET').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NAMAPAKET'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_KODESKPD').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KODESKPD'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_TANGGALKONTRAK').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_TANGGALKONTRAK'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_PAGU').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_PAGU'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_HPS').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_HPS'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_NILAIKONTRAK').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_NILAIKONTRAK'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_PEMENANG').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_PEMENANG'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_KETERANGAN').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_KETERANGAN'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_PEJABATPENGADAAN').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_PEJABATPENGADAAN'].value==\"Between\" ? '' : 'none'; ");
	    includes.Append("document.getElementById('second_MENGETAHUI').style.display =  ");
		includes.Append("document.forms.editform.elements['asearchopt_MENGETAHUI'].value==\"Between\" ? '' : 'none'; ");
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
	        includes.Append("document.forms.editform.value_NAMAKEGIATAN.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_NAMAKEGIATAN,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMAKEGIATAN.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_NAMAKEGIATAN,'advanced1')};");
	        includes.Append("document.forms.editform.value_NAMAKEGIATAN.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_NAMAKEGIATAN,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMAKEGIATAN.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_NAMAKEGIATAN,'advanced1')};");
	        includes.Append("document.forms.editform.value_NAMAPAKET.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_NAMAPAKET,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMAPAKET.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_NAMAPAKET,'advanced1')};");
	        includes.Append("document.forms.editform.value_NAMAPAKET.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_NAMAPAKET,'advanced')};");
	        includes.Append("document.forms.editform.value1_NAMAPAKET.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_NAMAPAKET,'advanced1')};");
	        includes.Append("document.forms.editform.value_PAGU.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_PAGU,'advanced')};");
	        includes.Append("document.forms.editform.value1_PAGU.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_PAGU,'advanced1')};");
	        includes.Append("document.forms.editform.value_PAGU.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_PAGU,'advanced')};");
	        includes.Append("document.forms.editform.value1_PAGU.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_PAGU,'advanced1')};");
	        includes.Append("document.forms.editform.value_HPS.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_HPS,'advanced')};");
	        includes.Append("document.forms.editform.value1_HPS.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_HPS,'advanced1')};");
	        includes.Append("document.forms.editform.value_HPS.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_HPS,'advanced')};");
	        includes.Append("document.forms.editform.value1_HPS.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_HPS,'advanced1')};");
	        includes.Append("document.forms.editform.value_NILAIKONTRAK.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_NILAIKONTRAK,'advanced')};");
	        includes.Append("document.forms.editform.value1_NILAIKONTRAK.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_NILAIKONTRAK,'advanced1')};");
	        includes.Append("document.forms.editform.value_NILAIKONTRAK.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_NILAIKONTRAK,'advanced')};");
	        includes.Append("document.forms.editform.value1_NILAIKONTRAK.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_NILAIKONTRAK,'advanced1')};");
	        includes.Append("document.forms.editform.value_PEMENANG.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value_PEMENANG,'advanced')};");
	        includes.Append("document.forms.editform.value1_PEMENANG.onkeyup=function(event) {searchSuggest(event,document.forms.editform.value1_PEMENANG,'advanced1')};");
	        includes.Append("document.forms.editform.value_PEMENANG.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value_PEMENANG,'advanced')};");
	        includes.Append("document.forms.editform.value1_PEMENANG.onkeydown=function(event) {return listenEvent(event,document.forms.editform.value1_PEMENANG,'advanced1')};");
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

        // NAMAKEGIATAN 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["NAMAKEGIATAN"];
	        not = Asearchnot["NAMAKEGIATAN"];
	        value = Asearchfor["NAMAKEGIATAN"];
        }

        Control control_NAMAKEGIATAN = null;
        Control control1_NAMAKEGIATAN = null;

        control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("NAMAKEGIATAN_editcontrol", control_NAMAKEGIATAN.BuildEditControl());
        control1_NAMAKEGIATAN = new Control("NAMAKEGIATAN", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("NAMAKEGIATAN_editcontrol1", control1_NAMAKEGIATAN.BuildEditControl());

        IDictionary<string, string> NAMAKEGIATAN_fieldblock = new Dictionary<string, string>();
	    NAMAKEGIATAN_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"NAMAKEGIATAN\">";
	    NAMAKEGIATAN_fieldblock["end"]=string.Empty;
	    smarty.Add("NAMAKEGIATAN_fieldblock", NAMAKEGIATAN_fieldblock);

        string NAMAKEGIATAN_notbox="name=\"not_NAMAKEGIATAN\"";
        if(not)
        {
	        NAMAKEGIATAN_notbox +=" checked";
        }
        smarty.Add("NAMAKEGIATAN_notbox",NAMAKEGIATAN_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_NAMAKEGIATAN\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_NAMAKEGIATAN", searchtype);
        //	edit format
                editformats["NAMAKEGIATAN"] = "Text field";
        // NAMAPAKET 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["NAMAPAKET"];
	        not = Asearchnot["NAMAPAKET"];
	        value = Asearchfor["NAMAPAKET"];
        }

        Control control_NAMAPAKET = null;
        Control control1_NAMAPAKET = null;

        control_NAMAPAKET = new Control("NAMAPAKET", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("NAMAPAKET_editcontrol", control_NAMAPAKET.BuildEditControl());
        control1_NAMAPAKET = new Control("NAMAPAKET", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("NAMAPAKET_editcontrol1", control1_NAMAPAKET.BuildEditControl());

        IDictionary<string, string> NAMAPAKET_fieldblock = new Dictionary<string, string>();
	    NAMAPAKET_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"NAMAPAKET\">";
	    NAMAPAKET_fieldblock["end"]=string.Empty;
	    smarty.Add("NAMAPAKET_fieldblock", NAMAPAKET_fieldblock);

        string NAMAPAKET_notbox="name=\"not_NAMAPAKET\"";
        if(not)
        {
	        NAMAPAKET_notbox +=" checked";
        }
        smarty.Add("NAMAPAKET_notbox",NAMAPAKET_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_NAMAPAKET\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_NAMAPAKET", searchtype);
        //	edit format
                editformats["NAMAPAKET"] = "Text field";
        // KODESKPD 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KODESKPD"];
	        not = Asearchnot["KODESKPD"];
	        value = Asearchfor["KODESKPD"];
        }

        Control control_KODESKPD = null;
        Control control1_KODESKPD = null;

        control_KODESKPD = new Control("KODESKPD", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_KODESKPD.FieldInfo);

        smarty.Add("KODESKPD_editcontrol", control_KODESKPD.BuildEditControl());
        control1_KODESKPD = new Control("KODESKPD", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_KODESKPD.FieldInfo);
        smarty.Add("KODESKPD_editcontrol1", control1_KODESKPD.BuildEditControl());

        IDictionary<string, string> KODESKPD_fieldblock = new Dictionary<string, string>();
	    KODESKPD_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KODESKPD\">";
	    KODESKPD_fieldblock["end"]=string.Empty;
	    smarty.Add("KODESKPD_fieldblock", KODESKPD_fieldblock);

        string KODESKPD_notbox="name=\"not_KODESKPD\"";
        if(not)
        {
	        KODESKPD_notbox +=" checked";
        }
        smarty.Add("KODESKPD_notbox",KODESKPD_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KODESKPD\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KODESKPD", searchtype);
        //	edit format
                editformats["KODESKPD"] = "Lookup wizard";
        // TANGGALKONTRAK 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["TANGGALKONTRAK"];
	        not = Asearchnot["TANGGALKONTRAK"];
	        value = Asearchfor["TANGGALKONTRAK"];
        }

        Control control_TANGGALKONTRAK = null;
        Control control1_TANGGALKONTRAK = null;

        control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("TANGGALKONTRAK_editcontrol", control_TANGGALKONTRAK.BuildEditControl());
        control1_TANGGALKONTRAK = new Control("TANGGALKONTRAK", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("TANGGALKONTRAK_editcontrol1", control1_TANGGALKONTRAK.BuildEditControl());

        IDictionary<string, string> TANGGALKONTRAK_fieldblock = new Dictionary<string, string>();
	    TANGGALKONTRAK_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"TANGGALKONTRAK\">";
	    TANGGALKONTRAK_fieldblock["end"]=string.Empty;
	    smarty.Add("TANGGALKONTRAK_fieldblock", TANGGALKONTRAK_fieldblock);

        string TANGGALKONTRAK_notbox="name=\"not_TANGGALKONTRAK\"";
        if(not)
        {
	        TANGGALKONTRAK_notbox +=" checked";
        }
        smarty.Add("TANGGALKONTRAK_notbox",TANGGALKONTRAK_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        options.Append("<OPTION VALUE=\"More than ...\" " + ((opt=="More than ...")?"selected":"") + ">" + "More than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Less than ...\" " + ((opt=="Less than ...")?"selected":"") + ">" + "Less than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Equal or more than ...\" " + ((opt=="Equal or more than ...")?"selected":"") + ">" + "Equal or more than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Equal or less than ...\" " + ((opt=="Equal or less than ...")?"selected":"") + ">" + "Equal or less than ..." + "</option>");
        options.Append("<OPTION VALUE=\"Between\" " + ((opt=="Between")?"selected":"") + ">" + "Between" + "</option>");
        options.Append("<OPTION VALUE=\"Empty\" " + ((opt=="Empty")?"selected":"") + ">" + "Empty" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_TANGGALKONTRAK\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_TANGGALKONTRAK", searchtype);
        //	edit format
                editformats["TANGGALKONTRAK"] = "Date";
        // PAGU 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["PAGU"];
	        not = Asearchnot["PAGU"];
	        value = Asearchfor["PAGU"];
        }

        Control control_PAGU = null;
        Control control1_PAGU = null;

        control_PAGU = new Control("PAGU", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("PAGU_editcontrol", control_PAGU.BuildEditControl());
        control1_PAGU = new Control("PAGU", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("PAGU_editcontrol1", control1_PAGU.BuildEditControl());

        IDictionary<string, string> PAGU_fieldblock = new Dictionary<string, string>();
	    PAGU_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"PAGU\">";
	    PAGU_fieldblock["end"]=string.Empty;
	    smarty.Add("PAGU_fieldblock", PAGU_fieldblock);

        string PAGU_notbox="name=\"not_PAGU\"";
        if(not)
        {
	        PAGU_notbox +=" checked";
        }
        smarty.Add("PAGU_notbox",PAGU_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_PAGU\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_PAGU", searchtype);
        //	edit format
                editformats["PAGU"] = "Text field";
        // HPS 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["HPS"];
	        not = Asearchnot["HPS"];
	        value = Asearchfor["HPS"];
        }

        Control control_HPS = null;
        Control control1_HPS = null;

        control_HPS = new Control("HPS", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("HPS_editcontrol", control_HPS.BuildEditControl());
        control1_HPS = new Control("HPS", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("HPS_editcontrol1", control1_HPS.BuildEditControl());

        IDictionary<string, string> HPS_fieldblock = new Dictionary<string, string>();
	    HPS_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"HPS\">";
	    HPS_fieldblock["end"]=string.Empty;
	    smarty.Add("HPS_fieldblock", HPS_fieldblock);

        string HPS_notbox="name=\"not_HPS\"";
        if(not)
        {
	        HPS_notbox +=" checked";
        }
        smarty.Add("HPS_notbox",HPS_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_HPS\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_HPS", searchtype);
        //	edit format
                editformats["HPS"] = "Text field";
        // NILAIKONTRAK 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["NILAIKONTRAK"];
	        not = Asearchnot["NILAIKONTRAK"];
	        value = Asearchfor["NILAIKONTRAK"];
        }

        Control control_NILAIKONTRAK = null;
        Control control1_NILAIKONTRAK = null;

        control_NILAIKONTRAK = new Control("NILAIKONTRAK", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("NILAIKONTRAK_editcontrol", control_NILAIKONTRAK.BuildEditControl());
        control1_NILAIKONTRAK = new Control("NILAIKONTRAK", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("NILAIKONTRAK_editcontrol1", control1_NILAIKONTRAK.BuildEditControl());

        IDictionary<string, string> NILAIKONTRAK_fieldblock = new Dictionary<string, string>();
	    NILAIKONTRAK_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"NILAIKONTRAK\">";
	    NILAIKONTRAK_fieldblock["end"]=string.Empty;
	    smarty.Add("NILAIKONTRAK_fieldblock", NILAIKONTRAK_fieldblock);

        string NILAIKONTRAK_notbox="name=\"not_NILAIKONTRAK\"";
        if(not)
        {
	        NILAIKONTRAK_notbox +=" checked";
        }
        smarty.Add("NILAIKONTRAK_notbox",NILAIKONTRAK_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_NILAIKONTRAK\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_NILAIKONTRAK", searchtype);
        //	edit format
                editformats["NILAIKONTRAK"] = "Text field";
        // PEMENANG 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["PEMENANG"];
	        not = Asearchnot["PEMENANG"];
	        value = Asearchfor["PEMENANG"];
        }

        Control control_PEMENANG = null;
        Control control1_PEMENANG = null;

        control_PEMENANG = new Control("PEMENANG", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
        
        smarty.Add("PEMENANG_editcontrol", control_PEMENANG.BuildEditControl());
        control1_PEMENANG = new Control("PEMENANG", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                smarty.Add("PEMENANG_editcontrol1", control1_PEMENANG.BuildEditControl());

        IDictionary<string, string> PEMENANG_fieldblock = new Dictionary<string, string>();
	    PEMENANG_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"PEMENANG\">";
	    PEMENANG_fieldblock["end"]=string.Empty;
	    smarty.Add("PEMENANG_fieldblock", PEMENANG_fieldblock);

        string PEMENANG_notbox="name=\"not_PEMENANG\"";
        if(not)
        {
	        PEMENANG_notbox +=" checked";
        }
        smarty.Add("PEMENANG_notbox",PEMENANG_notbox);

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
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_PEMENANG\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_PEMENANG", searchtype);
        //	edit format
                editformats["PEMENANG"] = "Text field";
        // KETERANGAN 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["KETERANGAN"];
	        not = Asearchnot["KETERANGAN"];
	        value = Asearchfor["KETERANGAN"];
        }

        Control control_KETERANGAN = null;
        Control control1_KETERANGAN = null;

        control_KETERANGAN = new Control("KETERANGAN", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_KETERANGAN.FieldInfo);

        smarty.Add("KETERANGAN_editcontrol", control_KETERANGAN.BuildEditControl());
        control1_KETERANGAN = new Control("KETERANGAN", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_KETERANGAN.FieldInfo);
        smarty.Add("KETERANGAN_editcontrol1", control1_KETERANGAN.BuildEditControl());

        IDictionary<string, string> KETERANGAN_fieldblock = new Dictionary<string, string>();
	    KETERANGAN_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"KETERANGAN\">";
	    KETERANGAN_fieldblock["end"]=string.Empty;
	    smarty.Add("KETERANGAN_fieldblock", KETERANGAN_fieldblock);

        string KETERANGAN_notbox="name=\"not_KETERANGAN\"";
        if(not)
        {
	        KETERANGAN_notbox +=" checked";
        }
        smarty.Add("KETERANGAN_notbox",KETERANGAN_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_KETERANGAN\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_KETERANGAN", searchtype);
        //	edit format
                editformats["KETERANGAN"] = "Lookup wizard";
        // PEJABATPENGADAAN 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["PEJABATPENGADAAN"];
	        not = Asearchnot["PEJABATPENGADAAN"];
	        value = Asearchfor["PEJABATPENGADAAN"];
        }

        Control control_PEJABATPENGADAAN = null;
        Control control1_PEJABATPENGADAAN = null;

        control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_PEJABATPENGADAAN.FieldInfo);

        smarty.Add("PEJABATPENGADAAN_editcontrol", control_PEJABATPENGADAAN.BuildEditControl());
        control1_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_PEJABATPENGADAAN.FieldInfo);
        smarty.Add("PEJABATPENGADAAN_editcontrol1", control1_PEJABATPENGADAAN.BuildEditControl());

        IDictionary<string, string> PEJABATPENGADAAN_fieldblock = new Dictionary<string, string>();
	    PEJABATPENGADAAN_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"PEJABATPENGADAAN\">";
	    PEJABATPENGADAAN_fieldblock["end"]=string.Empty;
	    smarty.Add("PEJABATPENGADAAN_fieldblock", PEJABATPENGADAAN_fieldblock);

        string PEJABATPENGADAAN_notbox="name=\"not_PEJABATPENGADAAN\"";
        if(not)
        {
	        PEJABATPENGADAAN_notbox +=" checked";
        }
        smarty.Add("PEJABATPENGADAAN_notbox",PEJABATPENGADAAN_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_PEJABATPENGADAAN\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_PEJABATPENGADAAN", searchtype);
        //	edit format
                editformats["PEJABATPENGADAAN"] = "Lookup wizard";
        // MENGETAHUI 
        opt = "";
        not = false;
        value = string.Empty;
        searchtype = string.Empty;
        if(Search == 2)
        {
	        opt = Asearchopt["MENGETAHUI"];
	        not = Asearchnot["MENGETAHUI"];
	        value = Asearchfor["MENGETAHUI"];
        }

        Control control_MENGETAHUI = null;
        Control control1_MENGETAHUI = null;

        control_MENGETAHUI = new Control("MENGETAHUI", value, false, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control_MENGETAHUI.FieldInfo);

        smarty.Add("MENGETAHUI_editcontrol", control_MENGETAHUI.BuildEditControl());
        control1_MENGETAHUI = new Control("MENGETAHUI", value, true, smarty, this.Request, builder, MODE.MODE_SEARCH);
                func.PopulateLookupFields(control1_MENGETAHUI.FieldInfo);
        smarty.Add("MENGETAHUI_editcontrol1", control1_MENGETAHUI.BuildEditControl());

        IDictionary<string, string> MENGETAHUI_fieldblock = new Dictionary<string, string>();
	    MENGETAHUI_fieldblock["begin"] = "<input type=\"Hidden\" name=\"asearchfield[]\" value=\"MENGETAHUI\">";
	    MENGETAHUI_fieldblock["end"]=string.Empty;
	    smarty.Add("MENGETAHUI_fieldblock", MENGETAHUI_fieldblock);

        string MENGETAHUI_notbox="name=\"not_MENGETAHUI\"";
        if(not)
        {
	        MENGETAHUI_notbox +=" checked";
        }
        smarty.Add("MENGETAHUI_notbox",MENGETAHUI_notbox);

        //	write search options
        options = options.Remove(0, options.Length);
                options.Append("<OPTION VALUE=\"Equals\" " + ((opt=="Equals")?"selected":"") + ">" + "Equals" + "</option>");
        searchtype = "<SELECT ID=\"SearchOption\" NAME=\"asearchopt_MENGETAHUI\" SIZE=1 onChange=\"return ShowHideControls();\">";
        searchtype += options.ToString();
        searchtype += "</SELECT>";
        smarty.Add("searchtype_MENGETAHUI", searchtype);
        //	edit format
                editformats["MENGETAHUI"] = "Lookup wizard";
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
                contents_block["begin"] += "action=\"PENGADAAN_LANGSUNG_list.aspx\"" ;
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
