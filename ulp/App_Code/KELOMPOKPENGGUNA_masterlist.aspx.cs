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

public class KELOMPOKPENGGUNAMasterList
{
    public static string CreateMasterTableInfo(string detailtable, string[] keys, System.Web.UI.Page page)
    {
        string strTableName = "dbo.KELOMPOKPENGGUNA";
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
                    (string)System.Web.HttpContext.Current.Session["language"], "dbo_KELOMPOKPENGGUNA"));
            }
        }
        IDictionary<string, object> par = new Dictionary<string, object>();
	        keyField = "KODEKELOMPOK";
        par[keyField] = keys[1 - 1];

        KELOMPOKPENGGUNAController controller = new KELOMPOKPENGGUNAController();
        KELOMPOKPENGGUNA item = controller.FetchByManyID(par);

	    string keylink = string.Empty;
        if(item != null)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(item.KODEKELOMPOK.ToString()));
        }
        	
        string value="";

        Control control_KODEKELOMPOK = new Control("KODEKELOMPOK", item.KODEKELOMPOK, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEKELOMPOK - 
	                            value = control_KODEKELOMPOK.GetData();
			        value = control_KODEKELOMPOK.ProcessLargeText(value,"field=KODEKELOMPOK" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODEKELOMPOK_mastervalue",value);

        Control control_DESKRIPSI = new Control("DESKRIPSI", item.DESKRIPSI, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	DESKRIPSI - 
	                            value = control_DESKRIPSI.GetData();
			        value = control_DESKRIPSI.ProcessLargeText(value,"field=DESKRIPSI" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("DESKRIPSI_mastervalue",value);
            return func.BuildOutput(page, @"~\KELOMPOKPENGGUNA_masterlist.aspx", smarty);
    }
}
