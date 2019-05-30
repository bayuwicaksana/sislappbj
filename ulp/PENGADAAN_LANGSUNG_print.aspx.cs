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

public partial class CPENGADAAN_LANGSUNG_Print : AspNetRunnerPage 
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

    PENGADAAN_LANGSUNGController controller = new PENGADAAN_LANGSUNGController();
    PENGADAAN_LANGSUNGCollection collection;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGADAAN_LANGSUNG";
        strTableNameLocale = "dbo_PENGADAAN_LANGSUNG";
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
                        GetData();
            BuildForm();
            BuildTotals();
            BuildMastertable();
            BuildBody();
            BuildPrintOrder();

            output = func.BuildOutput(this, @"~\PENGADAAN_LANGSUNG_print.aspx", smarty);
            this.Response.Write(output);
            this.Response.End();
    }

    private void BuildPrintOrder()
    {
        smarty.Add("NAMAKEGIATAN_fieldheadercolumn",true);
        smarty.Add("NAMAKEGIATAN_fieldheader",true);
        smarty.Add("NAMAKEGIATAN_fieldcolumn",true);
        smarty.Add("NAMAKEGIATAN_fieldfootercolumn",true);
        smarty.Add("NAMAPAKET_fieldheadercolumn",true);
        smarty.Add("NAMAPAKET_fieldheader",true);
        smarty.Add("NAMAPAKET_fieldcolumn",true);
        smarty.Add("NAMAPAKET_fieldfootercolumn",true);
        smarty.Add("KODESKPD_fieldheadercolumn",true);
        smarty.Add("KODESKPD_fieldheader",true);
        smarty.Add("KODESKPD_fieldcolumn",true);
        smarty.Add("KODESKPD_fieldfootercolumn",true);
        smarty.Add("TANGGALKONTRAK_fieldheadercolumn",true);
        smarty.Add("TANGGALKONTRAK_fieldheader",true);
        smarty.Add("TANGGALKONTRAK_fieldcolumn",true);
        smarty.Add("TANGGALKONTRAK_fieldfootercolumn",true);
        smarty.Add("PAGU_fieldheadercolumn",true);
        smarty.Add("PAGU_fieldheader",true);
        smarty.Add("PAGU_fieldcolumn",true);
        smarty.Add("PAGU_fieldfootercolumn",true);
        smarty.Add("HPS_fieldheadercolumn",true);
        smarty.Add("HPS_fieldheader",true);
        smarty.Add("HPS_fieldcolumn",true);
        smarty.Add("HPS_fieldfootercolumn",true);
        smarty.Add("NILAIKONTRAK_fieldheadercolumn",true);
        smarty.Add("NILAIKONTRAK_fieldheader",true);
        smarty.Add("NILAIKONTRAK_fieldcolumn",true);
        smarty.Add("NILAIKONTRAK_fieldfootercolumn",true);
        smarty.Add("PEMENANG_fieldheadercolumn",true);
        smarty.Add("PEMENANG_fieldheader",true);
        smarty.Add("PEMENANG_fieldcolumn",true);
        smarty.Add("PEMENANG_fieldfootercolumn",true);
        smarty.Add("KETERANGAN_fieldheadercolumn",true);
        smarty.Add("KETERANGAN_fieldheader",true);
        smarty.Add("KETERANGAN_fieldcolumn",true);
        smarty.Add("KETERANGAN_fieldfootercolumn",true);
        smarty.Add("PEJABATPENGADAAN_fieldheadercolumn",true);
        smarty.Add("PEJABATPENGADAAN_fieldheader",true);
        smarty.Add("PEJABATPENGADAAN_fieldcolumn",true);
        smarty.Add("PEJABATPENGADAAN_fieldfootercolumn",true);
        smarty.Add("MENGETAHUI_fieldheadercolumn",true);
        smarty.Add("MENGETAHUI_fieldheader",true);
        smarty.Add("MENGETAHUI_fieldcolumn",true);
        smarty.Add("MENGETAHUI_fieldfootercolumn",true);

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

			    keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEPENGADAANLANGSUNG.ToString()));


                string value="";

        //	NAMAKEGIATAN - 
                Control control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", collection[i].NAMAKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_NAMAKEGIATAN.GetData();
			        value = control_NAMAKEGIATAN.ProcessLargeText(value,"field=NAMAKEGIATAN" + keylink,"",MODE.MODE_LIST);
			        record["NAMAKEGIATAN_value"]=value;

        //	NAMAPAKET - 
                Control control_NAMAPAKET = new Control("NAMAPAKET", collection[i].NAMAPAKET, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_NAMAPAKET.GetData();
			        value = control_NAMAPAKET.ProcessLargeText(value,"field=NAMAPAKET" + keylink,"",MODE.MODE_LIST);
			        record["NAMAPAKET_value"]=value;

        //	KODESKPD - 
                Control control_KODESKPD = new Control("KODESKPD", collection[i].KODESKPD, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                control_KODESKPD.Value = func.GetLookupValue(control_KODESKPD.FieldInfo);
			        value=control_KODESKPD.DisplayLookupWizard();
			        record["KODESKPD_value"]=value;

        //	TANGGALKONTRAK - Short Date
                Control control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", collection[i].TANGGALKONTRAK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_TANGGALKONTRAK.GetData();
			        value = control_TANGGALKONTRAK.ProcessLargeText(value,"field=TANGGALKONTRAK" + keylink,"",MODE.MODE_LIST);
			        record["TANGGALKONTRAK_value"]=value;

        //	PAGU - Number
                Control control_PAGU = new Control("PAGU", collection[i].PAGU, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_PAGU.GetData();
			        value = control_PAGU.ProcessLargeText(value,"field=PAGU" + keylink,"",MODE.MODE_LIST);
			        record["PAGU_value"]=value;

        //	HPS - Number
                Control control_HPS = new Control("HPS", collection[i].HPS, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_HPS.GetData();
			        value = control_HPS.ProcessLargeText(value,"field=HPS" + keylink,"",MODE.MODE_LIST);
			        record["HPS_value"]=value;

        //	NILAIKONTRAK - Number
                Control control_NILAIKONTRAK = new Control("NILAIKONTRAK", collection[i].NILAIKONTRAK, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_NILAIKONTRAK.GetData();
			        value = control_NILAIKONTRAK.ProcessLargeText(value,"field=NILAIKONTRAK" + keylink,"",MODE.MODE_LIST);
			        record["NILAIKONTRAK_value"]=value;

        //	PEMENANG - 
                Control control_PEMENANG = new Control("PEMENANG", collection[i].PEMENANG, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                value = control_PEMENANG.GetData();
			        value = control_PEMENANG.ProcessLargeText(value,"field=PEMENANG" + keylink,"",MODE.MODE_LIST);
			        record["PEMENANG_value"]=value;

        //	KETERANGAN - 
                Control control_KETERANGAN = new Control("KETERANGAN", collection[i].KETERANGAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                control_KETERANGAN.Value = func.GetLookupValue(control_KETERANGAN.FieldInfo);
			        value=control_KETERANGAN.DisplayLookupWizard();
			        record["KETERANGAN_value"]=value;

        //	PEJABATPENGADAAN - 
                Control control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", collection[i].PEJABATPENGADAAN, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                control_PEJABATPENGADAAN.Value = func.GetLookupValue(control_PEJABATPENGADAAN.FieldInfo);
			        value=control_PEJABATPENGADAAN.DisplayLookupWizard();
			        record["PEJABATPENGADAAN_value"]=value;

        //	MENGETAHUI - 
                Control control_MENGETAHUI = new Control("MENGETAHUI", collection[i].MENGETAHUI, false, smarty, this.Request, builder, MODE.MODE_LIST);
	                                control_MENGETAHUI.Value = func.GetLookupValue(control_MENGETAHUI.FieldInfo);
			        value=control_MENGETAHUI.DisplayLookupWizard();
			        record["MENGETAHUI_value"]=value;

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
		    if(all && records >= 30)
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
                    columns.Append("KODEPENGADAANLANGSUNG");
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

