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

public partial class CPENGGUNA_Detailspreview : AspNetRunnerPage
{
    string _mode = string.Empty;
    string mastertable = string.Empty;
    int numrows = 0;

    PENGGUNAController controller = new PENGGUNAController();
    PENGGUNACollection collection = new PENGGUNACollection();

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGGUNA";
        strTableNameLocale = "dbo_PENGGUNA";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _mode = (string)Request["mode"];

                CheckSecurity();
        InitVariables();
        GetData();
        BuildForm();
        output.Append(func.BuildOutput(this, @"~\PENGGUNA_Detailspreview.aspx", smarty));
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
        if(mastertable=="KELOMPOKPENGGUNA")
        {
	                    IDictionary<string, object> par = new Dictionary<string, object>();
	        par.Add("KODEKELOMPOK", this.Session[strTableName + "_masterkey1"]);
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
		            keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(collection[i].KODEPENGGUNA.ToString()));

                string value="";
                Control control_KODEPENGGUNA = new Control("KODEPENGGUNA", collection[i].KODEPENGGUNA, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_KODEPENGGUNA.GetData();
			        value = control_KODEPENGGUNA.ProcessLargeText(value,"field=KODEPENGGUNA" + keylink,"",MODE.MODE_LIST);
			        row["KODEPENGGUNA_value"]=value;
                Control control_NAMA = new Control("NAMA", collection[i].NAMA, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_NAMA.GetData();
			        value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
			        row["NAMA_value"]=value;
                Control control_KATAKUNCI = new Control("KATAKUNCI", collection[i].KATAKUNCI, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                value = control_KATAKUNCI.GetData();
			        value = control_KATAKUNCI.ProcessLargeText(value,"field=KATAKUNCI" + keylink,"",MODE.MODE_LIST);
			        row["KATAKUNCI_value"]=value;
                Control control_KODEKELOMPOK = new Control("KODEKELOMPOK", collection[i].KODEKELOMPOK, false, smarty, this.Request, builder, MODE.MODE_PRINT);
	                                control_KODEKELOMPOK.Value = func.GetLookupValue(control_KODEKELOMPOK.FieldInfo);
			        value=control_KODEKELOMPOK.DisplayLookupWizard();
			        row["KODEKELOMPOK_value"]=value;
                rowinfo_list.Add(row);
            }
            smarty.Add("details_row",rowinfo);
        }
        else
        {

        }
    }
}
