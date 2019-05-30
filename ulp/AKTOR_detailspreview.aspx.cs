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

public partial class CAKTOR_Detailspreview : AspNetRunnerPage
{
    string _mode = string.Empty;
    string mastertable = string.Empty;
    int numrows = 0;

    AKTORController controller = new AKTORController();
    AKTORCollection collection = new AKTORCollection();

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.AKTOR";
        strTableNameLocale = "dbo_AKTOR";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _mode = (string)Request["mode"];

                CheckSecurity();
        InitVariables();
        GetData();
        BuildForm();
        output.Append(func.BuildOutput(this, @"~\AKTOR_Detailspreview.aspx", smarty));
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
        if(mastertable=="TIPEAKTOR")
        {
	                    IDictionary<string, object> par = new Dictionary<string, object>();
	        par.Add("KODETIPE", this.Session[strTableName + "_masterkey1"]);
            collection = controller.FetchForDetails(par, OrderBy, OwnerColumn, OwnerID);
            numrows = controller.FetchForDetailsCount(par, OwnerColumn, OwnerID);
        }
        if(mastertable=="JABATANAKTOR")
        {
	                    IDictionary<string, object> par = new Dictionary<string, object>();
	        par.Add("KODEJABATAN", this.Session[strTableName + "_masterkey1"]);
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
		            keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].NIP.ToString()));

                string value="";
                Control control_NIP = new Control("NIP", collection[i].NIP, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_NIP.GetData();
			        value = control_NIP.ProcessLargeText(value,"field=NIP" + keylink,"",MODE.MODE_LIST);
			        row["NIP_value"]=value;
                Control control_NAMA = new Control("NAMA", collection[i].NAMA, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_NAMA.GetData();
			        value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
			        row["NAMA_value"]=value;
                Control control_KODEJABATAN = new Control("KODEJABATAN", collection[i].KODEJABATAN, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                control_KODEJABATAN.Value = func.GetLookupValue(control_KODEJABATAN.FieldInfo);
			        value=control_KODEJABATAN.DisplayLookupWizard();
			        row["KODEJABATAN_value"]=value;
                Control control_KODETIPE = new Control("KODETIPE", collection[i].KODETIPE, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                control_KODETIPE.Value = func.GetLookupValue(control_KODETIPE.FieldInfo);
			        value=control_KODETIPE.DisplayLookupWizard();
			        row["KODETIPE_value"]=value;
                rowinfo_list.Add(row);
            }
            smarty.Add("details_row",rowinfo);
        }
        else
        {

        }
    }
}
