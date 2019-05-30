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

public class STATUSPBJMasterList
{
    public static string CreateMasterTableInfo(string detailtable, string[] keys, System.Web.UI.Page page)
    {
        string strTableName = "dbo.STATUSPBJ";
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
                    (string)System.Web.HttpContext.Current.Session["language"], "dbo_STATUSPBJ"));
            }
        }
        IDictionary<string, object> par = new Dictionary<string, object>();
	        keyField = "KODESTATUS";
        par[keyField] = keys[1 - 1];

        STATUSPBJController controller = new STATUSPBJController();
        STATUSPBJ item = controller.FetchByManyID(par);

	    string keylink = string.Empty;
        if(item != null)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(item.KODESTATUS.ToString()));
        }
        	
        string value="";

        Control control_KODESTATUS = new Control("KODESTATUS", item.KODESTATUS, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODESTATUS - 
	                            value = control_KODESTATUS.GetData();
			        value = control_KODESTATUS.ProcessLargeText(value,"field=KODESTATUS" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODESTATUS_mastervalue",value);

        Control control_DESKRIPSI = new Control("DESKRIPSI", item.DESKRIPSI, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	DESKRIPSI - 
	                            value = control_DESKRIPSI.GetData();
			        value = control_DESKRIPSI.ProcessLargeText(value,"field=DESKRIPSI" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("DESKRIPSI_mastervalue",value);

        Control control_URUTAN = new Control("URUTAN", item.URUTAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	URUTAN - 
	                            value = control_URUTAN.GetData();
			        value = control_URUTAN.ProcessLargeText(value,"field=URUTAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("URUTAN_mastervalue",value);
            return func.BuildOutput(page, @"~\STATUSPBJ_masterlist.aspx", smarty);
    }
}
