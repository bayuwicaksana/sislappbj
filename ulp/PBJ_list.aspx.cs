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
using SubSonic;
using System.Data.SqlClient;
#endregion

public partial class CPBJ_List : AspNetRunnerPage 
{
    string message = string.Empty;
    string filename="";
    int rowCount = 0;
    int numrows = 0;
    IDictionary bodyDict;
    IDictionary totals_records;
    bool allow_export;
    bool allow_edit;
    bool allow_add;
    bool allow_delete;
    bool allow_search;
    bool display_grid;
    bool rowsfound = false;
    bool allow_import;
        bool allow_KELENGKAPANPBJ;
        bool allow_ASSIGNMENT;
    int colsonpage;
    int mypage;
    bool shade;
    IDictionary rowinfo;
    int recno = 1;
    int gPageSize = 20;
    string id;
    Smarty.MODE mode = MODE.MODE_LIST_SIMPLE;

    Data.PBJController controller = new Data.PBJController();
    Data.PBJCollection collection;

    Data.KELENGKAPANPBJCollection KELENGKAPANPBJ_detailCollection;
    Data.ASSIGNMENTCollection ASSIGNMENT_detailCollection;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PBJ";
        strTableNameLocale = "dbo_PBJ";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
        string output = string.Empty;
                        if (User != null && !string.IsNullOrEmpty("PBJ"))
            {
                OwnerColumn = func.GetOwnerIDField("PBJ");
            }
                        allow_KELENGKAPANPBJ = func.CheckUserPermissions("dbo.KELENGKAPANPBJ", "SA");
                        allow_ASSIGNMENT = func.CheckUserPermissions("dbo.ASSIGNMENT", "SA");
            rowinfo = array();
            bodyDict = array();
            rowinfo["data"] = list();
            id = (string)this.Request["id"];
            smarty.Add("id", id);
            if((string)this.Request["mode"]=="lookup")
            {
	            mode = MODE.MODE_LIST_LOOKUP;
            }
                        if(!CheckSecurity())
            {
                this.Response.End();
                return;
            }
                        ProcessRequest();
            Body();
            ProcessSessionVariables();
                        DeleteRecord();
            ProcessPermissions();
            AddMasterDetailInfo();
            GetData();
            InlineAdd();
            BuildForm();
            AddSearchAttributes();
            AddLoginAttributes();
            AddLinkAttributes();
            AddDisplayGridAttributes();
            AddLinkdata();

            output = func.BuildOutput(this, @"~\PBJ_list.aspx", smarty);
            this.Response.Write(output);
            this.Response.End();
    }

    
    private void AddLinkdata()
    {
        string linkdata="";

        linkdata += "<script type=\"text/javascript\">\r\n";

        	        linkdata += "</script>\r\n";
        
        linkdata +="<script>" +
        "if(!$('[@disptype=control1]').length && $('[@disptype=controltable1]').length)" +
	        "$('[@disptype=controltable1]').hide(); " +
        "</script>";
        if(Search == 1)
        {
	        linkdata += "<script>if(document.getElementById('SearchFor')) document.getElementById('ctlSearchFor').focus();</script>";
        }

        bodyDict["end"]=linkdata;
        smarty.Add("body",bodyDict);

        smarty.Add("style_block",true);
        smarty.Add("iestyle_block",true);

        
        smarty.Add("changepwd_link", AccessLevel != Control.ACCESS_LEVEL_GUEST);
        smarty.Add("changepwdlink_attrs","onclick=\"window.location.href='changepwd.aspx';return false;\"");


        
                    }

    private void AddDisplayGridAttributes()
    {
        if(display_grid)
        {
            IDictionary grid_block = array();
            grid_block["begin"] = "<form method=\"POST\" action=\"PBJ_list.aspx\" name=\"frmAdmin\" id=\"frmAdmin\">" +
	        "<input type=\"hidden\" id=\"a\" name=\"a\" value=\"delete\">";
            grid_block["end"] = "</form>";
            smarty.Add("grid_block", grid_block);
	        IDictionary record_header=array();
            record_header["data"] = array();
	        IDictionary record_footer=array();
            record_footer["data"] = array();
	        for(int i = 0; i < colsonpage; i++)
	        {
		        IDictionary rheader=array();
		        IDictionary rfooter=array();
		        if(i < colsonpage-1)
		        {
			        rheader["endrecordheader_block"]=true;
			        rfooter["endrecordfooter_block"]=true;
		        }
		        record_header["data"] = rheader;
		        record_footer["data"] = rfooter;
	        }
	        smarty.Add("record_header",record_header);
	        smarty.Add("record_footer",record_footer);
	        smarty.Add("grid_header",true);
	        smarty.Add("grid_footer",true);
	        
            smarty.Add("record_controls",true);
        }

        smarty.Add("recordcontrols_block",allow_add || display_grid);
        smarty.Add("newrecord_controls", allow_add);

        smarty.Add("details_block",allow_search && rowsfound);
        smarty.Add("pages_block",allow_search && rowsfound);
        smarty.Add("recordspp_block",allow_search && rowsfound);
        smarty.Add("recordspp_attrs","onchange=\"javascript: document.location='PBJ_list.aspx?pagesize='+this.options[this.selectedIndex].value;\"");
        smarty.Add("grid_controls",display_grid);

    }

    private void AddMasterDetailInfo()
    {
    }

    private void AddLinkAttributes()
    {
        smarty.Add("toplinks_block",true);
	    smarty.Add("print_link", allow_export);
	    smarty.Add("printall_link", allow_export);
	    smarty.Add("printlink_attrs","onclick=\"window.open('PBJ_print.aspx','wPrint');return false;\"");
	    smarty.Add("printalllink_attrs","onclick=\"window.open('PBJ_print.aspx?all=1','wPrint');return false;\"");
	    smarty.Add("export_link", allow_export);
	    smarty.Add("exportlink_attrs","onclick=\"window.open('PBJ_export.aspx','wExport');return false;\"");
    	
	    smarty.Add("printselected_link", allow_export);
	    smarty.Add("printselectedlink_attrs","disptype=\"control1\" onclick=\"" +
	    "if(!$('input[@type=checkbox][@checked][@name^=selection]').length)" +
		"return true;" +
	    "document.forms.frmAdmin.action='PBJ_print.aspx';" +
	    "document.forms.frmAdmin.target='_blank';" +
	    "document.forms.frmAdmin.submit(); " +
	    "document.forms.frmAdmin.action='PBJ_list.aspx'; " +
	    "document.forms.frmAdmin.target='_self';\"");
	    smarty.Add("exportselected_link", allow_export);
	    smarty.Add("exportselectedlink_attrs","disptype=\"control1\" onclick=\"" +
	    "if(!$('input[@type=checkbox][@checked][@name^=selection]').length)" +
		    "return true;" +
	    "document.forms.frmAdmin.action='PBJ_export.aspx';" +
	    "document.forms.frmAdmin.target='_blank';" +
	    "document.forms.frmAdmin.submit(); " +
	    "document.forms.frmAdmin.action='PBJ_list.aspx';  " +
	    "document.forms.frmAdmin.target='_self';\"");
    	
	    smarty.Add("add_link",allow_add);
        smarty.Add("copy_column",allow_add);
	    smarty.Add("inlineadd_link",allow_add);
	    smarty.Add("addlink_attrs","onClick=\"window.location.href='PBJ_add.aspx'\"");
	    smarty.Add("inlineaddlink_attrs","href=\"PBJ_add.aspx\" onclick=\"return inlineAdd(newrecord_id++);\"");

    	
	    smarty.Add("checkbox_column",allow_delete || allow_export  || allow_edit);
	    smarty.Add("checkboxheader_attrs","onClick = \"var i; " +
        "if ((typeof frmAdmin.elements['selection[]'].length)=='undefined')" +
	    "frmAdmin.elements['selection[]'].checked=this.checked;" +
        "else" +
        " for (i=0;i<frmAdmin.elements['selection[]'].length;++i) " +
	    "frmAdmin.elements['selection[]'][i].checked=this.checked;\"");
	    smarty.Add("editselected_link",allow_edit);
	    smarty.Add("editselectedlink_attrs","disptype=\"control1\" name=\"edit_selected\" onclick=\"$('input[@type=checkbox][@checked][@id^=check]').each(function(i){" +
				    "if(!isNaN(parseInt(this.id.substr(5))))" +
					    "$('a#ieditlink'+this.id.substr(5)).click();});\"");
	    smarty.Add("saveall_link",allow_edit||allow_edit);
	    smarty.Add("savealllink_attrs","disptype=\"control1\" name=\"saveall_edited\" style=\"display:none\" onclick=\"$('a[@id^=save_]').click();\"");
	    smarty.Add("cancelall_link",allow_edit||allow_edit);
	    smarty.Add("cancelalllink_attrs","disptype=\"control1\" name=\"revertall_edited\" style=\"display:none\" onclick=\"$('a[@id^=revert_]').click();\"");
    	

	    smarty.Add("edit_column",allow_edit);
	    smarty.Add("edit_headercolumn",allow_edit);
	    smarty.Add("edit_footercolumn",allow_edit);
	    smarty.Add("inlineedit_column",allow_edit);
	    smarty.Add("inlineedit_headercolumn",allow_edit);
	    smarty.Add("inlineedit_footercolumn",allow_edit);
    	
	    smarty.Add("view_column",allow_search);

 	        smarty.Add("KELENGKAPANPBJ_dtable_column", allow_KELENGKAPANPBJ);
 	        smarty.Add("ASSIGNMENT_dtable_column", allow_ASSIGNMENT);


        smarty.Add("KODEPBJ_fieldheadercolumn",true);
        smarty.Add("KODEPBJ_fieldcolumn",true);
        smarty.Add("KODEPBJ_fieldfootercolumn",true);
        smarty.Add("NAMAKEGIATAN_fieldheadercolumn",true);
        smarty.Add("NAMAKEGIATAN_fieldcolumn",true);
        smarty.Add("NAMAKEGIATAN_fieldfootercolumn",true);
        smarty.Add("NAMAPAKET_fieldheadercolumn",true);
        smarty.Add("NAMAPAKET_fieldcolumn",true);
        smarty.Add("NAMAPAKET_fieldfootercolumn",true);
        smarty.Add("KODESKPD_fieldheadercolumn",true);
        smarty.Add("KODESKPD_fieldcolumn",true);
        smarty.Add("KODESKPD_fieldfootercolumn",true);
        smarty.Add("PPK_fieldheadercolumn",true);
        smarty.Add("PPK_fieldcolumn",true);
        smarty.Add("PPK_fieldfootercolumn",true);
        smarty.Add("PPTK_fieldheadercolumn",true);
        smarty.Add("PPTK_fieldcolumn",true);
        smarty.Add("PPTK_fieldfootercolumn",true);
        smarty.Add("KODEJENISKEGIATAN_fieldheadercolumn",true);
        smarty.Add("KODEJENISKEGIATAN_fieldcolumn",true);
        smarty.Add("KODEJENISKEGIATAN_fieldfootercolumn",true);
        smarty.Add("TANGGALPENGAJUAN_fieldheadercolumn",true);
        smarty.Add("TANGGALPENGAJUAN_fieldcolumn",true);
        smarty.Add("TANGGALPENGAJUAN_fieldfootercolumn",true);
        smarty.Add("TANGGALKEMBALI_fieldheadercolumn",true);
        smarty.Add("TANGGALKEMBALI_fieldcolumn",true);
        smarty.Add("TANGGALKEMBALI_fieldfootercolumn",true);
        smarty.Add("LENGKAP_fieldheadercolumn",true);
        smarty.Add("LENGKAP_fieldcolumn",true);
        smarty.Add("LENGKAP_fieldfootercolumn",true);
        smarty.Add("DIKEMBALIKAN_fieldheadercolumn",true);
        smarty.Add("DIKEMBALIKAN_fieldcolumn",true);
        smarty.Add("DIKEMBALIKAN_fieldfootercolumn",true);
        smarty.Add("KODESTATUSPBJ_fieldheadercolumn",true);
        smarty.Add("KODESTATUSPBJ_fieldcolumn",true);
        smarty.Add("KODESTATUSPBJ_fieldfootercolumn",true);
        	
                display_grid = allow_search && rowsfound;

        smarty.Add("asearch_link",allow_search);
        smarty.Add("asearchlink_attrs","onclick=\"window.location.href='PBJ_search.aspx';return false;\"");
        smarty.Add("import_link",allow_import);
        smarty.Add("importlink_attrs","onclick=\"window.location.href='PBJ_import.aspx';return false;\"");

        smarty.Add("search_records_block",allow_search);
        smarty.Add("searchform",allow_search);
        smarty.Add("searchform_field",allow_search);
        smarty.Add("searchform_option",allow_search);
        smarty.Add("searchform_text",allow_search);
        smarty.Add("searchform_search",allow_search);
        smarty.Add("searchform_showall",allow_search);

        smarty.Add("delete_link",allow_delete);
        smarty.Add("deletelink_attrs","onclick=\"if($('input[@type=checkbox][@checked][@name^=selection]').length && confirm('" + "Do you really want to delete these records?" + "'))frmAdmin.submit(); return false;\"");
        smarty.Add("usermessage",true);
    }

    private void AddLoginAttributes()
    {
                smarty.Add("login_block",true);
        smarty.Add("username",Control.HTMLEncodeSpecialChars(UserName));
        smarty.Add("logoutlink_attrs","onclick=\"window.location.href='login.aspx?a=logout';\"");
    }

    private void AddSearchAttributes()
    {
                if(allow_search)
        {
            	            string searchfor_attrs = "autocomplete=off onkeydown=\"return listenEvent(event,this,'ordinary');\" onkeyup=\"searchSuggest(event,this,'ordinary');\"";
	            if(Search == 0)
	            {
                //	fill in search variables
	            //	field selection
		            if(!string.IsNullOrEmpty(SearchField))
                    {
			            smarty.Add(Control.GoodFieldName(SearchField) + "_searchfieldoption","selected");
                    }
	            // search type selection
		            smarty.Add(Control.GoodFieldName(SearchOption) + "_searchtypeoption", "selected");
	            }
                searchfor_attrs += " value=\"" + Control.HTMLEncodeSpecialChars(SearchFor) + "\"";
	            searchfor_attrs += " name=\"ctlSearchFor\" id=\"ctlSearchFor\"";
	            smarty.Add("searchfor_attrs",searchfor_attrs);
	            smarty.Add("searchbutton_attrs","onClick=\"javascript: RunSearch();\"");
	            smarty.Add("showallbutton_attrs","onClick=\"javascript: document.forms.frmSearch.a.value = 'showall'; document.forms.frmSearch.submit();\"");
         }
    }

    private void BuildForm()
    {
		string userGroup = "";
	
		//show appropriate menu based on user group
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select distinct kodekelompok from pengguna where KODEPENGGUNA = '"+UserName+"';";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        while (myReader.Read())
            {
				userGroup = myReader.GetValue(0).ToString();
            }
        myReader.Close();

        //	add grid data
	    for(int i = 0; i < collection.Count; ++ i)
        {
		    IDictionary row=array();
    		    if(!shade)
		    {
			    row["rowattrs"]="class=shade onmouseover=\"this.className = 'rowselected';\" onmouseout=\"this.className = 'shade';\"";
			    shade=true;
		    }
		    else
		    {
			    row["rowattrs"]="onmouseover=\"this.className = 'rowselected';\" onmouseout=\"this.className = '';\"";
			    shade=false;
		    }
		    row["grid_record"]=array();
            IDictionary data = (IDictionary)row["grid_record"];
            data["data"] = list();
            int col=1;
            row["rowattrs"] +=" rowid=\"" + i.ToString() + "\"";
            bool beforeProcessRowListResult = true;
                        if(beforeProcessRowListResult)
            {
		        for(col=1;collection != null && collection.Count !=0 && recno <= collection.Count && col<=colsonpage;col++)
		        {
			        IDictionary record=array();
                    object totalValue = null;
                                        bool editable = false;
                	                editable=true;
	                record["edit_link"]=editable;
	                record["inlineedit_link"]=editable;
	                record["view_link"]=true;
	                record["copy_link"]=true;
	                record["checkbox"]=editable;
                
                //	detail tables
                string masterquery;
                bool dpreview=true;
                string masterID = null;
			    masterquery = "mastertable=PBJ";
			    masterquery += "&masterkey1=" + this.Server.UrlEncode(collection[i].KODEPBJ.ToString());
                masterID = collection[i].KODEPBJ.ToString();
                //detail tables
	            record["KELENGKAPANPBJ_dtable_link"]=true;
	            //record["KELENGKAPANPBJ_dtablelink_attrs"]="onmouseover=\"RollDetailsLink.showPopup(this,'KELENGKAPANPBJ_detailspreview.aspx'+this.href.substr(this.href.indexOf('?')));\" onmouseout=\"RollDetailsLink.hidePopup();\" href=\"KELENGKAPANPBJ_list.aspx?" + masterquery + "\" id=\"master_KELENGKAPANPBJ" + recno + "\"";

                dpreview=true;
                int KELENGKAPANPBJ_cnt = 0;
                foreach (Data.KELENGKAPANPBJ details in KELENGKAPANPBJ_detailCollection)
                {
                    if (masterID != null && details.KODEBPJ.ToString() == masterID)
                    {
                        ++KELENGKAPANPBJ_cnt;
                    }
                }
	            	            if(KELENGKAPANPBJ_cnt > 0)
                {
		            record["KELENGKAPANPBJ_childcount"]=true;
                }
	            else
                {
		            dpreview=false;
                }
	            record["KELENGKAPANPBJ_childnumber"]=KELENGKAPANPBJ_cnt;
	                	        
                record["KELENGKAPANPBJ_dtablelink_attrs"]="href=\"KELENGKAPANPBJ_list.aspx?" + masterquery + "\" id=\"master_KELENGKAPANPBJ" + recno.ToString() + "\"";
                if(dpreview)
	            {
	            		            record["KELENGKAPANPBJ_dtablelink_attrs"] +=" onmouseover=\"RollDetailsLink.showPopup(this,'KELENGKAPANPBJ_detailspreview.aspx'+this.href.substr(this.href.indexOf('?')));\" onmouseout=\"RollDetailsLink.hidePopup();\"";
	                            }
			    masterquery = "mastertable=PBJ";
			    masterquery += "&masterkey1=" + this.Server.UrlEncode(collection[i].KODEPBJ.ToString());
                masterID = collection[i].KODEPBJ.ToString();
                //detail tables
	            record["ASSIGNMENT_dtable_link"]=true;
	            //record["ASSIGNMENT_dtablelink_attrs"]="onmouseover=\"RollDetailsLink.showPopup(this,'ASSIGNMENT_detailspreview.aspx'+this.href.substr(this.href.indexOf('?')));\" onmouseout=\"RollDetailsLink.hidePopup();\" href=\"ASSIGNMENT_list.aspx?" + masterquery + "\" id=\"master_ASSIGNMENT" + recno + "\"";

                dpreview=true;
                int ASSIGNMENT_cnt = 0;
                foreach (Data.ASSIGNMENT details in ASSIGNMENT_detailCollection)
                {
                    if (masterID != null && details.KODEPBJ.ToString() == masterID)
                    {
                        ++ASSIGNMENT_cnt;
                    }
                }
	            	            if(ASSIGNMENT_cnt > 0)
                {
		            record["ASSIGNMENT_childcount"]=true;
                }
	            else
                {
		            dpreview=false;
                }
	            record["ASSIGNMENT_childnumber"]=ASSIGNMENT_cnt;
	                	        
                record["ASSIGNMENT_dtablelink_attrs"]="href=\"ASSIGNMENT_list.aspx?" + masterquery + "\" id=\"master_ASSIGNMENT" + recno.ToString() + "\"";
                if(dpreview)
	            {
	            		            record["ASSIGNMENT_dtablelink_attrs"] +=" onmouseover=\"RollDetailsLink.showPopup(this,'ASSIGNMENT_detailspreview.aspx'+this.href.substr(this.href.indexOf('?')));\" onmouseout=\"RollDetailsLink.hidePopup();\"";
	                            }

            //	key fields
	            string keyblock="";
	            string editlink="";
	            string copylink="";
	            string keylink="";
	            keyblock +=  this.Server.UrlEncode(collection[i].KODEPBJ.ToString());
	            editlink += "editid1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEPBJ.ToString()));
	            copylink +="copyid1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEPBJ.ToString()));
	            keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEPBJ.ToString()));

	            record["editlink_attrs"]="href=\"PBJ_edit.aspx?" + editlink + "\" id=\"editlink" + recno.ToString() + "\"";
	            record["inlineeditlink_attrs"]= "href=\"PBJ_edit.aspx?" + editlink + "\" onclick=\"return inlineEdit('" + recno.ToString() + "','" + editlink + "');\" id=\"ieditlink" + recno.ToString() + "\"";
	            record["copylink_attrs"]="href=\"PBJ_add.aspx?" + copylink + "\" id=\"copylink" + recno.ToString() + "\"";
	            record["viewlink_attrs"]="href=\"tanda_terima.aspx?usrgrp="  + userGroup + "&action=prn&"  + editlink + "\" id=\"viewlink" + recno.ToString() + "\"";
	            record["checkbox_attrs"]="name=\"selection[]\" value=\"" + keyblock + "\" id=\"check" + recno.ToString() + "\"";

            string value;
            value = string.Empty;
    //	KODEPBJ - 
            Control control_KODEPBJ = new Control("KODEPBJ", collection[i].KODEPBJ, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_KODEPBJ.GetData();
			    value = control_KODEPBJ.ProcessLargeText(value,"field=KODEPBJ" + keylink,"",MODE.MODE_LIST);
			    record["KODEPBJ_value"]=value;
            value = string.Empty;
    //	NAMAKEGIATAN - 
            Control control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", collection[i].NAMAKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_NAMAKEGIATAN.GetData();
			    value = control_NAMAKEGIATAN.ProcessLargeText(value,"field=NAMAKEGIATAN" + keylink,"",MODE.MODE_LIST);
			    record["NAMAKEGIATAN_value"]=value;
            value = string.Empty;
    //	NAMAPAKET - 
            Control control_NAMAPAKET = new Control("NAMAPAKET", collection[i].NAMAPAKET, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_NAMAPAKET.GetData();
			    value = control_NAMAPAKET.ProcessLargeText(value,"field=NAMAPAKET" + keylink,"",MODE.MODE_LIST);
			    record["NAMAPAKET_value"]=value;
            value = string.Empty;
    //	KODESKPD - 
            Control control_KODESKPD = new Control("KODESKPD", collection[i].KODESKPD, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        //func.PopulateLookupFields(control_KODESKPD.FieldInfo);
			    value=func.GetLookupValue(control_KODESKPD.FieldInfo);
                control_KODESKPD.Value = value;
			    record["KODESKPD_value"]=value;
            value = string.Empty;
    //	PPK - 
            Control control_PPK = new Control("PPK", collection[i].PPK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        //func.PopulateLookupFields(control_PPK.FieldInfo);
			    value=func.GetLookupValue(control_PPK.FieldInfo);
                control_PPK.Value = value;
			    record["PPK_value"]=value;
            value = string.Empty;
    //	PPTK - 
            Control control_PPTK = new Control("PPTK", collection[i].PPTK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        //func.PopulateLookupFields(control_PPTK.FieldInfo);
			    value=func.GetLookupValue(control_PPTK.FieldInfo);
                control_PPTK.Value = value;
			    record["PPTK_value"]=value;
            value = string.Empty;
    //	KODEJENISKEGIATAN - 
            Control control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", collection[i].KODEJENISKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        //func.PopulateLookupFields(control_KODEJENISKEGIATAN.FieldInfo);
			    value=func.GetLookupValue(control_KODEJENISKEGIATAN.FieldInfo);
                control_KODEJENISKEGIATAN.Value = value;
			    record["KODEJENISKEGIATAN_value"]=value;
            value = string.Empty;
    //	TANGGALPENGAJUAN - Short Date
            Control control_TANGGALPENGAJUAN = new Control("TANGGALPENGAJUAN", collection[i].TANGGALPENGAJUAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_TANGGALPENGAJUAN.GetData();
			    value = control_TANGGALPENGAJUAN.ProcessLargeText(value,"field=TANGGALPENGAJUAN" + keylink,"",MODE.MODE_LIST);
			    record["TANGGALPENGAJUAN_value"]=value;
            value = string.Empty;
    //	TANGGALKEMBALI - Short Date
            Control control_TANGGALKEMBALI = new Control("TANGGALKEMBALI", collection[i].TANGGALKEMBALI, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_TANGGALKEMBALI.GetData();
			    value = control_TANGGALKEMBALI.ProcessLargeText(value,"field=TANGGALKEMBALI" + keylink,"",MODE.MODE_LIST);
			    record["TANGGALKEMBALI_value"]=value;
            value = string.Empty;
    //	LENGKAP - 
            Control control_LENGKAP = new Control("LENGKAP", collection[i].LENGKAP, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_LENGKAP.GetData();
			    value = control_LENGKAP.ProcessLargeText(value,"field=LENGKAP" + keylink,"",MODE.MODE_LIST);
			    record["LENGKAP_value"]=value;
            value = string.Empty;
    //	DIKEMBALIKAN - 
            Control control_DIKEMBALIKAN = new Control("DIKEMBALIKAN", collection[i].DIKEMBALIKAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_DIKEMBALIKAN.GetData();
			    value = control_DIKEMBALIKAN.ProcessLargeText(value,"field=DIKEMBALIKAN" + keylink,"",MODE.MODE_LIST);
			    record["DIKEMBALIKAN_value"]=value;
            value = string.Empty;
    //	KODESTATUSPBJ - 
            Control control_KODESTATUSPBJ = new Control("KODESTATUSPBJ", collection[i].KODESTATUSPBJ, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        //func.PopulateLookupFields(control_KODESTATUSPBJ.FieldInfo);
			    value=func.GetLookupValue(control_KODESTATUSPBJ.FieldInfo);
                control_KODESTATUSPBJ.Value = value;
			    record["KODESTATUSPBJ_value"]=value;
			    record["show"]=true;
                string span = string.Empty;
                    			    if(col<colsonpage)
				    record["endrecord_block"]=true;

                data = (IDictionary)row["grid_record"];
                IList rec_list = (IList)data["data"];
                rec_list.Add(record);
			    recno++;
		    }
		    while(col<=colsonpage)
		    {
			    IDictionary record = array();
			    if(col<colsonpage)
				    record["endrecord_block"]=true;
			    data = (IDictionary)row["grid_record"];
                IList rec_list = (IList)data["data"];
                rec_list.Add(record);
			    col++;
		    }
		    IList row_list = (IList)rowinfo["data"];
            row_list.Add(row);
	    }
    }
	smarty.Add("grid_row",rowinfo);

        
    }

    bool IsNullableType(Type theType)
    {
        return (theType.IsGenericType && theType.
          GetGenericTypeDefinition().Equals
          (typeof(Nullable<>)));
    }

    private void InlineAdd()
    {
            }

    private void GetSearchRows()
    {
        string oCol = OwnerColumn;
        string oID = OwnerID;
        IDictionary<string, object> par = new Dictionary<string, object>();
                if(func.IsAdminUser() || func.GetsAdvSecurityMethod(strTableName) == "2") 
        {
            oCol = string.Empty;
            oID = string.Empty;
        }
        if(string.IsNullOrEmpty(SearchField))
        {
            if(par.Count > 0)
            {
                collection = controller.FetchByAllParameters(SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID, par);
                numrows = controller.FetchByAllParametersCount(SearchOption, SearchFor, oCol, oID, par);
            }
            else
            {
                collection = controller.FetchByAllParameters(SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchByAllParametersCount(SearchOption, SearchFor, oCol, oID);
            }
        }
        else
        {
            if(par.Count > 0)
            {
                collection = controller.FetchByParameter(SearchField, SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID, par);
                numrows = controller.FetchByParameterCount(SearchField, SearchOption, SearchFor, oCol, oID, par);
            }
            else
            {
                collection = controller.FetchByParameter(SearchField, SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchByParameterCount(SearchField, SearchOption, SearchFor, oCol, oID);
            }
        }
    }

    private void GetAdvancedSearchRows()
    {
        string[] asearchfield = this.Request.Form.GetValues("asearchfield[]");
        if(asearchfield == null)
        {
            asearchfield = Asearchfield;
        }
        IDictionary<string, object> par = new Dictionary<string, object>();
        string oCol = OwnerColumn;
        string oID = OwnerID;
                if(func.IsAdminUser() || func.GetsAdvSecurityMethod(strTableName) == "2") 
        {
            oCol = string.Empty;
            oID = string.Empty;
        }
        if(par.Count > 0)
        {
            collection = controller.FetchForAdvancedSearch(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID, par);

        numrows = controller.FetchForAdvancedSearchCount(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID, par);
        }
        else
        {
        collection = controller.FetchForAdvancedSearch(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID);

        numrows = controller.FetchForAdvancedSearchCount(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID);
        }
    }

    private void GetAllRows()
    {
        string oCol = OwnerColumn;
        string oID = OwnerID;
                if(func.IsAdminUser() || func.GetsAdvSecurityMethod(strTableName) == "2") 
        {
            oCol = string.Empty;
            oID = string.Empty;
        }
        {
            collection = controller.FetchAllPaged((PageNumber - 1) * PageSize, PageSize, OrderBy, oCol, oID);
            numrows = controller.FetchAllCount(oCol, oID);
        }
    }

    private void GetData()
    {
        bool bNoRecordsFirstPage = false;
        
        if (bNoRecordsFirstPage)
        {
            collection = new Data.PBJCollection();
            numrows = 0;
        }
        else
        {
            if (Search == 0)
            {
                GetSearchRows();
            }
            else if(Search == 2)
            {
                GetAdvancedSearchRows();
            }
            else
            {
                GetAllRows();
            }
        }

        
        Data.KELENGKAPANPBJController KELENGKAPANPBJ_detailController = new Data.KELENGKAPANPBJController();
        //foreach @TABLE.arrKeyFields as @tk
                ArrayList KELENGKAPANPBJ_masterids = new ArrayList();
        for(int i = 0; i < collection.Count; ++ i)
        {
            try{
            KELENGKAPANPBJ_masterids.Add(collection[i].KODEPBJ.ToString());
            }
            catch
            {
            }
        }
        KELENGKAPANPBJ_detailCollection = KELENGKAPANPBJ_detailController.FetchForDetails("KODEBPJ", KELENGKAPANPBJ_masterids.ToArray(), OwnerColumn, OwnerID);
        Data.ASSIGNMENTController ASSIGNMENT_detailController = new Data.ASSIGNMENTController();
        //foreach @TABLE.arrKeyFields as @tk
                ArrayList ASSIGNMENT_masterids = new ArrayList();
        for(int i = 0; i < collection.Count; ++ i)
        {
            try{
            ASSIGNMENT_masterids.Add(collection[i].KODEPBJ.ToString());
            }
            catch
            {
            }
        }
        ASSIGNMENT_detailCollection = ASSIGNMENT_detailController.FetchForDetails("KODEPBJ", ASSIGNMENT_masterids.ToArray(), OwnerColumn, OwnerID);
        //	save SQL for use in "Export" and "Printer-friendly" pages
        //	select and display records
        if(allow_search)
        {
            //	 Pagination:
	        if(numrows == 0)
	        {
		        rowsfound=false;
		        message="No records found";
		        IDictionary message_block=array();
		        message_block["begin"]="<span name=\"notfound_message\">";
		        message_block["end"]="</span>";
		        smarty.Add("message_block", message_block);
		        smarty.Add("message", message);
	        }
	        else
	        {
		        rowsfound=true;
		        int maxRecords = numrows;
		        smarty.Add("records_found",numrows);
		        int maxpages=(int)Math.Ceiling((double)maxRecords/PageSize);
		        if(mypage > maxpages)
                {
			        mypage = maxpages;
                }
		        if( mypage < 1) 
                {
			        mypage=1;
                }
		        smarty.Add("page", mypage);
		        smarty.Add("maxpages", maxpages);
        		

                //	write pagination
	            if(maxpages > 1)
	            {
		            smarty.Add("pagination_block",true);
                    string pagination = string.Format("<script language=\"JavaScript\">WritePagination({0},{1});function GotoPage(nPageNumber)", mypage, maxpages);
                    pagination += "{window.location='PBJ_list.aspx?goto=' + nPageNumber;}</script>";
		            smarty.Add("pagination", pagination);
	            }
            }

            //	hide colunm headers if needed
	        int recordsonpage = numrows-(mypage-1)*PageSize;
	        if(recordsonpage > PageSize)
            {
	            recordsonpage = PageSize;
            }
	        colsonpage = 1;
	        if(colsonpage > recordsonpage)
            {
		        colsonpage = recordsonpage;
            }
	        if(colsonpage < 1)
            {
		        colsonpage = 1;
            }
        }
    }
    private void ProcessPermissions()
    {
        bool createmenu = false;
        if(createmenu)
        {
	        smarty.Add("menu_block", true);
        }

                if (AccessLevel == Control.ACCESS_LEVEL_GUEST)
        {
            allow_add = BaseCheckSecurity(UserName, "A");
            allow_delete = BaseCheckSecurity(UserName, "D");
            allow_edit = BaseCheckSecurity(UserName, "E");
            allow_search = BaseCheckSecurity(UserName, "S");
            allow_export = BaseCheckSecurity(UserName, "P");
            allow_import = BaseCheckSecurity(UserName, "I");
        }
        else
        {
        allow_add = BaseCheckSecurity(User.GetUserOwnerID(strTableName), "A");
        allow_delete = BaseCheckSecurity(User.GetUserOwnerID(strTableName), "D");
        allow_edit = BaseCheckSecurity(User.GetUserOwnerID(strTableName), "E");
        allow_search = BaseCheckSecurity(User.GetUserOwnerID(strTableName), "S");
        allow_export = BaseCheckSecurity(User.GetUserOwnerID(strTableName), "P");
        allow_import = BaseCheckSecurity(User.GetUserOwnerID(strTableName), "I");
        }
    }

        private void DeleteRecord()
    {
        // delete record
        IList selected_recs = new List<string>();
        string[] mdelete = this.Request.Params.GetValues("mdelete[]");
        string[] selection = this.Request.Params.GetValues("selection[]");
        if (mdelete != null)
        {
            for(int ind = 0; ind < mdelete.Length; ++ ind)
	        {
                string[] indicies;
                indicies = this.Request.Params.GetValues("mdelete1");
                selected_recs.Add(indicies[ind]);
	        }
        }
        else if(selection != null)
        {
	        for(int ind = 0; ind < selection.Length; ++ ind)
	        {
                selected_recs.Add(selection[ind]);
	        }
        }
        
        foreach(string val in selected_recs)
        {
        
            bool abortDeleting = false;
                        if(!abortDeleting)
            {
                                if(1 > 1)
                {
                    string[] arr = val.ToString().Split(new char[]{'&'});

                
                    controller.Delete(
                         
                                                                                        Convert.ToString(this.Server.UrlDecode(arr[0]).Trim())

                    );
                }
                else
                {
                                    Data.PBJ.Destroy(val);
                }
                            }
        }

        if(selected_recs.Count > 0)
        {
	                }
    }


    private void ProcessSessionVariables()
    {
        //	process session variables
        //	order by
        int order_ind = -1;
        int numrows = 0;

        smarty.Add("KODEPBJ_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aKODEPBJ\"");
        smarty.Add("KODEPBJ_fieldheader", true);
        smarty.Add("NAMAKEGIATAN_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aNAMAKEGIATAN\"");
        smarty.Add("NAMAKEGIATAN_fieldheader", true);
        smarty.Add("NAMAPAKET_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aNAMAPAKET\"");
        smarty.Add("NAMAPAKET_fieldheader", true);
        smarty.Add("KODESKPD_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aKODESKPD\"");
        smarty.Add("KODESKPD_fieldheader", true);
        smarty.Add("PPK_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aPPK\"");
        smarty.Add("PPK_fieldheader", true);
        smarty.Add("PPTK_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aPPTK\"");
        smarty.Add("PPTK_fieldheader", true);
        smarty.Add("KODEJENISKEGIATAN_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aKODEJENISKEGIATAN\"");
        smarty.Add("KODEJENISKEGIATAN_fieldheader", true);
        smarty.Add("TANGGALPENGAJUAN_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aTANGGALPENGAJUAN\"");
        smarty.Add("TANGGALPENGAJUAN_fieldheader", true);
        smarty.Add("TANGGALKEMBALI_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aTANGGALKEMBALI\"");
        smarty.Add("TANGGALKEMBALI_fieldheader", true);
        smarty.Add("LENGKAP_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aLENGKAP\"");
        smarty.Add("LENGKAP_fieldheader", true);
        smarty.Add("DIKEMBALIKAN_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aDIKEMBALIKAN\"");
        smarty.Add("DIKEMBALIKAN_fieldheader", true);
        smarty.Add("KODESTATUSPBJ_orderlinkattrs", "href=\"PBJ_list.aspx?orderby=aKODESTATUSPBJ\"");
        smarty.Add("KODESTATUSPBJ_fieldheader", true);
        string tmp_orderby = this.Request["orderby"];
        if(tmp_orderby != null)
        {
	        string order_field = tmp_orderby.Substring(1);
	        string order_dir = tmp_orderby.Substring(0,1);
	        order_ind = builder.Tables[strTableName].Fields[order_field].Index;

	        string dir = "a";
	        string img = "down";

	        if(order_dir == "a")
	        {
		        dir = "d";
		        img = "up";
	        }

	        IDictionary dict = new Dictionary<object, object>();
            dict.Add("end", "<img src=\"images/" + img + ".gif\" border=0/>");
            smarty[Control.GoodFieldName(order_field) + "_fieldheader"] = dict;
	        smarty[Control.GoodFieldName(order_field) + "_orderlinkattrs"] = "href=\"PBJ_list.aspx?orderby=" + dir + Control.GoodFieldName(order_field) + "\"";

	        if(order_ind > 0)
	        {
		        if(order_dir == "a")
                {
			        OrderBy = builder.Tables[strTableName].Fields[order_field].Name + " asc";
                }
		        else
                {
			        OrderBy = builder.Tables[strTableName].Fields[order_field].Name + " desc";
                }
	        }
        }

        //	page number
        mypage = PageNumber;
        if(mypage == 0)
        {
	        mypage = 1;
        }

        //	page size
        if(PageSize == 0)
        {
	        PageSize = gPageSize;
        }

        smarty.Add("rpp" + PageSize.ToString() + "_selected","selected");
    }

    private void Body()
    {
        bodyDict["begin"] = GetIncludes() + 
        "<form name=\"frmSearch\" method=\"GET\" action=\"PBJ_list.aspx\">" + 
        "<input type=\"Hidden\" name=\"a\" value=\"search\">" + 
        "<input type=\"Hidden\" name=\"value\" value=\"1\">" + 
        "<input type=\"Hidden\" name=\"SearchFor\" value=\"\">" + 
        "<input type=\"Hidden\" name=\"SearchOption\" value=\"\">" + 
        "<input type=\"Hidden\" name=\"SearchField\" value=\"\">" + 
        "</form>";
    }

    private string GetIncludes()
    {
        StringBuilder includes = new StringBuilder();

        
        
        includes.Append("<script type=\"text/javascript\" src=\"include/jquery.js\"></script>\r\n");
        includes.Append("<script type=\"text/javascript\" src=\"include/ajaxsuggest.js\"></script>\r\n");
        
        includes.Append("<script type=\"text/javascript\" src=\"include/jsfunctions.js\">" +
        "</script>\n" + 
        "<script type=\"text/javascript\">" +
        "\nvar bSelected=false;" +
        "\nwindow.TEXT_FIRST = \"" + "First" + "\";" + 
        "\nwindow.TEXT_PREVIOUS = \"" + "Previous" + "\";" + 
        "\nwindow.TEXT_NEXT = \"" + "Next" + "\";" + 
        "\nwindow.TEXT_LAST = \"" + "Last" + "\";" + 
        "\nwindow.TEXT_PLEASE_SELECT='" + Control.jsreplace("Please select") + "';" + 
        "\nwindow.TEXT_SAVE='" + Control.jsreplace("Save") + "';" + 
        "\nwindow.TEXT_CANCEL='" + Control.jsreplace("Cancel") + "';" + 
        "\nwindow.TEXT_INLINE_ERROR='" + Control.jsreplace("Error occurred") + "';" + 
        "\nwindow.TEXT_PREVIEW='" + Control.jsreplace("preview") + "';" +
        "\nwindow.TEXT_HIDE='" + Control.jsreplace("hide") + "';" +
        "\nwindow.TEXT_LOADING='" + Control.jsreplace("loading") + "';" +
        "\nvar locale_dateformat = '" + Control.locale_info("LOCALE_IDATE", smarty) + "';" + 
        "\nvar locale_datedelimiter = \"" + Control.locale_info("LOCALE_SDATE", smarty) + "\";" + 
        "\nvar bLoading=false;\r\n");

	    includes.Append("var INLINE_EDIT_TABLE='PBJ_edit.aspx';\r\n");
	    includes.Append("var INLINE_ADD_TABLE='PBJ_add.aspx';\r\n");
	    includes.Append("var INLINE_VIEW_TABLE='PBJ_view.aspx';\r\n");
	    includes.Append("var SUGGEST_TABLE='PBJ_searchsuggest.aspx';\r\n");
	    includes.Append("var MASTER_PREVIEW_TABLE='PBJ_masterpreview.aspx';\r\n");
        includes.Append("\n</script>\n");
        includes.Append("<div id=\"search_suggest\"></div>");
        includes.Append("<div id=\"master_details\" onmouseover=\"RollDetailsLink.showPopup();\" onmouseout=\"RollDetailsLink.hidePopup();\"></div>");
        
        return includes.ToString();
    }

    private void CleanUpSession()
    {
        // clean up session for the table
        if(this.Request.QueryString.Count == 0 && this.Request.Form.Count == 0)
        {
            List<string> sessionKeys = new List<string>();
            foreach(string key in this.Session.Keys)
            {
                if(key.StartsWith(strTableName + "_"))
                {
                    // if key belongs to the table put in temporary list
                    sessionKeys.Add(key);
                }
            }

            // remove entries for the table
            foreach(string key in sessionKeys)
            {
                this.Session.Remove(key);
            }
        }
    }

    private IDictionary array()
    {
        return new Hashtable();
    }

    private IList list()
    {
        return new List<object>();
    }

    private void RenewSessionParams()
    {
        if(RequestAction.CompareTo("showall") == 0 || string.IsNullOrEmpty(RequestAction))
        {
            Search = -1;
            SearchFor = string.Empty;
            CleanUpSession();
        }
        else if(RequestAction.CompareTo("search") == 0)
        {
            SearchField = this.Request["SearchField"];
	        SearchOption = this.Request["SearchOption"];
	        SearchFor = this.Request["SearchFor"];
	        if(string.IsNullOrEmpty(SearchFor) || this.Request["SearchOption"] == "Empty")
            {
		        Search = 1;
            }
	        else
            {
				//manipulate the search for value, if search field = skpd/ppk/pptk and search option = equals
				if (SearchField=="KODESKPD" && SearchOption=="Contains") {
					SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
					SearchFor = SearchFor.Replace("+", " ");
					string ssql = "select distinct kodeskpd from skpd where deskripsi like '%"+SearchFor+"%';";
					SqlCommand myCommand = new SqlCommand();
					myCommand.CommandText = ssql;
					myCommand.CommandType = CommandType.Text;
					myCommand.Connection = myConnection;
					myConnection.Open();
					SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
					while (myReader.Read())
						{
							SearchFor = myReader.GetValue(0).ToString();
						}
					myReader.Close();
				} else if((SearchField=="PPK" || SearchField=="PPTK") && SearchOption=="Contains") {
					SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
					string ssql = "select distinct LEFT(nip,16) from aktor where NAMA like '%"+SearchFor+"%' ";
					if (SearchField=="PPTK") {
						ssql = ssql + " and kodetipe = 'PPTK' ";
					} else {
						ssql = ssql + " and kodetipe = 'PPK' ";
					}
					SqlCommand myCommand = new SqlCommand();
					myCommand.CommandText = ssql;
					myCommand.CommandType = CommandType.Text;
					myCommand.Connection = myConnection;
					myConnection.Open();
					SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
					while (myReader.Read())
						{
							SearchFor = myReader.GetValue(0).ToString();
						}
					myReader.Close();
				}
				//end of manipulation
		        Search = 0;
            }
	        PageNumber = 1;
        }
        else if(RequestAction.CompareTo("advsearch") == 0)
        {
            Asearchnot = new Dictionary<string, bool>();
	        Asearchopt = new Dictionary<string, string>();
	        Asearchfor = new Dictionary<string, string>();
	        Asearchfor2 = new Dictionary<string, string>();
            SearchFor = null;
	        int tosearch = 0;
	        string[] asearchfield = this.Request.Form.GetValues("asearchfield[]");
            Asearchfield = asearchfield;
	        Asearchtype = this.Request.Form["type"];
	        if(Asearchtype == null)
            {
		        Asearchtype = "and";
            }
            foreach(string field in asearchfield)
	        {
		        string gfield = Control.GoodFieldName(field);
		        string asopt = this.Request.Form["asearchopt_" + gfield];
		        string[] value1 = this.Request.Form.GetValues("value_" + field);
		        string type = this.Request.Form["type_" + gfield];
		        string value2 = this.Request.Form["value1_" + gfield];
		        string not = this.Request.Form["not_" + gfield];
		        if(value1 != null || asopt == "Empty")
		        {
			        tosearch = 1;
			        Asearchopt[field] = asopt;
			        if(value1.Length == 1)
                    {
				        Asearchfor[field] = value1[0];
                    }
			        else
                    {
				        Asearchfor[field] = string.Join("",value1);
                    }
			        Asearchfortype[field] = type;
			        if(value2 != null)
                    {
				        Asearchfor2[field] = value2;
                    }
			        Asearchnot[field] = (not == "on");
		        }
	        }

            if(tosearch == 1)
            {
		        Search = 2;
            }
	        else
            {
		        Search = 0;
            }
            PageNumber = 1;
        }
    }

    
    
    private void ProcessRequest()
    {
        // clean up session for the table
        CleanUpSession();
        RenewSessionParams();
                
        if(!string.IsNullOrEmpty(this.Request["pagesize"]))
        {
            int size = 0;
            if(int.TryParse(this.Request["pagesize"], out size))
            {
	            PageSize = size;
            }
	        PageNumber = 1;
        }

        if(!string.IsNullOrEmpty(this.Request["goto"]))
        {
	        PageNumber = int.Parse(this.Request["goto"].ToString());
        }
    }

        private bool CheckSecurity()
    {
        if(string.IsNullOrEmpty(UserName))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
	        return false;
        }
                if(!BaseCheckSecurity(OwnerID, "Search") && !BaseCheckSecurity(OwnerID, "Add"))
        {
                    {
	            this.Response.Write("<p>" + "You don't have permissions to access this table" + " <a href=\"login.aspx\">" + "Back to login page" + "</a></p>");
            }
	        return false;
        }
        return true;
    }


    // helper property makes code more readable
    // removes ugliness of dealing with checking for null

    private int PageSize
    {
        get
        {
            return (int)SessionPropertyGet(strTableName + "_pagesize", gPageSize);
        }
        set
        {
            SessionPropertySet(strTableName + "_pagesize", value);
        }
    }

    private int PageNumber
    {
        get
        {
            return (int)SessionPropertyGet(strTableName + "_pagenumber", 1);
        }
        set
        {
            SessionPropertySet(strTableName + "_pagenumber", value);
        }
    }

    private string GoTo
    {
        get
        {
            return (string)SessionPropertyGet(strTableName + "goto", string.Empty);
        }
        set
        {
            SessionPropertySet(strTableName + "goto", value);
        }
    }

    private string SearchFor
    {
        get
        {
            return (string)SessionPropertyGet("SearchFor", string.Empty);
        }
        set
        {
            SessionPropertySet("SearchFor", value);
        }
    }

    private string SearchOption
    {
        get
        {
            return (string)SessionPropertyGet("SearchOption", string.Empty);
        }
        set
        {
            SessionPropertySet("SearchOption", value);
        }
    }

    private string SearchField
    {
        get
        {
            return (string)SessionPropertyGet("SearchField", string.Empty);
        }
        set
        {
            SessionPropertySet("SearchField", value);
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
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchopt", array());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchopt", value);
        }
    }

    private IDictionary<string, string> Asearchfor
    {
        get
        {
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchfor", array());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfor", value);
        }
    }

    private string[] Asearchfield
    {
        get
        {
            return (string[])SessionPropertyGet(strTableName + "_asearchfield", null);
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfield", value);
        }
    }

    private IDictionary Asearchfortype
    {
        get
        {
            return (IDictionary)SessionPropertyGet(strTableName + "_asearchfortype", array());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfortype", value);
        }
    }

    private IDictionary<string, string> Asearchfor2
    {
        get
        {
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchfor2", array());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfor2", value);
        }
    }

    private IDictionary<string, bool> Asearchnot
    {
        get
        {
            return (IDictionary<string, bool>)SessionPropertyGet(strTableName + "_asearchnot", array());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchnot", value);
        }
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
}

