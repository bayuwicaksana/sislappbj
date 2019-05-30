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

public class KELENGKAPANMasterList
{
    public static string CreateMasterTableInfo(string detailtable, string[] keys, System.Web.UI.Page page)
    {
        string strTableName = "dbo.KELENGKAPAN";
        string oldTableName = strTableName;
        string keyField = string.Empty;
        string output = string.Empty;
        Dictionary<string, object> smarty = new Dictionary<string, object>();
        Builder builder = Factory.CreateBuilder();

        smarty.Add("__table", strTableName);
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
                    (string)System.Web.HttpContext.Current.Session["language"], "dbo_KELENGKAPAN"));
            }
        }
        IDictionary<string, object> par = new Dictionary<string, object>();
	        keyField = "KODEKELENGKAPAN";
        par[keyField] = keys[1 - 1];

        KELENGKAPANController controller = new KELENGKAPANController();
        KELENGKAPAN item = controller.FetchByManyID(par);

	    string keylink = string.Empty;
        if(item != null)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(item.KODEKELENGKAPAN.ToString()));
        }
        	
        string value="";

        Control control_KODEKELENGKAPAN = new Control("KODEKELENGKAPAN", item.KODEKELENGKAPAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEKELENGKAPAN - 
	                            value = control_KODEKELENGKAPAN.GetData();
			        value = control_KODEKELENGKAPAN.ProcessLargeText(value,"field=KODEKELENGKAPAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODEKELENGKAPAN_mastervalue",value);

        Control control_KODEDOKUMEN = new Control("KODEDOKUMEN", item.KODEDOKUMEN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEDOKUMEN - 
	                            control_KODEDOKUMEN.Value = func.GetLookupValue(control_KODEDOKUMEN.FieldInfo);
                    value=control_KODEDOKUMEN.DisplayLookupWizard();
			        smarty.Add("KODEDOKUMEN_mastervalue",value);

        Control control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", item.KODEJENISKEGIATAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEJENISKEGIATAN - 
	                            control_KODEJENISKEGIATAN.Value = func.GetLookupValue(control_KODEJENISKEGIATAN.FieldInfo);
                    value=control_KODEJENISKEGIATAN.DisplayLookupWizard();
			        smarty.Add("KODEJENISKEGIATAN_mastervalue",value);
            return func.BuildOutput(page, @"~\KELENGKAPAN_masterlist.aspx", smarty);
    }
}
