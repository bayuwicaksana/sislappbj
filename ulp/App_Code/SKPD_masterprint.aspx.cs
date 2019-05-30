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

public class SKPDMasterPrint
{
    public static string DisplayMasterTableInfo(string sourcetable, IList<object> masterkeys, System.Web.UI.Page page)
    {
        string strTableName = "SKPD";
        string oldTableName = strTableName;
        string keyField = string.Empty;
        string output = string.Empty;
        Dictionary<string, object> smarty = new Dictionary<string, object>();
        Builder builder = Factory.CreateBuilder();

        smarty.Add("__table", "SKPD");
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
                    "dbo_SKPD"));
            }
        }

	        keyField = "KODESKPD";

        SKPDController controller = new SKPDController();
        SKPDCollection collection = controller.FetchByID(masterkeys[0]);

	    string keylink = string.Empty;
        if(collection != null && collection.Count > 0)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(collection[0].KODESKPD.ToString()));
        }
        	
        string value="";

        Control control_KODESKPD = new Control("KODESKPD", collection[0].KODESKPD, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODESKPD - 
	                            value = control_KODESKPD.GetData();
			        value = control_KODESKPD.ProcessLargeText(value,"field=KODESKPD" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODESKPD_mastervalue",value);

        Control control_DESKRIPSI = new Control("DESKRIPSI", collection[0].DESKRIPSI, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	DESKRIPSI - 
	                            value = control_DESKRIPSI.GetData();
			        value = control_DESKRIPSI.ProcessLargeText(value,"field=DESKRIPSI" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("DESKRIPSI_mastervalue",value);

        Control control_ALAMAT = new Control("ALAMAT", collection[0].ALAMAT, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	ALAMAT - 
	                            value = control_ALAMAT.GetData();
			        value = control_ALAMAT.ProcessLargeText(value,"field=ALAMAT" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("ALAMAT_mastervalue",value);
            return func.BuildOutput(page, @"~\SKPD_masterprint.aspx", smarty);
    }
}
