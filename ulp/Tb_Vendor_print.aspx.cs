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
using SubSonic;
#endregion

public partial class CTb_Vendor_Print : AspNetRunnerPage 
{
    string filename="";
    string message = string.Empty;
    string strOrderBy = string.Empty;
    int rowCount = 0;
    int numrows = 0;
    IDictionary body;
    int colsonpage;
    int mypage;
    bool shade;
    int gPageSize = 20;
    int recno = 1;
    int records = 0;
    bool all = false;
    bool pdf = false;
    int pageindex = 1;

    Tb_VendorController controller = new Tb_VendorController();
    Tb_VendorCollection collection;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.Tb_Vendor";
        strTableNameLocale = "dbo_Tb_Vendor";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
        string output = string.Empty;
            if(Request["all"] != null)
            {
                all = ((string)Request["all"] == "1");
            }

            if(Request["pdf"] != null)
            {
                pdf = ((string)Request["pdf"] == "1");
            }

            body = new Hashtable();
                        CheckSecurity();
            GetData();
            BuildForm();
            BuildTotals();
            BuildMastertable();
            BuildBody();
            BuildPrintOrder();

            output = func.BuildOutput(this, @"~\Tb_Vendor_print.aspx", smarty);
            this.Response.Write(output);
            this.Response.End();
    }

    private void BuildPrintOrder()
    {
        smarty.Add("KD_VENDOR_fieldheadercolumn",true);
        smarty.Add("KD_VENDOR_fieldheader",true);
        smarty.Add("KD_VENDOR_fieldcolumn",true);
        smarty.Add("KD_VENDOR_fieldfootercolumn",true);
        smarty.Add("NAMA_fieldheadercolumn",true);
        smarty.Add("NAMA_fieldheader",true);
        smarty.Add("NAMA_fieldcolumn",true);
        smarty.Add("NAMA_fieldfootercolumn",true);
        smarty.Add("ALAMAT_fieldheadercolumn",true);
        smarty.Add("ALAMAT_fieldheader",true);
        smarty.Add("ALAMAT_fieldcolumn",true);
        smarty.Add("ALAMAT_fieldfootercolumn",true);
        smarty.Add("NPWP_fieldheadercolumn",true);
        smarty.Add("NPWP_fieldheader",true);
        smarty.Add("NPWP_fieldcolumn",true);
        smarty.Add("NPWP_fieldfootercolumn",true);
        smarty.Add("TELEPON_fieldheadercolumn",true);
        smarty.Add("TELEPON_fieldheader",true);
        smarty.Add("TELEPON_fieldcolumn",true);
        smarty.Add("TELEPON_fieldfootercolumn",true);
        smarty.Add("FAX_fieldheadercolumn",true);
        smarty.Add("FAX_fieldheader",true);
        smarty.Add("FAX_fieldcolumn",true);
        smarty.Add("FAX_fieldfootercolumn",true);
        smarty.Add("EMAIL_fieldheadercolumn",true);
        smarty.Add("EMAIL_fieldheader",true);
        smarty.Add("EMAIL_fieldcolumn",true);
        smarty.Add("EMAIL_fieldfootercolumn",true);
        smarty.Add("STATUS_fieldheadercolumn",true);
        smarty.Add("STATUS_fieldheader",true);
        smarty.Add("STATUS_fieldcolumn",true);
        smarty.Add("STATUS_fieldfootercolumn",true);

	    IDictionary record_header = new Hashtable();
        IList<object> rheaders = new List<object>();
        record_header["data"] = rheaders;
	    for(int i=0; i < colsonpage; i++)
	    {
		    IDictionary rheader = new Hashtable();
		    if(i < colsonpage-1)
		    {
		        rheader["endrecordheader_block"]=true;
		    }
		    rheaders.Add(rheader);
	    }
	    smarty.Add("record_header",record_header);
	    smarty.Add("grid_header",true);
	    smarty.Add("grid_footer",true);
    }

    private void BuildBody()
    {
        body = new Hashtable();
        
        smarty.Add("body",body);
        smarty.Add("grid_block",true);
    }

    private void BuildMastertable()
    {
        string mastertable = string.Empty;
    }

    private void BuildTotals()
    {
        //	process totals
	    //smarty.Add("totals_row",true);
	    IDictionary totals_records = new Hashtable();
        IList totals_records_data = new List<object>();
        totals_records["data"] = totals_records_data;
	    for(int i=0; i < colsonpage; i++)
	    {
		    IDictionary record = new Hashtable();
		    //if(i == 0)
		    //{
            if(i < colsonpage-1)
            {
		        record["endrecordtotals_block"]=true;
            }
        }
	    smarty.Add("totals_row", totals_records);
    }

    private void BuildForm()
    {
        int col=1;
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

        IList<object> pages = new List<object>();
        IDictionary rowinfo = new Hashtable();
        IList<object> rowinfo_data =  new List<object>();
        rowinfo["data"] = rowinfo_data;
        string keylink;

        //	add grid data
	    for(int i = 0; i < collection.Count; ++ i)
        {
		    IDictionary row = new Hashtable();
            IDictionary grid_record = new Hashtable();
            row["grid_record"] = grid_record;
            IList<object> grid_record_data = new List<object>();
            grid_record["data"] = grid_record_data;
            bool beforeProcessRowPrintResult = true;
                        if(beforeProcessRowPrintResult)
            {
		        for(col=1;collection != null && collection.Count !=0 && recno <= collection.Count && col<=colsonpage;col++)
		        {
			        IDictionary record = new Hashtable();
                    object totalValue = null;
                recno ++;
                records ++;
                keylink = string.Empty;

			    keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KD_VENDOR.ToString()));


                string value="";

        //	KD_VENDOR - 
                Control control_KD_VENDOR = new Control("KD_VENDOR", collection[i].KD_VENDOR, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_KD_VENDOR.GetData();
			        value = control_KD_VENDOR.ProcessLargeText(value,"field=KD%5FVENDOR" + keylink,"",MODE.MODE_LIST);
			        record["KD_VENDOR_value"]=value;

        //	NAMA - 
                Control control_NAMA = new Control("NAMA", collection[i].NAMA, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_NAMA.GetData();
			        value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
			        record["NAMA_value"]=value;

        //	ALAMAT - 
                Control control_ALAMAT = new Control("ALAMAT", collection[i].ALAMAT, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_ALAMAT.GetData();
			        value = control_ALAMAT.ProcessLargeText(value,"field=ALAMAT" + keylink,"",MODE.MODE_LIST);
			        record["ALAMAT_value"]=value;

        //	NPWP - 
                Control control_NPWP = new Control("NPWP", collection[i].NPWP, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_NPWP.GetData();
			        value = control_NPWP.ProcessLargeText(value,"field=NPWP" + keylink,"",MODE.MODE_LIST);
			        record["NPWP_value"]=value;

        //	TELEPON - 
                Control control_TELEPON = new Control("TELEPON", collection[i].TELEPON, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_TELEPON.GetData();
			        value = control_TELEPON.ProcessLargeText(value,"field=TELEPON" + keylink,"",MODE.MODE_LIST);
			        record["TELEPON_value"]=value;

        //	FAX - 
                Control control_FAX = new Control("FAX", collection[i].FAX, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_FAX.GetData();
			        value = control_FAX.ProcessLargeText(value,"field=FAX" + keylink,"",MODE.MODE_LIST);
			        record["FAX_value"]=value;

        //	EMAIL - 
                Control control_EMAIL = new Control("EMAIL", collection[i].EMAIL, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_EMAIL.GetData();
			        value = control_EMAIL.ProcessLargeText(value,"field=EMAIL" + keylink,"",MODE.MODE_LIST);
			        record["EMAIL_value"]=value;

        //	STATUS - Checkbox
                Control control_STATUS = new Control("STATUS", collection[i].STATUS, false, smarty, this.Request, builder, MODE.MODE_LIST);
	            			        value = control_STATUS.GetData();
			        record["STATUS_value"]=value;

			    if(col < colsonpage)
                {
				    record["endrecord_block"] = true;
                }
			    record["grid_recordheader"] = true;
			    record["grid_vrecord"] = true;
			    grid_record_data.Add(record);
                		    }

            if(col <= colsonpage)
		    {
			    IList<object> data = grid_record_data;
                IDictionary block = (IDictionary)data[data.Count - 1];
                block["endrecord_block"] = false;
		    }
		    row["grid_rowspace"] = true;
            IDictionary grid_recordspace = new Hashtable();
		    row["grid_recordspace"] = grid_recordspace;
            IList<bool> grid_recordspace_data = new List<bool>();
            grid_recordspace["data"] = grid_recordspace_data;
		    for(int j=0; j < colsonpage*2-1; j++)
            {
			    grid_recordspace_data.Add(true);
            }
    		
		    rowinfo_data.Add(row);
		    if(all && records >= 50)
		    {
			    IDictionary page = new Hashtable();
                page["grid_row"] = rowinfo;
			    page["idx"] = pageindex;
			    pageindex++;
			    pages.Add(page);
			    records = 0;
			    rowinfo = new Hashtable();
		    }
        }
    }

    if(rowinfo.Count > 0)
	{
        IDictionary page = new Hashtable();
        page["grid_row"] = rowinfo;
		page["idx"] = pageindex;
		pages.Add(page);
	}
	for(int i=0; i < pages.Count; i++)
	{
        IDictionary page = (IDictionary)pages[i];
		if(i < (pages.Count - 1 ))
        {
			page["begin"]="<div name=page class=printpage>";
        }
		else
        {
			page["begin"]="<div name=page>";
        }
		page["end"]="</div>";
	}
	if(pages.Count > 0)
	{
        IDictionary page = (IDictionary)pages[pages.Count - 1];
		page["totals_row"] = true;
	}
	IDictionary newpage = new Hashtable();
    newpage["data"] = pages;
	smarty.Add("page", newpage);
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
        if (all)
        {
            collection = controller.FetchAll(OrderBy, OwnerColumn, OwnerID);
        }
        else
        {
            string[] selection = this.Request.Params.GetValues("selection[]");
            if (selection == null)
            {
                collection = controller.FetchAllPaged((PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID);
            }
            else
            {
                StringBuilder columns = new StringBuilder();
                    columns.Append("KD_VENDOR");
                    columns.Append('\0');
                collection = controller.FetchSelected(columns.ToString().Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries), 
                    selection, 
                    OrderBy, 
                    OwnerColumn, OwnerID);
            }
        }
    }

    private void GetData()
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

        private bool CheckSecurity()
    {
        if(string.IsNullOrEmpty(UserName))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
	        return false;
        }
                if(!BaseCheckSecurity(OwnerID, "Export"))
        {
                }
        return true;
    }

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

    private string OrderBy
    {
        get
        {
            return (string)SessionPropertyGet(strTableName + "_orderby", string.Empty);
        }
        set
        {
            SessionPropertySet(strTableName + "_orderby", value);
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

    private IDictionary Asearchfortype
    {
        get
        {
            return (IDictionary)SessionPropertyGet(strTableName + "_asearchfortype", new Hashtable());
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
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchfor2", new Dictionary<string, string>());
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
            return (IDictionary<string, bool>)SessionPropertyGet(strTableName + "_asearchnot", new Dictionary<string, bool>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchnot", value);
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

    private string MasterTable
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

