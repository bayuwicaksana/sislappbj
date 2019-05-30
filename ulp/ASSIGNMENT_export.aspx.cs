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

public partial class CASSIGNMENT_Export : AspNetRunnerPage 
{
    int numrows = 0;
    IDictionary body;
    int mypage = 1;
    int gPageSize = 20;
    int recno = 1;
    int records = 0;
    int pageindex = 1;
    bool options = false;
    bool all = false;
    IDictionary<char, string> xmlRejects = new Dictionary<char, string>();

    ASSIGNMENTController controller = new ASSIGNMENTController();
    ASSIGNMENTCollection collection;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.ASSIGNMENT";
        strTableNameLocale = "dbo_ASSIGNMENT";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
            body = new Hashtable();
            xmlRejects.Add(' ',string.Empty);
            xmlRejects.Add('#',string.Empty);
            xmlRejects.Add('/',string.Empty);
            xmlRejects.Add('\\',string.Empty);
            xmlRejects.Add('(',string.Empty);
            xmlRejects.Add(')',string.Empty);
            xmlRejects.Add(',',string.Empty);
            xmlRejects.Add('[',string.Empty);
            xmlRejects.Add(']',string.Empty);
            xmlRejects.Add('+',string.Empty);
            xmlRejects.Add('\'',string.Empty);
            xmlRejects.Add('-',string.Empty);
            xmlRejects.Add('_',string.Empty);
            xmlRejects.Add('|',string.Empty);
            xmlRejects.Add('}',string.Empty);
            xmlRejects.Add('{',string.Empty);
            xmlRejects.Add('=',string.Empty);

            if(Request["records"] != null)
            {
                if((string)Request["records"] == "all")
                {
                    all = true;
                }
            }

                        CheckSecurity();
            options = string.IsNullOrEmpty(RequestAction);
            if(Request["type"] != null)
	        {
                GetData();
                BuildPagination();
                Export();
            }
            else
            {
                Selection = this.Request.Params.GetValues("selection[]");
                BuildBody();
                output.Append(func.BuildOutput(this, @"~\ASSIGNMENT_export.aspx", smarty));
            }
            this.Response.Write(output.ToString());
            this.Response.End();
    }

    private void WriteTableData()
    {
	    output.Append("<tr>");
	    if(Request["type"] != null && Request["type"].ToString() == "excel")
	    {
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("NIP") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("KODEPBJ") + "</td>");
	    }
	    else
	    {
		    output.Append("<td>NIP</td>");
		    output.Append("<td>KODEPBJ</td>");
	    }
	    output.Append( "</tr>");

	    IDictionary<string, IList<string>> totals = new Dictionary<string, IList<string>>();
    // write data rows
	    for(int i = 0; i < collection.Count; ++ i)
	    {
            object totalValue = null;
		    output.Append("<tr>");
    Control control_NIP = new Control("NIP", collection[i].NIP, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    		    if((object)collection[i].NIP != null)
		    {
                control_NIP.Value = func.GetLookupValue(control_NIP.FieldInfo);
			    string strValue_NIP = control_NIP.Value;
			    			    if(Request["type"] != null && Request["type"].ToString() == "excel")
				    output.Append( PrepareForExcel(strValue_NIP));
			    else
				    output.Append( Control.HTMLEncodeSpecialChars(strValue_NIP));

		    }
	    output.Append( "</td>" );
    Control control_KODEPBJ = new Control("KODEPBJ", collection[i].KODEPBJ, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    		    if((object)collection[i].KODEPBJ != null)
		    {
                control_KODEPBJ.Value = func.GetLookupValue(control_KODEPBJ.FieldInfo);
			    string strValue_KODEPBJ = control_KODEPBJ.Value;
			    			    if(Request["type"] != null && Request["type"].ToString() == "excel")
				    output.Append( PrepareForExcel(strValue_KODEPBJ));
			    else
				    output.Append( Control.HTMLEncodeSpecialChars(strValue_KODEPBJ));

		    }
	    output.Append( "</td>" );
		    output.Append( "</tr>" );
	    }
    
    }

    private void ExportToCSV()
    {
        Response.AddHeader("Content-type", "application/csv");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=ASSIGNMENT.csv");

	    IDictionary<string, IList<string>> totals = new Dictionary<string, IList<string>>();

    	
    // write header
	    StringBuilder outstr = new StringBuilder();
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"NIP\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"KODEPBJ\"");
	    output.Append(outstr);
	    output.Append("\r\n");

    // write data rows
	    for(int i = 0; i < collection.Count; ++ i)
	    {
            object totalValue = null;
		    outstr.Remove(0, outstr.Length);
            Control control_NIP = new Control("NIP", collection[i].NIP, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
                control_NIP.Value = func.GetLookupValue(control_NIP.FieldInfo);
		    string value_NIP = control_NIP.DisplayLookupWizard();
		    if(value_NIP.Length > 0)
			    outstr.Append('"' + Control.HTMLEncodeSpecialChars(value_NIP) + '"');

            Control control_KODEPBJ = new Control("KODEPBJ", collection[i].KODEPBJ, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
                control_KODEPBJ.Value = func.GetLookupValue(control_KODEPBJ.FieldInfo);
		    string value_KODEPBJ = control_KODEPBJ.DisplayLookupWizard();
		    if(value_KODEPBJ.Length > 0)
			    outstr.Append('"' + Control.HTMLEncodeSpecialChars(value_KODEPBJ) + '"');

		    output.Append(outstr);
		    output.Append("\r\n");
	    }

    //	display totals
	    bool first = true;
    
    }

    private void ExportToWord()
    {
        Response.AddHeader("Content-type", "application/vnd.ms-word");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=ASSIGNMENT.doc");

	    output.Append("<html>");
	    output.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=Windows-1252\">");
	    output.Append("<body>");
	    output.Append("<table border=1>");

	    WriteTableData();

	    output.Append("</table>");
	    output.Append("</body>");
	    output.Append("</html>");
    }

    private void  ExportToExcel()
    {
	    Response.AddHeader("Content-type", "application/vnd.ms-excel");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=ASSIGNMENT.xls");

	    output.Append ("<html>");
	    output.Append ("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">");
    	
	    output.Append ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=Windows-1252\">");
	    output.Append ("<body>");
	    output.Append ("<table border=1>");

	    WriteTableData();

	    output.Append ("</table>");
	    output.Append ("</body>");
	    output.Append ("</html>");
    }

    private string XMLNameEncode(string strValue)
    {	
        StringBuilder newString = new StringBuilder();
        foreach(char ch in strValue)
        {
            if(!xmlRejects.ContainsKey(ch))
            {
                newString.Append(ch);
            }
        }
	    return newString.ToString();
    }

    private string PrepareForExcel(string str)
    {
        if(string.IsNullOrEmpty(str))
        {
            return str;
        }
	    string ret = Control.HTMLEncodeSpecialChars(str);
	    if (str.StartsWith("="))
        {
		    ret = "&#61;" + str.Substring(1);
        }
	    return ret;

    }

    private void ExportToXML()
    {
        Response.AddHeader("Content-type", "text/xml");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=ASSIGNMENT.xml");


	    output.Append ("<?xml version=\"1.0\" encoding=\"Windows-1252\" standalone=\"yes\"?>\r\n");
	    output.Append ("<table>\r\n");
	    for(int i = 0; i < collection.Count; ++ i)
	    {
		    output.Append("<row>\r\n");
		    string field_NIP = Control.HTMLEncodeSpecialChars(XMLNameEncode("NIP"));
		    output.Append("<" + field_NIP + ">");
            Control control_NIP = new Control("NIP", collection[i].NIP, false, smarty, this.Request, builder, MODE.MODE_EXPORT);

            control_NIP.Value = func.GetLookupValue(control_NIP.FieldInfo);
		    output.Append(Control.HTMLEncodeSpecialChars(control_NIP.DisplayLookupWizard()));
    		
		    output.Append("</" + field_NIP + ">\r\n");
		    string field_KODEPBJ = Control.HTMLEncodeSpecialChars(XMLNameEncode("KODEPBJ"));
		    output.Append("<" + field_KODEPBJ + ">");
            Control control_KODEPBJ = new Control("KODEPBJ", collection[i].KODEPBJ, false, smarty, this.Request, builder, MODE.MODE_EXPORT);

            control_KODEPBJ.Value = func.GetLookupValue(control_KODEPBJ.FieldInfo);
		    output.Append(Control.HTMLEncodeSpecialChars(control_KODEPBJ.DisplayLookupWizard()));
    		
		    output.Append("</" + field_KODEPBJ + ">\r\n");
		    output.Append("</row>\r\n");
	    }
	    output.Append("</table>\r\n");
    }

    private void Export()
    {
        string type = (string)Request["type"];
        if(type=="excel")
        {
		    ExportToExcel();
        }
	    else if(type=="word")
        {
		    ExportToWord();
        }
	    else if(type=="xml")
        {
		    ExportToXML();
        }
	    else if(type=="csv")
        {
		    ExportToCSV();
        }
        else
        {
            throw new NotImplementedException(type);
        }
    }

    private void BuildPagination()
    {
        int nPageSize = 0;
	    if(Request["records"] != null && Request["records"].ToString() =="page" && numrows > 0)
	    {
		    mypage = PageNumber;
		    int maxRecords = numrows;
		    smarty.Add("records_found",numrows);
		    int maxpages=(int)Math.Ceiling((double)maxRecords/PageSize);
		    if(mypage > maxpages)
            {
			    mypage = maxpages;
            }
		    if( mypage < 1) 
            {
			    mypage = 1;
            }
        }
    }

    private void BuildBody()
    {
        body = new Hashtable();
        if(options)
        {
	        smarty.Add("rangeheader_block",true);
	        smarty.Add("range_block",true);
        }
        body["begin"]="<form action=\"ASSIGNMENT_export.aspx\" method=get id=frmexport name=frmexport>";
        body["end"]="</form>";
        smarty.Add("body",body);
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
        if(MasterTable=="AKTOR")
        {
	        par.Add("NIP", this.Session[strTableName + "_masterkey1"]);
        }
        if(MasterTable=="PBJ")
        {
	        par.Add("KODEPBJ", this.Session[strTableName + "_masterkey1"]);
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
        if(MasterTable=="AKTOR")
        {
	        Asearchfor["NIP"] = (string)this.Session[strTableName + "_masterkey1"];
            par.Add("NIP", this.Session[strTableName + "_masterkey1"]);
        }
        if(MasterTable=="PBJ")
        {
	        Asearchfor["KODEPBJ"] = (string)this.Session[strTableName + "_masterkey1"];
            par.Add("KODEPBJ", this.Session[strTableName + "_masterkey1"]);
        }
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
        if (Selection == null)
        {
            if(all)
            {
                collection = controller.FetchAll(OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchAllCount(OwnerColumn, OwnerID);
            }
            else
            {
                collection = controller.FetchAllPaged((PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchAllCount(OwnerColumn, OwnerID);
            }
        }
        else
        {
            StringBuilder columns = new StringBuilder();
                    columns.Append("NIP");
                    columns.Append('\0');
                    columns.Append("KODEPBJ");
                    columns.Append('\0');
                collection = controller.FetchSelected(columns.ToString().Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries), 
                    Selection, 
                    OrderBy, 
                    OwnerColumn, OwnerID);
            numrows = collection.Count;
            Selection = null;
        }
    }

    private void GetData()
    {
        if (Search == 0 && Selection == null)
        {
            GetSearchRows();
        }
        else if(Search == 2 && Selection == null)
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
            this.MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
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

 
    private string[] Selection
    {
        get
        {
            return (string[])SessionPropertyGet("Selection", null);
        }
        set
        {
            SessionPropertySet("Selection", value);
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

