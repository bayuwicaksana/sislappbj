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

public partial class CKELENGKAPAN_Detailspreview : AspNetRunnerPage
{
    string _mode = string.Empty;
    string mastertable = string.Empty;
    int numrows = 0;

    KELENGKAPANController controller = new KELENGKAPANController();
    KELENGKAPANCollection collection = new KELENGKAPANCollection();

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.KELENGKAPAN";
        strTableNameLocale = "dbo_KELENGKAPAN";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _mode = (string)Request["mode"];

                CheckSecurity();
        InitVariables();
        GetData();
        BuildForm();
        output.Append(func.BuildOutput(this, @"~\KELENGKAPAN_Detailspreview.aspx", smarty));
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
        if(mastertable=="JENISKEGIATAN")
        {
	                    IDictionary<string, object> par = new Dictionary<string, object>();
	        par.Add("KODEJENISKEGIATAN", this.Session[strTableName + "_masterkey1"]);
            collection = controller.FetchForDetails(par, OrderBy, OwnerColumn, OwnerID);
            numrows = controller.FetchForDetailsCount(par, OwnerColumn, OwnerID);
        }
        if(mastertable=="DOKUMEN")
        {
	                    IDictionary<string, object> par = new Dictionary<string, object>();
	        par.Add("KODEDOKUMEN", this.Session[strTableName + "_masterkey1"]);
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
		            keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEKELENGKAPAN.ToString()));

                string value="";
                Control control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", collection[i].KODEKELENGKAPAN, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_KODEKELENGKAPAN.GetData();
			        value = control_KODEKELENGKAPAN.ProcessLargeText(value,"field=KODEKELENGKAPAN" + keylink,"",MODE.MODE_LIST);
			        row["KODEKELENGKAPAN_value"]=value;
                Control control_KODEDOKUMEN = new Control("KODEDOKUMEN", collection[i].KODEDOKUMEN, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                control_KODEDOKUMEN.Value = func.GetLookupValue(control_KODEDOKUMEN.FieldInfo);
			        value=control_KODEDOKUMEN.DisplayLookupWizard();
			        row["KODEDOKUMEN_value"]=value;
                Control control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", collection[i].KODEJENISKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                control_KODEJENISKEGIATAN.Value = func.GetLookupValue(control_KODEJENISKEGIATAN.FieldInfo);
			        value=control_KODEJENISKEGIATAN.DisplayLookupWizard();
			        row["KODEJENISKEGIATAN_value"]=value;
                rowinfo_list.Add(row);
            }
            smarty.Add("details_row",rowinfo);
        }
        else
        {

        }
    }
}
