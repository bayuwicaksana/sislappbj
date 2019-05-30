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

public class JABATANAKTORMasterPrint
{
    public static string DisplayMasterTableInfo(string sourcetable, IList<object> masterkeys, System.Web.UI.Page page)
    {
        string strTableName = "JABATANAKTOR";
        string oldTableName = strTableName;
        string keyField = string.Empty;
        string output = string.Empty;
        Dictionary<string, object> smarty = new Dictionary<string, object>();
        Builder builder = Factory.CreateBuilder();

        smarty.Add("__table", "JABATANAKTOR");
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
                    "dbo_JABATANAKTOR"));
            }
        }

	        keyField = "KODEJABATAN";

        JABATANAKTORController controller = new JABATANAKTORController();
        JABATANAKTORCollection collection = controller.FetchByID(masterkeys[0]);

	    string keylink = string.Empty;
        if(collection != null && collection.Count > 0)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(collection[0].KODEJABATAN.ToString()));
        }
        	
        string value="";

        Control control_KODEJABATAN = new Control("KODEJABATAN", collection[0].KODEJABATAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEJABATAN - 
	                            value = control_KODEJABATAN.GetData();
			        value = control_KODEJABATAN.ProcessLargeText(value,"field=KODEJABATAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODEJABATAN_mastervalue",value);

        Control control_DESKRIPSI = new Control("DESKRIPSI", collection[0].DESKRIPSI, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	DESKRIPSI - 
	                            value = control_DESKRIPSI.GetData();
			        value = control_DESKRIPSI.ProcessLargeText(value,"field=DESKRIPSI" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("DESKRIPSI_mastervalue",value);
            return func.BuildOutput(page, @"~\JABATANAKTOR_masterprint.aspx", smarty);
    }
}
