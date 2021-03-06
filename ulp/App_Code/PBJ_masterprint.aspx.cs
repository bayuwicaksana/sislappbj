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

public class PBJMasterPrint
{
    public static string DisplayMasterTableInfo(string sourcetable, IList<object> masterkeys, System.Web.UI.Page page)
    {
        string strTableName = "PBJ";
        string oldTableName = strTableName;
        string keyField = string.Empty;
        string output = string.Empty;
        Dictionary<string, object> smarty = new Dictionary<string, object>();
        Builder builder = Factory.CreateBuilder();

        smarty.Add("__table", "PBJ");
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
                    "dbo_PBJ"));
            }
        }

	        keyField = "KODEPBJ";
	        keyField = "KODEPBJ";

        PBJController controller = new PBJController();
        PBJCollection collection = controller.FetchByID(masterkeys[0]);

	    string keylink = string.Empty;
        if(collection != null && collection.Count > 0)
        {
	    keylink += "&key1=" + Control.HTMLEncodeSpecialChars(HttpUtility.UrlEncode(collection[0].KODEPBJ.ToString()));
        }
        	
        string value="";

        Control control_KODEPBJ = new Control("KODEPBJ", collection[0].KODEPBJ, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEPBJ - 
	                            value = control_KODEPBJ.GetData();
			        value = control_KODEPBJ.ProcessLargeText(value,"field=KODEPBJ" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("KODEPBJ_mastervalue",value);

        Control control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", collection[0].NAMAKEGIATAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	NAMAKEGIATAN - 
	                            value = control_NAMAKEGIATAN.GetData();
			        value = control_NAMAKEGIATAN.ProcessLargeText(value,"field=NAMAKEGIATAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("NAMAKEGIATAN_mastervalue",value);

        Control control_NAMAPAKET = new Control("NAMAPAKET", collection[0].NAMAPAKET, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	NAMAPAKET - 
	                            value = control_NAMAPAKET.GetData();
			        value = control_NAMAPAKET.ProcessLargeText(value,"field=NAMAPAKET" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("NAMAPAKET_mastervalue",value);

        Control control_KODESKPD = new Control("KODESKPD", collection[0].KODESKPD, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODESKPD - 
	                            control_KODESKPD.Value = func.GetLookupValue(control_KODESKPD.FieldInfo);
                    value=control_KODESKPD.DisplayLookupWizard();
			        smarty.Add("KODESKPD_mastervalue",value);

        Control control_PPK = new Control("PPK", collection[0].PPK, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	PPK - 
	                            control_PPK.Value = func.GetLookupValue(control_PPK.FieldInfo);
                    value=control_PPK.DisplayLookupWizard();
			        smarty.Add("PPK_mastervalue",value);

        Control control_PPTK = new Control("PPTK", collection[0].PPTK, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	PPTK - 
	                            control_PPTK.Value = func.GetLookupValue(control_PPTK.FieldInfo);
                    value=control_PPTK.DisplayLookupWizard();
			        smarty.Add("PPTK_mastervalue",value);

        Control control_KODEJENISKEGIATAN = new Control("KODEJENISKEGIATAN", collection[0].KODEJENISKEGIATAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODEJENISKEGIATAN - 
	                            control_KODEJENISKEGIATAN.Value = func.GetLookupValue(control_KODEJENISKEGIATAN.FieldInfo);
                    value=control_KODEJENISKEGIATAN.DisplayLookupWizard();
			        smarty.Add("KODEJENISKEGIATAN_mastervalue",value);

        Control control_TANGGALPENGAJUAN = new Control("TANGGALPENGAJUAN", collection[0].TANGGALPENGAJUAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	TANGGALPENGAJUAN - Short Date
	                            value = control_TANGGALPENGAJUAN.GetData();
			        value = control_TANGGALPENGAJUAN.ProcessLargeText(value,"field=TANGGALPENGAJUAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("TANGGALPENGAJUAN_mastervalue",value);

        Control control_LENGKAP = new Control("LENGKAP", collection[0].LENGKAP, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	LENGKAP - 
	                            value = control_LENGKAP.GetData();
			        value = control_LENGKAP.ProcessLargeText(value,"field=LENGKAP" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("LENGKAP_mastervalue",value);

        Control control_DIKEMBALIKAN = new Control("DIKEMBALIKAN", collection[0].DIKEMBALIKAN, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	DIKEMBALIKAN - 
	                            value = control_DIKEMBALIKAN.GetData();
			        value = control_DIKEMBALIKAN.ProcessLargeText(value,"field=DIKEMBALIKAN" + keylink,"",MODE.MODE_LIST);
			        smarty.Add("DIKEMBALIKAN_mastervalue",value);

        Control control_KODESTATUSPBJ = new Control("KODESTATUSPBJ", collection[0].KODESTATUSPBJ, false, smarty, page.Request, builder, MODE.MODE_LIST);
        //	KODESTATUSPBJ - 
	                            control_KODESTATUSPBJ.Value = func.GetLookupValue(control_KODESTATUSPBJ.FieldInfo);
                    value=control_KODESTATUSPBJ.DisplayLookupWizard();
			        smarty.Add("KODESTATUSPBJ_mastervalue",value);
            return func.BuildOutput(page, @"~\PBJ_masterprint.aspx", smarty);
    }
}
