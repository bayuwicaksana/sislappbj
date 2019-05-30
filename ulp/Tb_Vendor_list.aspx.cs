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
using SubSonic;
#endregion

public partial class CTb_Vendor_List : AspNetRunnerPage 
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
        bool allow_Tb_Login;
        bool allow_Tb_Kecamatan;
        bool allow_Tb_Kelurahan;
        bool allow_Tb_SKPD;
        bool allow_Tb_Status;
        bool allow_Tb_Tipe_Aktor;
        bool allow_Tb_Jabatan;
        bool allow_Tb_Pertanyaan;
        bool allow_Tb_Vendor;
        bool allow_Tb_Aktor;
        bool allow_Tb_Kontrak;
        bool allow_Tb_Kegiatan;
        bool allow_Tb_Paket_Pekerjaan;
        bool allow_VIEW_KONSTRUKSI;
        bool allow_VIEW_KONSULTASI;
        bool allow_VIEW_PENGADAAN;
        bool allow_Tb_Jenis_Kegiatan;
        bool allow_VIEW_JENIS_LAINNYA;
    int colsonpage;
    int mypage;
    bool shade;
    IDictionary rowinfo;
    int recno = 1;
    int gPageSize = 20;
    string id;
    Smarty.MODE mode = MODE.MODE_LIST_SIMPLE;

    Data.Tb_VendorController controller = new Data.Tb_VendorController();
    Data.Tb_VendorCollection collection;

    //Data.Tb_KontrakCollection Tb_Kontrak_detailCollection;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.Tb_Vendor";
        strTableNameLocale = "dbo_Tb_Vendor";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
        string output = string.Empty;
                        if (User != null && !string.IsNullOrEmpty("Tb_Vendor"))
            {
                OwnerColumn = func.GetOwnerIDField("Tb_Vendor");
            }
                        allow_Tb_Login = func.CheckUserPermissions("dbo.Tb_Login", "SA");
                        allow_Tb_Kecamatan = func.CheckUserPermissions("dbo.Tb_Kecamatan", "SA");
                        allow_Tb_Kelurahan = func.CheckUserPermissions("dbo.Tb_Kelurahan", "SA");
                        allow_Tb_SKPD = func.CheckUserPermissions("dbo.Tb_SKPD", "SA");
                        allow_Tb_Status = func.CheckUserPermissions("dbo.Tb_Status", "SA");
                        allow_Tb_Tipe_Aktor = func.CheckUserPermissions("dbo.Tb_Tipe_Aktor", "SA");
                        allow_Tb_Jabatan = func.CheckUserPermissions("dbo.Tb_Jabatan", "SA");
                        allow_Tb_Pertanyaan = func.CheckUserPermissions("dbo.Tb_Pertanyaan", "SA");
                        allow_Tb_Vendor = func.CheckUserPermissions("dbo.Tb_Vendor", "SA");
                        allow_Tb_Aktor = func.CheckUserPermissions("dbo.Tb_Aktor", "SA");
                        allow_Tb_Kontrak = func.CheckUserPermissions("dbo.Tb_Kontrak", "SA");
                        allow_Tb_Kegiatan = func.CheckUserPermissions("dbo.Tb_Kegiatan", "SA");
                        allow_Tb_Paket_Pekerjaan = func.CheckUserPermissions("dbo.Tb_Paket_Pekerjaan", "SA");
                        allow_VIEW_KONSTRUKSI = func.CheckUserPermissions("dbo.VIEW_KONSTRUKSI", "SA");
                        allow_VIEW_KONSULTASI = func.CheckUserPermissions("dbo.VIEW_KONSULTASI", "SA");
                        allow_VIEW_PENGADAAN = func.CheckUserPermissions("dbo.VIEW_PENGADAAN", "SA");
                        allow_Tb_Jenis_Kegiatan = func.CheckUserPermissions("dbo.Tb_Jenis_Kegiatan", "SA");
                        allow_VIEW_JENIS_LAINNYA = func.CheckUserPermissions("dbo.VIEW_JENIS_LAINNYA", "SA");
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

            output = func.BuildOutput(this, @"~\Tb_Vendor_list.aspx", smarty);
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


        
                smarty.Add("quickjump_attrs","onchange=\"window.location.href=this.options[this.selectedIndex].value;\"");
            }

    private void AddDisplayGridAttributes()
    {
        if(display_grid)
        {
            IDictionary grid_block = array();
            grid_block["begin"] = "<form method=\"POST\" action=\"Tb_Vendor_list.aspx\" name=\"frmAdmin\" id=\"frmAdmin\">" +
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
        smarty.Add("recordspp_attrs","onchange=\"javascript: document.location='Tb_Vendor_list.aspx?pagesize='+this.options[this.selectedIndex].value;\"");
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
	    smarty.Add("printlink_attrs","onclick=\"window.open('Tb_Vendor_print.aspx','wPrint');return false;\"");
	    smarty.Add("printalllink_attrs","onclick=\"window.open('Tb_Vendor_print.aspx?all=1','wPrint');return false;\"");
	    smarty.Add("export_link", allow_export);
	    smarty.Add("exportlink_attrs","onclick=\"window.open('Tb_Vendor_export.aspx','wExport');return false;\"");
    	
	    smarty.Add("printselected_link", allow_export);
	    smarty.Add("printselectedlink_attrs","disptype=\"control1\" onclick=\"" +
	    "if(!$('input[@type=checkbox][@checked][@name^=selection]').length)" +
		"return true;" +
	    "document.forms.frmAdmin.action='Tb_Vendor_print.aspx';" +
	    "document.forms.frmAdmin.target='_blank';" +
	    "document.forms.frmAdmin.submit(); " +
	    "document.forms.frmAdmin.action='Tb_Vendor_list.aspx'; " +
	    "document.forms.frmAdmin.target='_self';\"");
	    smarty.Add("exportselected_link", allow_export);
	    smarty.Add("exportselectedlink_attrs","disptype=\"control1\" onclick=\"" +
	    "if(!$('input[@type=checkbox][@checked][@name^=selection]').length)" +
		    "return true;" +
	    "document.forms.frmAdmin.action='Tb_Vendor_export.aspx';" +
	    "document.forms.frmAdmin.target='_blank';" +
	    "document.forms.frmAdmin.submit(); " +
	    "document.forms.frmAdmin.action='Tb_Vendor_list.aspx';  " +
	    "document.forms.frmAdmin.target='_self';\"");
    	
	    smarty.Add("add_link",allow_add);
        smarty.Add("copy_column",allow_add);
	    smarty.Add("inlineadd_link",allow_add);
	    smarty.Add("addlink_attrs","onClick=\"window.location.href='Tb_Vendor_add.aspx'\"");
	    smarty.Add("inlineaddlink_attrs","href=\"Tb_Vendor_add.aspx\" onclick=\"return inlineAdd(newrecord_id++);\"");

    	
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

 	        smarty.Add("Tb_Kontrak_dtable_column", allow_Tb_Kontrak);


        smarty.Add("KD_VENDOR_fieldheadercolumn",true);
        smarty.Add("KD_VENDOR_fieldcolumn",true);
        smarty.Add("KD_VENDOR_fieldfootercolumn",true);
        smarty.Add("NAMA_fieldheadercolumn",true);
        smarty.Add("NAMA_fieldcolumn",true);
        smarty.Add("NAMA_fieldfootercolumn",true);
        smarty.Add("ALAMAT_fieldheadercolumn",true);
        smarty.Add("ALAMAT_fieldcolumn",true);
        smarty.Add("ALAMAT_fieldfootercolumn",true);
        smarty.Add("NPWP_fieldheadercolumn",true);
        smarty.Add("NPWP_fieldcolumn",true);
        smarty.Add("NPWP_fieldfootercolumn",true);
        smarty.Add("TELEPON_fieldheadercolumn",true);
        smarty.Add("TELEPON_fieldcolumn",true);
        smarty.Add("TELEPON_fieldfootercolumn",true);
        smarty.Add("FAX_fieldheadercolumn",true);
        smarty.Add("FAX_fieldcolumn",true);
        smarty.Add("FAX_fieldfootercolumn",true);
        smarty.Add("EMAIL_fieldheadercolumn",true);
        smarty.Add("EMAIL_fieldcolumn",true);
        smarty.Add("EMAIL_fieldfootercolumn",true);
        smarty.Add("STATUS_fieldheadercolumn",true);
        smarty.Add("STATUS_fieldcolumn",true);
        smarty.Add("STATUS_fieldfootercolumn",true);
        	
                display_grid = allow_search && rowsfound;

        smarty.Add("asearch_link",allow_search);
        smarty.Add("asearchlink_attrs","onclick=\"window.location.href='Tb_Vendor_search.aspx';return false;\"");
        smarty.Add("import_link",allow_import);
        smarty.Add("importlink_attrs","onclick=\"window.location.href='Tb_Vendor_import.aspx';return false;\"");

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
                	                if(allow_export)
                    {
		                record["checkbox"]=true;
                    }

				/*
                //	detail tables
                string masterquery;
                bool dpreview=true;
                string masterID = null;
			    masterquery = "mastertable=Tb_Vendor";
			    masterquery += "&masterkey1=" + this.Server.UrlEncode(collection[i].KD_VENDOR.ToString());
                masterID = collection[i].KD_VENDOR.ToString();
                //detail tables
	            record["Tb_Kontrak_dtable_link"]=true;
	            //record["Tb_Kontrak_dtablelink_attrs"]="onmouseover=\"RollDetailsLink.showPopup(this,'Tb_Kontrak_detailspreview.aspx'+this.href.substr(this.href.indexOf('?')));\" onmouseout=\"RollDetailsLink.hidePopup();\" href=\"Tb_Kontrak_list.aspx?" + masterquery + "\" id=\"master_Tb_Kontrak" + recno + "\"";

                dpreview=true;
                int Tb_Kontrak_cnt = 0;
                foreach (Data.Tb_Kontrak details in Tb_Kontrak_detailCollection)
                {
                    if (masterID != null && details.KD_VENDOR.ToString() == masterID)
                    {
                        ++Tb_Kontrak_cnt;
                    }
                }
	            	            if(Tb_Kontrak_cnt > 0)
                {
		            record["Tb_Kontrak_childcount"]=true;
                }
	            else
                {
		            dpreview=false;
                }
	            record["Tb_Kontrak_childnumber"]=Tb_Kontrak_cnt;
	                	        
                record["Tb_Kontrak_dtablelink_attrs"]="href=\"Tb_Kontrak_list.aspx?" + masterquery + "\" id=\"master_Tb_Kontrak" + recno.ToString() + "\"";
                if(dpreview)
	            {
	            		            record["Tb_Kontrak_dtablelink_attrs"] +=" onmouseover=\"RollDetailsLink.showPopup(this,'Tb_Kontrak_detailspreview.aspx'+this.href.substr(this.href.indexOf('?')));\" onmouseout=\"RollDetailsLink.hidePopup();\"";
	                            }
	*/

            //	key fields
	            string keyblock="";
	            string editlink="";
	            string copylink="";
	            string keylink="";
	            keyblock +=  this.Server.UrlEncode(collection[i].KD_VENDOR.ToString());
	            editlink += "editid1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KD_VENDOR.ToString()));
	            copylink +="copyid1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KD_VENDOR.ToString()));
	            keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KD_VENDOR.ToString()));

	            record["editlink_attrs"]="href=\"Tb_Vendor_edit.aspx?" + editlink + "\" id=\"editlink" + recno.ToString() + "\"";
	            record["inlineeditlink_attrs"]= "href=\"Tb_Vendor_edit.aspx?" + editlink + "\" onclick=\"return inlineEdit('" + recno.ToString() + "','" + editlink + "');\" id=\"ieditlink" + recno.ToString() + "\"";
	            record["copylink_attrs"]="href=\"Tb_Vendor_add.aspx?" + copylink + "\" id=\"copylink" + recno.ToString() + "\"";
	            record["viewlink_attrs"]="href=\"Tb_Vendor_view.aspx?"  + editlink + "\" id=\"viewlink" + recno.ToString() + "\"";
	            record["checkbox_attrs"]="name=\"selection[]\" value=\"" + keyblock + "\" id=\"check" + recno.ToString() + "\"";

			string value;
            value = string.Empty;
	
	//	KD_VENDOR - 
            Control control_KD_VENDOR = new Control("KD_VENDOR", collection[i].KD_VENDOR, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_KD_VENDOR.GetData();
			    value = control_KD_VENDOR.ProcessLargeText(value,"field=KD%5FVENDOR" + keylink,"",MODE.MODE_LIST);
			    record["KD_VENDOR_value"]=value;
            value = string.Empty;
    //	NAMA - 
            Control control_NAMA = new Control("NAMA", collection[i].NAMA, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_NAMA.GetData();
			    value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
			    record["NAMA_value"]=value;
            value = string.Empty;
    //	ALAMAT - 
            Control control_ALAMAT = new Control("ALAMAT", collection[i].ALAMAT, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_ALAMAT.GetData();
			    value = control_ALAMAT.ProcessLargeText(value,"field=ALAMAT" + keylink,"",MODE.MODE_LIST);
			    record["ALAMAT_value"]=value;
            value = string.Empty;
    //	NPWP - 
            Control control_NPWP = new Control("NPWP", collection[i].NPWP, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_NPWP.GetData();
			    value = control_NPWP.ProcessLargeText(value,"field=NPWP" + keylink,"",MODE.MODE_LIST);
			    record["NPWP_value"]=value;
            value = string.Empty;
    //	TELEPON - 
            Control control_TELEPON = new Control("TELEPON", collection[i].TELEPON, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_TELEPON.GetData();
			    value = control_TELEPON.ProcessLargeText(value,"field=TELEPON" + keylink,"",MODE.MODE_LIST);
			    record["TELEPON_value"]=value;
            value = string.Empty;
    //	FAX - 
            Control control_FAX = new Control("FAX", collection[i].FAX, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_FAX.GetData();
			    value = control_FAX.ProcessLargeText(value,"field=FAX" + keylink,"",MODE.MODE_LIST);
			    record["FAX_value"]=value;
            value = string.Empty;
    //	EMAIL - 
            Control control_EMAIL = new Control("EMAIL", collection[i].EMAIL, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                        value = control_EMAIL.GetData();
			    value = control_EMAIL.ProcessLargeText(value,"field=EMAIL" + keylink,"",MODE.MODE_LIST);
			    record["EMAIL_value"]=value;
            value = string.Empty;
    //	STATUS - Checkbox
            Control control_STATUS = new Control("STATUS", collection[i].STATUS, false, smarty, this.Request, builder, MODE.MODE_LIST);
	        			    value = control_STATUS.GetData();
			    record["STATUS_value"]=value;
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
            collection = new Data.Tb_VendorCollection();
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

        /*
        Data.Tb_KontrakController Tb_Kontrak_detailController = new Data.Tb_KontrakController();
        //foreach @TABLE.arrKeyFields as @tk
                ArrayList Tb_Kontrak_masterids = new ArrayList();
        for(int i = 0; i < collection.Count; ++ i)
        {
            try{
            Tb_Kontrak_masterids.Add(collection[i].KD_VENDOR.ToString());
            }
            catch
            {
            }
        }
        Tb_Kontrak_detailCollection = Tb_Kontrak_detailController.FetchForDetails("KD_VENDOR", Tb_Kontrak_masterids.ToArray(), OwnerColumn, OwnerID);
		*/
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
                    pagination += "{window.location='Tb_Vendor_list.aspx?goto=' + nPageNumber;}</script>";
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
        if(allow_Tb_Kegiatan)
        {
	        createmenu = true;
	        smarty.Add("Tb_Kegiatan_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Kegiatan", "A") && func.CheckUserPermissions("Tb_Kegiatan", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Kegiatan_tablelink_attrs","href=\"Tb_Kegiatan_" + page + ".aspx\"");
            smarty.Add("Tb_Kegiatan_optionattrs","value=\"Tb_Kegiatan_" + page + ".aspx\"");
        }
        if(allow_VIEW_KONSTRUKSI)
        {
	        createmenu = true;
	        smarty.Add("VIEW_KONSTRUKSI_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("VIEW_KONSTRUKSI", "A") && func.CheckUserPermissions("VIEW_KONSTRUKSI", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("VIEW_KONSTRUKSI_tablelink_attrs","href=\"VIEW_KONSTRUKSI_" + page + ".aspx\"");
            smarty.Add("VIEW_KONSTRUKSI_optionattrs","value=\"VIEW_KONSTRUKSI_" + page + ".aspx\"");
        }
        if(allow_VIEW_KONSULTASI)
        {
	        createmenu = true;
	        smarty.Add("VIEW_KONSULTASI_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("VIEW_KONSULTASI", "A") && func.CheckUserPermissions("VIEW_KONSULTASI", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("VIEW_KONSULTASI_tablelink_attrs","href=\"VIEW_KONSULTASI_" + page + ".aspx\"");
            smarty.Add("VIEW_KONSULTASI_optionattrs","value=\"VIEW_KONSULTASI_" + page + ".aspx\"");
        }
        if(allow_VIEW_PENGADAAN)
        {
	        createmenu = true;
	        smarty.Add("VIEW_PENGADAAN_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("VIEW_PENGADAAN", "A") && func.CheckUserPermissions("VIEW_PENGADAAN", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("VIEW_PENGADAAN_tablelink_attrs","href=\"VIEW_PENGADAAN_" + page + ".aspx\"");
            smarty.Add("VIEW_PENGADAAN_optionattrs","value=\"VIEW_PENGADAAN_" + page + ".aspx\"");
        }
        if(allow_VIEW_JENIS_LAINNYA)
        {
	        createmenu = true;
	        smarty.Add("VIEW_JENIS_LAINNYA_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("VIEW_JENIS_LAINNYA", "A") && func.CheckUserPermissions("VIEW_JENIS_LAINNYA", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("VIEW_JENIS_LAINNYA_tablelink_attrs","href=\"VIEW_JENIS_LAINNYA_" + page + ".aspx\"");
            smarty.Add("VIEW_JENIS_LAINNYA_optionattrs","value=\"VIEW_JENIS_LAINNYA_" + page + ".aspx\"");
        }
        if(allow_Tb_Paket_Pekerjaan)
        {
	        createmenu = true;
	        smarty.Add("Tb_Paket_Pekerjaan_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Paket_Pekerjaan", "A") && func.CheckUserPermissions("Tb_Paket_Pekerjaan", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Paket_Pekerjaan_tablelink_attrs","href=\"Tb_Paket_Pekerjaan_" + page + ".aspx\"");
            smarty.Add("Tb_Paket_Pekerjaan_optionattrs","value=\"Tb_Paket_Pekerjaan_" + page + ".aspx\"");
        }
        if(allow_Tb_Kontrak)
        {
	        createmenu = true;
	        smarty.Add("Tb_Kontrak_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Kontrak", "A") && func.CheckUserPermissions("Tb_Kontrak", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Kontrak_tablelink_attrs","href=\"Tb_Kontrak_" + page + ".aspx\"");
            smarty.Add("Tb_Kontrak_optionattrs","value=\"Tb_Kontrak_" + page + ".aspx\"");
        }
        if(allow_Tb_Vendor)
        {
	        createmenu = true;
	        smarty.Add("Tb_Vendor_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Vendor", "A") && func.CheckUserPermissions("Tb_Vendor", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Vendor_tablelink_attrs","href=\"Tb_Vendor_" + page + ".aspx\"");
            smarty.Add("Tb_Vendor_optionattrs","value=\"Tb_Vendor_" + page + ".aspx\"");
        }
        if(allow_Tb_Login)
        {
	        createmenu = true;
	        smarty.Add("Tb_Login_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Login", "A") && func.CheckUserPermissions("Tb_Login", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Login_tablelink_attrs","href=\"Tb_Login_" + page + ".aspx\"");
            smarty.Add("Tb_Login_optionattrs","value=\"Tb_Login_" + page + ".aspx\"");
        }
        if(allow_Tb_Jenis_Kegiatan)
        {
	        createmenu = true;
	        smarty.Add("Tb_Jenis_Kegiatan_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Jenis_Kegiatan", "A") && func.CheckUserPermissions("Tb_Jenis_Kegiatan", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Jenis_Kegiatan_tablelink_attrs","href=\"Tb_Jenis_Kegiatan_" + page + ".aspx\"");
            smarty.Add("Tb_Jenis_Kegiatan_optionattrs","value=\"Tb_Jenis_Kegiatan_" + page + ".aspx\"");
        }
        if(allow_Tb_Kecamatan)
        {
	        createmenu = true;
	        smarty.Add("Tb_Kecamatan_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Kecamatan", "A") && func.CheckUserPermissions("Tb_Kecamatan", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Kecamatan_tablelink_attrs","href=\"Tb_Kecamatan_" + page + ".aspx\"");
            smarty.Add("Tb_Kecamatan_optionattrs","value=\"Tb_Kecamatan_" + page + ".aspx\"");
        }
        if(allow_Tb_Kelurahan)
        {
	        createmenu = true;
	        smarty.Add("Tb_Kelurahan_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Kelurahan", "A") && func.CheckUserPermissions("Tb_Kelurahan", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Kelurahan_tablelink_attrs","href=\"Tb_Kelurahan_" + page + ".aspx\"");
            smarty.Add("Tb_Kelurahan_optionattrs","value=\"Tb_Kelurahan_" + page + ".aspx\"");
        }
        if(allow_Tb_SKPD)
        {
	        createmenu = true;
	        smarty.Add("Tb_SKPD_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_SKPD", "A") && func.CheckUserPermissions("Tb_SKPD", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_SKPD_tablelink_attrs","href=\"Tb_SKPD_" + page + ".aspx\"");
            smarty.Add("Tb_SKPD_optionattrs","value=\"Tb_SKPD_" + page + ".aspx\"");
        }
        if(allow_Tb_Status)
        {
	        createmenu = true;
	        smarty.Add("Tb_Status_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Status", "A") && func.CheckUserPermissions("Tb_Status", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Status_tablelink_attrs","href=\"Tb_Status_" + page + ".aspx\"");
            smarty.Add("Tb_Status_optionattrs","value=\"Tb_Status_" + page + ".aspx\"");
        }
        if(allow_Tb_Pertanyaan)
        {
	        createmenu = true;
	        smarty.Add("Tb_Pertanyaan_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Pertanyaan", "A") && func.CheckUserPermissions("Tb_Pertanyaan", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Pertanyaan_tablelink_attrs","href=\"Tb_Pertanyaan_" + page + ".aspx\"");
            smarty.Add("Tb_Pertanyaan_optionattrs","value=\"Tb_Pertanyaan_" + page + ".aspx\"");
        }
        if(allow_Tb_Jabatan)
        {
	        createmenu = true;
	        smarty.Add("Tb_Jabatan_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Jabatan", "A") && func.CheckUserPermissions("Tb_Jabatan", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Jabatan_tablelink_attrs","href=\"Tb_Jabatan_" + page + ".aspx\"");
            smarty.Add("Tb_Jabatan_optionattrs","value=\"Tb_Jabatan_" + page + ".aspx\"");
        }
        if(allow_Tb_Tipe_Aktor)
        {
	        createmenu = true;
	        smarty.Add("Tb_Tipe_Aktor_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Tipe_Aktor", "A") && func.CheckUserPermissions("Tb_Tipe_Aktor", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Tipe_Aktor_tablelink_attrs","href=\"Tb_Tipe_Aktor_" + page + ".aspx\"");
            smarty.Add("Tb_Tipe_Aktor_optionattrs","value=\"Tb_Tipe_Aktor_" + page + ".aspx\"");
        }
        if(allow_Tb_Aktor)
        {
	        createmenu = true;
	        smarty.Add("Tb_Aktor_tablelink", true);
	        string page = string.Empty;
	        	        page = "list";
	                    	        bool perm = (func.CheckUserPermissions("Tb_Aktor", "A") && func.CheckUserPermissions("Tb_Aktor", "S") == false);

	        if(perm)
            {
		        page = "add";
            }
	        smarty.Add("Tb_Aktor_tablelink_attrs","href=\"Tb_Aktor_" + page + ".aspx\"");
            smarty.Add("Tb_Aktor_optionattrs","value=\"Tb_Aktor_" + page + ".aspx\"");
        }
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
                         
                                                                                        Convert.ToInt32(this.Server.UrlDecode(arr[0]).Trim())

                    );
                }
                else
                {
                                    Data.Tb_Vendor.Destroy(val);
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

        smarty.Add("KD_VENDOR_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aKD_VENDOR\"");
        smarty.Add("KD_VENDOR_fieldheader", true);
        smarty.Add("NAMA_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aNAMA\"");
        smarty.Add("NAMA_fieldheader", true);
        smarty.Add("ALAMAT_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aALAMAT\"");
        smarty.Add("ALAMAT_fieldheader", true);
        smarty.Add("NPWP_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aNPWP\"");
        smarty.Add("NPWP_fieldheader", true);
        smarty.Add("TELEPON_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aTELEPON\"");
        smarty.Add("TELEPON_fieldheader", true);
        smarty.Add("FAX_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aFAX\"");
        smarty.Add("FAX_fieldheader", true);
        smarty.Add("EMAIL_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aEMAIL\"");
        smarty.Add("EMAIL_fieldheader", true);
        smarty.Add("STATUS_orderlinkattrs", "href=\"Tb_Vendor_list.aspx?orderby=aSTATUS\"");
        smarty.Add("STATUS_fieldheader", true);
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
	        smarty[Control.GoodFieldName(order_field) + "_orderlinkattrs"] = "href=\"Tb_Vendor_list.aspx?orderby=" + dir + Control.GoodFieldName(order_field) + "\"";

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
        "<form name=\"frmSearch\" method=\"GET\" action=\"Tb_Vendor_list.aspx\">" + 
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

	    includes.Append("var INLINE_EDIT_TABLE='Tb_Vendor_edit.aspx';\r\n");
	    includes.Append("var INLINE_ADD_TABLE='Tb_Vendor_add.aspx';\r\n");
	    includes.Append("var INLINE_VIEW_TABLE='Tb_Vendor_view.aspx';\r\n");
	    includes.Append("var SUGGEST_TABLE='Tb_Vendor_searchsuggest.aspx';\r\n");
	    includes.Append("var MASTER_PREVIEW_TABLE='Tb_Vendor_masterpreview.aspx';\r\n");
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

