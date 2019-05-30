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

public partial class CKELENGKAPANPBJ_Detailspreview : AspNetRunnerPage
{
    string _mode = string.Empty;
    string mastertable = string.Empty;
    int numrows = 0;

    KELENGKAPANPBJController controller = new KELENGKAPANPBJController();
    KELENGKAPANPBJCollection collection = new KELENGKAPANPBJCollection();

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.KELENGKAPANPBJ";
        strTableNameLocale = "dbo_KELENGKAPANPBJ";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _mode = (string)Request["mode"];

                CheckSecurity();
        InitVariables();
        GetData();
        BuildForm();
        output.Append(func.BuildOutput(this, @"~\KELENGKAPANPBJ_Detailspreview.aspx", smarty));
        this.Response.Write(output.ToString());
        if(_mode != "inline")
        {
	        this.Response.Write("counterSeparator" + (string)this.Request["counter"]);
        }
        this.Response.End();
    }

        private bool CheckSecurity()
    {
        if(string.IsNullOrEmpty(UserName))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
	        return false;
        }
                if(!BaseCheckSecurity(OwnerID, "Search") && !BaseCheckSecurity(OwnerID, "View"))
        {
                }
        return true;
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

    private void GetData()
    {
        if(mastertable=="PBJ")
        {
	                    IDictionary<string, object> par = new Dictionary<string, object>();
	        par.Add("KODEBPJ", this.Session[strTableName + "_masterkey1"]);
            collection = controller.FetchForDetails(par, OrderBy, OwnerColumn, OwnerID);
            numrows = controller.FetchForDetailsCount(par, OwnerColumn, OwnerID);
        }
        if(mastertable=="KELENGKAPAN")
        {
	                    IDictionary<string, object> par = new Dictionary<string, object>();
	        par.Add("KODEKELENGKAPAN", this.Session[strTableName + "_masterkey1"]);
            collection = controller.FetchForDetails(par, OrderBy, OwnerColumn, OwnerID);
            numrows = controller.FetchForDetailsCount(par, OwnerColumn, OwnerID);
        }
    }

    private void InitVariables()
    {
                //	process masterkey value
        mastertable = (string)Request["mastertable"];
        if(!string.IsNullOrEmpty(mastertable))
        {
	        Mastertable = mastertable;
        //	copy keys to session
            int i;
            for(i = 1;; ++ i)
            {
                string masterkeyName = "masterkey" + i.ToString();
                string masterkey = this.Request.Params.Get(masterkeyName);
	            if(masterkey != null)
	            {
		            this.Session[strTableName + "_" + masterkeyName] = masterkey;
	            }
                else
                {
                    break;
                }
            }

	        if(this.Session[strTableName + "_masterkey" + i.ToString()] != null)
            {
		        this.Session.Remove(strTableName + "_masterkey" + i.ToString());
            }
        }
        else
        {
            mastertable = Mastertable;
        }

    }

    private void BuildForm()
    {
        smarty.Add("row_count", numrows);
        int display_count = 0;
        if(numrows > 0)
        {
            smarty.Add("details_data",true);
            	            display_count = 10;
            if(_mode=="inline")
            {
		        display_count*=2;
            }

            if(numrows > display_count + 2)
	        {
		        smarty.Add("display_first", true);
		        smarty.Add("display_count", display_count);
	        }
	        else
            {
		        display_count = numrows;
            }
            IDictionary rowinfo = new Hashtable();
            IList rowinfo_list = new List<object>();
            rowinfo["data"] = rowinfo_list;
            for(int i = 0; i < display_count; ++ i)
            {
                IDictionary row = new Hashtable();
                string keylink="";
		            keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEBPJ.ToString()));
		            keylink +="&key2=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEKELENGKAPAN.ToString()));

                string value="";
                Control control_KODEBPJ = new Control("KODEBPJ", collection[i].KODEBPJ, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                control_KODEBPJ.Value = func.GetLookupValue(control_KODEBPJ.FieldInfo);
			        value=control_KODEBPJ.DisplayLookupWizard();
			        row["KODEBPJ_value"]=value;
                Control control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", collection[i].KODEKELENGKAPAN, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                control_KODEKELENGKAPAN.Value = func.GetLookupValue(control_KODEKELENGKAPAN.FieldInfo);
			        value=control_KODEKELENGKAPAN.DisplayLookupWizard();
			        row["KODEKELENGKAPAN_value"]=value;
                Control control_TANGGALDITERIMA = new Control("TANGGALDITERIMA", collection[i].TANGGALDITERIMA, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_TANGGALDITERIMA.GetData();
			        value = control_TANGGALDITERIMA.ProcessLargeText(value,"field=TANGGALDITERIMA" + keylink,"",MODE.MODE_LIST);
			        row["TANGGALDITERIMA_value"]=value;
                Control control_PENERIMAKELENGKAPAN = new Control("PENERIMAKELENGKAPAN", collection[i].PENERIMAKELENGKAPAN, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_PENERIMAKELENGKAPAN.GetData();
			        value = control_PENERIMAKELENGKAPAN.ProcessLargeText(value,"field=PENERIMAKELENGKAPAN" + keylink,"",MODE.MODE_LIST);
			        row["PENERIMAKELENGKAPAN_value"]=value;
                rowinfo_list.Add(row);
            }
            smarty.Add("details_row",rowinfo);
        }
        else
        {

        }
    }
}
