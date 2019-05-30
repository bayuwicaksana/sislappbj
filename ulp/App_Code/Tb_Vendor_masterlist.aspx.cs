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

public class Tb_VendorMasterList
{
    public static string CreateMasterTableInfo(string detailtable, string[] keys, System.Web.UI.Page page)
    {
        string strTableName = "dbo.Tb_Vendor";
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
                    (string)System.Web.HttpContext.Current.Session["language"], "dbo_Tb_Vendor"));
            }
        }
        IDictionary<string, object> par = new Dictionary<string, object>();
	        keyField = "KD_VENDOR";
        par[keyField] = keys[1 - 1];

        Tb_VendorController controller = new Tb_VendorController();
        Tb_Vendor item = controller.FetchByManyID(par);

	    string keylink = string.Empty;
        if(item != null)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(item.KD_VENDOR.ToString()));
        }
        	
        string value="";

        Control control_KD_VENDOR = new Control("KD_VENDOR", item.KD_VENDOR, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KD_VENDOR - 
	                            value = control_KD_VENDOR.GetData();
			        value = control_KD_VENDOR.ProcessLargeText(value,"field=KD%5FVENDOR" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KD_VENDOR_mastervalue",value);

        Control control_NAMA = new Control("NAMA", item.NAMA, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	NAMA - 
	                            value = control_NAMA.GetData();
			        value = control_NAMA.ProcessLargeText(value,"field=NAMA" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("NAMA_mastervalue",value);

        Control control_ALAMAT = new Control("ALAMAT", item.ALAMAT, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	ALAMAT - 
	                            value = control_ALAMAT.GetData();
			        value = control_ALAMAT.ProcessLargeText(value,"field=ALAMAT" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("ALAMAT_mastervalue",value);

        Control control_NPWP = new Control("NPWP", item.NPWP, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	NPWP - 
	                            value = control_NPWP.GetData();
			        value = control_NPWP.ProcessLargeText(value,"field=NPWP" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("NPWP_mastervalue",value);

        Control control_TELEPON = new Control("TELEPON", item.TELEPON, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	TELEPON - 
	                            value = control_TELEPON.GetData();
			        value = control_TELEPON.ProcessLargeText(value,"field=TELEPON" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("TELEPON_mastervalue",value);

        Control control_FAX = new Control("FAX", item.FAX, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	FAX - 
	                            value = control_FAX.GetData();
			        value = control_FAX.ProcessLargeText(value,"field=FAX" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("FAX_mastervalue",value);

        Control control_EMAIL = new Control("EMAIL", item.EMAIL, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	EMAIL - 
	                            value = control_EMAIL.GetData();
			        value = control_EMAIL.ProcessLargeText(value,"field=EMAIL" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("EMAIL_mastervalue",value);

        Control control_STATUS = new Control("STATUS", item.STATUS, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	STATUS - Checkbox
	        			        value = control_STATUS.GetData();
			        smarty.Add("STATUS_mastervalue",value);
            return func.BuildOutput(page, @"~\Tb_Vendor_masterlist.aspx", smarty);
    }
}
