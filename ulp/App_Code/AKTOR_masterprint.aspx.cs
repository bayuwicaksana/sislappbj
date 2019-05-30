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
using System.Web;
using System.Xml;

public class AKTORMasterPrint
{
    public static string DisplayMasterTableInfo(string sourcetable, IList<object> masterkeys, System.Web.UI.Page page)
    {
        string strTableName = "AKTOR";
        string oldTableName = strTableName;
        string keyField = string.Empty;
        string output = string.Empty;
        Dictionary<string, object> smarty = new Dictionary<string, object>();
        Builder builder = Factory.CreateBuilder();

        smarty.Add("__table", "AKTOR");
            string sCulture = ConfigurationManager.AppSettings["LCID"];
            if (!String.IsNullOrEmpty(sCulture)) 
            {
                int nCulture = int.Parse(sCulture);
                smarty.Add("LCID", nCulture);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(nCulture, false);
            } 
                if(System.Web.HttpContext.Current.Session["locale_xml"] != null)
        {
            smarty.Add("Captions", AspNetRunnerPage.GetTableCaptions((XmlNode)System.Web.HttpContext.Current.Session["locale_xml"], 
                (string)System.Web.HttpContext.Current.Session["language"]));
            if(!string.IsNullOrEmpty(strTableName))
            {
                smarty.Add("Labels", AspNetRunnerPage.GetFieldCaptions((XmlNode)System.Web.HttpContext.Current.Session["locale_xml"], 
                    (string)System.Web.HttpContext.Current.Session["language"], 
                    "dbo_AKTOR"));
            }
        }

	        keyField = "NIP";
	        keyField = "NIP";

        AKTORController controller = new AKTORController();
        AKTORCollection collection = controller.FetchByID(masterkeys[0]);

	    string keylink = string.Empty;
        if(collection != null && collection.Count > 0)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(collection[0].NIP.ToString()));
        }
        	
        string value="";

        Control control_NIP = new Control("NIP", collection[0].NIP, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	NIP - 
	                            value = control_NIP.GetData();
			        value = control_NIP.ProcessLargeText(value,"field=NIP" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("NIP_mastervalue",value);

        Control control_NAMA = new Control("NAMA", collection[0].NAMA, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	NAMA - 
	                            value = control_NAMA.GetData();
			        value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("NAMA_mastervalue",value);

        Control control_KODEJABATAN = new Control("KODEJABATAN", collection[0].KODEJABATAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEJABATAN - 
	                            control_KODEJABATAN.Value = func.GetLookupValue(control_KODEJABATAN.FieldInfo);
                    value=control_KODEJABATAN.DisplayLookupWizard();
			        smarty.Add("KODEJABATAN_mastervalue",value);

        Control control_KODETIPE = new Control("KODETIPE", collection[0].KODETIPE, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODETIPE - 
	                            control_KODETIPE.Value = func.GetLookupValue(control_KODETIPE.FieldInfo);
                    value=control_KODETIPE.DisplayLookupWizard();
			        smarty.Add("KODETIPE_mastervalue",value);
            return func.BuildOutput(page, @"~\AKTOR_masterprint.aspx", smarty);
    }
}
