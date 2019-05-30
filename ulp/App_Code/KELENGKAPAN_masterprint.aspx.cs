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

public class KELENGKAPANMasterPrint
{
    public static string DisplayMasterTableInfo(string sourcetable, IList<object> masterkeys, System.Web.UI.Page page)
    {
        string strTableName = "KELENGKAPAN";
        string oldTableName = strTableName;
        string keyField = string.Empty;
        string output = string.Empty;
        Dictionary<string, object> smarty = new Dictionary<string, object>();
        Builder builder = Factory.CreateBuilder();

        smarty.Add("__table", "KELENGKAPAN");
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
                    "dbo_KELENGKAPAN"));
            }
        }

	        keyField = "KODEKELENGKAPAN";

        KELENGKAPANController controller = new KELENGKAPANController();
        KELENGKAPANCollection collection = controller.FetchByID(masterkeys[0]);

	    string keylink = string.Empty;
        if(collection != null && collection.Count > 0)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(collection[0].KODEKELENGKAPAN.ToString()));
        }
        	
        string value="";

        Control control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", collection[0].KODEKELENGKAPAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEKELENGKAPAN - 
	                            value = control_KODEKELENGKAPAN.GetData();
			        value = control_KODEKELENGKAPAN.ProcessLargeText(value,"field=KODEKELENGKAPAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODEKELENGKAPAN_mastervalue",value);

        Control control_KODEDOKUMEN = new Control("KODEDOKUMEN", collection[0].KODEDOKUMEN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEDOKUMEN - 
	                            control_KODEDOKUMEN.Value = func.GetLookupValue(control_KODEDOKUMEN.FieldInfo);
                    value=control_KODEDOKUMEN.DisplayLookupWizard();
			        smarty.Add("KODEDOKUMEN_mastervalue",value);

        Control control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", collection[0].KODEJENISKEGIATAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEJENISKEGIATAN - 
	                            control_KODEJENISKEGIATAN.Value = func.GetLookupValue(control_KODEJENISKEGIATAN.FieldInfo);
                    value=control_KODEJENISKEGIATAN.DisplayLookupWizard();
			        smarty.Add("KODEJENISKEGIATAN_mastervalue",value);
            return func.BuildOutput(page, @"~\KELENGKAPAN_masterprint.aspx", smarty);
    }
}
