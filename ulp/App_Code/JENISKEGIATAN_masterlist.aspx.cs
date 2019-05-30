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

public class JENISKEGIATANMasterList
{
    public static string CreateMasterTableInfo(string detailtable, string[] keys, System.Web.UI.Page page)
    {
        string strTableName = "dbo.JENISKEGIATAN";
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
                    (string)System.Web.HttpContext.Current.Session["language"], "dbo_JENISKEGIATAN"));
            }
        }
        IDictionary<string, object> par = new Dictionary<string, object>();
	        keyField = "KODEJENISKEGIATAN";
        par[keyField] = keys[1 - 1];
	        keyField = "KODEJENISKEGIATAN";
        par[keyField] = keys[1 - 1];

        JENISKEGIATANController controller = new JENISKEGIATANController();
        JENISKEGIATAN item = controller.FetchByManyID(par);

	    string keylink = string.Empty;
        if(item != null)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(item.KODEJENISKEGIATAN.ToString()));
        }
        	
        string value="";

        Control control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", item.KODEJENISKEGIATAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEJENISKEGIATAN - 
	                            value = control_KODEJENISKEGIATAN.GetData();
			        value = control_KODEJENISKEGIATAN.ProcessLargeText(value,"field=KODEJENISKEGIATAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODEJENISKEGIATAN_mastervalue",value);

        Control control_DESKRIPSI = new Control("DESKRIPSI", item.DESKRIPSI, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	DESKRIPSI - 
	                            value = control_DESKRIPSI.GetData();
			        value = control_DESKRIPSI.ProcessLargeText(value,"field=DESKRIPSI" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("DESKRIPSI_mastervalue",value);
            return func.BuildOutput(page, @"~\JENISKEGIATAN_masterlist.aspx", smarty);
    }
}
